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
        lblDnsServer = New Label()
        cmbDnsServers = New ComboBox()
        btnQuery = New Button()
        txtOutput = New RichTextBox()
        SuspendLayout()
        ' 
        ' lblDnsServer
        ' 
        lblDnsServer.AutoSize = True
        lblDnsServer.Location = New Point(37, 21)
        lblDnsServer.Name = "lblDnsServer"
        lblDnsServer.Size = New Size(169, 25)
        lblDnsServer.TabIndex = 1
        lblDnsServer.Text = "Select a DNS server:"
        ' 
        ' cmbDnsServers
        ' 
        cmbDnsServers.FormattingEnabled = True
        cmbDnsServers.Location = New Point(212, 18)
        cmbDnsServers.Name = "cmbDnsServers"
        cmbDnsServers.Size = New Size(297, 33)
        cmbDnsServers.TabIndex = 2
        ' 
        ' btnQuery
        ' 
        btnQuery.Location = New Point(397, 66)
        btnQuery.Name = "btnQuery"
        btnQuery.Size = New Size(112, 34)
        btnQuery.TabIndex = 3
        btnQuery.Text = "Run test"
        btnQuery.UseVisualStyleBackColor = True
        ' 
        ' txtOutput
        ' 
        txtOutput.Location = New Point(56, 133)
        txtOutput.Name = "txtOutput"
        txtOutput.ReadOnly = True
        txtOutput.Size = New Size(453, 287)
        txtOutput.TabIndex = 4
        txtOutput.Text = ""
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(633, 541)
        Controls.Add(txtOutput)
        Controls.Add(btnQuery)
        Controls.Add(cmbDnsServers)
        Controls.Add(lblDnsServer)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblDnsServer As Label
    Friend WithEvents cmbDnsServers As ComboBox
    Friend WithEvents btnQuery As Button
    Friend WithEvents txtOutput As RichTextBox
End Class
