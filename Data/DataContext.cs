using InsuranceAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<CoveragePlan> CoveragePlans { get; set; }

        public DbSet<RateChart> RateCharts { get; set; }

        public DbSet<Contract> Contracts { get; set; }
    }
}
