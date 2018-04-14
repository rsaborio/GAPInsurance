namespace GAP.Insurace.EF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GAP.Insurace.EF.InsuranceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GAP.Insurace.EF.InsuranceContext context)
        {
            Client c1 = new Client() { firstName = "Ronald", lastName = "Saborio" };
            context.Client.AddOrUpdate(x => x.id,
            c1,
            new Client() { firstName = "Ozoora", lastName = "Tsubasa" },
            new Client() { firstName = "Ana", lastName = "Hernandez" }
            );

            Policy p1 = new Policy() { name = " Poliza # 1", coverageType = CoverageTypeEnum.Terremoto, description = "Poliza # 1", fee = 50, initDate = DateTime.Now, monthsCoverage = 5, porcentage = 50, riskType = RiskType.bajo };
            Policy p2 = new Policy() { name = " Poliza # 2", coverageType = CoverageTypeEnum.Terremoto, description = "Poliza # 1", fee = 50, initDate = DateTime.Now, monthsCoverage = 5, porcentage = 50, riskType = RiskType.bajo };
           context.Policy.AddOrUpdate(x => x.id,
           p1,
           p2
           );
           context.ClientPolicy.AddOrUpdate(x => x.id,
                new ClientPolicy() { client= c1 , policy= p1 },
                new ClientPolicy() { client = c1, policy = p2 },
                new ClientPolicy() { client = c1, policy = p1 },
                new ClientPolicy() { client = c1, policy = p2 },
                new ClientPolicy() { client = c1, policy = p1 },
                new ClientPolicy() { client = c1, policy = p2 }
           );

        }
    }
}
