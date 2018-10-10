using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogicNP.CryptoLicensing;

namespace Pokno.Infrastructure.Models
{
    public class EsnecilStatus
    {
        public LicenseStatus State { get; set; }
        public short MaxUsageDays { get; set; }
        public short RemainingUsageDays { get; set; }
        public bool IsEvaluation { get; set; }
        public bool IsConsistent { get; set; }
        public bool IsEvaluationExpired { get; set; }
    }




}
