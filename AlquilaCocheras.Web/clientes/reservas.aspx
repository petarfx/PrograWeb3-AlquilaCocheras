<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Clientes.Master" AutoEventWireup="true" CodeBehind="reservas.aspx.cs" Inherits="AlquilaCocheras.Web.clientes.reservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Principal" runat="server">

    <%--    LISTADO DE RESERVAS (gridview, repeater o datalist)
        
            fecha inicio.
            fecha fin
            horario
            precio total.
            puntuación 
        
    --%>

        <div class="row">
        <asp:GridView ID="gvReservas" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowDataBound="gvReservas_RowDataBound" OnSelectedIndexChanged="gvReservas_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="idReserva" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idReserva") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblid" runat="server" Text='<%# Bind("idReserva") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FechaInicio">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("FechaInicio") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblFechaInicio" runat="server" Text='<%# Bind("FechaInicio") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FechaFin">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("FechaFin") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblFechaFin" runat="server" Text='<%# Bind("FechaFin") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Horario" DataField="Horario" />
                <asp:BoundField HeaderText="PrecioTotal" DataField="PrecioTotal" />
                <asp:TemplateField HeaderText="Puntuacion">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Puntuacion") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPuntuacion" runat="server" Text='<%# Bind("Puntuacion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Puntuar" ShowHeader="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkPuntuar" runat="server"  CommandName="Select">Puntuar</asp:LinkButton> <%--class="modal-trigger" href="#miModal"--%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>


    

    <!-- Modal -->
    <div id="miModal" class="modal">
        <!-- Contenido Modal -->
        <div class="modal-content">
            <span class="close">x</span>
            <div>
                <%--hidden donde se guarda el id de la reserva elegida para que desde el codebehind se pueda identificar--%>
                <input type="hidden" id="hdIdReserva" />
                <asp:DropDownList runat="server" ID="ddlPuntuacion" ClientIDMode="Static">
                    <asp:ListItem Text="1" Value="1" />
                    <asp:ListItem Text="2" Value="2" />
                    <asp:ListItem Text="3" Value="3" />
                    <asp:ListItem Text="4" Value="4" />
                    <asp:ListItem Text="5" Value="5" />
                </asp:DropDownList>

                <asp:Button Text="Confirmar" runat="server" ID="btnConfirmar" ClientIDMode="Static" class="btn cyan waves-effect waves-light"/>
                <button class="cerrar btn cyan waves-effect waves-light">Cerrar</button>
            </div>
        </div>
    </div>

</asp:Content>
