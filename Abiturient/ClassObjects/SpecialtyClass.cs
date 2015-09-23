using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abiturient
{
    class SpecialtyClass
    {
        public int ID { get; set; }
        public string Specialty { get; set; }
        public int Amount { get; set; } 
        public List<ListAbiturienClass> listAbitur { get; set; }
    }
}
