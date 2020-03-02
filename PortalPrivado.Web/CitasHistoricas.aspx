<%@ Page Title="" Language="C#" MasterPageFile="~/PortalM.Master" AutoEventWireup="true" CodeBehind="CitasHistoricas.aspx.cs" Inherits="PortalPrivado.Web.CitasHistoricas" %>
<asp:Content ID="Content1" class="box-perfil s-p" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" class="box-perfil s-p" runat="server">
        <ContentTemplate>
            <div class="box-perfil s-p">
                <div class="box-res tabla-prof mt-0">
                    <table class="table-responsive">
                        <thead>
                            <tr>
                                <th>Profesional</th>
                                <th>Especialidad</th>
                                <th>Hora Historica</th>

                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="grdHistorico" runat="server" OnPagePropertiesChanging="grdHistorico_PagePropertiesChanging">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Medico") %></td>
                                        <td><%# Eval("Especialidad") %></td>
                                        <td>
                                            <p>
                                                <%# Eval("Fecreserva") %>
                                            </p>
                                        </td>

                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </tbody>
                    </table>
                </div>
                <div class="paginador">
                    <a href="#" class="pag-nav"><i class="fas fa-chevron-left"></i></a>
                    <asp:DataPager ID="DataPager1" PagedControlID="grdHistorico" PageSize="10" runat="server">
                        <Fields>
                            <asp:NumericPagerField />
                        </Fields>
                    </asp:DataPager>
                    <a href="#" class="pag-nav"><i class="fas fa-chevron-right"></i></a>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
