Imports Microsoft.VisualBasic.FileIO
Public Class Form1
    Private Sub loadForm(sender As Object, e As EventArgs) Handles MyBase.Load
        With CbRegion      
            .Items.Add("Choose Region")
            .Items.Add("email-smtp.us-east-1.amazonaws.com")
            .Items.Add("email-smtp.us-east-2.amazonaws.com")
            .Items.Add("email-smtp.us-west-1.amazonaws.com")
            .Items.Add("email-smtp.us-west-2.amazonaws.com")
            .Items.Add("email-smtp.ap-south-1.amazonaws.com")
            .Items.Add("email-smtp.ap-northeast-3.amazonaws.com")
            .Items.Add("email-smtp.ap-northeast-2.amazonaws.com")
            .Items.Add("email-smtp.ap-southeast-1.amazonaws.com")
            .Items.Add("email-smtp.ap-southeast-2.amazonaws.com")
            .Items.Add("email-smtp.ap-northeast-1.amazonaws.com")
            .Items.Add("email-smtp.ca-central-1.amazonaws.com")
            .Items.Add("email-smtp.eu-central-1.amazonaws.com")
            .Items.Add("email-smtp.eu-west-1.amazonaws.com")
            .Items.Add("email-smtp.eu-west-2.amazonaws.com")
            .Items.Add("email-smtp.eu-west-3.amazonaws.com")
            .Items.Add("email-smtp.eu-north-1.amazonaws.com")
            .Items.Add("email-smtp.sa-east-1.amazonaws.com")
            .Items.Add("email-smtp.us-gov-west-1.amazonaws.com") 
        End With
        CbRegion.SelectedIndex = 0  
        TxtBody.Text = "This is a Test"
    End Sub
    Private Sub ButtonSend_Click(sender As Object, e As EventArgs) Handles ButtonSend.Click
        Dim username As String = TxtKey.Text
        Dim password As String = TxtSecret.Text
        Dim host As String = CbRegion.SelectedItem
        Dim port As Integer = 587
        Dim sFrom As String =  TxtFrom.Text
        Dim sTo As String = TxtTo.Text
        Dim sSubject As String = TxtSubject.Text
        Dim sBody As String = TxtBody.Text

        If CheckBox1.Checked = True Then
            username= getUserName()
            password= getUserPass()
        End If
        If CbRegion.Text = "Choose Region" Then
            MsgBox("Please Select Region")
            Exit Sub
        End If
        If username = "" Then
            MsgBox("User Name Is Empty")
            Exit Sub
        End If
        If password = "" Then
            MsgBox("Access Secret KeyIs Empty")
            Exit Sub
        End If

        if checkString(sTo, sFrom, sSubject, sBody) > 0 Then
            Exit Sub
        End If

    Using client = New System.Net.Mail.SmtpClient(host, port)
        client.Credentials = New System.Net.NetworkCredential(username, password)
        client.EnableSsl = True
        client.Send(sFrom, sto, sSubject, sBody)        
    End Using

    End Sub
    Private Function getUserPass()
        Dim accesskey As String = ""
        Using myReader As New TextFieldParser(TxtFilePath.Text) 
            myReader.TextFieldType = FieldType.Delimited
            myReader.SetDelimiters(",")
            Dim currentRow As String()
            myReader.ReadLine.Skip(1)
            While Not myReader.EndOfData
                Try
                    currentRow = myReader.ReadFields()
                    accesskey = currentRow(2)
                Catch ex As Exception

                End Try
            End While
        End Using
        Return accesskey

    End Function
    Private Function getUserName() 
        Dim accessID As String = ""
           Using myReader As New TextFieldParser(TxtFilePath.Text) 
            myReader.TextFieldType = FieldType.Delimited
            myReader.SetDelimiters(",")
            Dim currentRow As String()
            myReader.ReadLine.Skip(1)
            While Not myReader.EndOfData
                Try
                    currentRow = myReader.ReadFields()
                    accessID = currentRow(1)
                Catch ex As Exception

                End Try
            End While
        End Using
        Return accessID

    End Function
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        TxtFilePath.Visible = True
        TxtFilePath.Text = "enter full file path here"
    End Sub
    Private Sub TxtFilePath_GotFocus() Handles TxtFilePath.GotFocus
    TxtFilePath.Text = ""
    End Sub
    Private Function checkString(sTo As String, sFrom As String, sSubject As String, sBody As String)
        Dim yesFlag As Integer = 0
        If sTo = "" Then
            MsgBox("Please Enter To Address")
            yesFlag +=1
        End If
        If sFrom = "" Then
            MsgBox("Please Enter From Address")
            yesFlag +=1
        End If   
        If sSubject = "" Then
            MsgBox("Please Enter Subject")
            yesFlag +=1
        End If
        If sBody = "" Then
            MsgBox("Please Enter Body")
            yesFlag +=1
        End If
        Return yesFlag
    End Function

    Private Sub TxtBody_GotFocus(sender As Object, e As EventArgs) Handles TxtBody.GotFocus
        TxtBody.Text = ""
    End Sub
End Class
