﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.ButtonSend = New System.Windows.Forms.Button()
        Me.CbRegion = New System.Windows.Forms.ComboBox()
        Me.LblRegion = New System.Windows.Forms.Label()
        Me.TxtFrom = New System.Windows.Forms.TextBox()
        Me.LblFrom = New System.Windows.Forms.Label()
        Me.LblTo = New System.Windows.Forms.Label()
        Me.TxtTo = New System.Windows.Forms.TextBox()
        Me.LblSubject = New System.Windows.Forms.Label()
        Me.TxtSubject = New System.Windows.Forms.TextBox()
        Me.LblBody = New System.Windows.Forms.Label()
        Me.TxtBody = New System.Windows.Forms.TextBox()
        Me.TxtKey = New System.Windows.Forms.TextBox()
        Me.TxtSecret = New System.Windows.Forms.TextBox()
        Me.LblAccessKey = New System.Windows.Forms.Label()
        Me.LblSecretKey = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txtAttachment = New System.Windows.Forms.TextBox()
        Me.lblAttach = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ButtonSearch = New System.Windows.Forms.Button()
        Me.TxtFilePath = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.CheckDelegate = New System.Windows.Forms.CheckBox()
        Me.TxtDelegate = New System.Windows.Forms.TextBox()
        Me.ButtonSearchFile = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'ButtonSend
        '
        Me.ButtonSend.Location = New System.Drawing.Point(21, 440)
        Me.ButtonSend.Name = "ButtonSend"
        Me.ButtonSend.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSend.TabIndex = 0
        Me.ButtonSend.Text = "Send"
        Me.ButtonSend.UseVisualStyleBackColor = true
        '
        'CbRegion
        '
        Me.CbRegion.FormattingEnabled = true
        Me.CbRegion.Location = New System.Drawing.Point(21, 53)
        Me.CbRegion.Name = "CbRegion"
        Me.CbRegion.Size = New System.Drawing.Size(222, 23)
        Me.CbRegion.TabIndex = 1
        '
        'LblRegion
        '
        Me.LblRegion.AutoSize = true
        Me.LblRegion.Location = New System.Drawing.Point(21, 23)
        Me.LblRegion.Name = "LblRegion"
        Me.LblRegion.Size = New System.Drawing.Size(47, 15)
        Me.LblRegion.TabIndex = 2
        Me.LblRegion.Text = "Region:"
        '
        'TxtFrom
        '
        Me.TxtFrom.Location = New System.Drawing.Point(21, 114)
        Me.TxtFrom.Name = "TxtFrom"
        Me.TxtFrom.Size = New System.Drawing.Size(222, 23)
        Me.TxtFrom.TabIndex = 3
        '
        'LblFrom
        '
        Me.LblFrom.AutoSize = true
        Me.LblFrom.Location = New System.Drawing.Point(21, 93)
        Me.LblFrom.Name = "LblFrom"
        Me.LblFrom.Size = New System.Drawing.Size(38, 15)
        Me.LblFrom.TabIndex = 4
        Me.LblFrom.Text = "From:"
        '
        'LblTo
        '
        Me.LblTo.AutoSize = true
        Me.LblTo.Location = New System.Drawing.Point(21, 160)
        Me.LblTo.Name = "LblTo"
        Me.LblTo.Size = New System.Drawing.Size(22, 15)
        Me.LblTo.TabIndex = 6
        Me.LblTo.Text = "To:"
        '
        'TxtTo
        '
        Me.TxtTo.Location = New System.Drawing.Point(21, 181)
        Me.TxtTo.Name = "TxtTo"
        Me.TxtTo.Size = New System.Drawing.Size(222, 23)
        Me.TxtTo.TabIndex = 5
        '
        'LblSubject
        '
        Me.LblSubject.AutoSize = true
        Me.LblSubject.Location = New System.Drawing.Point(21, 236)
        Me.LblSubject.Name = "LblSubject"
        Me.LblSubject.Size = New System.Drawing.Size(49, 15)
        Me.LblSubject.TabIndex = 8
        Me.LblSubject.Text = "Subject:"
        '
        'TxtSubject
        '
        Me.TxtSubject.Location = New System.Drawing.Point(21, 257)
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(222, 23)
        Me.TxtSubject.TabIndex = 7
        '
        'LblBody
        '
        Me.LblBody.AutoSize = true
        Me.LblBody.Location = New System.Drawing.Point(22, 303)
        Me.LblBody.Name = "LblBody"
        Me.LblBody.Size = New System.Drawing.Size(37, 15)
        Me.LblBody.TabIndex = 10
        Me.LblBody.Text = "Body:"
        '
        'TxtBody
        '
        Me.TxtBody.Location = New System.Drawing.Point(21, 321)
        Me.TxtBody.Name = "TxtBody"
        Me.TxtBody.Size = New System.Drawing.Size(216, 23)
        Me.TxtBody.TabIndex = 9
        '
        'TxtKey
        '
        Me.TxtKey.Location = New System.Drawing.Point(275, 53)
        Me.TxtKey.Name = "TxtKey"
        Me.TxtKey.Size = New System.Drawing.Size(216, 23)
        Me.TxtKey.TabIndex = 11
        '
        'TxtSecret
        '
        Me.TxtSecret.Location = New System.Drawing.Point(275, 114)
        Me.TxtSecret.Name = "TxtSecret"
        Me.TxtSecret.Size = New System.Drawing.Size(216, 23)
        Me.TxtSecret.TabIndex = 12
        '
        'LblAccessKey
        '
        Me.LblAccessKey.AutoSize = true
        Me.LblAccessKey.Location = New System.Drawing.Point(275, 23)
        Me.LblAccessKey.Name = "LblAccessKey"
        Me.LblAccessKey.Size = New System.Drawing.Size(76, 15)
        Me.LblAccessKey.TabIndex = 13
        Me.LblAccessKey.Text = "AccessKeyID:"
        '
        'LblSecretKey
        '
        Me.LblSecretKey.AutoSize = true
        Me.LblSecretKey.Location = New System.Drawing.Point(275, 93)
        Me.LblSecretKey.Name = "LblSecretKey"
        Me.LblSecretKey.Size = New System.Drawing.Size(97, 15)
        Me.LblSecretKey.TabIndex = 14
        Me.LblSecretKey.Text = "AccessSecretKey:"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = true
        Me.CheckBox1.Location = New System.Drawing.Point(275, 160)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(210, 19)
        Me.CheckBox1.TabIndex = 15
        Me.CheckBox1.Text = "Check To Get Access Key From .csv"
        Me.CheckBox1.UseVisualStyleBackColor = true
        '
        'txtAttachment
        '
        Me.txtAttachment.Location = New System.Drawing.Point(22, 411)
        Me.txtAttachment.Name = "txtAttachment"
        Me.txtAttachment.Size = New System.Drawing.Size(222, 23)
        Me.txtAttachment.TabIndex = 17
        '
        'lblAttach
        '
        Me.lblAttach.AutoSize = true
        Me.lblAttach.Location = New System.Drawing.Point(21, 356)
        Me.lblAttach.Name = "lblAttach"
        Me.lblAttach.Size = New System.Drawing.Size(100, 15)
        Me.lblAttach.TabIndex = 18
        Me.lblAttach.Text = "Attachment Path:"
        '
        'ButtonSearch
        '
        Me.ButtonSearch.Location = New System.Drawing.Point(275, 196)
        Me.ButtonSearch.Name = "ButtonSearch"
        Me.ButtonSearch.Size = New System.Drawing.Size(222, 23)
        Me.ButtonSearch.TabIndex = 20
        Me.ButtonSearch.Text = "Search For CSV File"
        Me.ButtonSearch.UseVisualStyleBackColor = true
        '
        'TxtFilePath
        '
        Me.TxtFilePath.Location = New System.Drawing.Point(275, 225)
        Me.TxtFilePath.Name = "TxtFilePath"
        Me.TxtFilePath.Size = New System.Drawing.Size(216, 23)
        Me.TxtFilePath.TabIndex = 21
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'CheckDelegate
        '
        Me.CheckDelegate.AutoSize = true
        Me.CheckDelegate.Location = New System.Drawing.Point(275, 260)
        Me.CheckDelegate.Name = "CheckDelegate"
        Me.CheckDelegate.Size = New System.Drawing.Size(133, 19)
        Me.CheckDelegate.TabIndex = 22
        Me.CheckDelegate.Text = "Use Delegate Sender"
        Me.CheckDelegate.UseVisualStyleBackColor = true
        '
        'TxtDelegate
        '
        Me.TxtDelegate.Location = New System.Drawing.Point(275, 285)
        Me.TxtDelegate.Name = "TxtDelegate"
        Me.TxtDelegate.Size = New System.Drawing.Size(216, 23)
        Me.TxtDelegate.TabIndex = 23
        Me.TxtDelegate.Text = "Identity ARN"
        '
        'ButtonSearchFile
        '
        Me.ButtonSearchFile.Location = New System.Drawing.Point(22, 382)
        Me.ButtonSearchFile.Name = "ButtonSearchFile"
        Me.ButtonSearchFile.Size = New System.Drawing.Size(222, 23)
        Me.ButtonSearchFile.TabIndex = 24
        Me.ButtonSearchFile.Text = "Search For File"
        Me.ButtonSearchFile.UseVisualStyleBackColor = true
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 15!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(517, 475)
        Me.Controls.Add(Me.ButtonSearchFile)
        Me.Controls.Add(Me.TxtDelegate)
        Me.Controls.Add(Me.CheckDelegate)
        Me.Controls.Add(Me.TxtFilePath)
        Me.Controls.Add(Me.ButtonSearch)
        Me.Controls.Add(Me.lblAttach)
        Me.Controls.Add(Me.txtAttachment)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.LblSecretKey)
        Me.Controls.Add(Me.LblAccessKey)
        Me.Controls.Add(Me.TxtSecret)
        Me.Controls.Add(Me.TxtKey)
        Me.Controls.Add(Me.LblBody)
        Me.Controls.Add(Me.TxtBody)
        Me.Controls.Add(Me.LblSubject)
        Me.Controls.Add(Me.TxtSubject)
        Me.Controls.Add(Me.LblTo)
        Me.Controls.Add(Me.TxtTo)
        Me.Controls.Add(Me.LblFrom)
        Me.Controls.Add(Me.TxtFrom)
        Me.Controls.Add(Me.LblRegion)
        Me.Controls.Add(Me.CbRegion)
        Me.Controls.Add(Me.ButtonSend)
        Me.Name = "Form1"
        Me.Text = "Send SMTP SES"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents ButtonSend As Button
    Friend WithEvents CbRegion As ComboBox
    Friend WithEvents LblRegion As Label
    Friend WithEvents TxtFrom As TextBox
    Friend WithEvents LblFrom As Label
    Friend WithEvents LblTo As Label
    Friend WithEvents TxtTo As TextBox
    Friend WithEvents LblSubject As Label
    Friend WithEvents TxtSubject As TextBox
    Friend WithEvents LblBody As Label
    Friend WithEvents TxtBody As TextBox
    Friend WithEvents TxtKey As TextBox
    Friend WithEvents TxtSecret As TextBox
    Friend WithEvents LblAccessKey As Label
    Friend WithEvents LblSecretKey As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents txtAttachment As TextBox
    Friend WithEvents lblAttach As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents ButtonSearch As Button
    Friend WithEvents TxtFilePath As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents CheckDelegate As CheckBox
    Friend WithEvents TxtDelegate As TextBox
    Friend WithEvents ButtonSearchFile As Button
End Class
