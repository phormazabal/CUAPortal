<%@ Page Title="" Language="C#" MasterPageFile="~/PortalM.Master" AutoEventWireup="true" CodeBehind="DetalleAgenda.aspx.cs" Inherits="PortalPrivado.Web.DetalleAgenda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">
     
      <div class="pasos-reserva">
          <div class="paso listo">
            <div class="num-paso">
              <span>1</span>
            </div>
            <p>Búsqueda</p>
          </div>
          <div class="paso listo">
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
        <div class="texto-res">
          <p>Listado ordenado de acuerdo a las horas disponibles más próximas</p>
        </div>

        <div class="row row-small">
          <div class="col-lg-6 mb-20">
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
                    <a href="#" class="btn btn-verde">VER PERFIL</a>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="col-lg-6 mb-20">
            <div class="box-res">
              <h3>Especialidad</h3>
              <div class="cont-res">
                <div class="item-agenda">
                  <p>Traumatología y Ortopedia - Rodilla - Medicina Deportiva</p>
                </div>
              </div>
            </div>
          </div>
          <div class="col-lg-6">
            <div class="box-res">
              <table>
                <thead>
                  <tr>
                    <th>Hora Médica</th>
                    <th>Disponibilidad</th>
                    <th></th>
                  </tr>
                </thead>
                <tbody>
                    <%--<asp:DataList ID="dlDisHora" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lbHora" runat="server" Text='<% # Eval("Hora") %>'>></asp:Label>
                                </td>
                                 <td><i class="far fa-check-circle"></i></td>
                                <td><a href="#" class="btn btn-amarillo">RESERVA</a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:DataList>--%>
                    <asp:Repeater ID="dlDisHora" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lbHora" runat="server" Text='<% # Eval("Hora") %>'>></asp:Label>
                                </td>
                                 <td><i class="far fa-check-circle"></i></td>
                                <td><a href="#" class="btn btn-amarillo">RESERVA</a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                 <%-- <tr>
                    <td>14:00 Hrs</td>
                    <td><i class="far fa-check-circle"></i></td>
                    <td><a href="#" class="btn btn-amarillo">RESERVA</a></td>
                  </tr>
                  <tr>
                    <td>15:00 Hrs</td>
                    <td><i class="far fa-check-circle"></i></td>
                    <td><a href="#" class="btn btn-amarillo">RESERVA</a></td>
                  </tr>
                  <tr>
                    <td>16:00 Hrs</td>
                    <td><i class="far fa-check-circle"></i></td>
                    <td><a href="#" class="btn btn-amarillo">RESERVA</a></td>
                  </tr>
                  <tr>
                    <td>17:00 Hrs</td>
                    <td><i class="far fa-check-circle"></i></td>
                    <td><a href="#" class="btn btn-amarillo">RESERVA</a></td>
                  </tr>
                  <tr>
                    <td>18:00 Hrs</td>
                    <td><i class="far fa-check-circle"></i></td>
                    <td><a href="#" class="btn btn-amarillo">RESERVA</a></td>
                  </tr>--%>
                </tbody>
              </table>
            </div>
          </div>
          <div class="col-lg-6">
            <div class="box-res">
              <h3>Selección reserva de hora</h3>
              <div class="cont-res">
                  <asp:Calendar ID="calendar" runat="server" FirstDayOfWeek="Monday" OnDayRender="calendar_DayRender" SelectionMode="None">
                  </asp:Calendar>
              </div>
            </div>
          </div></div>
      
</asp:Content>
