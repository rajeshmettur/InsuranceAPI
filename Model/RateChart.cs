using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceAPI.Model
{
    public class RateChart
    {
        [Key]
        public int Id { get; set; }

        public int CoveragePlanId { get; set; }
        
        [ForeignKey("CoveragePlanId")]
        public CoveragePlan CoveragePlan { get; set; }
        public string Gender { get; set; }

        public int Age { get; set; }

        public double NetPrice { get; set; }

    }
}
