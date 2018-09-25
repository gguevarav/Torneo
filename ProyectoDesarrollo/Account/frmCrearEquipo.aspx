<%@ Page Title="Equipos" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="frmCrearEquipo.aspx.vb" Inherits="CrearEquipo" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <h4>Crear un Nuevo Equipo.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cbxSede" CssClass="col-md-2 control-label">Sede del equipo</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="cbxSede" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="cbxSede"
                    CssClass="text-danger" ErrorMessage="El campo de la sede del equipo es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtNombreEquipo" CssClass="col-md-2 control-label">Nombre del Equipo</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtNombreEquipo" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombreEquipo"
                    CssClass="text-danger" ErrorMessage="El campo nombre es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cbxTecnico" CssClass="col-md-2 control-label">Técnico del equipo</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="cbxTecnico" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="cbxTecnico"
                    CssClass="text-danger" ErrorMessage="El campo del técnico es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CrearEquipo" Text="Crear Equipo" CssClass="btn btn-default" ID="btnCrearEquipo" />
            </div>
        </div>
    </div>
</asp:Content>

