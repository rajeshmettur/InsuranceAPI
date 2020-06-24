using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceAPI.Model
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerGender { get; set; }

        public string CustomerCountry { get; set; }

        public DateTime CustomerDateOfBirth { get; set; }

        public DateTime SaleDate { get; set; }

        public int CoveragePlanId { get; set; }
        
        [ForeignKey("CoveragePlanId")]
        public CoveragePlan CoveragePlan { get; set; }

        public double NetPrice { get; set; }
    }
}
