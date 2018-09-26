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

Partial Public Class CrearEquipo
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
        If (cbxTorneo.SelectedValue.ToString = "") Then
            Dim TablaTorneo As String = "Torneo"
            Dim TablaEquipo As String = "Equipo"
            Dim Campos As String = "*"
            Dim DatosTorneo As NpgsqlDataReader
            Dim DatosEquipo As NpgsqlDataReader
            Try
                DatosTorneo = Consulta.SentenciaSelectSinCondiciones(TablaTorneo, Campos)
                DatosEquipo = Consulta.SentenciaSelectSinCondiciones(TablaEquipo, Campos)
            Catch ex As Exception
                Debug.Write(ex)
            End Try
            ' Agregamos los técnicos leídos
            While DatosTorneo.Read
                Dim Item As ListItem = New ListItem()
                Item.Text = DatosTorneo("Nombre")
                Item.Value = DatosTorneo("idTorneo")
                cbxTorneo.Items.Add(Item)
            End While
            While DatosEquipo.Read
                Dim Item As ListItem = New ListItem()
                Item.Text = DatosEquipo("Nombre")
                Item.Value = DatosEquipo("idEquipo")
                cbxEquipo.Items.Add(Item)
            End While
        End If
        If (Page.IsPostBack = False) Then
            'Agregamos las comlumnas al datagrid
            Dim Tabla As New DataTable()
            'Agregamos las columnas
            Tabla.Columns.Add("No.")
            Tabla.Columns.Add("Codigo Torneo")
            Tabla.Columns.Add("Nombre Torneo")
            Tabla.Columns.Add("Codigo Equipo")
            Tabla.Columns.Add("Nombre Equipo")
            ' Creamo la variable en la sesión
            Session("Tabla") = Tabla
        End If
    End Sub
    Protected Sub RegistrarEquipos()
        ' Para insertar los datos debemos leer todas las filas de la tabla
        For i As Integer = 0 To gridListaEquipos.Rows.Count - 1
            ' Variables para uso en parámetros
            ' Tabla y campos a utilizarse
            Dim Tabla As String = "torneoequipo"
            Dim Campos As String = "idtorneo, idequipo"
            ' Información del Equipo
            Dim ValoresInsertarEquipo As String
            ValoresInsertarEquipo = gridListaEquipos.Rows(i).Cells(1).Text.ToString & ", " & gridListaEquipos.Rows(i).Cells(3).Text.ToString
            Try
                Consulta.InsertarDatos(Tabla, Campos, ValoresInsertarEquipo)
            Catch ex As Exception
                Debug.Write(ex)
            End Try
        Next
    End Sub
    Protected Sub Agregar()
        Tabla = Session("Tabla")
        Row = Tabla.NewRow()
        Row("No.") = Correlativo.ToString()
        Row("Codigo Torneo") = cbxTorneo.SelectedValue.ToString()
        Row("Nombre Torneo") = cbxTorneo.SelectedItem.ToString()
        Row("Codigo Equipo") = cbxEquipo.SelectedValue.ToString()
        Row("Nombre Equipo") = cbxEquipo.SelectedItem.ToString()
        Tabla.Rows.Add(Row)
        gridListaEquipos.DataSource = Tabla
        gridListaEquipos.DataBind()
        Session("Tabla") = Tabla
    End Sub
End Class