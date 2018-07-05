<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnMysql = New System.Windows.Forms.Button()
        Me.btnDapper = New System.Windows.Forms.Button()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.btnMap = New System.Windows.Forms.Button()
        Me.txtDbName = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtIp = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'btnMysql
        '
        Me.btnMysql.Location = New System.Drawing.Point(184, 175)
        Me.btnMysql.Name = "btnMysql"
        Me.btnMysql.Size = New System.Drawing.Size(75, 23)
        Me.btnMysql.TabIndex = 39
        Me.btnMysql.Text = "Map Mysql"
        Me.btnMysql.UseVisualStyleBackColor = True
        '
        'btnDapper
        '
        Me.btnDapper.Location = New System.Drawing.Point(103, 175)
        Me.btnDapper.Name = "btnDapper"
        Me.btnDapper.Size = New System.Drawing.Size(75, 23)
        Me.btnDapper.TabIndex = 38
        Me.btnDapper.Text = "Map Dapper"
        Me.btnDapper.UseVisualStyleBackColor = True
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(115, 63)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(140, 20)
        Me.txtUsername.TabIndex = 35
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(22, 63)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(55, 13)
        Me.label6.TabIndex = 34
        Me.label6.Text = "Username"
        '
        'txtResult
        '
        Me.txtResult.Location = New System.Drawing.Point(22, 215)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtResult.Size = New System.Drawing.Size(230, 154)
        Me.txtResult.TabIndex = 33
        '
        'btnMap
        '
        Me.btnMap.Location = New System.Drawing.Point(22, 175)
        Me.btnMap.Name = "btnMap"
        Me.btnMap.Size = New System.Drawing.Size(75, 23)
        Me.btnMap.TabIndex = 32
        Me.btnMap.Text = "Map"
        Me.btnMap.UseVisualStyleBackColor = True
        '
        'txtDbName
        '
        Me.txtDbName.Location = New System.Drawing.Point(115, 129)
        Me.txtDbName.Name = "txtDbName"
        Me.txtDbName.Size = New System.Drawing.Size(140, 20)
        Me.txtDbName.TabIndex = 26
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(115, 98)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(140, 20)
        Me.txtPassword.TabIndex = 25
        '
        'txtIp
        '
        Me.txtIp.Location = New System.Drawing.Point(115, 25)
        Me.txtIp.Name = "txtIp"
        Me.txtIp.Size = New System.Drawing.Size(140, 20)
        Me.txtIp.TabIndex = 24
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(19, 129)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(53, 13)
        Me.label3.TabIndex = 23
        Me.label3.Text = "DB Name"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(19, 98)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(53, 13)
        Me.label2.TabIndex = 22
        Me.label2.Text = "Password"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(19, 28)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(51, 13)
        Me.label1.TabIndex = 21
        Me.label1.Text = "Server IP"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 392)
        Me.Controls.Add(Me.btnMysql)
        Me.Controls.Add(Me.btnDapper)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.btnMap)
        Me.Controls.Add(Me.txtDbName)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtIp)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Name = "Form1"
        Me.Text = "Mapping VB"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnMysql As System.Windows.Forms.Button
    Private WithEvents btnDapper As System.Windows.Forms.Button
    Private WithEvents txtUsername As System.Windows.Forms.TextBox
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents txtResult As System.Windows.Forms.TextBox
    Private WithEvents btnMap As System.Windows.Forms.Button
    Private WithEvents txtDbName As System.Windows.Forms.TextBox
    Private WithEvents txtPassword As System.Windows.Forms.TextBox
    Private WithEvents txtIp As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog

End Class
