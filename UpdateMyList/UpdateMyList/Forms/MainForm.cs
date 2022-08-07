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
            var listType = _uow.ListTypeMastRepository.Select();
            this.listTypelb.DataSource = listType;
            this.listTypelb.DisplayMember = "listTypeDesc";
            this.listTypelb.ValueMember = "listTypeId";
        }

        private void listTypelb_DoubleClick(object sender, EventArgs e)
        {
            openForm();
        }

        private void listTypelb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
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
