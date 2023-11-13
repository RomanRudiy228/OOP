using OOPLAB_3;
using static OOPLAB_3.Doctor;

    Doctor doctor = new Doctor(new Person("Dr. Smith", 40), Education.PhD, 12345);
    Console.WriteLine("Doctor Information (Short):");
    Console.WriteLine(doctor.ToShortString());

    Console.WriteLine("\nIndexer Values:");
    Console.WriteLine($"Bachelor: {doctor[Education.Bachelor]}");
    Console.WriteLine($"Master: {doctor[Education.Master]}");
    Console.WriteLine($"PhD: {doctor[Education.PhD]}");

    Console.WriteLine("\nSetting Values:");
    doctor.DoctorData = new Person("Dr. Brown", 35);
    doctor.edu = Education.Master;
    doctor.DiplomaNumber = 54321;
    Console.WriteLine(doctor.ToString());

    Clinic clinic1 = new Clinic("Clinic A", "Practical", new DateTime(2000, 01, 01));
    Clinic clinic2 = new Clinic("Clinic B", "Theoretical", new DateTime(2010, 05, 15));
    doctor.AddClinics(clinic1, clinic2);

    Console.WriteLine("\nAfter Adding Clinics:");
    Console.WriteLine(doctor.ToString());

    Clinic[] clinics = new Clinic[1000000];
    Clinic[][] rectangularArray = new Clinic[1000][];
    for (int i = 0; i < rectangularArray.Length; i++)
    {
        rectangularArray[i] = new Clinic[1000];
    }
    Clinic[][][] jaggedArray = new Clinic[1000][][];
    for (int i = 0; i < jaggedArray.Length; i++)
    {
        jaggedArray[i] = new Clinic[1000][];
        for (int j = 0; j < jaggedArray[i].Length; j++)
        {
            jaggedArray[i][j] = new Clinic[100];
        }
    }

    var watch = System.Diagnostics.Stopwatch.StartNew();
    var lastElement = clinics[clinics.Length - 1];
    watch.Stop();
    Console.WriteLine($"\nTime to access last element in one-dimensional array: {watch.ElapsedMilliseconds}ms");

    watch = System.Diagnostics.Stopwatch.StartNew();
    lastElement = rectangularArray[999][999];
    watch.Stop();
    Console.WriteLine($"Time to access last element in rectangular array: {watch.ElapsedMilliseconds}ms");

    watch = System.Diagnostics.Stopwatch.StartNew();
    lastElement = jaggedArray[99][99][99];
    watch.Stop();
    Console.WriteLine($"Time to access last element in jagged array: {watch.ElapsedMilliseconds}ms");