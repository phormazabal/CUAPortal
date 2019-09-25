<%@ Page Title="" Language="C#" MasterPageFile="~/PortalM.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="PortalPrivado.Web.Formulario_web11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">
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
              <label>E-mail <span class="editar-f"><i class="far fa-edit"></i></span></label>
              <asp:Label ID="lbEmail" runat="server" Text=""></asp:Label> 
            </div>
          </div>
          <div class="col-lg-6">
            <div class="form-group">
              <label>Dirección <span class="editar-f"><i class="far fa-edit"></i></span></label>
              <asp:Label ID="lbDireccion" runat="server" Text=""></asp:Label> 
            </div>
            <div class="form-group">
              <label>Contraseña <span class="editar-f"><i class="far fa-edit"></i></span></label>
              <input type="password" value="******" class="editable" readonly>
            </div>
            <div class="form-group">
              <label>Teléfono 1 <span class="editar-f"><i class="far fa-edit"></i></span></label>
              <asp:Label ID="lbTelefono1" runat="server" Text=""></asp:Label> 
            </div>
            <div class="form-group">
              <label>Teléfono 2 <span class="editar-f"><i class="far fa-edit"></i></span></label>
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
</asp:Content>
