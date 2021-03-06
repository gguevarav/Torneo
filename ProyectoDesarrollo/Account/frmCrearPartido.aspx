﻿ <%@ Page Title="Partido" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="frmCrearPartido.aspx.vb" Inherits="CrearPartido" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <h4>Crear un Nuevo Partido.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cbxTorneo" CssClass="col-md-2 control-label">Seleccione el torneo</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="cbxTorneo" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="cbxTorneo"
                    CssClass="text-danger" ErrorMessage="El campo del torneo es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cbxSede" CssClass="col-md-2 control-label">Sede en que se llevará a cabo el partido</asp:Label>
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
            <asp:Label runat="server" AssociatedControlID="txtHoraPartido" CssClass="col-md-2 control-label">Hora del partido</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="txtHoraPartido" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtHoraPartido"
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

