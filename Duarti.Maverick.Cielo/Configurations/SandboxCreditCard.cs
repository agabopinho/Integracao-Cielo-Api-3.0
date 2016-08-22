using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duarti.Maverick.Cielo.Configurations
{
    public static class SandboxCreditCard
    {
        public const string NotAuthorizedTimeOut = "0000000000000006";
        public const string NotAuthorizedCardExpired = "0000000000000003";
        public const string NotAuthorizedCardBlocked = "0000000000000005";
        public const string NotAuthorizedCardProblems = "0000000000000008";
        public const string NotAuthorizedCardCanceled = "0000000000000007";
        public const string SucessfulOrTimeout = "0000000000000009";
        public const string NotAuthorized = "0000000000000002";
        public const string Authorized1 = "0000000000000001";
        public const string Authorized2 = "0000000000000004";
    }
}
