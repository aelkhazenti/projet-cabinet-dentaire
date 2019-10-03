Imports MySql.Data.MySqlClient

Public Class cherche
    Dim cn As New MySqlConnection
    Dim req As New MySqlCommand
    Dim req1 As New MySqlCommand
    Dim req2 As New MySqlCommand
    Dim datread As MySqlDataReader

    Dim idm As String
    Dim idcah As String
    Dim idrdv As String
    Dim idpatient As String

    Private Shared _instance As cherche
    Public Shared ReadOnly Property instance As cherche

        '----------------------------
        'cree un getter pour exporter la page cherche dans forme 2 

        Get
            If _instance Is Nothing Then
                _instance = New cherche
            End If
            Return _instance
        End Get
    End Property

    Private Sub cherche_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox9.Clear()
        TextBox8.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cn = New MySqlConnection
        cn.ConnectionString = "server= localhost;userid=root;password=;database=projet_vb.net"
        cn.Open()

        '---------------------

        Dim met As New MySqlCommand("SELECT * FROM `patient` WHERE `nom_P`= @nom and `prenom_P`=@pre", cn)
        met.Parameters.Add("@nom", MySqlDbType.VarChar).Value = TextBox1.Text
        met.Parameters.Add("@pre", MySqlDbType.VarChar).Value = TextBox2.Text
        met.ExecuteNonQuery()
        datread = met.ExecuteReader
        If datread.Read Then

            'on enregistremment des cles étrangère dans les variables idrdv,idcah,idm et idpatient
            'pour utilisé dans la partie modification  


            idrdv = datread.GetValue(5)
            idcah = datread.GetValue(6)
            idm = datread.GetValue(7)

            TextBox9.Text = datread.GetValue(1)
            TextBox10.Text = datread.GetValue(2)
            TextBox11.Text = datread.GetValue(3)
            TextBox12.Text = datread.GetValue(4)
            idpatient = datread.GetValue(0)

        End If
        datread.Close()

        Dim qw As New MySqlCommand("SELECT * FROM `mutuelle` WHERE `ID_M`= @nom ", cn)

        '--------------------------

        qw.Parameters.Add("@nom", MySqlDbType.VarChar).Value = idm
        qw.ExecuteNonQuery()
        datread = qw.ExecuteReader
        If datread.Read Then
            TextBox3.Text = datread.GetValue(2)
            TextBox4.Text = datread.GetValue(1)


            If TextBox3.Text = "NULL" And TextBox4.Text = "NULL" Then
                TextBox8.Text = "non"
            Else
                TextBox8.Text = "oui"
            End If
        End If
        datread.Close()

        '-------------------

        Dim cah As New MySqlCommand("SELECT * FROM `cahier_med` WHERE `ID_CM`= @nom ", cn)
        cah.Parameters.Add("@nom", MySqlDbType.VarChar).Value = idcah
        cah.ExecuteNonQuery()
        datread = cah.ExecuteReader
        If datread.Read Then
            TextBox5.Text = datread.GetValue(2)
            TextBox6.Text = datread.GetValue(1)

        End If
        datread.Close()



    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint, Panel4.Paint

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        'la modification de la table Patient

        Dim updpat As New MySqlCommand("UPDATE `patient` SET `nom_P`=@no,`prenom_P`=@pr,`age_P`=@ag,`sex`=@se WHERE `ID_P`=@idpat", cn)
        '   MsgBox(updpat.CommandText)
        updpat.Parameters.Add("@no", MySqlDbType.VarChar).Value = TextBox9.Text
        updpat.Parameters.Add("@pr", MySqlDbType.VarChar).Value = TextBox10.Text
        updpat.Parameters.Add("@ag", MySqlDbType.VarChar).Value = TextBox11.Text
        updpat.Parameters.Add("@se", MySqlDbType.VarChar).Value = TextBox12.Text
        updpat.Parameters.Add("@idpat", MySqlDbType.VarChar).Value = idpatient

        updpat.ExecuteNonQuery()

        'la modification de la table mutuelle

        Dim updmut As New MySqlCommand("UPDATE `mutuelle` SET `num_M`=@nummutt,`nom_M`=@nommutt WHERE ID_M = @m", cn)
        updmut.Parameters.Add("@nummutt", MySqlDbType.Int16).Value = TextBox4.Text
        updmut.Parameters.Add("@nommutt", MySqlDbType.VarChar).Value = TextBox3.Text
        updmut.Parameters.Add("@m", MySqlDbType.Int16).Value = idm
        updmut.ExecuteNonQuery()
        '--------------------------

        'la modification de la table rendez-vous

        Dim updrdv As New MySqlCommand("UPDATE `rdv` SET `date_R`=@upddat WHERE `ID_R`= @idt", cn)
        updrdv.Parameters.Add("@upddat", MySqlDbType.Date).Value = DateTimePicker1.Text
        updrdv.Parameters.Add("@idt", MySqlDbType.Int16).Value = idrdv
        updrdv.ExecuteNonQuery()
        '--------------------------


        'la modification de la table cahier medical

        Dim updcah As New MySqlCommand(" UPDATE `cahier_med` SET `maladi_CM`=@malad,`note_de_doc`=@notdoc WHERE  ID_CM = @ca", cn)
        updcah.Parameters.Add("@malad", MySqlDbType.VarChar).Value = TextBox6.Text
        updcah.Parameters.Add("@notdoc", MySqlDbType.VarChar).Value = TextBox5.Text
        updcah.Parameters.Add("@ca", MySqlDbType.Int16).Value = idcah

        MsgBox("la modification raussi")

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs)

    End Sub

End Class
