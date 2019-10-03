Imports MySql.Data.MySqlClient

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.UseSystemPasswordChar = True
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cn As New MySqlConnection
        cn = New MySqlConnection

        Dim req3 As New MySqlCommand

        cn.ConnectionString = "server= localhost;userid=root;password=;database=projet_vb.net"
        cn.Open()

        Dim READER As MySqlDataReader



        Dim Query As String
        Query = "select * from docteur where nom_D='" & TextBox1.Text & "' and mdp_D='" & TextBox2.Text & "' "
        req3 = New MySqlCommand(Query, cn)
        READER = req3.ExecuteReader
        Dim count As Integer
        count = 0

        ' on ajoute un compteur pour varifier si le nom d'utilisateur et le mot de passe
        ' existe ou pas et il accepte seulement si le compteur = 1 

        While READER.Read
            count = count + 1

        End While

        If count = 1 Then

            Me.Hide()
            Form2.Show()

            Form2.Label3.Text = Me.TextBox1.Text()

        Else
            MsgBox("le mote de passe ou le nom d'utilisateur et incorect")

        End If



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        End
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click, PictureBox6.Click

        'pour affiche le mot de passe

        If TextBox2.UseSystemPasswordChar = True Then

            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub
End Class
