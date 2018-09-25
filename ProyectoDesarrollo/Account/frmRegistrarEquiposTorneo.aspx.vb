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
    Dim Consulta As New clsConsultas()
    ' Correlativo de la tabla
    Dim Correlativo As Integer = 1
    Protected Sub Page_Load()
        If (cbxTorneo.SelectedValue.ToString = "") Then
            Dim TablaTorneo As String = "Torneo"
            Dim TablaEquipo As String = "Equipo"
            Dim Campos As String = "*"
            Dim DatosTorneo As NpgsqlDataReader
            Dim DatosEquipo As NpgsqlDataReader
            Try
                DatosTorneo = Consulta.SentenciaSelectSinCondiciones(TablaTorneo, Campos)
                DatosEquipo = Consulta.SentenciaSelectSinCondiciones(TablaEquipo, Campos)
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
            'Agregamos las comlumnas al datagrid
            Dim DT As New DataTable()
            'Agregamos las columnas
            DT.Columns.Add("No.")
            DT.Columns.Add("Código")
            DT.Columns.Add("Nombre Equipo")
            gridListaEquipos.DataSource = DT
            gridListaEquipos.DataBind()
        End If
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
    End Sub
End Class