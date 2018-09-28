Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports System
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports Npgsql
Imports System.Diagnostics
Imports System.Data

Partial Public Class RegistrarGoles
    Inherits Page
    ' Creación e instancia del objeto de Consultas
    Dim Consulta As New clsConsultas()
    ' Correlativo de la tabla
    Dim Correlativo As Integer = 1
    ' Creamos la tabla
    Dim Tabla As New DataTable()
    ' Creamos el objeto row
    Dim Row As DataRow
    Protected Sub Page_Load()
        If (cbxPartidos.SelectedValue.ToString = "") Then
            Dim TablaPartido As String = "Partido"
            Dim Campos As String = "*"
            Dim Restricciones As String = "Estado='Creado'"
            Dim DatosPartido As NpgsqlDataReader
            Try
                DatosPartido = Consulta.SentenciaSelectConCondiciones(TablaPartido, Campos, Restricciones)
            Catch ex As Exception
                Debug.Write(ex)
            End Try
            ' Primero limpiamos el combo box
            cbxPartidos.Items.Clear()
            ' Verificamos si no está vacío
            If DatosPartido.Read = True Then
                ' Agregamos los técnicos leídos
                While DatosPartido.Read
                    Dim Item As ListItem = New ListItem()
                    Item.Text = DatosPartido("Fecha") & " - " & Consulta.ObtenerNombreEquipo(DatosPartido("EquipoLocal")) & " - " & Consulta.ObtenerNombreEquipo(DatosPartido("EquipoVisitante"))
                    Item.Value = DatosPartido("idPartido")
                    cbxPartidos.Items.Add(Item)
                End While
            Else
                ' Agregamos el texto que muestra que no existe nada en la base de datos
                Dim Item As ListItem = New ListItem()
                Item.Text = "No existen partidos creados"
                Item.Value = 1
                cbxPartidos.Items.Add(Item)
            End If
            If (Page.IsPostBack = False) Then
                'Agregamos las comlumnas al datagrid
                Dim Tabla As New DataTable()
                'Agregamos las columnas
                Tabla.Columns.Add("No.")
                Tabla.Columns.Add("Codigo Jugador")
                Tabla.Columns.Add("Nombre Jugador")
                Tabla.Columns.Add("Codigo partido")
                Tabla.Columns.Add("Partido")
                Tabla.Columns.Add("Codigo equipo")
                Tabla.Columns.Add("Nombre equipo")
                Tabla.Columns.Add("Minuto")
                ' Creamo la variable en la sesión
                Session("TablaAmonestaciones") = Tabla
            End If
        End If
    End Sub
    Protected Sub FinalizarPartido()
        'Para insertar los datos debemos leer todas las filas de la tabla
        For i As Integer = 0 To gridListadoGoles.Rows.Count - 1
            ' Variables para uso en parámetros
            ' Tabla y campos a utilizarse
            Dim TablaGol As String = "Gol"
            Dim TablaPartido As String = "Partido"
            Dim Campos As String = "idJugador, idPartido, idEquipo, minuto"
            ' Información del Amonestación
            Dim ValoresInsertarAmonestacion As String
            ValoresInsertarAmonestacion = gridListadoGoles.Rows(i).Cells(1).Text.ToString & ", " & gridListadoGoles.Rows(i).Cells(3).Text.ToString & ", " & gridListadoGoles.Rows(i).Cells(5).Text.ToString & ", '" & gridListadoGoles.Rows(i).Cells(7).Text.ToString & "'"
            Dim ValoresPartido = "Estado='Finalizado'"
            Dim RestriccionesPartido = "idPartido=" & cbxPartidos.SelectedValue.ToString()
            Try
                Consulta.InsertarDatos(TablaGol, Campos, ValoresInsertarAmonestacion)
                Consulta.ActualizarDatos(TablaPartido, ValoresPartido, RestriccionesPartido)
            Catch ex As Exception
                Debug.Write(ex)
            End Try
        Next
    End Sub
    Protected Sub Agregar()
        Tabla = Session("TablaAmonestaciones")
        Row = Tabla.NewRow()
        Row("No.") = Correlativo.ToString()
        Row("Codigo jugador") = cbxJugador.SelectedValue.ToString()
        Row("Nombre Jugador") = cbxJugador.SelectedItem.ToString()
        Row("Codigo partido") = cbxPartidos.SelectedValue.ToString()
        Row("Partido") = cbxPartidos.SelectedItem.ToString()
        Row("Codigo equipo") = cbxEquipo.SelectedValue.ToString()
        Row("Nombre equipo") = cbxEquipo.SelectedItem.ToString()
        Row("Minuto") = txtMinuto.Text
        Tabla.Rows.Add(Row)
        gridListadoGoles.DataSource = Tabla
        gridListadoGoles.DataBind()
        Session("Tabla") = Tabla
        Correlativo += 1
    End Sub
    Private Sub cbxPartidos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPartidos.SelectedIndexChanged
        Dim TablaPartido As String = "Partido"
        Dim TablaJugador As String = "Jugador"
        Dim Campos As String = "*"
        Dim CamposDevolverPartido As String = "EquipoLocal, EquipoVisitante"
        Dim Restricciones As String = "idPartido=" & cbxPartidos.SelectedValue.ToString()
        Dim DatosPartido As NpgsqlDataReader
        Dim DatosJugador As NpgsqlDataReader
        Try
            DatosPartido = Consulta.SentenciaSelectConCondiciones(TablaPartido, CamposDevolverPartido, Restricciones)
        Catch ex As Exception
            Debug.Write(ex)
        End Try
        ' Primero limpiamos el combobox
        cbxJugador.Items.Clear()
        ' Agregamos los técnicos leídos
        While DatosPartido.Read
            Dim CamposDevolverJugador As String = "idPersona, idJugador"
            Dim RestriccionesDeEquipos As String = "idEquipo=" & DatosPartido("EquipoLocal") & " OR idEquipo=" & DatosPartido("EquipoVisitante")
            ' extraemos los datos de la tabla mientras cumpla con la retricciones que sea del equipo que está seleccionado en el combo box de arriba
            DatosJugador = Consulta.SentenciaSelectConCondiciones(TablaJugador, CamposDevolverJugador, RestriccionesDeEquipos)
            Try
                While DatosJugador.Read
                    Dim Item As ListItem = New ListItem()
                    Item.Text = Consulta.ObtenerNombrePersona(DatosJugador("idPersona"))
                    Item.Value = DatosJugador("idJugador")
                    cbxJugador.Items.Add(Item)
                End While
            Catch ex As Exception
                Debug.Write(ex)
            End Try
        End While
    End Sub
    Protected Sub cbxJugador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxJugador.SelectedIndexChanged
        Dim TablaJugador As String = "Jugador"
        Dim TablaEquipo As String = "Equipo"
        Dim Campos As String = "*"
        Dim CamposDevolverJugador As String = "idEquipo"
        Dim Restricciones As String = "idJugador=" & cbxJugador.SelectedValue.ToString()
        Dim DatosJugador As NpgsqlDataReader
        Dim DatosEquipo As NpgsqlDataReader
        Try
            DatosJugador = Consulta.SentenciaSelectConCondiciones(TablaJugador, CamposDevolverJugador, Restricciones)
        Catch ex As Exception
            Debug.Write(ex)
        End Try
        ' Primero limpiamos el combobox
        cbxEquipo.Items.Clear()
        ' Agregamos los técnicos leídos
        While DatosJugador.Read
            Dim CamposDevolverEquipo As String = "Nombre, idEquipo"
            Dim RestriccionesDeEquipos As String = "idEquipo=" & DatosJugador("idEquipo")
            ' extraemos los datos de la tabla mientras cumpla con la retricciones que sea del equipo que está seleccionado en el combo box de arriba
            DatosEquipo = Consulta.SentenciaSelectConCondiciones(TablaEquipo, CamposDevolverEquipo, RestriccionesDeEquipos)
            Try
                While DatosEquipo.Read
                    Dim Item As ListItem = New ListItem()
                    Item.Text = DatosEquipo("Nombre")
                    Item.Value = DatosEquipo("idEquipo")
                    cbxEquipo.Items.Add(Item)
                End While
            Catch ex As Exception
                Debug.Write(ex)
            End Try
        End While
    End Sub
End Class