using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.Insurace.EF;

namespace GAP.Insurace.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork unit = new UnitOfWork(new InsuranceContext());
            try
            {
                var clientReturn = unit.Client.GetAll();
            }
            finally
            {
                unit.Dispose();
            }
        }
    }
}
