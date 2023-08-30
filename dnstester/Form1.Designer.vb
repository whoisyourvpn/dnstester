<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Home = New TabControl()
        TabPage1 = New TabPage()
        btnTestAll = New Button()
        txtOutput = New RichTextBox()
        btnQuery = New Button()
        cmbDnsServers = New ComboBox()
        lblDnsServer = New Label()
        Results = New TabPage()
        rtbResultsLog = New RichTextBox()
        btnClearLog = New Button()
        Home.SuspendLayout()
        TabPage1.SuspendLayout()
        Results.SuspendLayout()
        SuspendLayout()
        ' 
        ' Home
        ' 
        Home.Controls.Add(TabPage1)
        Home.Controls.Add(Results)
        Home.Location = New Point(0, 0)
        Home.Name = "Home"
        Home.SelectedIndex = 0
        Home.Size = New Size(621, 509)
        Home.TabIndex = 6
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(btnTestAll)
        TabPage1.Controls.Add(txtOutput)
        TabPage1.Controls.Add(btnQuery)
        TabPage1.Controls.Add(cmbDnsServers)
        TabPage1.Controls.Add(lblDnsServer)
        TabPage1.Location = New Point(4, 34)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(613, 491)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Home"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' btnTestAll
        ' 
        btnTestAll.Location = New Point(274, 92)
        btnTestAll.Name = "btnTestAll"
        btnTestAll.Size = New Size(112, 34)
        btnTestAll.TabIndex = 10
        btnTestAll.Text = "Test all"
        btnTestAll.UseVisualStyleBackColor = True
        ' 
        ' txtOutput
        ' 
        txtOutput.Location = New Point(51, 159)
        txtOutput.Name = "txtOutput"
        txtOutput.ReadOnly = True
        txtOutput.Size = New Size(529, 287)
        txtOutput.TabIndex = 9
        txtOutput.Text = ""
        ' 
        ' btnQuery
        ' 
        btnQuery.Location = New Point(392, 92)
        btnQuery.Name = "btnQuery"
        btnQuery.Size = New Size(112, 34)
        btnQuery.TabIndex = 8
        btnQuery.Text = "Run test"
        btnQuery.UseVisualStyleBackColor = True
        ' 
        ' cmbDnsServers
        ' 
        cmbDnsServers.FormattingEnabled = True
        cmbDnsServers.Location = New Point(207, 44)
        cmbDnsServers.Name = "cmbDnsServers"
        cmbDnsServers.Size = New Size(297, 33)
        cmbDnsServers.TabIndex = 7
        ' 
        ' lblDnsServer
        ' 
        lblDnsServer.AutoSize = True
        lblDnsServer.Location = New Point(32, 47)
        lblDnsServer.Name = "lblDnsServer"
        lblDnsServer.Size = New Size(169, 25)
        lblDnsServer.TabIndex = 6
        lblDnsServer.Text = "Select a DNS server:"
        ' 
        ' Results
        ' 
        Results.Controls.Add(btnClearLog)
        Results.Controls.Add(rtbResultsLog)
        Results.Location = New Point(4, 34)
        Results.Name = "Results"
        Results.Padding = New Padding(3)
        Results.Size = New Size(613, 471)
        Results.TabIndex = 1
        Results.Text = "Results"
        Results.UseVisualStyleBackColor = True
        ' 
        ' rtbResultsLog
        ' 
        rtbResultsLog.Location = New Point(8, 6)
        rtbResultsLog.Name = "rtbResultsLog"
        rtbResultsLog.ScrollBars = RichTextBoxScrollBars.Vertical
        rtbResultsLog.Size = New Size(599, 419)
        rtbResultsLog.TabIndex = 0
        rtbResultsLog.Text = ""
        ' 
        ' btnClearLog
        ' 
        btnClearLog.Location = New Point(8, 431)
        btnClearLog.Name = "btnClearLog"
        btnClearLog.Size = New Size(112, 34)
        btnClearLog.TabIndex = 1
        btnClearLog.Text = "Clear logs"
        btnClearLog.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(633, 541)
        Controls.Add(Home)
        Name = "Form1"
        Text = "Form1"
        Home.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        Results.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents Home As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Results As TabPage
    Friend WithEvents btnTestAll As Button
    Friend WithEvents txtOutput As RichTextBox
    Friend WithEvents btnQuery As Button
    Friend WithEvents cmbDnsServers As ComboBox
    Friend WithEvents lblDnsServer As Label
    Friend WithEvents rtbResultsLog As RichTextBox
    Friend WithEvents btnClearLog As Button
End Class
