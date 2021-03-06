//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PortalPrivado.DAO.WsMenu {
    using System.Xml.Serialization;
    using System.Diagnostics;
    using System.Web.Services;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "8.2.5.5")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SI_os_GetMenuBinding", Namespace="urn:Clinicauandes.org.ish.GetMenuPortal")]
    public partial class SI_os_GetMenuService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SI_os_GetMenuOperationCompleted;
        
        /// <remarks/>
        public SI_os_GetMenuService() {
            this.Url = "http://dcpiddev.clinicauandes.cl:50000/XISOAPAdapter/MessageServlet?senderParty=&" +
                "senderService=BC_PORTAL_WEB_115&receiverParty=&receiverService=&interface=SI_os_" +
                "GetMenu&interfaceNamespace=urn%3AClinicauandes.org.ish.GetMenuPortal";
        }
        
        public SI_os_GetMenuService(string url) {
            this.Url = url;
        }
        
        /// <remarks/>
        public event SI_os_GetMenuCompletedEventHandler SI_os_GetMenuCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://sap.com/xi/WebService/soap1.1", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlArrayAttribute("MT_r_GetMenu", Namespace="urn:Clinicauandes.org.ish.GetMenuPortal")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute("Menu", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public DT_r_GetMenuMenu[] SI_os_GetMenu([System.Xml.Serialization.XmlElementAttribute(Namespace="urn:Clinicauandes.org.ish.GetMenuPortal")] DT_GetMenu MT_GetMenu) {
            object[] results = this.Invoke("SI_os_GetMenu", new object[] {
                        MT_GetMenu});
            return ((DT_r_GetMenuMenu[])(results[0]));
        }
        
        /// <remarks/>
        public void SI_os_GetMenuAsync(DT_GetMenu MT_GetMenu) {
            this.SI_os_GetMenuAsync(MT_GetMenu, null);
        }
        
        /// <remarks/>
        public void SI_os_GetMenuAsync(DT_GetMenu MT_GetMenu, object userState) {
            if ((this.SI_os_GetMenuOperationCompleted == null)) {
                this.SI_os_GetMenuOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSI_os_GetMenuOperationCompleted);
            }
            this.InvokeAsync("SI_os_GetMenu", new object[] {
                        MT_GetMenu}, this.SI_os_GetMenuOperationCompleted, userState);
        }
        
        private void OnSI_os_GetMenuOperationCompleted(object arg) {
            if ((this.SI_os_GetMenuCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SI_os_GetMenuCompleted(this, new SI_os_GetMenuCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "8.2.5.5")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:Clinicauandes.org.ish.GetMenuPortal")]
    public partial class DT_GetMenu {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Nbp;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "8.2.5.5")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:Clinicauandes.org.ish.GetMenuPortal")]
    public partial class DT_r_GetMenuMenu {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Glosa;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IdMenu;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string URL;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Orden;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SubMenu", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DT_r_GetMenuMenuSubMenu[] SubMenu;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "8.2.5.5")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:Clinicauandes.org.ish.GetMenuPortal")]
    public partial class DT_r_GetMenuMenuSubMenu {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IdSubMenu;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string GlosaSubMenu;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string URL;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Orden;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "8.2.5.5")]
    public delegate void SI_os_GetMenuCompletedEventHandler(object sender, SI_os_GetMenuCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "8.2.5.5")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SI_os_GetMenuCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SI_os_GetMenuCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public DT_r_GetMenuMenu[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((DT_r_GetMenuMenu[])(this.results[0]));
            }
        }
    }
}
