using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UpdateMyList.Common;
using UpdateMyList.Entity;
using UpdateMyList.Entity.Model;

namespace UpdateMyList.Forms
{
    public partial class MyListForm : Form
    {
        private readonly IUnitOfWork _uow;
        private ListTypeModel _model;
        private int myListId { get; set; }
        private string IU_Flag { get; set; }
        private bool? rePageFlag { get; set; }
        private string lstStsSelecet { get; set; }
        private bool? clear { get; set; }
        private string similar { get; set; }
        private int? takeData { get; set; }
        private string sortCode { get; set; } = "Descending";
        private string sortName { get; set; } = "Descending";
        private string sortUpdateDate { get; set; } = "Descending";
        private int pageCount { get; set; } = 1;
        private int totalCount { get; set; }
        private int totalCountAfterFilter { get; set; }
        private int pageSelect { get; set; } = 1;
        private int countData { get; set; } = 0;
        private List<GenreModel> genres { get; set; }
        private List<SeasonMastModel> seasons { get; set; }
        private List<MyListModel> myLists { get; set; }
        private ConfigMyList config { get; set; }
        private List<int> selectGen { get; set; } = new List<int>();
        public void ClearPage(bool allData)
        {
            this.myLists = new List<MyListModel>();
            var reFlag = this.rePageFlag ?? true;
            this.IU_Flag = this.IU_Flag ?? "I";
            var cleaFlag = this.clear ?? false;
            if (reFlag || !this.IU_Flag.Equals("U"))
            {
                this.myListId = 0;
                this.IU_Flag = "";
                this.nametxt.Text = "";
                this.ePtxt.Text = "";
                this.eplasttxt.Text = "";
                this.linkUrltxt.Text = "";
                this.commenttxt.Text = "";
                this.stscbb.SelectedIndex = 0;
                this.stslastcbb.SelectedIndex = 0;
                this.similar = "";
                this.searchGenTxt.Text = "";
                this.searchSeaTxt.Text = "";
                this.gobtn.Enabled = false;
                this.deletebtn.Enabled = false;
                this.seasoncbb.SelectedIndex = 0;
                this.selectGen = new List<int>();
                ClearSelection();
                this.myListtap.SelectedTab = listtap;
            }
            if (cleaFlag)
            {
                this.stslb.ClearSelected();
                this.stslb.SelectedIndex = 0;

                this.stslastlb.ClearSelected();
                this.stslastlb.SelectedIndex = 0;

                this.seasonlb.ClearSelected();
                this.seasonlb.SelectedIndex = 0;

                this.genrelb.ClearSelected();
                this.genrelb.SelectedIndex = 0;

                this.notincb.Checked = false;
                this.notincb.Enabled = false;

                this.nonrdb.Checked = true;

                this.searchtxt.Text = "";
                this.clear = false;
            }
            if (allData)
            {
                this.myLists = _uow.MyListRepository.SelectByType(_model);
                search();
            }
            this.rePageFlag = true;

        }
        public MyListForm(IUnitOfWork uow, ListTypeModel model)
        {
            InitializeComponent();
            this.Text = $"MyList{model.listTypeDesc}";
            this._uow = uow;
            this._model = model;
        }

