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
            context.Client.AddOrUpdate(x => x.id,
            new Client() { id = 1, firstName = "Ronald", lastName = "Saborio" },
            new Client() { id = 2, firstName = "Ozoora", lastName = "Tsubasa" },
            new Client() { id = 3, firstName = "Ana", lastName = "Hernandez" }
            );

           context.CoverageType.AddOrUpdate(x => x.id,
           new CoverageType() { id = 1, name = "Terremoto", description = "Terremoto" },
           new CoverageType() { id = 2, name = "incendio", description = "incendio" },
           new CoverageType() { id = 3, name = "Robo", description = "Robo" }
           );

        }
    }
}
