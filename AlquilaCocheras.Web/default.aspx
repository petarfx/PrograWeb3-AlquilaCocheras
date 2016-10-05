<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Anonimo.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AlquilaCocheras.Web._default" %>

<%@ Register TagName="Buscador" TagPrefix="uc" Src="~/ucBuscador.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Principal" runat="server">
    <%-- <%--Esto va en un UserControl--%>    <%--Inicio User Control--%>    <%--<asp:Label ID="label1" runat="server" Text="Ubicación: "></asp:Label>
    <asp:TextBox ID="txtUbicacion" runat="server" ClientIDMode="Static"></asp:TextBox>
    
    <asp:Label ID="label2" runat="server" Text="Período Disponible: "></asp:Label>
    <asp:TextBox ID="txtFechaInicio" runat="server" ClientIDMode="Static"></asp:TextBox>
    <asp:TextBox ID="txtFechaFin" runat="server" ClientIDMode="Static"></asp:TextBox>

    <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" ClientIDMode="Static" />--%>
    <%--si no se encuentran resultados mostrar mensaje "No se encontraron resultados"--%>    <%--<asp:Label ID="lblResultado" runat="server"></asp:Label>--%>    <%--Fin User Control--%>
    <uc:Buscador runat="server" ID="ucBuscador" myFiltrar="btnFiltrar" EnableViewState="false" />

    <%--    LISTADO  (gridview, repeater o datalist)
    Por cada disponibilidad se deberá mostrar la siguiente información:
    precio, 
    nombre y 
    apellido del propietario, 
    precio total por las horas que se desean reservar, 
    la foto, 
    el mapa del lugar donde está ubicado (utilizar la API de Google Maps) 
    la puntuación promedio        
    y el link a confirmar reserva que esta agregado abajo como asp:HyperLink, 
        donde deberán cambiarle dinamicamente el link y ponerle el idcochera correspondiente
    --%>
    <div class="row">
        <asp:GridView ID="gvCocheras" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="idCochera" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idCochera") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("idCochera") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Precio" DataField="Precio" />
                <asp:BoundField HeaderText="ApeyNom" DataField="ApeyNom" />
                <asp:BoundField HeaderText="PrecioTotal" DataField="PrecioTotal" />
                <asp:BoundField HeaderText="Foto" DataField="Foto" />
                <asp:BoundField HeaderText="Mapa" DataField="Mapa" />
                <asp:BoundField HeaderText="Puntuacion" DataField="Puntuacion" />
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

    <asp:HyperLink ID="aConfirmar" runat="server" ClientIDMode="Static" NavigateUrl="/clientes/confirmar-reserva.aspx?idcochera=123">Reservar</asp:HyperLink>
</asp:Content>

