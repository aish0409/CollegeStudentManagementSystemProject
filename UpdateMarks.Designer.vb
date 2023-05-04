<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateMarks
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
        Me.MarksTextBox = New System.Windows.Forms.TextBox()
        Me.UpdateButton = New System.Windows.Forms.Button()
        Me.RemoveButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.StudentIDComboBox = New System.Windows.Forms.ComboBox()
        Me.CourseIDComboBox = New System.Windows.Forms.ComboBox()
        Me.StudentIdDeleteComboBox = New System.Windows.Forms.ComboBox()
        Me.CourseIdDeleteComboBox = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'MarksTextBox
        '
        Me.MarksTextBox.Location = New System.Drawing.Point(164, 215)
        Me.MarksTextBox.Name = "MarksTextBox"
        Me.MarksTextBox.PlaceholderText = "Marks"
        Me.MarksTextBox.Size = New System.Drawing.Size(125, 27)
        Me.MarksTextBox.TabIndex = 2
        '
        'UpdateButton
        '
        Me.UpdateButton.Location = New System.Drawing.Point(48, 319)
        Me.UpdateButton.Name = "UpdateButton"
        Me.UpdateButton.Size = New System.Drawing.Size(94, 29)
        Me.UpdateButton.TabIndex = 3
        Me.UpdateButton.Text = "Update"
        Me.UpdateButton.UseVisualStyleBackColor = True
        '
        'RemoveButton
        '
        Me.RemoveButton.Location = New System.Drawing.Point(607, 249)
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.Size = New System.Drawing.Size(94, 29)
        Me.RemoveButton.TabIndex = 4
        Me.RemoveButton.Text = "Remove"
        Me.RemoveButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "STUDENT ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(48, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "COURSE ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(48, 218)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "MARKS"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(455, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "STUDENT ID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(455, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "COURSE ID"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(236, 319)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 29)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'StudentIDComboBox
        '
        Me.StudentIDComboBox.FormattingEnabled = True
        Me.StudentIDComboBox.Location = New System.Drawing.Point(164, 63)
        Me.StudentIDComboBox.Name = "StudentIDComboBox"
        Me.StudentIDComboBox.Size = New System.Drawing.Size(151, 28)
        Me.StudentIDComboBox.TabIndex = 13
        '
        'CourseIDComboBox
        '
        Me.CourseIDComboBox.FormattingEnabled = True
        Me.CourseIDComboBox.Location = New System.Drawing.Point(164, 132)
        Me.CourseIDComboBox.Name = "CourseIDComboBox"
        Me.CourseIDComboBox.Size = New System.Drawing.Size(151, 28)
        Me.CourseIDComboBox.TabIndex = 14
        '
        'StudentIdDeleteComboBox
        '
        Me.StudentIdDeleteComboBox.FormattingEnabled = True
        Me.StudentIdDeleteComboBox.Location = New System.Drawing.Point(597, 86)
        Me.StudentIdDeleteComboBox.Name = "StudentIdDeleteComboBox"
        Me.StudentIdDeleteComboBox.Size = New System.Drawing.Size(151, 28)
        Me.StudentIdDeleteComboBox.TabIndex = 15
        '
        'CourseIdDeleteComboBox
        '
        Me.CourseIdDeleteComboBox.FormattingEnabled = True
        Me.CourseIdDeleteComboBox.Location = New System.Drawing.Point(597, 165)
        Me.CourseIdDeleteComboBox.Name = "CourseIdDeleteComboBox"
        Me.CourseIdDeleteComboBox.Size = New System.Drawing.Size(151, 28)
        Me.CourseIdDeleteComboBox.TabIndex = 16
        '
        'UpdateMarks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CourseIdDeleteComboBox)
        Me.Controls.Add(Me.StudentIdDeleteComboBox)
        Me.Controls.Add(Me.CourseIDComboBox)
        Me.Controls.Add(Me.StudentIDComboBox)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RemoveButton)
        Me.Controls.Add(Me.UpdateButton)
        Me.Controls.Add(Me.MarksTextBox)
        Me.Name = "UpdateMarks"
        Me.Text = "UpdateMarks"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MarksTextBox As TextBox
    Friend WithEvents UpdateButton As Button
    Friend WithEvents RemoveButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents StudentIDComboBox As ComboBox
    Friend WithEvents CourseIDComboBox As ComboBox
    Friend WithEvents StudentIdDeleteComboBox As ComboBox
    Friend WithEvents CourseIdDeleteComboBox As ComboBox
End Class
