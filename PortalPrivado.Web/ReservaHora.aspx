<%@ Page Title="" Language="C#" MasterPageFile="~/PortalM.Master" AutoEventWireup="true" CodeBehind="ReservaHora.aspx.cs" Inherits="PortalPrivado.Web.ReservaHora" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <script>
        function IAmSelected(source, eventArgs) {
            alert(eventArgs.get_value());
            document.getElementById("contentPlaceHolder_hdRut").value = eventArgs.get_value();
        }
    </script>
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <div class="box-perfil" id="form-perfil">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <ajaxToolkit:ModalPopupExtender runat="server" PopupControlID="divdesv" TargetControlID="Label1" ID="LinkButton3_ModalPopupExtender"></ajaxToolkit:ModalPopupExtender>
        <div class="pasos-reserva">
            <div class="paso activo">
                <div class="num-paso">
                    <span>1</span>
                </div>
                <p>Búsqueda</p>
            </div>
            <div class="paso">
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
        <div class="box-busqueda">
            <div class="w-form full">
                <div class="form-group">
                    <label>Ingrese la especialidad o nombre del profesional</label>
                    <asp:DropDownList ID="dpBusqueda" CssClass="chosen-select" runat="server" OnSelectedIndexChanged="dpBusqueda_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="w-form full">
                        <div class="form-group text-right mb-0">
                        </div>
                        <div class="form-group text-right mb-0">
                            <asp:LinkButton ID="btnaceptarSimple" CssClass="btn btn-amarillo" OnClick="btnAceptar_Click" Visible="false" runat="server">BUSCAR</asp:LinkButton>
                            <%-- <asp:Button ID="btnaceptarSimple" CssClass="btn btn-amarillo" runat="server" Text="Buscar" OnClick="btnAceptar_Click" Visible="false" />--%>
                        </div>
                    </div>
                    <div class="w-form full">
                        <div class="form-group">
                            <label>
                                <asp:Label ID="lbEspejo" runat="server" Text="Ingrese la especialidad" Visible="false"></asp:Label></label>
                            <asp:DropDownList ID="dpEspejo" CssClass="chosen-select" runat="server" Visible="false" TabIndex="1"></asp:DropDownList>
                        </div>
                        <div class="form-group text-right mb-0">

                            <asp:LinkButton ID="btnAceptar" CssClass="btn btn-amarillo" OnClick="btnAceptar_Click" Visible="false" runat="server">BUSCAR</asp:LinkButton>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="dpBusqueda" EventName="SelectedIndexChanged" />
                    <%--<asp:AsyncPostBackTrigger ControlID="btnaceptarSimple" EventName="Click" />--%>
                    <asp:PostBackTrigger ControlID="btnaceptarSimple" />
                    <asp:PostBackTrigger ControlID="btnAceptar" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <%--<asp:Panel ID="pnModal" runat="server" Visible="false">
        <div id="divdesv">
            <div class="popup visible">
                <div class="w-pop">
                    <h3>Sesión Portal Clínica Universidad de los Andes</h3>
                    <p><span>Su sesión ha caducado, favor ingresar sus credenciales nuevamente</span></p>
                    <div class="botones">
                        <asp:LinkButton ID="LinkButton4" CssClass="btn btn-amarillo" runat="server" OnClick="LinkButton4_Click">ACEPTAR</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>--%>
</asp:Content>
