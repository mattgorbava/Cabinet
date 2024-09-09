namespace Cabinet.Model.Entities
{
    internal class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public Medic Medic { get; set; }
        public int MedicId { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public bool IsActive { get; set; }
    }
}
