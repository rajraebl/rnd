using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.ServiceModel;
using System.Text;
using System.Web.Services.Description;

namespace SecureService
{
    [MessageContract]
    public class AccountCredential
    {
        [MessageHeader(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        public string SecretKey { get; set; }

        [MessageBodyMember(ProtectionLevel = ProtectionLevel.Sign)]
        public string CustId { get; set; }
    }
}
