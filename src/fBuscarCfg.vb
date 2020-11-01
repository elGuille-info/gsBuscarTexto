'------------------------------------------------------------------------------
' Configuración para gsBuscarTextos                                 (07/Feb/08)
'
' ©Guillermo 'guille' Som, 2008
'------------------------------------------------------------------------------
Option Strict On
Option Infer On

Imports Microsoft.VisualBasic
Imports vb = Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.Win32

Imports elGuille.BuscarTexto.elGuille.info.Util.Utilidades

Public Class fBuscarCfg

    Private m_ExtensionesNO As New System.Collections.Generic.List(Of String)
    Private m_DirCfg As String
    Private deshaciendo As Boolean = False
    Private m_chkShell As Boolean

    Private Const programa As String = "gsBuscarTexto"
    'Private Const shellKey As String = "SOFTWARE\Classes\Folder\Shell"

    Private Sub fBuscarCfg_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        chkShell.Enabled = EsAdministrador

        picReemplazar.Top = grbReemplazar.Top
        picReemplazar.Left = grbReemplazar.Left + 7

        ' Si es administrador
        If chkShell.Enabled Then
            picAdmin.Image = My.Resources.escudo16_OK
            picAdmin.ToolTipText = "Ejecutando como administrador"
            txtInfoShell.Text &= "(ahora estás ejecutando como administrador)."
            ' Las opciones de reemplazar                            (08/Feb/08)
            'chkHacerCopiaReemplazar.Image = My.Resources.escudo16_OK
            'chkPermitirReemplazar.Image = My.Resources.escudo16_OK
            picReemplazar.Image = My.Resources.escudo16_OK
            grbReemplazar.Enabled = True
            toolTip1.SetToolTip(picReemplazar, "")
        Else
            picAdmin.Image = My.Resources.escudo16_Exclamation
            picAdmin.ToolTipText = "No estás ejecutando como administrador."
            txtInfoShell.Text &= "(ahora no estás ejecutando como administrador)."
            ' Las opciones de reemplazar                            (08/Feb/08)
            'chkHacerCopiaReemplazar.Image = My.Resources.escudo16_Exclamation
            'chkPermitirReemplazar.Image = My.Resources.escudo16_Exclamation
            picReemplazar.Image = My.Resources.escudo16_Exclamation
            grbReemplazar.Enabled = False
            toolTip1.SetToolTip(picReemplazar, "Estas opciones solo están disponibles cuando ejecutas la aplicación como administrador")
        End If
        '' Para probar
        'picReemplazar.Image = My.Resources.escudo16_Exclamation
        'grbReemplazar.Enabled = False
        'toolTip1.SetToolTip(picReemplazar, "Estas opciones solo están disponibles cuando ejecutas la aplicación como administrador")
        LabelInfo.Text = picAdmin.ToolTipText

        'If EstaEnRegistro().HasValue Then
        '    chkShell.Checked = EstaEnRegistro().Value
        'Else
        '    chkShell.CheckState = CheckState.Indeterminate
        '    toolTip1.SetToolTip(chkShell, "No se ha podido leer el valor del registro")
        '    chkShell.Text &= " (error al leer clave)"
        'End If

        m_chkShell = chkShell.Checked
        m_DirCfg = My.Settings.dirConfig

        ' Las opciones de las extensiones                           (09/Feb/08)
        toolTip1.SetToolTip(LabelExtensiones, toolTip1.GetToolTip(LabelExtensiones) & " " & My.Settings.ExtensionesNo)

        Dim ext1() As String = My.Settings.ExtensionesNo.Split(";".ToCharArray, StringSplitOptions.RemoveEmptyEntries)
        For Each s In ext1
            m_ExtensionesNO.Add(s.ToLower.Trim)
        Next

        ' TODO
        ' Esta opción aún no está implementada                      (09/Feb/08)
        ' Dejarlo habilitado para hacer pruebas
        'My.Settings.chkPermitirReemplazar = False
        'chkPermitirReemplazar.Enabled = False
        toolTip1.SetToolTip(grbReemplazar, "La opción de reemplazar (cambiar texto) aún no está implementada")


        btnDeshacer_Click(Nothing, Nothing)
        'optDirPersonalizado_CheckedChanged(Nothing, Nothing)
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click
        'If EsAdministrador Then
        '    CrearShell(chkShell.Checked)
        'End If

        With My.Settings
            .usarMisDocumentos = optDirDocumentos.Checked
            'directorioCfg()
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

            .Save()
        End With

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    End Sub

