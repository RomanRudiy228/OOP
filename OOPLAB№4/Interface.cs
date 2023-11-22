using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPLAB_4.Doctor;

namespace OOPLAB_4
{
    internal interface _
    {
        interface IDateAndCopy
        {
            object DeepCopy();
            DateTime Date { get; set; }
        }

        class Person : IDateAndCopy
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public DateTime Date { get; set; }

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
                Date = DateTime.Now;
            }

            public Person()
            {
                Name = "Yarik Pchel";
                Age = 30;
                Date = DateTime.Now;
            }

            public virtual bool Equals(object obj)
            {
                if (obj is Person other)
                {
                    return Name == other.Name && Age == other.Age;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Name, Age);
            }

            public virtual object DeepCopy()
            {
                return new Person(Name, Age);
            }
        }

        class Chair : IDateAndCopy
        {
            public string Name { get; set; }
            public DateTime Date { get; set; }

            public Chair(string name)
            {
                Name = name;
                Date = DateTime.Now;
            }

            public Chair()
            {
                Name = "Default Chair";
                Date = DateTime.Now;
            }

            public object DeepCopy()
            {
                return new Chair(Name);
            }
        }

        class Section : IDateAndCopy
        {
            public string Name { get; set; }
            public bool IsDepartment { get; set; }
            public DateTime Date { get; set; }

            public Section(string name, bool isDepartment)
            {
                Name = name;
                IsDepartment = isDepartment;
                Date = DateTime.Now;
            }

            public Section()
            {
                Name = "Default Section";
                IsDepartment = false;
                Date = DateTime.Now;
            }

            public override string ToString()
            {
                return $"Name: {Name}, IsDepartment: {IsDepartment}, Date: {Date.ToShortDateString()}";
            }

            public object DeepCopy()
            {
                return new Section(Name, IsDepartment);
            }
        }

        class Employees : Person
        {
            private Education education;
            private int age;
            private ArrayList sections;
            private ArrayList chairs;

            public Employees(Person person, Education education, int age) : base(person.Name, person.Age)
            {
                this.education = education;
                this.age = age;
                sections = new ArrayList();
                chairs = new ArrayList();
            }

            public Employees() : base()
            {
                education = Education.PhD;
                age = 1;
                sections = new ArrayList();
                chairs = new ArrayList { new Chair() };
            }

            public Person PersonData
            {
                get { return new Person(Name, Age); }
                set { Name = value.Name; Age = value.Age; }
            }

            public double AverageAge
            {
                get { return chairs.Count > 0 ? (double)age / chairs.Count : 0; }
            }

            public ArrayList Sections
            {
                get { return sections; }
                set { sections = value; }
            }

            public ArrayList Chairs
            {
                get { return chairs; }
                set { chairs = value; }
            }

            public void AddChairs(params Chair[] newChairs)
            {
                chairs.AddRange(newChairs);
            }

            public override string ToString()
            {
                return $"Person Data: {PersonData.Name}, Age: {PersonData.Age}, Education: {education}, Average Age: {AverageAge}, Sections: {string.Join(", ", Sections.ToArray())}, Chairs: {string.Join(", ", Chairs.ToArray())}";
            }
           
            public override object DeepCopy()
            {
                Employees copy = new Employees(PersonData, education, age);
                copy.sections = new ArrayList((ICollection)sections.Cast<Section>().Select(s => s.DeepCopy()));
                copy.chairs = new ArrayList((ICollection)chairs.Cast<Chair>().Select(c => c.DeepCopy()));
                return copy;
            }

            public IEnumerator GetEnumerator()
            {
                return sections.Cast<object>().Concat(chairs.Cast<object>()).GetEnumerator();
            }

            public IEnumerable GetEnumerator(double maxAge)
            {
                return chairs.Cast<Chair>().Where(c => c.Date > DateTime.Now.AddYears((int)-maxAge));
            }
        }

    }
}
