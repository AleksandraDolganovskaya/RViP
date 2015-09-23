using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Abiturient
{
    public partial class Specialty : Form
    {

         protected string connectionstring;
        private Generation_Class generation_class;
        public Specialty(string connectionstring)
        {
            InitializeComponent();
            this.connectionstring = connectionstring;
            generation_class = new Generation_Class(this.connectionstring);
        }
        private void Specialty_Load(object sender, EventArgs e)
        {
            try 
            {
            string nameTable = "Specialty";
            generation_class.writerTableStaudent1(nameTable, DGV_specialty);
            }
            catch
            {
                MessageBox.Show("Таблица пуста! Заполните ее!");
            }
        }

        private void BTN_generation_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(TB_abit.Text);
            string nameTable = "Specialty";
            string parametr1 = "name";
            string parametr2 = "amount";
            string name = "Специальность";
            generation_class.genAdd1(n, nameTable, parametr1,parametr2, DGV_specialty, name);
            generation_class.writerTableStaudent1(nameTable, DGV_specialty);

        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            generation_class.Delete("Specialty");
            DGV_specialty.Rows.Clear();
        }
    }
}
