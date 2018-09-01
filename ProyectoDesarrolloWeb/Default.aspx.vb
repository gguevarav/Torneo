
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load()
        FailureText.Text = Session("NombreUsuario")
        ErrorMessage.Visible = True
    End Sub
End Class