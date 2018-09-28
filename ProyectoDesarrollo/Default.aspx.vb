
Partial Class _Default
    Inherits Page
    ' Instanciamos la clase
    Dim Consulta As New clsConsultas()
    Private Sub Page_Load()
        chartMaximosGoleadores.DataSource = Consulta.Top10Historico()
        chartMaximosGoleadores.Series("Series1").XValueMember = "Nombre"
        chartMaximosGoleadores.Series("Series1").YValueMembers = "Cantidad"
        'chartMaximosGoleadores.Series(0).ChartType = SeriesChartType.Pie
        chartMaximosGoleadores.Series("Series1").Palette = System.Web.UI.DataVisualization.Charting.ChartColorPalette.Pastel
        chartMaximosGoleadores.DataBind()
    End Sub
End Class