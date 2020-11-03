'------------------------------------------------------------------------------
' Utilidades                                                        (10/Feb/08)
' Clase con funciones de apoyo
'
' ©Guillermo 'guille' Som, 2008
'------------------------------------------------------------------------------
Option Strict On
Option Infer On

Imports Microsoft.VisualBasic
Imports vb = Microsoft.VisualBasic
Imports System
Imports System.Diagnostics

Namespace elGuille.info.Util

    Public NotInheritable Class Utilidades

        Public Shared ReadOnly NombreAplicacion As String
        Public Shared ReadOnly EsAdministrador As Boolean
        Public Shared ReadOnly FileVersion As String

        Private Shared fvi As System.Diagnostics.FileVersionInfo

        ' No permitir crear instancias ya que
        ' todos los métodos están compartidos
        Private Sub New()
        End Sub

        ' Si estamos en el IDE hacer que siempre sea administrador  (28/Dic/12)
#Const ESVSIDE = 0

        Shared Sub New()

#If ESVSIDE Then
            EsAdministrador = True
#Else
            EsAdministrador = UserAdministrador()
#End If

            FileVersion = _FileVersion
            NombreAplicacion = fvi.ProductName ' My.Application.Info.ProductName
        End Sub

        ' Comprobar si se ejecuta como administrador                    (07/Feb/08)
        Private Shared Function UserAdministrador() As Boolean
            My.User.InitializeWithWindowsUser()

            ' Microsoft.VisualBasic.ApplicationServices
            Return My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator)
        End Function

        Private Shared ReadOnly Property _FileVersion() As String
            Get
                ' Solo asignar la info, la primera vez que se solicite  (09/Feb/08)
                Static yaEstuve As Boolean
                Static laVersion As String

                If yaEstuve = False Then
                    Dim ensamblado As System.Reflection.Assembly = _
                            System.Reflection.Assembly.GetExecutingAssembly
                    'Dim fvi As System.Diagnostics.FileVersionInfo = _
                    '        System.Diagnostics.FileVersionInfo.GetVersionInfo(ensamblado.Location)
                    fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(ensamblado.Location)

                    ' Asignar la cadena de la versión del fichero
                    laVersion = fvi.FileVersion
                    ' Esto hará que no se vuelva a ejecutar este código
                    yaEstuve = True
                End If

                Return laVersion
            End Get
        End Property

        Public Shared Sub EscribirEventLog(ByVal msg As String, ByVal tipo As EventLogEntryType)
            ' Solo si se tienen permisos de administrador
            If EsAdministrador Then
                EventLog.WriteEntry(NombreAplicacion, _
                                    msg & _
                                    vbCrLf & "v" & FileVersion & " " & DateTime.Now.ToString, _
                                    tipo)
            Else
                Dim tipoVB As TraceEventType = TraceEventType.Information
                Select Case tipo
                    Case EventLogEntryType.Error
                        tipoVB = TraceEventType.Error
                    Case EventLogEntryType.Information
                        tipoVB = TraceEventType.Information
                    Case EventLogEntryType.Warning
                        tipoVB = TraceEventType.Warning
                    Case Else
                        tipoVB = TraceEventType.Information
                End Select
                My.Application.Log.WriteEntry(msg & _
                                              vbCrLf & "v" & FileVersion & " " & _
                                              DateTime.Now.ToString, _
                                              tipoVB)
            End If
        End Sub
    End Class
End Namespace
