Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports Microsoft.Owin.Security
Imports Npgsql
Imports System.Diagnostics

Partial Public Class RegistrarSede
    Inherits Page
    ' Creación e instancia del objeto de Consultas
    Dim Consulta As New clsConsultas()
    Protected Sub RegistrarSede()
        ' Variables para uso en parámetros
        ' Información de la Sede
        Dim ValoresInsertarSede As String
        ValoresInsertarSede = "'" & txtNombreSede.Text & "', '" & txtUbicacion.Text & "', '" & txtCapacidad.Text & "'"
        ' Tabla y campos a utilizarse
        Dim Tabla As String = "Sede"
        Dim Campos As String = "Nombre, Ubicacion, Capacidad"
        Try
            Consulta.InsertarDatos(Tabla, Campos, ValoresInsertarSede)
        Catch ex As Exception
            Debug.Write(ex)
        End Try
    End Sub
End Class