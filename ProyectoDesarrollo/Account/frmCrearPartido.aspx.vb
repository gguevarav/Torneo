﻿Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports Microsoft.Owin.Security
Imports Npgsql
Imports System.Diagnostics

Partial Public Class CrearPartido
    Inherits Page
    ' Creación e instancia del objeto de Consultas
    Dim Consulta As New clsConsultas()
    Protected Sub Page_Load()
        If (cbxSede.SelectedValue = "") Then
            Dim TablaSede As String = "Sede"
            Dim TablaEquipo As String = "equipo"
            Dim Campos As String = "*"
            Dim DatosSede As NpgsqlDataReader
            Dim DatosEquipo As NpgsqlDataReader
            Try
                DatosSede = Consulta.SentenciaSelectSinCondiciones(TablaSede, Campos)
                DatosEquipo = Consulta.SentenciaSelectSinCondiciones(TablaEquipo, Campos)
            Catch ex As Exception
                Debug.Write(ex)
            End Try
            ' Agregamos los técnicos leídos
            While DatosSede.Read
                Dim Item As ListItem = New ListItem()
                Item.Text = DatosSede("Nombre")
                Item.Value = DatosSede("idSede")
                cbxSede.Items.Add(Item)
            End While
            While DatosEquipo.Read
                Dim Item As ListItem = New ListItem()
                Item.Text = DatosEquipo("Nombre")
                Item.Value = DatosEquipo("idEquipo")
                cbxEquipoLocal.Items.Add(Item)
                cbxEquipoVisitante.Items.Add(Item)
            End While
        End If
    End Sub
    Protected Sub CrearPartido()
        ' Variables para uso en parámetros
        ' Información del Equipo
        Dim ValoresInsertarPartido As String = "'" & CalFechaPartido.SelectedDate.ToString & "', '" & tmrHoraPartido.SelectedDate.ToString & "', " & cbxSede.SelectedValue.ToString & ", " & cbxEquipoLocal.SelectedValue.ToString & ", " & cbxEquipoVisitante.SelectedValue.ToString
        ' Tabla y campos a utilizarse
        Dim Tabla As String = "Partido"
        Dim Campos As String = "Fecha, Hora, idSede, EquipoLocal, EquipoVisitante"
        Try
            Consulta.InsertarDatos(Tabla, Campos, ValoresInsertarPartido)
        Catch ex As Exception
            Debug.Write(ex)
        End Try
    End Sub
End Class