using Cielo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo
{
    public interface ICieloApi
    {
        Transaction CreateTransaction(Guid requestId, Transaction transaction);
    }
}
