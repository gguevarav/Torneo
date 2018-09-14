Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports System
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports Npgsql
Imports System.Diagnostics

Partial Public Class CrearEquipo
    Inherits Page
    ' Creación e instancia del Objeto para la conexión
    Dim Conexion As New Conexion()
    ' Creación e instancia del objeto de Consultas
    Dim Consult As New Consulta()
    Protected Sub Page_Load()
        ' Cuando carga la página debe mostrar los datos en los ComboBox
        Dim Consult As New Consulta()
        Dim TablaTecnico As String = "Tecnico"
        Dim TablaSede As String = "Sede"
        Dim Campos As String = "*"
        Dim DatosTecnico As NpgsqlDataReader
        Dim DatosSede As NpgsqlDataReader
        Try
            DatosTecnico = Consult.SentenciaSelectSinCondiciones(TablaTecnico, Campos, Conexion.ConexionBaseDatosPostgres)
            DatosSede = Consult.SentenciaSelectSinCondiciones(TablaSede, Campos, Conexion.ConexionBaseDatosPostgres)
        Catch ex As Exception
            Debug.Write(ex)
        End Try
        ' Agregamos los técnicos leídos
        While DatosTecnico.Read
            Dim Item As ListItem = New ListItem()
            Item.Text = Consult.ObtenerNombrePersona(DatosTecnico("idPersona"), Conexion.ConexionBaseDatosPostgres)
            Item.Value = DatosTecnico("idTecnico")
            cbxTecnico.Items.Add(Item)
        End While
        While DatosSede.Read
            Dim Item As ListItem = New ListItem()
            Item.Text = DatosSede("Nombre")
            Item.Value = DatosSede("idSede")
            cbxSede.Items.Add(Item)
        End While
    End Sub
    Protected Sub CrearEquipo()
        ' Variables para uso en parámetros
        ' Información del Equipo
        Dim ValoresInsertarEquipo As String
        ValoresInsertarEquipo = "" & cbxSede.SelectedValue.ToString & ", '" & txtNombreEquipo.Text & "', " & cbxTecnico.SelectedValue.ToString & ""
        ' Tabla y campos a utilizarse
        Dim Tabla As String = "Equipo"
        Dim Campos As String = "idSede, Nombre, idTecnico"
        Try
            Consult.InsertarDatos(Tabla, Conexion.ConexionBaseDatosPostgres(), Campos, ValoresInsertarEquipo)
        Catch ex As Exception
            Debug.Write(ex)
        End Try
    End Sub
End Class
