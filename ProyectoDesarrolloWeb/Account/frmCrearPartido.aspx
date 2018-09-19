 <%@ Page Title="Partido" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="frmCrearPartido.aspx.vb" Inherits="CrearPartido" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.Bootstrap" tagprefix="dx" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Crear un Nuevo Partido.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="CalFechaPartido" CssClass="col-md-2 control-label">Fecha partido</asp:Label>
            <div class="col-md-10">
                <asp:Calendar ID="CalFechaPartido" runat="server" CssClass="form-control" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" SelectedDate="09/17/2018 21:27:04" VisibleDate="2018-09-17">
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
            <asp:Label runat="server" AssociatedControlID="tmrHoraPartido" CssClass="col-md-2 control-label">Hora del partido</asp:Label>
            <div class="col-md-10">
                <asp:Calendar ID="tmrHoraPartido" runat="server" CssClass="form-control" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" BorderStyle="Outset" Caption="Seleccione la hora del partido" SelectedDate="09/17/2018 21:26:46" VisibleDate="2018-09-17">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
                &nbsp;</div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cbxSede" CssClass="col-md-2 control-label">Sede e que se llevará a cabo el partido</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="cbxSede" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="cbxSede"
                    CssClass="text-danger" ErrorMessage="El campo de la sede es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cbxEquipoLocal" CssClass="col-md-2 control-label">Equipo Local</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="cbxEquipoLocal" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="cbxEquipoLocal"
                    CssClass="text-danger" ErrorMessage="El campo del equipo local es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cbxEquipoVisitante" CssClass="col-md-2 control-label">Equipo Visitante</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="cbxEquipoVisitante" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="cbxEquipoVisitante"
                    CssClass="text-danger" ErrorMessage="El campo del equipo visitante es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CrearPartido" Text="Crear Partido" CssClass="btn btn-default" ID="btnCrearPartido" />
            </div>
        </div>
    </div>
</asp:Content>