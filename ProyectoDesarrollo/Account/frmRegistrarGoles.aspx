 <%@ Page Title="Finalización de partido" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="frmRegistrarGoles.aspx.vb" Inherits="RegistrarGoles" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

        <h4>Registro de goles</h4>

    <div class="row">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cbxPartidos" CssClass="col-md-2 control-label">Escoja un partido a agregarle los resultados</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="cbxPartidos" runat="server" CssClass="form-control" AutoPostBack="True">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="cbxPartidos"
                    CssClass="text-danger" ErrorMessage="Debe escoger un partido." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cbxJugador" CssClass="col-md-2 control-label">Escoja un jugador</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="cbxJugador" runat="server" CssClass="form-control" AutoPostBack="True">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="cbxJugador"
                    CssClass="text-danger" ErrorMessage="Debe escoger un jugador" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cbxEquipo" CssClass="col-md-2 control-label">Escoja un equipo</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="cbxEquipo" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="cbxEquipo"
                    CssClass="text-danger" ErrorMessage="Escoja el equipo al que pertenece" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtMinuto" CssClass="col-md-2 control-label">Ingrese el minuto en que ocurrió la amonestación</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtMinuto" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMinuto"
                    CssClass="text-danger" ErrorMessage="El minuto en que ocurrió la amonestación es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="Agregar" Text="Agregar" CssClass="btn btn-default" ID="btnAgregar" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="gridListadoGoles" CssClass="col-md-2 control-label">Listado de amonestaciones</asp:Label>
            <div class="col-md-10">
                <asp:GridView ID="gridListadoGoles" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                <asp:Button runat="server" OnClick="FinalizarPartido" Text="Finalizar partido" CssClass="btn btn-default" ID="btnFinalizarPartido" />
            </div>
        </div>
    </div>
</asp:Content>

