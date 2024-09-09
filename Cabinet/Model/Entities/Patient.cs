namespace Cabinet.Model.Entities
{
    internal class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public Medic Medic { get; set; }
        public int MedicId { get; set; }
        public bool IsActive { get; set; }
    }
}
