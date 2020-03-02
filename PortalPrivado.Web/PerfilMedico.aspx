<%@ Page Title="" Language="C#" MasterPageFile="~/PortalM.Master" AutoEventWireup="true" CodeBehind="PerfilMedico.aspx.cs" Inherits="PortalPrivado.Web.PerfilMedico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div class="box-perfil" id="form-perfil">
    <div class="row">
          <div class="col-lg-12">
              <asp:LinkButton ID="LinkButton1" CssClass="volver"  runat="server" OnClick="LinkButton1_Click"><img src="images/flecha-izq-verde.svg" alt="">Volver</asp:LinkButton>
           
          </div>
          <div class="col-lg-12">
            <div class="b-doctor">
              <div class="titulo-doctor">
                <img src="images/ic-doctor.svg" alt="">
                <h2 class="t-2b">
                    <asp:Label ID="lbNombre" runat="server" Text=""></asp:Label></h2>
              </div>
              <div class="ficha-doctor">
                <div class="row">
                  <div class="col-lg-5">
                    <figure>
                        <asp:Image ID="imgDr" runat="server" />
                     <%-- <img src="images/img-d.jpg" alt="">--%>
                    </figure>
                  </div>
                  <div class="col-lg-7">
                    <div class="texto-ficha">
                      <p><span>Especialidad:</span> <asp:Label ID="lbEspecialidad" runat="server" Text=""></asp:Label></p>
                      <p><span>Sub Especialidad:</span><asp:Label ID="lbSubEsp" runat="server" Text=""></asp:Label></p>
                      <p><span>Área de interés:</span> <asp:Label ID="lbAreaInteres" runat="server" Text=""></asp:Label> </p>
                      <p><span>Idiomas en que atiende:</span><asp:Label ID="lbIdiomas" runat="server" Text=""></asp:Label></p>
                      <p><span>Actividad docente:</span><asp:Label ID="lbActividadDoc" runat="server" Text=""></asp:Label></p>
                      <p><span>Área de investigación:</span><asp:Label ID="lbArea" runat="server" Text=""></asp:Label></p>
                      <p><span>Ubicación de consulta:</span><asp:Label ID="lbUbicacion" runat="server" Text=""></asp:Label></p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="reserva-hora">
              <p>Próxima hora disponible: <span>El  <asp:Label ID="lbFecha" runat="server" Text="Label"></asp:Label> - <asp:Label ID="lbHora" runat="server" Text="Label"></asp:Label> Hrs</span></p>              
                <asp:LinkButton ID="lkReservar" CssClass="btn btn-amarillo" runat="server" OnClick="lkReservar_Click">RESERVAR</asp:LinkButton>
            </div>

            <div class="titulo-doctor">
              <img src="images/ic-doc.svg" class="ic-doc" alt="">
              <h2 class="t-2b">Descripción</h2>
            </div>
            <div class="des-doc">
              <p><asp:Label ID="lbDetalle" runat="server" Text=""></asp:Label></p>
            </div>
          </div>
        </div></div>
    
</asp:Content>
