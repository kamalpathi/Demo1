﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShowLineVer3.ShowLineServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/ShowLineWcfService")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TicketSeatModel", Namespace="http://schemas.datacontract.org/2004/07/ShowLineWcfService.Model")]
    [System.SerializableAttribute()]
    public partial class TicketSeatModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CUSTIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EventSPIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FullNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SeatesBookedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TicketTypeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CUSTID {
            get {
                return this.CUSTIDField;
            }
            set {
                if ((object.ReferenceEquals(this.CUSTIDField, value) != true)) {
                    this.CUSTIDField = value;
                    this.RaisePropertyChanged("CUSTID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EventSPID {
            get {
                return this.EventSPIDField;
            }
            set {
                if ((object.ReferenceEquals(this.EventSPIDField, value) != true)) {
                    this.EventSPIDField = value;
                    this.RaisePropertyChanged("EventSPID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FullName {
            get {
                return this.FullNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FullNameField, value) != true)) {
                    this.FullNameField = value;
                    this.RaisePropertyChanged("FullName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SeatesBooked {
            get {
                return this.SeatesBookedField;
            }
            set {
                if ((this.SeatesBookedField.Equals(value) != true)) {
                    this.SeatesBookedField = value;
                    this.RaisePropertyChanged("SeatesBooked");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TicketType {
            get {
                return this.TicketTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TicketTypeField, value) != true)) {
                    this.TicketTypeField = value;
                    this.RaisePropertyChanged("TicketType");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ShowLineServiceReference.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        ShowLineVer3.ShowLineServiceReference.CompositeType GetDataUsingDataContract(ShowLineVer3.ShowLineServiceReference.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<ShowLineVer3.ShowLineServiceReference.CompositeType> GetDataUsingDataContractAsync(ShowLineVer3.ShowLineServiceReference.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SetTicketTemporyRegistration", ReplyAction="http://tempuri.org/IService1/SetTicketTemporyRegistrationResponse")]
        string SetTicketTemporyRegistration(ShowLineVer3.ShowLineServiceReference.TicketSeatModel[] ticketseatModel, string userName, string pwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SetTicketTemporyRegistration", ReplyAction="http://tempuri.org/IService1/SetTicketTemporyRegistrationResponse")]
        System.Threading.Tasks.Task<string> SetTicketTemporyRegistrationAsync(ShowLineVer3.ShowLineServiceReference.TicketSeatModel[] ticketseatModel, string userName, string pwd);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : ShowLineVer3.ShowLineServiceReference.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<ShowLineVer3.ShowLineServiceReference.IService1>, ShowLineVer3.ShowLineServiceReference.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public ShowLineVer3.ShowLineServiceReference.CompositeType GetDataUsingDataContract(ShowLineVer3.ShowLineServiceReference.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<ShowLineVer3.ShowLineServiceReference.CompositeType> GetDataUsingDataContractAsync(ShowLineVer3.ShowLineServiceReference.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public string SetTicketTemporyRegistration(ShowLineVer3.ShowLineServiceReference.TicketSeatModel[] ticketseatModel, string userName, string pwd) {
            return base.Channel.SetTicketTemporyRegistration(ticketseatModel, userName, pwd);
        }
        
        public System.Threading.Tasks.Task<string> SetTicketTemporyRegistrationAsync(ShowLineVer3.ShowLineServiceReference.TicketSeatModel[] ticketseatModel, string userName, string pwd) {
            return base.Channel.SetTicketTemporyRegistrationAsync(ticketseatModel, userName, pwd);
        }
    }
}
