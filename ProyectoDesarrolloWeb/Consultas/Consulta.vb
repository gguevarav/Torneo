Imports Microsoft.VisualBasic

Public Class Consulta
    Private Name As String
    Private Salary As Decimal
    Private HireDate As DateTime

    Public Sub New(ByVal Name As String, ByVal Salary As Decimal, ByVal HireDate As DateTime)
        Me.Name = Name
        Me.Salary = Salary
        Me.HireDate = HireDate
    End Sub

    Public Sub PayRise(ByVal Amount As Decimal)
        Me.Salary += Amount
    End Sub

    Public Property FullName() As String
        Get
            Return Me.Name
        End Get
        Set(ByVal Value As String)
            Me.Name = Value
        End Set
    End Property
End Class