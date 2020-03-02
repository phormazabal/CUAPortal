<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfilPublic.aspx.cs" Inherits="PortalPrivado.Web.publica.PerfilPublic" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width,initial-scale=1">
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
                    <div class="col-lg-12">
                        <div class="box-perfil w-busqueda">
                            <div class="row">
                                <div class="col-lg-12">
                                    <asp:LinkButton ID="LinkButton1" CssClass="volver" runat="server" OnClick="LinkButton1_Click"><img src="../images/flecha-izq-verde.svg" alt="">Volver</asp:LinkButton>

                                </div>
                                <div class="col-lg-12">
                                    <div class="b-doctor">
                                        <div class="titulo-doctor">
                                            <img src="../images/ic-doctor.svg" alt="">
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
                                                        <p>
                                                            <span>Especialidad:</span>
                                                            <asp:Label ID="lbEspecialidad" runat="server" Text=""></asp:Label>
                                                        </p>
                                                        <p><span>Sub Especialidad:</span><asp:Label ID="lbSubEsp" runat="server" Text=""></asp:Label></p>
                                                        <p>
                                                            <span>Área de interés:</span>
                                                            <asp:Label ID="lbAreaInteres" runat="server" Text=""></asp:Label>
                                                        </p>
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
                                        <p>
                                            Próxima hora disponible: <span>El 
                            <asp:Label ID="lbFecha" runat="server" Text="Label"></asp:Label>
                                                -
                            <asp:Label ID="lbHora" runat="server" Text="Label"></asp:Label>
                                                Hrs</span>
                                            <asp:Label ID="lbEspecialidadR" Visible="false" runat="server" Text="Label"></asp:Label>
                                        </p>
                                        <asp:LinkButton ID="lkReservar" CssClass="btn btn-amarillo" runat="server" OnClick="lkReservar_Click">RESERVAR</asp:LinkButton>
                                    </div>
                                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                                        <div class="reserva-hora">
                                        <p>
                                            Próxima hora disponible: <span>El 
                            <asp:Label ID="lbFecha1" runat="server" Text="Label"></asp:Label>
                                                -
                            <asp:Label ID="lbHora1" runat="server" Text="Label"></asp:Label>
                                                Hrs</span>
                                            <asp:Label ID="lbEspecialidadR1" runat="server" Text="Label"></asp:Label>
                                        </p>
                                        <asp:LinkButton ID="LinkButton2" CssClass="btn btn-amarillo" runat="server" OnClick="lkReservar2_Click">RESERVAR</asp:LinkButton>
                                    </div>
                                    </asp:Panel>
                                    <div class="titulo-doctor">
                                        <img src="../images/ic-doc.svg" class="ic-doc" alt=""/>
                                        <h2 class="t-2b">Descripción</h2>
                                    </div>
                                    <div class="des-doc">
                                        <p>
                                            <asp:Label ID="lbDetalle" runat="server" Text=""></asp:Label>
                                        </p>
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
           <style>
   .p-2 {
       padding-top: 0;
       padding-bottom: : 0;
   }
   </style>
</body>
</html>
