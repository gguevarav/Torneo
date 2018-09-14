Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports System
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports Npgsql
Imports System.Diagnostics

Partial Public Class RegistrarArbitro
    Inherits Page
    ' Creación e instancia del Objeto para la conexión
    Dim Conexion As New Conexion()
    ' Creación e instancia del objeto de Consultas
    Dim Consult As New Consulta()
    ' Variables para uso en parámetros
    ' Información de la persona
    Dim ValoresInsertarPersona As String
        ValoresInsertarPersona = "'" & txtNombreArbitro.Text & "', '" & txtApellidoArbitro.Text & "', '" & calFechaNacimiento.SelectedDate.ToString & "', '" &
            cbxGenero.SelectedValue & "', '" & cbxNacionalidad.SelectedValue & "', '" & txtResidencia.Text & "'"
        ' Información del Arbitro
        Dim idPersona As Integer = Consult.InsertarPersona(Conexion.ConexionBaseDatosPostgres(), ValoresInsertarPersona)
        ' Almacenamos los valores que se le enviarán al Arbitro
        Dim ValoresInsertarTecnico As String = idPersona.ToString & ", '" & cbxEstado.SelectedValue & "'"
        Dim Tabla As String = "Arbitro"
        Dim Campos As String = "idPersona, Estado"
        Try
            Consult.InsertarDatos(Tabla, Conexion.ConexionBaseDatosPostgres(), Campos, ValoresInsertarTecnico)
        Catch ex As Exception
            Debug.Write(ex)
        End Try
    End Sub
End Class
