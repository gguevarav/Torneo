Imports Microsoft.VisualBasic
Imports Npgsql
Imports System.Data
Imports System.Data.Common.DbDataAdapter
Imports System.Diagnostics

Public Class clsConsultas
    ' Creamos el objeto tipo conexión para almacenar el método de conexión de la clase clsConexion
    Dim ConexionBaseDatos As NpgsqlConnection = New clsConexion().ConexionBaseDatosPostgres()
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Function ObtenerNombrePersona(idPersona As String) As String
        ' Objetos a utilizar
        Dim Consulta As String
        Dim Comando As NpgsqlCommand = New NpgsqlCommand()
        Dim LectorDatos As NpgsqlDataReader
        Dim NombreCompletoPersona As String
        ' Se le pasa la conexion al comando
        Comando.Connection = ConexionBaseDatos
        ' Le Pasamos la sentencia a la variable consulta
        Consulta = "SELECT Nombr, Apellido From  Persona WHERE idPersona=" & idPersona & ";"
        ' Le pasamos la consulta al comando
        Comando.CommandText = Consulta
        'Debug.Write(Consulta)
        ' Ejecutamos el comando
        LectorDatos = Comando.ExecuteReader()
        While LectorDatos.Read
            NombreCompletoPersona = LectorDatos(0) & " " & LectorDatos(1)
        End While
        ' Devolvemos el DataReader
        Return NombreCompletoPersona
    End Function
    ' Realizar Selects
    Public Function SentenciaSelectConCondiciones(Tabla As String, CamposDevolver As String, Restricciones As String) As NpgsqlDataReader
        ' Objetos a utilizar
        Dim Consulta As String
        Dim Comando As NpgsqlCommand = New NpgsqlCommand()
        Dim LectorDatos As NpgsqlDataReader
        ' Se le pasa la conexion al comando
        Comando.Connection = ConexionBaseDatos
        ' Le Pasamos la sentencia a la variable consulta
        Consulta = "SELECT " & CamposDevolver & " From " & Tabla & " WHERE " & Restricciones & ";"
        ' Le pasamos la consulta al comando
        Comando.CommandText = Consulta
        'Debug.Write(Consulta)
        ' Ejecutamos el comando
        LectorDatos = Comando.ExecuteReader()
        ' Devolvemos el DataReader
        Return LectorDatos
    End Function
    ' Realizar Selects
    Public Function SentenciaSelectSinCondiciones(Tabla As String, CamposDevolver As String) As NpgsqlDataReader
        ' Objetos a utilizar
        Dim Consulta As String
        Dim Comando As NpgsqlCommand = New NpgsqlCommand()
        Dim LectorDatos As NpgsqlDataReader
        ' Se le pasa la conexion al comando
        Comando.Connection = ConexionBaseDatos
        ' Le Pasamos la sentencia a la variable consulta
        Consulta = "SELECT " & CamposDevolver & " From " & Tabla & ";"
        ' Le pasamos la consulta al comando
        Comando.CommandText = Consulta
        'Debug.Write(Consulta)
        ' Ejecutamos el comando
        LectorDatos = Comando.ExecuteReader()
        ' Devolvemos el DataReader
        Return LectorDatos
    End Function
    Public Function InsertarPersona(Valores As String) As Integer
        ' Método para insertar una persona, recibe la conexion, los valores a insertar y
        ' devuelve el id del valor que se insertó
        ' Objetos a utilizar
        Dim Consulta As String
        Dim Comando As NpgsqlCommand = New NpgsqlCommand()
        Dim LectorDatos As NpgsqlDataReader
        Dim ValoridPersona As Integer
        ' Pasamos la conexion al comando
        Comando.Connection = ConexionBaseDatos
        ' Creamos la consulta, insertamos los datos obtenedios del argumento Valores y retornamos el id de la persona insertada
        Consulta = "INSERT INTO Persona (Nombr, Apellido, FechaNacimiento, Genero, Nacionalidad, Residencia)" &
                                "Values (" & Valores & ") RETURNING idPersona;"
        ' Le pasamos la consulta al comando
        Comando.CommandText = Consulta
        ' Ejecutamos el comando
        LectorDatos = Comando.ExecuteReader()
        While LectorDatos.Read()
            ' Pasamos el valor devuelto a la variable
            ValoridPersona = Convert.ToInt32(LectorDatos(0))
        End While
        Return ValoridPersona
    End Function
    Public Sub InsertarJugador(Valores As String)
        ' Método para insertar un jugador, recibe la conexion, los valores a insertar y
        ' devuelve el id del valor que se insertó
        ' Objetos a utilizar
        Dim Consulta As String
        Dim Comando As NpgsqlCommand = New NpgsqlCommand()
        ' Pasamos la conexion al comando
        Comando.Connection = ConexionBaseDatos
        ' Creamos la consulta, insertamos los datos obtenedios del argumento Valores y retornamos el id de la persona insertada
        Consulta = "INSERT INTO Jugador (idPersona, idEquipo, Numero, FechaInicio, FechaFin, Estado)" &
                                "Values (" & Valores & ");"
        ' Le pasamos la consulta al comando
        Comando.CommandText = Consulta
        ' Ejecutamos el comando
        Try
            Comando.ExecuteNonQuery()
        Catch ex As Exception
            Debug.Write(ex)
        End Try
    End Sub
    Public Sub InsertarDatos(Tabla As String, Campos As String, Valores As String)
        ' Método para insertar datos, esté método es genérico solo necesita la tabla en la que necesita insertar
        ' los campos a insertar, los valores y la conexion a utilizar
        ' Objetos a utilizar
        Dim Consulta As String
        Dim Comando As NpgsqlCommand = New NpgsqlCommand()
        ' Pasamos la conexion al comando
        Comando.Connection = ConexionBaseDatos
        ' Creamos la consulta
        Consulta = "INSERT INTO " & Tabla & " (" & Campos & ") VALUES(" & Valores & ");"
        ' Le pasamos la consulta al comando
        Comando.CommandText = Consulta
        ' Ejecutamos el comando
        Try
            Comando.ExecuteNonQuery()
        Catch ex As Exception
            Debug.Write(ex)
        End Try
    End Sub
End Class
