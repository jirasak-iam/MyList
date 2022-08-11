using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class SettingForm : Form
    {
        private readonly IUnitOfWork _uow;
        private string IU_Flag = "I";
        private string _mapCode = "";
        private string _code = "";
        private int id = 0;
        public SettingForm(IUnitOfWork uow)
        {
            InitializeComponent();
            _uow = uow;
        }
        private void Clear(bool loadGrid)
        {
            this.IU_Flag = "";
            this.codetxt.Text = "";
            this.desctxt.Text = "";
            this.recstatuscbb.SelectedIndex = 0;
            this.sortseqnb.Value = 0;
            this.settingtap.SelectedTab = tabPage1;
            this._mapCode = "";
            this._code = "";
            this.id = 0;
            if (loadGrid)
            {
                SearchOption();
            }
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            this.dataGridView1.ReadOnly = true;
            this.mapcbb.DataSource = _uow.MapSetingParamRepository.SelectAll();
            this.mapcbb.DisplayMember = "mapDisplay";
            this.mapcbb.ValueMember = "mapCode";

            this.recstatuscbb.DataSource = Utility.GetRecStatus();
            this.recstatuscbb.DisplayMember = "recDesc";
            this.recstatuscbb.ValueMember = "recStatus";
        }

        private void SearchOption()
        {
            var data = (MapSettingParamModel)this.mapcbb.SelectedItem;
            if (data != null)
            {
                this._mapCode = data.mapCode;
                var preData = new List<DataGridViewSettingModel>();
                if (MappingParam.Status.Equals(data.mapCode))
                {
                    var rawData = _uow.StsMastRepository.SelectAllType();
                    preData = rawData.Select( a =>
                        new DataGridViewSettingModel 
                        { 
                            code = a.stsCode,
                            desc = a.stsDesc,
                            recStatus = Utility.SetRecDesc(a.recStatus),
                            sortSeq = a.sortSeq,
                            updateDate = a.updateDateStr
                        }).ToList();
                    this.dataGridView1.DataSource = preData;
                }
                else if (MappingParam.ListType.Equals(data.mapCode))
                {
                    var rawData = _uow.ListTypeMastRepository.SelectAllType();
                    preData = rawData.Select(a =>
                       new DataGridViewSettingModel
                       {
                           code = a.listTypeCode,
                           desc = a.listTypeDesc,
                           recStatus = Utility.SetRecDesc(a.recStatus),
                           sortSeq = a.sortSeq,
                           updateDate = a.updateDateStr
                       }).ToList();
                    this.dataGridView1.DataSource = preData;
                }
                else if (MappingParam.Genre.Equals(data.mapCode))
                {
                    var rawData = _uow.GenreMastRepository.SelectAllType();
                    preData = rawData.Select(a =>
                       new DataGridViewSettingModel
                       {
                           code = a.genreCode,
                           desc = a.genreDesc,
                           recStatus = Utility.SetRecDesc(a.recStatus),
                           sortSeq = a.sortSeq,
                           updateDate = a.updateDateStr
                       }).ToList();
                    this.dataGridView1.DataSource = preData;
                }
                else if (MappingParam.Season.Equals(data.mapCode))
                {
                    var rawData = _uow.SeasonMastRepository.SelectAllType();
                    preData = rawData.Select(a =>
                       new DataGridViewSettingModel
                       {
                           code = a.seasonCode,
                           desc = a.seasonDesc,
                           recStatus = Utility.SetRecDesc(a.recStatus),
                           sortSeq = a.sortSeq,
                           updateDate = a.updateDateStr
                       }).ToList();
                    this.dataGridView1.DataSource = preData;
                }
                else if (MappingParam.MapSetingParameter.Equals(data.mapCode))
                {
                    var rawData = _uow.MapSetingParamRepository.SelectAllType();
                    preData = rawData.Select(a =>
                       new DataGridViewSettingModel
                       {
                           code = a.mapCode,
                           desc = a.mapDesc,
                           recStatus = Utility.SetRecDesc(a.recStatus),
                           sortSeq = a.sortSeq,
                           updateDate = a.updateDateStr
                       }).ToList();
                    this.dataGridView1.DataSource = preData;
                }
                else
                {
                    this.dataGridView1.DataSource = preData;
                }

                if (preData.Count > 0)
                {
                    this._code = preData.FirstOrDefault().code;
                }
            }
            if (this.dataGridView1.DataSource != null)
            {
                this.dataGridView1.Columns[0].HeaderText = "รหัส";
                this.dataGridView1.Columns[1].HeaderText = "รายละเอียด";
                this.dataGridView1.Columns[2].HeaderText = "สถานะใช้งาน";
                this.dataGridView1.Columns[3].HeaderText = "แก้ไขล่าสุด";
                this.dataGridView1.Columns[4].HeaderText = "เรียงลำดับ";

                this.dataGridView1.Columns[0].Width = 100;
                this.dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dataGridView1.Columns[1].Width = 150;
                this.dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dataGridView1.Columns[2].Width = 115;
                this.dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dataGridView1.Columns[3].Width = 125;
                this.dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dataGridView1.Columns[4].Width = 80;
                this.dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void mapcbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchOption();
            var selectItem = (MapSettingParamModel)this.mapcbb.SelectedItem;
            if (MappingParam.MapSetingParameter.Equals(selectItem.mapCode))
            {
                label6.Visible = true;
                tablenametxt.Visible = true;
                this.seasonlistlb.Visible = false;
                this.gencodebtn.Visible = false;
            }
            else if (MappingParam.Season.Equals(selectItem.mapCode))
            {
                label6.Visible = false;
                tablenametxt.Visible = false;
                this.seasonlistlb.Visible = true;
                this.seasonlistlb.DataSource = Utility.GetSeasonalList();
                this.seasonlistlb.DisplayMember = "seasonDisplay";
                this.seasonlistlb.ValueMember = "seasonCode";
                this.gencodebtn.Visible = true;
            }
            else
            {
                label6.Visible = false;
                tablenametxt.Visible = false;
                this.seasonlistlb.Visible = false;
                this.gencodebtn.Visible = false;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            EditData();
        }

        private void EditData()
        {
            this.IU_Flag = "U";
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = 0;

            var code = (dataGridView1.Rows[rowindex].Cells[columnindex].Value).ToString();
            this.settingtap.SelectedTab = tabPage2;
            BindingData(code);
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            Clear(false);
        }
        private void BindingData(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                if (MappingParam.Status.Equals(this._mapCode))
                {
                    var data = _uow.StsMastRepository.SelectAllType().FirstOrDefault(p => code.Equals(p.stsCode));
                    this.codetxt.Text = data.stsCode;
                    this.desctxt.Text = data.stsDesc;
                    this.id = data.stsId;
                    this.recstatuscbb.SelectedValue = data.recStatus;
                    this.sortseqnb.Value = data.sortSeq ?? 0;
                }
                else if (MappingParam.ListType.Equals(this._mapCode))
                {
                    var data = _uow.ListTypeMastRepository.SelectAllType().FirstOrDefault(p => code.Equals(p.listTypeCode));
                    this.codetxt.Text = data.listTypeCode;
                    this.desctxt.Text = data.listTypeDesc;
                    this.id = data.listTypeId;
                    this.recstatuscbb.SelectedValue = data.recStatus;
                    this.sortseqnb.Value = data.sortSeq ?? 0;
                }
                else if (MappingParam.Genre.Equals(this._mapCode))
                {
                    var data = _uow.GenreMastRepository.SelectAllType().FirstOrDefault(p => code.Equals(p.genreCode));
                    this.codetxt.Text = data.genreCode;
                    this.desctxt.Text = data.genreDesc;
                    this.id = data.genreId;
                    this.recstatuscbb.SelectedValue = data.recStatus;
                    this.sortseqnb.Value = data.sortSeq ?? 0;
                }
                else if (MappingParam.Season.Equals(this._mapCode))
                {
                    var data = _uow.SeasonMastRepository.SelectAllType().FirstOrDefault(p => code.Equals(p.seasonCode));
                    this.codetxt.Text = data.seasonCode;
                    this.desctxt.Text = data.seasonDesc;
                    this.id = data.seasonId;
                    this.recstatuscbb.SelectedValue = data.recStatus;
                    this.sortseqnb.Value = data.sortSeq ?? 0;
                }
                else if (MappingParam.MapSetingParameter.Equals(this._mapCode))
                {
                    var data = _uow.MapSetingParamRepository.SelectAllType().FirstOrDefault(p => code.Equals(p.mapCode));
                    this.codetxt.Text = data.mapCode;
                    this.desctxt.Text = data.mapDesc;
                    this.id = data.mapId;
                    this.recstatuscbb.SelectedValue = data.recStatus;
                    this.sortseqnb.Value = data.sortSeq ?? 0;
                }
            }
        }

        private void reloadbtn_Click(object sender, EventArgs e)
        {
            this.mapcbb.SelectedIndex = 0;
            Clear(true);
            
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

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (this.mapcbb.SelectedIndex > 0)
            {
                SaveSettingParam();
            }
            else
            {
                MessageBox.Show($"กรุณาเลือก Option ที่ต้องการบันทึก", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void SaveSettingParam()
        {
            var selectItem = (MapSettingParamModel)this.mapcbb.SelectedItem;
            this.IU_Flag = this.IU_Flag ?? "I";
            if (!string.IsNullOrEmpty(this.codetxt.Text))
            {
                if (MappingParam.Status.Equals(this._mapCode))
                {
                    var data = new StsMastModel
                    {
                        stsId = this.id,
                        stsCode = this.codetxt.Text,
                        stsDesc = this.desctxt.Text,
                        recStatus = this.recstatuscbb.SelectedValue.ToString(),
                        sortSeq = Convert.ToInt32(this.sortseqnb.Value),
                        updateBy = Constants.UserApp,
                        updateDate = DateTime.Now,
                        createDate = DateTime.Now,
                        createBy = Constants.UserApp,
                    };
                    if (("U").Equals(this.IU_Flag))
                    {
                        var rs = _uow.StsMastRepository.UpdateById(data);
                        if (rs > 0)
                        {
                            Clear(true);
                        }
                    }
                    else
                    {
                        var chqdup = _uow.StsMastRepository.Read().FirstOrDefault(p => p.stsCode.ToUpper().Equals(data.stsCode.ToUpper()));
                        if (chqdup is null)
                        {
                            var rs = _uow.StsMastRepository.Insert(data);
                            if (rs > 0)
                            {
                                Clear(true);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"{chqdup.stsCode} มีอยู่แล้ว", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                }
                else if (MappingParam.ListType.Equals(this._mapCode))
                {
                    var data = new ListTypeModel
                    {
                        listTypeId = this.id,
                        listTypeCode = this.codetxt.Text,
                        listTypeDesc = this.desctxt.Text,
                        recStatus = this.recstatuscbb.SelectedValue.ToString(),
                        sortSeq = Convert.ToInt32(this.sortseqnb.Value),
                        updateBy = Constants.UserApp,
                        updateDate = DateTime.Now,
                        createDate = DateTime.Now,
                        createBy = Constants.UserApp,
                    };
                    if (("U").Equals(this.IU_Flag))
                    {
                        var rs = _uow.ListTypeMastRepository.UpdateById(data);
                        if (rs > 0)
                        {
                            Clear(true);
                        }
                    }
                    else
                    {
                        var chqdup = _uow.ListTypeMastRepository.Read().FirstOrDefault(p => p.listTypeCode.ToUpper().Equals(data.listTypeCode.ToUpper()));
                        if (chqdup is null)
                        {
                            var rs = _uow.ListTypeMastRepository.Insert(data);
                            if (rs > 0)
                            {
                                Clear(true);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"{chqdup.listTypeCode} มีอยู่แล้ว", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else if (MappingParam.Genre.Equals(this._mapCode))
                {
                    var data = new GenreModel
                    {
                        genreId = this.id,
                        genreCode = this.codetxt.Text,
                        genreDesc = this.desctxt.Text,
                        recStatus = this.recstatuscbb.SelectedValue.ToString(),
                        sortSeq = Convert.ToInt32(this.sortseqnb.Value),
                        updateBy = Constants.UserApp,
                        updateDate = DateTime.Now,
                        createDate = DateTime.Now,
                        createBy = Constants.UserApp,
                    };
                    if (("U").Equals(this.IU_Flag))
                    {
                        var rs = _uow.GenreMastRepository.UpdateById(data);
                        if (rs > 0)
                        {
                            Clear(true);
                        }
                    }
                    else
                    {
                        var chqdup = _uow.GenreMastRepository.Read().FirstOrDefault(p => p.genCode.ToUpper().Equals(data.genreCode.ToUpper()));
                        if (chqdup is null)
                        {
                            var rs = _uow.GenreMastRepository.Insert(data);
                            if (rs > 0)
                            {
                                Clear(true);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"{chqdup.genCode} มีอยู่แล้ว", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        } 
                    }
                }
                else if (MappingParam.Season.Equals(this._mapCode))
                {
                    var data = new SeasonMastModel
                    {
                        seasonId = this.id,
                        seasonCode = this.codetxt.Text,
                        seasonDesc = this.desctxt.Text,
                        recStatus = this.recstatuscbb.SelectedValue.ToString(),
                        sortSeq = Convert.ToInt32(this.sortseqnb.Value),
                        updateBy = Constants.UserApp,
                        updateDate = DateTime.Now,
                        createDate = DateTime.Now,
                        createBy = Constants.UserApp,
                    };
                    if (("U").Equals(this.IU_Flag))
                    {
                        var rs = _uow.SeasonMastRepository.UpdateById(data);
                        if (rs > 0)
                        {
                            Clear(true);
                        }
                    }
                    else
                    {
                        var chqdup = _uow.SeasonMastRepository.Read().FirstOrDefault(p => p.seaCode.ToUpper().Equals(data.seasonCode.ToUpper()));
                        if (chqdup is null)
                        {
                            var rs = _uow.SeasonMastRepository.Insert(data);
                            if (rs > 0)
                            {
                                Clear(true);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"{chqdup.seaCode} มีอยู่แล้ว", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else if (MappingParam.MapSetingParameter.Equals(this._mapCode))
                {
                    var data = new MapSettingParamModel
                    {
                        mapId = this.id,
                        mapCode = this.codetxt.Text,
                        mapDesc = this.desctxt.Text,
                        recStatus = this.recstatuscbb.SelectedValue.ToString(),
                        mapTbName = this.tablenametxt.Text,
                        sortSeq = Convert.ToInt32(this.sortseqnb.Value),
                        updateBy = Constants.UserApp,
                        updateDate = DateTime.Now,
                        createDate = DateTime.Now,
                        createBy = Constants.UserApp,
                    };
                    if (("U").Equals(this.IU_Flag))
                    {
                        var rs = _uow.MapSetingParamRepository.UpdateById(data);
                        if (rs > 0)
                        {
                            Clear(true);
                        }
                    }
                    else
                    {
                        var chqdup = _uow.MapSetingParamRepository.Read().FirstOrDefault(p => p.mapCode.ToUpper().Equals(data.mapCode.ToUpper()));
                        if (chqdup is null)
                        {
                            var rs = _uow.MapSetingParamRepository.Insert(data);
                            if (rs > 0)
                            {
                                Clear(true);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"{chqdup.mapCode} มีอยู่แล้ว", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอก Code ด้วย", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void codetxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveSettingParam();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void desctxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveSettingParam();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void tablenametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveSettingParam();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void sortseqnb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveSettingParam();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void SettingForm_KeyDown(object sender, KeyEventArgs e)
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

        private void settingtap_KeyDown(object sender, KeyEventArgs e)
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

        private void gbtn_Click(object sender, EventArgs e)
        {
            if (MappingParam.Status.Equals(this._mapCode))
            {
                var maxseq = _uow.StsMastRepository.Read().Max(p => p.sortSeq) ?? 0;
                this.sortseqnb.Value = maxseq +1;

            }
            else if (MappingParam.ListType.Equals(this._mapCode))
            {
                var maxseq = _uow.ListTypeMastRepository.Read().Max(p => p.sortSeq) ?? 0;
                this.sortseqnb.Value = maxseq + 1;
            }
            else if (MappingParam.Genre.Equals(this._mapCode))
            {
                var maxseq = _uow.GenreMastRepository.Read().Max(p => p.sortSeq) ?? 0;
                this.sortseqnb.Value = maxseq + 1;
            }
            else if (MappingParam.Season.Equals(this._mapCode))
            {
                var maxseq = _uow.SeasonMastRepository.Read().Max(p => p.sortSeq) ?? 0;
                this.sortseqnb.Value = maxseq + 1;
            }
            else if (MappingParam.MapSetingParameter.Equals(this._mapCode))
            {
                var maxseq = _uow.MapSetingParamRepository.Read().Max(p => p.sortSeq) ?? 0;
                this.sortseqnb.Value = maxseq + 1;
            }
        }

        private void gencodebtn_Click(object sender, EventArgs e)
        {
            var textArray = this.desctxt.Text.Split(' ');
            if (textArray.Length == 2)
            {
                var year = textArray[1];
                var season = textArray[0].ToUpper();
                this.codetxt.Text = $"{year}{Utility.GetSeasonalList().FirstOrDefault(p => p.seasonDesc.ToUpper().Equals(season)).seasonCode}";
            }
        }
    }
}
