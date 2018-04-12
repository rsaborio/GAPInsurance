using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Insurace.EF
{
    public class ClientRepository : Repository<Client> , IClientRepository
    {
        public ClientRepository(InsuranceContext context) : base(context)
        {
        }
    }
}
