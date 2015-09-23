using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Abiturient
{
    class ListsStudents
    {
        protected string connectionstring;
        protected DB db;
        protected int amount = 0;
        List<SpecialtyClass> listSpecWithAbit;
        List<ListAbiturienClass> listAbit;

        public ListsStudents(string connectionstring)
        {
            this.connectionstring = connectionstring;
            db = new DB(connectionstring);
            listSpecWithAbit = new List<SpecialtyClass>();
            
        }

        public List<SpecialtyClass> WriterLists()
        {
            createListsSpecWithAbit();
            sortLists();
            //selectPrior(1);
            return listSpecWithAbit;
        }

        public List<SpecialtyClass> writerNewLists()
        {
            do
            {
                selectPrior(1);
            }
            while (amount != 0);
            do
            {
                selectPrior(2);
                do
                {
                    selectPrior(1);
                }
                while (amount != 0);
            }
            while (amount != 0);
            return listSpecWithAbit;
        }

        /// <summary>
        /// Создание списков абитуриентов по каждой специальности
        /// </summary>
        private void createListsSpecWithAbit()
        {
            DataTable dt_spec = db.readTableSpecialty();
            foreach(DataRow row_spec in dt_spec.Rows)
            {
                SpecialtyClass spec = new SpecialtyClass { ID = Convert.ToInt32(row_spec[0]), Specialty = row_spec[1].ToString(), Amount = Convert.ToInt32(row_spec[2]), listAbitur = createListAbit(Convert.ToInt32(row_spec[0]))};
                listSpecWithAbit.Add(spec);
            }
        }

        private List<ListAbiturienClass> createListAbit(int id_spec)
        {
            listAbit = new List<ListAbiturienClass>();
            DataTable dt_abit = db.selectAbitOnSpec(id_spec);
            foreach (DataRow row_abit in dt_abit.Rows)
            {
                ListAbiturienClass abit = new ListAbiturienClass { ID = Convert.ToInt32(row_abit[0]), FIO = row_abit[1].ToString(), Prior = Convert.ToInt32(row_abit[2]), Scores = Convert.ToInt32(row_abit[3]) };
                listAbit.Add(abit);
            }
            return listAbit;
        }

        /// <summary>
        /// Отсортировать списки абитуриентов
        /// </summary>
        public void sortLists()
        {
            foreach (var i in listSpecWithAbit)
            {
                i.listAbitur.Sort(delegate(ListAbiturienClass ab1, ListAbiturienClass ab2)
                { return ab1.Scores.CompareTo(ab2.Scores); });
                i.listAbitur.Reverse();
            }
        }

        private void selectPrior(int prior)
        {
            SpecialtyClass[] spec_array = listSpecWithAbit.ToArray();
            amount = 0;
            int specCount = 0;
            do
            {
                int studCount = 0;
                ListAbiturienClass[] array = spec_array[0].listAbitur.ToArray();
                for (int j = 0; j < array.Length; j++)
                {
                    if (studCount != spec_array[0].Amount)
                    {
                        if (array[j].Prior == prior)
                        {
                            if(array[j].Prior == 1)
                                deleteAbitur(array[j].ID, spec_array);
                            else
                                deleteAbitur2(array[j].ID, spec_array);
                        }
                        studCount++;
                    }
                }


                SpecialtyClass temp = spec_array[0];

                for (int k = 0; k < spec_array.Length - 1; k++)
                {
                    spec_array[k] = spec_array[k + 1];
                }
                spec_array[spec_array.Length - 1] = temp;
                specCount++;
            } while (specCount != spec_array.Length);
        }

        private void deleteAbitur(int id_abit, SpecialtyClass[] spec_array)
        {
            for (int i = 1; i < spec_array.Length; i++ )
            {
                    foreach (var j in spec_array[i].listAbitur)
                    {
                        if (j.ID == id_abit)
                        {
                            spec_array[i].listAbitur.Remove(j);
                            amount++;
                            break;
                        }
                    }
            }
        }

        private void deleteAbitur2(int id_abit, SpecialtyClass[] spec_array)
        {
            for (int i = 1; i < spec_array.Length; i++)
            {
                foreach (var j in spec_array[i].listAbitur)
                {
                    if (j.ID == id_abit && j.Prior == 3)
                    {
                        spec_array[i].listAbitur.Remove(j);
                        amount++;
                        break;
                    }
                }
            }
        }


    }
}
