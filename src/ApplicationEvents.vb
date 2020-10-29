'------------------------------------------------------------------------------
' Eventos de la aplicación gsBuscarTexto                            (07/Feb/08)
'
' ©Guillermo 'guille' Som, 2008
'------------------------------------------------------------------------------
Option Strict On
Option Infer Off

Imports System
Imports System.Collections.Generic

Imports Microsoft.VisualBasic.ApplicationServices

Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        ' Solo una instancia, pero es la única forma de controlar   (07/Feb/08)
        ' varios directorios desde la opción del Shell del Windows explorer

        ' Esto se produce cuando se inicia la primera
        Private Sub MyApplication_Startup(ByVal sender As Object, _
                                          ByVal e As StartupEventArgs) _
                                          Handles Me.Startup
            ' Cuando se inicia la aplicación,
            ' si se han indicado argumentos, no añadirlos al texto
            ' del combo de directorios
            If Environment.GetCommandLineArgs().Length > 1 Then
                My.Forms.Form1.directorioCmd = ""
                My.Forms.Form1.ConLineaComandos = True
                My.Forms.Form1.lineaComandos(Environment.GetCommandLineArgs())
            Else
                My.Forms.Form1.ConLineaComandos = False
            End If
        End Sub

        ' Este cuando ya está funcionando
        Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, _
                                                      ByVal e As StartupNextInstanceEventArgs) _
                                                      Handles Me.StartupNextInstance
            Dim argumentos As New List(Of String)
            My.Forms.Form1.ConLineaComandos = True

            ' Esta colección no tiene el nombre del ejecutable
            argumentos.Add(".exe")
            ' Esta opción indica que se debe añadir
            ' los argumentos a lo que haya en el combo del directorio
            argumentos.Add("/usarDir")
            For Each s As String In e.CommandLine
                argumentos.Add(s)
            Next

            With My.Forms.Form1
                If argumentos.Count > 2 Then
                    .directorioCmd = My.Forms.Form1.cboDir.Text
                End If
                .lineaComandos(argumentos.ToArray)

                .Size = .RestoreBounds.Size
                .Location = .RestoreBounds.Location
            End With
            e.BringToForeground = True

        End Sub
    End Class

End Namespace

