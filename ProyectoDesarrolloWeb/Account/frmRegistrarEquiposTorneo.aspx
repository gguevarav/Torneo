 <%@ Page Title="Registrar equipos en Torneo" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="frmRegistrarEquiposTorneo.aspx.vb" Inherits="CrearEquipo" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
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
                <asp:GridView ID="gridListaEquipos" CssClass="form-control" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
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