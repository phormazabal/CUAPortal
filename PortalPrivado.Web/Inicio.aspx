<%@ Page Title="" Language="C#" MasterPageFile="~/PortalM.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="PortalPrivado.Web.Formulario_web11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="box-perfil">
        <div class="row row-small">
          <div class="col-lg-6">
            <div class="form-group">
              <label>Nombre</label>
                <asp:Label ID="lbNombre" runat="server" Text=""></asp:Label>             
            </div>
            <div class="form-group">
              <label>Rut / Pasaporte</label>
              <asp:Label ID="lbRut" runat="server" Text=""></asp:Label> 
            </div>
            <div class="form-group">
              <label>Fecha de nacimiento</label>
              <asp:Label ID="lbFechaNac" runat="server" Text=""></asp:Label> 
            </div>
            <div class="form-group">
              <label>E-mail <span class="editar-f"></span></label>
              <asp:Label ID="lbEmail" runat="server" Text=""></asp:Label> 
            </div>
          </div>
          <div class="col-lg-6">
            <div class="form-group">
              <label>Dirección <span class="editar-f"></span></label>
              <asp:Label ID="lbDireccion" runat="server" Text=""></asp:Label> 
            </div>
            <div class="form-group">
              <label>Contraseña <span class="editar-f"><%--<i class="far fa-edit"></i>--%></span></label>
                <asp:Label ID="lbpass" runat="server" Text="******"></asp:Label> 
               <%-- <asp:TextBox ID="TextBox1" CssClass="editable" runat="server"></asp:TextBox>--%>
             <%-- <input type="password" value="******" class="editable" readonly>--%>
            </div>
            <div class="form-group">
              <label>Teléfono 1 <span class="editar-f"></span></label>
              <asp:Label ID="lbTelefono1" runat="server" Text=""></asp:Label> 
            </div>
            <div class="form-group">
              <label>Teléfono 2 <span class="editar-f"></span></label>
               <asp:Label ID="lbTelefono2" runat="server" Text=""></asp:Label> 
            </div>
          </div>
        </div>
        <div class="panel-editar">
          <a href="#" id="cancelar-editar">Cancelar</a>
          <button class="btn btn-amarillo" id="guardar-editar">GUARDAR</button>
        </div>
        <div class="cuadro-mensaje">
          <p>"Si presenta algún problema para modificar los datos <br><b>favor llamar al siguiente número (56) 22 618 3660"</b></p>
        </div>
        </div>
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                <ajaxToolkit:ModalPopupExtender runat="server" PopupControlID="divdesvSes" TargetControlID="Label2" ID="ModalPopupExtender1"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnModalSes" runat="server" Visible="false">
        <div id="divdesvSes">
            <div class="popup visible">
                <div class="w-pop">
                    <h3>Sesión Portal Clínica Universidad de los Andes</h3>
                    <p><span>Su sesión ha caducado, favor ingresar sus credenciales nuevamente</span></p>
                    <div class="botones">
                        <asp:LinkButton ID="LinkButton5" CssClass="btn btn-amarillo" runat="server" OnClick="LinkButton5_Click">ACEPTAR</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
