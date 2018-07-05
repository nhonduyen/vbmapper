Public Class MapDapper
    Public Function MakeInsert(ByVal table As String, ByVal colums As DataTable)
        Dim db = New DbHandler()
        Dim DIC = New Dictionary(Of String, Object)
        Dim insert = "INSERT INTO " + table + "("
        Dim tempinsert = ""
        Dim parameter = ""
        Dim param = ""
        For Each col In colums.Rows
            Dim colName = col("COLUMN_NAME").ToString().Trim
            Dim type = db.ConvertType(col("DATA_TYPE").ToString())
            If (Not (colName.Equals("ID"))) Then
                parameter += "ByVal " + colName + " AS " + type + ","
                insert += colName + ","
                tempinsert += "@" + colName + ","
                param += "Key ." + colName + " = " + colName + ","
            End If
        Next
        tempinsert = tempinsert.Remove(tempinsert.Length - 1)
        insert = insert.Remove(insert.Length - 1) + ") VALUES(" & tempinsert & ")"""
        Dim strfunction = "Public Function Insert(" + parameter.Remove(parameter.Length - 1) + ")" + System.Environment.NewLine
        strfunction += "Dim DBManager = New DBManager(Of Dapper)" + System.Environment.NewLine
        strfunction += "Dim sql = """ + insert + "" + System.Environment.NewLine
        strfunction += "Return DBManager.Execute(sql,  New With {" + param.Remove(param.Length - 1) + "})" + System.Environment.NewLine
        strfunction += "End Function" + System.Environment.NewLine
        Return strfunction
    End Function
    Public Function MakeUpdate(ByVal table As String, ByVal colums As DataTable)
        Dim db = New DbHandler()
        Dim DIC = New Dictionary(Of String, Object)
        Dim update = "UPDATE " + table + " SET "
        Dim param = ""
        Dim parameter = ""
        Dim dictionary = "Dim param = New Dictionary(Of String, Object)" + System.Environment.NewLine
        For Each col In colums.Rows
            Dim colName = col("COLUMN_NAME").ToString().Trim
            Dim type = db.ConvertType(col("DATA_TYPE").ToString())
            parameter += "ByVal " + colName + " AS " + type + ","
            If (Not (colName.Equals("ID"))) Then
                update += colName + "=@" + colName + ","
            End If
            param += "Key ." + colName + " = " + colName + ","
        Next
        update = update.Remove(update.Length - 1) + " WHERE ID=@ID"""
        Dim strfunction = "Public Function Update(" + parameter.Remove(parameter.Length - 1) + ")" + System.Environment.NewLine
        strfunction += "Dim DBManager = New DBManager(Of Dapper)" + System.Environment.NewLine
        strfunction += "Dim sql =""" + update + "" + System.Environment.NewLine
        strfunction += dictionary + System.Environment.NewLine
        strfunction += "Return DBManager.Execute(sql,  New With {" + param.Remove(param.Length - 1) + "})" + System.Environment.NewLine
        strfunction += "End Function" + System.Environment.NewLine
        Return strfunction
    End Function
End Class
