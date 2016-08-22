using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duarti.Maverick.Cielo.Configurations
{
    public interface IMerchant
    {
        Guid Id { get; }
        string Key { get; }
    }
}
