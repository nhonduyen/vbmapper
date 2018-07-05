Public Class Dapper
    Protected id As Integer
   
    Public Function SelectData(Optional ByVal ID As Integer = 0, Optional ByVal listcolumn As String = "")
        Dim DBManager = New DBManager(Of Dapper)
        Dim sql = "SELECT * FROM Dapper "
        If (Not (String.IsNullOrEmpty(listcolumn))) Then
            sql = sql.Replace("*", listcolumn)
        End If
        If ID = 0 Then
            Return DBManager.ExecuteReader(sql)
        End If
        sql += "WHERE ID=@ID"
        Return DBManager.ExecuteReader(sql, New With {Key .ID = ID})
    End Function
    Public Overridable Function SelectPaging(Optional ByVal start As Integer = 0, Optional ByVal end1 As Integer = 10, Optional ByVal listcolumn As String = "") As List(Of Dapper)
        Dim DBManager = New DBManager(Of Dapper)
        Dim sql = "SELECT * FROM(SELECT ROW_NUMBER() OVER (order by id) AS ROWNUM, * FROM Dapper) as u  WHERE   RowNum BETWEEN @start AND < @end1 ORDER BY RowNum;"
        If (Not (String.IsNullOrEmpty(listcolumn))) Then
            sql = sql.Replace("*", listcolumn)
        End If
        Return DBManager.ExecuteReader(sql, New With {Key .start = start, Key .end1 = end1})
    End Function

    Public Overridable Function GetCount() As Integer
        Dim DBManager = New DBManager(Of Dapper)
        Dim sql = "SELECT COUNT(1) AS CNT FROM Dapper;"
        Dim result = DBManager.ExecuteScalar(sql)
        Return CInt(result)
    End Function


    Public Overridable Function Update1Column(ByVal ID, ByVal COLUMN, ByVal VALUE) As Integer
        Dim DBManager = New DBManager(Of Dapper)
        Dim sql = String.Format("UPDATE Dapper SET {0}=@VALUE WHERE ID=@ID", COLUMN)
        Return DBManager.Execute(sql, New With {Key .VALUE = VALUE})
    End Function

    Public Overridable Function Delete(Optional ByVal ID As Integer = 0) As Integer
        Dim DBManager = New DBManager(Of Dapper)
        Dim sql = "DELETE FROM Dapper "
        If ID = 0 Then Return DBManager.Execute(sql)
        sql += " WHERE ID=@ID "
        Return DBManager.Execute(sql, New With {Key .ID = ID})
    End Function
    Dim InsertFunction
    Dim UpdateFunction

End Class
