Imports Microsoft.VisualBasic.FileIO
Public Class Form1
    Private Sub loadForm(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable

        dt.Columns.AddRange(New DataColumn() {New DataColumn With {.ColumnName = "Endpoint", .DataType = GetType(String)} _
                                                , New DataColumn With {.ColumnName = "Region", .DataType = GetType(String)} _
                                                })
        
        dt.Rows.Add("Choose Region", "Choose Region")
        dt.Rows.Add("email-smtp.us-east-1.amazonaws.com", "US-East-1")
        dt.Rows.Add("email-smtp.us-east-2.amazonaws.com", "US-East-2")
        dt.Rows.Add("email-smtp.us-west-1.amazonaws.com","US-West-1")
        dt.Rows.Add("email-smtp.us-west-2.amazonaws.com", "US-West-2")                
        dt.Rows.Add("email-smtp.eu-west-1.amazonaws.com", "EU-West-1")
        dt.Rows.Add("email-smtp.eu-west-2.amazonaws.com", "EU-West-2")
        dt.Rows.Add("email-smtp.eu-west-3.amazonaws.com", "EU-West-3")
        dt.Rows.Add("email-smtp.eu-north-1.amazonaws.com", "EU-North-1")
        dt.Rows.Add("email-smtp.eu-central-1.amazonaws.com", "EU-Central-1")
        dt.Rows.Add("email-smtp.ap-northeast-1.amazonaws.com", "AP-NorthEast-1")
        dt.Rows.Add("email-smtp.ap-northeast-2.amazonaws.com", "AP-NorthEast-2")
        dt.Rows.Add("email-smtp.ap-northeast-3.amazonaws.com", "AP-NorthEast-3")                
        dt.Rows.Add("email-smtp.ap-southeast-1.amazonaws.com", "AP-SouthEast-1")
        dt.Rows.Add("email-smtp.ap-southeast-2.amazonaws.com", "AP-SouthEast-2")                
        dt.Rows.Add("email-smtp.ap-south-1.amazonaws.com", "AP-South-1")
        dt.Rows.Add("email-smtp.ca-central-1.amazonaws.com", "CA-Central-1")                
        dt.Rows.Add("email-smtp.sa-east-1.amazonaws.com", "SA-East-1")
        dt.Rows.Add("email-smtp.us-gov-west-1.amazonaws.com", "US-GOV-West-1")
        
        CbRegion.DataSource = dt        
        CbRegion.DisplayMember = "Region"        
        CbRegion.ValueMember = "Endpoint"    
        CbRegion.SelectedIndex = 0
        TxtBody.Text = "This is a Test"
        ButtonSearch.Visible = False
        TxtFilePath.Visible =False
    End Sub
    Private Sub ButtonSend_Click(sender As Object, e As EventArgs) Handles ButtonSend.Click
        Dim username As String = TxtKey.Text
        Dim password As String = TxtSecret.Text
        Dim host As String = CbRegion.SelectedValue
        Dim port As Integer = 587
        Dim From As String = TxtFrom.Text
        Dim sTo As String = TxtTo.Text
        Dim Subject As String = TxtSubject.Text
        Dim Body As String = TxtBody.Text
        
        If CheckBox1.Checked = True Then
            username = getUserName()
            password = getUserPass()
        End If

        If CheckTextBoxEmpty(CbRegion.Text, username, password) > 0 Then
            Exit Sub
        End If

        If CheckEmailStrings(sTo, From, Subject, Body) > 0 Then
            Exit Sub
        End If
        Dim mailMessage = New Net.Mail.MailMessage
        mailMessage.From = New Net.Mail.MailAddress(From)
        mailMessage.To.Add(sTo)
        mailMessage.Subject = Subject
        mailMessage.Body = Body
        Try
            Using client = New Net.Mail.SmtpClient(host, port)
                client.Credentials = New System.Net.NetworkCredential(username, password)
                client.EnableSsl = True
                If txtAttachment.Text IsNot "" Then
                    Dim file As String = txtAttachment.Text                    
                    Dim attachment As Net.Mail.Attachment 
                    attachment = New Net.Mail.Attachment(file)
                    mailMessage.Attachments.Add(attachment)
                End If
                If CheckDelegate.Checked Then
                   Dim headerARN As String = TxtDelegate.Text 
                   mailMessage.Headers.Add("X-SES-SOURCE-ARN", headerARN)
                   mailMessage.Headers.Add("X-SES-FROM-ARN", headerARN)
                   mailMessage.Headers.Add("X-SES-RETURN-PATH-ARN", headerARN)
                End If                
                client.Send(mailMessage)
            End Using
            MsgBox("Sent successful!")
        Catch ex As Exception
            MessageBox.show(ex.Message)
        End Try
    End Sub
    Private Function getUserPass()
        Dim accesskey As String = ""
        Dim filePath As String = TxtFilePath.Text
        filePath = filePath.Replace("""", "").Trim()
        Using myReader As New TextFieldParser(filePath)
            myReader.TextFieldType = FieldType.Delimited
            myReader.SetDelimiters(",")
            Dim currentRow As String()
            myReader.ReadLine.Skip(1)
            While Not myReader.EndOfData
                Try
                    currentRow = myReader.ReadFields()
                    accesskey = currentRow(2)
                Catch ex As Exception
                    MsgBox("Could not get password from csv file.")
                End Try
            End While
        End Using

        Return accesskey

    End Function
    Private Function getUserName()
        Dim accessID As String = ""
        Dim filePath As String = TxtFilePath.Text

        filePath = filePath.Replace("""", "").Trim()

        Using myReader As New TextFieldParser(filePath)
            myReader.TextFieldType = FieldType.Delimited
            myReader.SetDelimiters(",")
            Dim currentRow As String()
            myReader.ReadLine.Skip(1)
            While Not myReader.EndOfData
                Try
                    currentRow = myReader.ReadFields()
                    accessID = currentRow(1)
                Catch ex As Exception
                    MsgBox("Could not get Username from csv file.")
                End Try
            End While
        End Using

        Return accessID

    End Function

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        TxtFilePath.Visible = True
        ButtonSearch.Visible = True
    End Sub   
    Private Function CheckEmailStrings(sTo As String, sFrom As String, sSubject As String, sBody As String)
        Dim count As Integer =0
        If sTo = "" Then
            MsgBox("Please Enter To Address")
            count = 1
            Exit Function
        End If
        If sFrom = "" Then
            MsgBox("Please Enter From Address")  
            count +=1
            Exit Function
        End If
        If sSubject = "" Then
            MsgBox("Please Enter Subject")  
            count +=1
            Exit Function
        End If
        If sBody = "" Then
            MsgBox("Please Enter Body")
            count +=1
            Exit Function
        End If
       Return count
    End Function
    Private Function CheckTextBoxEmpty(CbRegion As String, userName As String, password As String)
        Dim count As Integer =0
        If CbRegion = "Choose Region" Then
            MsgBox("Please Select Region")
            count +=1
            Exit Function
        End If
        If username = "" Then
            MsgBox("User Name Is Empty")
            count +=1
            Exit Function
        End If
        If password = "" Then
            MsgBox("Access Secret KeyIs Empty")
            count +=1
            Exit Function
        End If
        Return count
    End Function
 
    Private Function removeQuotes(filePath As string) As String
        filePath.Replace("""", "").Trim()
        Return filePath
    End Function 

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            TxtFilePath.Text = OpenFileDialog1.FileName
        End If
    End Sub
    Private Sub TxtDelegate_GotFocus() Handles TxtDelegate.GotFocus
        If TxtDelegate.Text = "Identity ARN"  Then
            TxtDelegate.Text = ""
        End If
    End Sub

    Private Sub ButtonSearchFile_Click(sender As Object, e As EventArgs) Handles ButtonSearchFile.Click
          If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            txtAttachment.Text = OpenFileDialog1.FileName
        End If
    End Sub
End Class