        private int saveData()
        {
            var rs = 0;
            if (this.IU_Flag == "U")
            {
                var data = _uow.MyListRepository.ReadById(this.myListId);
                data.listId = this.myListId;
                data.listName = this.nametxt.Text;
                data.listLink = this.linkUrltxt.Text;
                data.listEP = this.ePtxt.Text;
                data.listEPLast = this.eplasttxt.Text;
                data.listComment = this.commenttxt.Text;
                data.stsId = Convert.ToInt32(this.stscbb.SelectedValue);
                data.stsIdLast = Convert.ToInt32(this.stslastcbb.SelectedValue);
                data.seaId = Convert.ToInt32(this.seasoncbb.SelectedValue);
                data.updateBy = Constants.UserApp;
                data.updateDate = DateTime.Now;
                _uow.Save();
                rs = data.listId;
            }
            else
            {
                var data = new MyListMast
                {
                    listTypeId = this._model.listTypeId,
                    listCode = _uow.MyListRepository.GetMaxCodeByType(this._model.listTypeId),
                    listName = this.nametxt.Text,
                    listLink = this.linkUrltxt.Text,
                    listEP = this.ePtxt.Text,
                    listEPLast = this.eplasttxt.Text,
                    listComment = this.commenttxt.Text,
                    stsId = Convert.ToInt32(this.stscbb.SelectedValue),
                    stsIdLast = Convert.ToInt32(this.stslastcbb.SelectedValue),
                    seaId = Convert.ToInt32(this.seasoncbb.SelectedValue),
                    recStatus = RecStatus.Active,
                    createBy = Constants.UserApp,
                    createDate = DateTime.Now,
                    updateDate = DateTime.Now
                };
                rs = (_uow.MyListRepository.ReadByCreate(data)).listId;
            }

            foreach (var genre in this.genres)
            {
                var genreGroup = new GenreGroupModel();
                if (this.selectGen.Contains(genre.genreId))
                {
                    genreGroup = _uow.GenreGroupRepository.SelectGenreGroupByListId(this.myListId).FirstOrDefault(p => p.genId == genre.genreId);
                    if (genreGroup == null)
                    {
                        var genGroupClose = _uow.GenreGroupRepository.SelectGenreGroupByListIdButClose(this.myListId).FirstOrDefault(p => p.genId == genre.genreId);
                        if (genGroupClose is null)
                        {
                            var genGroup = new GenreGroup
                            {
                                genId = genre.genreId,
                                listId = rs,
                                recStatus = RecStatus.Active,
                                createBy = Constants.UserApp,
                                createDate = DateTime.Now
                            };
                            _uow.GenreGroupRepository.Create(genGroup);
                            _uow.Save();
                        }
                        else
                        {
                            var genGroup = _uow.GenreGroupRepository.ReadById(genGroupClose.gengroupId);
                            genGroup.genId = genGroupClose.genId;
                            genGroup.listId = genGroupClose.listId;
                            genGroup.recStatus = RecStatus.Active;
                            genGroup.updateBy = Constants.UserApp;
                            genGroup.updateDate = DateTime.Now;
                            _uow.Save();
                        }
                    }
                }
                else
                {
                    genreGroup = _uow.GenreGroupRepository.SelectGenreGroupByListId(this.myListId).FirstOrDefault(p => p.genId == genre.genreId);
                    if (genreGroup != null)
                    {
                        var genGroup = _uow.GenreGroupRepository.ReadById(genreGroup.gengroupId);
                        genGroup.gengroupId = genreGroup.gengroupId;
                        genGroup.genId = genre.genreId;
                        genGroup.listId = rs;
                        genGroup.recStatus = RecStatus.Close;
                        genGroup.updateBy = Constants.UserApp;
                        genGroup.updateDate = DateTime.Now;
                        _uow.Save();
                    }
                }
            }
            return rs;
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.nametxt.Text))
            {
                if (!string.IsNullOrEmpty(this.ePtxt.Text))
                {
                    if (!string.IsNullOrEmpty(this.linkUrltxt.Text))
                    {
                        var result = 0;
                        this.IU_Flag = this.IU_Flag ?? "I";

                        if (this.config?.IsSimilar ?? false)
                        {
                            var chkContain = CheckContainByName(this.nametxt.Text);
                            if (chkContain && !this.IU_Flag.Equals("U"))
                            {
                                if (MessageBox.Show("มีชื่อเรื่องที่คล้ายกันอยู่คือ " + this.similar + "ต้องการทำรายการต่อหรือไม่ ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    result = saveData();
                                    if (result > 0)
                                    {
                                        ClearPage(true);
                                    }
                                }
                            }
                            else
                            {
                                result = saveData();
                                if (result > 0)
                                {
                                    ClearPage(true);
                                }
                            }
                        }
                        else
                        {
                            result = saveData();
                            if (result > 0)
                            {
                                ClearPage(true);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("ใส่ Link ด้วย", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("ใส่ตอนด้วย", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("ใส่ชื่อเรื่องด้วย", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void MyListForm_Load(object sender, EventArgs e)
        {
            //this.editbtn.Visible = false;
            //this.reloadbtn.Visible = false;
            this.config = _uow.ConfigMyListRepository.Read().FirstOrDefault();
            var dataPerPage = this.config.DataPerPage ?? 0;
            if (dataPerPage == 0)
            {
                this.allrbtn.PerformClick();
            }
            else if (dataPerPage == 10)
            {
                this.tenrbtn.PerformClick();
            }
            else if (dataPerPage == 50)
            {
                this.fiftyrbtn.PerformClick();
            }
            else if (dataPerPage == 100)
            {
                this.hunrbtn.PerformClick();
            }

            this.deletebtn.Enabled = false;

            this.dataGridView1.ReadOnly = true;

            this.nonrdb.Checked = true;

            this.stslb.DataSource = _uow.StsMastRepository.SelectAll();
            this.stslb.DisplayMember = "stsDesc";
            this.stslb.ValueMember = "stsId";

            this.stslastlb.DataSource = _uow.StsMastRepository.SelectAll();
            this.stslastlb.DisplayMember = "stsDesc";
            this.stslastlb.ValueMember = "stsId";

            this.stscbb.DataSource = _uow.StsMastRepository.Select();
            this.stscbb.DisplayMember = "stsDesc";
            this.stscbb.ValueMember = "stsId";

            this.stslastcbb.DataSource = _uow.StsMastRepository.Select();
            this.stslastcbb.DisplayMember = "stsDesc";
            this.stslastcbb.ValueMember = "stsId";

            this.genres = _uow.GenreMastRepository.Select();
            this.genreclb.DataSource = this.genres;
            this.genreclb.DisplayMember = "genreDisplay";
            this.genreclb.ValueMember = "genreId";

            this.genrelb.DataSource = _uow.GenreMastRepository.SelectAll();
            this.genrelb.DisplayMember = "genreDisplay";
            this.genrelb.ValueMember = "genreId";

            this.seasons = _uow.SeasonMastRepository.Select(this._model.listTypeId);
            this.seasoncbb.DataSource = this.seasons;
            this.seasoncbb.DisplayMember = "seaDesc";
            this.seasoncbb.ValueMember = "seaId";

            this.seasonlb.DataSource = _uow.SeasonMastRepository.SelectAll(this._model.listTypeId);
            this.seasonlb.DisplayMember = "seaDesc";
            this.seasonlb.ValueMember = "seaId";

            this.myLists = _uow.MyListRepository.SelectByType(_model);
            search();
            CalPage();
        }
        private void search()
        {
            this.dataGridView1.DataSource = null;
            var stsLb = this.stslb.SelectedItems.Cast<StsMastModel>().ToList();
            var stsLbSelect = stsLb?.Select(p => p.stsId).ToList();

            var stsLbLast = this.stslastlb.SelectedItems.Cast<StsMastModel>().ToList();
            var stsLbLastSelect = stsLbLast?.Select(p => p.stsId).ToList();

            var chkSelectSts = stsLbSelect?.Sum() ?? 0;
            var chkSelectStsLast = stsLbLastSelect?.Sum() ?? 0;

            var seasonLb = this.seasonlb.SelectedItems.Cast<SeasonMastModel>().ToList();
            var seasonLbSelect = seasonLb?.Select(p => p.seaId).ToList();
            var chkSelectSeason = seasonLbSelect?.Sum() ?? 0;

            var genreLb = this.genrelb.SelectedItems.Cast<GenreModel>().ToList();
            var genreLbSelect = genreLb?.Select(p => p.genreId).ToList();
            var chkSelectGen = genreLbSelect?.Sum() ?? 0;

            var notincb = this.notincb.Checked;

            var stsNotEqrdb = this.stsnoteqrdb.Checked;
            var stsEqrdb = this.stseqrdb.Checked;

            var searchName = this.searchtxt.Text.ToUpper();
            if (_model != null)
            {
                var getByType = this.myLists;
                //var config = _uow.ConfigMyListRepository.Read().FirstOrDefault();
                var sortmode = this.config.sortmode.Split(',');
                var sortcolumn = sortmode.Length == 2 ? sortmode[0] : "";
                var sortorder = sortmode.Length == 2 ? sortmode[1] : "";
                if (getByType != null)
                {
                    if (sortcolumn.Contains("ID"))
                    {
                        if (sortorder.Contains("ASC"))
                        {
                            getByType = getByType.OrderBy(o => o.listId).ToList();
                        }
                        else if (sortorder.Contains("DESC"))
                        {
                            getByType = getByType.OrderByDescending(o => o.listId).ToList();
                        }
                    }
                    else if (sortcolumn.Contains("DATE"))
                    {
                        if (sortorder.Contains("ASC"))
                        {
                            getByType = getByType.OrderBy(o => o.updateDate).ToList();
                        }
                        else if (sortorder.Contains("DESC"))
                        {
                            getByType = getByType.OrderByDescending(o => o.updateDate).ToList();
                        }
                    }
                    this.totalCount = getByType.Count;
                    if (chkSelectSts > 0)
                    {
                        getByType = getByType.Where(p => stsLbSelect.Contains(p.stsId)).ToList();
                    }
                    if (chkSelectStsLast > 0)
                    {
                        getByType = getByType.Where(p => stsLbLastSelect.Contains(p.stsIdLast ?? 0)).ToList();
                    }
                    if (chkSelectSeason > 0)
                    {
                        getByType = getByType.Where(p => seasonLbSelect.Contains(p.seaId ?? 0)).ToList();
                    }
                    if (chkSelectGen > 0)
                    {
                        var genreGroup = _uow.GenreGroupRepository.SelectGenreGroupBygenIdMany(genreLbSelect).Select(a => a.listId).ToList();
                        if (notincb)
                        {
                            getByType = getByType.Where(p => !genreGroup.Contains(p.listId)).ToList();
                        }
                        else
                        {
                            getByType = getByType.Where(p => genreGroup.Contains(p.listId)).ToList();
                        }
                    }
                    if (stsNotEqrdb)
                    {
                        getByType = getByType.Where(p => p.listEP != (p.listEPLast ?? string.Empty)).ToList();
                    }
                    if (stsEqrdb)
                    {
                        getByType = getByType.Where(p => p.listEP == (p.listEPLast ?? string.Empty)).ToList();
                    }
                    if (!string.IsNullOrEmpty(searchName))
                    {
                        //var splitSearchName = searchName.Split(Constants.delimiterChars).ToList();
                        //if (splitSearchName.Count > 0)
                        //{
                        //    splitSearchName = splitSearchName.Where(p => !string.IsNullOrWhiteSpace(p)).ToList();
                        //    if (splitSearchName.Count > 0)
                        //    {
                        //        var tempData = new List<MyListModel>();
                        //        splitSearchName.ForEach(item => tempData.AddRange(getByType.Where(p => p.listName.ToUpper().Contains(item.ToUpper())).ToList()));
                        //        getByType = tempData;
                        //    }
                        //    else
                        //    {
                        //        getByType = getByType.Where(p => p.listName.ToUpper().Contains(searchName)).ToList();
                        //    }
                        //}
                        //else
                        //{
                        getByType = getByType.Where(p => p.listName.ToUpper().Contains(searchName)).ToList();
                        //}
                    }
                    this.totalCountAfterFilter = getByType.Count;
                    if (this.pageSelect > 1)
                    {
                        var skip = (this.takeData ?? 0) * (pageSelect - 1);
                        getByType = getByType.Skip(skip).ToList();
                    }
                    this.countData = getByType.Count;
                    if (this.takeData != null)
                    {
                        if (this.takeData > 0)
                        {
                            getByType = getByType.Take(this.takeData.Value).ToList();
                        }
                    }

                    this.setDataGrid(getByType);
                }
            }
        }
        private void setDataGrid(List<MyListModel> lstModel)
        {
            try
            {
                var genreGroup = _uow.GenreGroupRepository.SelectGenreGroupByListIdMany(lstModel.Select(a => a.listId).ToList());
                var preData = (from a in lstModel
                               select new DataGridViewModel
                               {
                                   listCode = a.listCode,
                                   listName = a.listName,
                                   listLink = a.listLink,
                                   stsDesc =
                                    !string.IsNullOrEmpty(a.stsDescLast) ?
                                    $"{(a.stsDesc.Length > 10 ? $"{a.stsDesc.Substring(0, 10).Split('/')[0]}..." : a.stsDesc)} / {(a.stsDescLast.Length > 10 ? $"{a.stsDescLast.Substring(0, 10).Split('/')[0]}..." : a.stsDescLast)}"
                                    : a.stsDesc,
                                   listEP = $"{a.listEP.PadLeft(7, ' ')}  {a.listEPLast.PadLeft(10, ' ')}",
                                   seaDesc = a.seaDesc,
                                   genreDesc = string.Join(",", genreGroup.Where(p => p.listId == a.listId).Select(o => o.genCode).OrderBy(o => o).ToList()),
                                   updateDateStr = a.updateDateStr
                               }).ToList();
                this.dataGridView1.DataSource = preData;
                this.dataGridView1.Columns[0].HeaderText = "ID";
                this.dataGridView1.Columns[0].Width = 50;
                this.dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[1].HeaderText = "ชื่อเรื่อง";
                this.dataGridView1.Columns[1].Width = 320;
                this.dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[2].HeaderText = "Link";
                this.dataGridView1.Columns[2].Width = 355;
                this.dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[3].HeaderText = "สถานะ";
                this.dataGridView1.Columns[3].Width = 130;
                this.dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[4].HeaderText = "EP";
                this.dataGridView1.Columns[4].Width = 100;
                this.dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                if (this._model.listTypeCode.Equals(TypeValue.Manga))
                {
                    this.dataGridView1.Columns[5].HeaderText = "Comic Group";
                    this.label7.Text = "Comic Group";
                }
                else if (this._model.listTypeCode.Equals(TypeValue.Serie))
                {
                    this.dataGridView1.Columns[5].HeaderText = "Serie Group";
                    this.label7.Text = "Serie Group";
                }
                else if (this._model.listTypeCode.Equals(TypeValue.Anime))
                {
                    this.dataGridView1.Columns[5].HeaderText = "Seasonal";
                }
                else
                {
                    this.dataGridView1.Columns[5].HeaderText = "Release";
                    this.label7.Text = "Release";
                }
                this.dataGridView1.Columns[5].Width = 125;
                this.dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[6].HeaderText = "Genre";
                this.dataGridView1.Columns[6].Width = 250;
                this.dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[7].HeaderText = "แก้ไขล่าสุด";
                this.dataGridView1.Columns[7].Width = 125;
                this.dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var maxDataInPage = this.takeData is null ? this.countData : this.countData < this.takeData ? this.countData : this.takeData;
                if (string.IsNullOrEmpty(this.searchtxt.Text) && this.stslb.SelectedIndex == 0 && this.seasonlb.SelectedIndex == 0 && this.genrelb.SelectedIndex == 0)
                {
                    labelcountpage.Text = $"{maxDataInPage}/{this.totalCount}";
                }
                else
                {
                    labelcountpage.Text = $"{maxDataInPage}/{this.totalCountAfterFilter}";
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void MyListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _uow.Dispose();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                r.Cells[2] = new DataGridViewLinkCell();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 2)
            {
                openLink(e.RowIndex);
            }
            else if (e.RowIndex == -1)
            {
                var datagv = (List<DataGridViewModel>)this.dataGridView1.DataSource;
                if (e.ColumnIndex == 0)
                {
                    if (this.sortCode.Equals(SortOrder.Descending.ToString()))
                    {
                        this.dataGridView1.DataSource = datagv.OrderBy(p => p.listCode).ToList();
                        this.sortCode = SortOrder.Ascending.ToString();
                    }
                    else if (this.sortCode.Equals(SortOrder.Ascending.ToString()))
                    {
                        this.dataGridView1.DataSource = datagv.OrderByDescending(p => p.listCode).ToList();
                        this.sortCode = SortOrder.Descending.ToString();
                    }
                }
                else if (e.ColumnIndex == 1)
                {
                    if (this.sortName.Equals(SortOrder.Descending.ToString()))
                    {
                        this.dataGridView1.DataSource = datagv.OrderBy(p => p.listName).ToList();
                        this.sortName = SortOrder.Ascending.ToString();
                    }
                    else if (this.sortName.Equals(SortOrder.Ascending.ToString()))
                    {
                        this.dataGridView1.DataSource = datagv.OrderByDescending(p => p.listName).ToList();
                        this.sortName = SortOrder.Descending.ToString();
                    }
                }
                else if (e.ColumnIndex == 7)
                {
                    if (this.sortUpdateDate.Equals(SortOrder.Descending.ToString()))
                    {
                        this.dataGridView1.DataSource = datagv.OrderBy(p => Utility.ConvertDateTHToEn(p.updateDateStr)).ToList();
                        this.sortUpdateDate = SortOrder.Ascending.ToString();
                    }
                    else if (this.sortUpdateDate.Equals(SortOrder.Ascending.ToString()))
                    {
                        this.dataGridView1.DataSource = datagv.OrderByDescending(p => Utility.ConvertDateTHToEn(p.updateDateStr)).ToList();
                        this.sortUpdateDate = SortOrder.Descending.ToString();
                    }
                }
            }
        }
        private void openLink(int rowIndex)
        {
            var myListId = (int)dataGridView1.Rows[rowIndex].Cells[0].Value;
            var data = _uow.MyListRepository.Read().FirstOrDefault(p => p.listTypeId == _model.listTypeId && p.listCode == myListId);
            var url = data?.listLink;
            Process.Start(url);
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            search();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var selectCell = sender as DataGridView;
                var cellIndex = selectCell.CurrentCell;
                var rowIndex = cellIndex.RowIndex;
                var columnIndex = cellIndex.ColumnIndex;
                if (rowIndex != -1 && columnIndex == 2)
                {
                    openLink(rowIndex);
                }
                else
                {
                    edit(dataGridView1.CurrentCell.RowIndex);
                }
                if (rowIndex > 0)
                {
                    DataGridViewCell cell = dataGridView1[columnIndex, rowIndex - 1];
                    dataGridView1.CurrentCell = cell;
                }
                else
                {
                    DataGridViewCell cell = dataGridView1[columnIndex, 0];
                    dataGridView1.CurrentCell = cell;
                }
            }
        }

        private void mainbtn_Click(object sender, EventArgs e)
        {
            escapeToMain();
        }

        private void escapeToMain()
        {
            this.Hide();
            var mainForm = new MainForm(_uow);
            mainForm.Closed += (s, args) => this.Close();
            mainForm.Show();
        }

        private void myListap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                escapeToMain();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.F5)
            {
                reload();
            }
        }

        private void MyListForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                escapeToMain();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void reload()
        {
            this.clear = true;
            ClearPage(true);
        }

        private void claerbtn_Click(object sender, EventArgs e)
        {
            ClearPage(true);
        }

        private void edit(int rowindex)
        {
            this.IU_Flag = "U";
            this.gobtn.Enabled = true;
            this.deletebtn.Enabled = true;
            //int rowindex = row;
            int columnindex = 0;


            if (this.dataGridView1.RowCount > 0)
            {
                var myListId = (int)dataGridView1.Rows[rowindex].Cells[columnindex].Value;
                if (myListId > 0)
                {
                    var data = _uow.MyListRepository.Read().FirstOrDefault(p => p.listTypeId == _model.listTypeId && p.listCode == myListId);

                    this.nametxt.Text = data.listName;
                    this.ePtxt.Text = data.listEP;
                    this.eplasttxt.Text = data.listEPLast;
                    this.linkUrltxt.Text = data.listLink;
                    this.stscbb.SelectedValue = data.stsId;
                    this.stslastcbb.SelectedValue = (data.stsIdLast ?? 5);
                    this.commenttxt.Text = data.listComment;
                    this.myListId = data.listId;
                    this.seasoncbb.SelectedValue = (data.seaId ?? 0);

                    this.myListtap.SelectedTab = inserttap;
                    ClearSelection();
                    var genreGroup = _uow.GenreGroupRepository.SelectGenreGroupByListId(data.listId);
                    if (genreGroup.Count > 0)
                    {
                        selectGen.AddRange(genreGroup.Select(p => p.genId).ToList());
                        for (int i = 0; i < this.genreclb.Items.Count; i++)
                        {
                            var genre = (GenreModel)this.genreclb.Items[i];
                            var chkData = genreGroup.FirstOrDefault(p => p.genId == genre.genreId);
                            if (chkData != null)
                            {
                                this.genreclb.SetItemChecked(i, true);
                            }
                            else
                            {
                                this.genreclb.SetItemChecked(i, false);
                            }
                        }
                    }

                }
            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            edit(dataGridView1.CurrentCell.RowIndex);
        }

        private void searchtxt_TextChanged(object sender, EventArgs e)
        {
            search();
            CalPage();
        }

        private void gobtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.linkUrltxt.Text))
            {
                try
                {
                    Process.Start(this.linkUrltxt.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        private bool CheckContainByName(string name)
        {
            var result = false;
            this.similar = "";
            List<MyListModel> model = new List<MyListModel>();
            if (!string.IsNullOrEmpty(name))
            {
                var contains = this.myLists
                    .Where(o =>
                        o.listName.ToUpper().Trim().Replace(" ", "").Contains(name.ToUpper().Trim().Replace(" ", "")))
                    .ToList();
                var listIds = new List<int>();
                if (contains != null && contains.Count > 0)
                {
                    model.AddRange(contains);
                    listIds = model.Select(s => s.listId).ToList();
                }
                var nameSeparator = name.Split(' ').ToList();
                if (nameSeparator.Count > 0)
                {
                    foreach (var item in nameSeparator)
                    {
                        if (!Constants.badWord.ToList().Where(p => p.ToUpper().Equals(item.ToUpper())).ToList().Any())
                        {
                            var listData = this.myLists.ToList();
                            if (contains != null && contains.Count > 0)
                            {
                                listData = listData.Where(o => !listIds.Contains(o.listId)).ToList();
                            }
                            var list = listData.Where(p => p.listName.Contains(item.Replace(" ", ""))).ToList();

                            if (list.Count > 0)
                            {
                                model.AddRange(list.Take(20));
                            }
                        }
                    }
                    if (model.Count > 0)
                    {
                        var realName = model.Select(p => p.listName).Distinct().ToList();
                        if (realName.Count > 0)
                        {
                            realName.ForEach(e => this.similar += "\n" + e);
                            //foreach (var item2 in realName)
                            //{
                            //    this.similar += "\n" + item2;
                            //}
                            this.similar += "\n";
                            result = true;
                        }
                    }
                }
            }
            return result;
        }

        private void nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveBtn.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                ClearPage(true);
            }
        }

        private void ePtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveBtn.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Add)
            {
                plusbtn.PerformClick();
            }
            if (e.KeyCode == Keys.Subtract)
            {
                minusbtn.PerformClick();
            }
            if (e.KeyCode == Keys.Multiply)
            {
                maxbtn.PerformClick();
            }
            if (e.KeyCode == Keys.Divide)
            {
                this.stscbb.SelectedValue = 3;
                this.stslastcbb.SelectedValue = 3;
                this.rePageFlag = false;
                if (!string.IsNullOrEmpty(this.IU_Flag))
                {
                    if (this.IU_Flag.Equals("U"))
                    {
                        saveBtn.PerformClick();
                        this.rePageFlag = true;
                    }
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                ClearPage(true);
            }
        }

        private void linkUrltxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveBtn.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                ClearPage(true);
            }
        }

        private void commenttxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveBtn.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                ClearPage(true);
            }
        }

        private void stslb_SelectedIndexChanged(object sender, EventArgs e)
        {
            search();
            CalPage();
        }

        private void plusbtn_Click(object sender, EventArgs e)
        {
            var epVal = !string.IsNullOrEmpty(this.ePtxt.Text) ? Convert.ToDecimal(this.ePtxt.Text) + 1 : 1;
            decimal eplast = 0;
            decimal.TryParse(this.eplasttxt.Text, out eplast);
            //int.TryParse(this.ePtxt.Text, out ep);
            this.ePtxt.Text = "";

            if (eplast <= epVal)
            {
                this.eplasttxt.Text = "";
                this.eplasttxt.Text = ((int)epVal).ToString();
            }

            this.ePtxt.Text = ((int)epVal).ToString();
            this.rePageFlag = false;
            if (!string.IsNullOrEmpty(this.IU_Flag))
            {
                changeStsByEp();
                if (this.IU_Flag.Equals("U"))
                {
                    saveBtn.PerformClick();
                    this.rePageFlag = true;
                }
            }
        }

        private void minusbtn_Click(object sender, EventArgs e)
        {
            var epVal = !string.IsNullOrEmpty(this.ePtxt.Text) ?
                            Convert.ToDecimal(this.ePtxt.Text) <= 0 ?
                                0 :
                                Convert.ToDecimal(this.ePtxt.Text) - 1 :
                            0;
            //int eplast = 0, ep = 0;
            //int.TryParse(this.eplasttxt.Text, out eplast);
            //int.TryParse(this.ePtxt.Text, out ep);
            this.ePtxt.Text = "";
            if ((decimal)epVal == 0)
            {
                this.eplasttxt.Text = "";
                this.eplasttxt.Text = ((decimal)epVal).ToString();
            }
            this.ePtxt.Text = ((int)epVal).ToString();
            this.rePageFlag = false;
            if (!string.IsNullOrEmpty(this.IU_Flag))
            {
                changeStsByEp();
                if (this.IU_Flag.Equals("U"))
                {
                    saveBtn.PerformClick();
                    this.rePageFlag = true;
                }
            }
        }

        private void ePtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void plusbtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                plusbtn.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                ClearPage(true);
            }
        }

