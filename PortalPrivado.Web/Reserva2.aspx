<%@ Page Title="" Language="C#" MasterPageFile="~/PortalM.Master" AutoEventWireup="true" CodeBehind="Reserva2.aspx.cs" Inherits="PortalPrivado.Web.Reserva2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">

        <div class="pasos-reserva">
          <div class="paso listo">
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
        <div class="texto-res">
          <p>Listado ordenado de acuerdo a las horas disponibles más próximas</p>
        </div>

        <div class="row row-small">
          <div class="col-lg-6">
            <div class="box-res">
              <h3>Profesional</h3>
              <div class="cont-res">
                <div class="item">
                  <figure>
                      <asp:Image ID="ImgDr" runat="server" />
                  </figure>
                  <div class="texto">
                    <h4>
                        <asp:Label ID="lbNombre" runat="server" Text="Label"></asp:Label></h4>
                      <asp:LinkButton ID="lkVerPerfil" CssClass="btn btn-verde" runat="server" OnClick="lkVerPerfil_Click">VER PERFIL</asp:LinkButton>
                    <%--<a href="#" class="btn btn-verde"></a>--%>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="col-lg-6">
            <div class="box-res">
              <h3>Especialidad</h3>
              <div class="cont-res s-p">
                  <asp:Repeater ID="rpEspecialidades" runat="server">
                      <ItemTemplate>
                          <div class="item-agenda">
                  <p>
                      <asp:Label ID="lbEspecialidad" runat="server" Text='<%# Eval("Especialidad") %>'></asp:Label></p>
                      <%--<asp:HyperLink ID="hpVerAgenda" CssClass="btn btn-amarillo" runat="server">VER AGENDA</asp:HyperLink>--%>
                        <asp:LinkButton ID="hpVerAgenda" CssClass="btn btn-amarillo"  runat="server" OnClick="hpVerAgenda">VER AGENDA</asp:LinkButton>
                </div>
                      </ItemTemplate>
                  </asp:Repeater>
              </div>
            </div>
          </div>
        </div>

</asp:Content>
