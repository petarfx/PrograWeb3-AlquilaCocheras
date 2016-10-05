<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBuscador.ascx.cs" Inherits="AlquilaCocheras.Web.ucBuscador" %>

<div class="row">
    <div class="col s12 m6 offset-m3">
        <div class="z-depth-4 card-panel">
            <div class="row">
                <div class=" col s12 m10 offset-m1 input-field">
                    <asp:Label ID="label1" runat="server" Text="Ubicacion: "></asp:Label>
                    <asp:TextBox ID="txtUbicacion" runat="server" ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class=" col s12 m10 offset-m1 input-field">
                    <asp:Label ID="label2" runat="server" Text="Período Disponible: "></asp:Label><i class="mdi mdi-bell"></i>
                    <asp:TextBox ID="txtFechaInicio" MaxLength="10" runat="server" ClientIDMode="Static"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revFechaInicio" runat="server" ControlToValidate="txtFechaInicio"
                        ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$">Fecha de Inicio Inválida (Ingrese dd/mm/aaaa)</asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <div class=" col s12 m10 offset-m1 input-field">
                    <asp:TextBox ID="txtFechaFin" MaxLength="10" runat="server" ClientIDMode="Static"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revFechaFin" runat="server" ControlToValidate="txtFechaFin"
                        ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$">Fecha de Fin Inválida (Ingrese dd/mm/aaaa)</asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row center-align">
                <asp:CustomValidator ID="cvPorLoMenosUnoIngresado" runat="server" ClientValidationFunction="validaAlMenosUnCampoIngresado"
                    ForeColor="Red">Debe ingresar al menos un campo</asp:CustomValidator>
            </div>
            <div class="row center-align">
                <%--<div class=" col s12 m10 offset-m1 input-field">
                    <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" ClientIDMode="Static" />
                </div>--%>
                <asp:LinkButton ID="btnFiltrar" CssClass="btn cyan waves-effect waves-light" runat="server" Text="Buscar" ClientIDMode="Static" CausesValidation="true"></asp:LinkButton>

            </div>
            <div class="row center-align">
                <%--si no se encuentran resultados mostrar mensaje "No se encontraron resultados"--%>
                <asp:Label ID="lblResultado" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</div>
