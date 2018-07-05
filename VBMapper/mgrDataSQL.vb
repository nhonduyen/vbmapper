Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient


Public Module mgrDataSQL
    Public Property connStr = ConfigurationManager.ConnectionStrings("cnnString").ConnectionString
    Public Property mysql = ConfigurationManager.ConnectionStrings("mysql").ConnectionString

    Public Function ExecuteReader(ByVal sql As String, Optional ByVal param As Dictionary(Of String, Object) = Nothing, Optional ByVal ConnectionString As String = "") As DataTable
        Dim connectionStr = If(String.IsNullOrEmpty(ConnectionString), connStr, ConnectionString)
        Using connect = New SqlConnection(connectionStr)
            Dim dtb = New DataTable()
            connect.Open()
            Using Command = New SqlCommand(sql, connect)
                If Not param Is Nothing Then
                    For Each p In param
                        Command.Parameters.AddWithValue(p.Key, p.Value)
                    Next
                End If
                Dim reader = Command.ExecuteReader()
                dtb.Load(reader)
            End Using

            Return dtb
        End Using
    End Function

    Public Function ExecuteNonQuery(ByVal sql As String, Optional ByVal param As Dictionary(Of String, Object) = Nothing, Optional ByVal ConnectionString As String = "") As Integer
        Dim connectionStr = If(String.IsNullOrEmpty(ConnectionString), connStr, ConnectionString)
        Using connect = New SqlConnection(connectionStr)
            connect.Open()
            Using Command = New SqlCommand(sql, connect)
                Dim transaction As SqlTransaction
                transaction = connect.BeginTransaction()
                Command.Transaction = transaction
                Command.Notification = Nothing
                If Not param Is Nothing Then
                    For Each p In param
                        Command.Parameters.AddWithValue(p.Key, p.Value)
                    Next
                End If
                Dim effectedRows = Command.ExecuteNonQuery()
                Return effectedRows
            End Using
        End Using
    End Function
    Public Function ExecuteScalar(ByVal sql As String, Optional ByVal param As Dictionary(Of String, Object) = Nothing, Optional ByVal ConnectionString As String = "") As Object
        Dim connectionStr = If(String.IsNullOrEmpty(ConnectionString), connStr, ConnectionString)
        Using connect = New SqlConnection(connectionStr)
            connect.Open()
            Using Command = New SqlCommand(sql, connect)
                If Not param Is Nothing Then
                    For Each p In param
                        Command.Parameters.AddWithValue(p.Key, p.Value)
                    Next
                End If
                Dim scalar = Command.ExecuteScalar()
                Return scalar
            End Using
        End Using
    End Function
End Module
