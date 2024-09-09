using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet.Model.Entities
{
    internal class Operation
    {
        public int OperationId { get; set; }
        public string OperationType { get; set; }
        public DateTime Date { get; set; }
        public Medic Medic { get; set; }
        public int MedicId { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public Price Price { get; set; }
        public int PriceId { get; set; }
        public bool IsActive { get; set; }
    }
}
