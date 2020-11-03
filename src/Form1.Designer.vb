<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAbrirFic = New System.Windows.Forms.Button()
        Me.btnAbrirDir = New System.Windows.Forms.Button()
        Me.chkFecha = New System.Windows.Forms.CheckBox()
        Me.chkIgnorarErrores = New System.Windows.Forms.CheckBox()
        Me.chkConSubDir = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkDistinguirMay = New System.Windows.Forms.CheckBox()
        Me.optFechaMayor = New System.Windows.Forms.RadioButton()
        Me.optfechaMenor = New System.Windows.Forms.RadioButton()
        Me.optFechaIgual = New System.Windows.Forms.RadioButton()
        Me.chkBuscar = New System.Windows.Forms.CheckBox()
        Me.chkBuscarMismaLinea = New System.Windows.Forms.CheckBox()
        Me.chkPoner = New System.Windows.Forms.CheckBox()
        Me.chkPalabrasCompletas = New System.Windows.Forms.CheckBox()
        Me.chkMultiple = New System.Windows.Forms.CheckBox()
        Me.btnAbrirCon = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lvFics = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFicsContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuContextAbrirFic = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextAbrirDir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextAbrirCon = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFic = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFicExaminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFicSep0 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFicBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFicSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFicAbrirFichero = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFicAbrirDir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFicAbrirCon = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFicSep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFicCfg = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFicSep3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFicAcerca = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFicOpcionesShell = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFicSep4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFicSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.grupoExp1 = New System.Windows.Forms.GroupBox()
        Me.cboPoner2 = New System.Windows.Forms.ComboBox()
        Me.cboPoner1 = New System.Windows.Forms.ComboBox()
        Me.cboBuscar2 = New System.Windows.Forms.ComboBox()
        Me.cboTipoBuca = New System.Windows.Forms.ComboBox()
        Me.cboBuscar1 = New System.Windows.Forms.ComboBox()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.pic1 = New System.Windows.Forms.PictureBox()
        Me.header1 = New System.Windows.Forms.Label()
        Me.grupoExp2 = New System.Windows.Forms.GroupBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.btnExaminarDir = New System.Windows.Forms.Button()
        Me.cboDir = New System.Windows.Forms.ComboBox()
        Me.cboFiltro = New System.Windows.Forms.ComboBox()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.pic2 = New System.Windows.Forms.PictureBox()
        Me.header2 = New System.Windows.Forms.Label()
        Me.LabelTiempo = New System.Windows.Forms.Label()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LabelInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsbBuscar = New System.Windows.Forms.ToolStripSplitButton()
        Me.tsbNoMostrarResultados = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbMostrarResultados = New System.Windows.Forms.ToolStripMenuItem()
        Me.picAdmin = New System.Windows.Forms.ToolStripStatusLabel()
        Me.picBuscando = New System.Windows.Forms.PictureBox()
        Me.lvFicsContextMenu.SuspendLayout()
        Me.menuStrip1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.grupoExp1.SuspendLayout()
        Me.panel1.SuspendLayout()
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grupoExp2.SuspendLayout()
        Me.panel2.SuspendLayout()
        CType(Me.pic2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusStrip1.SuspendLayout()
        CType(Me.picBuscando, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAbrirFic
        '
        Me.btnAbrirFic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAbrirFic.Location = New System.Drawing.Point(12, 447)
        Me.btnAbrirFic.Name = "btnAbrirFic"
        Me.btnAbrirFic.Size = New System.Drawing.Size(90, 23)
        Me.btnAbrirFic.TabIndex = 2
        Me.btnAbrirFic.Text = "Abrir fichero"
        Me.toolTip1.SetToolTip(Me.btnAbrirFic, "Abrir el fichero seleccionado con el programa que tenga asociado")
        Me.btnAbrirFic.UseVisualStyleBackColor = True
        '
        'btnAbrirDir
        '
        Me.btnAbrirDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAbrirDir.Location = New System.Drawing.Point(108, 447)
        Me.btnAbrirDir.Name = "btnAbrirDir"
        Me.btnAbrirDir.Size = New System.Drawing.Size(90, 23)
        Me.btnAbrirDir.TabIndex = 3
        Me.btnAbrirDir.Text = "Abrir directorio"
        Me.toolTip1.SetToolTip(Me.btnAbrirDir, "Abrir la carpeta del fichero seleccionado")
        Me.btnAbrirDir.UseVisualStyleBackColor = True
        '
        'chkFecha
        '
        Me.chkFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkFecha.AutoSize = True
        Me.chkFecha.Location = New System.Drawing.Point(364, 84)
        Me.chkFecha.Name = "chkFecha"
        Me.chkFecha.Size = New System.Drawing.Size(161, 17)
        Me.chkFecha.TabIndex = 8
        Me.chkFecha.Text = "Los modificados en la fecha:"
        Me.toolTip1.SetToolTip(Me.chkFecha, " Buscar solo ficheros modificados en la fecha indicada ")
        Me.chkFecha.UseVisualStyleBackColor = True
        '
        'chkIgnorarErrores
        '
        Me.chkIgnorarErrores.AutoSize = True
        Me.chkIgnorarErrores.Checked = True
        Me.chkIgnorarErrores.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIgnorarErrores.Location = New System.Drawing.Point(93, 107)
        Me.chkIgnorarErrores.Name = "chkIgnorarErrores"
        Me.chkIgnorarErrores.Size = New System.Drawing.Size(147, 17)
        Me.chkIgnorarErrores.TabIndex = 7
        Me.chkIgnorarErrores.Text = "Ignorar los avisos de error"
        Me.toolTip1.SetToolTip(Me.chkIgnorarErrores, " Si se producen errores al buscar, ignorarlos ")
        Me.chkIgnorarErrores.UseVisualStyleBackColor = True
        '
        'chkConSubDir
        '
        Me.chkConSubDir.AutoSize = True
        Me.chkConSubDir.Checked = True
        Me.chkConSubDir.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkConSubDir.Location = New System.Drawing.Point(93, 84)
        Me.chkConSubDir.Name = "chkConSubDir"
        Me.chkConSubDir.Size = New System.Drawing.Size(122, 17)
        Me.chkConSubDir.TabIndex = 6
        Me.chkConSubDir.Text = "Incluir subdirectorios"
        Me.toolTip1.SetToolTip(Me.chkConSubDir, " Incluir los subdirectorios ")
        Me.chkConSubDir.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Directorio:"
        Me.toolTip1.SetToolTip(Me.Label2, " Directorio en el que se iniciará la búsqueda (puedes indicar varios, separados p" &
        "or puntos y comas) ")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Filtro búsqueda:"
        Me.toolTip1.SetToolTip(Me.Label1, " El filtro (signos comodín) a usar para buscar los ficheros (puedes indicar vario" &
        "s separdos por puntos y comas) ")
        '
        'chkDistinguirMay
        '
        Me.chkDistinguirMay.AutoSize = True
        Me.chkDistinguirMay.Location = New System.Drawing.Point(93, 82)
        Me.chkDistinguirMay.Name = "chkDistinguirMay"
        Me.chkDistinguirMay.Size = New System.Drawing.Size(197, 17)
        Me.chkDistinguirMay.TabIndex = 8
        Me.chkDistinguirMay.Text = "Distinguir mayúsculas de minúsculas"
        Me.toolTip1.SetToolTip(Me.chkDistinguirMay, " Si en la búsquedas de textos se debe hacer una comprobación exacta ")
        Me.chkDistinguirMay.UseVisualStyleBackColor = True
        '
        'optFechaMayor
        '
        Me.optFechaMayor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optFechaMayor.AutoSize = True
        Me.optFechaMayor.Location = New System.Drawing.Point(499, 106)
        Me.optFechaMayor.Name = "optFechaMayor"
        Me.optFechaMayor.Size = New System.Drawing.Size(54, 17)
        Me.optFechaMayor.TabIndex = 12
        Me.optFechaMayor.Text = "Mayor"
        Me.toolTip1.SetToolTip(Me.optFechaMayor, " Solo se tienen en cuenta los que la fecha sea mayor a la indicada ")
        Me.optFechaMayor.UseVisualStyleBackColor = True
        '
        'optfechaMenor
        '
        Me.optfechaMenor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optfechaMenor.AutoSize = True
        Me.optfechaMenor.Location = New System.Drawing.Point(438, 106)
        Me.optfechaMenor.Name = "optfechaMenor"
        Me.optfechaMenor.Size = New System.Drawing.Size(55, 17)
        Me.optfechaMenor.TabIndex = 11
        Me.optfechaMenor.Text = "Menor"
        Me.toolTip1.SetToolTip(Me.optfechaMenor, " Solo se tienen en cuenta los que la fecha sea menor a la indicada ")
        Me.optfechaMenor.UseVisualStyleBackColor = True
        '
        'optFechaIgual
        '
        Me.optFechaIgual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optFechaIgual.AutoSize = True
        Me.optFechaIgual.Checked = True
        Me.optFechaIgual.Location = New System.Drawing.Point(384, 106)
        Me.optFechaIgual.Name = "optFechaIgual"
        Me.optFechaIgual.Size = New System.Drawing.Size(48, 17)
        Me.optFechaIgual.TabIndex = 10
        Me.optFechaIgual.TabStop = True
        Me.optFechaIgual.Text = "Igual"
        Me.toolTip1.SetToolTip(Me.optFechaIgual, " Solo se tienen en cuenta los que la fecha sea igual a la indicada ")
        Me.optFechaIgual.UseVisualStyleBackColor = True
        '
        'chkBuscar
        '
        Me.chkBuscar.AutoSize = True
        Me.chkBuscar.Location = New System.Drawing.Point(6, 28)
        Me.chkBuscar.Name = "chkBuscar"
        Me.chkBuscar.Size = New System.Drawing.Size(62, 17)
        Me.chkBuscar.TabIndex = 1
        Me.chkBuscar.Text = "Buscar:"
        Me.toolTip1.SetToolTip(Me.chkBuscar, " El texto a buscar")
        Me.chkBuscar.UseVisualStyleBackColor = True
        '
        'chkBuscarMismaLinea
        '
        Me.chkBuscarMismaLinea.AutoSize = True
        Me.chkBuscarMismaLinea.Checked = True
        Me.chkBuscarMismaLinea.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBuscarMismaLinea.Location = New System.Drawing.Point(325, 82)
        Me.chkBuscarMismaLinea.Name = "chkBuscarMismaLinea"
        Me.chkBuscarMismaLinea.Size = New System.Drawing.Size(255, 17)
        Me.chkBuscarMismaLinea.TabIndex = 10
        Me.chkBuscarMismaLinea.Text = "Al buscar varios textos hacerlo en la misma línea"
        Me.toolTip1.SetToolTip(Me.chkBuscarMismaLinea, " Si al buscar varios textos, se hace en la misma cadena o en el fichero completo " &
        "(en el fichero completo puede tardar más dependiendo del tamaño del fichero) ")
        Me.chkBuscarMismaLinea.UseVisualStyleBackColor = True
        '
        'chkPoner
        '
        Me.chkPoner.AutoSize = True
        Me.chkPoner.Location = New System.Drawing.Point(6, 55)
        Me.chkPoner.Name = "chkPoner"
        Me.chkPoner.Size = New System.Drawing.Size(85, 17)
        Me.chkPoner.TabIndex = 5
        Me.chkPoner.Text = "Cambiar por:"
        Me.toolTip1.SetToolTip(Me.chkPoner, " El texto a poner (reemplazar) " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Solo disponible en modo Administrador.")
        Me.chkPoner.UseVisualStyleBackColor = True
        '
        'chkPalabrasCompletas
        '
        Me.chkPalabrasCompletas.AutoSize = True
        Me.chkPalabrasCompletas.Location = New System.Drawing.Point(93, 105)
        Me.chkPalabrasCompletas.Name = "chkPalabrasCompletas"
        Me.chkPalabrasCompletas.Size = New System.Drawing.Size(118, 17)
        Me.chkPalabrasCompletas.TabIndex = 9
        Me.chkPalabrasCompletas.Text = "Palabras completas"
        Me.toolTip1.SetToolTip(Me.chkPalabrasCompletas, " Solo se buscarán palabras completas (si lo desactivas, se buscarán todas las que" &
        " contengan esa cadena, sin importar dónde esté) ")
        Me.chkPalabrasCompletas.UseVisualStyleBackColor = True
        '
        'chkMultiple
        '
        Me.chkMultiple.AutoSize = True
        Me.chkMultiple.Location = New System.Drawing.Point(325, 105)
        Me.chkMultiple.Name = "chkMultiple"
        Me.chkMultiple.Size = New System.Drawing.Size(249, 17)
        Me.chkMultiple.TabIndex = 11
        Me.chkMultiple.Text = "En Buscar usar varias cadenas separadas por ;"
        Me.toolTip1.SetToolTip(Me.chkMultiple, "Marca esta opción si quieres indicar varias cadenas a buscar," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "estarán separadas " &
        "por punto y coma [;]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Solo se permite usar NOT o AND en el segundo texto." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "No se" &
        " permite reemplazar.")
        Me.chkMultiple.UseVisualStyleBackColor = True
        '
        'btnAbrirCon
        '
        Me.btnAbrirCon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAbrirCon.Location = New System.Drawing.Point(204, 447)
        Me.btnAbrirCon.Name = "btnAbrirCon"
        Me.btnAbrirCon.Size = New System.Drawing.Size(90, 23)
        Me.btnAbrirCon.TabIndex = 4
        Me.btnAbrirCon.Text = "Abrir con..."
        Me.toolTip1.SetToolTip(Me.btnAbrirCon, "Abrir la carpeta del fichero seleccionado")
        Me.btnAbrirCon.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Location = New System.Drawing.Point(525, 480)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lvFics
        '
        Me.lvFics.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvFics.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvFics.ContextMenuStrip = Me.lvFicsContextMenu
        Me.lvFics.FullRowSelect = True
        Me.lvFics.GridLines = True
        Me.lvFics.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvFics.HideSelection = False
        Me.lvFics.Location = New System.Drawing.Point(3, 278)
        Me.lvFics.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.lvFics.Name = "lvFics"
        Me.lvFics.ShowItemToolTips = True
        Me.lvFics.Size = New System.Drawing.Size(612, 130)
        Me.lvFics.TabIndex = 2
        Me.lvFics.UseCompatibleStateImageBehavior = False
        Me.lvFics.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nombre"
        Me.ColumnHeader1.Width = 249
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Directorio"
        Me.ColumnHeader2.Width = 340
        '
        'lvFicsContextMenu
        '
        Me.lvFicsContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuContextAbrirFic, Me.mnuContextAbrirDir, Me.mnuContextAbrirCon})
        Me.lvFicsContextMenu.Name = "lvFicsContextMenu"
        Me.lvFicsContextMenu.Size = New System.Drawing.Size(155, 70)
        '
        'mnuContextAbrirFic
        '
        Me.mnuContextAbrirFic.Name = "mnuContextAbrirFic"
        Me.mnuContextAbrirFic.Size = New System.Drawing.Size(154, 22)
        Me.mnuContextAbrirFic.Text = "Abrir &fichero"
        '
        'mnuContextAbrirDir
        '
        Me.mnuContextAbrirDir.Name = "mnuContextAbrirDir"
        Me.mnuContextAbrirDir.Size = New System.Drawing.Size(154, 22)
        Me.mnuContextAbrirDir.Text = "Abrir &directorio"
        '
        'mnuContextAbrirCon
        '
        Me.mnuContextAbrirCon.Name = "mnuContextAbrirCon"
        Me.mnuContextAbrirCon.Size = New System.Drawing.Size(154, 22)
        Me.mnuContextAbrirCon.Text = "Abrir &con..."
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFic})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(644, 24)
        Me.menuStrip1.TabIndex = 0
        Me.menuStrip1.Text = "MenuStrip1"
        '
        'mnuFic
        '
        Me.mnuFic.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFicExaminar, Me.mnuFicSep0, Me.mnuFicBuscar, Me.mnuFicSep1, Me.mnuFicAbrirFichero, Me.mnuFicAbrirDir, Me.mnuFicAbrirCon, Me.mnuFicSep2, Me.mnuFicCfg, Me.mnuFicSep3, Me.mnuFicAcerca, Me.mnuFicOpcionesShell, Me.mnuFicSep4, Me.mnuFicSalir})
        Me.mnuFic.Name = "mnuFic"
        Me.mnuFic.Size = New System.Drawing.Size(58, 20)
        Me.mnuFic.Text = "&Fichero"
        '
        'mnuFicExaminar
        '
        Me.mnuFicExaminar.Name = "mnuFicExaminar"
        Me.mnuFicExaminar.Size = New System.Drawing.Size(318, 22)
        Me.mnuFicExaminar.Text = "S&eleccionar directorio"
        '
        'mnuFicSep0
        '
        Me.mnuFicSep0.Name = "mnuFicSep0"
        Me.mnuFicSep0.Size = New System.Drawing.Size(315, 6)
        '
        'mnuFicBuscar
        '
        Me.mnuFicBuscar.Name = "mnuFicBuscar"
        Me.mnuFicBuscar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.mnuFicBuscar.Size = New System.Drawing.Size(318, 22)
        Me.mnuFicBuscar.Text = "&Buscar"
        '
        'mnuFicSep1
        '
        Me.mnuFicSep1.Name = "mnuFicSep1"
        Me.mnuFicSep1.Size = New System.Drawing.Size(315, 6)
        '
        'mnuFicAbrirFichero
        '
        Me.mnuFicAbrirFichero.Name = "mnuFicAbrirFichero"
        Me.mnuFicAbrirFichero.Size = New System.Drawing.Size(318, 22)
        Me.mnuFicAbrirFichero.Text = "Abrir &fichero"
        '
        'mnuFicAbrirDir
        '
        Me.mnuFicAbrirDir.Name = "mnuFicAbrirDir"
        Me.mnuFicAbrirDir.Size = New System.Drawing.Size(318, 22)
        Me.mnuFicAbrirDir.Text = "Abrir &directorio"
        '
        'mnuFicAbrirCon
        '
        Me.mnuFicAbrirCon.Name = "mnuFicAbrirCon"
        Me.mnuFicAbrirCon.Size = New System.Drawing.Size(318, 22)
        Me.mnuFicAbrirCon.Text = "Abrir &con..."
        '
        'mnuFicSep2
        '
        Me.mnuFicSep2.Name = "mnuFicSep2"
        Me.mnuFicSep2.Size = New System.Drawing.Size(315, 6)
        '
        'mnuFicCfg
        '
        Me.mnuFicCfg.Name = "mnuFicCfg"
        Me.mnuFicCfg.ShortcutKeys = System.Windows.Forms.Keys.F10
        Me.mnuFicCfg.Size = New System.Drawing.Size(318, 22)
        Me.mnuFicCfg.Text = "Confi&gurar..."
        '
        'mnuFicSep3
        '
        Me.mnuFicSep3.Name = "mnuFicSep3"
        Me.mnuFicSep3.Size = New System.Drawing.Size(315, 6)
        '
        'mnuFicAcerca
        '
        Me.mnuFicAcerca.Name = "mnuFicAcerca"
        Me.mnuFicAcerca.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.mnuFicAcerca.Size = New System.Drawing.Size(318, 22)
        Me.mnuFicAcerca.Text = "Acerca de..."
        '
        'mnuFicOpcionesShell
        '
        Me.mnuFicOpcionesShell.Name = "mnuFicOpcionesShell"
        Me.mnuFicOpcionesShell.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.mnuFicOpcionesShell.Size = New System.Drawing.Size(318, 22)
        Me.mnuFicOpcionesShell.Text = "A&yuda opciones de la línea de comandos..."
        '
        'mnuFicSep4
        '
        Me.mnuFicSep4.Name = "mnuFicSep4"
        Me.mnuFicSep4.Size = New System.Drawing.Size(315, 6)
        '
        'mnuFicSalir
        '
        Me.mnuFicSalir.Name = "mnuFicSalir"
        Me.mnuFicSalir.Size = New System.Drawing.Size(318, 22)
        Me.mnuFicSalir.Text = "&Salir"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AllowDrop = True
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.grupoExp1)
        Me.FlowLayoutPanel1.Controls.Add(Me.grupoExp2)
        Me.FlowLayoutPanel1.Controls.Add(Me.lvFics)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 27)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(624, 414)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'grupoExp1
        '
        Me.grupoExp1.Controls.Add(Me.chkMultiple)
        Me.grupoExp1.Controls.Add(Me.chkPalabrasCompletas)
        Me.grupoExp1.Controls.Add(Me.chkBuscarMismaLinea)
        Me.grupoExp1.Controls.Add(Me.chkDistinguirMay)
        Me.grupoExp1.Controls.Add(Me.cboPoner2)
        Me.grupoExp1.Controls.Add(Me.cboPoner1)
        Me.grupoExp1.Controls.Add(Me.chkPoner)
        Me.grupoExp1.Controls.Add(Me.cboBuscar2)
        Me.grupoExp1.Controls.Add(Me.cboTipoBuca)
        Me.grupoExp1.Controls.Add(Me.cboBuscar1)
        Me.grupoExp1.Controls.Add(Me.chkBuscar)
        Me.grupoExp1.Controls.Add(Me.panel1)
        Me.grupoExp1.Location = New System.Drawing.Point(3, 3)
        Me.grupoExp1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.grupoExp1.Name = "grupoExp1"
        Me.grupoExp1.Size = New System.Drawing.Size(612, 135)
        Me.grupoExp1.TabIndex = 0
        Me.grupoExp1.TabStop = False
        Me.grupoExp1.Text = "Directorios de origen:"
        '
        'cboPoner2
        '
        Me.cboPoner2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPoner2.FormattingEnabled = True
        Me.cboPoner2.Location = New System.Drawing.Point(416, 55)
        Me.cboPoner2.Name = "cboPoner2"
        Me.cboPoner2.Size = New System.Drawing.Size(190, 21)
        Me.cboPoner2.TabIndex = 7
        '
        'cboPoner1
        '
        Me.cboPoner1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPoner1.FormattingEnabled = True
        Me.cboPoner1.Location = New System.Drawing.Point(93, 55)
        Me.cboPoner1.Name = "cboPoner1"
        Me.cboPoner1.Size = New System.Drawing.Size(226, 21)
        Me.cboPoner1.TabIndex = 6
        '
        'cboBuscar2
        '
        Me.cboBuscar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboBuscar2.FormattingEnabled = True
        Me.cboBuscar2.Location = New System.Drawing.Point(416, 28)
        Me.cboBuscar2.Name = "cboBuscar2"
        Me.cboBuscar2.Size = New System.Drawing.Size(190, 21)
        Me.cboBuscar2.TabIndex = 4
        '
        'cboTipoBuca
        '
        Me.cboTipoBuca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTipoBuca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoBuca.FormattingEnabled = True
        Me.cboTipoBuca.Items.AddRange(New Object() {"Solo uno", "Not (No)", "And (Y)", "Or (O)"})
        Me.cboTipoBuca.Location = New System.Drawing.Point(325, 28)
        Me.cboTipoBuca.Name = "cboTipoBuca"
        Me.cboTipoBuca.Size = New System.Drawing.Size(85, 21)
        Me.cboTipoBuca.TabIndex = 3
        Me.toolTip1.SetToolTip(Me.cboTipoBuca, "Si se selecciona AND u OR se puede indicar el segundo valor de 'cambiar'.")
        '
        'cboBuscar1
        '
        Me.cboBuscar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboBuscar1.FormattingEnabled = True
        Me.cboBuscar1.Location = New System.Drawing.Point(93, 28)
        Me.cboBuscar1.Name = "cboBuscar1"
        Me.cboBuscar1.Size = New System.Drawing.Size(226, 21)
        Me.cboBuscar1.TabIndex = 2
        '
        'panel1
        '
        Me.panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.panel1.Controls.Add(Me.pic1)
        Me.panel1.Controls.Add(Me.header1)
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(612, 22)
        Me.panel1.TabIndex = 0
        '
        'pic1
        '
        Me.pic1.BackColor = System.Drawing.Color.Transparent
        Me.pic1.Image = Global.elGuille.BuscarTexto.My.Resources.Resources.ExpanderUp
        Me.pic1.Location = New System.Drawing.Point(0, 0)
        Me.pic1.Name = "pic1"
        Me.pic1.Size = New System.Drawing.Size(21, 21)
        Me.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic1.TabIndex = 2
        Me.pic1.TabStop = False
        '
        'header1
        '
        Me.header1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.header1.Location = New System.Drawing.Point(24, 4)
        Me.header1.Name = "header1"
        Me.header1.Size = New System.Drawing.Size(582, 17)
        Me.header1.TabIndex = 0
        Me.header1.Text = "Texto a buscar"
        '
        'grupoExp2
        '
        Me.grupoExp2.Controls.Add(Me.optFechaIgual)
        Me.grupoExp2.Controls.Add(Me.optfechaMenor)
        Me.grupoExp2.Controls.Add(Me.optFechaMayor)
        Me.grupoExp2.Controls.Add(Me.txtFecha)
        Me.grupoExp2.Controls.Add(Me.chkFecha)
        Me.grupoExp2.Controls.Add(Me.chkIgnorarErrores)
        Me.grupoExp2.Controls.Add(Me.chkConSubDir)
        Me.grupoExp2.Controls.Add(Me.btnExaminarDir)
        Me.grupoExp2.Controls.Add(Me.Label2)
        Me.grupoExp2.Controls.Add(Me.cboDir)
        Me.grupoExp2.Controls.Add(Me.Label1)
        Me.grupoExp2.Controls.Add(Me.cboFiltro)
        Me.grupoExp2.Controls.Add(Me.panel2)
        Me.grupoExp2.Location = New System.Drawing.Point(3, 141)
        Me.grupoExp2.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.grupoExp2.Name = "grupoExp2"
        Me.grupoExp2.Size = New System.Drawing.Size(612, 131)
        Me.grupoExp2.TabIndex = 1
        Me.grupoExp2.TabStop = False
        Me.grupoExp2.Text = "Directorios de origen:"
        '
        'txtFecha
        '
        Me.txtFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFecha.Location = New System.Drawing.Point(531, 82)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(75, 20)
        Me.txtFecha.TabIndex = 9
        Me.txtFecha.Text = "25/12/2007"
        '
        'btnExaminarDir
        '
        Me.btnExaminarDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExaminarDir.Location = New System.Drawing.Point(531, 53)
        Me.btnExaminarDir.Name = "btnExaminarDir"
        Me.btnExaminarDir.Size = New System.Drawing.Size(75, 23)
        Me.btnExaminarDir.TabIndex = 5
        Me.btnExaminarDir.Text = "Examinar..."
        Me.btnExaminarDir.UseVisualStyleBackColor = True
        '
        'cboDir
        '
        Me.cboDir.AllowDrop = True
        Me.cboDir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDir.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.cboDir.FormattingEnabled = True
        Me.cboDir.Location = New System.Drawing.Point(93, 55)
        Me.cboDir.Name = "cboDir"
        Me.cboDir.Size = New System.Drawing.Size(432, 21)
        Me.cboDir.TabIndex = 4
        '
        'cboFiltro
        '
        Me.cboFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFiltro.FormattingEnabled = True
        Me.cboFiltro.Location = New System.Drawing.Point(93, 28)
        Me.cboFiltro.Name = "cboFiltro"
        Me.cboFiltro.Size = New System.Drawing.Size(513, 21)
        Me.cboFiltro.TabIndex = 2
        '
        'panel2
        '
        Me.panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.panel2.Controls.Add(Me.pic2)
        Me.panel2.Controls.Add(Me.header2)
        Me.panel2.Location = New System.Drawing.Point(0, 0)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(612, 22)
        Me.panel2.TabIndex = 0
        '
        'pic2
        '
        Me.pic2.BackColor = System.Drawing.Color.Transparent
        Me.pic2.Image = Global.elGuille.BuscarTexto.My.Resources.Resources.ExpanderUp
        Me.pic2.Location = New System.Drawing.Point(0, 0)
        Me.pic2.Name = "pic2"
        Me.pic2.Size = New System.Drawing.Size(21, 21)
        Me.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic2.TabIndex = 2
        Me.pic2.TabStop = False
        '
        'header2
        '
        Me.header2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.header2.Location = New System.Drawing.Point(24, 4)
        Me.header2.Name = "header2"
        Me.header2.Size = New System.Drawing.Size(582, 17)
        Me.header2.TabIndex = 0
        Me.header2.Text = "Fichero a buscar"
        '
        'LabelTiempo
        '
        Me.LabelTiempo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelTiempo.Location = New System.Drawing.Point(300, 452)
        Me.LabelTiempo.Name = "LabelTiempo"
        Me.LabelTiempo.Size = New System.Drawing.Size(336, 18)
        Me.LabelTiempo.TabIndex = 6
        Me.LabelTiempo.Text = "LabelTiempo"
        '
        'statusStrip1
        '
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LabelInfo, Me.tsbBuscar, Me.picAdmin})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 477)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.ShowItemToolTips = True
        Me.statusStrip1.Size = New System.Drawing.Size(644, 28)
        Me.statusStrip1.TabIndex = 8
        Me.statusStrip1.Text = "StatusStrip1"
        '
        'LabelInfo
        '
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(522, 23)
        Me.LabelInfo.Spring = True
        Me.LabelInfo.Text = "LabelInfo"
        Me.LabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tsbBuscar
        '
        Me.tsbBuscar.AutoSize = False
        Me.tsbBuscar.AutoToolTip = False
        Me.tsbBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbBuscar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNoMostrarResultados, Me.tsbMostrarResultados})
        Me.tsbBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tsbBuscar.Image = CType(resources.GetObject("tsbBuscar.Image"), System.Drawing.Image)
        Me.tsbBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbBuscar.Margin = New System.Windows.Forms.Padding(0, 1, 2, 0)
        Me.tsbBuscar.Name = "tsbBuscar"
        Me.tsbBuscar.Size = New System.Drawing.Size(89, 27)
        '
        'tsbNoMostrarResultados
        '
        Me.tsbNoMostrarResultados.Checked = True
        Me.tsbNoMostrarResultados.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsbNoMostrarResultados.Name = "tsbNoMostrarResultados"
        Me.tsbNoMostrarResultados.Size = New System.Drawing.Size(250, 22)
        Me.tsbNoMostrarResultados.Text = "No mostrar resultados mientras busca"
        Me.tsbNoMostrarResultados.ToolTipText = " No mostrar los resultados mientras se busca (más rápido) "
        '
        'tsbMostrarResultados
        '
        Me.tsbMostrarResultados.Name = "tsbMostrarResultados"
        Me.tsbMostrarResultados.Size = New System.Drawing.Size(250, 22)
        Me.tsbMostrarResultados.Text = "Mostrar resultados mientras busca"
        Me.tsbMostrarResultados.ToolTipText = " Mostrar los resultados mientras se busca (más lento) "
        '
        'picAdmin
        '
        Me.picAdmin.Image = Global.elGuille.BuscarTexto.My.Resources.Resources.escudo16_Exclamation
        Me.picAdmin.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.picAdmin.Name = "picAdmin"
        Me.picAdmin.Size = New System.Drawing.Size(16, 23)
        '
        'picBuscando
        '
        Me.picBuscando.Image = Global.elGuille.BuscarTexto.My.Resources.Resources.buscar_animado_lupa_hoja
        Me.picBuscando.Location = New System.Drawing.Point(79, 426)
        Me.picBuscando.Name = "picBuscando"
        Me.picBuscando.Size = New System.Drawing.Size(48, 48)
        Me.picBuscando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picBuscando.TabIndex = 7
        Me.picBuscando.TabStop = False
        Me.picBuscando.Visible = False
        '
        'Form1
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 505)
        Me.Controls.Add(Me.btnAbrirCon)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.LabelTiempo)
        Me.Controls.Add(Me.picBuscando)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.btnAbrirDir)
        Me.Controls.Add(Me.btnAbrirFic)
        Me.Controls.Add(Me.menuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuStrip1
        Me.MinimumSize = New System.Drawing.Size(580, 500)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar ficheros (y texto) en los directorios indicados"
        Me.lvFicsContextMenu.ResumeLayout(False)
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.grupoExp1.ResumeLayout(False)
        Me.grupoExp1.PerformLayout()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grupoExp2.ResumeLayout(False)
        Me.grupoExp2.PerformLayout()
        Me.panel2.ResumeLayout(False)
        Me.panel2.PerformLayout()
        CType(Me.pic2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        CType(Me.picBuscando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents toolTip1 As System.Windows.Forms.ToolTip
    Private WithEvents btnBuscar As System.Windows.Forms.Button
    Private WithEvents lvFics As System.Windows.Forms.ListView
    Private WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents btnAbrirFic As System.Windows.Forms.Button
    Private WithEvents btnAbrirDir As System.Windows.Forms.Button
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents mnuFic As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFicSalir As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFicExaminar As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFicSep0 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuFicBuscar As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFicSep1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuFicAbrirFichero As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFicAbrirDir As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFicSep3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents grupoExp1 As System.Windows.Forms.GroupBox
    Private WithEvents cboPoner2 As System.Windows.Forms.ComboBox
    Private WithEvents cboPoner1 As System.Windows.Forms.ComboBox
    Private WithEvents chkPoner As System.Windows.Forms.CheckBox
    Private WithEvents cboBuscar2 As System.Windows.Forms.ComboBox
    Private WithEvents cboTipoBuca As System.Windows.Forms.ComboBox
    Private WithEvents cboBuscar1 As System.Windows.Forms.ComboBox
    Private WithEvents chkBuscar As System.Windows.Forms.CheckBox
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents pic1 As System.Windows.Forms.PictureBox
    Private WithEvents header1 As System.Windows.Forms.Label
    Private WithEvents grupoExp2 As System.Windows.Forms.GroupBox
    Private WithEvents txtFecha As System.Windows.Forms.TextBox
    Private WithEvents chkFecha As System.Windows.Forms.CheckBox
    Private WithEvents chkIgnorarErrores As System.Windows.Forms.CheckBox
    Private WithEvents chkConSubDir As System.Windows.Forms.CheckBox
    Private WithEvents btnExaminarDir As System.Windows.Forms.Button
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents cboFiltro As System.Windows.Forms.ComboBox
    Private WithEvents panel2 As System.Windows.Forms.Panel
    Private WithEvents pic2 As System.Windows.Forms.PictureBox
    Private WithEvents header2 As System.Windows.Forms.Label
    Private WithEvents chkDistinguirMay As System.Windows.Forms.CheckBox
    Private WithEvents LabelTiempo As System.Windows.Forms.Label
    Private WithEvents picBuscando As System.Windows.Forms.PictureBox
    Private WithEvents optFechaIgual As System.Windows.Forms.RadioButton
    Private WithEvents optfechaMenor As System.Windows.Forms.RadioButton
    Private WithEvents optFechaMayor As System.Windows.Forms.RadioButton
    Private WithEvents mnuFicSep4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuFicAcerca As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents LabelInfo As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents picAdmin As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents mnuFicSep2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFicCfg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboDir As System.Windows.Forms.ComboBox
    Private WithEvents mnuFicOpcionesShell As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents chkBuscarMismaLinea As System.Windows.Forms.CheckBox
    Friend WithEvents tsbNoMostrarResultados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbMostrarResultados As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tsbBuscar As System.Windows.Forms.ToolStripSplitButton
    Private WithEvents lvFicsContextMenu As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnuContextAbrirFic As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuContextAbrirDir As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents chkPalabrasCompletas As System.Windows.Forms.CheckBox
    Private WithEvents chkMultiple As System.Windows.Forms.CheckBox
    Private WithEvents btnAbrirCon As System.Windows.Forms.Button
    Private WithEvents mnuContextAbrirCon As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFicAbrirCon As System.Windows.Forms.ToolStripMenuItem
End Class
