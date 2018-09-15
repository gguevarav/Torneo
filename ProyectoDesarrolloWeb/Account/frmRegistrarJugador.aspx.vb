Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports System
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports Npgsql
Imports System.Diagnostics

Partial Public Class RegistrarJugador
    Inherits Page
    ' Creación e instancia del objeto de Consultas
    Dim Consult As New clsConsultas()
    Protected Sub Page_Load()
        ' Cuando carga la página debe mostrar los datos en los ComboBox
        Dim TablaEquipo As String = "Equipo"
        Dim Campos As String = "*"
        Dim DatosEquipo As NpgsqlDataReader
        Try
            DatosEquipo = Consult.SentenciaSelectSinCondiciones(TablaEquipo, Campos)
        Catch ex As Exception
            Debug.Write(ex)
        End Try
        ' Agregamos los técnicos leídos
        While DatosEquipo.Read
            Dim Item As ListItem = New ListItem()
            Item.Text = DatosEquipo("Nombre")
            Item.Value = DatosEquipo("idEquipo")
            cbxEquipo.Items.Add(Item)
        End While
    End Sub
    ' Registrar un Jugador
    Protected Sub RegistrarJugador()
        ' Variables para uso en parámetros
        ' Información de la persona
        Dim ValoresInsertarPersona As String
        ValoresInsertarPersona = "'" & txtNombreJugador.Text & "', '" & txtApellidoJugador.Text & "', '" & calFechaNacimiento.SelectedDate.ToString & "', '" &
            cbxGenero.SelectedValue & "', '" & cbxNacionalidad.SelectedValue & "', '" & txtResidencia.Text & "'"
        ' Información del jugador
        Dim idPersona As Integer = Consult.InsertarPersona(ValoresInsertarPersona)
        ' Almacenamos los valores que se le enviarán al jugador
        Dim ValoresInsertarJugador As String
        ValoresInsertarJugador = idPersona.ToString & ", " & cbxEquipo.SelectedValue.ToString & ", " & txtNumeroJugador.Text & ", '" &
            calFechaIncio.SelectedDate.ToString & "', '" & calFechaFin.SelectedDate.ToString & "', '" & cbxEstado.SelectedValue & "'"
        Try
            Consult.InsertarJugador(ValoresInsertarJugador)
        Catch ex As Exception
            Debug.Write(ex)
        End Try
    End Sub
End Class
