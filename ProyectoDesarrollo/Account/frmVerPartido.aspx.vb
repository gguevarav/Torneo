Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports Microsoft.Owin.Security
Imports Npgsql
Imports System.Diagnostics
Imports System.Data

Partial Public Class VerPartido
    Inherits Page
    ' Instanciamos la clase
    Dim Consulta As New clsConsultas()
    Protected Sub Page_Load()
        gridVerPartidos.DataSource = Consulta.VerPartidos()
        gridVerPartidos.DataBind()
    End Sub
End Class
