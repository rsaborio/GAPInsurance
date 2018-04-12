using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Insurace.EF
{
    class PolicyRepository : Repository<Policy>, IPolicyRepository
    {
        public PolicyRepository(InsuranceContext context) : base(context)
        {
        }
    }
}
