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
using System.Data.SQLite;

namespace Abiturient
{
    public partial class Stud_Subj : Form
    {
        protected string connectionstring;
        private Generation_Class generation_class;

        public Stud_Subj(string connectionstring)
        {
            InitializeComponent();
            this.connectionstring = connectionstring;
            generation_class = new Generation_Class(this.connectionstring);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteDataReader read_sub = generation_class.writerTable("Subject");
            SQLiteDataReader read_stud = generation_class.writerTable("Abiturient");

            int count_mas = 5;
            int max = 0;
            int min = 0;
            int[] mas_id_sub = new int[count_mas];
            int i = 0;
            while (read_sub.Read())
            {
                mas_id_sub[i] = Convert.ToInt32(read_sub.GetValue(0).ToString());
                i++;
            }
            //Поиск мин и макс id абитуриентов
            min = mas_id_sub[0];
            max = mas_id_sub[0];
            for (int j = 0; j < mas_id_sub.Length - 1; j++)
            {

                for (int k = j + 1; k < mas_id_sub.Length; k++)
                {
                    if (mas_id_sub[k] < min)
                        min = mas_id_sub[k];
                    if (mas_id_sub[k] > max)
                        max = mas_id_sub[k];
                }
            }
            Random rn= new Random();
            int[] mas_sub_3 = new int[5];//Предположим, что каждый студент сдает все 5 предметов*/

            /*while (read_stud.Read())
            {
                for (int j = 0; j < 3; j++)
                {
                    mas_sub_3[j] = rn.Next(min, max);
                    if (j > 0)
                    {
                        int temp = mas_sub_3[j];
                        for (int jj = j - 1; jj >= 0; jj--)
                        {
                            if (temp == mas_sub_3[jj])
                            {
                                j--;
                            }
                        }
                    }
                }
                for (int j = 0; j < mas_sub_3.Length; j++)
                {
                    generation_class.Stud_Sub("AbitSubj", "id_abit", "id_subj", Convert.ToInt32(read_stud.GetValue(0).ToString()), mas_sub_3[j]);
                }

            }*/
            while (read_stud.Read())
            {
                //Предположим, что каждый студент сдает все 5 предметов
                mas_sub_3[0] = min;
                mas_sub_3[1] = min + 1;
                //mas_sub_3[2] = rn.Next(min + 2, max);
                mas_sub_3[2] = min + 2;
                mas_sub_3[3] = min + 3;
                mas_sub_3[4] = max;
                for (int j = 0; j < mas_sub_3.Length; j++)
                {
                    generation_class.Stud_Sub("AbitSubj", "id_abit", "id_subj", Convert.ToInt32(read_stud.GetValue(0).ToString()), mas_sub_3[j]);
                }
            }

            generation_class.writerTableStudentSubj("AbitSubj", DGV_studsubj);
        }

        private void Stud_Subj_Load(object sender, EventArgs e)
        {
            try
            {
                generation_class.writerTableStudentSubj("AbitSubj", DGV_studsubj);
            }
            catch
            {
                MessageBox.Show("Таблица пуста! Заполните ее!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            generation_class.Delete("AbitSubj");
            DGV_studsubj.Rows.Clear();
        }
    }
}
