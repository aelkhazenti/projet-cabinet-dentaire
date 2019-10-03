Imports MySql.Data.MySqlClient


Public Class fils

    Dim cn As New MySqlConnection
    Dim req As New MySqlCommand
    Dim req1 As New MySqlCommand
    Dim req2 As New MySqlCommand
    Dim datread As MySqlDataReader

    Dim idrdv As String
    Dim idcah As String
    Dim count As Integer
    Dim i As Integer
    Private Shared _instance As fils
    Public Shared ReadOnly Property instance As fils
        '----------------------------
        'cree un getter pour exporter la page file attete dans forme 2 

        Get
            If _instance Is Nothing Then
                _instance = New fils
            End If
            Return _instance
        End Get
    End Property

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        DataGridView1.ClearSelection()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cn = New MySqlConnection
        cn.ConnectionString = "server= localhost;userid=root;password=;database=projet_vb.net"
        cn.Open()
        count = 0
        Dim met As New MySqlCommand("SELECT * FROM `rdv` WHERE `date_R`= @dat ", cn)
        met.Parameters.Add("@dat", MySqlDbType.Date).Value = DateTimePicker1.Text

        met.ExecuteNonQuery()
        datread = met.ExecuteReader
        While datread.Read
            idrdv = datread.GetValue(0)
            count = count + 1
        End While

        'on ajoute un compteur pour affiche le nombre de rendez-vous
        'et aussi pour affiche un message si il y'a aucun enregistremment 

        datread.Close()
        If count < 1 Then
            MsgBox("aucun rendez-vous dans cette date")
            i = 0
            Dim table As New DataTable
            DataGridView1.DataSource = table
            Label4.Text = i
        Else
            Dim pati As New MySqlCommand("SELECT * FROM `patient` WHERE  `ID_R`= @nom ", cn)
            pati.Parameters.Add("@nom", MySqlDbType.VarChar).Value = idrdv
            pati.ExecuteNonQuery()
            datread = pati.ExecuteReader

            While datread.Read

                i = i + 1

            End While
            datread.Close()

            If i >= 0 Then
                Dim table As New DataTable
                Dim adapt As New MySqlDataAdapter("SELECT `nom_P`,`prenom_P`,`age_P`,`sex` FROM `patient` WHERE  `ID_R`= '" & idrdv & "'", cn)
                adapt.Fill(table)
                DataGridView1.DataSource = table
                Label4.Text = i
            Else

            End If

        End If



    End Sub

    Private Sub fils_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

