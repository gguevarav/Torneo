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
    Dim Consult As New clsConsultas()
    ' Correlativo de la tabla
    Dim Correlativo As Integer = 1
    Protected Sub Page_Load()
        Dim TablaTorneo As String = "Torneo"
        Dim TablaEquipo As String = "Equipo"
        Dim Campos As String = "*"
        Dim DatosTorneo As NpgsqlDataReader
        Dim DatosEquipo As NpgsqlDataReader
        Try
            DatosTorneo = Consult.SentenciaSelectSinCondiciones(TablaTorneo, Campos)
            DatosEquipo = Consult.SentenciaSelectSinCondiciones(TablaEquipo, Campos)
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
    End Sub
    Protected Sub RegistrarEquipos()
        ' Variables para uso en parámetros
        ' Información del Equipo
        'Dim ValoresInsertarEquipo As String
        'ValoresInsertarEquipo = "" & cbxSede.SelectedValue.ToString & ", '" & txtNombreEquipo.Text & "', " & cbxTecnico.SelectedValue.ToString & ""
        ' Tabla y campos a utilizarse
        'Dim Tabla As String = "Equipo"
        'Dim Campos As String = "idSede, Nombre, idTecnico"
        'Try
        'Consult.InsertarDatos(Tabla, Conexion.ConexionBaseDatosPostgres(), Campos, ValoresInsertarEquipo)
        'Catch ex As Exception
        ' Debug.Write(ex)
        'End Try
    End Sub
    Protected Sub Agregar()
        Dim DT As New DataTable()
        ' Agregamos las columnas
        DT.Columns.Add("No.")
        DT.Columns.Add("Código")
        DT.Columns.Add("Nombre Equipo")

        ' AgregarDatos
        Dim Row As DataRow = DT.NewRow()
        Row("No.") = Correlativo
        Row("Código") = cbxEquipo.SelectedValue
        Row("Nombre Equipo") = cbxEquipo.SelectedItem.ToString
        DT.Rows.Add(Row)
        ' Enlazar el DataTable a datagridview
        gridListaEquipos.DataSource = DT
        gridListaEquipos.DataBind()
    End Sub
End Class
