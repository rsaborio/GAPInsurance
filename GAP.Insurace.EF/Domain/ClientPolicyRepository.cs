using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Insurace.EF
{
    class ClientPolicyRepository : Repository<ClientPolicy>, IClientPolicyRepository
    {
        private readonly InsuranceContext _context;
        public ClientPolicyRepository(InsuranceContext context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<ClientPolicy> GetBy(Expression<Func<ClientPolicy, bool>> expression)
        {
            return _context.Set<ClientPolicy>().Include("Client").Include("Policy").Where(expression);
        }

        //public override void Add(ClientPolicy entity)
        //{
        //    _context.Entry(entity.client).State= EntityState.Modified;
        //    _context.Entry(entity.policy).State = EntityState.Modified;
        //    _context.Set<ClientPolicy>().Add(entity);
        //    _context.SaveChanges();
        //}
    }


}
