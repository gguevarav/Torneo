Imports Microsoft.VisualBasic
Imports Npgsql
Imports System.Diagnostics

Public Class Conexion
    Public Function ConexionBaseDatosPostgres() As NpgsqlConnection
        ' Variables
        'Dim Mensaje As String
        Dim configuracion As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("BDTorneo_PruebaConnectionString")
        Dim MiConeccion As NpgsqlConnection = New NpgsqlConnection With {
            .ConnectionString = configuracion.ConnectionString
        }
        ' Intentamos realizar la conexión a la base de datos
        Try
            MiConeccion.Open()
        Catch ex As Exception
            Dim Mensaje As String = "Falló debido AddressOf: " & ex.ToString
            Debug.Write(Mensaje)
            MiConeccion.Close()
        End Try
        Return MiConeccion
    End Function
End Class
