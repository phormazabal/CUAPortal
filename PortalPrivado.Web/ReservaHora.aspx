<%@ Page Title="" Language="C#" MasterPageFile="~/PortalM.Master" AutoEventWireup="true" CodeBehind="ReservaHora.aspx.cs" Inherits="PortalPrivado.Web.ReservaHora" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" runat="Server" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <head runat="server">
    </head>
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <div class="box-perfil" id="form-perfil">
        <div class="pasos-reserva">
          <div class="paso activo">
            <div class="num-paso">
              <span>1</span>
            </div>
            <p>Búsqueda</p>
          </div>
          <div class="paso">
            <div class="num-paso">
              <span>2</span>
            </div>
            <p>Profesional</p>
          </div>
          <div class="paso">
            <div class="num-paso">
              <span>3</span>
            </div>
            <p>Hora</p>
          </div>
          <div class="paso">
            <div class="num-paso">
              <span>4</span>
            </div>
            <p>Reserva</p>
          </div>
        </div>
       
        <div class="box-busqueda">
          <label>Ingrese la especialidad o nombre del profesional</label>
          
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>
                      <div class="w-form">
                      <asp:TextBox ID="txtbus" CssClass="texto" runat="server"></asp:TextBox>
                         
                      <ajaxToolkit:AutoCompleteExtender ServiceMethod="getBusqueda" MinimumPrefixLength="1" CompletionInterval="10"
                                            EnableCaching="false" CompletionSetCount="10" TargetControlID="txtbus" ID="AutoCompleteExtender1"
                                            runat="server" FirstRowSelected="false">
                                        </ajaxToolkit:AutoCompleteExtender><button class="btn btn-amarillo">BUSCAR </button></div>
                  </ContentTemplate>

              </asp:UpdatePanel>
            
            

        </div>
      </div>
</asp:Content>
