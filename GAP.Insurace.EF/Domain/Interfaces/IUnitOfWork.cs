using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Insurace.EF
{
    public interface IUnitOfWork
    {
        IClientRepository Client { get; }
        IPolicyRepository Policy { get; }
        IClientPolicyRepository ClientPolicy { get; }

        int Complete();
    }
}
