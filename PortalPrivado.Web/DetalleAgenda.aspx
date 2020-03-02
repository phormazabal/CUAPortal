<%@ Page Title="" Language="C#" MasterPageFile="~/PortalM.Master" AutoEventWireup="true" CodeBehind="DetalleAgenda.aspx.cs" Inherits="PortalPrivado.Web.DetalleAgenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <script type="text/javascript">
        function ActivarPostClickAceptar() {
            div = document.getElementById('divdesv');
            div.style.display = 'none';
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <link href='css/fullcalendar.min.css' rel='stylesheet' />
            <div class="box-perfil" id="form-perfil">
                <div class="col-lg-12">
                    <asp:LinkButton ID="LinkButton1" CssClass="volver" runat="server" OnClick="LinkButton1_Click"><img src="images/flecha-izq-verde.svg" alt="">Volver</asp:LinkButton>
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
                                        <asp:LinkButton ID="lkVerPerfil" CssClass="btn btn-verde" runat="server" OnClick="lkVerPerfil_Click">VER PERFIL</asp:LinkButton>
                                        <%--<a href="#" class="">VER PERFIL</a>--%>
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
                                    <p>
                                        <asp:Label ID="lbEspecialidad" runat="server" Text=""></asp:Label>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="box-res">
                            <table>
                                <thead>
                                </thead>
                                <caption>
                                    <h3>
                                        <asp:Label ID="lbFecha" runat="server" Text="Label"></asp:Label>
                                    </h3>
                                    <tr>
                                        <th>Hora Médica</th>
                                        <th>Disponibilidad</th>
                                        <th></th>
                                    </tr>
                                    </thead>
                                <tbody>
                                    <asp:Repeater ID="dlDisHora" runat="server" OnItemCommand="dlDisHora_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbHora" runat="server" Text='<% # Eval("Hora") %>'></asp:Label>
                                                    <asp:HiddenField ID="hdUt" runat="server" Value='<% # Eval("Utratamiento") %>' />
                                                </td>
                                                <%# Eval("Estado").Equals("Reservar")  ?
                                                "<td><i class='far fa-check-circle'></i></td>" : 
                                                 Eval("Estado").Equals("No Disponible") ? "<td><i class='fas fa-ban gris'></i></td>" : "<td><i class='fas fa-ban gris'></i></td>"%>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName='<%# Eval("Estado").Equals("Reservar")  ? "R" : "" %>'
                                                            CssClass='<%# Eval("Estado").Equals("Reservar")  ? "btn btn-amarillo" :  
                                                        Eval("Estado").Equals("No Disponible") ? "btn btn-gris" : "btn btn-amarillo-op" %>'><%# Eval("Estado").Equals("Reservar")  ? "<label>SELECCIONAR</label>" :  
                                                        Eval("Estado").Equals("No Disponible") ? "NO DISPONIBLE" : "RESERVADO" %></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                                </caption>
                            </table>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="box-res">
                            <h3>Selección reserva de hora</h3>
                            <div class="cont-res">
                                 <asp:Calendar ID="calendar" runat="server" CssClass="calendario" FirstDayOfWeek="Monday" 
                                                        OnDayRender="calendar_DayRender" SelectionMode="None" OnVisibleMonthChanged="calendar_VisibleMonthChanged" 
                                                        OnSelectionChanged="calendar_SelectionChanged" SelectedDayStyle-BackColor="#D3F4B2" SelectorStyle-BackColor="White" 
                                                        ForeColor="#477025" BorderColor="Silver" CellPadding="2" DayHeaderStyle-ForeColor="Black" DayNameFormat="FirstLetter" ></asp:Calendar>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Label ID="lbPartic" runat="server" Text=""></asp:Label>         
           
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="lkVerPerfil" />
            <asp:PostBackTrigger ControlID="LinkButton1" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Panel ID="pnModal" runat="server" Visible="false">
        <div id="divParti">
            <div class="popup visible">
                <div class="w-pop">
                    <div class="cerrar-pop"><i class="fas fa-times"></i></div>
                    <h3>Particularidad de la Cita</h3>
                    <p>
                        <span>
                            <asp:Label ID="lbParti" runat="server" Text="Label"></asp:Label></span>
                    </p>
                    <div class="botones">
                        <asp:LinkButton ID="LinkButton3" CssClass="btn btn-borde-gris" runat="server" OnClick="LinkButton3_Click">Cancelar</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton4" CssClass="btn btn-amarillo" runat="server" OnClick="LinkButton4_Click">Aceptar</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
