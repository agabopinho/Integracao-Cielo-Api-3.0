using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo
{
    public interface IEnvironment
    {
        string TransactionUrl { get; }
        string QueryUrl { get; }
    }
}
