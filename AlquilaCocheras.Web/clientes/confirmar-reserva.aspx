<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Clientes.Master" AutoEventWireup="true" CodeBehind="confirmar-reserva.aspx.cs" Inherits="AlquilaCocheras.Web.clientes.confirmar_reserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Principal" runat="server">

    <%--    <asp:Label ID="label2" runat="server" Text="Fecha Inicio: "></asp:Label>
    <asp:TextBox ID="txtFechaInicio" runat="server" ClientIDMode="Static"></asp:TextBox>
    <asp:Label ID="label4" runat="server" Text="Fecha Fin: "></asp:Label>
    <asp:TextBox ID="txtFechaFin" runat="server" ClientIDMode="Static"></asp:TextBox>

    <asp:Label ID="label3" runat="server" Text="Hora de Entrada: "></asp:Label>
    <asp:TextBox ID="txtHorarioInicio" runat="server" ClientIDMode="Static"></asp:TextBox>
    <asp:Label ID="label1" runat="server" Text="Hora de Salida: "></asp:Label>
    <asp:TextBox ID="txtHorarioFin" runat="server" ClientIDMode="Static"></asp:TextBox>

    <asp:Label ID="lblUbicacion" ClientIDMode="Static" runat="server"></asp:Label>
    <asp:Image ID="imgFoto" ClientIDMode="Static" runat="server" />
    <asp:Label ID="lblPrecioHora" ClientIDMode="Static" runat="server"></asp:Label>
    <asp:Label ID="lblPrecioTotal" ClientIDMode="Static" runat="server"></asp:Label>

    <asp:Label ID="lblResultado" runat="server"></asp:Label>
    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar Reserva" ClientIDMode="Static"/>   
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" ClientIDMode="Static" />--%>


    <div class="row">
        <div class="col s12 m10 offset-m1">
            <div class="z-depth-4 card-panel">

                <div class="row">
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label2" runat="server" Text="Fecha Inicio: "></asp:Label>
                        <asp:TextBox ID="txtFechaInicio" runat="server" ClientIDMode="Static" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFechaInicio" runat="server" ControlToValidate="txtFechaInicio" ErrorMessage="Debe ingresar la fecha de inicio" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revFInicio" runat="server" ControlToValidate="txtFechaInicio" ErrorMessage="Fecha de Inicio Invalida (Ingrese dd/mm/aaaa)" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$">*</asp:RegularExpressionValidator>
                    </div>
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label4" runat="server" Text="Fecha Fin: "></asp:Label>
                        <asp:TextBox ID="txtFechaFin" runat="server" ClientIDMode="Static" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtFechaFin" runat="server" ControlToValidate="txtFechaFin" ErrorMessage="Debe ingresar la fecha de fin" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revFechaFin" runat="server" ControlToValidate="txtFechaFin" ErrorMessage="Fecha de Fin Invalida (Ingrese dd/mm/aaaa)" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$">*</asp:RegularExpressionValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtFechaFin" ControlToValidate="txtFechaInicio" ErrorMessage="La Fecha de Inicio no puede superar la de Fin" ForeColor="Red" Type="Date" Operator="LessThan">*</asp:CompareValidator>
                    </div>
                </div>

                <div class="row">
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label1" runat="server" Text="Hora de Entrada: "></asp:Label>
                        <asp:TextBox ID="txtHorarioInicio" runat="server" ClientIDMode="Static" MaxLength="5"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtHorarioInicio" runat="server" ControlToValidate="txtHorarioInicio" ErrorMessage="Debe ingresar la hora de inicio" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revHoraInicio" runat="server" ControlToValidate="txtHorarioInicio" ErrorMessage="Formato de Hora invalido (hh:mm) en formato 24hs" ForeColor="Red" ValidationExpression="^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$">*</asp:RegularExpressionValidator>
                    </div>
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label3" runat="server" Text="Hora de Salida: "></asp:Label>
                        <asp:TextBox ID="txtHorarioFin" runat="server" ClientIDMode="Static" MaxLength="5"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtHorarioFin" runat="server" ControlToValidate="txtHorarioFin" ErrorMessage="Debe ingresar la hora de fin" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvHorario" runat="server" ControlToCompare="txtHorarioFin" ControlToValidate="txtHorarioInicio" ErrorMessage="El horario de Inicio no puede superar el de Fin" ForeColor="Red" Operator="LessThan">*</asp:CompareValidator>
                        <asp:RegularExpressionValidator ID="revHoraFin" runat="server" ControlToValidate="txtHorarioFin" ErrorMessage="Formato de Hora invalido (hh:mm) en formato 24hs" ForeColor="Red" ValidationExpression="^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$">*</asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="row">
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label5" runat="server" Text="Precio Hora: "></asp:Label>
                        <asp:Label ID="lblPrecioHora" name="PrecioHora" ClientIDMode="Static" runat="server"></asp:Label>

                    </div>
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label6" runat="server" Text="Precio Total: "></asp:Label>
                        <asp:Label ID="lblPrecioTotal" name="PrecioTotal" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                </div>

                <div class="row">
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label7" runat="server" Text="Ubicacion: "></asp:Label>
                        <asp:Label ID="lblUbicacion" ClientIDMode="Static" runat="server"></asp:Label>

                    </div>
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label9" runat="server" Text="Foto: "></asp:Label>
                        <asp:Image ID="imgFoto" ClientIDMode="Static" runat="server" />
                    </div>
                </div>

                <div class="row">
                    <div class=" col s12 m12 center-align input-field">
                        <asp:Button ID="btnConfirmar" runat="server" Class="btn cyan waves-effect waves-light" Text="Confirmar Reserva" ClientIDMode="Static" OnClick="btnConfirmar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Class="btn cyan waves-effect waves-light" Text="Cancelar" ClientIDMode="Static" />
                    </div>
                </div>
                <div class="row">
                    <div class=" col s12 m12 center-align input-field">
                        <asp:Label ID="lblResultado" runat="server"></asp:Label>
                    </div>
                </div>

                <div class="row">
                    <div class=" col s12 center-align">
                        <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" />
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
