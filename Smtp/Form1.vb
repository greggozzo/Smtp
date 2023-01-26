Imports System.IO
Imports System
Imports System.Text
Imports System.Security.Cryptography
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
        Dim sFrom As String = TxtFrom.Text
        Dim sTo As String = TxtTo.Text
        Dim sSubject As String = TxtSubject.Text
        Dim sBody As String = TxtBody.Text

        
        If CheckBox1.Checked = True Then
            username = getUserName()
            password = getUserPass()
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

        If checkString(sTo, sFrom, sSubject, sBody) > 0 Then
            Exit Sub
        End If
        Try
            Using client = New System.Net.Mail.SmtpClient(host, port)
            client.Credentials = New System.Net.NetworkCredential(username, password)
            client.EnableSsl = True
            client.Send(sFrom, sTo, sSubject, sBody)
             End Using
        Catch ex As Exception
            MessageBox.show(ex.Message)
        End Try
        If CheckSavePW.Checked = True Then
           SavePass(password)
           SaveUser(username)
        End If
        
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
            yesFlag += 1
        End If
        If sFrom = "" Then
            MsgBox("Please Enter From Address")
            yesFlag += 1
        End If
        If sSubject = "" Then
            MsgBox("Please Enter Subject")
            yesFlag += 1
        End If
        If sBody = "" Then
            MsgBox("Please Enter Body")
            yesFlag += 1
        End If
        Return yesFlag
    End Function

    Private Sub TxtBody_GotFocus(sender As Object, e As EventArgs) Handles TxtBody.GotFocus
        TxtBody.Text = ""
    End Sub
    Public Function EncryptString(ByVal inputString As String) As String
    Dim memStream As MemoryStream = Nothing
   
    
    Try
        Dim key As Byte() = {}
        Dim IV As Byte() = {12, 21, 43, 17, 57, 35, 67, 27}
        Dim encryptKey As String = "aXb2uy4z"
        key = Encoding.UTF8.GetBytes(encryptKey)
        Dim byteInput As Byte() = Encoding.UTF8.GetBytes(inputString)
        Dim provider As DESCryptoServiceProvider = New DESCryptoServiceProvider()
        memStream = New MemoryStream()
        Dim transform As ICryptoTransform = provider.CreateEncryptor(key, IV)
        Dim cryptoStream As CryptoStream = New CryptoStream(memStream, transform, CryptoStreamMode.Write)
        cryptoStream.Write(byteInput, 0, byteInput.Length)
        cryptoStream.FlushFinalBlock()
    Catch ex As Exception
        MessageBox.Show(ex.Message)
    End Try
        
    Return Convert.ToBase64String(memStream.ToArray())

End Function
    Public Function DecryptString(ByVal inputString As String) As String
    Dim memStream As MemoryStream = Nothing

    Try
        Dim key As Byte() = {}
        Dim IV As Byte() = {12, 21, 43, 17, 57, 35, 67, 27}
        Dim encryptKey As String = "aXb2uy4z"
        key = Encoding.UTF8.GetBytes(encryptKey)
        Dim byteInput As Byte() = New Byte(inputString.Length - 1) {}
        byteInput = Convert.FromBase64String(inputString)
        Dim provider As DESCryptoServiceProvider = New DESCryptoServiceProvider()
        memStream = New MemoryStream()
        Dim transform As ICryptoTransform = provider.CreateDecryptor(key, IV)
        Dim cryptoStream As CryptoStream = New CryptoStream(memStream, transform, CryptoStreamMode.Write)
        cryptoStream.Write(byteInput, 0, byteInput.Length)
        cryptoStream.FlushFinalBlock()
    Catch ex As Exception
        MessageBox.Show(ex.Message)
    End Try

    Dim encoding1 As Encoding = Encoding.UTF8
    Return encoding1.GetString(memStream.ToArray())
End Function
    Private Function removeQuotes(filePath As string) As String
        filePath.Replace("""", "").Trim()
        Return filePath
    End Function
    Private Sub SaveUser(stringIn As String)
         Dim savefilePath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
         Dim fileName As String = "SMTP-Setting.txt"
           File.AppendAllText(savefilePath & "\" & fileName, vbCrLf & stringIn)
    End Sub
      Private Sub SavePass(stringIn As String)
         Dim savefilePath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
         Dim fileName As String = "SMTP-Setting.txt"
        Dim encryptedP As String = EncryptString(stringIn)
           File.WriteAllText(savefilePath & "\" & fileName, encryptedP)
    End Sub


    ''''next check if file is empty and grab credentials and decrypt pass word''''
End Class
