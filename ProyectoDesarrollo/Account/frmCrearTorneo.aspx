<%@ Page Title="Torneos" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="frmCrearTorneo.aspx.vb" Inherits="CrearTorneo" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <h4>Crear un Nuevo Torneo.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtNombreTorneo" CssClass="col-md-2 control-label">Nombre del Torneo</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtNombreTorneo" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombreTorneo"
                    CssClass="text-danger" ErrorMessage="El campo nombre es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="CalFechaInicio" CssClass="col-md-2 control-label">Fecha de inicio del Torneo</asp:Label>
            <div class="col-md-10">
                <asp:Calendar ID="CalFechaInicio" runat="server" CssClass="form-control" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
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
            <asp:Label runat="server" AssociatedControlID="CalFechaFin" CssClass="col-md-2 control-label">Fecha de Finalización del Torneo</asp:Label>
            <div class="col-md-10">
                <asp:Calendar ID="CalFechaFin" runat="server" CssClass="form-control" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
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
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CrearTorneo" Text="Crear Torneo" CssClass="btn btn-default" ID="btnCrearTorneo" />
            </div>
        </div>
    </div>
</asp:Content>

