Imports System.ComponentModel.DataAnnotations

Namespace GroupSummaries.Models

    Public Class Order

        Public Property OrderID As Integer

        <Required>
        Public Property ProductName As String

        Public Property Price As Integer

        Public Property Quantity As Integer

        Public Property SomeDate As DateTime

        Public Property Group1 As String

        Public Property Group2 As String

        Public Property Discontinued As Boolean
    End Class
End Namespace
