using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Insurace.EF
{
    class CoverageTypeRepository : Repository<CoverageType>, ICoverageTypeRepository
    {
        public CoverageTypeRepository(InsuranceContext context) : base(context)
        {
        }
    }
}
