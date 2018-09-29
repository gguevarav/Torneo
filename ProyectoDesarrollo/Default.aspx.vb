Partial Class _Default
    Inherits Page
    ' Instanciamos la clase
    Dim Consulta As New clsConsultas()
    Private Sub Page_Load()
        CargarDatos()
    End Sub
    Public Sub CargarDatos()
        ' Máximos goleadores
        chartMaximosGoleadores.DataSource = Consulta.Top10Historico()
        chartMaximosGoleadores.Series("Series1").XValueMember = "Nombre"
        chartMaximosGoleadores.Series("Series1").YValueMembers = "Cantidad"
        chartMaximosGoleadores.Series("Series1").Palette = System.Web.UI.DataVisualization.Charting.ChartColorPalette.Pastel
        chartMaximosGoleadores.DataBind()
        ' Porteros menos vencidos
        chartPorterosMenosVencidos.DataSource = Consulta.Top10Historico()
        chartPorterosMenosVencidos.Series("Series1").XValueMember = "Nombre"
        chartPorterosMenosVencidos.Series("Series1").YValueMembers = "Cantidad"
        chartPorterosMenosVencidos.Series("Series1").Palette = System.Web.UI.DataVisualization.Charting.ChartColorPalette.Pastel
        chartPorterosMenosVencidos.DataBind()
        ' Jugadores menos amonestados
        chartJugadorMenosAmonestados.DataSource = Consulta.Top10MenosAmonestados()
        chartJugadorMenosAmonestados.Series("Series1").XValueMember = "Nombre"
        chartJugadorMenosAmonestados.Series("Series1").YValueMembers = "Cantidad"
        chartJugadorMenosAmonestados.Series("Series1").Palette = System.Web.UI.DataVisualization.Charting.ChartColorPalette.Pastel
        chartJugadorMenosAmonestados.DataBind()
        ' Top 10 de equipos mas goleadores por histórico
        gridEquiposMasGoleadores.DataSource = Consulta.Top10MasGoleadores()
        gridEquiposMasGoleadores.Series("Series1").XValueMember = "Nombre"
        gridEquiposMasGoleadores.Series("Series1").YValueMembers = "Cantidad"
        gridEquiposMasGoleadores.Series("Series1").Palette = System.Web.UI.DataVisualization.Charting.ChartColorPalette.Pastel
        gridEquiposMasGoleadores.DataBind()
    End Sub
End Class