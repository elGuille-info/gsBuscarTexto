'------------------------------------------------------------------------------
' Configuración para gsBuscarTextos                                 (07/Feb/08)
'
' ©Guillermo 'guille' Som, 2008, 2020
'------------------------------------------------------------------------------
Option Strict On
Option Infer On

Imports Microsoft.VisualBasic
Imports vb = Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.Win32
Imports System.Collections.Generic

Imports elGuille.BuscarTexto.elGuille.info.Util.Utilidades

Public Class fBuscarCfg

    Private m_ExtensionesNO As New System.Collections.Generic.List(Of String)
    Private m_DirCfg As String
    Private deshaciendo As Boolean = False

    Private Const programa As String = "gsBuscarTexto"

    Private Sub fBuscarCfg_Load() Handles MyBase.Load

        picReemplazar.Top = grbReemplazar.Top
        picReemplazar.Left = grbReemplazar.Left + 7

        ' Si es administrador
        If EsAdministrador Then 'If chkShell.Enabled Then
            picAdmin.Image = My.Resources.escudo16_OK
            picAdmin.ToolTipText = "Ejecutando como administrador"
            picReemplazar.Image = My.Resources.escudo16_OK
            grbReemplazar.Enabled = True
            toolTip1.SetToolTip(picReemplazar, "")
        Else
            picAdmin.Image = My.Resources.escudo16_Exclamation
            picAdmin.ToolTipText = "No estás ejecutando como administrador."
            ' Las opciones de reemplazar                            (08/Feb/08)
            picReemplazar.Image = My.Resources.escudo16_Exclamation
            grbReemplazar.Enabled = False
            toolTip1.SetToolTip(picReemplazar, "Estas opciones solo están disponibles cuando ejecutas la aplicación como administrador")
        End If
        '' Para probar
        'picReemplazar.Image = My.Resources.escudo16_Exclamation
        'grbReemplazar.Enabled = False
        'toolTip1.SetToolTip(picReemplazar, "Estas opciones solo están disponibles cuando ejecutas la aplicación como administrador")
        LabelInfo.Text = picAdmin.ToolTipText

        m_DirCfg = My.Settings.dirConfig

        ' Las opciones de las extensiones                           (09/Feb/08)
        toolTip1.SetToolTip(LabelExtensiones, toolTip1.GetToolTip(LabelExtensiones) & " " & My.Settings.ExtensionesNo)

        Dim ext1() As String = My.Settings.ExtensionesNo.Split(";".ToCharArray, StringSplitOptions.RemoveEmptyEntries)
        For Each s In ext1
            m_ExtensionesNO.Add(s.ToLower.Trim)
        Next

        ' Asignar los items del combo de abrir con                  (02/Nov/20)

        Dim m_Cfg = Form1.m_Cfg
        Dim cuantos = m_Cfg.GetValue("AbrirCon", "Count", 0)
        cboAbrirCon.Items.Clear()

        For i = 0 To cuantos - 1
            Dim s = m_Cfg.GetValue("AbrirCon", $"Item_{i}", "")
            If String.IsNullOrEmpty(s) Then Continue For
            cboAbrirCon.Items.Add(s)
        Next
        If cboAbrirCon.Items.Contains(My.Settings.AbrirCon) = False Then
            cboAbrirCon.Items.Add(My.Settings.AbrirCon)
        End If
        cboAbrirCon.Text = m_Cfg.GetValue("General", "AbrirCon", My.Settings.AbrirCon)

        btnDeshacer_Click()
    End Sub

    Private Sub btnAceptar_Click() Handles btnAceptar.Click
        With My.Settings
            .usarMisDocumentos = optDirDocumentos.Checked
            .dirConfig = Me.txtDirPersonal.Text
            ' Para las opciones de reemplazar                       (08/Feb/08)
            .chkPermitirReemplazar = Me.chkPermitirReemplazar.Checked
            .chkHacerCopiaReemplazar = Me.chkHacerCopiaReemplazar.Checked
            .DirBackupReemplazar = Me.txtDirBackupReemplazar.Text

            ' Si se guardan automáticamente al reemplazar           (28/Dic/12)
            .chkGuardarAutomaticamente = Me.chkGuardarAutomaticamente.Checked

            ' Comprobar que no tenga las extensiones no permitidas  (10/Feb/08)
            .Extensiones = comprobarExtensiones()
            ' Opciones de excluir directorios                       (26/Feb/08)
            .chkExcluirDir = chkExcluirDir.Checked
            .txtExcluirDir = txtExcluirDir.Text

            ' Guardar en el fichero de configuración                (02/Nov/20)
            ' los valores indicados para AbrirCon

            .AbrirCon = cboAbrirCon.Text

            ' Usar el objeto compartido                             (02/Nov/20)
            ' porque si no se cierra, estas asignaciones no prevalecen
            Dim m_Cfg = Form1.m_Cfg

            m_Cfg.SetValue("General", "AbrirCon", .AbrirCon)
            Dim cuantos = -1
            For i = 0 To cboAbrirCon.Items.Count - 1
                Dim s = cboAbrirCon.Items(i).ToString
                If String.IsNullOrEmpty(s) Then Continue For
                cuantos += 1
                m_Cfg.SetValue("AbrirCon", $"Item_{i}", s)
            Next
            m_Cfg.SetValue("AbrirCon", "Count", cuantos + 1)
            m_Cfg.Save()

            .Save()
        End With

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancelar_Click() Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnRestaurarVentana_Click() Handles btnRestaurarVentana.Click
        ' w, h 660; 541'515
        With My.Settings
            .Size = New Size(660, 541)
            My.Forms.Form1.Size = .Size
        End With
    End Sub

    Private Sub btnExaminar_Click() Handles btnExaminar.Click
        Dim fbd As New FolderBrowserDialog

        Dim dirCfg As String = Me.txtDirPersonal.Text

        If String.IsNullOrEmpty(dirCfg) Then
            dirCfg = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        End If
        If dirCfg.ToLower().Contains(My.Application.Info.ProductName.ToLower()) = False Then
            dirCfg = System.IO.Path.Combine(dirCfg, My.Application.Info.ProductName)
        End If

        With fbd
            .Description = "Seleccionar directorio para guardar la configuración"
            .RootFolder = Environment.SpecialFolder.Desktop
            .ShowNewFolderButton = True
            .SelectedPath = dirCfg
            If .ShowDialog() = DialogResult.OK Then
                dirCfg = .SelectedPath
                ' Comprobar si incluye el ProductName
                ' si no es así, agregarlo
                If dirCfg.ToLower().Contains(My.Application.Info.ProductName.ToLower()) = False Then
                    dirCfg = System.IO.Path.Combine(.SelectedPath, My.Application.Info.ProductName)
                End If
                Me.optDirPersonalizado.Checked = True
                Me.optDirDocumentos.Checked = False
                ' Crear el directorio con el nombre de la aplicación
                Try
                    If My.Computer.FileSystem.DirectoryExists(dirCfg) = False Then
                        My.Computer.FileSystem.CreateDirectory(dirCfg)
                    End If
                Catch ex As Exception
                    ' Si da error al crear el path indicado, usar el de documentos
                    dirCfg = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & My.Application.Info.ProductName
                    Me.optDirPersonalizado.Checked = False
                    Me.optDirDocumentos.Checked = True
                End Try

                Me.txtDirPersonal.Text = dirCfg
            End If
        End With
    End Sub

    Private Sub optDirPersonalizado_CheckedChanged() Handles optDirPersonalizado.CheckedChanged
        If deshaciendo Then Exit Sub

        Me.txtDirPersonal.Enabled = optDirPersonalizado.Checked
        Me.btnExaminar.Enabled = optDirPersonalizado.Checked

        deshaciendo = True
        optDirDocumentos.Checked = Not optDirPersonalizado.Checked
        deshaciendo = False

        directorioCfg()
        datosCambiados()
    End Sub

    Private Sub optDirProg_CheckedChanged(sender As Object,
                                          e As EventArgs) _
                                          Handles optDirDocumentos.CheckedChanged
        If deshaciendo Then Exit Sub

        Dim opt As RadioButton = TryCast(sender, RadioButton)
        If opt Is Nothing Then Exit Sub

        If opt.Checked Then
            optDirPersonalizado.Checked = False
        End If
        directorioCfg()
        datosCambiados()
    End Sub

    Private Sub datosCambiados()
        If deshaciendo Then Exit Sub

        Dim cambiados As Boolean = False

        With My.Settings
            If cboAbrirCon.Text <> My.Settings.AbrirCon Then
                cambiados = True
            End If
            If optDirDocumentos.Checked <> .usarMisDocumentos Then
                cambiados = True
            End If
            If optDirPersonalizado.Checked = .usarMisDocumentos Then
                cambiados = True
            End If
            If Me.txtDirPersonal.Text <> m_DirCfg Then
                cambiados = True
            End If
            If Me.chkPermitirReemplazar.Checked <> .chkPermitirReemplazar Then
                cambiados = True
            End If
            If Me.chkHacerCopiaReemplazar.Checked <> .chkHacerCopiaReemplazar Then
                cambiados = True
            End If
            If .chkGuardarAutomaticamente <> Me.chkGuardarAutomaticamente.Checked Then
                cambiados = True
            End If
            If Me.txtDirBackupReemplazar.Text <> .DirBackupReemplazar Then
                cambiados = True
            End If
            If Me.txtExtensiones.Text <> .Extensiones Then
                cambiados = True
            End If
            If chkExcluirDir.Checked <> .chkExcluirDir Then
                cambiados = True
            End If
            If txtExcluirDir.Text <> .txtExcluirDir Then
                cambiados = True
            End If

        End With

        btnDeshacer.Enabled = cambiados
        btnAceptar.Enabled = cambiados
    End Sub

    Private Sub directorioCfg()
        Dim dirCfg As String

        ' Para guardar el fichero en el directorio del ejecutable
        With My.Application.Info
            If Me.optDirDocumentos.Checked Then
                ' Mis Documentos\<aplicacion>
                dirCfg = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & .ProductName
                If My.Computer.FileSystem.DirectoryExists(dirCfg) = False Then
                    My.Computer.FileSystem.CreateDirectory(dirCfg)
                End If
            Else
                dirCfg = Me.txtDirPersonal.Text
                If String.IsNullOrEmpty(dirCfg) Then
                    dirCfg = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                End If
                If dirCfg.ToLower().Contains(My.Application.Info.ProductName.ToLower()) = False Then
                    dirCfg = System.IO.Path.Combine(dirCfg, My.Application.Info.ProductName)
                End If
                Try
                    If My.Computer.FileSystem.DirectoryExists(dirCfg) = False Then
                        My.Computer.FileSystem.CreateDirectory(dirCfg)
                    End If
                    Me.txtDirPersonal.Text = dirCfg
                Catch ex As Exception
                    ' Si da error al crear el path indicado, usar el de documentos
                    dirCfg = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & .ProductName
                    Me.optDirPersonalizado.Checked = False
                    Me.optDirDocumentos.Checked = True
                End Try
            End If
        End With

    End Sub

    Private Sub btnDeshacer_Click() Handles btnDeshacer.Click
        deshaciendo = True

        With My.Settings
            cboAbrirCon.Text = .AbrirCon
            optDirDocumentos.Checked = .usarMisDocumentos
            If .usarMisDocumentos Then
                optDirDocumentos.Checked = True
                optDirPersonalizado.Checked = False
            Else
                optDirDocumentos.Checked = False
                optDirPersonalizado.Checked = True
            End If
            Me.txtDirPersonal.Text = m_DirCfg ' .dirConfig
            Me.txtDirPersonal.Enabled = optDirPersonalizado.Checked
            Me.btnExaminar.Enabled = optDirPersonalizado.Checked
            ' Para las opciones de reemplazar                       (08/Feb/08)
            Me.chkPermitirReemplazar.Checked = .chkPermitirReemplazar
            Me.chkHacerCopiaReemplazar.Checked = .chkHacerCopiaReemplazar
            Me.txtDirBackupReemplazar.Text = .DirBackupReemplazar
            Me.txtExtensiones.Text = .Extensiones

            ' Guardar automáticamente al reemplazar                 (28/Dic/12)
            Me.chkGuardarAutomaticamente.Checked = .chkGuardarAutomaticamente

            ' Opciones de excluir directorios                       (26/Feb/08)
            chkExcluirDir.Checked = .chkExcluirDir
            txtExcluirDir.Text = .txtExcluirDir

        End With

        btnDeshacer.Enabled = False
        btnAceptar.Enabled = False

        deshaciendo = False

        chkPermitirReemplazar_CheckedChanged()
    End Sub

    Private Sub chkGuardarAutomaticamente_CheckedChanged() Handles chkGuardarAutomaticamente.CheckedChanged
        datosCambiados()
    End Sub

    Private Sub chkHacerCopia_CheckedChanged() Handles chkHacerCopiaReemplazar.CheckedChanged
        If deshaciendo Then Exit Sub

        Dim b = chkHacerCopiaReemplazar.Checked
        LabelDirBackup.Enabled = b
        txtDirBackupReemplazar.Enabled = b
        btnExaminarBackup.Enabled = b

        datosCambiados()
    End Sub

    Private Sub chkPermitirReemplazar_CheckedChanged() Handles chkPermitirReemplazar.CheckedChanged
        If deshaciendo Then Exit Sub

        Dim b = chkPermitirReemplazar.Checked
        chkHacerCopiaReemplazar.Enabled = b
        LabelExtensiones.Enabled = b
        txtExtensiones.Enabled = b

        chkGuardarAutomaticamente.Enabled = b

        If b Then
            b = chkHacerCopiaReemplazar.Checked
        End If
        LabelDirBackup.Enabled = b
        txtDirBackupReemplazar.Enabled = b
        btnExaminarBackup.Enabled = b

        datosCambiados()
    End Sub

    Private Sub txtDirBackup_TextChanged() Handles txtDirBackupReemplazar.TextChanged,
                                                 txtExtensiones.TextChanged, txtDirPersonal.TextChanged
        datosCambiados()
    End Sub

    Private Sub fBuscarCfg_DragEnter(ByVal sender As Object, _
                                     ByVal e As DragEventArgs) _
                                     Handles MyBase.DragEnter, txtExtensiones.DragEnter, _
                                             txtDirPersonal.DragEnter, txtDirBackupReemplazar.DragEnter
        ' Drag & Drop, comprobar con DataFormats
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub txtDirPersonal_DragDrop(ByVal sender As Object, _
                                        ByVal e As DragEventArgs) _
                                        Handles txtDirPersonal.DragDrop, txtDirBackupReemplazar.DragDrop
        If e.Data.GetDataPresent("FileDrop") Then
            Dim txtFic As TextBox = TryCast(sender, TextBox)
            If txtFic Is Nothing Then Exit Sub
            txtFic.Text = CType(e.Data.GetData("FileDrop", True), String())(0)
        End If
    End Sub

    Private Sub txtExtensiones_DragDrop(ByVal sender As Object, _
                                        ByVal e As DragEventArgs) _
                                        Handles txtExtensiones.DragDrop
        If e.Data.GetDataPresent("FileDrop") Then
            Dim fics() As String = CType(e.Data.GetData("FileDrop", True), String())

            Dim exts As New System.Collections.Generic.List(Of String)
            Dim ext1() As String = txtExtensiones.Text.Split(";".ToCharArray, _
                                                             StringSplitOptions.RemoveEmptyEntries)
            For Each s In ext1
                exts.Add(s.ToLower.Trim)
            Next
            For Each s In fics
                Dim s1 As String = System.IO.Path.GetExtension(s).ToLower
                If exts.Contains(s1) = False _
                AndAlso m_ExtensionesNO.Contains(s1) = False Then
                    exts.Add(s1)
                End If
            Next
            Dim sb As New System.Text.StringBuilder
            For i = 0 To exts.Count - 2
                sb.AppendFormat("{0}; ", exts(i))
            Next
            sb.Append(exts(exts.Count - 1))
            txtExtensiones.Text = sb.ToString
        End If
    End Sub

    Private Function comprobarExtensiones() As String
        Dim exts As New System.Collections.Generic.List(Of String)
        Dim ext1() As String = txtExtensiones.Text.Replace("*.", ".").Split(";".ToCharArray, _
                                                         StringSplitOptions.RemoveEmptyEntries)
        For Each s In ext1
            Dim s1 As String = s.ToLower.Trim
            If m_ExtensionesNO.Contains(s1) = False Then
                exts.Add(s1)
            End If
        Next
        Dim sb As New System.Text.StringBuilder
        For i = 0 To exts.Count - 2
            sb.AppendFormat("{0}; ", exts(i))
        Next
        sb.Append(exts(exts.Count - 1))

        Return sb.ToString
    End Function

    Private Sub btnExaminarBackup_Click() Handles btnExaminarBackup.Click
        Dim fbd As New FolderBrowserDialog
        With fbd
            .Description = "Selecciona el directorio para la copia de seguridad al reemplazar textos"
            .SelectedPath = txtDirBackupReemplazar.Text
            .ShowNewFolderButton = True
            .RootFolder = Environment.SpecialFolder.Desktop
            If .ShowDialog = DialogResult.OK Then
                txtDirBackupReemplazar.Text = .SelectedPath
            End If
        End With
    End Sub

    Private Sub chkExcluirDir_CheckedChanged() Handles chkExcluirDir.CheckedChanged
        datosCambiados()
    End Sub

    Private Sub txtExcluirDir_TextChanged() Handles txtExcluirDir.TextChanged
        If vb.Len(txtExcluirDir.Text) = 0 Then
            chkExcluirDir.Checked = False
        End If
        datosCambiados()
    End Sub

    Private Sub cboAbrirCon_Validating() Handles cboAbrirCon.Validating
        Dim s = cboAbrirCon.Text
        If String.IsNullOrEmpty(s) Then Return
        If Not cboAbrirCon.Items.Contains(s) Then
            cboAbrirCon.Items.Add(s)
        End If
    End Sub

    Private Sub cboAbrirCon_TextChanged(sender As Object, e As EventArgs) Handles cboAbrirCon.TextChanged
        datosCambiados()
    End Sub
End Class