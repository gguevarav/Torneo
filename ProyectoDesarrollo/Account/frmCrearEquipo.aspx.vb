Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports Microsoft.Owin.Security
Imports Npgsql
Imports System.Diagnostics

Partial Public Class CrearEquipo
    Inherits Page
    Dim Consulta As New clsConsultas()
    Protected Sub Page_Load()
        If (cbxSede.SelectedValue = "") Then
            Dim TablaTecnico As String = "Tecnico"
            Dim TablaSede As String = "Sede"
            Dim Campos As String = "*"
            Dim DatosTecnico As NpgsqlDataReader
            Dim DatosSede As NpgsqlDataReader
            Try
                DatosTecnico = Consulta.SentenciaSelectSinCondiciones(TablaTecnico, Campos)
                DatosSede = Consulta.SentenciaSelectSinCondiciones(TablaSede, Campos)
                ' Agregamos los técnicos leídos
                While DatosTecnico.Read
                    Dim Item As ListItem = New ListItem()
                    Item.Text = Consulta.ObtenerNombrePersona(DatosTecnico("idPersona"))
                    Item.Value = DatosTecnico("idTecnico")
                    cbxTecnico.Items.Add(Item)
                End While
                While DatosSede.Read
                    Dim Item As ListItem = New ListItem()
                    Item.Text = DatosSede("Nombre")
                    Item.Value = DatosSede("idSede")
                    cbxSede.Items.Add(Item)
                End While
            Catch ex As Exception
                Debug.Write(ex)
            End Try
        End If
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
            Consulta.InsertarDatos(Tabla, Campos, ValoresInsertarEquipo)
        Catch ex As Exception
            Debug.Write(ex)
        End Try
    End Sub
End Class
