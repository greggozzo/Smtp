

Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class Cryptography
    Public Shared Function Encrypt(ByVal clearText As String) As String
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Dim rand As New Random()
        Using encryptor As Aes = Aes.Create()
            Dim IV As Byte() = New Byte(14) {}
            rand.NextBytes(IV)
           ' Dim pdb As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(----EncryptionKey----, IV)
            'encryptor.Key = pdb.GetBytes(32)
            'encryptor.IV = pdb.GetBytes(16)

            Using ms As MemoryStream = New MemoryStream()

                Using cs As CryptoStream = New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using

                clearText = Convert.ToBase64String(IV) + Convert.ToBase64String(ms.ToArray())
            End Using
        End Using

        Return clearText
    End Function
    Public Shared Function Decrypt(ByVal cipherText As String) As String
        Dim IV As Byte() = Convert.FromBase64String(cipherText.Substring(0, 20))
        cipherText = cipherText.Substring(20).Replace(" ", "+")
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)

        Using encryptor As Aes = Aes.Create()
            'Dim pdb As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(----EncryptionKey----, IV)
            'encryptor.Key = pdb.GetBytes(32)
            'encryptor.IV = pdb.GetBytes(16)

            Using ms As MemoryStream = New MemoryStream()

                Using cs As CryptoStream = New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using

                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using

        Return cipherText
    End Function
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
End Class
