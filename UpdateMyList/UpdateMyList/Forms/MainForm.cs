using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UpdateMyList.Entity;
using UpdateMyList.Entity.Model;

namespace UpdateMyList.Forms
{
    public partial class MainForm : Form
    {
        private readonly IUnitOfWork _uow;
        public MainForm(IUnitOfWork uow)
        {
            InitializeComponent();
            _uow = uow;
        }

        private void listTypelb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var config = _uow.ConfigMyListRepository.Read().FirstOrDefault();
            var dataPerPage = config.DataPerPage ?? 0;
            var sortmode = config.sortmode.Split(',');
            var sortcolumn = sortmode.Length == 2 ? sortmode[0] : "";
            var sortorder = sortmode.Length == 2 ? sortmode[1] : "";

            this.similarcb.Checked = (config.IsSimilar ?? false); 

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

            if (sortcolumn.Contains("ID"))
            {
                if (sortorder.Contains("ASC"))
                {
                    this.idascrbtn.PerformClick();
                }
                else if (sortorder.Contains("DESC"))
                {
                    this.iddescrbtn.PerformClick();
                }
            }
            else if (sortcolumn.Contains("DATE"))
            {
                if (sortorder.Contains("ASC"))
                {
                    this.dateascrbtn.PerformClick();
                }
                else if (sortorder.Contains("DESC"))
                {
                    this.datedescrbtn.PerformClick();
                }
            }

            var listType = _uow.ListTypeMastRepository.Select();
            this.listTypelb.DataSource = listType;
            this.listTypelb.DisplayMember = "listTypeDesc";
            this.listTypelb.ValueMember = "listTypeId";
        }
        private string StringSortMode()
        {
            var sortstring = string.Empty;
            if (this.idascrbtn.Checked)
            {
                sortstring = "ID,ASC";
            }
            else if (this.iddescrbtn.Checked)
            {
                sortstring = "ID,DESC";
            }
            else if (this.dateascrbtn.Checked)
            {
                sortstring = "DATE,ASC";
            }
            else if (this.datedescrbtn.Checked)
            {
                sortstring = "DATE,DESC";
            }
            return sortstring;
        }
        private void listTypelb_DoubleClick(object sender, EventArgs e)
        {
            var config = new ConfigMyList();
            if (this.allrbtn.Checked)
            {
                config.DataPerPage = null;
                config.sortmode = StringSortMode();
                config.IsSimilar = this.similarcb.Checked;
                _uow.ConfigMyListRepository.UpdateConfig(config);
            }
            else if (this.tenrbtn.Checked)
            {
                config.DataPerPage = 10;
                config.sortmode = StringSortMode();
                config.IsSimilar = this.similarcb.Checked;
                _uow.ConfigMyListRepository.UpdateConfig(config);
            }
            else if (this.fiftyrbtn.Checked)
            {
                config.DataPerPage = 50;
                config.sortmode = StringSortMode();
                config.IsSimilar = this.similarcb.Checked;
                _uow.ConfigMyListRepository.UpdateConfig(config);
            }
            else if (this.hunrbtn.Checked)
            {
                config.DataPerPage = 100;
                config.sortmode = StringSortMode();
                config.IsSimilar = this.similarcb.Checked;
                _uow.ConfigMyListRepository.UpdateConfig(config);
            }
            openForm();
        }

        private void listTypelb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var config = _uow.ConfigMyListRepository.Read().FirstOrDefault();
                if (this.allrbtn.Checked)
                {
                    config.DataPerPage = null;
                }
                else if (this.tenrbtn.Checked)
                {
                    config.DataPerPage = 10;
                }
                else if (this.fiftyrbtn.Checked)
                {
                    config.DataPerPage = 50;;
                }
                else if (this.hunrbtn.Checked)
                {
                    config.DataPerPage = 100;
                }
                config.IsSimilar = this.similarcb.Checked;
                _uow.Save();
                openForm();
            }
            if (e.KeyCode == Keys.Escape)
            {
                _uow.Dispose();
                this.Close();
            }
        }
        private void openForm()
        {
            try
            {
                var selectItem = (ListTypeModel)listTypelb.SelectedItem;
                //var listTypeid = selectItem.listTypeId;

                var model = new ListTypeModel
                {
                    listTypeId = selectItem.listTypeId,
                    listTypeDesc = selectItem.listTypeDesc,
                    listTypeCode = selectItem.listTypeCode,
                    recStatus = selectItem.recStatus
                };
                this.Hide();
                var myListForm = new MyListForm(_uow, model);
                myListForm.Closed += (s, args) => this.Close();
                myListForm.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _uow.Dispose();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _uow.Dispose();
                this.Close();
            }
        }

        private void settingbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var settingForm = new SettingForm(_uow);
            settingForm.Closed += (s, args) => this.Close();
            settingForm.Show();
        }
    }
}
