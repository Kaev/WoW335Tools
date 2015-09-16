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
        Me.tbAdtFile = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnSearchAdt = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSearchWdt = New System.Windows.Forms.Button()
        Me.tbWdtFile = New System.Windows.Forms.TextBox()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'tbAdtFile
        '
        Me.tbAdtFile.BackColor = System.Drawing.Color.White
        Me.tbAdtFile.Location = New System.Drawing.Point(12, 30)
        Me.tbAdtFile.Name = "tbAdtFile"
        Me.tbAdtFile.ReadOnly = True
        Me.tbAdtFile.Size = New System.Drawing.Size(360, 20)
        Me.tbAdtFile.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Choose a .adt file:"
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(12, 95)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnLoad.TabIndex = 2
        Me.btnLoad.Text = "Load .adt"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'btnSearchAdt
        '
        Me.btnSearchAdt.Location = New System.Drawing.Point(378, 30)
        Me.btnSearchAdt.Name = "btnSearchAdt"
        Me.btnSearchAdt.Size = New System.Drawing.Size(31, 20)
        Me.btnSearchAdt.TabIndex = 3
        Me.btnSearchAdt.Text = "..."
        Me.btnSearchAdt.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(366, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Choose the .wdt file (Optional, only if you need the alphamap (MCAL) chunk)"
        '
        'btnSearchWdt
        '
        Me.btnSearchWdt.Location = New System.Drawing.Point(378, 69)
        Me.btnSearchWdt.Name = "btnSearchWdt"
        Me.btnSearchWdt.Size = New System.Drawing.Size(31, 20)
        Me.btnSearchWdt.TabIndex = 6
        Me.btnSearchWdt.Text = "..."
        Me.btnSearchWdt.UseVisualStyleBackColor = True
        '
        'tbWdtFile
        '
        Me.tbWdtFile.BackColor = System.Drawing.Color.White
        Me.tbWdtFile.Location = New System.Drawing.Point(12, 69)
        Me.tbWdtFile.Name = "tbWdtFile"
        Me.tbWdtFile.ReadOnly = True
        Me.tbWdtFile.Size = New System.Drawing.Size(360, 20)
        Me.tbWdtFile.TabIndex = 5
        '
        'ofd
        '
        Me.ofd.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 125)
        Me.Controls.Add(Me.btnSearchWdt)
        Me.Controls.Add(Me.tbWdtFile)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSearchAdt)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbAdtFile)
        Me.Name = "Form1"
        Me.Text = "AdtLib335 Demo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbAdtFile As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnLoad As Button
    Friend WithEvents btnSearchAdt As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSearchWdt As Button
    Friend WithEvents tbWdtFile As TextBox
    Friend WithEvents ofd As OpenFileDialog
End Class
