using System;
using System.Linq;
using BAI_1_3_EFCORE_DBFIRST.Context;
using BAI_1_3_EFCORE_DBFIRST.DomainClass;

namespace BAI_1_3_EFCORE_DBFIRST
{
    internal class Program
    {
        //Scaffold-DbContext 'Data Source=DUNGNAPC\SQLEXPRESS;Initial Catalog=FINALASS_FPOLYSHOP_SM22_BL2_DUNGNA29;Persist Security Info=True;User ID=dungna34;Password=123456' Microsoft.EntityFrameworkCore.SqlServer -OutputDir DomainClass -context FpolyDBContext -Contextdir Context -DataAnnotations -Force
        private static void Main(string[] args)
        {
            FpolyDBContext dbContext = new FpolyDBContext();

            Nsx nsx = new Nsx() { Id = Guid.Empty, Ma = "IP1", Ten = "Apple1" };
            dbContext.Nsxes.Add(nsx);
            dbContext.SaveChanges();

            foreach (var x in dbContext.Nsxes.ToList().Where(c => c.Ma.StartsWith("1")))
            {
                Console.WriteLine($"{x.Id} {x.Ma} {x.Ten} ");
            }
        }
    }
}