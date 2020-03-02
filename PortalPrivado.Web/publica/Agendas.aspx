<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agendas.aspx.cs" Inherits="PortalPrivado.Web.publica.Agendas" %>

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
        <section class="p-2 home-priv">
            <div class="wrap">
                <div class="row">
                    <div class="col-lg-9">
                        <div class="box-perfil w-busqueda">
                            <div class="col-lg-12">
                                <asp:LinkButton ID="LinkButton1" CssClass="volver" runat="server" OnClick="LinkButton1_Click"><img src="../images/flecha-izq-verde.svg" alt="">Volver</asp:LinkButton>
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

                            <div class="row row-small">
                                <div class="col-lg-6">
                                    <div class="box-res">
                                        <h3>Profesional</h3>
                                        <div class="cont-res">
                                            <div class="item">
                                                <figure>
                                                    <asp:Image ID="imgDoctor" runat="server" />
                                                    <%-- <img src="images/min-doc.jpg" alt="">--%>
                                                </figure>
                                                <div class="texto">
                                                    <h4>
                                                        <asp:Label ID="lbNombre" runat="server" Text="Label"></asp:Label></h4>
                                                    <asp:LinkButton ID="lkVerPerfil" CssClass="btn btn-verde" runat="server" OnClick="lkVerPerfil_Click">VER PERFIL</asp:LinkButton>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="box-res">
                                        <h3>Especialidad</h3>
                                        <div class="cont-res s-p">
                                            <div class="item-agenda">
                                                <p>
                                                    <asp:Label ID="lbEspecialidad1" runat="server" Text="Label"></asp:Label>
                                                </p>
                                                <asp:LinkButton ID="lnkEsp1" CssClass="btn btn-amarillo" runat="server" OnClick="lnkEsp1_Click">VER AGENDA</asp:LinkButton>

                                            </div>
                                            <div class="item-agenda">
                                                <p>
                                                    <asp:Label ID="lbEspecialidad2" runat="server" Text="Label"></asp:Label>
                                                </p>
                                                <asp:LinkButton ID="lnkEsp2" CssClass="btn btn-amarillo" runat="server" OnClick="lnkEsp2_Click">VER AGENDA</asp:LinkButton>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
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
