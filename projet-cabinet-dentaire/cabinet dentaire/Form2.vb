Imports MySql.Data.MySqlClient


Public Class Form2

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        'pour importer la page Home dans le panel 

        If Not Panel1.Controls.Contains(docteur1.instance) Then
            Panel1.Controls.Add(docteur1.instance)
            docteur1.instance.Dock = DockStyle.Fill
            docteur1.instance.BringToFront()
            docteur1.instance.Visible = True

        End If
        docteur1.instance.BringToFront()
        docteur1.instance.Visible = True
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Label5.Text = DateTime.Now

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form1.Show()
        Form1.TextBox1.Clear()
        Form1.TextBox2.Clear()

    End Sub


    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        'pour importer la page nouveau dans le panel 

        If Not Panel1.Controls.Contains(nouv.instance) Then
            Panel1.Controls.Add(nouv.instance)
            nouv.instance.Dock = DockStyle.Fill
            nouv.instance.BringToFront()
            nouv.instance.Visible = True

        End If
        nouv.instance.BringToFront()
        nouv.instance.Visible = True

    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'pour importer la page le file d'attente dans le panel 

        If Not Panel1.Controls.Contains(fils.instance) Then
            Panel1.Controls.Add(fils.instance)
            fils.instance.Dock = DockStyle.Fill
            fils.instance.BringToFront()
            fils.instance.Visible = True

        End If
        fils.instance.BringToFront()
        fils.instance.Visible = True

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'pour importer la page modifie dans le panel 
        If Not Panel1.Controls.Contains(cherche.instance) Then
            Panel1.Controls.Add(cherche.instance)
            cherche.instance.Dock = DockStyle.Fill
            cherche.instance.BringToFront()
            cherche.instance.Visible = True

        End If
        cherche.instance.BringToFront()
        cherche.instance.Visible = True
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

        If Not Panel1.Controls.Contains(docteur1.instance) Then
            Panel1.Controls.Add(docteur1.instance)
            docteur1.instance.Dock = DockStyle.Fill
            docteur1.instance.BringToFront()
            docteur1.instance.Visible = True

        End If
        docteur1.instance.BringToFront()
        docteur1.instance.Visible = True


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        'pour importer la page checher dans le panel 

        If Not Panel1.Controls.Contains(modif.instance) Then
            Panel1.Controls.Add(modif.instance)
            modif.instance.Dock = DockStyle.Fill
            modif.instance.BringToFront()
            modif.instance.Visible = True

        End If
        modif.instance.BringToFront()
        modif.instance.Visible = True
    End Sub
End Class