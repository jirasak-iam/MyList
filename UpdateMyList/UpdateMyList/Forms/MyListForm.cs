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
        public int myListId { get; set; }
        public string IU_Flag { get; set; }
        public bool? rePageFlag { get; set; }
        public string lstStsSelecet { get; set; }
        public bool? clear { get; set; }
        public string similar { get; set; }
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
                gobtn.Enabled = false;
                myListtap.SelectedTab = listtap;
            }
            if (cleaFlag)
            {
                this.stslb.ClearSelected();
                this.stslb.SelectedIndex = 0;
                this.stscbb.SelectedIndex = 0;
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
            _uow = uow;
            _model = model;
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
                    stsId = Convert.ToInt32(this.stscbb.SelectedValue.ToString()),
                    updateBy = "C# Win App",
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
                    stsId = Convert.ToInt32(this.stscbb.SelectedValue.ToString()),
                    recStatus = "A",
                    createBy = "C# Win App",
                    createDate = DateTime.Now,
                    updateDate = DateTime.Now
                };
                rs= _uow.MyListRepository.Insert(data);
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
            dataGridView1.ReadOnly = true;
            search();
            this.stslb.DataSource = _uow.StsMastRepository.SelectAll();
            this.stslb.DisplayMember = "stsDesc";
            this.stslb.ValueMember = "stsId";

            this.stscbb.DataSource = _uow.StsMastRepository.Select();
            this.stscbb.DisplayMember = "stsDesc";
            this.stscbb.ValueMember = "stsId";

        }
        private void search()
        {
            var stsLb = this.stslb.SelectedItems.Cast<StsMastModel>().ToList();
            var stsLbSelect = stsLb?.Select(p => p.stsId).ToList();
            var chkSelect = stsLbSelect?.Sum();
            var searchName = this.searchtxt.Text.ToUpper();
            if (_model != null)
            {
                var getByType = _uow.MyListRepository.SelectByType(_model);
                if (chkSelect > 0)
                {
                    getByType = getByType.Where(p => stsLbSelect.Contains(p.stsId)).ToList();
                }
                if (!string.IsNullOrEmpty(searchName))
                {
                    getByType = getByType.Where(p => p.listName.ToUpper().Contains(searchName)).ToList();
                }
                this.setDataGrid(getByType);
            }
        }
        private void setDataGrid(List<MyListModel> lstModel)
        {
            try
            {
                var preData = (from a in lstModel
                               select new DataGridViewModel
                               {
                                   listCode = a.listCode,
                                   listName = a.listName,
                                   listLink = a.listLink,
                                   stsDesc = a.stsDesc,
                                   listEP = a.listEP,
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
                this.dataGridView1.Columns[5].HeaderText = "แก้ไขล่าสุด";
                this.dataGridView1.Columns[5].Width = 125;
                this.dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            gobtn.Enabled = true;
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = 0;

            var myListId = (int)dataGridView1.Rows[rowindex].Cells[columnindex].Value;
            if (myListId > 0)
            {
                var data = _uow.MyListRepository.Read().FirstOrDefault(p => p.listTypeId == _model.listTypeId && p.listCode == myListId);

                nametxt.Text = data.listName;
                ePtxt.Text = data.listEP;
                linkUrltxt.Text = data.listLink;
                stscbb.SelectedIndex = data.stsId - 1;
                this.commenttxt.Text = data.listComment;
                this.myListId = data.listId;

                myListtap.SelectedTab = inserttap;

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
            if (!string.IsNullOrEmpty(linkUrltxt.Text))
            {
                try
                {
                    Process.Start(linkUrltxt.Text);
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
                        if (!Constants.badWord.ToList().Where(p => p.Equals(item)).ToList().Any())
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
    }
}
