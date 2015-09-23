using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace Abiturient
{
    class DB
    {
        protected string connectionstring;
        protected string tableAbiturient = @"CREATE TABLE Abiturient(id INTEGER PRIMARY KEY, fio TEXT)";
        protected string tableSubject = @"CREATE TABLE Subject(id INTEGER PRIMARY KEY, name TEXT)";
        protected string tableSpecialty = @"CREATE TABLE Specialty(id INTEGER PRIMARY KEY, name TEXT, amount INTEGER)";
        protected string tableAbitSubj = @"CREATE TABLE AbitSubj(id INTEGER PRIMARY KEY, id_abit INTEGER, id_subj INTEGER,  FOREIGN KEY(id_abit) REFERENCES Abiturient(id), FOREIGN KEY(id_subj) REFERENCES Subject(id))";
        protected string tableAbitSpec = @"CREATE TABLE AbitSpec(id INTEGER PRIMARY KEY, id_abit INTEGER, id_spec INTEGER, prior INTEGER, scores INTEGER, FOREIGN KEY(id_abit) REFERENCES Abiturient(id), FOREIGN KEY(id_spec) REFERENCES Specialty(id))";
        protected string tableSpecSubj = @"CREATE TABLE SpecSubj(id INTEGER PRIMARY KEY, id_spec INTEGER, id_subj INTEGER,  FOREIGN KEY(id_subj) REFERENCES Subject(id), FOREIGN KEY(id_spec) REFERENCES Specialty(id))";        
        protected SQLiteConnection sql;
        public DB(string connectionstring)
        {
            this.connectionstring = connectionstring;
            sql = new SQLiteConnection(connectionstring);
            sql.Open();
        }
        public void createTables()
        { 
            createQuery(tableAbiturient);
            createQuery(tableSubject);
            createQuery(tableSpecialty);
            createQuery(tableAbitSubj);
            createQuery(tableAbitSpec);
            createQuery(tableSpecSubj);
        }

        private void createQuery(string strQuery)
        {
            SQLiteCommand sc = new SQLiteCommand(sql);
            sc.CommandText = strQuery;
            sc.ExecuteNonQuery();
        }

        /// <summary>
        /// Читает таблицу "Специальность"
        /// </summary>
        /// <returns></returns>
        public DataTable readTableSpecialty()
        {
            SQLiteCommand command = new SQLiteCommand(sql);
            command.CommandText = @"SELECT * FROM Specialty";
            SQLiteDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }

        /// <summary>
        /// Отбирает абитуриентов по специальности
        /// </summary>
        /// <param name="id_spec"></param>
        public DataTable selectAbitOnSpec(int id_spec)
        {
            SQLiteCommand command = new SQLiteCommand(sql);
            command.CommandText = @"SELECT abitSpec.id_abit, abit.fio, abitSpec.prior, abitSpec.scores FROM AbitSpec AS abitSpec INNER JOIN Abiturient AS abit ON abitSpec.id_abit = abit.id WHERE abitSpec.id_spec='" + id_spec + "'";
            SQLiteDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }
    }
}
