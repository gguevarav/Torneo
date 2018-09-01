Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports Microsoft.Owin.Security
Imports System.Configuration
Imports Npgsql


Public Partial Class Account_Login
    Inherits Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        RegisterHyperLink.NavigateUrl = "Register"
        OpenAuthLogin.ReturnUrl = Request.QueryString("ReturnUrl")
        Dim returnUrl = HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
        If Not [String].IsNullOrEmpty(returnUrl) Then
            RegisterHyperLink.NavigateUrl += "?ReturnUrl=" & returnUrl
        End If
    End Sub

    Protected Sub LogIn(sender As Object, e As EventArgs)
        If IsValid Then
            ' Validar la contraseña del usuario
            Dim manager = New UserManager()
            Dim user As ApplicationUser = manager.Find(UserName.Text, Password.Text)
            If user IsNot Nothing Then
                IdentityHelper.SignIn(manager, user, RememberMe.Checked)
                IdentityHelper.RedirectToReturnUrl(Request.QueryString("ReturnUrl"), Response)
            Else
                FailureText.Text = "Nombre de usuario o contraseña no válidos."
                ErrorMessage.Visible = True
            End If
        End If
    End Sub

    ' Clase para conectar
    Public Sub InicarSesion()
        ' Variables
        Dim configuracion As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("BDTorneo_PruebaConnectionString")
        Dim MiConeccion As NpgsqlConnection = New NpgsqlConnection With {
            .ConnectionString = configuracion.ConnectionString
        }
        Dim Consulta As String
        Dim Comando As NpgsqlCommand = New NpgsqlCommand()

        Try
            MiConeccion.Open()
        Catch
            FailureText.Text = "Contraseña Incorrecta"
            ErrorMessage.Visible = True
            MiConeccion.Close()
        End Try
        ' Consultas
        Comando.Connection = MiConeccion
        Consulta = "SELECT NombreUsuario, Password From Usuario WHERE NombreUsuario='" & UserName.Text & "' AND Password='" & Password.Text & "';"
        Comando.CommandText = Consulta
        If Comando.ExecuteNonQuery = True Then
            Session("NombreUsuario") = UserName.Text
            IdentityHelper.RedirectToReturnUrl(Request.QueryString("ReturnUrl"), Response)
            'FailureText.Text = "Inicio de sesion Valido"
            'ErrorMessage.Visible = True
        End If
        MiConeccion.Close()
    End Sub
End Class
