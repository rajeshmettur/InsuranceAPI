using InsuranceAPI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceAPI.Data
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.CoveragePlans.Any())
            {
                var CoveragePlanData = System.IO.File.ReadAllText("Data/CoveragePlanData.json");
                var plans = JsonConvert.DeserializeObject<List<CoveragePlan>>(CoveragePlanData);
                foreach(var plan in plans)
                {
                    context.CoveragePlans.Add(plan);
                }
                context.SaveChanges();
            }
            if (!context.RateCharts.Any())
            {
                var RateChartData = System.IO.File.ReadAllText("Data/RateChartData.json");
                var rates = JsonConvert.DeserializeObject<List<RateChart>>(RateChartData);
                foreach (var rate in rates)
                {
                    context.RateCharts.Add(rate);
                }
                context.SaveChanges();
            }
        }
    }
}
