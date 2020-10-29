'------------------------------------------------------------------------------
' Formulario para ver los ficheros modificados al reemplazar        (10/Feb/08)
'
' ©Guillermo 'guille' Som, 2008
'------------------------------------------------------------------------------
Option Strict On
Option Infer On

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.IO

Public Class fReemplazados

    Public CerrarSinGuardar As Boolean
    Private guardado As Boolean = False

    Public Sub New(ByVal ficOriginal As FileInfo, ByVal nuevoTexto As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtOriginal.Text = ficOriginal.FullName
        txtNuevo.Text = Path.GetFileNameWithoutExtension(ficOriginal.Name) & " - Copia" & ficOriginal.Extension
        Me.Text = txtNuevo.Text

        rtbNuevo.Text = nuevoTexto
        If ficOriginal.Extension.ToLower = ".txt" Then
            rtbOriginal.LoadFile(ficOriginal.FullName, RichTextBoxStreamType.PlainText)
        ElseIf ficOriginal.Extension.ToLower = ".rtf" Then
            rtbOriginal.LoadFile(ficOriginal.FullName, RichTextBoxStreamType.RichText)
        Else
            rtbOriginal.Text = File.OpenText(ficOriginal.FullName).ReadToEnd()
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, _
                                 ByVal e As EventArgs) _
                                 Handles btnGuardar.Click
        Dim sFD As New SaveFileDialog
        With sFD
            .Title = "Guardar el texto modificado"
            .Filter = "Fichero de texto (*.txt)|*.txt|RTF (*.rtf)|*.rtf"
            .AddExtension = True
            .CheckPathExists = True
            .SupportMultiDottedExtensions = False
            .FileName = txtNuevo.Text
            .InitialDirectory = Path.GetDirectoryName(txtOriginal.Text)
            .OverwritePrompt = True
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                txtNuevo.Text = .FileName
                GuardarAuto()
            End If
        End With
    End Sub

    Public Sub Guardar()
        btnGuardar_Click(Nothing, Nothing)
    End Sub

    Public Sub GuardarAuto()
        If Path.GetExtension(txtNuevo.Text).ToLower = ".txt" Then
            rtbNuevo.SaveFile(txtNuevo.Text, RichTextBoxStreamType.PlainText)
        Else
            rtbNuevo.SaveFile(txtNuevo.Text, RichTextBoxStreamType.RichText)
        End If
        guardado = True
    End Sub

    Private Sub fReemplazados_FormClosing(ByVal sender As Object, _
                                          ByVal e As FormClosingEventArgs) _
                                          Handles Me.FormClosing
        If CerrarSinGuardar Then Exit Sub

        If guardado = False Then
            Dim ret As DialogResult
            ret = MessageBox.Show("El nuevo texto no se ha guardado." & vbCrLf & _
                                  "¿Quieres guardarlo?", _
                                  "Mostrar ficheros modificados", _
                                  MessageBoxButtons.YesNoCancel, _
                                  MessageBoxIcon.Question)
            If ret = Windows.Forms.DialogResult.Cancel Then
                e.Cancel = True
                Exit Sub
            End If
            If ret = Windows.Forms.DialogResult.Yes Then
                btnGuardar_Click(Nothing, Nothing)
            End If
        End If
    End Sub
End Class