using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Insurace.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InsuranceContext _context;
        public UnitOfWork(InsuranceContext context) {
            _context = context;
            Client = new ClientRepository(_context);
            Policy = new PolicyRepository(_context);
            ClientPolicy = new ClientPolicyRepository(_context);

        }

        public IClientRepository Client { get; private set; }
        public IPolicyRepository Policy { get; private set; }

        public IClientPolicyRepository ClientPolicy { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
