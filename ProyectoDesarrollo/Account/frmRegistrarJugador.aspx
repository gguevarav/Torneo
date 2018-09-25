<%@ Page Title="Jugador" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="frmRegistrarJugador.aspx.vb" Inherits="RegistrarJugador" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <h4>Registrar un jugador.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtNombreJugador" CssClass="col-md-2 control-label">Nombre</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtNombreJugador" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombreJugador"
                    CssClass="text-danger" ErrorMessage="El campo nombre es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtApellidoJugador" CssClass="col-md-2 control-label">Apellido</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtApellidoJugador" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtApellidoJugador"
                    CssClass="text-danger" ErrorMessage="El campo apellido es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="calFechaNacimiento" CssClass="col-md-2 control-label">Fecha de Nacimiento</asp:Label>
            <div class="col-md-10">
                <asp:Calendar ID="calFechaNacimiento" runat="server" CssClass="form-control" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cbxGenero" CssClass="col-md-2 control-label">Género</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="cbxGenero" runat="server" CssClass="form-control">
                    <asp:ListItem Value="M">Masculino</asp:ListItem>
                    <asp:ListItem Value="F">Femenino</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="cbxGenero"
                    CssClass="text-danger" ErrorMessage="El campo género es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cbxNacionalidad" CssClass="col-md-2 control-label">Nacionalidad</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="cbxNacionalidad" runat="server" CssClass="form-control">
                    <asp:ListItem Value="Guatemalteca">Guatemalteca</asp:ListItem>
                    <asp:ListItem Value="Hondureña">Hondureña</asp:ListItem>
                    <asp:ListItem Value="Salvadoreña">Salvadoreña</asp:ListItem>
                    <asp:ListItem Value="Nicaragüense">Nicaragüense</asp:ListItem>
                    <asp:ListItem Value="Costaricense">Costaricense</asp:ListItem>
                    <asp:ListItem Value="Panameña">Panameña</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="cbxNacionalidad"
                    CssClass="text-danger" ErrorMessage="El campo nacionalidad es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtResidencia" CssClass="col-md-2 control-label">Residencia</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtResidencia" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtResidencia"
                    CssClass="text-danger" ErrorMessage="El campo residencia es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cbxEquipo" CssClass="col-md-2 control-label">Equipo</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="cbxEquipo" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="cbxEquipo"
                    CssClass="text-danger" ErrorMessage="El campo de equipo es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtNumeroJugador" CssClass="col-md-2 control-label">Numero del Jugador</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtNumeroJugador" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNumeroJugador"
                    CssClass="text-danger" ErrorMessage="El campo del numero es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="calFechaIncio" CssClass="col-md-2 control-label">Fecha de inicio</asp:Label>
            <div class="col-md-10">
                <asp:Calendar ID="calFechaIncio" runat="server" CssClass="form-control" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="calFechaFin" CssClass="col-md-2 control-label">Fecha de Finalización</asp:Label>
            <div class="col-md-10">
                <asp:Calendar ID="calFechaFin" runat="server" CssClass="form-control" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cbxEstado" CssClass="col-md-2 control-label">Estado</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="cbxEstado" runat="server" CssClass="form-control">
                    <asp:ListItem Value="Activo">Activo</asp:ListItem>
                    <asp:ListItem Value="Inactivo">Inactivo</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="cbxEstado"
                    CssClass="text-danger" ErrorMessage="El campo de estado del jugador es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="RegistrarJugador" Text="Registrar Jugador" CssClass="btn btn-default" ID="btnRegistrarJugador" />
            </div>
        </div>
    </div>
</asp:Content>

