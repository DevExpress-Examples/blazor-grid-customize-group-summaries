Namespace GroupSummaries.Models

    Public Class OrderService

        Private orders As List(Of Order)

        Public Sub CreateOrders()
            orders = New List(Of Order)()
            Dim myRand As Random = New Random()
            For i As Integer = 0 To 10 - 1
                Dim newOrder As Order = New Order()
                newOrder.OrderID = i
                newOrder.ProductName = "Product " & i.ToString()
                newOrder.Price = myRand.[Next](100, 500)
                newOrder.Quantity = myRand.[Next](10, 50)
                newOrder.SomeDate = DateTime.Now.AddDays(i)
                newOrder.Group1 = "Parent Group " & (i Mod 2).ToString()
                newOrder.Group2 = "Child Group " & (i Mod 3).ToString()
                newOrder.Discontinued = Convert.ToBoolean(myRand.[Next](0, 2))
                orders.Add(newOrder)
            Next
        End Sub

        Public Function GetOrdersAsync() As Task(Of List(Of Order))
            If orders Is Nothing Then
                CreateOrders()
            End If

            Return Task.FromResult(orders)
        End Function
    End Class
End Namespace
