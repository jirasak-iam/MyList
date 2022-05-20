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
    public partial class MyListForm : Form
    {
        private readonly IUnitOfWork _uow;
        private ListTypeModel _model;
        public MyListForm(IUnitOfWork uow,ListTypeModel model)
        {
            InitializeComponent();
            _uow = uow;
            _model = model;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

        }

        private void MyListForm_Load(object sender, EventArgs e)
        {
            //this.dataGridView1 = _uow.MyListRepository.SelectByType(_model) ;
        }
    }
}
