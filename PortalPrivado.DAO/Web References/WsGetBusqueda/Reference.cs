﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace PortalPrivado.DAO.WsGetBusqueda {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="Si_os_busquedaBinding", Namespace="urn:Clinicauandes.org.GetBusquedapredic")]
    public partial class Si_os_busquedaService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback Si_os_busquedaOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Si_os_busquedaService() {
            this.Url = global::PortalPrivado.DAO.Properties.Settings.Default.PortalPrivado_DAO_WsGetBusqueda_Si_os_busquedaService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event Si_os_busquedaCompletedEventHandler Si_os_busquedaCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://sap.com/xi/WebService/soap1.1", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlArrayAttribute("MT_r_Busqueda", Namespace="urn:Clinicauandes.org.GetBusquedapredic")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute("Busqueda", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public DT_r_BusquedaBusqueda[] Si_os_busqueda([System.Xml.Serialization.XmlElementAttribute(Namespace="urn:Clinicauandes.org.GetBusquedapredic")] DT_Busqueda MT_Busqueda) {
            object[] results = this.Invoke("Si_os_busqueda", new object[] {
                        MT_Busqueda});
            return ((DT_r_BusquedaBusqueda[])(results[0]));
        }
        
        /// <remarks/>
        public void Si_os_busquedaAsync(DT_Busqueda MT_Busqueda) {
            this.Si_os_busquedaAsync(MT_Busqueda, null);
        }
        
        /// <remarks/>
        public void Si_os_busquedaAsync(DT_Busqueda MT_Busqueda, object userState) {
            if ((this.Si_os_busquedaOperationCompleted == null)) {
                this.Si_os_busquedaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSi_os_busquedaOperationCompleted);
            }
            this.InvokeAsync("Si_os_busqueda", new object[] {
                        MT_Busqueda}, this.Si_os_busquedaOperationCompleted, userState);
        }
        
        private void OnSi_os_busquedaOperationCompleted(object arg) {
            if ((this.Si_os_busquedaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Si_os_busquedaCompleted(this, new Si_os_busquedaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:Clinicauandes.org.GetBusquedapredic")]
    public partial class DT_Busqueda {
        
        private string idBusquedaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IdBusqueda {
            get {
                return this.idBusquedaField;
            }
            set {
                this.idBusquedaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:Clinicauandes.org.GetBusquedapredic")]
    public partial class DT_r_BusquedaBusqueda {
        
        private string idBusquedaField;
        
        private string glosaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IdBusqueda {
            get {
                return this.idBusquedaField;
            }
            set {
                this.idBusquedaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Glosa {
            get {
                return this.glosaField;
            }
            set {
                this.glosaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void Si_os_busquedaCompletedEventHandler(object sender, Si_os_busquedaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Si_os_busquedaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Si_os_busquedaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public DT_r_BusquedaBusqueda[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((DT_r_BusquedaBusqueda[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591