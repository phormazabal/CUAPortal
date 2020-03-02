<%@ Page Title="" Language="C#" MasterPageFile="~/PortalM.Master" AutoEventWireup="true" CodeBehind="Reserva.aspx.cs" Inherits="PortalPrivado.Web.Reserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="box-perfil" id="form-perfil">
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
            <div class="paso activo">
                <div class="num-paso">
                    <span>4</span>
                </div>
                <p>Reserva</p>
            </div>
        </div>

        <div class="ficha-id">
            <div class="reserva-exito">
                <div class="check">
                    <i class="far fa-check-circle"></i>
                </div>
                <div class="texto">
                    <h4>Su hora médica ha sido reservada exitosamente</h4>
                    <ul>
                        <li><b>Profesional:</b><asp:Label ID="lbMedico" runat="server" Text="Label"></asp:Label></li>
                        <li><b>Fecha:</b><asp:Label ID="lbFecha" runat="server" Text="Label"></asp:Label></li>
                        <li><b>Hora:</b><asp:Label ID="lbHora" runat="server" Text="Label"></asp:Label></li>
                        <li><b>Especialidad:</b><asp:Label ID="lbEspecialidad" runat="server" Text="Label"></asp:Label></li>                        
                    </ul>
                    <br />
                    <h4>Hemos enviado un correo electrónico<br />
                        de confirmación de su reserva</h4>
                </div>
            </div>
          <%--  <div class="text-right">
                <a href="#" class="btn btn-verde">HOME MI CLINICA UANDES</a>
            </div>--%>
        </div>
    </div>
</asp:Content>
