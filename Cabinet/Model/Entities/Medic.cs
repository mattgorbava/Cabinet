using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet.Model.Entities
{
    internal class Medic
    {
        public int MedicId { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
