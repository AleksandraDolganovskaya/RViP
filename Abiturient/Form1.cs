using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;


namespace Abiturient
{
    public partial class Form1 : Form
    {
        public string connectionstring = @"Data Source=C:\Users\Шурупчик\Documents\RViP_abit\RViP\mydb.sqlite;Version=3";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void BTN_abiturient_Click(object sender, EventArgs e)
        {
            Abiturient form_abiturient = new Abiturient(connectionstring);
            form_abiturient.Show();
        }

        private void BTN_subject_Click(object sender, EventArgs e)
        {
            Subject form_subject = new Subject(connectionstring);
            form_subject.Show();
        }

        private void BTN_specialty_Click(object sender, EventArgs e)
        {
            Specialty form_specialty = new Specialty(connectionstring);
            form_specialty.Show();
        }

        private void BTN_specsubj_Click(object sender, EventArgs e)
        {
            Spec_Subj spec_subj = new Spec_Subj(connectionstring);
            spec_subj.Show();
        }

        private void BTN_abitsubj_Click(object sender, EventArgs e)
        {
            Stud_Subj form_studsubj = new Stud_Subj(connectionstring);
            form_studsubj.Show();
        }

        private void BTN_priority_Click(object sender, EventArgs e)
        {
            Priority form_prior = new Priority(connectionstring);
            form_prior.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Generation_Class generation_class = new Generation_Class(connectionstring);
            ListsStudents listStut = new ListsStudents(connectionstring);
            List<SpecialtyClass> listsStudent = listStut.WriterLists();
            createTabControl(listsStudent, tabControl1);
            List<SpecialtyClass> listNewStudent = listStut.writerNewLists();
            createTabControl(listNewStudent, tabControl2);

            /*SQLiteDataReader read_spec = generation_class.writerTable("Specialty");

            SQLiteDataReader read_spiski = generation_class.writerTable("AbitSpec");
            List<List> list_spisok = new List<List>();
            while (read_spiski.Read())
            {
                list_spisok.Add(new List { ID_student = Convert.ToInt32(read_spiski.GetValue(1)), ID_specialty = Convert.ToInt32(read_spiski.GetValue(2)), Prio = Convert.ToInt32(read_spiski.GetValue(3)), Sum = Convert.ToInt32(read_spiski.GetValue(4)) });
            }

            List<ListSpec> listSpec = new List<ListSpec>();
            while (read_spec.Read())
            {
                listSpec.Add(new ListSpec { ID = Convert.ToInt32(read_spec.GetValue(0)), Specialty = (read_spec.GetValue(1)).ToString(), Amount = Convert.ToInt32(read_spec.GetValue(2)) });
            }
            */
            

               
            
            /*int i = 0;
            foreach (var k in listSpec)
            {
                DataGridView dgv = new DataGridView();
                DataGridView dgv1 = new DataGridView();
                dgv.Name = "DGV" + i.ToString();
                dgv.Width = 500;
                dgv.Height = 500;
                dgv.Left = 0;
                dgv.Top = 0;
                dgv.Columns.Add("123", "Номер_студента");
                dgv.Columns.Add("123", "Приоритет");
                dgv.Columns.Add("123", "Сумма баллов");
                tabControl1.TabPages[i].Controls.Add(dgv);
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                foreach (var j in list_spisok)
                {
                    if (j.ID_specialty == k.ID)
                    {
                        dgv.Rows.Add(j.ID_student, j.Prio, j.Sum);
                    }

                }
                i++;
            } */ 
        }

        private void createTabControl(List<SpecialtyClass> listsStudent, TabControl tab)
        {
            
            int i = 0;
            foreach (var k in listsStudent)
            {
                DataGridView dgv = new DataGridView();
                dgv.Name = "DGV" + i.ToString();
                dgv.Width = 500;
                dgv.Height = 500;
                dgv.Left = 0;
                dgv.Top = 0;
                dgv.Columns.Add("123", "Номер_студента");
                dgv.Columns.Add("123", "Приоритет");
                dgv.Columns.Add("123", "Сумма баллов");
                tab.TabPages[i].Controls.Add(dgv);
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;

                
                    foreach (var j in k.listAbitur)
                    {
                        dgv.Rows.Add(j.ID, j.Prior, j.Scores);

                    }
                i++;

                if (dgv.RowCount != 0)
               {
                   for (int l = 0; l < k.Amount; l++)
                   {
                       dgv.Rows[l].DefaultCellStyle.BackColor = Color.LightCoral;
                   }
               }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection.CreateFile(@"C:\Users\Шурупчик\Documents\RViP_abit\RViP\mydb.sqlite");
            DB db = new DB(connectionstring);
            db.createTables();
        }

        private void btn_srateList_Click(object sender, EventArgs e)
        {
              
        }
    }
}
