using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Abiturient
{
    class Generation_Class
    {
        protected string connectionstring;
        public SQLiteConnection con;
        public Generation_Class(string connectionstring)
        {
            this.connectionstring = connectionstring;
            con = new SQLiteConnection(this.connectionstring);
            con.Open();
        }
 
        /// <summary>
        /// Добавление записей в таблица Абитуриент
        /// </summary>
        /// <param name="n"></param>
        /// <param name="nameTable"></param>
        /// <param name="parametr"></param>
        /// <param name="DGV_abiturient"></param>
        /// <param name="name"></param>
        public void GenAdd(int n, string nameTable, string parametr, DataGridView DGV_abiturient, string name)
        {
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * from " + nameTable, con);
                for (int i = 0; i < n; i++)
                {
                    adapter.InsertCommand = new SQLiteCommand("INSERT INTO " + nameTable + " (" + parametr + @") VALUES ('" + name + i.ToString() + @"')", con);
                    adapter.InsertCommand.ExecuteNonQuery();
                }            
        }


        /// <summary>
        /// Метод считывания и отображения таблицы Абитуриент
        /// </summary>
        /// <param name="nameTable"></param>
        /// <param name="DGV_abiturient"></param>
        public void WriterTableStaudent(string nameTable, DataGridView DGV_abiturient)
        {
            SQLiteDataAdapter adapter_read = new SQLiteDataAdapter("SELECT * from " + nameTable, con);
            adapter_read.SelectCommand = new SQLiteCommand("SELECT * from " + nameTable, con);
            SQLiteDataReader table_read = adapter_read.SelectCommand.ExecuteReader();
            while (table_read.Read())
            {
                DGV_abiturient.Rows.Add(table_read.GetValue(0).ToString(), table_read.GetValue(1).ToString());
            }
        }

      //  public void GenAdd1(int n, string nameTable, string parametr1,string parametr2, DataGridView DGV_abiturient, string name)
      //  {
      //      SqlConnection con = new SqlConnection(connectionstring);
      //      con.Open();
      //      Random rn = new Random();
      //      SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from " + nameTable, con);
      //      adapter.InsertCommand = new SqlCommand("INSERT INTO " + nameTable + " (" + parametr1+","+ parametr2+ ") VALUES (@FIO, @Amount )", con);
      //      adapter.InsertCommand.Parameters.Add("@FIO", SqlDbType.VarChar);
      //      adapter.InsertCommand.Parameters.Add("@Amount", SqlDbType.Int);
      //      for (int i = 0; i < n; i++)
      //      {
      //          adapter.InsertCommand.Parameters[0].Value = name + i.ToString();
      //          adapter.InsertCommand.Parameters[1].Value = rn.Next(20, 30);
      //          adapter.InsertCommand.ExecuteNonQuery();
      //      }

      //      con.Close();
      //  }

        /// <summary>
        /// Добавление записей в таблицу Специальность
        /// </summary>
        /// <param name="n"></param>
        /// <param name="nameTable"></param>
        /// <param name="parametr"></param>
        /// <param name="parametr2"></param>
        /// <param name="DGV_abiturient"></param>
        /// <param name="name"></param>
        public void genAdd1(int n, string nameTable, string parametr,string parametr2, DataGridView DGV_abiturient, string name)
        {
            Random rn = new Random();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * from " + nameTable, con);
            for (int i = 0; i < n; i++)
            {
                adapter.InsertCommand = new SQLiteCommand("INSERT INTO " + nameTable + " (" + parametr +","+parametr2+ @") VALUES ('" + name + i.ToString() +"','"+rn.Next(5,12)+ @"')", con);
                adapter.InsertCommand.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// Добавление записей в таблицу "Специальность-Предмет"
        /// </summary>
        /// <param name="nameTable"></param>
        /// <param name="parametr1"></param>
        /// <param name="parametr2"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        public void Spec_Sub(string nameTable, string parametr1, string parametr2, int value1, int value2)
        {
            Random rn = new Random();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * from " + nameTable, con);
            adapter.InsertCommand = new SQLiteCommand("INSERT INTO " + nameTable + " (" + parametr1 + "," + parametr2 + @") VALUES ('"+value1+"','"+value2+@"')",con);
            adapter.InsertCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// Добавление таблицыАбитуриент-Предмет
        /// </summary>
        /// <param name="nameTable"></param>
        /// <param name="parametr1"></param>
        /// <param name="parametr2"></param>
        /// <param name="parametr3"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        public void Stud_Sub(string nameTable, string parametr1, string parametr2, int value1, int value2)
        {
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * from " + nameTable, con);
            adapter.InsertCommand = new SQLiteCommand("INSERT INTO " + nameTable + " (" + parametr1 + "," + parametr2 + @") VALUES ('" + value1 + "','" + value2 +  @"')", con);
            adapter.InsertCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// Удаление таблицы Специальность
        /// </summary>
        /// <param name="nameTable"></param>
        /// <param name="DGV_abiturient"></param>
        public void writerTableStaudent1(string nameTable, DataGridView DGV_abiturient)
        {
            SQLiteDataAdapter adapter_read = new SQLiteDataAdapter("SELECT * from " + nameTable, con);
            adapter_read.SelectCommand = new SQLiteCommand("SELECT * from " + nameTable, con);
            SQLiteDataReader table_read = adapter_read.SelectCommand.ExecuteReader();
            while (table_read.Read())
            {
                DGV_abiturient.Rows.Add(table_read.GetValue(0).ToString(), table_read.GetValue(1).ToString(), table_read.GetValue(2).ToString());
            }
        }
      ///*  public void WriterTableStaudent12(string nameTable, DataGridView DGV_abiturient)
      //  {
      //      SqlConnection con = new SqlConnection(connectionstring);
      //      con.Open();

      //      SqlDataAdapter adapter_read = new SqlDataAdapter("SELECT * from " + nameTable, con);
      //      adapter_read.SelectCommand = new SqlCommand("SELECT * from " + nameTable, con);
      //      SqlDataAdapter read_spec = new SqlDataAdapter("SELECT * from Specialty", con);
      //      read_spec.SelectCommand = new SqlCommand("SELECT * from Specialty", con);
      //      SqlDataAdapter read_subj = new SqlDataAdapter("SELECT * from Subject", con);
      //      read_subj.SelectCommand = new SqlCommand("SELECT * from Subject", con);
      //      SqlDataReader table_read = adapter_read.SelectCommand.ExecuteReader();
      //      SqlDataReader table_read1 = read_spec.SelectCommand.ExecuteReader();
      //      SqlDataReader table_read2 = read_subj.SelectCommand.ExecuteReader();
      //      while (table_read.Read())
      //      {
      //          while ()
      //          if (Convert.ToInt32(table_read.GetValue(1))==)
      //          DGV_abiturient.Rows.Add(table_read.GetValue(0).ToString(), table_read.GetValue(1).ToString(), table_read.GetValue(2).ToString());
      //      }

      //      con.Close();
      //  }
      //  */
        /// <summary>
        /// Вывод таблицы Абитуриент-Предмет
        /// </summary>
        /// <param name="nameTable"></param>
        /// <param name="DGV_abiturient"></param>
        public void writerTableStudentSubj(string nameTable, DataGridView DGV_abiturient)
        {
            SQLiteDataAdapter adapter_read = new SQLiteDataAdapter("SELECT * from " + nameTable, con);
            adapter_read.SelectCommand = new SQLiteCommand("SELECT * from " + nameTable, con);
            SQLiteDataReader table_read = adapter_read.SelectCommand.ExecuteReader();
            while (table_read.Read())
            {
                DGV_abiturient.Rows.Add(table_read.GetValue(0).ToString(), table_read.GetValue(1).ToString(), table_read.GetValue(2).ToString());
            }
        }

        /// <summary>
        /// Отображение таблицы
        /// </summary>
        /// <param name="nameTable"></param>
        /// <returns></returns>
        public SQLiteDataReader writerTable(string nameTable)
        {
            SQLiteDataAdapter adapter_read = new SQLiteDataAdapter("SELECT * from " + nameTable, con);
            adapter_read.SelectCommand = new SQLiteCommand("SELECT * from " + nameTable, con);
            SQLiteDataReader table_read = adapter_read.SelectCommand.ExecuteReader();
            return table_read;
        }

      //  //public SqlDataReader Count(string nameTable)
      //  //{
      //  //    SqlConnection con = new SqlConnection(connectionstring);
      //  //    con.Open();

      //  //    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from " + nameTable, con);
      //  //    adapter.SelectCommand = new SqlCommand("SELECT * from " + nameTable + "; Select @@rowcount", con);
             
      //  //   SqlDataReader read = adapter.SelectCommand.ExecuteReader();
      //  //   return read;
      //  //}

      //  public SqlDataReader IdSubj(int value)
      //  {
      //      SqlConnection con = new SqlConnection(connectionstring);
      //      con.Open();

      //      SqlDataAdapter adapter_read = new SqlDataAdapter("SELECT * from Spec_subj", con);
      //      adapter_read.SelectCommand = new SqlCommand("SELECT ID_subject from Spec_subj Where ID_specialty = @value ", con);
      //      adapter_read.SelectCommand.Parameters.Add("@value", SqlDbType.Int);
      //      adapter_read.SelectCommand.Parameters[0].Value = value;

      //      SqlDataReader table_read = adapter_read.SelectCommand.ExecuteReader();

      //      return table_read;
      //  }

      //  public SqlDataReader Score(int value, int value1)
      //  {
      //      SqlConnection con = new SqlConnection(connectionstring);
      //      con.Open();

      //      SqlDataAdapter adapter_read = new SqlDataAdapter("SELECT * from Student_subj", con);
      //      adapter_read.SelectCommand = new SqlCommand("SELECT Scores from Student_subj Where ID_subj = @value AND ID_student = @value1 ", con);
      //      adapter_read.SelectCommand.Parameters.Add("@value", SqlDbType.Int);
      //      adapter_read.SelectCommand.Parameters.Add("@value1", SqlDbType.Int);
      //      adapter_read.SelectCommand.Parameters[0].Value = value;
      //      adapter_read.SelectCommand.Parameters[1].Value = value1;

      //      SqlDataReader table_read = adapter_read.SelectCommand.ExecuteReader();

      //      return table_read;
      //  }

        /// <summary>
        /// Добавление записи в таблицу "АбитуриентСпециальность"
        /// </summary>
        /// <param name="nameTable"></param>
        /// <param name="parametr1"></param>
        /// <param name="parametr2"></param>
        /// <param name="parametr3"></param>
        /// <param name="parametr4"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="value4"></param>
        public void AbitSpec( string nameTable, string parametr1, string parametr2, string parametr3, string parametr4, int value1, int value2, int value3, int value4)
        {
            Random rn = new Random();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * from " + nameTable, con);
            adapter.InsertCommand= new SQLiteCommand("INSERT INTO " + nameTable + " (" + parametr1 + "," + parametr2 + "," + parametr3 + "," + parametr4 + @") VALUES ('" + value1 + "','" + value2 + "','" + value3 + "','" + value4 + @"')", con);
            adapter.InsertCommand.ExecuteNonQuery(); 
        }

        /// <summary>
        /// Вывод таблицы "Абитуриент-Специальность"
        /// </summary>
        /// <param name="nameTable"></param>
        /// <param name="DGV_abiturient"></param>
        public void writerTableAbitSpec(string nameTable, DataGridView DGV_abiturient)
        {
            SQLiteDataAdapter adapter_read = new SQLiteDataAdapter("SELECT * from " + nameTable, con);
            adapter_read.SelectCommand = new SQLiteCommand("SELECT * from " + nameTable, con);
            SQLiteDataReader table_read = adapter_read.SelectCommand.ExecuteReader();
            while (table_read.Read())
            {
                DGV_abiturient.Rows.Add(table_read.GetValue(0).ToString(), table_read.GetValue(1).ToString(), table_read.GetValue(2).ToString(), table_read.GetValue(3).ToString(), table_read.GetValue(4).ToString());
            }
        }

      //  public int Sum(int idspec, int idstud)
      //  {
      //      int sum = 0;
      //      SqlDataReader readsubj = IdSubj(idspec);
      //      while (readsubj.Read())
      //      {
      //          SqlDataReader readScore = Score(Convert.ToInt32(readsubj.GetValue(0)), Convert.ToInt32(idstud));
      //          while (readScore.Read())
      //          {
      //              sum += Convert.ToInt32(readScore.GetValue(0));
      //          }
      //      }
      //      return sum;
      //  }
        /// <summary>
        /// Удаление записей из справочников
        /// </summary>
        /// <param name="nametable"></param>
        public void Delete(string nametable)
        {
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * from " + nametable, con);
            adapter.DeleteCommand = new SQLiteCommand("Delete from " + nametable, con);
            adapter.DeleteCommand.ExecuteNonQuery();
        }

      //  public SqlDataReader Spiski(int value)
      //  {
      //      SqlConnection con = new SqlConnection(connectionstring);
      //      con.Open();
      //      SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from Priority", con);
      //      adapter.SelectCommand = new SqlCommand("SELECT * From Priority Where ID_specialty = @value", con);
      //      adapter.SelectCommand.Parameters.Add("@value", SqlDbType.Int);
      //      adapter.SelectCommand.Parameters[0].Value = value;
      //      SqlDataReader read = adapter.SelectCommand.ExecuteReader();
      //    //  con.Close();
      //      return read;
      //  }
    
    }
}
