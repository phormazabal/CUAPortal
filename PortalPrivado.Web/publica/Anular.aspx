<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Anular.aspx.cs" Inherits="PortalPrivado.Web.publica.Anular" %>

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
    <link rel="stylesheet" href="../css/tiny-slider.css" type="text/css" />
    <link rel="stylesheet" href="../css/animate.css" type="text/css" />
    <link rel="stylesheet" href="../css/normalize.css" type="text/css" />
    <link rel="stylesheet" href="../css/estilos.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
                <section class="p-2 home-priv">
                    <div class="wrap">
                        <div class="row">
                            <div class="col-lg-9">
                                <div class="box-perfil w-busqueda anular-hora">
                                    <div class="box-busqueda b-anular">
                                        <label>Para visualizar sus horas médicas activas, por favor, ingrese su RUT o Pasaporte y código de reserva.</label>
                                        <div class="row">
                                            <div class="col-lg-9">
                                                <div class="form-group">
                                                    <label>RUT / Pasaporte:</label>
                                                    <asp:TextBox ID="txtRut" runat="server"></asp:TextBox>
                                                    <%--<input type="text" placeholder="Ej: 9.999.999-9">--%>
                                                </div>
                                                <div class="form-group">
                                                    <label>Código Reserva:</label>
                                                    <asp:TextBox ID="txtCod" runat="server"></asp:TextBox>
                                                    <%--<input type="text" placeholder="">--%>
                                                </div>
                                                <div class="text-right">
                                                    <asp:LinkButton ID="lkBuscar" runat="server" CssClass="btn btn-amarillo"  OnClick="lkBuscar_Click">BUSCAR</asp:LinkButton>
                                                    
                                                    <%--<a href="http://lfi.lfi.cl/clinica-uandes-reserva/anular-hora2.html" class="btn btn-amarillo"></a>--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </section>
            <%--</ContentTemplate>
            <Triggers>
               
                <asp:AsyncPostBackTrigger ControlID="lkBuscar" EventName="Click" />
               
            </Triggers>
        </asp:UpdatePanel>--%>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <div class="popup visible">
                <div class="w-pop">
                   <%-- <div class="cerrar-pop close-pop">--%>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lkCancelar_Click" CssClass="cerrar-pop close-pop"><i class="fas fa-times"></i></asp:LinkButton><%--</div>--%>
                    <h3>¿Esta seguro que desea anular la hora reserva?</h3>
                    <p class="text-left">
                        <b><asp:Label ID="lbNombreMed" runat="server" Text="Profesional: "></asp:Label></b><asp:Literal ID="ltMedico" Text="" runat="server"></asp:Literal><br>
                        <b>
                            <asp:Label ID="lbFecha" runat="server" Text="Fecha: "></asp:Label></b><asp:Literal ID="ltFecha" runat="server"></asp:Literal><br>
                        <b>
                            <asp:Label ID="lbHora" runat="server" Text="Hora: "></asp:Label></b><asp:Literal ID="ltHora" runat="server"></asp:Literal><br>
                        <b>
                            <asp:Label ID="lbEspecialidad" runat="server" Text="Especialidad: "></asp:Label></b> <asp:Literal ID="ltEspecialidad" runat="server"></asp:Literal><br>
                    
                    </p>
                    <div class="text-right">
                        <asp:LinkButton ID="lkCancelar" runat="server" CssClass="btn btn-borde-gris close-pop" OnClick="lkCancelar_Click">CANCELAR</asp:LinkButton>
                        <asp:LinkButton ID="lkAnular" runat="server" OnClick="lkAnular_Click" class="btn btn-amarillo">ANULAR</asp:LinkButton>
                        
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="PnAnu" runat="server" Visible="false">
            <div class="popup visible">
                <div class="w-pop">
                   <%-- <div class="cerrar-pop close-pop">--%>
                        <a id="aClose" target="_parent" runat="server" class="cerrar-pop close-pop"><i class="fas fa-times"></i></a><%--</div>--%>
                    <h3>Anulación de Reserva</h3>
                    <p class="text-left">
                        <b>La reserva  fue anulada con exito.</b></p>
                    <div class="text-right">                        
                        <a id="aOk" target="_parent" runat="server" class="btn btn-amarillo">ACEPTAR</a>                        
                    </div>
                </div>
            </div>
        </asp:Panel>
    </form>
    <%--<script src="../js/jquery.min.js"></script>
    <script src="../js/tiny-slider.js" defer></script>
    <script src="../js/jquery.basictable.min.js" defer></script>
    <script src="../js/lazyload.js" defer></script>
    <script src="../js/accordion.js" defer></script>
    <script src="../js/wow.js" defer></script>
    <script type="text/javascript" src="../js/funciones.js" defer></script>
    <script type="text/javascript" src="../js/funciones-privado.js" defer></script>
    <script src="../js/funciones-widget.js" defer></script>--%>
</body>
</html>
