using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceAPI.Data;
using InsuranceAPI.Helper;
using InsuranceAPI.Model;
using System.Xml.XPath;
using Extensions = InsuranceAPI.Helper.Extensions;
using InsuranceAPI.Dto;

namespace InsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly DataContext _context;
        public ContractsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Contracts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contract>>> GetContracts()
        {
            return await _context.Contracts.ToListAsync();
        }

        // GET: api/Contracts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contract>> GetContract(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);

            if (contract == null)
            {
                return NotFound();
            }

            return contract;
        }

        // PUT: api/Contracts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContract(int id, Contract contract)
        {
            if (id != contract.Id)
            {
                return BadRequest();
            }

            _context.Entry(contract).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Contracts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Contract>> PostContract(string customername, string address, string dateofbirth, string gender, string saledate, string country)
        {
            //try
            //{
                Contract contract = new Contract();
                int Age = Extensions.CalculateAge(Convert.ToDateTime(dateofbirth));

                contract = await _context.RateCharts.Include(x => x.CoveragePlan)
                                    .Where(x =>
                                    (
                                    string.IsNullOrEmpty(gender) || gender.ToLower().StartsWith(x.Gender.ToLower())
                                    && (Age == null || Age == 0 || (Age <= x.Age || Age >= x.Age))
                                    && ((Convert.ToDateTime(saledate) >= x.CoveragePlan.FromDate && (Convert.ToDateTime(saledate) <= x.CoveragePlan.ToDate)))
                                    //&& (string.IsNullOrEmpty(country) || country.ToLower().StartsWith(x.CoveragePlan.Country.ToLower()))
                                    ))
                                    .Select(x => new Contract
                                    {
                                        CoveragePlanId = x.CoveragePlanId,
                                        //CoveragePlan = x.CoveragePlan.PlanName,
                                        CustomerAddress = address,
                                        CustomerCountry = x.CoveragePlan.Country,
                                        //CustomerDateOfBirth = Convert.ToDateTime(dateofbirth),
                                        CustomerGender = gender,
                                        CustomerName = customername,
                                        SaleDate = Convert.ToDateTime(saledate),
                                        NetPrice = x.NetPrice
                                    })
                                    .SingleOrDefaultAsync();

                _context.Contracts.Add(contract);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetContract", new { id = contract.Id }, contract);
            //}
            //catch(Exception ex)
            //{
            //    throw ex.Message.ToString();
            //}
        }

        // DELETE: api/Contracts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contract>> DeleteContract(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }

            _context.Contracts.Remove(contract);
            await _context.SaveChangesAsync();

            return contract;
        }

        private bool ContractExists(int id)
        {
            return _context.Contracts.Any(e => e.Id == id);
        }
    }
}
