Imports System.Configuration
Imports Dapper
Imports System.Data
Imports System.Data.Common
Class DBManager(Of TEntity As Class)
    Private Shared ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("cnnString").ConnectionString

    Function GetOpenConnection() As IDbConnection
        Dim factory = DbProviderFactories.GetFactory("System.Data.SqlClient")
        Dim connection = factory.CreateConnection()
        connection.ConnectionString = connectionString
        connection.Open()
        Return connection
    End Function

    Public Function ExecuteDynamic(ByVal sql As String, Optional ByVal param As Object = Nothing, Optional ByVal type As CommandType = CommandType.Text)
        Using db As IDbConnection = GetOpenConnection()
            Return db.Query(sql, param, commandType:=type).AsList()
        End Using
    End Function

    Public Function ExecuteReader(ByVal sql As String, Optional ByVal param As Object = Nothing, Optional ByVal type As CommandType = CommandType.Text) As List(Of TEntity)
        Using db As IDbConnection = GetOpenConnection()
            Return db.Query(Of TEntity)(sql, param, commandType:=type).AsList()
        End Using
    End Function

    Public Function ExecuteSingle(ByVal sql As String, Optional ByVal param As Object = Nothing, Optional ByVal type As CommandType = CommandType.Text) As Integer
        Using db As IDbConnection = GetOpenConnection()
            Return db.Query(Of Integer)(sql, param, commandType:=type).Single()
        End Using
    End Function


    Public Function Execute(ByVal sql As String, Optional ByVal param As Object = Nothing, Optional ByVal type As CommandType = CommandType.Text) As Integer
        Using db As IDbConnection = GetOpenConnection()
            Return db.Execute(sql, param, commandType:=type)
        End Using
    End Function

    Public Function ExecuteMultiple(ByVal sql As String, Optional ByVal param As Object() = Nothing, Optional ByVal type As CommandType = CommandType.Text) As Integer
        Using db As IDbConnection = GetOpenConnection()
            Return db.Execute(sql, param, commandType:=type)
        End Using
    End Function

    Public Function ExecuteScalar(ByVal sql As String, Optional ByVal param As Object = Nothing, Optional ByVal type As CommandType = CommandType.Text) As Object
        Using db As IDbConnection = GetOpenConnection()
            Return db.ExecuteScalar(sql, param, commandType:=type)
        End Using
    End Function
End Class
