﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.7.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "Funcionalidad para autoguardar My.Settings"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-1, -1")>  _
        Public Property Location() As Global.System.Drawing.Point
            Get
                Return CType(Me("Location"),Global.System.Drawing.Point)
            End Get
            Set
                Me("Location") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-1, -1")>  _
        Public Property Size() As Global.System.Drawing.Size
            Get
                Return CType(Me("Size"),Global.System.Drawing.Size)
            End Get
            Set
                Me("Size") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("*.*")>  _
        Public Property Filtro() As String
            Get
                Return CType(Me("Filtro"),String)
            End Get
            Set
                Me("Filtro") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\")>  _
        Public Property Directorio() As String
            Get
                Return CType(Me("Directorio"),String)
            End Get
            Set
                Me("Directorio") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property conSubDir() As Boolean
            Get
                Return CType(Me("conSubDir"),Boolean)
            End Get
            Set
                Me("conSubDir") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property IgnorarError() As Boolean
            Get
                Return CType(Me("IgnorarError"),Boolean)
            End Get
            Set
                Me("IgnorarError") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property textoBuscar1() As String
            Get
                Return CType(Me("textoBuscar1"),String)
            End Get
            Set
                Me("textoBuscar1") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property textoBuscar2() As String
            Get
                Return CType(Me("textoBuscar2"),String)
            End Get
            Set
                Me("textoBuscar2") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property textoPoner1() As String
            Get
                Return CType(Me("textoPoner1"),String)
            End Get
            Set
                Me("textoPoner1") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property textoPoner2() As String
            Get
                Return CType(Me("textoPoner2"),String)
            End Get
            Set
                Me("textoPoner2") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Solo uno")>  _
        Public Property opcionBuscar() As String
            Get
                Return CType(Me("opcionBuscar"),String)
            End Get
            Set
                Me("opcionBuscar") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\|E:\gsCodigo_00\VS2005; E:\gsCodigo_00\VS2008")>  _
        Public Property ultimosDirectorios() As String
            Get
                Return CType(Me("ultimosDirectorios"),String)
            End Get
            Set
                Me("ultimosDirectorios") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property ultimosBuscar1() As String
            Get
                Return CType(Me("ultimosBuscar1"),String)
            End Get
            Set
                Me("ultimosBuscar1") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property ultimosBuscar2() As String
            Get
                Return CType(Me("ultimosBuscar2"),String)
            End Get
            Set
                Me("ultimosBuscar2") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property ultimosPoner1() As String
            Get
                Return CType(Me("ultimosPoner1"),String)
            End Get
            Set
                Me("ultimosPoner1") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property ultimosPoner2() As String
            Get
                Return CType(Me("ultimosPoner2"),String)
            End Get
            Set
                Me("ultimosPoner2") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("*.*| *.zip; *.rar")>  _
        Public Property ultimosFiltros() As String
            Get
                Return CType(Me("ultimosFiltros"),String)
            End Get
            Set
                Me("ultimosFiltros") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property chkBuscarTexto() As Boolean
            Get
                Return CType(Me("chkBuscarTexto"),Boolean)
            End Get
            Set
                Me("chkBuscarTexto") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property expanderBuscarExpanded() As Boolean
            Get
                Return CType(Me("expanderBuscarExpanded"),Boolean)
            End Get
            Set
                Me("expanderBuscarExpanded") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property expanderFicheroExpanded() As Boolean
            Get
                Return CType(Me("expanderFicheroExpanded"),Boolean)
            End Get
            Set
                Me("expanderFicheroExpanded") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property chkFecha() As Boolean
            Get
                Return CType(Me("chkFecha"),Boolean)
            End Get
            Set
                Me("chkFecha") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Fecha() As String
            Get
                Return CType(Me("Fecha"),String)
            End Get
            Set
                Me("Fecha") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property chkPoner() As Boolean
            Get
                Return CType(Me("chkPoner"),Boolean)
            End Get
            Set
                Me("chkPoner") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property distinguirMay() As Boolean
            Get
                Return CType(Me("distinguirMay"),Boolean)
            End Get
            Set
                Me("distinguirMay") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-1")>  _
        Public Property lvCol1() As Integer
            Get
                Return CType(Me("lvCol1"),Integer)
            End Get
            Set
                Me("lvCol1") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-1")>  _
        Public Property lvCol2() As Integer
            Get
                Return CType(Me("lvCol2"),Integer)
            End Get
            Set
                Me("lvCol2") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property FechaTipoBusc() As Integer
            Get
                Return CType(Me("FechaTipoBusc"),Integer)
            End Get
            Set
                Me("FechaTipoBusc") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property chkBuscarMismaLinea() As Boolean
            Get
                Return CType(Me("chkBuscarMismaLinea"),Boolean)
            End Get
            Set
                Me("chkBuscarMismaLinea") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property tsbMostrarResultados() As Boolean
            Get
                Return CType(Me("tsbMostrarResultados"),Boolean)
            End Get
            Set
                Me("tsbMostrarResultados") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property dirConfig() As String
            Get
                Return CType(Me("dirConfig"),String)
            End Get
            Set
                Me("dirConfig") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property usarMisDocumentos() As Boolean
            Get
                Return CType(Me("usarMisDocumentos"),Boolean)
            End Get
            Set
                Me("usarMisDocumentos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property chkPermitirReemplazar() As Boolean
            Get
                Return CType(Me("chkPermitirReemplazar"),Boolean)
            End Get
            Set
                Me("chkPermitirReemplazar") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property chkHacerCopiaReemplazar() As Boolean
            Get
                Return CType(Me("chkHacerCopiaReemplazar"),Boolean)
            End Get
            Set
                Me("chkHacerCopiaReemplazar") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property DirBackupReemplazar() As String
            Get
                Return CType(Me("DirBackupReemplazar"),String)
            End Get
            Set
                Me("DirBackupReemplazar") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute(".txt; .ini; .vb; .cs; .c; .h; .hpp; .cpp; .bas; .frm; .cls; .sql; .js; .aspx; .as"& _ 
            "p; .htm; .pl; .php; .xml; .xaml; .sln; .vbp; .vbproj; .csproj")>  _
        Public Property Extensiones() As String
            Get
                Return CType(Me("Extensiones"),String)
            End Get
            Set
                Me("Extensiones") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute(".*; .com; .exe; .dll; .lib; .tlb; .bin; .ocx; .zip; .rar; .cab; .jpg; .png; .gif;"& _ 
            " .tif; .ico; .bmp")>  _
        Public Property ExtensionesNo() As String
            Get
                Return CType(Me("ExtensionesNo"),String)
            End Get
            Set
                Me("ExtensionesNo") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property chkPalabrasCompletas() As Boolean
            Get
                Return CType(Me("chkPalabrasCompletas"),Boolean)
            End Get
            Set
                Me("chkPalabrasCompletas") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property chkExcluirDir() As Boolean
            Get
                Return CType(Me("chkExcluirDir"),Boolean)
            End Get
            Set
                Me("chkExcluirDir") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("_vti; _private")>  _
        Public Property txtExcluirDir() As String
            Get
                Return CType(Me("txtExcluirDir"),String)
            End Get
            Set
                Me("txtExcluirDir") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property chkGuardarAutomaticamente() As Boolean
            Get
                Return CType(Me("chkGuardarAutomaticamente"),Boolean)
            End Get
            Set
                Me("chkGuardarAutomaticamente") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property chkMultiple() As Boolean
            Get
                Return CType(Me("chkMultiple"),Boolean)
            End Get
            Set
                Me("chkMultiple") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("""E:\ISOs guilleAcer5930\Instalar (registrados)\TextPad\TextPad portable\TextPad.e"& _ 
            "xe""")>  _
        Public Property AbrirCon() As String
            Get
                Return CType(Me("AbrirCon"),String)
            End Get
            Set
                Me("AbrirCon") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.elGuille.BuscarTexto.My.MySettings
            Get
                Return Global.elGuille.BuscarTexto.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
