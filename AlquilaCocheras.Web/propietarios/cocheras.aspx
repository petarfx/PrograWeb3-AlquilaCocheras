<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Propietarios.Master" AutoEventWireup="true" CodeBehind="cocheras.aspx.cs" Inherits="AlquilaCocheras.Web.propietarios.cocheras" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Principal" runat="server">

    <%--<asp:Label ID="label1" runat="server" Text="Ubicación: "></asp:Label>
    <asp:TextBox ID="txtUbicacion" runat="server" ClientIDMode="Static"></asp:TextBox>

    <asp:Label ID="label2" runat="server" Text="Período Disponible: "></asp:Label>
    <asp:TextBox ID="txtFechaInicio" runat="server" ClientIDMode="Static"></asp:TextBox>
    <asp:TextBox ID="txtFechaFin" runat="server" ClientIDMode="Static"></asp:TextBox>

    <asp:Label ID="label3" runat="server" Text="Horario Diario Disponible: "></asp:Label>
    <asp:TextBox ID="txtHorarioInicio" runat="server" ClientIDMode="Static"></asp:TextBox>
    <asp:TextBox ID="txtHorarioFin" runat="server" ClientIDMode="Static"></asp:TextBox>

    <asp:Label ID="label4" runat="server" Text="Descripción: "></asp:Label>
    <asp:TextBox ID="txtDescripcion" runat="server" ClientIDMode="Static"></asp:TextBox>

    <asp:Label ID="label5" runat="server" Text="Latitud: "></asp:Label>
    <asp:TextBox ID="txtLatitud" runat="server" ClientIDMode="Static"></asp:TextBox>

    <asp:Label ID="label6" runat="server" Text="Longitud: "></asp:Label>
    <asp:TextBox ID="txtLongitud" runat="server" ClientIDMode="Static"></asp:TextBox>

    <asp:Label ID="label7" runat="server" Text="Metros Cuadrados: "></asp:Label>
    <asp:TextBox ID="txtMetrosCuadrados" runat="server" ClientIDMode="Static"></asp:TextBox>

    <asp:Label ID="label8" runat="server" Text="Tipo Vehículo: "></asp:Label>
    <asp:ListBox ID="lbTipoVehiculo" runat="server" ClientIDMode="Static">
        <asp:ListItem Value="0">Seleccione:</asp:ListItem>
        <asp:ListItem Value="1">Auto</asp:ListItem>
        <asp:ListItem Value="2">Pickup</asp:ListItem>
        <asp:ListItem Value="3">Camion</asp:ListItem>
        <asp:ListItem Value="4">Moto</asp:ListItem>
    </asp:ListBox>

    <asp:Label ID="label9" runat="server" Text="Precio por Hora: "></asp:Label>
    <asp:TextBox ID="txtPrecioHora" runat="server" ClientIDMode="Static"></asp:TextBox>

    <asp:Label ID="label10" runat="server" Text="Foto: "></asp:Label>
    <asp:FileUpload ID="fuFoto" runat="server" ClientIDMode="Static" />

    <asp:Button ID="btnCrearCochera" runat="server" Text="Crear Cochera" ClientIDMode="Static"/>--%>

    <asp:HiddenField ID="esEdicion" runat="server" />

    <div class="row">
        <div class="col s12 m10 offset-m1">
            <div class="z-depth-4 card-panel">

                <div class="row">
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label1" runat="server" Text="Ubicación: "></asp:Label>
                        <asp:TextBox ID="txtUbicacion" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtUbicacion" runat="server" ControlToValidate="txtUbicacion" ErrorMessage="Debe ingresar la Ubicacion" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <div class=" col s12 m12 center-align input-field">
                        <asp:Label ID="label2" runat="server" Text="Período Disponible: "></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label3" runat="server" Text="Fecha Inicio: "></asp:Label>
                        <asp:TextBox ID="txtFechaInicio" CausesValidation="True" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFechaInicio" runat="server" ControlToValidate="txtFechaInicio" ErrorMessage="Debe ingresar la fecha de inicio" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revFInicio" runat="server" ControlToValidate="txtFechaInicio" ErrorMessage="Fecha de Inicio Invalida (Ingrese dd/mm/aaaa)" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$">*</asp:RegularExpressionValidator>
                    </div>
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label4" runat="server" Text="Fecha Fin: "></asp:Label>
                        <asp:TextBox ID="txtFechaFin" CausesValidation="True" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtFechaFin" runat="server" ControlToValidate="txtFechaFin" ErrorMessage="Debe ingresar la fecha de fin" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revFechaFin" runat="server" ControlToValidate="txtFechaFin" ErrorMessage="Fecha de Fin Invalida (Ingrese dd/mm/aaaa)" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$">*</asp:RegularExpressionValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtFechaFin" ControlToValidate="txtFechaInicio" ErrorMessage="La Fecha de Inicio no puede superar la de Fin" ForeColor="Red" Type="Date" Operator="LessThan">*</asp:CompareValidator>
                    </div>
                </div>

                <div class="row">
                    <div class=" col s12 m12 center-align input-field">
                        <asp:Label ID="label5" runat="server" Text="Horario Diario Disponible: "></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label6" runat="server" Text="Horario Inicio: "></asp:Label>
                        <asp:TextBox ID="txtHorarioInicio" runat="server" ClientIDMode="Static" MaxLength="5"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtHorarioInicio" runat="server" ControlToValidate="txtHorarioInicio" ErrorMessage="Debe ingresar la hora de inicio" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revHoraInicio" runat="server" ControlToValidate="txtHorarioInicio" ErrorMessage="Formato de Hora invalido (hh:mm) en formato 24hs" ForeColor="Red" ValidationExpression="^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$">*</asp:RegularExpressionValidator>
                    </div>
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label7" runat="server" Text="Horario Fin: "></asp:Label>
                        <asp:TextBox ID="txtHorarioFin" runat="server" ClientIDMode="Static" MaxLength="5"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtHorarioFin" runat="server" ControlToValidate="txtHorarioFin" ErrorMessage="Debe ingresar la hora de fin" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvHorario" runat="server" ControlToCompare="txtHorarioFin" ControlToValidate="txtHorarioInicio" ErrorMessage="El horario de Inicio no puede superar el de Fin" ForeColor="Red" Operator="LessThan">*</asp:CompareValidator>
                        <asp:RegularExpressionValidator ID="revHoraFin" runat="server" ControlToValidate="txtHorarioFin" ErrorMessage="Formato de Hora invalido (hh:mm) en formato 24hs" ForeColor="Red" ValidationExpression="^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$">*</asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="row">
                    <div class=" col s12 m12 center-align input-field">
                        <%--      <textarea id="txtDescripcion" class="materialize-textarea"></textarea>
                        <label for="txtDescripcion">Descripción: </label>--%>
                        <asp:Label ID="label8" runat="server" Text="Descripción: "></asp:Label>
                        <asp:TextBox ID="txtDescripcion" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtDescripcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="Debe ingresar la descripcion" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                </div>



                <div class="row">
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label10" runat="server" Text="Latitud: "></asp:Label>
                        <asp:TextBox ID="txtLatitud" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtLatitud" runat="server" ControlToValidate="txtLatitud" ErrorMessage="Debe ingresar la latitud" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator ID="revLatitud" runat="server" ControlToValidate="txtLatitud" ErrorMessage="Debe ingresar un valor decimal para la latitud" ForeColor="Red" ValidationExpression="^[0-9]\d{0,9}(\.\d{1,3})?%?$">*</asp:RegularExpressionValidator>--%>
                        <asp:RegularExpressionValidator ID="revLatitud" runat="server" ControlToValidate="txtLatitud"
                            ErrorMessage="Debe Ingresar solo Numeros de hasta 3 enteros y 4 decimales separados por un punto para la Latitud"
                            ValidationExpression="(^([0-9]{1,3}(\.|\,)[0-9]{1,4})$)|(^([0-9]{0,3})$)" ForeColor="Red">*</asp:RegularExpressionValidator>
                    </div>
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label11" runat="server" Text="Longitud: "></asp:Label>
                        <asp:TextBox ID="txtLongitud" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtLongitud" runat="server" ControlToValidate="txtLongitud" ErrorMessage="Debe ingresar la longitud" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator ID="revLongitud" runat="server" ControlToValidate="txtLongitud" ErrorMessage="Debe ingresar un valor decimal para la longitud" ForeColor="Red" ValidationExpression="^[0-9]\d{0,9}(\.\d{1,3})?%?$">*</asp:RegularExpressionValidator>--%>
                        <asp:RegularExpressionValidator ID="revLongitud" runat="server" ControlToValidate="txtLongitud"
                            ErrorMessage="Debe Ingresar solo Numeros de hasta 3 enteros y 4 decimales separados por un punto para la Longitud"
                            ValidationExpression="(^([0-9]{1,3}(\.|\,)[0-9]{1,4})$)|(^([0-9]{0,3})$)" ForeColor="Red">*</asp:RegularExpressionValidator>
                    </div>
                </div>

