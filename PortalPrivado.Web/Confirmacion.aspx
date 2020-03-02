<%@ Page Title="" Language="C#" MasterPageFile="~/PortalM.Master" AutoEventWireup="true" CodeBehind="Confirmacion.aspx.cs" Inherits="PortalPrivado.Web.Confirmacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="box-perfil" id="form-perfil">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
       <%--  <ajaxToolkit:ModalPopupExtender runat="server" PopupControlID="divdesv" TargetControlID="Label1" ID="LinkButton3_ModalPopupExtender"></ajaxToolkit:ModalPopupExtender>--%>
       
        <div class="col-lg-12">
             <asp:LinkButton ID="LinkButton1" CssClass="volver"  runat="server" OnClick="LinkButton1_Click"><img src="images/flecha-izq-verde.svg" alt="">Volver</asp:LinkButton>
        </div>
        <div class="pasos-reserva">
          <div class="paso activo">
            <div class="num-paso">
              <span>1</span>
            </div>
            <p>Búsqueda</p>
          </div>
          <div class="paso activo">
            <div class="num-paso">
              <span>2</span>
            </div>
            <p>Profesional</p>
          </div>
          <div class="paso activo">
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

        <div class="ficha-id">
          <div class="f-id">
            <h3>Para confirmar su hora médica, favor seleccionar botón reservar</h3>
            <ul>
              <li><b>Profesional:</b> <asp:Label ID="lbNombreMed" runat="server" Text=""></asp:Label></li>
              <li><b>Fecha:</b> <asp:Label ID="lbFecha" runat="server" Text=""></asp:Label></li>
              <li><b>Hora:</b> <asp:Label ID="lbHora" runat="server" Text=""></asp:Label></li>
              <li><b>Especialidad:</b> <asp:Label ID="lbEspecialidad" runat="server" Text=""></asp:Label></li>
              <li><b>Paciente:</b> <asp:Label ID="lbPaciente" runat="server" Text=""></asp:Label></li>
            </ul>
          </div>
          <div class="panel-editar visible c-m">            
              <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Cancelar</asp:LinkButton>&nbsp;
              <asp:LinkButton ID="btnReservar" CssClass="btn btn-amarillo" runat="server" OnClick="btnReservar_Click">RESERVAR</asp:LinkButton>
          </div>
        </div>
      </div>
     <asp:Panel ID="pnModal" runat="server" Visible="false">
    <div id="divdesv">
        <div class="popup visible">
            <div class="w-pop">                
                <h3>Confirmación de cita</h3>
                <p><span>La cita fue agendada por otro paciente</span></p>
                <div class="botones">
                    <asp:LinkButton ID="LinkButton5" CssClass="btn btn-amarillo" runat="server" OnClick="LinkButton5_Click">ACEPTAR</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    </asp:Panel>
     
</asp:Content>