#Region " Acceso al registro de Windows "

    'Friend Shared Sub CrearShell(ByVal crearClave As Boolean)
    '    ' Del blog de Enrique Cortés:
    '    ' http://ekort.blogspot.com/2007/02/acceso-directo-ms-dos-desde-carpetas.html
    '    '
    '    ' Crear una clave en:
    '    ' HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Folder\Shell
    '    ' Crear el comando a ejecutar

    '    ' Solo si se tienen privilegios de administrador
    '    If EsAdministrador = False Then
    '        Exit Sub
    '    End If

    '    Const progId As String = "Abrir con gsBuscarTexto"
    '    Dim sPath As String = ChrW(34) & Application.ExecutablePath & ChrW(34) & " " &
    '                          ChrW(34) & "%1" & ChrW(34) & " /sub /nobuscar /nofecha /noerror"

    '    Try
    '        Using rk As RegistryKey = Registry.LocalMachine.OpenSubKey(shellKey, True)
    '            If rk Is Nothing Then
    '                MessageBox.Show("No se puede abrir la clave del registro.",
    '                                "Crear opción contextual",
    '                                MessageBoxButtons.OK,
    '                                MessageBoxIcon.Exclamation)
    '            End If

    '            If crearClave Then
    '                Using rkc As RegistryKey = rk.CreateSubKey(programa)
    '                    rkc.SetValue("", progId)
    '                    Using rkc2 As RegistryKey = rkc.CreateSubKey("command")
    '                        rkc2.SetValue("", sPath)
    '                    End Using
    '                End Using
    '            Else
    '                ' Quitar la clave
    '                rk.DeleteSubKeyTree(programa)
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show("Error al asignar el registro:" & vbCrLf &
    '                        ex.Message,
    '                        "Crear opción contextual",
    '                        MessageBoxButtons.OK,
    '                        MessageBoxIcon.Exclamation)
    '    End Try
    'End Sub

    '''' <summary>
    '''' Comprueba si ya está la clave del registro creada
    '''' </summary>
    '''' <returns>
    '''' True si ya está registrado
    '''' </returns>
    '''' <remarks></remarks>
    'Friend Function EstaEnRegistro() As Boolean?
    '    Dim progId As String = ""
    '    Dim sKey As String = shellKey & "\" & programa

    '    Try
    '        Using rk As RegistryKey = Registry.LocalMachine.OpenSubKey(sKey)
    '            If rk IsNot Nothing Then
    '                progId = rk.GetValue("").ToString
    '                rk.Close()
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        progId = "Error"
    '    End Try

    '    Return Not String.IsNullOrEmpty(progId)
    'End Function

#End Region

    Private Sub btnRestaurarVentana_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRestaurarVentana.Click
        ' w, h 660; 541'515
        With My.Settings
            .Size = New Size(660, 541)
            My.Forms.Form1.Size = .Size
        End With
    End Sub

    Private Sub btnExaminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExaminar.Click
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

    Private Sub optDirPersonalizado_CheckedChanged(ByVal sender As Object, _
                                                   ByVal e As EventArgs) _
                                                   Handles optDirPersonalizado.CheckedChanged
        If deshaciendo Then Exit Sub

        Me.txtDirPersonal.Enabled = optDirPersonalizado.Checked
        Me.btnExaminar.Enabled = optDirPersonalizado.Checked

        deshaciendo = True
        optDirDocumentos.Checked = Not optDirPersonalizado.Checked
        deshaciendo = False

        directorioCfg()
        datosCambiados()
    End Sub

    Private Sub optDirProg_CheckedChanged(ByVal sender As Object, _
                                          ByVal e As EventArgs) _
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
            If optDirDocumentos.Checked <> .usarMisDocumentos Then
                cambiados = True
            End If
            If optDirPersonalizado.Checked = .usarMisDocumentos Then
                cambiados = True
            End If
            If Me.txtDirPersonal.Text <> m_DirCfg Then '.dirConfig Then
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
        If chkShell.Checked <> m_chkShell Then
            cambiados = True
        End If

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

        'Me.txtDirPersonal.Text = dirCfg
    End Sub


    Private Sub btnDeshacer_Click(ByVal sender As Object, _
                                  ByVal e As EventArgs) _
                                  Handles btnDeshacer.Click
        deshaciendo = True

        With My.Settings
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
        chkShell.Checked = m_chkShell

        btnDeshacer.Enabled = False
        btnAceptar.Enabled = False

        deshaciendo = False

        chkPermitirReemplazar_CheckedChanged(Nothing, Nothing)
    End Sub

    Private Sub chkGenéricos_CheckedChanged(ByVal sender As Object,
                                            ByVal e As EventArgs) _
                                        Handles chkShell.CheckedChanged,
                                                chkGuardarAutomaticamente.CheckedChanged
        datosCambiados()
    End Sub

    Private Sub chkHacerCopia_CheckedChanged(ByVal sender As Object, _
                                             ByVal e As EventArgs) _
                                             Handles chkHacerCopiaReemplazar.CheckedChanged
        If deshaciendo Then Exit Sub

        Dim b = chkHacerCopiaReemplazar.Checked
        LabelDirBackup.Enabled = b
        txtDirBackupReemplazar.Enabled = b
        btnExaminarBackup.Enabled = b

        datosCambiados()
    End Sub

    Private Sub chkPermitirReemplazar_CheckedChanged(ByVal sender As Object, _
                                                     ByVal e As EventArgs) _
                                                     Handles chkPermitirReemplazar.CheckedChanged
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

    Private Sub txtDirBackup_TextChanged(ByVal sender As Object, _
                                         ByVal e As EventArgs) _
                                         Handles txtDirBackupReemplazar.TextChanged, _
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

            'datosCambiados()
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

    Private Sub btnExaminarBackup_Click(ByVal sender As Object, _
                                        ByVal e As EventArgs) _
                                        Handles btnExaminarBackup.Click
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

    Private Sub chkExcluirDir_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExcluirDir.CheckedChanged
        datosCambiados()
    End Sub

    Private Sub txtExcluirDir_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExcluirDir.TextChanged
        If vb.Len(txtExcluirDir.Text) = 0 Then
            chkExcluirDir.Checked = False
        End If
        datosCambiados()
    End Sub
End Class