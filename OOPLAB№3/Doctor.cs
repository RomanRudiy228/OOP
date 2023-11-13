using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static OOPLAB_3.Doctor;

namespace OOPLAB_3
{
    internal class Doctor
    {
        public enum Education
        {
            Bachelor,
            Master,
            PhD
        }

        private Person doctorData;
        private Education _education;
        private int diplomaNumber;
        private Clinic[] clinics;

        public Doctor(Person doctorData, Education education, int diplomaNumber)
        {
            this.doctorData = doctorData;
            this._education = education;
            this.diplomaNumber = diplomaNumber;
            this.clinics = new Clinic[0];
        }

        public Doctor()
        {
            this.doctorData = new Person();
            this._education = Education.PhD;
            this.diplomaNumber = 1;
            this.clinics = new Clinic[1];
        }

        public Person DoctorData
        {
            get { return doctorData; }
            set { doctorData = value; }
        }

        public Education edu
        {
            get { return _education; }
            set { _education = value; }
        }

        public int DiplomaNumber
        {
            get { return diplomaNumber; }
            set { diplomaNumber = value; }
        }

        public Clinic[] Clinics
        {
            get { return clinics; }
        }

        public double AverageClinics
        {
            get { return clinics.Length > 0 ? (double)clinics.Length / clinics.Length : 0; }
        }

        public bool this[Education eduс]
        {
            get { return edu == eduс; }
        }

        public void AddClinics(params Clinic[] newClinics)
        {
            clinics = clinics.Concat(newClinics).ToArray();
        }

        public override string ToString()
        {
            return $"Doctor Data: {DoctorData.Name}, Age: {DoctorData.Age}, Education: {_education}, Diploma: {diplomaNumber}, Clinics: {string.Join(", ", Clinics.Select(c => c.ToString()))}";
        }

        public virtual string ToShortString()
        {
            return $"Doctor Data: {DoctorData.Name}, Age: {DoctorData.Age}, Education: {_education}, Diploma Number: {DiplomaNumber}, Average Clinics: {AverageClinics}";
        }
    }
}
