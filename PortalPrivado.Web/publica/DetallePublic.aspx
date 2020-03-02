<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetallePublic.aspx.cs" Inherits="PortalPrivado.Web.publica.DetallePublic" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Clínica UA</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css"
        integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous"
        async />
    <link rel="stylesheet" href="../css/fonts.css" type="text/css" />
    <link rel="stylesheet" href="../css/bootstrap-grid.min.css" type="text/css" />
    <%--<link href='../css/fullcalendar.min.css' rel='stylesheet' />--%>
    <link rel="stylesheet" href="../css/tiny-slider.css" type="text/css" />
    <link rel="stylesheet" href="../css/animate.css" type="text/css" />
    <link rel="stylesheet" href="../css/normalize.css" type="text/css" />
    <link rel="stylesheet" href="../css/estilos.css" type="text/css" />
    <link href='../css/fullcalendar.min.css' rel='stylesheet' />
    <script type="text/javascript">
        function ActivarPostClickAceptar() {
            div = document.getElementById('divdesv');
            div.style.display = 'none';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <%--<asp:Label ID="Label1" runat="server" Text=""></asp:Label>--%>
        <%--<ajaxToolkit:ModalPopupExtender runat="server" PopupControlID="divdesv" TargetControlID="Label1" ID="LinkButton3_ModalPopupExtender"></ajaxToolkit:ModalPopupExtender>--%>
        <section class="p-2 home-priv">
            <div class="wrap">
                <div class="row">
                    <div class="col-lg-9">
                        <div class="box-perfil w-busqueda">
                            <asp:LinkButton ID="LinkButton1" CssClass="volver" runat="server" OnClick="LinkButton1_Click"><img src="../images/flecha-izq-verde.svg" alt=""/>Volver</asp:LinkButton>

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
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
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
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="R" CssClass='<%# Eval("Estado").Equals("Reservar")  ? "btn btn-amarillo" :  
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
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="lkVerPerfil" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
            <div id="divdesv">
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
        </section>
    </form>
    <script type="text/javascript" src="../js/iframeResizer.contentWindow.min.js" defer></script>   
</body>

</html>

