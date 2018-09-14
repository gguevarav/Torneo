Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports System
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports Npgsql
Imports System.Diagnostics

Partial Public Class RegistrarSede
    Inherits Page
    ' Creación e instancia del Objeto para la conexión
    Dim Conexion As New Conexion()
    ' Creación e instancia del objeto de Consultas
    Dim Consult As New Consulta()
    Protected Sub RegistrarSede()
        ' Variables para uso en parámetros
        ' Información de la Sede
        Dim ValoresInsertarSede As String
        ValoresInsertarSede = "'" & txtNombreSede.Text & "', '" & txtUbicacion.Text & "', '" & txtCapacidad.Text & "'"
        ' Tabla y campos a utilizarse
        Dim Tabla As String = "Sede"
        Dim Campos As String = "Nombre, Ubicacion, Capacidad"
        Try
            Consult.InsertarDatos(Tabla, Conexion.ConexionBaseDatosPostgres(), Campos, ValoresInsertarSede)
        Catch ex As Exception
            Debug.Write(ex)
        End Try
    End Sub
End Class
