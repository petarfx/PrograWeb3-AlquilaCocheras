<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Propietarios.Master" AutoEventWireup="true" CodeBehind="reservas.aspx.cs" Inherits="AlquilaCocheras.Web.propietarios.reservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Principal" runat="server">
    <asp:HiddenField ID="esEdicion" runat="server" />
    <div class="row">
        <div class="col s12 m10 offset-m1">
            <div class="z-depth-4 card-panel">
                <div class="row">
                    <div class=" col s12 m12 input-field">
                        <asp:Label ID="label1" runat="server" Text="Período Disponible: "></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class=" col s12 m12 iconoDate">
                        <asp:TextBox ID="txtFechaInicio" runat="server" ClientIDMode="Static" MaxLength="10"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revFechaInicio" runat="server" ControlToValidate="txtFechaInicio"
                            ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ErrorMessage="Fecha de Inicio Inválida (Ingrese dd/mm/aaaa)">*</asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtFechaFin" runat="server" ClientIDMode="Static" MaxLength="10"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revFechaFin" runat="server" ControlToValidate="txtFechaFin"
                            ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ErrorMessage="Fecha de Fin Inválida (Ingrese dd/mm/aaaa)">*</asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="cvDate90" runat="server" ClientValidationFunction="validaFecha90" ForeColor="Red" ErrorMessage="El periodo de fechas a filtrar no puede ser mayor de 90 días">*</asp:CustomValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtFechaFin" ControlToValidate="txtFechaInicio" ErrorMessage="La Fecha de Inicio no puede superar la de Fin" ForeColor="Red" Type="Date" Operator="LessThan">*</asp:CompareValidator>
                    </div>
                </div>
                <div class="row">
                    <div class=" col s12 m12 input-field">
                        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" ClientIDMode="Static" CssClass="btn cyan waves-effect waves-light" OnClick="btnFiltrar_Click" />
                    </div>
                    <asp:ValidationSummary ID="vsReservas" runat="server" ForeColor="Red" />
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <asp:GridView ID="gvReservas" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowDataBound="gvCocheras_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="idCochera" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idCochera") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblid" runat="server" Text='<%# Bind("idCochera") %>'></asp:Label>
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
                <asp:BoundField HeaderText="Ubicacion" DataField="Ubicacion" />
                <asp:BoundField HeaderText="CantidadHoras" DataField="CantidadHoras" />
                <asp:BoundField HeaderText="Usuario" DataField="UsuarioReserva" />
                <asp:BoundField HeaderText="Puntuacion" DataField="Puntuacion" />
                <asp:BoundField DataField="Precio" HeaderText="TotalCobrado" />
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


    <script>
        $(function () {
            $.datepicker.regional['es'] = {
                closeText: 'Cerrar',
                prevText: '<Ant',
                nextText: 'Sig>',
                currentText: 'Hoy',
                monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
                dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
                dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
                weekHeader: 'Sm',
                dateFormat: 'dd/mm/yy',
                showOn: "button",
                buttonImage: "../imagenes/calendario.png",
                //buttonImageOnly: true,
                buttonText: "Seleccione una Fecha",
                firstDay: 1,
                isRTL: false,
                //showMonthAfterYear: false,
                yearSuffix: ''
            };
            $.datepicker.setDefaults($.datepicker.regional['es']);

            $(function () {
                $("#txtFechaInicio,#txtFechaFin").datepicker();
            });

        });
    </script>

</asp:Content>
