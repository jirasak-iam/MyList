using AutoMapper;
using Newtonsoft.Json;
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
        private IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private string IU_Flag = "I";
        private string _mapCode = "";
        private string _code = "";
        private int id = 0;
        public SettingForm(IUnitOfWork uow)
        {
            InitializeComponent();
            _uow = uow;
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
        }
        private void Clear(bool loadGrid)
        {
            this.IU_Flag = "";
            this.codetxt.Text = "";
            this.desctxt.Text = "";
            this.recstatuscbb.SelectedIndex = 0;
            this.sortseqnb.Value = 0;
            this.settingtap.SelectedTab = tabPage1;
            //this._mapCode = "";
            this._code = "";
            this.id = 0;
            ClearSelection();
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

            this.listTypeclb.DataSource = _uow.ListTypeMastRepository.Select();
            this.listTypeclb.DisplayMember = "listTypeDesc";
            this.listTypeclb.ValueMember = "listTypeId";

            this.consumecbb.DataSource = _uow.ConsumeTypeRepository.Select();
            this.consumecbb.DisplayMember = "consumeTypDisplay";
            this.consumecbb.ValueMember = "consumeTypeId";
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
                    preData = rawData.Select(a =>
                       new DataGridViewSettingModel
                       {
                           code = a.stsCode,
                           desc = a.stsDesc,
                           recStatus = Utility.SetRecDesc(a.recStatus),
                           sortSeq = a.sortSeq,
                           updateDate = a.updateDateStr
                       }).ToList();
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
                }
                else if (MappingParam.Season.Equals(data.mapCode))
                {
                    var rawData = _uow.SeasonMastRepository.SelectAllType();
                    preData = rawData.Select(a =>
                       new DataGridViewSettingModel
                       {
                           code = a.seaCode,
                           desc = a.seaDesc,
                           recStatus = Utility.SetRecDesc(a.recStatus),
                           sortSeq = a.sortSeq,
                           updateDate = a.updateDateStr
                       }).ToList();
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
                }
                else if (MappingParam.ConsumeType.Equals(data.mapCode))
                {
                    var rawData = _uow.ConsumeTypeRepository.SelectAll();
                    preData = rawData.Select(a =>
                       new DataGridViewSettingModel
                       {
                           code = a.consumeTypeCode,
                           desc = a.consumeTypeDesc,
                           recStatus = Utility.SetRecDesc(a.recStatus),
                           sortSeq = a.sortSeq,
                           updateDate = a.updateDateStr
                       }).ToList();
                }
                if (!string.IsNullOrEmpty(this.txtcode.Text))
                {
                    preData = preData.Where(p => p.code.ToUpper().Contains(this.txtcode.Text.ToUpper())).ToList();
                }
                if (!string.IsNullOrEmpty(this.txtdesc.Text))
                {
                    preData = preData.Where(p => p.desc.ToUpper().Contains(this.txtdesc.Text.ToUpper())).ToList();
                }
                this.dataGridView1.DataSource = preData;

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
            Search();
        }
        private void Search()
        {
            SearchOption();
            this.settingtap.SelectedTab = tabPage1;
            var selectItem = (MapSettingParamModel)this.mapcbb.SelectedItem;
            this._mapCode = selectItem.mapCode;
            if (MappingParam.MapSetingParameter.Equals(selectItem.mapCode))
            {
                this.label9.Visible = false;
                this.consumecbb.Visible = false;
                label6.Visible = true;
                tablenametxt.Visible = true;
                this.seasonlistlb.Visible = false;
                this.gencodebtn.Visible = false;
                this.listTypeclb.Visible = false;
            }
            else if (MappingParam.Season.Equals(selectItem.mapCode))
            {
                this.label9.Visible = false;
                this.consumecbb.Visible = false;
                label6.Visible = false;
                tablenametxt.Visible = false;
                this.seasonlistlb.Visible = true;
                this.listTypeclb.Visible = true;
                this.seasonlistlb.DataSource = Utility.GetSeasonalList();
                this.seasonlistlb.DisplayMember = "seasonDisplay";
                this.seasonlistlb.ValueMember = "seaCode";
                this.gencodebtn.Visible = true;
            }
            else if(MappingParam.ListType.Equals(selectItem.mapCode))
            {
                this.label9.Visible = true;
                this.consumecbb.Visible = true;
                label6.Visible = false;
                tablenametxt.Visible = false;
                this.seasonlistlb.Visible = false;
                this.gencodebtn.Visible = false;
                this.listTypeclb.Visible = false;
            }
            else
            {
                this.label9.Visible = false;
                this.consumecbb.Visible = false;
                label6.Visible = false;
                tablenametxt.Visible = false;
                this.seasonlistlb.Visible = false;
                this.gencodebtn.Visible = false;
                this.listTypeclb.Visible = false;
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
                    var data = _uow.SeasonMastRepository.SelectAllType().FirstOrDefault(p => code.Equals(p.seaCode));
                    this.codetxt.Text = data.seaCode;
                    this.desctxt.Text = data.seaDesc;
                    this.id = data.seaId;
                    this.recstatuscbb.SelectedValue = data.recStatus;
                    this.sortseqnb.Value = data.sortSeq ?? 0;
                    ClearSelection();
                    var seasonGroup = _uow.SeasonGroupRepository.SelectSeasonGroupBySeaId(data.seaId);
                    if (seasonGroup.Count > 0)
                    {
                        for (int i = 0; i < this.listTypeclb.Items.Count; i++)
                        {
                            var listType = (ListTypeModel)this.listTypeclb.Items[i];
                            var chkData = seasonGroup.FirstOrDefault(p => p.listTypeId == listType.listTypeId);
                            if (chkData != null)
                            {
                                this.listTypeclb.SetItemChecked(i, true);
                            }
                        }
                    }
                }
                else if (MappingParam.MapSetingParameter.Equals(this._mapCode))
                {
                    var data = _uow.MapSetingParamRepository.SelectAllType().FirstOrDefault(p => code.Equals(p.mapCode));
                    this.codetxt.Text = data.mapCode;
                    this.desctxt.Text = data.mapDesc;
                    this.id = data.mapId;
                    this.recstatuscbb.SelectedValue = data.recStatus;
                    this.sortseqnb.Value = data.sortSeq ?? 0;
                    this.tablenametxt.Text = data.mapTbName ?? string.Empty;
                }
                else if (MappingParam.ConsumeType.Equals(this._mapCode))
                {
                    var data = _uow.ConsumeTypeRepository.SelectAll().FirstOrDefault(p => code.Equals(p.consumeTypeCode));
                    this.codetxt.Text = data.consumeTypeCode;
                    this.desctxt.Text = data.consumeTypeDesc;
                    this.id = data.consumeTypeId;
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
        private void ClearSelection()
        {
            this.listTypeclb.DataSource = _uow.ListTypeMastRepository.SelectAllType();
            for (int i = 0; i < this.listTypeclb.Items.Count; i++)
            {
                this.listTypeclb.SetItemChecked(i, false);
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
                    if (("U").Equals(this.IU_Flag))
                    {
                        var data = _uow.StsMastRepository.ReadById(this.id);
                        if (data != null)
                        {
                            data.stsCode = this.codetxt.Text;
                            data.stsDesc = this.desctxt.Text;
                            data.recStatus = this.recstatuscbb.SelectedValue.ToString();
                            data.sortSeq = Convert.ToInt32(this.sortseqnb.Value);
                            data.updateBy = Constants.UserApp;
                            data.updateDate = DateTime.Now;
                        }
                        var rs = _uow.Save();
                        if (rs > 0)
                        {
                            Clear(true);
                        }
                    }
                    else
                    {
                        var chqdup = _uow.StsMastRepository.ReadByPredicate(p => p.stsCode.ToUpper().Equals(this.codetxt.Text.ToUpper()));
                        if (chqdup is null)
                        {
                            var data = new StsMast
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
                            _uow.StsMastRepository.Create(data);
                            var rs = _uow.Save();
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

                    if (("U").Equals(this.IU_Flag))
                    {
                        var data = _uow.ListTypeMastRepository.ReadById(this.id);
                        data.listTypeCode = this.codetxt.Text;
                        data.listTypeDesc = this.desctxt.Text;
                        data.recStatus = this.recstatuscbb.SelectedValue.ToString();
                        data.sortSeq = Convert.ToInt32(this.sortseqnb.Value);
                        data.updateBy = Constants.UserApp;
                        data.updateDate = DateTime.Now;
                        var rs = _uow.Save();
                        if (rs > 0)
                        {
                            Clear(true);
                        }
                    }
                    else
                    {
                        var chqdup = _uow.ListTypeMastRepository.ReadByPredicate(p => p.listTypeCode.ToUpper().Equals(this.codetxt.Text.ToUpper()));
                        if (chqdup is null)
                        {
                            var data = new ListTypeMast
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
                            _uow.ListTypeMastRepository.Create(data);
                            var rs = _uow.Save();
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
                    if (("U").Equals(this.IU_Flag))
                    {
                        var data = _uow.GenreMastRepository.ReadById(this.id);
                        data.genCode = this.codetxt.Text;
                        data.genDesc = this.desctxt.Text;
                        data.recStatus = this.recstatuscbb.SelectedValue.ToString();
                        data.sortSeq = Convert.ToInt32(this.sortseqnb.Value);
                        data.updateBy = Constants.UserApp;
                        data.updateDate = DateTime.Now;
                        var rs = _uow.Save();
                        if (rs > 0)
                        {
                            Clear(true);
                        }
                    }
                    else
                    {
                        var chqdup = _uow.GenreMastRepository.ReadByPredicate(p => p.genCode.ToUpper().Equals(this.codetxt.Text.ToUpper()));
                        if (chqdup is null)
                        {
                            var data = new GenreMast
                            {
                                genId = this.id,
                                genCode = this.codetxt.Text,
                                genDesc = this.desctxt.Text,
                                recStatus = this.recstatuscbb.SelectedValue.ToString(),
                                sortSeq = Convert.ToInt32(this.sortseqnb.Value),
                                updateBy = Constants.UserApp,
                                updateDate = DateTime.Now,
                                createDate = DateTime.Now,
                                createBy = Constants.UserApp,
                            };
                            _uow.GenreMastRepository.Create(data);
                            var rs = _uow.Save();
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
                    var rs = 0;
                    if (("U").Equals(this.IU_Flag))
                    {
                        var data = _uow.SeasonMastRepository.ReadById(this.id);
                        data.seaCode = this.codetxt.Text;
                        data.seaDesc = this.desctxt.Text;
                        data.recStatus = this.recstatuscbb.SelectedValue.ToString();
                        data.sortSeq = Convert.ToInt32(this.sortseqnb.Value);
                        data.updateBy = Constants.UserApp;
                        data.updateDate = DateTime.Now;
                        rs = data.seaId;
                        _uow.Save();

                    }
                    else
                    {
                        var chqdup = _uow.SeasonMastRepository.ReadByPredicate(p => p.seaCode.ToUpper().Equals(this.codetxt.Text.ToUpper()));
                        if (chqdup is null)
                        {
                            var data = new SeasonMast
                            {
                                seaId = this.id,
                                seaCode = this.codetxt.Text,
                                seaDesc = this.desctxt.Text,
                                recStatus = this.recstatuscbb.SelectedValue.ToString(),
                                sortSeq = Convert.ToInt32(this.sortseqnb.Value),
                                updateBy = Constants.UserApp,
                                updateDate = DateTime.Now,
                                createDate = DateTime.Now,
                                createBy = Constants.UserApp,
                            };
                            var model = _uow.SeasonMastRepository.ReadByCreate(data);
                            rs = model.seaId;
                            //if (rs > 0)
                            //{
                            //    Clear(true);
                            //}
                        }
                        else
                        {
                            MessageBox.Show($"{chqdup.seaCode} มีอยู่แล้ว", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    var listTypeList = this.listTypeclb.Items;
                    for (int i = 0; i <= this.listTypeclb.Items.Count -1; i++)
                    {
                        if (this.listTypeclb.GetItemCheckState(i) == CheckState.Checked)
                        {
                            var listType = (ListTypeModel)this.listTypeclb.Items[i];
                            var seaGroup = _uow.SeasonGroupRepository.SelectSeasonGroupBySeaId(rs).FirstOrDefault(p => p.listTypeId == listType.listTypeId);
                            if (seaGroup == null)
                            {
                                var seaGroupClose = _uow.SeasonGroupRepository.SelectSeasonGroupBySeaIdButClose(rs).FirstOrDefault(p => p.listTypeId == listType.listTypeId);
                                if (seaGroupClose is null)
                                {
                                    var seasonGroup = new SeasonGroup
                                    {
                                        lisTypetId = listType.listTypeId,
                                        seaId = rs,
                                        recStatus = RecStatus.Active,
                                        createBy = Constants.UserApp,
                                        createDate = DateTime.Now
                                    };
                                    _uow.SeasonGroupRepository.Create(seasonGroup);
                                    _uow.Save();
                                }
                                else
                                {
                                    var seasonGroup = _uow.SeasonGroupRepository.ReadById(seaGroupClose.seagroupId);
                                    seasonGroup.seaId = seaGroupClose.seaId;
                                    seasonGroup.lisTypetId = seaGroupClose.listTypeId;
                                    seasonGroup.recStatus = RecStatus.Active;
                                    seasonGroup.updateBy = Constants.UserApp;
                                    seasonGroup.updateDate = DateTime.Now;
                                    _uow.Save();
                                }
                            }
                        }
                        else if (this.listTypeclb.GetItemCheckState(i) == CheckState.Unchecked)
                        {
                            var listType = (ListTypeModel)this.listTypeclb.Items[i];
                            var seaGroup = _uow.SeasonGroupRepository.SelectSeasonGroupBySeaId(rs).FirstOrDefault(p => p.listTypeId == listType.listTypeId);
                            if (seaGroup != null)
                            {
                                var seasonGroup = _uow.SeasonGroupRepository.ReadById(seaGroup.seagroupId);
                                seasonGroup.lisTypetId = seaGroup.listTypeId;
                                seasonGroup.seaId = rs;
                                seasonGroup.recStatus = RecStatus.Close;
                                seasonGroup.updateBy = Constants.UserApp;
                                seasonGroup.updateDate = DateTime.Now;
                                _uow.Save();
                            }
                        }

                    }
                    if (rs > 0)
                    {
                        Clear(true);
                    }
                }
                else if (MappingParam.MapSetingParameter.Equals(this._mapCode))
                {
                    if (("U").Equals(this.IU_Flag))
                    {
                        var data = _uow.MapSetingParamRepository.ReadById(this.id);
                        data.mapCode = this.codetxt.Text;
                        data.mapDesc = this.desctxt.Text;
                        data.recStatus = this.recstatuscbb.SelectedValue.ToString();
                        data.mapTbName = this.tablenametxt.Text;
                        data.sortSeq = Convert.ToInt32(this.sortseqnb.Value);
                        data.updateBy = Constants.UserApp;
                        data.updateDate = DateTime.Now;
                        var rs = _uow.Save();
                        if (rs > 0)
                        {
                            Clear(true);
                        }
                    }
                    else
                    {
                        var chqdup = _uow.MapSetingParamRepository.ReadByPredicate(p => p.mapCode.ToUpper().Equals(this.codetxt.Text.ToUpper()));
                        if (chqdup is null)
                        {
                            var data = new MapSetingParam
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
                            _uow.MapSetingParamRepository.Create(data);
                            var rs = _uow.Save();
                            if (rs > 0)
                            {
                                Clear(true);
                                this.mapcbb.DataSource = _uow.MapSetingParamRepository.SelectAll();
                            }
                        }
                        else
                        {
                            MessageBox.Show($"{chqdup.mapCode} มีอยู่แล้ว", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else if (MappingParam.ConsumeType.Equals(this._mapCode))
                {
                    if (("U").Equals(this.IU_Flag))
                    {
                        var data = _uow.ConsumeTypeRepository.ReadById(this.id);
                        data.consumeTypeCode = this.codetxt.Text;
                        data.consumeTypeDesc = this.desctxt.Text;
                        data.recStatus = this.recstatuscbb.SelectedValue.ToString();
                        data.sortSeq = Convert.ToInt32(this.sortseqnb.Value);
                        data.updateBy = Constants.UserApp;
                        data.updateDate = DateTime.Now;
                        var rs = _uow.Save();
                        if (rs > 0)
                        {
                            Clear(true);
                        }
                    }
                    else
                    {
                        var chqdup = _uow.ConsumeTypeRepository.ReadByPredicate(p => p.consumeTypeCode.ToUpper().Equals(this.codetxt.Text.ToUpper()));
                        if (chqdup is null)
                        {
                            var data = new ConsumeTypeMast
                            {
                                consumeTypeId = this.id,
                                consumeTypeCode = this.codetxt.Text,
                                consumeTypeDesc = this.desctxt.Text,
                                recStatus = this.recstatuscbb.SelectedValue.ToString(),
                                sortSeq = Convert.ToInt32(this.sortseqnb.Value),
                                updateBy = Constants.UserApp,
                                updateDate = DateTime.Now,
                                createDate = DateTime.Now,
                                createBy = Constants.UserApp,
                            };
                            _uow.ConsumeTypeRepository.Create(data);
                            var rs = _uow.Save();
                            if (rs > 0)
                            {
                                Clear(true);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"{chqdup.consumeTypeCode} มีอยู่แล้ว", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                this.sortseqnb.Value = maxseq + 1;

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
            else if (MappingParam.ConsumeType.Equals(this._mapCode))
            {
                var maxseq = _uow.ConsumeTypeRepository.Read().Max(p => p.sortSeq) ?? 0;
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
                this.codetxt.Text = $"{year}{Utility.GetSeasonalList().FirstOrDefault(p => p.seaDesc.ToUpper().Equals(season)).seaCode}";
            }
        }

        private void txtcode_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void txtdesc_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void listTypeclb_Click(object sender, EventArgs e)
        {
            var state = this.listTypeclb.GetItemCheckState(this.listTypeclb.SelectedIndex);
            if (state == CheckState.Checked)
            {
                this.listTypeclb.SetItemChecked(this.listTypeclb.SelectedIndex, false);
            }
            else if (state == CheckState.Unchecked)
            {
                this.listTypeclb.SetItemChecked(this.listTypeclb.SelectedIndex, true);
            }
        }
    }
}
