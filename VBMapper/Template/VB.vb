Imports System.Data

Public Class VB
    Protected id As Integer

    Public Function SelectData(Optional ByVal ID As Integer = 0, Optional ByVal listcolumn As String = "")
        Dim sql = "SELECT * FROM TABLE "
        If (Not (String.IsNullOrEmpty(listcolumn))) Then
            sql = sql.Replace("*", listcolumn)
        End If
        If ID = 0 Then
            Return mgrDataSQL.ExecuteReader(sql)
        End If
        sql += "WHERE ID=@ID"
        Dim param = New Dictionary(Of String, Object)
        param.Add("@ID", ID)
        Return mgrDataSQL.ExecuteReader(sql, param)
    End Function
    Public Function SelectPaging(Optional ByVal min As Integer = 1, Optional ByVal max As Integer = 10, Optional ByVal listcolumn As String = "")
        Dim sql = "SELECT * FROM(SELECT ROW_NUMBER() OVER (order by id) AS ROWNUM, * FROM TABLE) as u  WHERE   RowNum BETWEEN @min  AND @max ORDER BY RowNum "
        If (Not (String.IsNullOrEmpty(listcolumn))) Then
            sql = sql.Replace("*", listcolumn)
        End If
        Dim param = New Dictionary(Of String, Object)
        param.Add("@min", min)
        param.Add("@max", max)
        Return mgrDataSQL.ExecuteReader(sql, param)
    End Function
    Public Function GetCount()
        Dim sql = "SELECT COUNT(1) AS CNT FROM TABLE "
        Dim count = mgrDataSQL.ExecuteScalar(sql)
        Return Convert.ToInt32(count)
    End Function
    Public Function Update1Column(ByVal ID, ByVal COLUMN, ByVal VALUE)
        Dim sql = String.Format("UPDATE TABLE SET {0}=@VALUE WHERE ID=@ID", COLUMN)
        Dim param = New Dictionary(Of String, Object)
        param.Add("@VALUE", VALUE)
        Return mgrDataSQL.ExecuteNonQuery(sql, param)
    End Function
    Public Function Delete(Optional ByVal ID = 0)
        Dim sql = "DELETE FROM TABLE "
        If ID = 0 Then
            Return mgrDataSQL.ExecuteNonQuery(sql)
        End If
        sql += "WHERE ID=@ID"
        Dim param = New Dictionary(Of String, Object)
        param.Add("@ID", ID)
        Return mgrDataSQL.ExecuteNonQuery(sql, param)
    End Function
    Dim InsertFunction
    Dim UpdateFunction
  
End Class
