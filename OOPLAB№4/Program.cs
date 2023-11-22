using OOPLAB_4;
using System.Collections;
using static OOPLAB_4._;
using static OOPLAB_4.Doctor;
using Person = OOPLAB_4._.Person;

try
        {
            Person person1 = new Person("John", 25);
            Person person2 = new Person("John", 25);

            Console.WriteLine($"Are persons equal? {person1.Equals(person2)}");
            Console.WriteLine($"Hash code of person1: {person1.GetHashCode()}");
            Console.WriteLine($"Hash code of person2: {person2.GetHashCode()}");

            Employees employees = new Employees(person1, Doctor.Education.PhD, 30);
            employees.AddChairs(new Chair("Chair A"), new Chair("Chair B"));
            employees.Sections.Add(new Section("Section X", true));
            employees.Sections.Add(new Section("Section Y", false));

            Console.WriteLine("\nEmployee Information:");
            Console.WriteLine(employees.ToString());

            Console.WriteLine("\nPerson Information (from Employee):");
            Console.WriteLine(employees.PersonData.ToString());

            Console.WriteLine("\nDeep Copy and Modification:");
            Employees copy = (Employees)employees.DeepCopy();
            copy.PersonData.Name = "Jane";
            copy.Sections.Add(new Section("Section Z", true));
            copy.Chairs.Add(new Chair("Chair C"));
            Console.WriteLine("Original Employee:");
            Console.WriteLine(employees.ToString());
            Console.WriteLine("Modified Copy:");
            Console.WriteLine(copy.ToString());

            Console.WriteLine("\nInvalid Age Assignment (Exception Handling):");
            try
            {
                employees.Age = 25; // This will throw an exception
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            Console.WriteLine("\nIterating through Sections and Chairs:");
            foreach (var item in employees)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nIterating through Chairs with Age > 35:");
            foreach (Chair chair in employees.GetEnumerator(35))
            {
                Console.WriteLine(chair);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected Exception: {ex.Message}");
        }
    
