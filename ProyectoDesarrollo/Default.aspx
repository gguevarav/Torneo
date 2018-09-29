<%@ Page Title="Página principal" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Torneo</h1>
        <p class="lead">Sistema para gestión de torneos de fútbol.</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Máximos Goleadores</h2>
            <p>
                <asp:Chart ID="chartMaximosGoleadores" runat="server">
                    <Legends>
                        <asp:Legend Alignment="Near" Docking="Bottom" IsTextAutoFit="False" LegendStyle="Table" Name="Default" />       
                    </Legends>
                    <series>
                        <asp:Series Name="Series1" ChartType="Pie"  Label="#VAL{N}" LabelToolTip="#VALX" LegendText="#VALX" LegendToolTip="#VAL{N}">
                        </asp:Series>
                    </series>
                    <chartareas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </chartareas>
                </asp:Chart>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Porteros Menos Vencidos</h2>
            <p>
                <asp:Chart ID="chartPorterosMenosVencidos" runat="server">
                    <Legends>
                        <asp:Legend Alignment="Near" Docking="Bottom" IsTextAutoFit="False" LegendStyle="Table" Name="Default" />       
                    </Legends>
                    <series>
                        <asp:Series Name="Series1" ChartType="Pie"  Label="#VAL{N}" LabelToolTip="#VALX" LegendText="#VALX" LegendToolTip="#VAL{N}">
                        </asp:Series>
                    </series>
                    <chartareas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </chartareas>
                </asp:Chart>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Jugadores menos amonestados</h2>
            <p>
                <asp:Chart ID="chartJugadorMenosAmonestados" runat="server">
                    <Legends>
                        <asp:Legend Alignment="Near" Docking="Bottom" IsTextAutoFit="False" LegendStyle="Table" Name="Default" />       
                    </Legends>
                    <series>
                        <asp:Series Name="Series1" ChartType="Pie"  Label="#VAL{N}" LabelToolTip="#VALX" LegendText="#VALX" LegendToolTip="#VAL{N}">
                        </asp:Series>
                    </series>
                    <chartareas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </chartareas>
                </asp:Chart>
            </p>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <h2>Equipos más goleadores</h2>
            <p>
                <asp:Chart ID="gridEquiposMasGoleadores" runat="server">
                    <Legends>
                        <asp:Legend Alignment="Near" Docking="Bottom" IsTextAutoFit="False" LegendStyle="Table" Name="Default" />       
                    </Legends>
                    <series>
                        <asp:Series Name="Series1" ChartType="Pie"  Label="#VAL{N}" LabelToolTip="#VALX" LegendText="#VALX" LegendToolTip="#VAL{N}">
                        </asp:Series>
                    </series>
                    <chartareas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </chartareas>
                </asp:Chart>
            </p>
        </div>
    </div>
</asp:Content>
