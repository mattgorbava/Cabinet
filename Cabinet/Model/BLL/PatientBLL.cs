using Cabinet.Model.DAL;
using Cabinet.Model.Entities;
using System.Collections.ObjectModel;

namespace Cabinet.Model.BLL
{
    class PatientBLL
    {
        private readonly PatientDAL patientDAL;

        public PatientBLL()
        {
            patientDAL = new PatientDAL();
        }

        public ObservableCollection<Patient> GetPatients()
        {
            return new ObservableCollection<Patient>(patientDAL.GetPatients());
        }

        public void AddPatient(Patient patient)
        {
            patientDAL.AddPatient(patient);
        }

        public void EditPatient(Patient patient)
        {
            patientDAL.EditPatient(patient);
        }
    }
}
