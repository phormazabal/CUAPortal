<%@ Page Title="" Language="C#" MasterPageFile="~/PortalM.Master" AutoEventWireup="true" CodeBehind="Especialidad.aspx.cs" Inherits="PortalPrivado.Web.Especialidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="box-perfil" id="form-perfil">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
            <p>
                <b>Se han encontrado
                    <asp:Literal ID="lbCantidad" runat="server"></asp:Literal>
                    resultados para Especialidad:</b> <span>
                        <asp:Label ID="lbEspecialidad" runat="server" Text=""></asp:Label></span>
            </p>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <div class="w-filtro flex-right">
                    <div class="filtros">
                        <img src="images/ver-lista.png" alt="" id="ver-lista">
                        <img src="images/ver-grid.png" alt="" id="ver-grid" class="activo">
                        <label for="s-filtros">
                            <asp:Label ID="lbFiltros" runat="server" Text="Filtros"></asp:Label></label>
                        <asp:DropDownList ID="dpSub" name="s-filtros" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dpSub_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>

                <asp:HiddenField ID="hdIdEspcialidad" runat="server" />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="row row-small grid-esp">
                            <asp:ListView ID="DataList2" DataKeyNames="IdMedico" runat="server" EnablePersistedSelection="true" PersistentDataSource="true" OnPagePropertiesChanging="DataList2_PagePropertiesChanging" OnItemCommand="DataList2_ItemCommand">
                                <ItemTemplate>
                                    <div class="col-lg-4 col-md-6">
                                        <div class="box-esp">
                                            <figure>
                                                <img alt="" src='<%# Eval("Value[0].oImagenes.Url") %>' />
                                            </figure>
                                            <div class="texto-esp">
                                                <h4>
                                                    <asp:Label ID="lbNombreMed" runat="server" Text='<% # Eval("Value[0].Nombres") + " " + Eval("Value[0].Apellidos") %>'></asp:Label></h4>
                                                <p>
                                                    <asp:Label ID="lbEspMed" runat="server" Text='<% # Eval("Especialidad") %>'></asp:Label>
                                                </p>
                                                <div class="botones flex-center">
                                                    <asp:LinkButton ID="btnVerAgenda" CssClass="btn btn-verde" CommandName="VerAgenda" runat="server">VER AGENDA</asp:LinkButton>
                                                    <asp:LinkButton ID="btnPerfil" CssClass="btn btn-blanco" CommandName="VerPerfil" runat="server">VER PERFIL</asp:LinkButton>

                                                </div>
                                            </div>
                                            <div class="botones-mobile">
                                                <asp:LinkButton ID="btnVerAgendaMob" CssClass="btn btn-verde" CommandName="VerAgenda" runat="server">VER AGENDA</asp:LinkButton>
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
                         </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="dpSub" EventName="SelectedIndexChanged" />
                        <asp:PostBackTrigger ControlID="DataPager1" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <div class="paginador">
                <%--<a href="#" class="pag-nav"><i class="fas fa-chevron-left"></i></a>--%>
                <asp:DataPager ID="DataPager1" PagedControlID="DataList2" PageSize="6" runat="server">
                    <Fields>
                        <asp:NumericPagerField />
                    </Fields>
                </asp:DataPager>
                <%--<asp:LinkButton ID="lkNext" CssClass="pag-nav" runat="server"><i class="fas fa-chevron-right"></i></asp:LinkButton>--%>
                <%--<a href="#" class="pag-nav"><i class="fas fa-chevron-right"></i></a>--%>
            </div>

        </div>
    </div>
    <asp:Panel ID="pnPop" runat="server" Visible="false">
        <div id="divdesv">
            <div class="popup visible">
                <div class="w-pop">                    
                    <h3>Particularidad de una cita</h3>
                    <p>
                        <asp:Label ID="lbParticularidades" runat="server" Text="Label"></asp:Label><span>
                            <asp:Label ID="lbNombreDes" runat="server" Text=""></asp:Label>?</span>
                    </p>
                    <div class="botones">
                        <asp:LinkButton ID="lnkAceptar" CssClass="" runat="server" OnClick="LinkButton4_Click">Aceptar</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
     
</asp:Content>
