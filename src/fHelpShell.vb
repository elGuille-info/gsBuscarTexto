'------------------------------------------------------------------------------
' Formulario para mostrar la ayuda de la línea de comandos          (07/Feb/08)
'
' ©Guillermo 'guille' Som, 2008
'------------------------------------------------------------------------------
Option Strict On
Option Infer Off

Imports System
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports elGuille.BuscarTexto.elGuille.info.Util.Utilidades

Public Class fHelpShell

    Public Sub Mostrar(Optional ByVal desplazar As Boolean = False)
        If desplazar Then
            Dim i As Integer = My.Forms.Form1.Left + My.Forms.Form1.Width - Me.Width \ 4
            If i > Screen.PrimaryScreen.WorkingArea.Width Then
                i = My.Forms.Form1.Left - Me.Width \ 4
            End If
            Me.Left = i
            Me.Top = My.Forms.Form1.Top + My.Forms.Form1.Height - Me.Height \ 4
        Else
            Me.Left = My.Forms.Form1.Left + (My.Forms.Form1.Width - Me.Width) \ 2
            Me.Top = My.Forms.Form1.Top + (My.Forms.Form1.Height - Me.Height) \ 2
        End If
        BringToFront()
    End Sub

    Private Sub fHelpShell_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BackColor = System.Drawing.Color.Black
        txtTitulo.Text = My.Application.Info.Title & _
                         " v" & My.Application.Info.Version.ToString & _
                         " (rev " & FileVersion & ")" & vbCrLf & _
                         "©Guillermo 'guille' Som, 2007-" & If(Year(Now) < 2008, "2008", Year(Now).ToString)
        txtInfo.Text = txtInfo.Text.Replace("%APP%", My.Application.Info.Title)
        'BringToFront()
        Mostrar()
    End Sub
End Class