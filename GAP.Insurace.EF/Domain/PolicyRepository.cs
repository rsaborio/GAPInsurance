using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Insurace.EF
{
    class PolicyRepository : Repository<Policy>, IPolicyRepository
    {
        private readonly InsuranceContext _context;
        public PolicyRepository(InsuranceContext context) : base(context)
        {
            _context = context;
        }
       
    }
}
