using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceAPI.Model
{
    public class CoveragePlan
    {
        [Key]
        public int Id { get; set; }
        public string PlanName { get; set; }
        public string Country { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public ICollection<RateChart> RateCharts { get; set; }

    }
}
