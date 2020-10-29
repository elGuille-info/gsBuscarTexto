<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fBuscarCfg
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fBuscarCfg))
        Me.chkShell = New System.Windows.Forms.CheckBox()
        Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkPermitirReemplazar = New System.Windows.Forms.CheckBox()
        Me.LabelExtensiones = New System.Windows.Forms.Label()
        Me.chkExcluirDir = New System.Windows.Forms.CheckBox()
        Me.panelBotones = New System.Windows.Forms.Panel()
        Me.btnDeshacer = New System.Windows.Forms.Button()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LabelInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.picAdmin = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtInfoShell = New System.Windows.Forms.TextBox()
        Me.grbShell = New System.Windows.Forms.GroupBox()
        Me.btnRestaurarVentana = New System.Windows.Forms.Button()
        Me.grbFicCfg = New System.Windows.Forms.GroupBox()
        Me.btnExaminar = New System.Windows.Forms.Button()
        Me.txtDirPersonal = New System.Windows.Forms.TextBox()
        Me.optDirPersonalizado = New System.Windows.Forms.RadioButton()
        Me.optDirDocumentos = New System.Windows.Forms.RadioButton()
        Me.grbReemplazar = New System.Windows.Forms.GroupBox()
        Me.txtExtensiones = New System.Windows.Forms.TextBox()
        Me.LabelDirBackup = New System.Windows.Forms.Label()
        Me.btnExaminarBackup = New System.Windows.Forms.Button()
        Me.txtDirBackupReemplazar = New System.Windows.Forms.TextBox()
        Me.chkHacerCopiaReemplazar = New System.Windows.Forms.CheckBox()
        Me.picReemplazar = New System.Windows.Forms.PictureBox()
        Me.grbDirExcluir = New System.Windows.Forms.GroupBox()
        Me.txtExcluirDir = New System.Windows.Forms.TextBox()
        Me.chkGuardarAutomaticamente = New System.Windows.Forms.CheckBox()
        Me.panelBotones.SuspendLayout()
        Me.statusStrip1.SuspendLayout()
        Me.grbShell.SuspendLayout()
        Me.grbFicCfg.SuspendLayout()
        Me.grbReemplazar.SuspendLayout()
        CType(Me.picReemplazar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbDirExcluir.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkShell
        '
        Me.chkShell.AutoSize = True
        Me.chkShell.Location = New System.Drawing.Point(12, 22)
        Me.chkShell.Margin = New System.Windows.Forms.Padding(6)
        Me.chkShell.Name = "chkShell"
        Me.chkShell.Size = New System.Drawing.Size(281, 17)
        Me.chkShell.TabIndex = 0
        Me.chkShell.Text = "Agregar menú contextual en las carpetas de Windows"
        Me.toolTip1.SetToolTip(Me.chkShell, " Añadir 'Buscar' como opción al menú contextual de las carpetas y unidades (solo " & _
        "como administrador)")
        Me.chkShell.UseVisualStyleBackColor = True
        '
        'chkPermitirReemplazar
        '
        Me.chkPermitirReemplazar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chkPermitirReemplazar.Location = New System.Drawing.Point(12, 22)
        Me.chkPermitirReemplazar.Margin = New System.Windows.Forms.Padding(6, 6, 6, 3)
        Me.chkPermitirReemplazar.Name = "chkPermitirReemplazar"
        Me.chkPermitirReemplazar.Size = New System.Drawing.Size(391, 24)
        Me.chkPermitirReemplazar.TabIndex = 0
        Me.chkPermitirReemplazar.Text = "Permitir seleccionar la opción de reemplazar texto (Cambiar por)"
        Me.chkPermitirReemplazar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.toolTip1.SetToolTip(Me.chkPermitirReemplazar, resources.GetString("chkPermitirReemplazar.ToolTip"))
        Me.chkPermitirReemplazar.UseVisualStyleBackColor = True
        '
        'LabelExtensiones
        '
        Me.LabelExtensiones.AutoSize = True
        Me.LabelExtensiones.Location = New System.Drawing.Point(18, 52)
        Me.LabelExtensiones.Margin = New System.Windows.Forms.Padding(22, 0, 3, 0)
        Me.LabelExtensiones.Name = "LabelExtensiones"
        Me.LabelExtensiones.Size = New System.Drawing.Size(67, 13)
        Me.LabelExtensiones.TabIndex = 1
        Me.LabelExtensiones.Text = "Extensiones:"
        Me.toolTip1.SetToolTip(Me.LabelExtensiones, resources.GetString("LabelExtensiones.ToolTip"))
        '
        'chkExcluirDir
        '
        Me.chkExcluirDir.AutoSize = True
        Me.chkExcluirDir.Location = New System.Drawing.Point(12, 22)
        Me.chkExcluirDir.Margin = New System.Windows.Forms.Padding(6, 6, 6, 3)
        Me.chkExcluirDir.Name = "chkExcluirDir"
        Me.chkExcluirDir.Size = New System.Drawing.Size(218, 17)
        Me.chkExcluirDir.TabIndex = 0
        Me.chkExcluirDir.Text = "Excluir los directorios que empiecen con:"
        Me.toolTip1.SetToolTip(Me.chkExcluirDir, " Si se deben excluir de la búsqueda los directorios que empiecen con los caracter" & _
        "es indicados " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " (debes separar los directorios con puntos y comas)")
        Me.chkExcluirDir.UseVisualStyleBackColor = True
        '
        'panelBotones
        '
        Me.panelBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelBotones.Controls.Add(Me.btnDeshacer)
        Me.panelBotones.Controls.Add(Me.statusStrip1)
        Me.panelBotones.Controls.Add(Me.btnAceptar)
        Me.panelBotones.Controls.Add(Me.btnCancelar)
        Me.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelBotones.Location = New System.Drawing.Point(0, 573)
        Me.panelBotones.Name = "panelBotones"
        Me.panelBotones.Size = New System.Drawing.Size(562, 53)
        Me.panelBotones.TabIndex = 5
        '
        'btnDeshacer
        '
        Me.btnDeshacer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeshacer.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDeshacer.Location = New System.Drawing.Point(320, 3)
        Me.btnDeshacer.Name = "btnDeshacer"
        Me.btnDeshacer.Size = New System.Drawing.Size(75, 23)
        Me.btnDeshacer.TabIndex = 0
        Me.btnDeshacer.Text = "Deshacer"
        Me.btnDeshacer.UseVisualStyleBackColor = True
        '
        'statusStrip1
        '
        Me.statusStrip1.AutoSize = False
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LabelInfo, Me.picAdmin})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 29)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.ShowItemToolTips = True
        Me.statusStrip1.Size = New System.Drawing.Size(560, 22)
        Me.statusStrip1.TabIndex = 3
        '
        'LabelInfo
        '
        Me.LabelInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(529, 17)
        Me.LabelInfo.Spring = True
        Me.LabelInfo.Text = "ToolStripStatusLabel1"
        Me.LabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picAdmin
        '
        Me.picAdmin.Image = Global.elGuille.BuscarTexto.My.Resources.Resources.escudo16_Exclamation
        Me.picAdmin.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.picAdmin.Name = "picAdmin"
        Me.picAdmin.Size = New System.Drawing.Size(16, 17)
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(401, 3)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(482, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtInfoShell
        '
        Me.txtInfoShell.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInfoShell.BackColor = System.Drawing.SystemColors.Info
        Me.txtInfoShell.Location = New System.Drawing.Point(6, 49)
        Me.txtInfoShell.Margin = New System.Windows.Forms.Padding(3, 4, 3, 3)
        Me.txtInfoShell.Multiline = True
        Me.txtInfoShell.Name = "txtInfoShell"
        Me.txtInfoShell.ReadOnly = True
        Me.txtInfoShell.Size = New System.Drawing.Size(527, 110)
        Me.txtInfoShell.TabIndex = 1
        Me.txtInfoShell.TabStop = False
        Me.txtInfoShell.Text = resources.GetString("txtInfoShell.Text")
        '
        'grbShell
        '
        Me.grbShell.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbShell.Controls.Add(Me.chkShell)
        Me.grbShell.Controls.Add(Me.txtInfoShell)
        Me.grbShell.Location = New System.Drawing.Point(12, 12)
        Me.grbShell.Name = "grbShell"
        Me.grbShell.Size = New System.Drawing.Size(539, 165)
        Me.grbShell.TabIndex = 0
        Me.grbShell.TabStop = False
        Me.grbShell.Text = "Menú contextual de Windows"
        '
        'btnRestaurarVentana
        '
        Me.btnRestaurarVentana.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRestaurarVentana.AutoSize = True
        Me.btnRestaurarVentana.Location = New System.Drawing.Point(12, 541)
        Me.btnRestaurarVentana.Name = "btnRestaurarVentana"
        Me.btnRestaurarVentana.Size = New System.Drawing.Size(243, 23)
        Me.btnRestaurarVentana.TabIndex = 4
        Me.btnRestaurarVentana.Text = "Restaurar la ventana principal al tamaño original"
        Me.btnRestaurarVentana.UseVisualStyleBackColor = True
        '
        'grbFicCfg
        '
        Me.grbFicCfg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFicCfg.Controls.Add(Me.btnExaminar)
        Me.grbFicCfg.Controls.Add(Me.txtDirPersonal)
        Me.grbFicCfg.Controls.Add(Me.optDirPersonalizado)
        Me.grbFicCfg.Controls.Add(Me.optDirDocumentos)
        Me.grbFicCfg.Location = New System.Drawing.Point(12, 186)
        Me.grbFicCfg.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.grbFicCfg.Name = "grbFicCfg"
        Me.grbFicCfg.Size = New System.Drawing.Size(538, 76)
        Me.grbFicCfg.TabIndex = 1
        Me.grbFicCfg.TabStop = False
        Me.grbFicCfg.Text = "Directorio para guardar la configuración"
        '
        'btnExaminar
        '
        Me.btnExaminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExaminar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExaminar.Location = New System.Drawing.Point(457, 42)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(75, 23)
        Me.btnExaminar.TabIndex = 3
        Me.btnExaminar.Text = "Examinar..."
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'txtDirPersonal
        '
        Me.txtDirPersonal.AllowDrop = True
        Me.txtDirPersonal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDirPersonal.Location = New System.Drawing.Point(109, 44)
        Me.txtDirPersonal.Name = "txtDirPersonal"
        Me.txtDirPersonal.Size = New System.Drawing.Size(342, 20)
        Me.txtDirPersonal.TabIndex = 2
        '
        'optDirPersonalizado
        '
        Me.optDirPersonalizado.AutoSize = True
        Me.optDirPersonalizado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.optDirPersonalizado.Location = New System.Drawing.Point(12, 45)
        Me.optDirPersonalizado.Name = "optDirPersonalizado"
        Me.optDirPersonalizado.Size = New System.Drawing.Size(91, 17)
        Me.optDirPersonalizado.TabIndex = 1
        Me.optDirPersonalizado.Text = "Personalizado"
        Me.optDirPersonalizado.UseVisualStyleBackColor = True
        '
        'optDirDocumentos
        '
        Me.optDirDocumentos.AutoSize = True
        Me.optDirDocumentos.Checked = True
        Me.optDirDocumentos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.optDirDocumentos.Location = New System.Drawing.Point(12, 22)
        Me.optDirDocumentos.Margin = New System.Windows.Forms.Padding(6, 6, 3, 3)
        Me.optDirDocumentos.Name = "optDirDocumentos"
        Me.optDirDocumentos.Size = New System.Drawing.Size(85, 17)
        Me.optDirDocumentos.TabIndex = 0
        Me.optDirDocumentos.TabStop = True
        Me.optDirDocumentos.Text = "Documentos"
        Me.optDirDocumentos.UseVisualStyleBackColor = True
        '
        'grbReemplazar
        '
        Me.grbReemplazar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbReemplazar.Controls.Add(Me.chkGuardarAutomaticamente)
        Me.grbReemplazar.Controls.Add(Me.LabelExtensiones)
        Me.grbReemplazar.Controls.Add(Me.txtExtensiones)
        Me.grbReemplazar.Controls.Add(Me.LabelDirBackup)
        Me.grbReemplazar.Controls.Add(Me.btnExaminarBackup)
        Me.grbReemplazar.Controls.Add(Me.txtDirBackupReemplazar)
        Me.grbReemplazar.Controls.Add(Me.chkHacerCopiaReemplazar)
        Me.grbReemplazar.Controls.Add(Me.chkPermitirReemplazar)
        Me.grbReemplazar.Location = New System.Drawing.Point(12, 271)
        Me.grbReemplazar.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.grbReemplazar.Name = "grbReemplazar"
        Me.grbReemplazar.Size = New System.Drawing.Size(538, 163)
        Me.grbReemplazar.TabIndex = 2
        Me.grbReemplazar.TabStop = False
        Me.grbReemplazar.Text = "      Opciones para reemplazar texto"
        '
        'txtExtensiones
        '
        Me.txtExtensiones.AllowDrop = True
        Me.txtExtensiones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExtensiones.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExtensiones.Location = New System.Drawing.Point(91, 52)
        Me.txtExtensiones.Multiline = True
        Me.txtExtensiones.Name = "txtExtensiones"
        Me.txtExtensiones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtExtensiones.Size = New System.Drawing.Size(441, 41)
        Me.txtExtensiones.TabIndex = 2
        Me.txtExtensiones.Text = ".txt; .ini; .vb; .cs; .c; .h; .hpp; .cpp; .bas; .frm; .cls; .sql; .js; .aspx; .as" & _
    "p; .htm; .pl; .php; .xml; .xaml; .sln; .vbp; .vbproj; .csproj"
        '
        'LabelDirBackup
        '
        Me.LabelDirBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelDirBackup.AutoSize = True
        Me.LabelDirBackup.Location = New System.Drawing.Point(25, 132)
        Me.LabelDirBackup.Margin = New System.Windows.Forms.Padding(22, 0, 3, 0)
        Me.LabelDirBackup.Name = "LabelDirBackup"
        Me.LabelDirBackup.Size = New System.Drawing.Size(113, 13)
        Me.LabelDirBackup.TabIndex = 5
        Me.LabelDirBackup.Text = "Directorio de respaldo:"
        '
        'btnExaminarBackup
        '
        Me.btnExaminarBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExaminarBackup.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExaminarBackup.Location = New System.Drawing.Point(457, 127)
        Me.btnExaminarBackup.Name = "btnExaminarBackup"
        Me.btnExaminarBackup.Size = New System.Drawing.Size(75, 23)
        Me.btnExaminarBackup.TabIndex = 7
        Me.btnExaminarBackup.Text = "Examinar..."
        Me.btnExaminarBackup.UseVisualStyleBackColor = True
        '
        'txtDirBackupReemplazar
        '
        Me.txtDirBackupReemplazar.AllowDrop = True
        Me.txtDirBackupReemplazar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDirBackupReemplazar.Location = New System.Drawing.Point(144, 129)
        Me.txtDirBackupReemplazar.Name = "txtDirBackupReemplazar"
        Me.txtDirBackupReemplazar.Size = New System.Drawing.Size(307, 20)
        Me.txtDirBackupReemplazar.TabIndex = 6
        '
        'chkHacerCopiaReemplazar
        '
        Me.chkHacerCopiaReemplazar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkHacerCopiaReemplazar.Checked = True
        Me.chkHacerCopiaReemplazar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHacerCopiaReemplazar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chkHacerCopiaReemplazar.Location = New System.Drawing.Point(21, 99)
        Me.chkHacerCopiaReemplazar.Margin = New System.Windows.Forms.Padding(18, 3, 3, 3)
        Me.chkHacerCopiaReemplazar.Name = "chkHacerCopiaReemplazar"
        Me.chkHacerCopiaReemplazar.Size = New System.Drawing.Size(251, 24)
        Me.chkHacerCopiaReemplazar.TabIndex = 3
        Me.chkHacerCopiaReemplazar.Text = "Hacer copia de seguridad antes de reemplazar"
        Me.chkHacerCopiaReemplazar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chkHacerCopiaReemplazar.UseVisualStyleBackColor = False
        '
        'picReemplazar
        '
        Me.picReemplazar.Image = Global.elGuille.BuscarTexto.My.Resources.Resources.escudo16_Exclamation
        Me.picReemplazar.Location = New System.Drawing.Point(19, 271)
        Me.picReemplazar.Name = "picReemplazar"
        Me.picReemplazar.Size = New System.Drawing.Size(16, 16)
        Me.picReemplazar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picReemplazar.TabIndex = 9
        Me.picReemplazar.TabStop = False
        '
        'grbDirExcluir
        '
        Me.grbDirExcluir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbDirExcluir.Controls.Add(Me.txtExcluirDir)
        Me.grbDirExcluir.Controls.Add(Me.chkExcluirDir)
        Me.grbDirExcluir.Location = New System.Drawing.Point(12, 440)
        Me.grbDirExcluir.Name = "grbDirExcluir"
        Me.grbDirExcluir.Size = New System.Drawing.Size(538, 91)
        Me.grbDirExcluir.TabIndex = 3
        Me.grbDirExcluir.TabStop = False
        Me.grbDirExcluir.Text = "Directorios a excluir"
        '
        'txtExcluirDir
        '
        Me.txtExcluirDir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExcluirDir.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExcluirDir.Location = New System.Drawing.Point(91, 45)
        Me.txtExcluirDir.Multiline = True
        Me.txtExcluirDir.Name = "txtExcluirDir"
        Me.txtExcluirDir.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtExcluirDir.Size = New System.Drawing.Size(441, 34)
        Me.txtExcluirDir.TabIndex = 1
        Me.txtExcluirDir.Text = "_vti; _private"
        '
        'chkGuardarAutomaticamente
        '
        Me.chkGuardarAutomaticamente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkGuardarAutomaticamente.Checked = True
        Me.chkGuardarAutomaticamente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkGuardarAutomaticamente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chkGuardarAutomaticamente.Location = New System.Drawing.Point(293, 99)
        Me.chkGuardarAutomaticamente.Margin = New System.Windows.Forms.Padding(18, 3, 3, 3)
        Me.chkGuardarAutomaticamente.Name = "chkGuardarAutomaticamente"
        Me.chkGuardarAutomaticamente.Size = New System.Drawing.Size(239, 24)
        Me.chkGuardarAutomaticamente.TabIndex = 4
        Me.chkGuardarAutomaticamente.Text = "Guardar los cambios automáticamente"
        Me.chkGuardarAutomaticamente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.toolTip1.SetToolTip(Me.chkGuardarAutomaticamente, resources.GetString("chkGuardarAutomaticamente.ToolTip"))
        Me.chkGuardarAutomaticamente.UseVisualStyleBackColor = False
        '
        'fBuscarCfg
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(562, 626)
        Me.Controls.Add(Me.grbDirExcluir)
        Me.Controls.Add(Me.picReemplazar)
        Me.Controls.Add(Me.grbReemplazar)
        Me.Controls.Add(Me.grbFicCfg)
        Me.Controls.Add(Me.btnRestaurarVentana)
        Me.Controls.Add(Me.grbShell)
        Me.Controls.Add(Me.panelBotones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(520, 648)
        Me.Name = "fBuscarCfg"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configuración"
        Me.panelBotones.ResumeLayout(False)
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.grbShell.ResumeLayout(False)
        Me.grbShell.PerformLayout()
        Me.grbFicCfg.ResumeLayout(False)
        Me.grbFicCfg.PerformLayout()
        Me.grbReemplazar.ResumeLayout(False)
        Me.grbReemplazar.PerformLayout()
        CType(Me.picReemplazar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbDirExcluir.ResumeLayout(False)
        Me.grbDirExcluir.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents chkShell As System.Windows.Forms.CheckBox
    Private WithEvents toolTip1 As System.Windows.Forms.ToolTip
    Private WithEvents btnAceptar As System.Windows.Forms.Button
    Private WithEvents btnCancelar As System.Windows.Forms.Button
    Private WithEvents panelBotones As System.Windows.Forms.Panel
    Private WithEvents txtInfoShell As System.Windows.Forms.TextBox
    Private WithEvents picAdmin As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Private WithEvents LabelInfo As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents grbShell As System.Windows.Forms.GroupBox
    Private WithEvents btnRestaurarVentana As System.Windows.Forms.Button
    Private WithEvents grbFicCfg As System.Windows.Forms.GroupBox
    Private WithEvents btnExaminar As System.Windows.Forms.Button
    Private WithEvents txtDirPersonal As System.Windows.Forms.TextBox
    Private WithEvents optDirPersonalizado As System.Windows.Forms.RadioButton
    Private WithEvents optDirDocumentos As System.Windows.Forms.RadioButton
    Private WithEvents btnDeshacer As System.Windows.Forms.Button
    Private WithEvents grbReemplazar As System.Windows.Forms.GroupBox
    Private WithEvents chkPermitirReemplazar As System.Windows.Forms.CheckBox
    Private WithEvents LabelDirBackup As System.Windows.Forms.Label
    Private WithEvents btnExaminarBackup As System.Windows.Forms.Button
    Private WithEvents txtDirBackupReemplazar As System.Windows.Forms.TextBox
    Private WithEvents chkHacerCopiaReemplazar As System.Windows.Forms.CheckBox
    Private WithEvents LabelExtensiones As System.Windows.Forms.Label
    Private WithEvents txtExtensiones As System.Windows.Forms.TextBox
    Friend WithEvents picReemplazar As System.Windows.Forms.PictureBox
    Private WithEvents grbDirExcluir As System.Windows.Forms.GroupBox
    Private WithEvents txtExcluirDir As System.Windows.Forms.TextBox
    Private WithEvents chkExcluirDir As System.Windows.Forms.CheckBox
    Private WithEvents chkGuardarAutomaticamente As System.Windows.Forms.CheckBox
End Class
