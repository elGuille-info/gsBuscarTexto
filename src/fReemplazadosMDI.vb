'------------------------------------------------------------------------------
' fReemplazarMDI                                                    (10/Feb/08)
' Formulario MDI para las ventanas de los ficheros modificados al reemplazar
'
' ©Guillermo 'guille' Som, 2008
'------------------------------------------------------------------------------
Option Strict On
Option Infer On

Imports System
Imports System.Windows.Forms

Public Class fReemplazadosMDI

    Private Sub mnuFicSalir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFicSalir.Click
        For Each ventana As fReemplazados In Me.MdiChildren
            ventana.CerrarSinGuardar = True
            ventana.Close()
        Next
        Me.Close()
    End Sub

    Private Sub mnuVentanaCascada_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuVentanaCascada.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub mnuVentanaVertical_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuVentanaVertical.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub mnuVentanaHorizontal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuVentanaHorizontal.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub mnuFicGuardarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFicGuardarTodos.Click
        For Each ventana As fReemplazados In Me.MdiChildren
            ventana.Guardar()
        Next
    End Sub

    Private Sub mnuFicGuardarAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFicGuardarAuto.Click
        For Each ventana As fReemplazados In Me.MdiChildren
            ventana.GuardarAuto()
        Next
    End Sub

    Private Sub mnuFicCerrarTodas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFicCerrarTodas.Click
        For Each ventana As fReemplazados In Me.MdiChildren
            ventana.Close()
        Next
    End Sub
End Class
