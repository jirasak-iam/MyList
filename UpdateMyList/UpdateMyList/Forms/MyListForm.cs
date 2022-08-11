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
        private int? takeData { get; set; } = 100;
        private string  sortCode { get; set; } = "Descending";
        private string sortUpdateDate { get; set; } = "Descending";
        private int pageCount { get; set; } = 1;
        private int pageSelect { get; set; } = 1;
        private int countDataBfSkip { get; set; } = 0;
        public void ClearPage(bool allData)
        {
            var reFlag = this.rePageFlag ?? true;
            this.IU_Flag = this.IU_Flag ?? "I";
            var cleaFlag = this.clear ?? false;
            if (reFlag || !this.IU_Flag.Equals("U"))
            {
                this.myListId = 0;
                this.IU_Flag = "";
                this.nametxt.Text = "";
                this.ePtxt.Text = "";
                this.linkUrltxt.Text = "";
                this.commenttxt.Text = "";
                this.stscbb.SelectedIndex = 0;
                this.similar = "";
                this.gobtn.Enabled = false;
                this.seasoncbb.SelectedIndex = 0;
                ClearSelection();
                this.myListtap.SelectedTab = listtap;
            }
            if (cleaFlag)
            {
                this.stslb.ClearSelected();
                this.stslb.SelectedIndex = 0;
                this.stscbb.SelectedIndex = 0;

                this.seasonlb.ClearSelected();
                this.seasonlb.SelectedIndex = 0;
                this.seasoncbb.SelectedIndex = 0;

                ClearSelection();
                this.genrelb.ClearSelected();
                this.genrelb.SelectedIndex = 0;

                this.searchtxt.Text = "";
                this.clear = false;
            }
            if (allData)
            {
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
                var data = new MyListModel
                {
                    listId = this.myListId,
                    listName = this.nametxt.Text,
                    listLink = this.linkUrltxt.Text,
                    listEP = this.ePtxt.Text,
                    listComment = this.commenttxt.Text,
                    stsId = Convert.ToInt32(this.stscbb.SelectedValue),
                    seasonId = Convert.ToInt32(this.seasoncbb.SelectedValue),
                    updateBy = Constants.UserApp,
                    updateDate = DateTime.Now
                };
                rs= _uow.MyListRepository.UpdateByApp(data);
            }
            else
            {
                var data = new MyListModel
                {
                    listTypeId = this._model.listTypeId,
                    listName = this.nametxt.Text,
                    listLink = this.linkUrltxt.Text,
                    listEP = this.ePtxt.Text,
                    listComment = this.commenttxt.Text,
                    stsId = Convert.ToInt32(this.stscbb.SelectedValue),
                    seasonId = Convert.ToInt32(this.seasoncbb.SelectedValue),
                    recStatus = RecStatus.Active,
                    createBy = Constants.UserApp,
                    createDate = DateTime.Now,
                    updateDate = DateTime.Now
                };
                rs = _uow.MyListRepository.Insert(data);
            }
            var genreList = this.genreclb.Items;
            for (int i = 0; i < this.genreclb.Items.Count; i++)
            {
                if (this.genreclb.GetItemCheckState(i) == CheckState.Checked)
                {
                    var genre = (GenreModel)this.genreclb.Items[i];
                    var genreGroup = _uow.GenreGroupRepository.SelectGenreGroupByListId(this.myListId).FirstOrDefault(p => p.genId == genre.genreId);
                    if (genreGroup == null)
                    {
                        var genGroupClose = _uow.GenreGroupRepository.SelectGenreGroupByListIdButClose(this.myListId).FirstOrDefault(p => p.genId == genre.genreId);
                        if (genGroupClose is null)
                        {
                            var genGroup = new GenreGroupModel
                            {
                                genId = genre.genreId,
                                listId = rs,
                                recStatus = RecStatus.Active,
                                createBy = Constants.UserApp,
                                createDate = DateTime.Now
                            };
                            _uow.GenreGroupRepository.Insert(genGroup);
                        }
                        else
                        {
                            var genGroup = new GenreGroupModel
                            {
                                gengroupId = genGroupClose.gengroupId,
                                genId = genGroupClose.genId,
                                listId = genGroupClose.listId,
                                recStatus = RecStatus.Active,
                                updateBy = Constants.UserApp,
                                updateDate = DateTime.Now
                            };
                            _uow.GenreGroupRepository.UpdateGenGroup(genGroup);
                        }
                    }
                }
                else if (this.genreclb.GetItemCheckState(i) == CheckState.Unchecked)
                {
                    var genre = (GenreModel)this.genreclb.Items[i];
                    var genreGroup = _uow.GenreGroupRepository.SelectGenreGroupByListId(this.myListId).FirstOrDefault(p => p.genId == genre.genreId);
                    if (genreGroup != null)
                    {
                        var genGroup = new GenreGroupModel
                        {
                            gengroupId = genreGroup.gengroupId,
                            genId = genre.genreId,
                            listId = rs,
                            recStatus = RecStatus.Close,
                            updateBy = Constants.UserApp,
                            updateDate = DateTime.Now
                        };
                        _uow.GenreGroupRepository.UpdateGenGroup(genGroup);
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
                        var chkContain = CheckContainByName(this.nametxt.Text);
                        
                        
                        this.IU_Flag = this.IU_Flag ?? "I";
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
            this.hunrbtn.Checked = true;
            this.dataGridView1.ReadOnly = true;

            this.stslb.DataSource = _uow.StsMastRepository.SelectAll();
            this.stslb.DisplayMember = "stsDesc";
            this.stslb.ValueMember = "stsId";

            this.stscbb.DataSource = _uow.StsMastRepository.Select();
            this.stscbb.DisplayMember = "stsDesc";
            this.stscbb.ValueMember = "stsId";

            this.genreclb.DataSource = _uow.GenreMastRepository.Select();
            this.genreclb.DisplayMember = "genreDisplay";
            this.genreclb.ValueMember = "genreId";

            this.genrelb.DataSource = _uow.GenreMastRepository.SelectAll();
            this.genrelb.DisplayMember = "genreDisplay";
            this.genrelb.ValueMember = "genreId";

            this.seasoncbb.DataSource = _uow.SeasonMastRepository.Select();
            this.seasoncbb.DisplayMember = "seasonDesc";
            this.seasoncbb.ValueMember = "seasonId";

            this.seasonlb.DataSource = _uow.SeasonMastRepository.SelectAll();
            this.seasonlb.DisplayMember = "seasonDesc";
            this.seasonlb.ValueMember = "seasonId";
            //this.genreclb.DataBindings

            //this.gobtn.Enabled = false;
            var data = (List<DataGridViewModel>)dataGridView1.DataSource;
            CalPage();

        }
        private void search()
        {
            this.dataGridView1.DataSource = null;
            var stsLb = this.stslb.SelectedItems.Cast<StsMastModel>().ToList();
            var stsLbSelect = stsLb?.Select(p => p.stsId).ToList();
            var chkSelectSts = stsLbSelect?.Sum() ?? 0;

            var seasonLb = this.seasonlb.SelectedItems.Cast<SeasonMastModel>().ToList();
            var seasonLbSelect = seasonLb?.Select(p => p.seasonId).ToList();
            var chkSelectSeason = seasonLbSelect?.Sum() ?? 0;

            var genreLb = this.genrelb.SelectedItems.Cast<GenreModel>().ToList();
            var genreLbSelect = genreLb?.Select(p => p.genreId).ToList();
            var chkSelectGen = genreLbSelect?.Sum() ?? 0;

            var searchName = this.searchtxt.Text.ToUpper();
            if (_model != null)
            {
                var getByType = _uow.MyListRepository.SelectByType(_model);
                if (chkSelectSts > 0)
                {
                    getByType = getByType.Where(p => stsLbSelect.Contains(p.stsId)).ToList();
                }
                if (chkSelectSeason > 0)
                {
                    getByType = getByType.Where(p => seasonLbSelect.Contains(p.seasonId ?? 0)).ToList();
                }
                if (chkSelectGen > 0)
                {
                    var genreGroup = _uow.GenreGroupRepository.SelectGenreGroupBygenIdMany(genreLbSelect).Select(a => a.listId).ToList();
                    getByType = getByType.Where(p => genreGroup.Contains(p.listId)).ToList();
                }
                if (!string.IsNullOrEmpty(searchName))
                {
                    getByType = getByType.Where(p => p.listName.ToUpper().Contains(searchName)).ToList();
                }
                this.countDataBfSkip = getByType.Count;
                if (this.pageSelect > 1)
                {
                    var skip = (this.takeData ?? 0) * (pageSelect - 1);
                    getByType = getByType.Skip(skip).ToList();
                }
                if (this.takeData != null)
                {
                    getByType = getByType.Take(this.takeData.Value).ToList();
                }
                
                this.setDataGrid(getByType);
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
                                   stsDesc = a.stsDesc,
                                   listEP = a.listEP,
                                   seasonDesc = a.seasonDesc,
                                   genreDesc = string.Join(",", genreGroup.Where(p => p.listId == a.listId).Select(o => o.genCode).OrderBy(o => o).ToList()),
                                   updateDateStr = a.updateDateStr
                               }).ToList();
                this.dataGridView1.DataSource = preData;
                this.dataGridView1.Columns[0].HeaderText = "ID";
                this.dataGridView1.Columns[0].Width = 50;
                this.dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[1].HeaderText = "ชื่อเรื่อง";
                this.dataGridView1.Columns[1].Width = 350;
                this.dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[2].HeaderText = "Link";
                this.dataGridView1.Columns[2].Width = 350;
                this.dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[3].HeaderText = "สถานะ";
                this.dataGridView1.Columns[3].Width = 125;
                this.dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[4].HeaderText = "EP";
                this.dataGridView1.Columns[4].Width = 80;
                this.dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[5].HeaderText = "Seasonal";
                this.dataGridView1.Columns[5].Width = 125;
                this.dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[6].HeaderText = "Genre";
                this.dataGridView1.Columns[6].Width = 250;
                this.dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[7].HeaderText = "แก้ไขล่าสุด";
                this.dataGridView1.Columns[7].Width = 125;
                this.dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                    editbtn.PerformClick();
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
                reloadbtn.PerformClick();
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

        private void reloadbtn_Click(object sender, EventArgs e)
        {
            this.clear = true;
            ClearPage(true);
        }

        private void claerbtn_Click(object sender, EventArgs e)
        {
            ClearPage(true);
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            this.IU_Flag = "U";
            this.gobtn.Enabled = true;
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = 0;

            var myListId = (int)dataGridView1.Rows[rowindex].Cells[columnindex].Value;
            if (myListId > 0)
            {
                var data = _uow.MyListRepository.Read().FirstOrDefault(p => p.listTypeId == _model.listTypeId && p.listCode == myListId);

                this.nametxt.Text = data.listName;
                this.ePtxt.Text = data.listEP;
                this.linkUrltxt.Text = data.listLink;
                this.stscbb.SelectedValue = data.stsId;
                this.commenttxt.Text = data.listComment;
                this.myListId = data.listId;
                this.seasoncbb.SelectedValue = (data.seasonId ?? 0);

                this.myListtap.SelectedTab = inserttap;
                ClearSelection();
                var genreGroup = _uow.GenreGroupRepository.SelectGenreGroupByListId(data.listId);
                if (genreGroup.Count > 0)
                {
                    for (int i = 0; i < this.genreclb.Items.Count; i++)
                    {
                        var genre = (GenreModel)this.genreclb.Items[i];
                        var chkData = genreGroup.FirstOrDefault(p => p.genId == genre.genreId);
                        if (chkData != null)
                        {
                            this.genreclb.SetItemChecked(i, true);
                        }
                    }
                }

            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            editbtn.PerformClick();
        }

        private void searchtxt_TextChanged(object sender, EventArgs e)
        {
            search();
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
                var nameSeparator = name.Split(' ').ToList();
                if (nameSeparator.Count > 0)
                {
                    foreach (var item in nameSeparator)
                    {
                        if (!Constants.badWord.ToList().Where(p => p.ToUpper().Equals(item.ToUpper())).ToList().Any())
                        {
                            var listData = _uow.MyListRepository.SelectByType(_model);
                            var list = listData.Where(p => p.listName.Contains(item.Replace(" ", ""))).ToList();
                            if (list.Count > 0)
                            {
                                model.AddRange(list);
                            }
                        }
                    }
                    if (model.Count > 0)
                    {
                        var realName = model.Select(p => p.listName).Distinct().ToList();
                        if (realName.Count > 0)
                        {
                            foreach (var item2 in realName)
                            {
                                this.similar += "\n" + item2;
                            }
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
            searchbtn.PerformClick();
        }

        private void plusbtn_Click(object sender, EventArgs e)
        {
            var epVal = !string.IsNullOrEmpty(this.ePtxt.Text) ? Convert.ToDecimal(this.ePtxt.Text) + 1 : 1;
            this.ePtxt.Text = "";
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
            var epVal = !string.IsNullOrEmpty(this.ePtxt.Text) ? Convert.ToDecimal(this.ePtxt.Text) - 1 : 1;
            this.ePtxt.Text = "";
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
                searchbtn.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                escapeToMain();
            }
            if (e.KeyCode == Keys.F5)
            {
                reloadbtn.PerformClick();
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
                reloadbtn.PerformClick();
            }
        }

        private void searchtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchbtn.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                escapeToMain();
            }
            if (e.KeyCode == Keys.F5)
            {
                reloadbtn.PerformClick();
            }
        }

        private void stslb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchbtn.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                escapeToMain();
            }
            if (e.KeyCode == Keys.F5)
            {
                reloadbtn.PerformClick();
            }
        }

        private void editbtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                editbtn.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                escapeToMain();
            }
            if (e.KeyCode == Keys.F5)
            {
                reloadbtn.PerformClick();
            }
        }

        private void reloadbtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                reloadbtn.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                escapeToMain();
            }
            if (e.KeyCode == Keys.F5)
            {
                reloadbtn.PerformClick();
            }
        }
        private void changeStsByEp()
        {
            var epDec = string.IsNullOrEmpty(this.ePtxt.Text) ? 0 : Convert.ToDecimal(this.ePtxt.Text);
            if (epDec == 0)
            {
                this.stscbb.SelectedValue = 5;
            }
            else
            {
                this.stscbb.SelectedValue = 1;
            }
        }

        private void ePtxt_TextChanged(object sender, EventArgs e)
        {
            changeStsByEp();
        }
        private void ClearSelection()
        {
            for (int i = 0; i < this.genreclb.Items.Count; i++)
            {
                this.genreclb.SetItemChecked(i, false);
            }
        }

        private void seasonlb_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchbtn.PerformClick();
        }

        private void seasonlb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchbtn.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                escapeToMain();
            }
            if (e.KeyCode == Keys.F5)
            {
                reloadbtn.PerformClick();
            }
        }

        private void genrelb_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchbtn.PerformClick();
        }

        private void genrelb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchbtn.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                escapeToMain();
            }
            if (e.KeyCode == Keys.F5)
            {
                reloadbtn.PerformClick();
            }
        }

        private void CalPage()
         {
            this.pageCount = 1;
            this.lbpage.DataSource = null;
            if (this.countDataBfSkip > 0)
            {
                var dataCount = this.countDataBfSkip;
                var take = this.takeData ?? 0;
                if (take > 0)
                {
                    this.pageCount += dataCount / this.takeData.Value;
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
            CalPage();
            search();
        }

        private void tenrbtn_Click(object sender, EventArgs e)
        {
            this.takeData = 10;
            CalPage();
            search();
        }

        private void fiftyrbtn_Click(object sender, EventArgs e)
        {
            this.takeData = 50;
            CalPage();
            search();
        }

        private void hunrbtn_Click(object sender, EventArgs e)
        {
            this.takeData = 100;
            CalPage();
            search();
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
    }
}
