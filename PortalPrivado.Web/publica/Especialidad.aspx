<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="Especialidad.aspx.cs" Inherits="PortalPrivado.Web.publica.Especialidad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    <script type="text/javascript">
        function ActivarPostClickAceptar() {
            div = document.getElementById('divdesv');
            div.style.display = 'none';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <ajaxToolkit:ModalPopupExtender runat="server" PopupControlID="divdesv" TargetControlID="Label1" ID="LinkButton3_ModalPopupExtender"></ajaxToolkit:ModalPopupExtender>
        <section class="p-2 home-priv">
            <div class="wrap">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="box-perfil w-busqueda">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:LinkButton ID="LinkButton1" CssClass="volver" runat="server" OnClick="LinkButton1_Click"><img src="../images/flecha-izq-verde.svg" alt="">Volver</asp:LinkButton>

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
                                <p>
                                    <b>Se han encontrado
                    <asp:Literal ID="lbCantidad" runat="server"></asp:Literal>
                                        resultados para Especialidad:</b> <span>
                                            <asp:Label ID="lbEspecialidad" runat="server" Text=""></asp:Label></span>
                                </p>
                            </div>
                            
                                    <asp:HiddenField ID="hdIdEspcialidad" runat="server" />
                                   <%-- <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
                                        <ContentTemplate>--%>
                                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="w-filtro flex-right">
                                        <div class="filtros">
                                            <img src="../images/ver-lista.png" alt="" id="ver-lista"/>
                                            <img src="../images/ver-grid.png" alt="" id="ver-grid" class="activo"/>
                                            <label for="s-filtros">
                                                <asp:Label ID="lbFiltros" runat="server" Text="Filtros"></asp:Label></label>
                                            <asp:DropDownList ID="dpSub" name="s-filtros" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dpSub_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                            <div class="row row-small grid-esp">
                                                <asp:ListView ID="DataList2" DataKeyNames="IdMedico" runat="server" EnablePersistedSelection="true" PersistentDataSource="true" OnPagePropertiesChanging="DataList2_PagePropertiesChanging" OnItemCommand="DataList2_ItemCommand" >
                                                    <ItemTemplate>
                                                        <div class="col-xl-4 col-lg-4 col-md-4 col-sm-6">
                                                            <div class="box-esp">
                                                                <figure>
                                                                    <img alt="" src='<%# Eval("Value[0].oImagenes.Url") %>' />
                                                                </figure>
                                                                <div class="texto-esp">
                                                                    <h4>
                                                                        <asp:Label ID="lbNombreMed" runat="server" Text='<% # Eval("Value[0].Nombres") + " " + Eval("Value[0].Apellidos") %>'></asp:Label></h4>
                                                                        <asp:HiddenField ID="hdIdMed" runat="server" Value='<% # Eval("IdMedico")%>' />
                                                                    <p>
                                                                        <asp:Label ID="lbEspMed" runat="server" Text='<% # Eval("Especialidad") %>'/>
                                                                    </p>
                                                                    <div class="botones flex-center">
                                                                        <asp:LinkButton ID="btnVerAgenda" CssClass="btn btn-verde" CommandName="VerAgenda" runat="server">VER AGENDA</asp:LinkButton>
                                                                        <asp:LinkButton ID="btnPerfil" CssClass="btn btn-blanco" CommandName="VerPerfil" runat="server">VER PERFIL</asp:LinkButton>

                                                                    </div>
                                                                </div>
                                                                <div class="botones-mobile">
                                                                    <asp:LinkButton ID="btnVerAgendaMob" CssClass="btn btn-verde" CommandName="VerAgenda" runat="server">VER AGENDA</asp:LinkButton>
                                                                    <asp:LinkButton ID="btnPerfilMob" CssClass="btn btn-blanco" CommandName="VerPerfil" runat="server">VER PERFIL</asp:LinkButton>
                                                                </div>
                                                            </div>
                                                            <div class="box-hora">
                                                                <p>
                                                                    <asp:Label ID="Label1" runat="server" Text='<% # Eval("Fecha") %>'></asp:Label>
                                                                </p>
                                                                <asp:LinkButton ID="btnReservaDirecta" CssClass="btn btn-amarillo" runat="server" CommandName="ReservaDirecta">RESERVAR HORA</asp:LinkButton>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                                <br />
                                            </div>
                                             <div class="paginador">
                                   <%-- <a href="#" class="pag-nav"><i class="fas fa-chevron-left"></i></a>--%>
                                    <asp:DataPager ID="DataPager1" PagedControlID="DataList2" PageSize="6" runat="server">
                                        <Fields>
                                            <asp:NumericPagerField />
                                        </Fields>
                                    </asp:DataPager>
                                    <%--<asp:LinkButton ID="lkNext" CssClass="pag-nav" runat="server"><i class="fas fa-chevron-right"></i></asp:LinkButton>--%>
                                    <%--<a href="#" class="pag-nav"><i class="fas fa-chevron-right"></i></a>--%>
                                </div></div></div>
                                        <%--</ContentTemplate>
                                        <Triggers>--%>
                                            <%--<asp:AsyncPostBackTrigger ControlID="dpSub" EventName="SelectedIndexChanged" />--%>
                                           <%--  <asp:AsyncPostBackTrigger ControlID="DataList2" EventName="DataBinding" />
                                            <asp:AsyncPostBackTrigger ControlID="DataList2" />--%>
                                            <%--<asp:AsyncPostBackTrigger ControlID="DataPager1" EventName="DataBinding" />--%>
                                            <asp:PostBackTrigger ControlID="dpSub" />
                                            <%--<asp:PostBackTrigger ControlID="DataPager1" />
                                            <asp:PostBackTrigger ControlID="DataList2" />--%>
                                       <%-- </Triggers>
                                    </asp:UpdatePanel>--%>
                                <%--</div>
                            </div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </section>    
        <asp:Panel ID="pnPop" runat="server" Visible="false">
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
    </form>
    <script type="text/javascript" src="../js/iframeResizer.contentWindow.min.js" defer></script>     
<script type="text/javascript" src="../js/funciones.js" defer></script> 
       <style>
   .p-2 {
       padding-top: 0;
       padding-bottom: : 0;
   }
   </style>
</body>
</html>
