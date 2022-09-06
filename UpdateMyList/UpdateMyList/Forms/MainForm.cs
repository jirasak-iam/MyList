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
            var listType = _uow.ListTypeMastRepository.Select();
            this.listTypelb.DataSource = listType;
            this.listTypelb.DisplayMember = "listTypeDesc";
            this.listTypelb.ValueMember = "listTypeId";
        }

        private void listTypelb_DoubleClick(object sender, EventArgs e)
        {
            var config = new ConfigMyList();
            if (this.allrbtn.Checked)
            {
                config.DataPerPage = null;
                _uow.ConfigMyListRepository.UpdateConfig(config);
            }
            else if (this.tenrbtn.Checked)
            {
                config.DataPerPage = 10;
                _uow.ConfigMyListRepository.UpdateConfig(config);
            }
            else if (this.fiftyrbtn.Checked)
            {
                config.DataPerPage = 50;
                _uow.ConfigMyListRepository.UpdateConfig(config);
            }
            else if (this.hunrbtn.Checked)
            {
                config.DataPerPage = 100;
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
                    _uow.Save();
                }
                else if (this.tenrbtn.Checked)
                {
                    config.DataPerPage = 10;
                    _uow.Save();
                }
                else if (this.fiftyrbtn.Checked)
                {
                    config.DataPerPage = 50;
                    _uow.Save();
                }
                else if (this.hunrbtn.Checked)
                {
                    config.DataPerPage = 100;
                    _uow.Save();
                }
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
