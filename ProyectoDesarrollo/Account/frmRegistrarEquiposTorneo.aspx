 <%@ Page Title="Registrar equipos en Torneo" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="frmRegistrarEquiposTorneo.aspx.vb" Inherits="CrearEquipo" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <h4>Registro de equipos en torneos.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cbxTorneo" CssClass="col-md-2 control-label">Nombre del Torneo</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="cbxTorneo" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="cbxTorneo"
                    CssClass="text-danger" ErrorMessage="El campo del Nombre del Torneo es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cbxEquipo" CssClass="col-md-2 control-label">Escoja un equipo</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="cbxEquipo" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="cbxEquipo"
                    CssClass="text-danger" ErrorMessage="El campo del Nombre del equipo es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="Agregar" Text="Agregar" CssClass="btn btn-default" ID="btnAgregar" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="gridListaEquipos" CssClass="col-md-2 control-label">Nombre del Torneo</asp:Label>
            <div class="col-md-10">
                <asp:GridView ID="gridListaEquipos" CssClass="form-control" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
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
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="RegistrarEquipos" Text="Registrar Equipos" CssClass="btn btn-default" ID="btnRegistrarEquipos" />
            </div>
        </div>
    </div>
</asp:Content>