<%--                <div class="row">
                    <div class="col s12 m6">--%>
                        <%-- <div class=" col s12 m12 input-field">--%>
                        <asp:Label ID="label19" runat="server" Text="Tipo Vehículo: "></asp:Label>
                        <asp:ListBox ID="lbTipoVehiculo" runat="server" SelectionMode="Multiple" ClientIDMode="Static">
                            <asp:ListItem Value="0" Enabled="false">Seleccione:</asp:ListItem>
                            <asp:ListItem Value="1">Auto</asp:ListItem>
                            <asp:ListItem Value="2">Pickup</asp:ListItem>
                            <asp:ListItem Value="3">Camion</asp:ListItem>
                            <asp:ListItem Value="4">Moto</asp:ListItem>
                        </asp:ListBox>
<%--                    </div>--%>


                    <%--<div class=" col s12 m12 input-field">
                        <p>
                            <asp:Label ID="label14" runat="server" Text="Tipo Vehículo: "></asp:Label>
                        </p>
                        <p>
                            <input type="checkbox" id="chk1" />
                            <label for="chk1">Auto</label>
                        </p>
                        <p>
                            <input type="checkbox" id="chk2" />
                            <label for="chk2">Pickup</label>
                        </p>
                        <p>
                            <input type="checkbox" id="chk3" />
                            <label for="chk3">Camion</label>
                        </p>
                        <p>
                            <input type="checkbox" id="chk4" />
                            <label for="chk4">Moto</label>
                        </p>
                    </div>--%>


