using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLAB_3
{
    internal class Clinic
    {
        public enum Medicine
        {
            Theoretical,
            Practical,
            EvidenceBased
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime FoundingDate { get; set; }

        public Clinic(string name, string type, DateTime foundingDate)
        {
            Name = name;
            Type = type;
            FoundingDate = foundingDate;
        }

        public Clinic() 
        {
            Name = "Regional Clinic";
            Type = Medicine.Theoretical.ToString();
            FoundingDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Type: {Type}, Founding Date: {FoundingDate.ToShortDateString()}";
        }
    }
}
