﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WishListConsoleClient.WishListServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WishListServiceReference.IWish")]
    public interface IWish {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWish/SayYourWish")]
        void SayYourWish(string wisherName, string yourWish);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWish/SayYourWish")]
        System.Threading.Tasks.Task SayYourWishAsync(string wisherName, string yourWish);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWishChannel : WishListConsoleClient.WishListServiceReference.IWish, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WishClient : System.ServiceModel.ClientBase<WishListConsoleClient.WishListServiceReference.IWish>, WishListConsoleClient.WishListServiceReference.IWish {
        
        public WishClient() {
        }
        
        public WishClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WishClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WishClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WishClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void SayYourWish(string wisherName, string yourWish) {
            base.Channel.SayYourWish(wisherName, yourWish);
        }
        
        public System.Threading.Tasks.Task SayYourWishAsync(string wisherName, string yourWish) {
            return base.Channel.SayYourWishAsync(wisherName, yourWish);
        }
    }
}