<%--                </div>--%>



                <div class="row">
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label13" runat="server" Text="Metros Cuadrados: "></asp:Label>
                        <asp:TextBox ID="txtMetrosCuadrados" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtMetrosCuadrados" runat="server" ControlToValidate="txtMetrosCuadrados" ErrorMessage="Debe ingresar los metros cuadrados" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revMetrosCuadrados" runat="server" ControlToValidate="txtMetrosCuadrados" ErrorMessage="Debe ingresar un valor entero para los metros cuadrados" ForeColor="Red" ValidationExpression="^[0-9]+$">*</asp:RegularExpressionValidator>
                        <asp:RangeValidator ID="rvMetrosCuadrados" runat="server" ControlToValidate="txtMetrosCuadrados" ErrorMessage="Los&nbsp;metros&nbsp;cuadrados&nbsp;no&nbsp;deben&nbsp;ser&nbsp;menores&nbsp;a&nbsp;5" ForeColor="Red" MaximumValue="99999" MinimumValue="5" Type="Integer">*</asp:RangeValidator>
                    </div>
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label9" runat="server" Text="Precio por Hora: "></asp:Label>
                        <asp:TextBox ID="txtPrecioHora" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtPrecioHora" runat="server" ControlToValidate="txtPrecioHora" ErrorMessage="Debe ingresar el precio por hora" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator ID="revPrecioHora" runat="server" ControlToValidate="txtPrecioHora" ErrorMessage="Debe ingresar un valor decimal para el precio por hora" ForeColor="Red" ValidationExpression="^[0-9]\d{0,9}(\.\d{1,3})?%?$">*</asp:RegularExpressionValidator>--%>
                        <asp:RangeValidator ID="rvPrecioHora" runat="server" ControlToValidate="txtPrecioHora" ErrorMessage="El&nbsp;precio&nbsp;de&nbsp;la&nbsp;cochera&nbsp;debe&nbsp;ser&nbsp;mayor&nbsp;a&nbsp;0&nbsp;(cero)." ForeColor="Red" MaximumValue="99999" MinimumValue="1">*</asp:RangeValidator>
                        <asp:RegularExpressionValidator ID="revPrecioHora" runat="server" ControlToValidate="txtPrecioHora"
                            ErrorMessage="Debe Ingresar solo Numeros de hasta 3 enteros y 4 decimales separados por un punto para el Precio"
                            ValidationExpression="(^([0-9]{1,3}(\.|\,)[0-9]{1,4})$)|(^([0-9]{0,3})$)" ForeColor="Red">*</asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row">
                    <div class=" col s12 m6 input-field">
                        <asp:Label ID="label12" runat="server" Text="Foto: "></asp:Label>
                        <asp:FileUpload ID="fuFoto" runat="server" ClientIDMode="Static" onchange="showimagepreview(this)" />
                        <asp:RequiredFieldValidator ID="rfvfuFoto" runat="server" ControlToValidate="fuFoto" ErrorMessage="Debe cargar la foto de la cochera" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                    <div class=" col s12 m6 input-field">
                        <asp:Image ID="imgFoto" runat="server" Height="200px" Width="200px" />
                    </div>
                </div>
                <div class="row">
                    <div class=" col s12 m12 center-align input-field">
                        <asp:Button ID="btnCrearCochera" runat="server" Text="Crear Cochera" ClientIDMode="Static" Class="btn cyan waves-effect waves-light" OnClick="btnCrearCochera_Click" />
                        <%--OnClientClick="showDiv('wnOk','Cochera Alta', 'Operacion Exitosa')"--%>
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

    <div id="wnOk" style="display: none" class="modal offset-m1">
        <div class="row">
            <asp:Label ID="lblMensaje" name="lblMensaje" runat="server" Text=""></asp:Label>
        </div>
        <div class="row">
            <div class=" col s12 m12 center-align input-field">
                <asp:Button ID="btnOK" runat="server" Text="Aceptar" ClientIDMode="Static" Class="btn cyan waves-effect waves-light" />
            </div>
        </div>
    </div>
</asp:Content>
