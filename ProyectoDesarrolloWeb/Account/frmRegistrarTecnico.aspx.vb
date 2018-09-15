﻿Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports System
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports Npgsql
Imports System.Diagnostics

Partial Public Class RegistrarTecnico
    Inherits Page
    ' Creación e instancia del objeto de Consultas
    Dim Consult As New clsConsultas()
    Protected Sub RegistrarTecnico()
        ' Variables para uso en parámetros
        ' Información de la persona
        Dim ValoresInsertarPersona As String
        ValoresInsertarPersona = "'" & txtNombreTecnico.Text & "', '" & txtApellidoTecnico.Text & "', '" & calFechaNacimiento.SelectedDate.ToString & "', '" &
            cbxGenero.SelectedValue & "', '" & cbxNacionalidad.SelectedValue & "', '" & txtResidencia.Text & "'"
        ' Información del jugador
        Dim idPersona As Integer = Consult.InsertarPersona(ValoresInsertarPersona)
        ' Almacenamos los valores que se le enviarán al Tecnico
        Dim ValoresInsertarTecnico As String = idPersona.ToString & ", '" & cbxEstado.SelectedValue & "'"
        Dim Tabla As String = "Tecnico"
        Dim Campos As String = "idPersona, Estado"
        Try
            Consult.InsertarDatos(Tabla, Campos, ValoresInsertarTecnico)
        Catch ex As Exception
            Debug.Write(ex)
        End Try
    End Sub
End Class
