<%@ Page Title="" Language="C#" MasterPageFile="~/PortalM.Master" AutoEventWireup="true" CodeBehind="Activa.aspx.cs" Inherits="PortalPrivado.Web.Activa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" class="box-perfil s-p" runat="server">
        <ContentTemplate>            
            <div class="box-res tabla-prof mt-0">
                <asp:HiddenField ID="hdMod" runat="server" />
                <table class="table-responsive">
                    <thead>
                        <tr>
                            <th>Profesional</th>
                            <th>Especialidad</th>
                            <th>Hora Historica</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="grdHistorico" DataKeyNames="CodCita" runat="server" OnItemCommand="grdHistorico_ItemCommand" OnPagePropertiesChanging="grdHistorico_PagePropertiesChanging">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Medico") %></td>
                                    <td><%# Eval("Especialidad") %></td>
                                    <td>
                                        <p>
                                            <%# Eval("Fecreserva") %>
                                        </p>
                                    </td>
                                    <td class="s-p">
                                        <div class="botones-tabla">
                                            <asp:LinkButton ID="LinkButton1" CommandName="A" class="btn btn-borde-gris" runat="server">ANULAR</asp:LinkButton>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </tbody>
                </table>
            </div>
            <div class="paginador">
                <a href="#" class="pag-nav"><i class="fas fa-chevron-left"></i></a>
                <asp:DataPager ID="DataPager1" PagedControlID="grdHistorico" PageSize="6" runat="server">
                    <Fields>
                        <asp:NumericPagerField />
                    </Fields>
                </asp:DataPager>
                <a href="#" class="pag-nav"><i class="fas fa-chevron-right"></i></a>
            </div>
            <asp:Label ID="ALabel2" runat="server" Text=""></asp:Label>
           <%-- <ajaxToolkit:ModalPopupExtender runat="server" PopupControlID="pnAnular" TargetControlID="ALabel2" ID="LinkButton3_ModalPopupExtender"></ajaxToolkit:ModalPopupExtender>--%>
            <asp:Panel ID="pnAnular" runat="server" Visible="false">
                <asp:UpdatePanel ID="udpInnerUpdatePanel" runat="Server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="divAnular">
                            <div class="popup visible">
                                <div class="w-pop">
                                    <div class="cerrar-pop">
                                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"><i class="fas fa-times"></i></asp:LinkButton>
                                    </div>
                                    <h3>Anulación de cita</h3>
                                    <p><span>¿Esta seguro que desea anular la cita?</span></p>
                                    <div class="botones">
                                        <asp:LinkButton ID="LinkButton3" CssClass="btn btn-borde-gris" runat="server" OnClick="LinkButton3_Click">CANCELAR</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton4" CssClass="btn btn-amarillo" runat="server" OnClick="LinkButton4_Click">Anular</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>                        
                    </Triggers>
                </asp:UpdatePanel>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
