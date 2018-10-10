using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Model
{
    public class Esnecil
    {
        public int Id { get; set; }
        public string ValidationKey { get; set; }
        public string MachineCode { get; set; }
        public string EsnecilCode { get; set; }
        public string SerialCode { get; set; }
        public DateTime? ActivationDate { get; set; }
        public bool IsEvaluation { get; set; }

    }



}
