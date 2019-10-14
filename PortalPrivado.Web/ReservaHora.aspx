<%@ Page Title="" Language="C#" MasterPageFile="~/PortalM.Master" AutoEventWireup="true" CodeBehind="ReservaHora.aspx.cs" Inherits="PortalPrivado.Web.ReservaHora" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <head>
    </head>
    <script>
        function IAmSelected(source, eventArgs) {
            alert(eventArgs.get_value()); 
            document.getElementById("contentPlaceHolder_hdRut").value = eventArgs.get_value();
           
        }
    </script>
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
   
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
          <div class="w-form">
          
            
             <asp:DropDownList ID="dpBusqueda" CssClass="chosen-select" runat="server"></asp:DropDownList>
              <asp:Button ID="btnAceptar" CssClass="btn btn-amarillo" runat="server" Text="Buscar" OnClick="btnAceptar_Click" />  
            
          </div>
        </div>
</asp:Content>
