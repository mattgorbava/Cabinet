using Cabinet.Model.Entities;
using System.Collections.ObjectModel;

namespace Cabinet.Model.BLL
{
    internal class MedicBLL
    {
        private readonly MedicDAL medicDAL;

        public MedicBLL()
        {
            medicDAL = new MedicDAL();
        }

        public ObservableCollection<Medic> GetMedics()
        {
            return medicDAL.GetMedics();
        }

        public void AddMedic(Medic medic)
        {
            medicDAL.AddMedic(medic);
        }

        public void EditMedic(Medic medic)
        {
            medicDAL.EditMedic(medic);
        }
    }
}
