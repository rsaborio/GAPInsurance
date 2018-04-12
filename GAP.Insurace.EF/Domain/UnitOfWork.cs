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
            CoverageType = new CoverageTypeRepository(_context);
            Policy = new PolicyRepository(_context);
        }

        public IClientRepository Client { get; private set; }
        public ICoverageTypeRepository CoverageType { get; private set; }
        public IPolicyRepository Policy { get; private set; }

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
