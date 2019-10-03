Imports MySql.Data.MySqlClient

Public Class docteur1
    Dim cn As New MySqlConnection
    Dim req As New MySqlCommand
    Dim req1 As New MySqlCommand
    Dim req2 As New MySqlCommand
    Dim datread As MySqlDataReader
    Dim idcah As String

    Dim iddoc As String
    Private Shared _instance As docteur1
    Public Shared ReadOnly Property instance As docteur1
        '----------------------------
        'cree un getter pour exporter la page docteur dans forme 2 

        Get
            If _instance Is Nothing Then
                _instance = New docteur1
            End If
            Return _instance
        End Get
    End Property

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub docteur1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New MySqlConnection
        cn.ConnectionString = "server= localhost;userid=root;password=;database=projet_vb.net"
        cn.Open()




        Dim med As New MySqlCommand("SELECT * FROM `docteur` WHERE `nom_D`= @mala", cn)
        med.Parameters.Add("@mala", MySqlDbType.VarChar).Value = Form1.TextBox1.Text
        med.ExecuteNonQuery()
        datread = med.ExecuteReader
        If datread.Read Then

            Label7.Text = datread.GetValue(3)

        End If
        ' MsgBox(test)
        datread.Close()


        Label6.Text = Form1.TextBox1.Text
    End Sub
End Class