        private void minusbtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                minusbtn.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                ClearPage(true);
            }
        }

        private void gobtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gobtn.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                ClearPage(true);
            }
        }

        private void stscbb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveBtn.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                ClearPage(true);
            }
        }

        private void saveBtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveBtn.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                ClearPage(true);
            }
        }

        private void claerbtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClearPage(true);
            }
            if (e.KeyCode == Keys.Escape)
            {
                ClearPage(true);
            }
        }

        private void searchbtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
                CalPage();
            }
            if (e.KeyCode == Keys.Escape)
            {
                escapeToMain();
            }
            if (e.KeyCode == Keys.F5)
            {
                reload();
            }
        }

        private void mainbtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                escapeToMain();
            }
            if (e.KeyCode == Keys.Escape)
            {
                escapeToMain();
            }
            if (e.KeyCode == Keys.F5)
            {
                reload();
            }
        }

        private void searchtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                edit(cuurRow());
                e.Handled = true;
                e.SuppressKeyPress = true;
                //search();
                //CalPage();
            }
            if (e.KeyCode == Keys.Escape)
            {
                escapeToMain();
            }
            if (e.KeyCode == Keys.PageDown)
            {
                int currentRowIndex = cuurRow();
                if (currentRowIndex >= 0)
                {
                    int newRowIndex = currentRowIndex + 1;
                    if (newRowIndex < dataGridView1.RowCount)
                    {
                        dataGridView1.Rows[currentRowIndex].Selected = false;
                        dataGridView1.Rows[newRowIndex].Selected = true;
                        // เลือกเซลล์แรกในแถวใหม่
                        if (dataGridView1.SelectedCells.Count > 0)
                        {
                            int firstCellIndex = dataGridView1.SelectedCells[0].ColumnIndex;
                            dataGridView1.CurrentCell = dataGridView1.Rows[newRowIndex].Cells[firstCellIndex];
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.PageUp)
            {
                int currentRowIndex = cuurRow();
                if (currentRowIndex >= 0)
                {
                    int newRowIndex = currentRowIndex - 1;
                    if (newRowIndex >= 0)
                    {
                        dataGridView1.Rows[currentRowIndex].Selected = false;
                        dataGridView1.Rows[newRowIndex].Selected = true;
                        // เลือกเซลล์แรกในแถวใหม่
                        if (dataGridView1.SelectedCells.Count > 0)
                        {
                            int firstCellIndex = dataGridView1.SelectedCells[0].ColumnIndex;
                            dataGridView1.CurrentCell = dataGridView1.Rows[newRowIndex].Cells[firstCellIndex];
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                reload();
            }
            if (e.KeyCode == Keys.Enter && e.Control)
            {
                this.openLink(cuurRow());
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private int cuurRow()
        {
            int row = 0;
            try
            {
                return dataGridView1.SelectedRows[0].Index;
            }
            catch (Exception)
            {
                return row;
            }
        }
        private void stslb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
                CalPage();
            }
            if (e.KeyCode == Keys.Escape)
            {
                escapeToMain();
            }
            if (e.KeyCode == Keys.F5)
            {
                reload();
            }
        }
        private void changeStsByEp()
        {
            var epDec = string.IsNullOrEmpty(this.ePtxt.Text) ? 0 : Convert.ToDecimal(this.ePtxt.Text);
            var epLasDec = string.IsNullOrEmpty(this.eplasttxt.Text) ? 0 : Convert.ToDecimal(this.eplasttxt.Text);
            var stsLast = 0;
            int.TryParse(this.stslastcbb.SelectedValue.ToString(), out stsLast);
            if (epDec == 0)
            {
                this.stscbb.SelectedValue = 5;
            }
            else if (epDec == epLasDec && stsLast == 3)
            {
                this.stscbb.SelectedValue = 3;
            }
            else
            {
                this.stscbb.SelectedValue = 1;
            }
        }
        private void changeStsLastByEp()
        {
            var epDec = string.IsNullOrEmpty(this.eplasttxt.Text) ? 0 : Convert.ToDecimal(this.eplasttxt.Text);
            if (epDec == 0)
            {
                this.stslastcbb.SelectedValue = 5;
            }
            else
            {
                this.stslastcbb.SelectedValue = 1;
            }
        }
        private void ePtxt_TextChanged(object sender, EventArgs e)
        {
            changeStsByEp();
            if (!string.IsNullOrEmpty(this.ePtxt.Text))
            {
                decimal ep = 0;
                decimal epLast = 0;

                decimal.TryParse(this.ePtxt.Text, out ep);
                decimal.TryParse(this.eplasttxt.Text, out epLast);
                var stsLast = 0;
                int.TryParse(this.stslastcbb.SelectedValue.ToString(), out stsLast);

                if (ep >= epLast)
                {
                    this.eplasttxt.Text = this.ePtxt.Text;
                }
            }
        }
        private void ClearSelection()
        {
            this.genreclb.DataSource = this.genres;
            for (int i = 0; i < this.genreclb.Items.Count; i++)
            {
                this.genreclb.SetItemChecked(i, false);
            }
        }

        private void seasonlb_SelectedIndexChanged(object sender, EventArgs e)
        {
            search();
            CalPage();
        }

        private void seasonlb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
                CalPage();
            }
            if (e.KeyCode == Keys.Escape)
            {
                escapeToMain();
            }
            if (e.KeyCode == Keys.F5)
            {
                reload();
            }
        }

        private void genrelb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var genLb = this.genrelb.SelectedItems.Cast<GenreModel>().ToList();
            if (!(this.clear ?? false))
            {
                if (genLb.FirstOrDefault(p => p.genreId == 0) != null)
                {
                    notincb.Checked = false;
                    notincb.Enabled = false;
                }
                else
                {
                    notincb.Enabled = true;
                }
            }

            search();
            CalPage();
        }

        private void genrelb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
                CalPage();
            }
            if (e.KeyCode == Keys.Escape)
            {
                escapeToMain();
            }
            if (e.KeyCode == Keys.F5)
            {
                reload();
            }
        }

        private void CalPage()
        {
            this.pageCount = 0;
            this.lbpage.DataSource = null;
            if (this.countData > 0)
            {
                var dataCount = 0;
                if (string.IsNullOrEmpty(this.searchtxt.Text) && this.stslb.SelectedIndex == 0 && this.seasonlb.SelectedIndex == 0 && this.genrelb.SelectedIndex == 0)
                {
                    dataCount = this.totalCount;
                }
                else
                {
                    dataCount = this.countData;
                }
                var take = this.takeData ?? 0;
                if (take > 0)
                {
                    var mod = dataCount % this.takeData.Value;
                    if (mod == 0)
                    {
                        this.pageCount = dataCount / this.takeData.Value;
                    }
                    else
                    {
                        this.pageCount = (dataCount / this.takeData.Value) + 1;
                    }
                }
                else
                {
                    this.pageCount = 1;
                }

                if (pageCount > 0)
                {
                    var pageSource = new List<int>();
                    for (int i = 1; i <= this.pageCount; i++)
                    {
                        pageSource.Add(i);
                    }
                    this.lbpage.DataSource = pageSource;
                }
            }
        }

        private void allrbtn_Click(object sender, EventArgs e)
        {
            this.takeData = null;
            search();
            CalPage();
        }

        private void tenrbtn_Click(object sender, EventArgs e)
        {
            this.takeData = 10;
            search();
            CalPage();
        }

        private void fiftyrbtn_Click(object sender, EventArgs e)
        {
            this.takeData = 50;
            search();
            CalPage();
        }

        private void hunrbtn_Click(object sender, EventArgs e)
        {
            this.takeData = 100;
            search();
            CalPage();
        }

        private void lbpage_SelectedIndexChanged(object sender, EventArgs e)
        {
            var page = Convert.ToInt32(lbpage.SelectedValue);
            if (page > 1)
            {
                this.pageSelect = page;
            }
            else
            {
                this.pageSelect = 1;
            }
            search();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"จะลบเรื่อง {this.nametxt.Text} ใช่มั้ย?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var dataGroup = _uow.GenreGroupRepository.Read().Where(p => p.listId == this.myListId).ToList();
                    //var data = _uow.MyListRepository.Read().FirstOrDefault(p => p.listId == this.myListId);
                    if (dataGroup != null && dataGroup.Count > 0)
                    {
                        _uow.GenreGroupRepository.DeleteRange(dataGroup);
                    }
                    _uow.MyListRepository.Delete(this.myListId);
                    var result = _uow.Save();
                    if (result > 0)
                    {
                        ClearPage(true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void deletebtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                deletebtn.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                ClearPage(true);
            }
        }

        private void notincb_CheckedChanged(object sender, EventArgs e)
        {
            search();
        }

        private void searchSeaTxt_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.searchSeaTxt.Text))
            {
                this.seasoncbb.DataSource = this.seasons.Where(p => p.seaDesc.ToUpper().Trim().Contains(this.searchSeaTxt.Text.ToUpper().Trim())).ToList();
                this.seasoncbb.DisplayMember = "seaDesc";
                this.seasoncbb.ValueMember = "seaId";
            }
            else
            {
                this.seasoncbb.DataSource = this.seasons.ToList();
                this.seasoncbb.DisplayMember = "seaDesc";
                this.seasoncbb.ValueMember = "seaId";
            }
        }

        private void searchGenTxt_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.searchGenTxt.Text))
            {
                this.genreclb.DataSource = this.genres.Where(p => p.genreDisplay.ToUpper().Trim().Contains(this.searchGenTxt.Text.ToUpper().Trim())).ToList();
                this.genreclb.DisplayMember = "genreDisplay";
                this.genreclb.ValueMember = "genreId";
            }
            else
            {
                this.genreclb.DataSource = this.genres.ToList();
                this.genreclb.DisplayMember = "genreDisplay";
                this.genreclb.ValueMember = "genreId";
            }

            for (int i = 0; i < this.genreclb.Items.Count; i++)
            {
                var genre = (GenreModel)this.genreclb.Items[i];
                int chkData = this.selectGen.FirstOrDefault(p => p == genre.genreId);
                if (chkData > 0)
                {
                    this.genreclb.SetItemChecked(i, true);
                }
                else
                {
                    this.genreclb.SetItemChecked(i, false);
                }
            }
        }

        private void pluslastbtn_Click(object sender, EventArgs e)
        {
            var epLastVal = !string.IsNullOrEmpty(this.eplasttxt.Text) ? Convert.ToDecimal(this.eplasttxt.Text) + 1 : 1;
            decimal epVal = 0;
            decimal.TryParse(this.ePtxt.Text, out epVal);
            if ((decimal)epLastVal <= epVal)
            {
                epLastVal = epVal;
            }
            this.eplasttxt.Text = "";
            this.eplasttxt.Text = ((int)epLastVal).ToString();
            this.rePageFlag = false;
            if (!string.IsNullOrEmpty(this.IU_Flag))
            {
                changeStsByEp();
                if (this.IU_Flag.Equals("U"))
                {
                    saveBtn.PerformClick();
                    this.rePageFlag = true;
                }
            }
        }

        private void pluslastbtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pluslastbtn.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                ClearPage(true);
            }
        }

        private void minuslastbtn_Click(object sender, EventArgs e)
        {
            var epLastVal = !string.IsNullOrEmpty(this.eplasttxt.Text) ?
                            Convert.ToDecimal(this.eplasttxt.Text) <= 0 ?
                                0 :
                                Convert.ToDecimal(this.eplasttxt.Text) - 1 :
                            0;
            decimal epVal = 0;
            decimal.TryParse(this.ePtxt.Text, out epVal);
            this.eplasttxt.Text = "";
            this.eplasttxt.Text = (((decimal)epLastVal) <= 0 ? 0 : (decimal)epLastVal).ToString();
            if (epVal >= epLastVal)
            {
                this.ePtxt.Text = "";
                this.ePtxt.Text = ((decimal)epLastVal).ToString();
            }
            this.rePageFlag = false;
            if (!string.IsNullOrEmpty(this.IU_Flag))
            {
                changeStsByEp();
                if (this.IU_Flag.Equals("U"))
                {
                    saveBtn.PerformClick();
                    this.rePageFlag = true;
                }
            }
        }

        private void minuslastbtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                minuslastbtn.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                ClearPage(true);
            }
        }

        private void eplasttxt_TextChanged(object sender, EventArgs e)
        {
            changeStsLastByEp();
        }

        private void eplasttxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void eplasttxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveBtn.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Add)
            {
                pluslastbtn.PerformClick();
            }
            if (e.KeyCode == Keys.Subtract)
            {
                minuslastbtn.PerformClick();
            }
            if (e.KeyCode == Keys.Multiply)
            {
                maxbtn.PerformClick();
            }
            if (e.KeyCode == Keys.Divide)
            {
                this.rePageFlag = false;
                this.stslastcbb.SelectedValue = 3;
                if (!string.IsNullOrEmpty(this.IU_Flag))
                {
                    if (this.IU_Flag.Equals("U"))
                    {
                        saveBtn.PerformClick();
                        this.rePageFlag = true;
                    }
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                ClearPage(true);
            }
        }

        private void stslastlb_SelectedIndexChanged(object sender, EventArgs e)
        {
            search();
            CalPage();
        }

        private void stslastlb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
                CalPage();
            }
            if (e.KeyCode == Keys.Escape)
            {
                escapeToMain();
            }
            if (e.KeyCode == Keys.F5)
            {
                reload();
            }
        }

        private void stseqsb_CheckedChanged(object sender, EventArgs e)
        {
            search();
        }

        private void genreclb_Click(object sender, EventArgs e)
        {
            genreclbClick();
        }
        private void genreclbClick()
        {
            var item = (GenreModel)this.genreclb.SelectedItem;
            if (!this.selectGen.Contains(item.genreId))
            {
                this.selectGen.Add(item.genreId);
            }
            else
            {
                this.selectGen.Remove(item.genreId);
            }
        }

        private void searchSeaTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveBtn.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.PageUp)
            {
                var maxIndex = this.seasoncbb.Items.Count - 1;
                var currIndex = this.seasoncbb.SelectedIndex;
                if (currIndex > 0)
                {
                    this.seasoncbb.SelectedIndex = currIndex - 1;
                }
            }
            if (e.KeyCode == Keys.PageDown)
            {
                var maxIndex = this.seasoncbb.Items.Count - 1;
                var currIndex = this.seasoncbb.SelectedIndex;
                if (currIndex < maxIndex)
                {
                    this.seasoncbb.SelectedIndex = currIndex + 1;
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                ClearPage(true);
            }
        }

        private void searchGenTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveBtn.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.PageUp)
            {
                var maxIndex = this.genreclb.Items.Count - 1;
                var currIndex = this.genreclb.SelectedIndex;
                if (currIndex > 0)
                {
                    this.genreclb.SelectedIndex = currIndex - 1;
                }
            }
            if (e.KeyCode == Keys.PageDown)
            {
                var maxIndex = this.genreclb.Items.Count - 1;
                var currIndex = this.genreclb.SelectedIndex;
                if (currIndex < maxIndex)
                {
                    this.genreclb.SelectedIndex = currIndex + 1;
                }
            }
            if (e.KeyCode == Keys.Add && e.Control)
            {
                this.genreclb.SetItemChecked(this.genreclb.SelectedIndex, true);
                genreclbClick();
                this.searchGenTxt.Text = string.Empty;
            }
            if (e.KeyCode == Keys.Subtract && e.Control)
            {
                this.genreclb.SetItemChecked(this.genreclb.SelectedIndex, false);
                genreclbClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                ClearPage(true);
            }

        }

        private void nonrdb_CheckedChanged(object sender, EventArgs e)
        {
            search();
            CalPage();
        }

        private void stseqrdb_CheckedChanged(object sender, EventArgs e)
        {
            search();
            CalPage();
        }

        private void stsnoteqrdb_CheckedChanged(object sender, EventArgs e)
        {
            search();
            CalPage();
        }

        private void genreclb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //var item = (GenreModel)this.genreclb.SelectedItem;
                var state = this.genreclb.GetItemCheckState(this.genreclb.SelectedIndex);
                if (state == CheckState.Checked)
                {
                    this.genreclb.SetItemChecked(this.genreclb.SelectedIndex, false);
                }
                else if (state == CheckState.Unchecked)
                {
                    this.genreclb.SetItemChecked(this.genreclb.SelectedIndex, true);
                }

                var item = (GenreModel)this.genreclb.SelectedItem;
                if (!this.selectGen.Contains(item.genreId))
                {
                    this.selectGen.Add(item.genreId);
                }
                else
                {
                    this.selectGen.Remove(item.genreId);
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void stscbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var stsval = 0;
            int.TryParse(this.stscbb.SelectedValue.ToString(), out stsval);
            if (stsval == 3)
            {
                this.stslastcbb.SelectedValue = this.stscbb.SelectedValue;
            }
        }

        private void maxbtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.eplasttxt.Text))
            {
                this.ePtxt.Text = this.eplasttxt.Text;
                this.rePageFlag = false;
                if (!string.IsNullOrEmpty(this.IU_Flag))
                {
                    changeStsByEp();
                    if (this.IU_Flag.Equals("U"))
                    {
                        saveBtn.PerformClick();
                        this.rePageFlag = true;
                    }
                }
            }
        }

        private void reloadbtn_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void clearTxt_Click(object sender, EventArgs e)
        {
            this.searchtxt.Text = string.Empty;
        }

        private void seasearchtxt_TextChanged(object sender, EventArgs e)
        {
            var seaSearch = this.seasearchtxt.Text;
            if (!string.IsNullOrEmpty(seaSearch) || !string.IsNullOrWhiteSpace(seaSearch))
            {
                var data = _uow.SeasonMastRepository.SelectAll(this._model.listTypeId);
                this.seasonlb.DataSource = data.Where(p => p.seaDesc.ToUpper().Trim().Contains(seaSearch.ToUpper().Trim())).ToList();
                this.seasonlb.DisplayMember = "seaDesc";
                this.seasonlb.ValueMember = "seaId";
            }
            else
            {
                this.seasonlb.DataSource = _uow.SeasonMastRepository.SelectAll(this._model.listTypeId);
                this.seasonlb.DisplayMember = "seaDesc";
                this.seasonlb.ValueMember = "seaId";
            }
        }

        private void clearTxtSea_Click(object sender, EventArgs e)
        {
            this.seasearchtxt.Text = string.Empty;
            this.seasonlb.DataSource = _uow.SeasonMastRepository.SelectAll(this._model.listTypeId);
            this.seasonlb.DisplayMember = "seaDesc";
            this.seasonlb.ValueMember = "seaId";
        }

        private void seasearchtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageUp)
            {
                var maxIndex = this.seasonlb.Items.Count - 1;
                var currIndex = this.seasonlb.SelectedIndex;
                if (currIndex > 0)
                {
                    this.seasonlb.SelectedIndex = currIndex - 1;
                }
            }
            if (e.KeyCode == Keys.PageDown)
            {
                var maxIndex = this.seasonlb.Items.Count - 1;
                var currIndex = this.seasonlb.SelectedIndex;
                if (currIndex < maxIndex)
                {
                    this.seasonlb.SelectedIndex = currIndex + 1;
                }
            }
        }

        private void gensearchtxt_TextChanged(object sender, EventArgs e)
        {
            var genSearch = this.gensearchtxt.Text;
            if (!string.IsNullOrEmpty(genSearch) || !string.IsNullOrWhiteSpace(genSearch))
            {
                var data = _uow.GenreMastRepository.SelectAll();
                this.genrelb.DataSource = data.Where(p => p.genreDisplay.ToUpper().Trim().Contains(genSearch.ToUpper().Trim())).ToList();
                this.genrelb.DisplayMember = "genreDisplay";
                this.genrelb.ValueMember = "genreId";
            }
            else
            {
                this.genrelb.DataSource = _uow.GenreMastRepository.SelectAll();
                this.genrelb.DisplayMember = "genreDisplay";
                this.genrelb.ValueMember = "genreId";
            }

        }

        private void clearTxtGen_Click(object sender, EventArgs e)
        {
            this.gensearchtxt.Text = string.Empty;
            this.genrelb.DataSource = _uow.GenreMastRepository.SelectAll();
            this.genrelb.DisplayMember = "genreDisplay";
            this.genrelb.ValueMember = "genreId";
        }

        private void plusdecbtn_Click(object sender, EventArgs e)
        {
            var epVal = !string.IsNullOrEmpty(this.ePtxt.Text) ? Convert.ToDecimal(this.ePtxt.Text) + (decimal)0.1 : 1;
            decimal eplast = 0;
            decimal.TryParse(this.eplasttxt.Text, out eplast);
            //int.TryParse(this.ePtxt.Text, out ep);
            this.ePtxt.Text = "";

            if (eplast <= epVal)
            {
                this.eplasttxt.Text = "";
                this.eplasttxt.Text = ((decimal)epVal).ToString();
            }

            this.ePtxt.Text = ((decimal)epVal).ToString();
            this.rePageFlag = false;
            if (!string.IsNullOrEmpty(this.IU_Flag))
            {
                changeStsByEp();
                if (this.IU_Flag.Equals("U"))
                {
                    saveBtn.PerformClick();
                    this.rePageFlag = true;
                }
            }
        }

        private void minusdecbtn_Click(object sender, EventArgs e)
        {
            var epVal = !string.IsNullOrEmpty(this.ePtxt.Text) ?
                            Convert.ToDecimal(this.ePtxt.Text) <= 0 ?
                                0 :
                                Convert.ToDecimal(this.ePtxt.Text) - (decimal)0.1 :
                            0;
            this.ePtxt.Text = "";
            if ((decimal)epVal == 0)
            {
                this.eplasttxt.Text = "";
                this.eplasttxt.Text = ((decimal)epVal).ToString();
            }
            this.ePtxt.Text = ((decimal)epVal).ToString();
            this.rePageFlag = false;
            if (!string.IsNullOrEmpty(this.IU_Flag))
            {
                changeStsByEp();
                if (this.IU_Flag.Equals("U"))
                {
                    saveBtn.PerformClick();
                    this.rePageFlag = true;
                }
            }
        }

        private void pluslastdecbtn_Click(object sender, EventArgs e)
        {
            var epLastVal = !string.IsNullOrEmpty(this.eplasttxt.Text) ? Convert.ToDecimal(this.eplasttxt.Text) + (decimal)0.1 : 1;
            decimal epVal = 0;
            decimal.TryParse(this.ePtxt.Text, out epVal);
            if ((decimal)epLastVal <= epVal)
            {
                epLastVal = epVal;
            }
            this.eplasttxt.Text = "";
            this.eplasttxt.Text = ((decimal)epLastVal).ToString();
            this.rePageFlag = false;
            if (!string.IsNullOrEmpty(this.IU_Flag))
            {
                changeStsByEp();
                if (this.IU_Flag.Equals("U"))
                {
                    saveBtn.PerformClick();
                    this.rePageFlag = true;
                }
            }
        }

        private void minuslastdecbtn_Click(object sender, EventArgs e)
        {
            var epLastVal = !string.IsNullOrEmpty(this.eplasttxt.Text) ?
                            Convert.ToDecimal(this.eplasttxt.Text) <= 0 ?
                                0 :
                                Convert.ToDecimal(this.eplasttxt.Text) - (decimal)0.1 :
                            0;
            decimal epVal = 0;
            decimal.TryParse(this.ePtxt.Text, out epVal);
            this.eplasttxt.Text = "";
            this.eplasttxt.Text = (((decimal)epLastVal) <= 0 ? 0 : (decimal)epLastVal).ToString();
            if (epVal >= epLastVal)
            {
                this.ePtxt.Text = "";
                this.ePtxt.Text = ((decimal)epLastVal).ToString();
            }
            this.rePageFlag = false;
            if (!string.IsNullOrEmpty(this.IU_Flag))
            {
                changeStsByEp();
                if (this.IU_Flag.Equals("U"))
                {
                    saveBtn.PerformClick();
                    this.rePageFlag = true;
                }
            }
        }
    }
}
