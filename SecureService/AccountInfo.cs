using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.ServiceModel;
using System.Text;

namespace SecureService
{
    [MessageContract]
    public class AccountInfo
    {
        [MessageBodyMember(ProtectionLevel = ProtectionLevel.None)]
        public string Name { get; set; }


        [MessageBodyMember(ProtectionLevel = ProtectionLevel.Sign)]
        public string Bank { get; set; }


        [MessageBodyMember(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        public int Balance { get; set; }
    }
}
