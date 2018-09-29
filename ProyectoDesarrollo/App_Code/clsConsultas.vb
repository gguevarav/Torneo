Imports Microsoft.VisualBasic
Imports Npgsql
Imports System.Data
Imports System.Data.Common.DbDataAdapter
Imports System.Diagnostics

Public Class clsConsultas
    Public Sub InsertarDatos(Tabla As String, Campos As String, Valores As String)
        ' Creamos el objeto tipo conexión para almacenar el método de conexión de la clase clsConexion
        Dim ConexionBaseDatos As NpgsqlConnection = New clsConexion().ConexionBaseDatosPostgres()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
        ' Cerramos la Conexion
        ' ConexionBaseDatos.Close()
    End Sub
    Public Sub InsertarJugador(Valores As String)
        ' Creamos el objeto tipo conexión para almacenar el método de conexión de la clase clsConexion
        Dim ConexionBaseDatos As NpgsqlConnection = New clsConexion().ConexionBaseDatosPostgres()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
        ' Cerramos la Conexion
        ' ConexionBaseDatos.Close()
    End Sub
    Public Function InsertarPersona(Valores As String) As Integer
        ' Creamos el objeto tipo conexión para almacenar el método de conexión de la clase clsConexion
        Dim ConexionBaseDatos As NpgsqlConnection = New clsConexion().ConexionBaseDatosPostgres()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
        ' Cerramos la Conexion
        ' ConexionBaseDatos.Close()
        ' Devolvemos el id generado en la insersión
        Return ValoridPersona
    End Function
    Public Function ObtenerNombrePersona(idPersona As String) As String
        ' Creamos el objeto tipo conexión para almacenar el método de conexión de la clase clsConexion
        Dim ConexionBaseDatos As NpgsqlConnection = New clsConexion().ConexionBaseDatosPostgres()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
        ' Cerramos la Conexion
        ' ConexionBaseDatos.Close()
        ' Devolvemos el DataReader
        Return NombreCompletoPersona
    End Function
    Public Function ObtenerNombreTecnico(idTecnico As String) As String
        ' Creamos el objeto tipo conexión para almacenar el método de conexión de la clase clsConexion
        Dim ConexionBaseDatos As NpgsqlConnection = New clsConexion().ConexionBaseDatosPostgres()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Objetos a utilizar
        Dim Consulta As String
        Dim Comando As NpgsqlCommand = New NpgsqlCommand()
        Dim LectorDatos As NpgsqlDataReader
        Dim idPersona As String
        ' Se le pasa la conexion al comando
        Comando.Connection = ConexionBaseDatos
        ' Le Pasamos la sentencia a la variable consulta
        Consulta = "SELECT idPersona From Tecnico WHERE idTecnico=" & idTecnico & ";"
        ' Le pasamos la consulta al comando
        Comando.CommandText = Consulta
        'Debug.Write(Consulta)
        ' Ejecutamos el comando
        LectorDatos = Comando.ExecuteReader()
        While LectorDatos.Read
            idPersona = LectorDatos(0)
        End While
        ' Retornamos el valor
        Return ObtenerNombrePersona(idPersona)
    End Function
    Public Function ObtenerNombreEquipo(idEquipo As String) As String
        ' Creamos el objeto tipo conexión para almacenar el método de conexión de la clase clsConexion
        Dim ConexionBaseDatos As NpgsqlConnection = New clsConexion().ConexionBaseDatosPostgres()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Objetos a utilizar
        Dim Consulta As String
        Dim Comando As NpgsqlCommand = New NpgsqlCommand()
        Dim LectorDatos As NpgsqlDataReader
        Dim NombreEquipo As String
        ' Se le pasa la conexion al comando
        Comando.Connection = ConexionBaseDatos
        ' Le Pasamos la sentencia a la variable consulta
        Consulta = "SELECT Nombre From Equipo WHERE idEquipo=" & idEquipo & ";"
        ' Le pasamos la consulta al comando
        Comando.CommandText = Consulta
        'Debug.Write(Consulta)
        ' Ejecutamos el comando
        LectorDatos = Comando.ExecuteReader()
        While LectorDatos.Read
            NombreEquipo = LectorDatos(0)
        End While
        ' Cerramos la Conexion
        ' ConexionBaseDatos.Close()
        ' Devolvemos el DataReader
        Return NombreEquipo
    End Function
    Public Function ObtenerNombre(Tabla As String, identificador As String, ValorIdentificador As String) As String
        ' Creamos el objeto tipo conexión para almacenar el método de conexión de la clase clsConexion
        Dim ConexionBaseDatos As NpgsqlConnection = New clsConexion().ConexionBaseDatosPostgres()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Objetos a utilizar
        Dim Consulta As String
        Dim Comando As NpgsqlCommand = New NpgsqlCommand()
        Dim LectorDatos As NpgsqlDataReader
        Dim NombreDevolver As String
        ' Se le pasa la conexion al comando
        Comando.Connection = ConexionBaseDatos
        ' Le Pasamos la sentencia a la variable consulta
        Consulta = "SELECT Nombre From " & Tabla & " WHERE " & identificador & "=" & ValorIdentificador & ";"
        ' Le pasamos la consulta al comando
        Comando.CommandText = Consulta
        'Debug.Write(Consulta)
        ' Ejecutamos el comando
        LectorDatos = Comando.ExecuteReader()
        While LectorDatos.Read
            NombreDevolver = LectorDatos(0)
        End While
        ' Cerramos la Conexion
        ' ConexionBaseDatos.Close()
        ' Devolvemos el DataReader
        Return NombreDevolver
    End Function
    ' Realizar Selects
    Public Function SentenciaSelectConCondiciones(Tabla As String, CamposDevolver As String, Restricciones As String) As NpgsqlDataReader
        ' Creamos el objeto tipo conexión para almacenar el método de conexión de la clase clsConexion
        Dim ConexionBaseDatos As NpgsqlConnection = New clsConexion().ConexionBaseDatosPostgres()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
        ' Cerramos la Conexion
        ' ConexionBaseDatos.Close()
        ' Devolvemos el DataReader
        Return LectorDatos
    End Function
    Public Function Top10Historico() As DataTable
        ' Creamos el objeto tipo conexión para almacenar el método de conexión de la clase clsConexion
        Dim ConexionBaseDatos As NpgsqlConnection = New clsConexion().ConexionBaseDatosPostgres()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Objetos a utilizar
        Dim Consulta As String
        Dim Comando As NpgsqlCommand = New NpgsqlCommand()
        Dim LectorDatos As NpgsqlDataReader
        Dim DatosTabla As DataTable = New DataTable()
        ' Se le pasa la conexion al comando
        Comando.Connection = ConexionBaseDatos
        ' Le Pasamos la sentencia a la variable consulta
        Consulta = "SELECT jugador.idpersona, COUNT(gol) FROM jugador LEFT JOIN gol ON jugador.idjugador = gol.idjugador GROUP BY jugador.idjugador ORDER BY count DESC FETCH FIRST 10 ROWS ONLY;"
        ' Le pasamos la consulta al comando
        Comando.CommandText = Consulta
        'Debug.Write(Consulta)
        ' Ejecutamos el comando
        LectorDatos = Comando.ExecuteReader()
        ' Cerramos la Conexion
        ' ConexionBaseDatos.Close()
        ' Agregamos los encabezados de la tabla
        DatosTabla.Columns.Clear()
        DatosTabla.Columns.Add("Nombre")
        DatosTabla.Columns.Add("Cantidad")
        If LectorDatos.HasRows Then
            While LectorDatos.Read
                Dim FilaDatos As DataRow
                FilaDatos = DatosTabla.NewRow()
                FilaDatos("Nombre") = ObtenerNombrePersona(LectorDatos("idPersona"))
                FilaDatos("Cantidad") = LectorDatos("count")
                DatosTabla.Rows.Add(FilaDatos)
            End While
        Else
            Dim FilaDatos As DataRow
            FilaDatos = DatosTabla.NewRow()
            FilaDatos("Nombre") = "No hay datos"
            FilaDatos("Cantidad") = "0"
            DatosTabla.Rows.Add(FilaDatos)
        End If
        ' Devolvemos el DataReader
        Return DatosTabla
    End Function
    Public Function Top10MenosAmonestados() As DataTable
        ' Creamos el objeto tipo conexión para almacenar el método de conexión de la clase clsConexion
        Dim ConexionBaseDatos As NpgsqlConnection = New clsConexion().ConexionBaseDatosPostgres()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Objetos a utilizar
        Dim Consulta As String
        Dim Comando As NpgsqlCommand = New NpgsqlCommand()
        Dim LectorDatos As NpgsqlDataReader
        Dim DatosTabla As DataTable = New DataTable()
        ' Se le pasa la conexion al comando
        Comando.Connection = ConexionBaseDatos
        ' Le Pasamos la sentencia a la variable consulta
        Consulta = "SELECT jugador.idpersona, COUNT(amonestacion) FROM jugador LEFT JOIN amonestacion ON jugador.idjugador = amonestacion.idjugador GROUP BY jugador.idjugador ORDER BY count DESC FETCH FIRST 10 ROWS ONLY;"
        ' Le pasamos la consulta al comando
        Comando.CommandText = Consulta
        'Debug.Write(Consulta)
        ' Ejecutamos el comando
        LectorDatos = Comando.ExecuteReader()
        ' Cerramos la Conexion
        ' ConexionBaseDatos.Close()
        ' Agregamos los encabezados de la tabla
        DatosTabla.Columns.Clear()
        DatosTabla.Columns.Add("Nombre")
        DatosTabla.Columns.Add("Cantidad")
        If LectorDatos.HasRows Then
            While LectorDatos.Read
                Dim FilaDatos As DataRow
                FilaDatos = DatosTabla.NewRow()
                FilaDatos("Nombre") = ObtenerNombrePersona(LectorDatos("idPersona"))
                FilaDatos("Cantidad") = LectorDatos("count")
                DatosTabla.Rows.Add(FilaDatos)
            End While
        Else
            Dim FilaDatos As DataRow
            FilaDatos = DatosTabla.NewRow()
            FilaDatos("Nombre") = "No hay datos"
            FilaDatos("Cantidad") = "0"
            DatosTabla.Rows.Add(FilaDatos)
        End If
        ' Devolvemos el DataReader
        Return DatosTabla
    End Function
    Public Function Top10MasGoleadores() As DataTable
        ' Creamos el objeto tipo conexión para almacenar el método de conexión de la clase clsConexion
        Dim ConexionBaseDatos As NpgsqlConnection = New clsConexion().ConexionBaseDatosPostgres()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Objetos a utilizar
        Dim Consulta As String
        Dim Comando As NpgsqlCommand = New NpgsqlCommand()
        Dim LectorDatos As NpgsqlDataReader
        Dim DatosTabla As DataTable = New DataTable()
        ' Se le pasa la conexion al comando
        Comando.Connection = ConexionBaseDatos
        ' Le Pasamos la sentencia a la variable consulta
        Consulta = "SELECT equipo.nombre, COUNT(gol) FROM equipo LEFT JOIN gol ON equipo.idequipo = gol.idequipo GROUP BY equipo.idequipo ORDER BY count DESC FETCH FIRST 10 ROWS ONLY;"
        ' Le pasamos la consulta al comando
        Comando.CommandText = Consulta
        'Debug.Write(Consulta)
        ' Ejecutamos el comando
        LectorDatos = Comando.ExecuteReader()
        ' Cerramos la Conexion
        ' ConexionBaseDatos.Close()
        ' Agregamos los encabezados de la tabla
        DatosTabla.Columns.Clear()
        DatosTabla.Columns.Add("Nombre")
        DatosTabla.Columns.Add("Cantidad")
        If LectorDatos.HasRows Then
            While LectorDatos.Read
                Dim FilaDatos As DataRow
                FilaDatos = DatosTabla.NewRow()
                FilaDatos("Nombre") = LectorDatos("nombre")
                FilaDatos("Cantidad") = LectorDatos("count")
                DatosTabla.Rows.Add(FilaDatos)
            End While
        Else
            Dim FilaDatos As DataRow
            FilaDatos = DatosTabla.NewRow()
            FilaDatos("Nombre") = "No hay datos"
            FilaDatos("Cantidad") = "0"
            DatosTabla.Rows.Add(FilaDatos)
        End If
        ' Devolvemos el DataReader
        Return DatosTabla
    End Function
    ' Realizar Selects
    Public Function SentenciaSelectSinCondiciones(Tabla As String, CamposDevolver As String) As NpgsqlDataReader
        ' Creamos el objeto tipo conexión para almacenar el método de conexión de la clase clsConexion
        Dim ConexionBaseDatos As NpgsqlConnection = New clsConexion().ConexionBaseDatosPostgres()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
        ' Cerramos la Conexion
        ' ConexionBaseDatos.Close()
        ' Devolvemos el DataReader
        Return LectorDatos
    End Function
    Public Sub ActualizarDatos(Tabla As String, Valores As String, Restricciones As String)
        ' Creamos el objeto de conexión
        Dim ConexionBaseDatos As NpgsqlConnection = New clsConexion().ConexionBaseDatosPostgres()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Objetos a utilizar
        Dim Consulta As String
        Dim Comando As NpgsqlCommand = New NpgsqlCommand()
        ' Le pasamos la conexion al comando
        Comando.Connection = ConexionBaseDatos
        ' Creamos la consutla, actualizammos los datos de la tabla a partir del ID que le pasamos
        Consulta = "UPDATE " & Tabla & " SET " & Valores & " WHERE " & Restricciones
        ' Le pasamos la consutla al comando
        Comando.CommandText = Consulta
        ' Intentamos ejecutar el comando y capturamos las exepciones para mostrarlas en consola
        Try
            Comando.ExecuteNonQuery()
        Catch ex As Exception
            Debug.Write(ex)
        End Try
        ' Cerramos la Conexion
        ' ConexionBaseDatos.Close()
    End Sub
    Public Function VerEquipos() As DataTable
        ' Creamos el objeto tipo conexión para almacenar el método de conexión de la clase clsConexion
        Dim ConexionBaseDatos As NpgsqlConnection = New clsConexion().ConexionBaseDatosPostgres()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Objetos a utilizar
        Dim Consulta As String
        Dim Comando As NpgsqlCommand = New NpgsqlCommand()
        Dim LectorDatos As NpgsqlDataReader
        Dim DatosTabla As DataTable = New DataTable()
        ' Se le pasa la conexion al comando
        Comando.Connection = ConexionBaseDatos
        ' Le Pasamos la sentencia a la variable consulta
        Consulta = "Select * From Equipo;"
        ' Le pasamos la consulta al comando
        Comando.CommandText = Consulta
        'Debug.Write(Consulta)
        ' Ejecutamos el comando
        LectorDatos = Comando.ExecuteReader()
        ' Cerramos la Conexion
        ' ConexionBaseDatos.Close()
        ' Agregamos los encabezados de la tabla
        DatosTabla.Columns.Clear()
        DatosTabla.Columns.Add("Código")
        DatosTabla.Columns.Add("Sede")
        DatosTabla.Columns.Add("Nombre")
        DatosTabla.Columns.Add("Técnico")
        If LectorDatos.HasRows Then
            While LectorDatos.Read
                Dim FilaDatos As DataRow
                FilaDatos = DatosTabla.NewRow()
                FilaDatos("Código") = LectorDatos("idEquipo")
                FilaDatos("Sede") = ObtenerNombre("Sede", "idSede", LectorDatos("idSede"))
                FilaDatos("Nombre") = LectorDatos("Nombre")
                FilaDatos("Técnico") = ObtenerNombreTecnico(LectorDatos("idTecnico"))
                DatosTabla.Rows.Add(FilaDatos)
            End While
        Else
            Dim FilaDatos As DataRow
            FilaDatos = DatosTabla.NewRow()
            FilaDatos("Nombre") = "No hay datos"
            FilaDatos("Cantidad") = "0"
            DatosTabla.Rows.Add(FilaDatos)
        End If
        ' Devolvemos el DataReader
        Return DatosTabla
    End Function
    Public Function VerPartidos() As DataTable
        ' Creamos el objeto tipo conexión para almacenar el método de conexión de la clase clsConexion
        Dim ConexionBaseDatos As NpgsqlConnection = New clsConexion().ConexionBaseDatosPostgres()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Objetos a utilizar
        Dim Consulta As String
        Dim Comando As NpgsqlCommand = New NpgsqlCommand()
        Dim LectorDatos As NpgsqlDataReader
        Dim DatosTabla As DataTable = New DataTable()
        ' Se le pasa la conexion al comando
        Comando.Connection = ConexionBaseDatos
        ' Le Pasamos la sentencia a la variable consulta
        Consulta = "Select * From Partido;"
        ' Le pasamos la consulta al comando
        Comando.CommandText = Consulta
        'Debug.Write(Consulta)
        ' Ejecutamos el comando
        LectorDatos = Comando.ExecuteReader()
        ' Cerramos la Conexion
        ' ConexionBaseDatos.Close()
        ' Agregamos los encabezados de la tabla
        DatosTabla.Columns.Clear()
        DatosTabla.Columns.Add("Código")
        DatosTabla.Columns.Add("Torneo")
        DatosTabla.Columns.Add("Fecha")
        DatosTabla.Columns.Add("Sede")
        DatosTabla.Columns.Add("Equipo Local")
        DatosTabla.Columns.Add("Equipo Visitante")
        DatosTabla.Columns.Add("Estado")
        DatosTabla.Columns.Add("Hora")
        If LectorDatos.HasRows Then
            While LectorDatos.Read
                Dim FilaDatos As DataRow
                FilaDatos = DatosTabla.NewRow()
                FilaDatos("Código") = LectorDatos("idpartido")
                FilaDatos("Torneo") = ObtenerNombre("Torneo", "idTorneo", LectorDatos("idTorneo"))
                FilaDatos("Fecha") = LectorDatos("Fecha")
                FilaDatos("Sede") = ObtenerNombre("Sede", "idSede", LectorDatos("idSede"))
                FilaDatos("Equipo Local") = ObtenerNombre("Equipo", "idEquipo", LectorDatos("equipolocal"))
                FilaDatos("Equipo Visitante") = ObtenerNombre("Equipo", "idEquipo", LectorDatos("equipovisitante"))
                FilaDatos("Estado") = LectorDatos("Estado")
                FilaDatos("Hora") = LectorDatos("Hora")
                DatosTabla.Rows.Add(FilaDatos)
            End While
        Else
            Dim FilaDatos As DataRow
            FilaDatos = DatosTabla.NewRow()
            FilaDatos("Nombre") = "No hay datos"
            FilaDatos("Cantidad") = "0"
            DatosTabla.Rows.Add(FilaDatos)
        End If
        ' Devolvemos el DataReader
        Return DatosTabla
    End Function
    Public Function VerJugadores() As DataTable
        ' Creamos el objeto tipo conexión para almacenar el método de conexión de la clase clsConexion
        Dim ConexionBaseDatos As NpgsqlConnection = New clsConexion().ConexionBaseDatosPostgres()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Objetos a utilizar
        Dim Consulta As String
        Dim Comando As NpgsqlCommand = New NpgsqlCommand()
        Dim LectorDatos As NpgsqlDataReader
        Dim DatosTabla As DataTable = New DataTable()
        ' Se le pasa la conexion al comando
        Comando.Connection = ConexionBaseDatos
        ' Le Pasamos la sentencia a la variable consulta
        Consulta = "Select * From Jugador;"
        ' Le pasamos la consulta al comando
        Comando.CommandText = Consulta
        'Debug.Write(Consulta)
        ' Ejecutamos el comando
        LectorDatos = Comando.ExecuteReader()
        ' Cerramos la Conexion
        ' ConexionBaseDatos.Close()
        ' Agregamos los encabezados de la tabla
        DatosTabla.Columns.Clear()
        DatosTabla.Columns.Add("Código")
        DatosTabla.Columns.Add("Nombre")
        DatosTabla.Columns.Add("Equipo")
        DatosTabla.Columns.Add("Numero")
        DatosTabla.Columns.Add("Fecha inicio")
        DatosTabla.Columns.Add("Fecha fin")
        DatosTabla.Columns.Add("Estado")
        If LectorDatos.HasRows Then
            While LectorDatos.Read
                Dim FilaDatos As DataRow
                FilaDatos = DatosTabla.NewRow()
                FilaDatos("Código") = LectorDatos("idpartido")
                FilaDatos("Nombre") = ObtenerNombrePersona(LectorDatos("idTorneo"))
                FilaDatos("Equipo") = ObtenerNombre("Equipo", "idEquipo", LectorDatos("idEquipo"))
                FilaDatos("Nombre") = LectorDatos("Numero")
                FilaDatos("Fecha inicio") = LectorDatos("Fechainicio")
                FilaDatos("Fecha fin") = LectorDatos("Fechafin")
                FilaDatos("Estado") = LectorDatos("Estado")
                DatosTabla.Rows.Add(FilaDatos)
            End While
        Else
            Dim FilaDatos As DataRow
            FilaDatos = DatosTabla.NewRow()
            FilaDatos("Nombre") = "No hay datos"
            FilaDatos("Cantidad") = "0"
            DatosTabla.Rows.Add(FilaDatos)
        End If
        ' Devolvemos el DataReader
        Return DatosTabla
    End Function
End Class