using InsuranceAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using InsuranceAPI.Helper;

namespace InsuranceAPI.Dto
{
    public class ContractDto : Profile
    {
        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerGender { get; set; }

        public string CustomerCountry { get; set; }

        public int Age { get; set; }

        public DateTime SaleDate { get; set; }

        public int CoveragePlanId { get; set; }

        [ForeignKey("CoveragePlanId")]
        public string CoveragePlan { get; set; }

        public double NetPrice { get; set; }

        public ContractDto()
        {
            //CreateMap<Contract, ContractDto>()
            //    .ForMember(dest => dest.CoveragePlan, opt => opt.MapFrom(src => src.CoveragePlan.))
            //    .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.CustomerDateOfBirth.CalculateAge()));
        }
    }


}
