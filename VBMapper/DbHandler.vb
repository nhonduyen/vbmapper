Imports System.Data

Public Class DbHandler
    Public Function GetAllDbName(ByVal connectionString)
        Dim sql = "SELECT name from sys.databases where name not in('master','tempdb','model','msdb','ReportServer','ReportServerTempDB')"
        Return mgrDataSQL.ExecuteReader(sql)
    End Function
    Public Function GetColumnsNames(ByVal dbName, ByVal table, ByVal connectionString)
        Dim sql = String.Format("SELECT COLUMN_NAME, DATA_TYPE FROM {0}.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'{1}'", dbName, table)
        Return mgrDataSQL.ExecuteReader(sql, Nothing, connectionString)
    End Function
    Public Function GetTableNames(ByVal db, ByVal connectionString)
        Dim sql = "USE " + db + ";  SELECT name FROM sys.Tables "
        Return mgrDataSQL.ExecuteReader(sql, Nothing, connectionString)
    End Function

    Public Function ConvertType(ByVal dataType As String)
        If (dataType.Contains("char") Or dataType.Contains("text")) Then
            Return "String"
        End If
        If dataType.Contains("int") Then
            Return "Integer"
        End If
        If dataType.Contains("float") Or dataType.Contains("double") Then
            Return "Double"
        End If
        If dataType.Contains("date") Then
            Return "DateTime"
        End If
        If dataType.Contains("decimal") Then
            Return "Decimal"
        End If
        Return "String"
    End Function

End Class
