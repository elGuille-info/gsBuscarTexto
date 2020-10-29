<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fReemplazadosMDI
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
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.mnuFic = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFicGuardarTodos = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFicGuardarAuto = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFicSep1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuFicCerrarTodas = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFicSep2 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuFicSalir = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuVentana = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuVentanaCascada = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuVentanaVertical = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuVentanaHorizontal = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuVentanaSep1 = New System.Windows.Forms.ToolStripSeparator
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFic, Me.mnuVentana})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.mnuVentana
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(736, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'mnuFic
        '
        Me.mnuFic.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFicGuardarTodos, Me.mnuFicGuardarAuto, Me.mnuFicSep1, Me.mnuFicCerrarTodas, Me.mnuFicSep2, Me.mnuFicSalir})
        Me.mnuFic.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.mnuFic.Name = "mnuFic"
        Me.mnuFic.Size = New System.Drawing.Size(63, 20)
        Me.mnuFic.Text = "&Ficheros"
        '
        'mnuFicGuardarTodos
        '
        Me.mnuFicGuardarTodos.ImageTransparentColor = System.Drawing.Color.Black
        Me.mnuFicGuardarTodos.Name = "mnuFicGuardarTodos"
        Me.mnuFicGuardarTodos.Size = New System.Drawing.Size(286, 22)
        Me.mnuFicGuardarTodos.Text = "Guardar todos..."
        Me.mnuFicGuardarTodos.ToolTipText = " Guardar todos, pidiendo el nombre "
        '
        'mnuFicGuardarAuto
        '
        Me.mnuFicGuardarAuto.Name = "mnuFicGuardarAuto"
        Me.mnuFicGuardarAuto.Size = New System.Drawing.Size(286, 22)
        Me.mnuFicGuardarAuto.Text = "Guardar todos con el nombre propuesto"
        Me.mnuFicGuardarAuto.ToolTipText = "Guarda todos con el nombre propuesto (en el mismo directorio del original)"
        '
        'mnuFicSep1
        '
        Me.mnuFicSep1.Name = "mnuFicSep1"
        Me.mnuFicSep1.Size = New System.Drawing.Size(283, 6)
        '
        'mnuFicCerrarTodas
        '
        Me.mnuFicCerrarTodas.Name = "mnuFicCerrarTodas"
        Me.mnuFicCerrarTodas.Size = New System.Drawing.Size(286, 22)
        Me.mnuFicCerrarTodas.Text = "Cerrar todas..."
        Me.mnuFicCerrarTodas.ToolTipText = " Si no está guardado, se pregunta si quiere guardar"
        '
        'mnuFicSep2
        '
        Me.mnuFicSep2.Name = "mnuFicSep2"
        Me.mnuFicSep2.Size = New System.Drawing.Size(283, 6)
        '
        'mnuFicSalir
        '
        Me.mnuFicSalir.Name = "mnuFicSalir"
        Me.mnuFicSalir.Size = New System.Drawing.Size(286, 22)
        Me.mnuFicSalir.Text = "&Salir (sin guardar)"
        Me.mnuFicSalir.ToolTipText = " Al Salir sin guardar, si hay algún fichero no guardado, se descartará "
        '
        'mnuVentana
        '
        Me.mnuVentana.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuVentanaCascada, Me.mnuVentanaVertical, Me.mnuVentanaHorizontal, Me.mnuVentanaSep1})
        Me.mnuVentana.Name = "mnuVentana"
        Me.mnuVentana.Size = New System.Drawing.Size(67, 20)
        Me.mnuVentana.Text = "&Ventanas"
        '
        'mnuVentanaCascada
        '
        Me.mnuVentanaCascada.Name = "mnuVentanaCascada"
        Me.mnuVentanaCascada.Size = New System.Drawing.Size(129, 22)
        Me.mnuVentanaCascada.Text = "&Cascada"
        '
        'mnuVentanaVertical
        '
        Me.mnuVentanaVertical.Name = "mnuVentanaVertical"
        Me.mnuVentanaVertical.Size = New System.Drawing.Size(129, 22)
        Me.mnuVentanaVertical.Text = "&Vertical"
        '
        'mnuVentanaHorizontal
        '
        Me.mnuVentanaHorizontal.Name = "mnuVentanaHorizontal"
        Me.mnuVentanaHorizontal.Size = New System.Drawing.Size(129, 22)
        Me.mnuVentanaHorizontal.Text = "&Horizontal"
        '
        'mnuVentanaSep1
        '
        Me.mnuVentanaSep1.Name = "mnuVentanaSep1"
        Me.mnuVentanaSep1.Size = New System.Drawing.Size(126, 6)
        '
        'fReemplazadosMDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 565)
        Me.Controls.Add(Me.MenuStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "fReemplazadosMDI"
        Me.Text = "Ficheros que se han modificado el texto"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuVentana As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuVentanaCascada As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuVentanaVertical As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuVentanaHorizontal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFicSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFicSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFicGuardarAuto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFic As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFicGuardarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuVentanaSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFicCerrarTodas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFicSep2 As System.Windows.Forms.ToolStripSeparator

End Class
