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
        Transaction GetTransaction(Guid requestId, Guid paymentId);
        ReturnStatus CancellationTransaction(Guid requestId, Guid paymentId, int? amount = default(int?));
        ReturnStatus CaptureTransaction(Guid requestId, Guid paymentId, int? amount = default(int?), int? serviceTaxAmount = default(int?));
    }
}
