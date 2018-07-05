Imports System.IO

Public Class FileHandler
    Public Function ReadFile(ByVal path As String)
        Using reader = New StreamReader(path)
            Dim result = reader.ReadToEnd()
            Return result
        End Using
    End Function
    Public Sub WriteFile(ByVal content As String, ByVal path As String)
        Using writer = New StreamWriter(path, False)
            writer.Write(content)
        End Using
    End Sub
    Public Sub Delete(ByVal path As String)
        File.Delete(path)
    End Sub
    Public Sub Create(ByVal path As String)
        File.Create(path).Dispose()
    End Sub
    Public Function FileExist(ByVal path As String)
        Return File.Exists(path)
    End Function
End Class
