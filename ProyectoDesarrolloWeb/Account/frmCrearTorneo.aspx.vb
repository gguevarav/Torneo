Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports System
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports Npgsql
Imports System.Diagnostics

Partial Public Class CrearTorneo
    Inherits Page
    ' Creación e instancia del Objeto para la conexión
    Dim Conexion As New Conexion()
    ' Creación e instancia del objeto de Consultas
    Dim Consult As New Consulta()
    Protected Sub CrearTorneo()
        ' Variables para uso en parámetros
        ' Información del Torneo
        Dim ValoresInsertarTorneo As String
        ValoresInsertarTorneo = "'" & txtNombreTorneo.Text & "', '" & CalFechaInicio.SelectedDate.ToString & "', '" & CalFechaFin.SelectedDate.ToString & "'"
        ' Tabla y campos a utilizarse
        Dim Tabla As String = "Torneo"
        Dim Campos As String = "Nombre, FechaInicio, FechaFin"
        Try
            Consult.InsertarDatos(Tabla, Conexion.ConexionBaseDatosPostgres(), Campos, ValoresInsertarTorneo)
        Catch ex As Exception
            Debug.Write(ex)
        End Try
    End Sub
End Class
