<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmacion.aspx.cs" Inherits="PortalPrivado.Web.publica.Confirmacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Clínica UA</title>

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>
    <meta name="viewport" content="width=device-width,initial-scale=1"/>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css"
        integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous"
        async/>
    <link rel="stylesheet" href="../css/fonts.css" type="text/css"/>
    <link rel="stylesheet" href="../css/bootstrap-grid.min.css" type="text/css"/>
    <link href='../css/fullcalendar.min.css' rel='stylesheet' />
    <link rel="stylesheet" href="../css/tiny-slider.css" type="text/css"/>
    <link rel="stylesheet" href="../css/animate.css" type="text/css"/>
    <link rel="stylesheet" href="../css/normalize.css" type="text/css"/>
    <link rel="stylesheet" href="../css/estilos.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <section class="p-2 home-priv">
            <div class="wrap">
                <div class="row">
                    <div class="col-lg-9">
                        <div class="box-perfil w-busqueda pb-0">
                            <asp:LinkButton ID="LinkButton1" CssClass="volver" runat="server" CausesValidation="false" OnClick="LinkButton1_Click"><img src="../images/flecha-izq-verde.svg" alt=""/>Volver</asp:LinkButton>

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
                            <div class="texto-res">
                                <p>Listado ordenado de acuerdo a las horas disponibles más próximas</p>
                            </div>

                            <div class="row row-small">
                                <div class="col-lg-5 mb-20">
                                    <div class="box-res">
                                        <h3>Profesional</h3>
                                        <div class="cont-res tipo2">
                                            <div class="item">
                                                <figure>
                                                    <asp:Image ID="imgDoc" runat="server" />
                                                </figure>
                                                <div class="texto">
                                                    <h4>
                                                        <asp:Label ID="lbNombre" runat="server" Text="Label"></asp:Label></h4>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-7 mb-20">
                                    <div class="box-res t-hora">
                                        <table class="table-responsive">
                                            <thead>
                                                <tr>
                                                    <th>Especialidad</th>
                                                    <th>Fecha</th>
                                                    <th>Hora</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbEspecialidad" runat="server" Text="Label"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lbFecha" runat="server" Text="Label"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lbHora" runat="server" Text="Label"></asp:Label></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="res-hora">
                                        <div class="row form-confirmacion">
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>Nombre</label>
                                                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                        ErrorMessage="Favor completar el campo" ControlToValidate="txtNombre" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>Teléfono contacto</label>
                                                    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvFono"  runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtTelefono" ErrorMessage="Falta Ingreso de Teléfono"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revFono" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtTelefono" ErrorMessage="Formato de teléfono no valido" ValidationExpression="[0-9]{9}"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>Apellidos</label>
                                                    <asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ErrorMessage="Favor completar el campo" ControlToValidate="txtApellidos" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>E-mail contacto</label>
                                                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Falta Ingreso de Email"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                                                        ErrorMessage="Formato de correo no valido" ForeColor="Red" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>Rut / Pasaporte</label>
                                                    <asp:TextBox ID="txtRut" runat="server"></asp:TextBox>
                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                        ErrorMessage="Favor completar el campo" ControlToValidate="txtRut" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <p class="mnsj">Si usted modifica el e-mail y teléfono de contacto, solo se utilizarán para efectos de esta reserva</p>
                                            </div>
                                            <%-- <div class="col-lg-12">
                    <div class="form-group form-check">
                      <input type="checkbox" id="check1">
                      <label for="check1">Autorizo a Clínica Universidad de los Andes para que me contacte por productos y servicios que ofrezca.</label>
                    </div>
                  </div>--%>
                                            
                                            
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-12 text-right">
                                                <div class="panel-editar">
                                                    <asp:LinkButton ID="lkReservar" CssClass="btn btn-amarillo" runat="server" OnClick="lkReservar_Click">RESERVAR</asp:LinkButton>                                            
                                                </div>
                                            </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </section>
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
    </form>
    <script type="text/javascript" src="../js/iframeResizer.contentWindow.min.js" defer></script> 
    <script src="../js/select2.min.js" defer></script>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/tiny-slider.js" defer></script>
    <script src="../js/lazyload.js" defer></script>
    <script type="text/javascript" src="../js/slowNumber.js"></script>
    <script src="../js/accordion.js" defer></script>
    <script src="../js/wow.js" defer></script>
    <script src='../js/moment.min.js'></script>
    <script src='../js/fullcalendar.min.js'></script>
    <script src='../js/es.js'></script>
    <script type="text/javascript" src="../js/funciones.js" defer></script>
    <script type="text/javascript" src="../js/funciones-privado.js" defer></script>
    <script src="../js/funciones-widget.js" defer></script>
</body>
</html>
