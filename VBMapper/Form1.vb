Imports System.IO

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Not (String.IsNullOrEmpty(mgrDataSQL.connStr))) Then
            txtIp.Text = "172.25.215.17"
            txtDbName.Text = "MBO"
            txtUsername.Text = "sa"
            txtPassword.Text = "pvst123@"
        End If
    End Sub

    Private Sub btnMap_Click(sender As Object, e As EventArgs) Handles btnMap.Click
        Dim template = "../../Template/VB.vb"

        Dim map = New MapADO()
        Dim filehandler = New FileHandler()
        Dim db = New DbHandler()
        Dim connectionString = mgrDataSQL.connStr
        If String.Compare(txtDbName.Text.Trim(), "MBO") <> 0 Then
            connectionString = "Data Source=" + txtIp.Text + "Initial Catalog=" + txtDbName.Text + "User ID=" + txtUsername.Text + "Password=" + txtPassword.Text + "Integrated Security=False"
        End If
        Dim tables = db.GetTableNames(txtDbName.Text, connectionString)
        For Each row In tables.Rows
            Dim tbname = row("NAME").ToString().Trim
            Dim content = "Public Class " + tbname + System.Environment.NewLine
            Dim columns = db.GetColumnsNames(txtDbName.Text, tbname, connectionString)
            Dim insertFunc = map.MakeInsert(tbname, columns)
            Dim updateFunc = map.MakeUpdate(tbname, columns)
            Dim prop = ""
            For Each col In columns.Rows
                Dim colName = col("COLUMN_NAME").ToString()
                Dim type = db.ConvertType(col("DATA_TYPE").ToString())
                prop += "Protected " + colName + " AS " + type + System.Environment.NewLine
            Next
            Dim strTemplate As String = filehandler.ReadFile(template)
            strTemplate = strTemplate.Replace("VB", tbname)
            strTemplate = strTemplate.Replace("Protected id As Integer", prop)
            strTemplate = strTemplate.Replace("InsertFunction", insertFunc)
            strTemplate = strTemplate.Replace("UpdateFunction", updateFunc)
            Dim location = template.Replace("Template", "Output").Replace("VB", tbname)

            If filehandler.FileExist(location) Then
                filehandler.Delete(location)
            End If
            Try
                filehandler.WriteFile(strTemplate, location)
            Catch ex As Exception
                MessageBox.Show("Cannot open file " + location)
                txtResult.Text = ex.ToString()
                Return
            End Try
            txtResult.Text += "Mapping " + tbname + ".vb success" + System.Environment.NewLine
        Next
        MessageBox.Show("Mapping done!")
    End Sub

    Private Sub btnDapper_Click(sender As Object, e As EventArgs) Handles btnDapper.Click
        Dim template = "../../Template/Dapper.vb"

        Dim map = New MapDapper()
        Dim filehandler = New FileHandler()
        Dim db = New DbHandler()
        Dim connectionString = mgrDataSQL.connStr
        If String.Compare(txtDbName.Text.Trim(), "MBO") <> 0 Then
            connectionString = "Data Source=" + txtIp.Text + "Initial Catalog=" + txtDbName.Text + "User ID=" + txtUsername.Text + "Password=" + txtPassword.Text + "Integrated Security=False"
        End If
        Dim tables = db.GetTableNames(txtDbName.Text, connectionString)
        For Each row In tables.Rows
            Dim tbname = row("NAME").ToString().Trim
            Dim content = "Public Class " + tbname + System.Environment.NewLine
            Dim columns = db.GetColumnsNames(txtDbName.Text, tbname, connectionString)
            Dim insertFunc = map.MakeInsert(tbname, columns)
            Dim updateFunc = map.MakeUpdate(tbname, columns)
            Dim prop = ""
            For Each col In columns.Rows
                Dim colName = col("COLUMN_NAME").ToString()
                Dim type = db.ConvertType(col("DATA_TYPE").ToString())
                prop += "Protected " + colName + " AS " + type + System.Environment.NewLine
            Next
            Dim strTemplate As String = filehandler.ReadFile(template)
            strTemplate = strTemplate.Replace("Dapper", tbname)
            strTemplate = strTemplate.Replace(" Protected id As Integer", prop)
            strTemplate = strTemplate.Replace("InsertFunction", insertFunc)
            strTemplate = strTemplate.Replace("UpdateFunction", updateFunc)
            Dim location = template.Replace("Template", "Output").Replace("Dapper", tbname)

            If filehandler.FileExist(location) Then
                filehandler.Delete(location)
            End If
            Try
                filehandler.WriteFile(strTemplate, location)
            Catch ex As Exception
                MessageBox.Show("Cannot open file " + location)
                txtResult.Text = ex.ToString()
                Return
            End Try
            txtResult.Text += "Mapping " + tbname + ".vb success" + System.Environment.NewLine
        Next
        MessageBox.Show("Mapping done!")
    End Sub
End Class
