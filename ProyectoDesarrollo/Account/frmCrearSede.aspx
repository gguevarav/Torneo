<%@ Page Title="Sedes (Estadios)" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="frmCrearSede.aspx.vb" Inherits="RegistrarSede" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <h4>Registrar una nueva Sede.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtNombreSede" CssClass="col-md-2 control-label">Nombre de la sede</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtNombreSede" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombreSede"
                    CssClass="text-danger" ErrorMessage="El campo nombre es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtUbicacion" CssClass="col-md-2 control-label">Ubicación de la Sede</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtUbicacion" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUbicacion"
                    CssClass="text-danger" ErrorMessage="El campo ubicación de la sede es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtCapacidad" CssClass="col-md-2 control-label">Capacidad de la Sede</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCapacidad" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCapacidad"
                    CssClass="text-danger" ErrorMessage="El campo de la capacidad de la sede es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="RegistrarSede" Text="Registrar Sede" CssClass="btn btn-default" ID="btnRegistrarSede" />
            </div>
        </div>
    </div>
</asp:Content>

