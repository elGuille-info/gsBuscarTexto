'------------------------------------------------------------------------------
' gsBuscarTexto                                                     (07/Dic/07)
' Buscar ficheros según la especificación indicada y buscar texto en esos ficheros
'
' Basado en gsBuscar
'
' ©Guillermo 'guille' Som, 2007-2008, 2012, 2018, 2020
'
' Revisiones:
' v2.0.4.0 (mientras reviso era: 2.0.3.0 ~ 2.0.3.33)                (07/Feb/08)
'   -Se pueden indicar directorios desde la línea de comandos
'       o arrastrándolos al acceso directo del programa
'   -Añado acerca de
'   -Se comprueba si se ejecuta como administrador
'   -Opciones de la línea de comandos
'       Se permiten:
'       /h,         Muestra la ventana de la ayuda
'       /usardir,   Al soltar directorios, si se mantiene lo que ya hubiera en el combo Directorios
'       /nobuscar,  Desactiva la opción de buscar (predeterminado con el menú contextual)
'       /buscar,    Activa la opción de buscar texto
'       /nofecha,   Desactiva la opción de buscar por fecha (predeterminado con el menú contextual)
'       /fecha,     Activa la opción de buscar por fecha
'       /sub,       Activa la opción de buscar en subdirectorios (predeterminado con el menú contextual)
'       /nosub,     Desactiva la opción de buscar en subdirectorios
'       /noerror,   Activa la opción de ignorar errores (predeterminado con el menú contextual)
'       /error,     Desactiva la opción de ignorar errores
'       /reg+,      Registra el programa en el menú contextual del explorador de Windows
'       /reg-       Quita el programa del menú contextual del explorador de Windows
'   -Añadir una opción al menú contextual del explorador de Windows
'   -Ventana de configuración para esta nueva funcionalidad
'   -Cambio a aplicación de una instancia,
'       para soportar varios directorios desde el menú contextual
'   -Ayuda de los comandos que se pueden usar
'   -Al buscar textos, se puede buscar línea a línea o en el fichero completo
'   -Varios cambios menores en los totales mostrados
'
' v2.0.5.0 (en revisión 2.0.4.0 ~ 2.0.4.39)                         (07/Feb/08)
'   -Opción para mostrar los ficheros hallados (será más lento)
'       Opción en el botón de buscar
'   -En configuración poder restaurar tamaño ventana principal
'   -En configuración opciones para el directorio de la configuración
'   -Guarda los datos de configuración en los documentos del usuario
'       Cada vez que se cambia de versión, se resetean...
'   -Se puede indicar el directorio en el que se guardará
'
' v2.0.6.0 (en revisión 2.0.5.9000 ~ 2.0.5.9107)              (08 al 10/Feb/08)
'   Estas opciones están funcionales, pero todavía no se reemplaza texto:
'   -Opciones para reemplazar, solo configurables por administradores
'   -Se harán copias de los programas antes de reemplazar
'   -Se deben indicar las extensiones en las que se permite reemplazar
'   -Hay ciertas extensiones que no se podrán usar para reemplazar:
'    .*; .com; .exe; .dll; .lib; .tlb; .bin; .ocx; .zip; .rar; .cab; .jpg; .png; .gif; .tif; .ico; .bmp
'   Esto si está operativo:
'   -Se guardan los datos en el EventLog cuando hay error
'       y al iniciar y cerrar el formulario principal
'   -Solo se escribe en el event log de Windows si se ejecuta como administrador
'   -Cuando no es administrador, se usa My.Application.Long.WriteEntry
'       En Vista se guarda en: %APPDATA%\<empresa>\<ProductName>\<versión>
'       En XP    se guarda en: %APPDATA%\<empresa>\<ProductName>\<versión>
'   -Se muestra ToolTip en el ListView con el FullPath
'   -Menú contextual para el ListView para abrir fichero o directorio
'   -Los botones y menús de abrir directorio o fichero se habilitan cuando se selecciona un elemento
'       Al empezar a buscar se deshabilita
'       En el evento EnabledChanged de btnAbrirDir se controla el estado de los otros
'   -Permitir búsquedas por palabras completas
'   -Al reemplazar se muestran los ficheros cambiados en un formulario
'       con el texto nuevo y el original
'   -Al reemplazar texto, se comprueba que no se usen extensiones no permitidas
' v2.0.6.1
'   -Al reemplazar texto, se comprueba que solo sean las extensiones indicadas
' v2.0.6.9 -> v2.0.7.0 (26/Feb/08)
'   -Poder excluir directorios en la búsqueda
' v2.0.8.0 (28/Dic/12)
'   -Poder reemplazar y guardar automáticamente
' v2.0.9.0 ~ 2.0.10.0 (11/Oct/18)
'   -Solo cambio la versión de .NET de la 2.0 a la 4.5
'   -Algunos cambios en el código por "recomendación del asistente"
'      versión 15.8.7 del Visual Studio Community 2017
'   -Cambio Option Infer a On
'
' v3.0.0.0  (28/Oct/20) Lo cambio a .NET Framework 4.8
'                       Añado opción para buscar si NO TIENE el texto indicado
'                       Poder indicar el programa para abrir el fichero seleccionado
' v3.0.0.1  (29/Oct/20) Cambio la funcionalidad de NO TIENE (solo OR y AND)
' v3.0.0.2              Cambio la opción NO TIENE por indicar Múltiples cadenas
'                       para buscar varias cosas si se indican separadas por ;
' v3.0.0.3              Las asignaciones de qué buscar/cambiar lo hago antes de empezar
'                       la búsqueda, antes se asignaban en cada fichero que se buscaba.
' v3.0.0.4              Con AbrirCon se pueden abrir varios ficheros
' v3.0.0.5              Añado AbrirCon al menú contextual y menú fichero
' v3.0.0.6  (30/Oct/20) Para AbrirCon a los ficheros los pongo entre comillas dobles
' v3.0.0.7              Al guardar el tamaño de la ventana por error usaba GetValue en vez de SetValue.
'
'------------------------------------------------------------------------------
Option Strict On
Option Infer On

Imports Microsoft.VisualBasic
Imports vb = Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Drawing

Imports System.IO
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Text

Imports elGuille.BuscarTexto.elGuille.info.Util
Imports elGuille.BuscarTexto.elGuille.info.Util.Utilidades

Public Class Form1
    Private m_ExcluirDir As New List(Of String)
    Private m_Extensiones As New List(Of String)
    Private m_ExtensionesNO As New List(Of String)
    ' Para que no asigne el valor guardado en los directorios       (09/Feb/08)
    Friend ConLineaComandos As Boolean = False

    '' Para el nombre de la aplicación (como campo compartido)       (09/Feb/08)
    'Friend Shared NombreAplicacion As String
    ' Para los datos de configuración en un fichero
    Private m_Cfg As ConfigXml
    '' Campo compartido para saber si se ejecuta como administrador
    'Friend Shared EsAdministrador As Boolean

    'Private Enum TiposBusqueda
    '    SoloUno
    '    [Not]
    '    [And]
    '    [Or]
    'End Enum

    ' La fecha a buscar
    Private m_FechaBuscar As DateTime
    Private iniciando As Boolean = True

    Private expanded As New List(Of Boolean)
    Private grSize As New List(Of Size)

    Private cancelar As Boolean = False
    Private fechaAsignada As String
    Private dirExaminados As New List(Of String)

    ''' <summary>
    ''' Asignar a los datos de configuración
    ''' los contenidos de los controles y demás preferencias.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub guardarConfig()
        With My.Settings
            ' Los elementos de los combos se guardan como una cadena
            ' en la que se separa cada elemento de los combos con una barra vertical,
            ' esas cadenas las devuelven las propiedades que tiene el control de usuario.
            .ultimosDirectorios = directorios
            .ultimosFiltros = filtros
            .ultimosBuscar1 = buscar1
            .ultimosBuscar2 = buscar2
            .ultimosPoner1 = poner1
            .ultimosPoner2 = poner2

            ' Los valores individuales de cada opción
            .Directorio = cboDir.Text
            .Filtro = cboFiltro.Text
            .conSubDir = chkConSubDir.Checked
            .IgnorarError = chkIgnorarErrores.Checked
            .textoBuscar1 = cboBuscar1.Text
            .textoBuscar2 = cboBuscar2.Text
            .textoPoner1 = cboPoner1.Text
            .textoPoner2 = cboPoner2.Text
            .opcionBuscar = cboTipoBuca.Text
            .chkFecha = chkFecha.Checked
            .chkBuscarTexto = chkBuscar.Checked
            .chkPoner = chkPoner.Checked
            ' Nueva opción v3.0.0.0                                 (28/Oct/20)
            .chkMultiple = chkMultiple.Checked

            .distinguirMay = chkDistinguirMay.Checked
            ' Nuevas opciones                                       (07/Feb/08)
            .chkBuscarMismaLinea = chkBuscarMismaLinea.Checked
            .tsbMostrarResultados = If(tsbMostrarResultados.Checked, True, False)
            .dirConfig = System.IO.Path.GetDirectoryName(ficheroCfg())
            ' Nueva opción de palabras completas                    (10/Feb/08)
            .chkPalabrasCompletas = chkPalabrasCompletas.Checked

            ' Solo asignar la fecha si se ha cambiado desde que se asignó al iniciar
            ' (cuando está vacio el valor, se usa la fecha actual)
            If String.IsNullOrEmpty(txtFecha.Text) = False _
            AndAlso fechaAsignada.CompareTo(txtFecha.Text) <> 0 Then
                .Fecha = txtFecha.Text
            End If

            ' Para las opciones del tipo de búsqueda en las fechas  (29/Dic/07)
            If optFechaIgual.Checked Then
                .FechaTipoBusc = 0
            ElseIf optFechaMayor.Checked Then
                .FechaTipoBusc = 1
            ElseIf optfechaMenor.Checked Then
                .FechaTipoBusc = -1
            End If

            ' Guardar la visibilidad de los Expander
            .expanderBuscarExpanded = expanded(0)
            .expanderFicheroExpanded = expanded(1)

            ' Guardar el tamaño y posición del formulario,
            ' si está maximizado se guarda el valor de RestoreBounds
            If Me.WindowState = FormWindowState.Normal Then
                .Location = Me.Location
                .Size = Me.Size
            Else
                .Location = Me.RestoreBounds.Location
                .Size = Me.RestoreBounds.Size
            End If
            ' En Visual Basic (de forma predeterminada) no hace falta guardar los datos de configuración,
            ' pero por si se cambia en las propiedades del proyecto
            .Save()

            ' Guardar los datos en el fichero .cfg
            '
            ' Juansa dice que le da error al abrir y al cerrar, y por el mensaje de error,
            ' seguramente es por esto... pero a mi me funciona bien en el Server 2008 x64
            Try
                m_Cfg.SetValue("General", "Size", .Size.Width.ToString & ";" & .Size.Height.ToString)
            Catch ex As Exception
                EscribirEventLog("Error al guardar los datos del tamaño (Size), valores: " & .Size.ToString,
                                 EventLogEntryType.Error)
            End Try
            Try
                m_Cfg.SetValue("General", "Location", .Location.X.ToString & ";" & .Location.Y.ToString)
            Catch ex As Exception
                EscribirEventLog("Error al guardar los datos de la posición (Location), valores: " & .Location.ToString,
                                 EventLogEntryType.Error)
            End Try
            ' Nueva opción v3.0.0.0                                 (28/Oct/20)
            m_Cfg.SetValue("General", "chkSiNoTiene", .chkMultiple)
            m_Cfg.SetValue("General", "chkBuscarMismaLinea", .chkBuscarMismaLinea)
            m_Cfg.SetValue("General", "chkBuscarTexto", .chkBuscarTexto)
            m_Cfg.SetValue("General", "chkFecha", .chkFecha)
            m_Cfg.SetValue("General", "chkPalabrasCompletas", .chkPalabrasCompletas)
            m_Cfg.SetValue("General", "chkPoner", .chkPoner)
            m_Cfg.SetValue("General", "conSubDir", .conSubDir)
            m_Cfg.SetValue("General", "dirConfig", .dirConfig)
            m_Cfg.SetValue("General", "Directorio", .Directorio)
            m_Cfg.SetValue("General", "distinguirMay", .distinguirMay)
            m_Cfg.SetValue("General", "expanderBuscarExpanded", .expanderBuscarExpanded)
            m_Cfg.SetValue("General", "expanderFicheroExpanded", .expanderFicheroExpanded)
            m_Cfg.SetValue("General", "Fecha", .Fecha)
            m_Cfg.SetValue("General", "FechaTipoBusc", .FechaTipoBusc)
            m_Cfg.SetValue("General", "Filtro", .Filtro)
            m_Cfg.SetValue("General", "IgnorarError", .IgnorarError)
            m_Cfg.SetValue("General", "lvCol1", .lvCol1)
            m_Cfg.SetValue("General", "lvCol2", .lvCol2)
            m_Cfg.SetValue("General", "opcionBuscar", .opcionBuscar)
            m_Cfg.SetValue("General", "textoBuscar1", .textoBuscar1)
            m_Cfg.SetValue("General", "textoBuscar2", .textoBuscar2)
            m_Cfg.SetValue("General", "textoPoner1", .textoPoner1)
            m_Cfg.SetValue("General", "textoPoner2", .textoPoner2)
            m_Cfg.SetValue("General", "tsbMostrarResultados", .tsbMostrarResultados)
            m_Cfg.SetValue("General", "ultimosBuscar1", .ultimosBuscar1)
            m_Cfg.SetValue("General", "ultimosBuscar2", .ultimosBuscar2)
            m_Cfg.SetValue("General", "ultimosDirectorios", .ultimosDirectorios)
            m_Cfg.SetValue("General", "ultimosFiltros", .ultimosFiltros)
            m_Cfg.SetValue("General", "ultimosPoner1", .ultimosPoner1)
            m_Cfg.SetValue("General", "ultimosPoner2", .ultimosPoner2)
            m_Cfg.SetValue("General", "usarMisDocumentos", .usarMisDocumentos)
            m_Cfg.SetValue("General", "Extensiones", .Extensiones)
            '.ExtensionesNo = m_Cfg.GetValue("General", "ExtensionesNo", .ExtensionesNo)
            m_Cfg.SetValue("General", "chkHacerCopiaReemplazar", .chkHacerCopiaReemplazar)
            m_Cfg.SetValue("General", "chkPermitirReemplazar", .chkPermitirReemplazar)
            m_Cfg.SetValue("General", "DirBackupReemplazar", .DirBackupReemplazar)
            '
            ' Guardar automáticamente                               (28/Dic/12)
            m_Cfg.SetValue("General", "chkGuardarAutomaticamente", .chkGuardarAutomaticamente)
            '
            m_Cfg.SetValue("General", "chkExcluirDir", .chkExcluirDir)
            m_Cfg.SetValue("General", "txtExcluirDir", .txtExcluirDir)

            ' La posición y tamaño de la ventana                    (28/Oct/20)
            If Me.WindowState = FormWindowState.Normal Then
                m_Cfg.SetValue("Ventana", "Left", Me.Left)
                m_Cfg.SetValue("Ventana", "Top", Me.Top)
                ' Estaban con GetValue en vez de SetValue           (30/Oct/20)
                m_Cfg.SetValue("Ventana", "Width", Me.Width)
                m_Cfg.SetValue("Ventana", "Height", Me.Height)
            End If

            m_Cfg.Save()
        End With
    End Sub

    Private Sub leerCfg()
        With My.Settings
            ' Si es la primera vez, tendrá un valor -1
            ' por tanto, solo asignar la posición y tamaño si ya se ha ejecutado antes
            If .Location.X > -1 Then
                Me.Location = .Location
                Me.Size = .Size
            End If

            ' Leer los datos del fichero de configuración           (15/Dic/07)
            ' si el fichero .cfg no existe, se usan los datos actuales de configuración (Settings)

            ' Por si da error al hacer esta asignación              (09/Feb/08)
            Dim obj As Object
            Try
                obj = New SizeConverter().ConvertFromString(m_Cfg.GetValue("General", "Size",
                                                                           .Size.Width & ";" & .Size.Height))
                .Size = CType(obj, Size)
            Catch ex As Exception
                EscribirEventLog("Error al leer los datos del tamaño (Size), valores: " & .Size.ToString,
                                 EventLogEntryType.Error)
            End Try
            Try
                obj = New PointConverter().ConvertFromString(m_Cfg.GetValue("General", "Location",
                                                                            .Location.X & ";" & .Location.Y))
                .Location = CType(obj, Point)
            Catch ex As Exception
                EscribirEventLog("Error al leer los datos de la posición (Location), valores: " & .Location.ToString,
                                 EventLogEntryType.Error)
            End Try

            ' Nueva opción v3.0.0.0                                 (28/Oct/20)
            .chkMultiple = m_Cfg.GetValue("General", "chkSiNoTiene", .chkMultiple)
            .chkBuscarMismaLinea = m_Cfg.GetValue("General", "chkBuscarMismaLinea", .chkBuscarMismaLinea)
            .chkBuscarTexto = m_Cfg.GetValue("General", "chkBuscarTexto", .chkBuscarTexto)
            .chkFecha = m_Cfg.GetValue("General", "chkFecha", .chkFecha)
            ' Estaba mal, se asignaba a .chkPoner                   (28/Oct/20)
            .chkPalabrasCompletas = m_Cfg.GetValue("General", "chkPalabrasCompletas", .chkPalabrasCompletas)
            .chkPoner = m_Cfg.GetValue("General", "chkPoner", .chkPoner)
            .conSubDir = m_Cfg.GetValue("General", "conSubDir", .conSubDir)
            .dirConfig = m_Cfg.GetValue("General", "dirConfig", .dirConfig)
            .Directorio = m_Cfg.GetValue("General", "Directorio", .Directorio)
            .distinguirMay = m_Cfg.GetValue("General", "distinguirMay", .distinguirMay)
            .expanderBuscarExpanded = m_Cfg.GetValue("General", "expanderBuscarExpanded", .expanderBuscarExpanded)
            .expanderFicheroExpanded = m_Cfg.GetValue("General", "expanderFicheroExpanded", .expanderFicheroExpanded)
            .Fecha = m_Cfg.GetValue("General", "Fecha", .Fecha)
            .FechaTipoBusc = m_Cfg.GetValue("General", "FechaTipoBusc", .FechaTipoBusc)
            .Filtro = m_Cfg.GetValue("General", "Filtro", .Filtro)
            .IgnorarError = m_Cfg.GetValue("General", "IgnorarError", .IgnorarError)
            .lvCol1 = m_Cfg.GetValue("General", "lvCol1", .lvCol1)
            .lvCol2 = m_Cfg.GetValue("General", "lvCol2", .lvCol2)
            .opcionBuscar = m_Cfg.GetValue("General", "opcionBuscar", .opcionBuscar)
            .textoBuscar1 = m_Cfg.GetValue("General", "textoBuscar1", .textoBuscar1)
            .textoBuscar2 = m_Cfg.GetValue("General", "textoBuscar2", .textoBuscar2)
            .textoPoner1 = m_Cfg.GetValue("General", "textoPoner1", .textoPoner1)
            .textoPoner2 = m_Cfg.GetValue("General", "textoPoner2", .textoPoner2)
            .tsbMostrarResultados = m_Cfg.GetValue("General", "tsbMostrarResultados", .tsbMostrarResultados)
            .ultimosBuscar1 = m_Cfg.GetValue("General", "ultimosBuscar1", .ultimosBuscar1)
            .ultimosBuscar2 = m_Cfg.GetValue("General", "ultimosBuscar2", .ultimosBuscar2)
            .ultimosDirectorios = m_Cfg.GetValue("General", "ultimosDirectorios", .ultimosDirectorios)
            .ultimosFiltros = m_Cfg.GetValue("General", "ultimosFiltros", .ultimosFiltros)
            .ultimosPoner1 = m_Cfg.GetValue("General", "ultimosPoner1", .ultimosPoner1)
            .ultimosPoner2 = m_Cfg.GetValue("General", "ultimosPoner2", .ultimosPoner2)
            .usarMisDocumentos = m_Cfg.GetValue("General", "usarMisDocumentos", .usarMisDocumentos)
            '
            .Extensiones = m_Cfg.GetValue("General", "Extensiones", .Extensiones)
            '.ExtensionesNo = m_Cfg.GetValue("General", "ExtensionesNo", .ExtensionesNo)
            .chkHacerCopiaReemplazar = m_Cfg.GetValue("General", "chkHacerCopiaReemplazar", .chkHacerCopiaReemplazar)
            .chkPermitirReemplazar = m_Cfg.GetValue("General", "chkPermitirReemplazar", .chkPermitirReemplazar)
            .DirBackupReemplazar = m_Cfg.GetValue("General", "DirBackupReemplazar", .DirBackupReemplazar)
            '
            ' Guardar automáticamente                               (28/Dic/12)
            .chkGuardarAutomaticamente = m_Cfg.GetValue("General", "chkGuardarAutomaticamente", .chkGuardarAutomaticamente)
            '
            .chkExcluirDir = m_Cfg.GetValue("General", "chkExcluirDir", .chkExcluirDir)
            .txtExcluirDir = m_Cfg.GetValue("General", "txtExcluirDir", .txtExcluirDir)

            ' La lista de extensiones permitidas                    (11/Feb/08)
            ' actualizarla desde leerCfg, por si cambia
            Dim ext2() As String = .Extensiones.Split(";".ToCharArray,
                                                      StringSplitOptions.RemoveEmptyEntries)
            m_Extensiones.Clear()
            For Each s As String In ext2
                m_Extensiones.Add(s.ToLower.Trim)
            Next

            ext2 = .txtExcluirDir.Split(";".ToCharArray,
                                        StringSplitOptions.RemoveEmptyEntries)
            m_ExcluirDir.Clear()
            For Each s As String In ext2
                m_ExcluirDir.Add(s.ToLower.Trim)
            Next


            ' Asignar los elementos de los combos por medio de las propiedades
            ' definidas en el control de usuario
            directorios = .ultimosDirectorios
            filtros = .ultimosFiltros
            buscar1 = .ultimosBuscar1
            buscar2 = .ultimosBuscar2
            poner1 = .ultimosPoner1
            poner2 = .ultimosPoner2

            '----------------------------------------------------------
            ' Como aún no está toda la funcionalidad no implementada,
            ' ocultamos o deshabilitamos los controles que no se deben
            ' tener en cuenta.
            '----------------------------------------------------------

            '' Esta opción aún no está implementada
            '.expanderBuscarExpanded = False
            '.chkBuscarTexto = False
            '.textoBuscar1 = ""
            '.textoBuscar2 = ""
            'OpcionesBuscar1.chkBuscar.Enabled= .chkBuscarTexto

            '' TODO
            '' Esta opción aún no está implementada
            '.chkPoner = False
            '.chkPermitirReemplazar = False
            ' Reemplazar solo se permite en modo administrador      (10/Feb/08)
            If EsAdministrador = False Then
                .chkPoner = False
                .chkPermitirReemplazar = False
            End If
            '
            'chkPoner.Tag = False
            '.textoPoner1 = ""
            '.textoPoner2 = ""
            'chkPoner.Enabled = .chkPoner


            '' Esta opción aún no está implementada
            '.chkFecha = False
            'chkFecha.Enabled = .chkFecha


            ' Asignamos el resto de opciones
            If ConLineaComandos = False Then
                cboDir.Text = .Directorio
            End If
            cboFiltro.Text = .Filtro
            chkConSubDir.Checked = .conSubDir
            chkIgnorarErrores.Checked = .IgnorarError
            cboTipoBuca.Text = .opcionBuscar
            cboBuscar1.Text = .textoBuscar1
            cboBuscar2.Text = .textoBuscar2
            cboPoner1.Text = .textoPoner1
            cboPoner2.Text = .textoPoner2
            chkBuscar.Checked = .chkBuscarTexto
            ' Si esto está antes de que se asigne el valor Checked  (09/Feb/08)
            ' siempre se habilita
            chkPoner.Enabled = .chkPermitirReemplazar
            If .chkPermitirReemplazar = False Then
                .chkPoner = False
            End If
            '
            chkMultiple.Checked = .chkMultiple
            chkPoner.Checked = .chkPoner
            chkPoner.Tag = .chkPoner
            cboPoner1.Text = .textoPoner1
            cboPoner2.Text = .textoPoner2
            chkPoner.Enabled = .chkPermitirReemplazar

            chkDistinguirMay.Checked = .distinguirMay
            ' Para buscar en la misma línea o en todo el fichero    (07/Feb/08)
            chkBuscarMismaLinea.Checked = .chkBuscarMismaLinea
            ' Para las palabras completas                           (10/Feb/08)
            chkPalabrasCompletas.Checked = .chkPalabrasCompletas

            ' Opciones de búsqueda para mostrar o no los resultados (07/Feb/08)
            If .tsbMostrarResultados Then
                tsbMostrarResultados.Checked = True
                tsbNoMostrarResultados.Checked = False
            Else
                tsbMostrarResultados.Checked = False
                tsbNoMostrarResultados.Checked = True
            End If

            chkFecha.Checked = .chkFecha
            ' Si la fecha está vacía, usar la fecha actual
            If String.IsNullOrEmpty(.Fecha) Then
                txtFecha.Text = DateTime.Now.ToShortDateString
            Else
                txtFecha.Text = .Fecha
            End If
            ' El tipo de búsqueda en las fechas                     (29/Dic/07)
            If .FechaTipoBusc = 0 Then
                optFechaIgual.Checked = True
            ElseIf .FechaTipoBusc = 1 Then
                optFechaMayor.Checked = True
            Else
                optfechaMenor.Checked = True
            End If

            ' para saber si inicialmente .Fecha estaba vacio
            fechaAsignada = txtFecha.Text

            ' Para ajustar los controles
            chkBuscar_Checked(Nothing, Nothing)
            chkPoner_Checked(Nothing, Nothing)
            chkFecha_Checked(Nothing, Nothing)

            ' Asignar los valores negados para que se asignen bien en el evento
            expanded = New List(Of Boolean)
            expanded.Add(Not .expanderBuscarExpanded)
            expanded.Add(Not .expanderFicheroExpanded)
            pic1_Click(pic1, Nothing)
            pic1_Click(pic2, Nothing)

            ' El ancho de las columnas del listview
            If .lvCol1 > 0 Then
                lvFics.Columns(0).Width = .lvCol1
            End If
            If .lvCol2 > 0 Then
                lvFics.Columns(1).Width = .lvCol2
            End If
        End With

        ' La posición y tamaño de la ventana                        (28/Oct/20)
        Dim iLeft = m_Cfg.GetValue("Ventana", "Left", -1)
        Dim iTop = m_Cfg.GetValue("Ventana", "Top", -1)
        Dim iWidth = m_Cfg.GetValue("Ventana", "Width", -1)
        Dim iHeight = m_Cfg.GetValue("Ventana", "Height", -1)
        If iLeft = -1 Then
            Me.Left = 0
        Else
            If Screen.PrimaryScreen.WorkingArea.Left < iLeft Then
                Me.Left = iLeft
                'Else
                '    Me.Left = 0
            End If
        End If
        If iTop = -1 Then
            Me.Top = 0
        Else
            If Screen.PrimaryScreen.WorkingArea.Top < iTop Then
                Me.Top = iTop
                'Else
                '    Me.Top = 0
            End If
        End If
        If iHeight <> -1 Then
            Me.Height = iHeight
        End If
        If iWidth <> -1 Then
            Me.Width = iWidth
        End If
    End Sub

    'Friend Shared Sub EscribirEventLog(ByVal msg As String, ByVal tipo As EventLogEntryType)
    '    ' Solo si se tienen permisos de administrador
    '    If EsAdministrador Then
    '        EventLog.WriteEntry(NombreAplicacion, _
    '                            msg & _
    '                            vbCrLf & "v" & FileVersion & " " & DateTime.Now.ToString, _
    '                            tipo)
    '        ''
    '        'Dim log As EventLog = New EventLog()
    '        'log.Source = NombreAplicacion
    '        'log.Log = "Application"
    '        'log.WriteEntry(msg & vbCrLf & "v" & FileVersion & " " & DateTime.Now.ToString, tipo)
    '    Else
    '        Dim tipoVB As TraceEventType = TraceEventType.Information
    '        Select Case tipo
    '            Case EventLogEntryType.Error
    '                tipoVB = TraceEventType.Error
    '            Case EventLogEntryType.Information
    '                tipoVB = TraceEventType.Information
    '            Case EventLogEntryType.Warning
    '                tipoVB = TraceEventType.Warning
    '            Case Else
    '                tipoVB = TraceEventType.Information
    '        End Select
    '        My.Application.Log.WriteEntry(msg & _
    '                                      vbCrLf & "v" & FileVersion & " " & DateTime.Now.ToString, _
    '                                      tipoVB)
    '    End If

    '    '' Para probar en XP, etc.
    '    'Dim tipoVB As TraceEventType = TraceEventType.Information
    '    'Select Case tipo
    '    '    Case EventLogEntryType.Error
    '    '        tipoVB = TraceEventType.Error
    '    '    Case EventLogEntryType.Information
    '    '        tipoVB = TraceEventType.Information
    '    '    Case EventLogEntryType.Warning
    '    '        tipoVB = TraceEventType.Warning
    '    '    Case Else
    '    '        tipoVB = TraceEventType.Information
    '    'End Select
    '    'My.Application.Log.WriteEntry(msg & _
    '    '                              vbCrLf & "v" & FileVersion & " " & DateTime.Now.ToString, _
    '    '                              tipoVB)
    'End Sub


    ''' <summary>
    ''' Al cerrarse el formulario principal,
    ''' se guadan los valores de configuración.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Form1_FormClosing(ByVal sender As Object,
                                  ByVal e As FormClosingEventArgs) _
                                  Handles Me.FormClosing
        guardarConfig()
        EscribirEventLog("Se cierra la aplicación (FormClosing) ",
                         EventLogEntryType.Information)
    End Sub

    ''' <summary>
    ''' Al cargarse (mostrarse) el formulario principal,
    ''' asignamos los valores de la configuración e inicializamos
    ''' el control de usuario
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Form1_Load(ByVal sender As Object,
                           ByVal e As EventArgs) _
                           Handles MyBase.Load
        ' Inicialmente centrar el formulario                        (28/Oct/20)
        Me.CenterToScreen()

        EscribirEventLog("Se inicia la aplicación (Load) ",
                         EventLogEntryType.Information)

        ' Crear la lista de extensiones no permitidas               (10/Feb/08)
        ' Esta se asignan en el evento Load, no se cambia después
        Dim ext1() As String = My.Settings.ExtensionesNo.Split(";".ToCharArray,
                                                               StringSplitOptions.RemoveEmptyEntries)
        For Each s As String In ext1
            m_ExtensionesNO.Add(s.ToLower.Trim)
        Next

        ' Los directorios a excluir                                 (26/Feb/08)
        ext1 = My.Settings.txtExcluirDir.Split(";".ToCharArray,
                                               StringSplitOptions.RemoveEmptyEntries)
        m_ExcluirDir.Clear()
        For Each s As String In ext1
            m_ExcluirDir.Add(s.ToLower.Trim)
        Next

        ' Poner el botón de buscar dentro del statusStrip           (07/Feb/08)
        btnBuscar.Top = statusStrip1.Top + 3
        btnBuscar.Left = statusStrip1.Width - 119

        ' Comprobar si se ejecuta como administrador
        ' Asignarlo a la variable, para comprobar desde la configuración
        ' (se asigna en el constructor compartido)
        'EsAdministrador = _EsAdministrador()

        If EsAdministrador Then
            picAdmin.Image = My.Resources.escudo16_OK
            picAdmin.ToolTipText = "Ejecutando como administrador"
        Else
            picAdmin.Image = My.Resources.escudo16_Exclamation
            picAdmin.ToolTipText = "No estás ejecutando como administrador, " &
                                   "algunas búsquedas pueden producir error."
        End If

        LabelTiempo.Text = ""

        grSize.Add(Me.grupoExp1.Size)
        grSize.Add(Me.grupoExp2.Size)

        panel1.BackColor = Color.FromKnownColor(KnownColor.ControlLightLight)
        panel2.BackColor = Color.FromKnownColor(KnownColor.ControlLightLight)


        Dim fic As String = ficheroCfg()
        ' Crear el objeto de configuración
        m_Cfg = New ConfigXml(fic, False)
        leerCfg()

        With My.Application.Info
            Me.LabelInfo.Text = .Title & " v" & .Version.ToString & " (rev " & FileVersion & ") - " & .Copyright
        End With

        ' Los dos botones de abrir fichero o directorio
        ' solo deben estar habilitados si hay datos en el ListView
        Me.btnAbrirDir.Enabled = False
        ' Los otros se asignan en el evento EnabledChanged
        'Me.btnAbrirFic.Enabled = False
        'Me.mnuFicAbrirFichero.Enabled = btnAbrirFic.Enabled
        'Me.mnuFicAbrirDir.Enabled = btnAbrirDir.Enabled

        cboTipoBuca_SelectedIndexChanged(Nothing, Nothing)

        If tsbMostrarResultados.Checked Then
            tsbBuscar.ToolTipText = " Iniciar la búsqueda (se mostrarán los ficheros conforme se encuentren, esto es más lento)"
        Else
            tsbBuscar.ToolTipText = " Iniciar la búsqueda (no se mostrarán los ficheros conforme se encuentren, recomendado)"
        End If
        toolTip1.SetToolTip(btnBuscar, tsbBuscar.ToolTipText)


        iniciando = False
    End Sub

    ''' <summary>
    ''' Cuando se pulsa en el botón de buscar.
    ''' Si ya se está buscando, se muestra cancelar,
    ''' con idea de cancelar la búsqueda (además de evitar la reentrada).
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBuscar_Click(ByVal sender As Object,
                                ByVal e As EventArgs) _
                                Handles btnBuscar.Click,
                                        mnuFicBuscar.Click, tsbBuscar.ButtonClick

        ' Buscar de forma recursiva (si es necesario)
        Static yaEstoy As Boolean

        If yaEstoy Then
            cancelar = True
            Me.btnBuscar.Text = "Cancelando..."
            Me.tsbBuscar.Text = Me.btnBuscar.Text
            Application.DoEvents()
            Exit Sub
        End If
        yaEstoy = True

        ' Si se indica la fecha, comprobar que es correcta          (29/Dic/07)
        If Me.chkFecha.Checked Then
            If DateTime.TryParse(txtFecha.Text, m_FechaBuscar) = False Then
                MessageBox.Show("El formato de la fecha no es correcto " &
                                "para la configuración actual",
                                "Buscar",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                Me.txtFecha.Focus()
                yaEstoy = False
                Exit Sub
            End If
        End If

        ' Actualizar los contenidos de los combos
        ' (esto es para que se compruebe si el texto de cada combo
        ' está o no en la lista de elementos, si no está, se añade)
        actualizarCombos()

        ' Guardar los datos de configuración y estado de la ventana
        guardarConfig()

        ' Si se indica buscar, que haya algo                        (11/Feb/08)
        If chkBuscar.Checked Then
            If String.IsNullOrEmpty(cboBuscar1.Text) Then
                MessageBox.Show("Si quieres buscar texto, ¡debes indicar algo que buscar!",
                                "Buscar",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk)
                cboBuscar1.Focus()
                yaEstoy = False
                Exit Sub
            End If
            If cboTipoBuca.SelectedIndex <> BuscarReemplazar.TiposBusqueda.SoloUno Then
                If String.IsNullOrEmpty(cboBuscar2.Text) Then
                    MessageBox.Show("Si quieres buscar más de un texto, ¡también debes indicar algo que buscar!",
                                    "Buscar",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Asterisk)
                    cboBuscar2.Focus()
                    yaEstoy = False
                    Exit Sub
                End If
            End If
            If chkPoner.Checked Then
                If String.IsNullOrEmpty(cboPoner1.Text) Then
                    If MessageBox.Show("No has indicado que poner, esto indica que quieres quitar lo buscado." & vbCrLf &
                                       "¿Es eso lo que quieres hacer?",
                                       "Reemplazar en vacio",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question
                                       ) = Windows.Forms.DialogResult.No Then
                        cboPoner1.Focus()
                        yaEstoy = False
                        Exit Sub
                    End If
                End If
            End If
        End If

        ' Asignar las cadenas a buscar y poner                      (29/Oct/20)
        AsignarBuscar()
        '' Esta comprobación ya se hace más arriba
        'If Len(sb1) = 0 AndAlso Len(sb2) = 0 Then
        '    MessageBox.Show("No se ha indicado nada que buscar.",
        '                    "Buscar",
        '                    MessageBoxButtons.OK,
        '                    MessageBoxIcon.Information)
        '    Return
        '    'Return col
        'End If

        Me.lvFics.Items.Clear()

        Me.LabelInfo.Text = "Buscando los ficheros..."
        Me.Cursor = Cursors.AppStarting
        Me.btnBuscar.Text = "Cancelar"
        Me.tsbBuscar.Text = Me.btnBuscar.Text
        Me.grupoExp1.Enabled = False
        Me.grupoExp2.Enabled = False
        ' Habilitarlo si se muestran los resultados                 (09/Feb/08)
        ' (en realidad cuando se seleccione un elemento)
        btnAbrirDir.Enabled = False ' tsbMostrarResultados.Checked
        Me.Refresh()

        ' Esta colección se usará para saber los directorios examinados
        ' con idea de que no se comprueben más de una vez
        ' (por ejemplo si se indica el mismo directorio más de una vez)
        dirExaminados.Clear()

        ' Ocultar el ListView, esto acelera el proceso de búsqueda  (27/Dic/07)
        ' Como opción al buscar                                     (07/Feb/08)
        If My.Settings.tsbMostrarResultados Then
            Me.lvFics.Visible = True
            picBuscando.Visible = False
        Else
            ' Mostrar un gif animado mientras se está buscando          (28/Dic/07)
            picBuscando.Top = lvFics.Top + FlowLayoutPanel1.Top + (lvFics.Height \ 4)
            picBuscando.Left = (Me.Width - picBuscando.Width) \ 2
            picBuscando.BringToFront()

            Me.lvFics.Visible = False
            picBuscando.Visible = True
        End If

        totalFicAnalizados = 0

        ' Usar el StopWatch para calcular el tiempo empleado        (28/Dic/07)
        Dim stopW As Stopwatch
        stopW = Stopwatch.StartNew

        LabelTiempo.Text = "Iniciada a las " & DateTime.Now.ToString("HH:mm:ss")
        LabelTiempo.Refresh()

        ' Como se pueden indicar varios directorios,
        ' creamos un array con cada uno de los valores que haya
        ' (esos valores estarán separados por punto y coma)
        Dim dirs() As String
        dirs = My.Settings.Directorio.Split(";".ToCharArray, StringSplitOptions.RemoveEmptyEntries)
        ' Antes era un For Each y lo convierto con el asistente de la versión 15.8.7 (11/Oct/18)
        For i As Integer = 0 To dirs.Length - 1
            Dim d As String = dirs(i)
            ' Antes de hacer nada, comprobar si se ha cancelado
            Application.DoEvents()
            If cancelar Then Exit For

            Try
                ' No comprobar los directorios vacios
                ' (por si se pone más de un punto y coma)
                If String.IsNullOrEmpty(d.Trim()) Then Continue For

                ' Crear un objeto del tipo DirectoryInfo con el directorio a examinar
                Dim di As New DirectoryInfo(d.Trim())

                ' Si no existe el directorio, pues nada que hacer
                ' aunque puede que no exista porque se haya indicado un fichero
                ' en ese caso, el valor de di.Attribute será FileAttributes.Archive
                If di.Exists = False _
                AndAlso di.Attributes = FileAttributes.Archive Then
                    di = New DirectoryInfo(Path.GetDirectoryName(di.FullName))
                End If
                If di.Exists Then
                    ' ¡Empieza el espectáculo!
                    ' Recorrer cada uno de los directorios principales indicados
                    ' en este método se comprueba si se debe buscar en los subdirectorios.
                    Me.recorrerDir(di)
                End If

            Catch ex As Exception
                EscribirEventLog("Error al buscar:" & vbCrLf & ex.Message,
                                 EventLogEntryType.Error)

                ' Si se produce un error, mostrarlo
                ' y preguntar si se quiere cancelar.
                If MessageBox.Show("Error: " & ex.Message & vbCrLf &
                                   "¿Quieres cancelar la búsqueda?",
                                   "Buscar ficheros",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Exclamation
                                   ) = System.Windows.Forms.DialogResult.Yes Then
                    Exit For
                End If
            End Try
        Next

        picBuscando.Visible = False
        Me.lvFics.Visible = True
        stopW.Stop()
        Dim totalSec As Double = stopW.ElapsedMilliseconds / 1000
        Dim totalMin As Double = vb.Fix(totalSec / 60)
        totalSec = totalSec - totalMin * 60
        LabelTiempo.Text &= ", terminada a las " & DateTime.Now.ToString("HH:mm:ss")

        ' Mostrar el resultado de la búsqueda
        Me.Cursor = Cursors.Default
        Me.btnBuscar.Text = "Buscar"
        Me.tsbBuscar.Text = Me.btnBuscar.Text
        Me.grupoExp1.Enabled = True
        Me.grupoExp2.Enabled = True

        ' Los botones de abrir fichero o directorio
        ' solo habilitarlos si hay algo en el ListView
        ' La asignación de los ficheros hallados se hace en esta comprobación,
        ' para mostrar un mensaje más adecuado al no hallar ficheros
        If Me.lvFics.Items.Count > 0 Then
            Dim nFics As Integer = Me.lvFics.Items.Count
            If nFics = 1 Then
                Me.LabelInfo.Text = "Se ha hallado 1 fichero"
            Else
                Me.LabelInfo.Text = "Se han hallado " & nFics.ToString("#,###") & " ficheros"
            End If
            ' Se habilita cuando se selecciona un elemento          (09/Feb/08)
            'Me.btnAbrirDir.Enabled = True
        Else
            Me.LabelInfo.Text = "No se han hallado ficheros"
        End If
        Me.LabelInfo.Text &= String.Format(" en {0:#,###} analizado{1}. Tiempo empleado: {2:#,##0.##} min {3:#,##0.0000} seg",
                                           totalFicAnalizados, If(totalFicAnalizados = 1, "", "s"),
                                           totalMin, totalSec)

        Me.Refresh()

        cancelar = False

        yaEstoy = False
    End Sub

    Private totalFicAnalizados As Integer

    ''' <summary>
    ''' Método recursivo para buscar en cada directorio,
    ''' se añadirá al ListView los ficheros hallados.
    ''' Aquí se comprueba si se debe seguir buscando en los subdirectorios,
    ''' si es así, se vuelve a llamar a este método.
    ''' </summary>
    ''' <param name="di">
    ''' Un objeto DirectoryInfo con el directorio a comprobar
    ''' </param>
    ''' <remarks></remarks>
    Private Sub recorrerDir(ByVal di As DirectoryInfo)
        ' Antes de hacer nada, comprobar si se ha cancelado
        Application.DoEvents()
        If cancelar Then Exit Sub

        ' Si se deben excluir directorios                           (26/Feb/08)
        If My.Settings.chkExcluirDir Then
            For Each s As String In m_ExcluirDir
                If di.Name.ToLower.StartsWith(s) Then
                    Exit Sub
                End If
            Next
        End If

        ' Añadir al directorio a comprobar a la lista de directorios
        ' pero solo si no estaba ya.
        If dirExaminados.Contains(di.FullName.ToLower()) Then
            Exit Sub
        End If
        dirExaminados.Add(di.FullName.ToLower())

        Me.LabelInfo.Text = di.FullName & "..."
        Me.statusStrip1.Refresh()

        ' Las especificaciones de los ficheros a buscar estarán separadas por puntos y comas,
        ' crear un array con cada una de esas especificaciones.
        Dim especs() As String
        especs = My.Settings.Filtro.Split(";".ToCharArray,
                                          StringSplitOptions.RemoveEmptyEntries)

        Dim listaFics As New List(Of FileInfo)

        Try
            ' el asistente del Community 2017 v15.8.7 lo cambia a For (11/Oct/18)
            ' como tenía el Option Infer Off, puse el i As Integer
            For i As Integer = 0 To especs.Length - 1
                Dim espec As String = especs(i)
                ' Asignar al array los ficheros de este directorio
                ' que concuerdan con el filtro (especificación) indicada
                Dim fics() As FileInfo = di.GetFiles(espec.Trim(),
                                                     SearchOption.TopDirectoryOnly)

                ' Si hay ficheros coincidentes, 
                ' agregarlos a la colección.
                ' Esto es para después usar lo que haya en la colección,
                ' de esa forma, estarán todos los ficheros que coincidan
                ' con las especificaciones (filtros) indicados.
                If fics.Length = 0 Then Continue For

                ' El total de ficheros                              (07/Feb/08)
                totalFicAnalizados += fics.Length

                ' Si se debe comprobar la fecha                     (29/Dic/07)
                If Me.chkFecha.Checked Then
                    Dim copiaFics As New List(Of FileInfo)
                    Dim tipoBusc As Integer = My.Settings.FechaTipoBusc
                    For Each fi As FileInfo In fics
                        ' =  0 si son iguales
                        ' = -1 si el fichero es menor que la fecha indicada
                        ' =  1 si el fichero es mayor que la fecha indicada
                        If fi.LastWriteTime.ToString("yyyyMMdd").CompareTo(
                                    m_FechaBuscar.ToString("yyyyMMdd")) = tipoBusc Then
                            copiaFics.Add(fi)
                        End If
                    Next
                    fics = copiaFics.ToArray
                    If fics.Length = 0 Then
                        Continue For
                    End If
                End If
                ' Si se busca texto, llamar al método               (25/Dic/07)
                ' que devolverá solo los que coincidan
                If My.Settings.chkBuscarTexto Then
                    ' Antes no lo agregaba, lo asignaba: listaFics = buscarTexto(fics)
                    ' pero se debe agregar por si hay varias especificaciones
                    listaFics.AddRange(buscarTexto(fics))
                Else
                    listaFics.AddRange(fics)
                End If
            Next

            ' Añadir al ListView los ficheros que se hayan encontrado
            With Me.lvFics
                For Each fi As FileInfo In listaFics
                    Dim lvi As ListViewItem = .Items.Add(fi.Name)
                    lvi.SubItems.Add(fi.DirectoryName)
                    ' Añadir al ToolTip el nombre completo          (09/Feb/08)
                    lvi.ToolTipText = fi.FullName
                Next
            End With

            ' Si se deben comprobar los subdirectorios
            If My.Settings.conSubDir Then
                ' obtener todos los subdirectorios
                ' y examinarlos llamando recursivamente
                ' a este mismo método
                Dim dirs() As DirectoryInfo = di.GetDirectories()
                For Each dir As DirectoryInfo In dirs
                    recorrerDir(dir)
                Next
            End If

        Catch ex As DirectoryNotFoundException
            EscribirEventLog("Error en recorrerDir (DirectoryNotFound):" & vbCrLf & ex.Message,
                             EventLogEntryType.Error)

            ' Si el error es que no existe el directorio,
            ' mostrar el mensaje, independientemente del valor de la opción de ignorar errores
            If MessageBox.Show("Error, el directorio '" & di.FullName & "' " & vbCrLf &
                               "no existe." & vbCrLf &
                               "¿Quieres continuar?" & vbCrLf &
                               "(pulsa NO para cancelar)",
                               "Buscar en directorios",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Exclamation
                               ) = DialogResult.No Then
                cancelar = True
                Application.DoEvents()
            End If

            'Catch ex As IOException
            '    ' Este error se producirá si en lugar de un directorio
            '    ' se ha indicado un fichero

        Catch ex As Exception
            ' Si se produce cualquier otro error y se ha indicado
            ' que se ignoren los errores, pues... se sigue...
            ' Normalmente esto se produce porque se accede a un fichero
            ' que está bloqueado o al que no se tiene autorización para accederlo.
            If My.Settings.IgnorarError Then
                EscribirEventLog("Error en recorrerDir (se ignora el error):" & vbCrLf & ex.Message,
                                 EventLogEntryType.Warning)
                Exit Sub
            End If
            EscribirEventLog("Error en recorrerDir:" & vbCrLf & ex.Message,
                             EventLogEntryType.Error)

            ' Si se llega aquí es porque no está marcada la opción de ignorar errores
            ' y se da la oportunidad de que el usuario decida lo que quiere hacer.
            If MessageBox.Show("Error: " & ex.Message & vbCrLf &
                               "¿Quieres continuar?" & vbCrLf &
                               "(pulsa NO para cancelar)",
                               "Buscar en directorios",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Exclamation
                               ) = DialogResult.No Then
                cancelar = True
                Application.DoEvents()
            End If
        End Try

    End Sub

    ' Para buscar varias coincidencias separadas por ;          (29/Oct/20)
    Private colB1 As New List(Of String)
    Private colB2 As New List(Of String)

    Private sb1 As String
    Private sb2 As String

    Private sp1, sp2 As String

    Private tipoB As BuscarReemplazar.TiposBusqueda

    ''' <summary>
    ''' Asignar los valores a buscar.
    ''' Llamar antes de empezar la búsqueda.
    ''' </summary>
    ''' <remarks>Antes estaban las asignaciones en buscarTexto,
    ''' y se repetían las asignaciones en cada fichero encontrado.</remarks>
    Private Sub AsignarBuscar()
        tipoB = CType(cboTipoBuca.SelectedIndex, BuscarReemplazar.TiposBusqueda)

        sp1 = My.Settings.textoPoner1
        sp2 = My.Settings.textoPoner2

        If My.Settings.distinguirMay Then
            sb1 = My.Settings.textoBuscar1
            sb2 = My.Settings.textoBuscar2
        Else
            sb1 = My.Settings.textoBuscar1.ToLower
            sb2 = My.Settings.textoBuscar2.ToLower
        End If
        ' Cuando es Not o SoloUno, solo se tiene en cuenta el primero
        ' si es NOT se debe tener en cuenta el segundo              (29/Oct/20)
        Select Case tipoB
            'Case BuscarReemplazar.TiposBusqueda.Not,
            '     BuscarReemplazar.TiposBusqueda.SoloUno
            Case BuscarReemplazar.TiposBusqueda.SoloUno
                sb2 = ""
                sp2 = ""
        End Select

        colB1.Clear()
        colB2.Clear()

        ' Asignar las cadenas a buscar si se indica ;
        ' En caso de que solo haya una, se asignará la que esté
        If chkMultiple.Checked Then
            colB1.AddRange(sb1.Split(";"c))
            If Not String.IsNullOrEmpty(sb2) Then
                colB2.AddRange(sb2.Split(";"c))
            End If
        End If
    End Sub

    ''' <summary>
    ''' Buscar texto en los ficheros indicados
    ''' </summary>
    ''' <param name="fics"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' 25/Dic/07
    ''' </remarks>
    Private Function buscarTexto(ByVal fics() As FileInfo) As List(Of FileInfo)
        Dim col As New List(Of FileInfo)

        Application.DoEvents()
        If cancelar Then Return col

        'Dim tipoB As BuscarReemplazar.TiposBusqueda
        'tipoB = CType(cboTipoBuca.SelectedIndex, BuscarReemplazar.TiposBusqueda)
        Dim fMDI As fReemplazadosMDI = Nothing

        '' Para buscar varias coincidencias separadas por ;          (29/Oct/20)
        'Dim colB1 As New List(Of String)
        'Dim colB2 As New List(Of String)

        'Dim sb1 As String
        'Dim sb2 As String = ""
        'Dim sp1, sp2 As String
        'sp1 = My.Settings.textoPoner1
        'sp2 = My.Settings.textoPoner2

        'If My.Settings.distinguirMay Then
        '    sb1 = My.Settings.textoBuscar1
        '    sb2 = My.Settings.textoBuscar2
        'Else
        '    sb1 = My.Settings.textoBuscar1.ToLower
        '    sb2 = My.Settings.textoBuscar2.ToLower
        'End If
        '' Cuando es Not o SoloUno, solo se tiene en cuenta el primero
        '' si es NOT se debe tener en cuenta el segundo              (29/Oct/20)
        'Select Case tipoB
        '    'Case BuscarReemplazar.TiposBusqueda.Not,
        '    '     BuscarReemplazar.TiposBusqueda.SoloUno
        '    Case BuscarReemplazar.TiposBusqueda.SoloUno
        '        sb2 = ""
        '        sp2 = ""
        'End Select

        ' Esta comprobación no es necesaria                         (29/Oct/20)
        'If Len(sb1) = 0 AndAlso Len(sb2) = 0 Then
        '    Return col
        'End If

        If chkPoner.Checked Then
            If Len(sp1) = 0 AndAlso Len(sp2) = 0 Then
                Return col
            End If
            fMDI = New fReemplazadosMDI
        End If

        Dim aBuscar As New List(Of String)
        Dim aPoner As New List(Of String)
        aBuscar.Add(sb1)
        If Len(sb2) > 0 Then
            aBuscar.Add(sb2)
        End If
        aPoner.Add(sp1)
        If Len(sp2) > 0 Then
            aPoner.Add(sp2)
        End If

        For Each fi As FileInfo In fics
            ' Comprobar si es una extensión permitida               (10/Feb/08)
            If My.Settings.chkPoner Then
                ' Se comprueban las extensiones permitidas          (11/Feb/08)
                Dim sExtActual As String = fi.Extension.ToLower
                If m_ExtensionesNO.Contains(sExtActual) _
                OrElse m_Extensiones.Contains(sExtActual) = False Then
                    EscribirEventLog("Se ha indicado una extensión no permitida " &
                                     "o no indicada en las estensiones: '" & sExtActual,
                                     EventLogEntryType.Warning)
                    Continue For
                End If
            End If

            Dim guardarFi As Boolean = False
            Dim sGuardar As String = ""

            Using sr As New StreamReader(fi.FullName, Encoding.Default, True)
                Dim s As String

                ' Antes era:
                ' Si se debe buscar lo que NO esté,                 (28/Oct/20)
                ' Ahora es:
                ' Buscar varias cadenas separadas por ;             (29/Oct/20)
                ' solo se busca y no se reemplaza.
                ' Se aplicará tanto a Buscar como a la segunda cadena
                ' Solo se comprobará NOT y AND
                If chkMultiple.Checked Then
                    If My.Settings.distinguirMay Then
                        s = sr.ReadToEnd
                    Else
                        s = sr.ReadToEnd().ToLower
                    End If
                    Dim bAñadir = True
                    For i = 0 To colB1.Count - 1
                        If s.Contains(colB1(i)) Then
                            ' Si es NOT no debe estar ninguna de las indicadas en colB2
                            If cboTipoBuca.SelectedIndex = BuscarReemplazar.TiposBusqueda.Not Then
                                For j = 0 To colB2.Count - 1
                                    If s.Contains(colB2(j)) Then
                                        bAñadir = False
                                        Exit For
                                    End If
                                Next
                                ' Si es AND deben estar todas las indicadas en colB2
                            ElseIf cboTipoBuca.SelectedIndex = BuscarReemplazar.TiposBusqueda.And Then
                                For j = 0 To colB2.Count - 1
                                    If Not s.Contains(colB2(j)) Then
                                        bAñadir = False
                                        Exit For
                                    End If
                                Next
                                'Else
                                '    'col.Add(fi)
                                '    bAñadir = True
                            End If
                        Else
                            bAñadir = False
                        End If
                        If bAñadir Then
                            col.Add(fi)
                            Exit For
                        End If
                    Next
                    sr.Close()
                    Continue For
                End If

                If cboTipoBuca.SelectedIndex = BuscarReemplazar.TiposBusqueda.Not Then
                    ' Comprobar con el texto completo
                    ' ya que línea a línea no es fiable
                    If My.Settings.distinguirMay Then
                        s = sr.ReadToEnd
                    Else
                        s = sr.ReadToEnd().ToLower
                    End If
                    If s.Contains(sb1) AndAlso (Len(sb2) = 0 OrElse s.Contains(sb2) = False) Then
                        col.Add(fi)
                    End If
                    sr.Close()
                    Continue For
                End If
                While Not sr.EndOfStream
                    ' reemplazar solo se hará en todo el texto
                    If My.Settings.chkBuscarMismaLinea = False OrElse chkPoner.Checked Then
                        s = sr.ReadToEnd
                    Else
                        s = sr.ReadLine
                    End If

                    If chkPoner.Checked Then
                        Dim sNuevo As String = BuscarReemplazar.ReemplazaPalabras(s,
                                                                                  aBuscar.ToArray,
                                                                                  aPoner.ToArray,
                                                                                  tipoB,
                                                                                  chkDistinguirMay.Checked = False,
                                                                                  chkPalabrasCompletas.Checked)
                        If sNuevo <> s Then
                            ' Si se debe reemplazar directamente        (28/Dic/12)
                            ' Si se indica chkHacerCopiaReemplazar
                            ' aunque se haya indicado chkGuardarAutomaticamente
                            ' se seguirá haciendo la copia
                            If My.Settings.chkGuardarAutomaticamente = True AndAlso
                               My.Settings.chkHacerCopiaReemplazar = False Then

                                ' Guardar el fichero
                                guardarFi = True
                                sGuardar = sNuevo

                            Else
                                Dim fReemp As New fReemplazados(fi, sNuevo)
                                fReemp.MdiParent = fMDI
                                fReemp.Top = (fMDI.MdiChildren.Length - 1) * 3
                                fReemp.Left = (fMDI.MdiChildren.Length - 1) * 3
                                fReemp.Show()
                            End If

                            col.Add(fi)
                        End If
                        Exit While
                    Else
                        If BuscarReemplazar.ContienePalabras(s,
                                                             tipoB,
                                                             chkDistinguirMay.Checked = False,
                                                             chkPalabrasCompletas.Checked,
                                                             aBuscar.ToArray) Then
                            col.Add(fi)
                            Exit While
                        End If
                    End If
                    ' Si se busca en todo el fichero, salir         (07/Feb/08)
                    If My.Settings.chkBuscarMismaLinea = False Then
                        Exit While
                    End If
                End While
                sr.Close()
            End Using
            If guardarFi Then
                If guardarFichero(fi, sGuardar) Then
                    Exit For
                End If
            End If
        Next

        If chkPoner.Checked Then
            If fMDI.MdiChildren().Length > 0 Then
                fMDI.Show()
            Else
                fMDI = Nothing
            End If
        End If

        Return col
    End Function

    Private Sub lvFics_ColumnWidthChanged(ByVal sender As Object,
                                          ByVal e As ColumnWidthChangedEventArgs) _
                                          Handles lvFics.ColumnWidthChanged
        If iniciando Then Exit Sub

        With My.Settings
            .lvCol1 = lvFics.Columns(0).Width
            .lvCol2 = lvFics.Columns(1).Width
        End With
    End Sub

    Private Sub lvFics_ItemSelectionChanged(ByVal sender As Object,
                                            ByVal e As ListViewItemSelectionChangedEventArgs) _
                                            Handles lvFics.ItemSelectionChanged
        btnAbrirDir.Enabled = e.IsSelected
    End Sub

    ''' <summary>
    ''' Cuando se hace doble clic en un elemento del ListView
    ''' se comprueba si se ha pulsado en el nombre del fichero
    ''' o en el directorio, y así se hará una cosa u otra.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lvFics_MouseDoubleClick(ByVal sender As Object,
                                        ByVal e As MouseEventArgs) _
                                        Handles lvFics.MouseDoubleClick

        With lvFics
            If .SelectedIndices.Count = 0 Then
                Exit Sub
            End If

            ' Comprobar en que columna se ha hecho doble clic
            ' El valor de e.X es relativo al control,
            ' por tanto, no hace falta añadir nada más.
            If e.X < .Columns(0).Width Then
                ' El nombre

                ' Abrir el fichero indicado
                ' Combinar los paths para que se agregue el separador de directorio
                ' si así hiciera falta
                Dim fic As String = Path.Combine(.SelectedItems(0).SubItems(1).Text,
                                                 .SelectedItems(0).SubItems(0).Text)
                Process.Start(fic)
            Else
                ' El directorio

                ' Abrir la ventana con el directorio del fichero indicado
                Dim dir As String = .SelectedItems(0).SubItems(1).Text
                Process.Start("explorer.exe", dir)
            End If

        End With
    End Sub

    ''' <summary>
    ''' Al pulsar en el botón Abrir Fichero, 
    ''' abrir el fichero del elemento seleccionado en el ListView
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAbrirFic_Click(ByVal sender As Object,
                                  ByVal e As EventArgs) _
                                  Handles btnAbrirFic.Click, mnuFicAbrirFichero.Click, mnuContextAbrirFic.Click

        With lvFics
            If .SelectedIndices.Count = 0 Then
                Exit Sub
            End If

            ' Abrir el fichero indicado
            ' Combinar los paths para que se agregue el separador de directorio
            ' si así hiciera falta
            Dim fic As String = Path.Combine(.SelectedItems(0).SubItems(1).Text,
                                             .SelectedItems(0).SubItems(0).Text)

            ' Si no tiene programa asociado, dará error             (08/Feb/08)
            Try
                Process.Start(fic)
            Catch ex As Exception
                EscribirEventLog("Error al iniciar el proceso: '" & fic & "'" & vbCrLf & ex.Message,
                                 EventLogEntryType.Error)
                MessageBox.Show("Seguramente ese fichero no tiene un programa asociado:" & vbCrLf &
                                ex.Message,
                                "Abrir fichero",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk)
            End Try
        End With
    End Sub

    ''' <summary>
    ''' Abrir con el fichero indicado
    ''' </summary>
    ''' <remarks>28/Oct/2020</remarks>
    Private Sub btnAbrirCon_Click(sender As Object, e As EventArgs) Handles btnAbrirCon.Click, mnuContextAbrirCon.Click, mnuFicAbrirCon.Click
        With lvFics
            If .SelectedIndices.Count = 0 Then
                Exit Sub
            End If

            Dim sProg = My.Settings.AbrirCon
            Dim res = InputBox("Indica el programa a usar para abrir el fichero", "Abrir con...", sProg)
            res = res.Trim()
            If String.IsNullOrWhiteSpace(res) Then Return

            ' Comprobar si tiene espacios y no está entre comillas dobles
            If res.Contains(" ") AndAlso Not res.StartsWith(ChrW(34)) Then
                res = ChrW(34) & res & ChrW(34)
            End If

            ' Si hay varios ficheros seleccionados, abrirlos todos  (29/Oct/20)
            Dim fic As String = ""
            For i = 0 To .SelectedIndices.Count - 1
                Dim s = Path.Combine(.SelectedItems(i).SubItems(1).Text, .SelectedItems(i).SubItems(0).Text)
                ' ponerlo entre comillas dobles por si hay espacios (30/Oct/20)
                fic &= ChrW(34) & s & ChrW(34) & " "
            Next

            ' Abrir el fichero indicado
            ' Combinar los paths para que se agregue el separador de directorio
            ' si así hiciera falta
            'Dim fic As String = Path.Combine(.SelectedItems(0).SubItems(1).Text,
            '                                 .SelectedItems(0).SubItems(0).Text)

            ' Si no tiene programa asociado, dará error             (08/Feb/08)
            Try
                Dim p As New Process
                p.StartInfo.FileName = res
                p.StartInfo.Arguments = fic
                p.Start()
                'Process.Start(fic)

                ' Si todo fue bien, guardar el fichero en la configuración
                My.Settings.AbrirCon = res
            Catch ex As Exception
                EscribirEventLog("Error al iniciar el proceso: '" & res & "'" & vbCrLf & ex.Message,
                                 EventLogEntryType.Error)
                MessageBox.Show("Error al iniciar '" & res & "' " & vbCrLf &
                                "seguramente el path no es correcto:" & vbCrLf &
                                ex.Message,
                                "Abrir fichero con",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk)
            End Try
        End With
    End Sub

    ''' <summary>
    ''' Al pulsar en el botón Abrir directorio, 
    ''' abrir el directorio del elemento seleccionado en el ListView
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAbrirDir_Click(ByVal sender As Object,
                                  ByVal e As EventArgs) _
                                  Handles btnAbrirDir.Click, mnuFicAbrirDir.Click, mnuContextAbrirDir.Click

        With lvFics
            If .SelectedIndices.Count = 0 Then
                Exit Sub
            End If

            ' Abrir la ventana con el directorio del fichero indicado
            Dim dir As String = .SelectedItems(0).SubItems(1).Text
            ' Por si da error al abrir el directorio                (09/Feb/08)
            Try
                Process.Start("explorer.exe", dir)
            Catch ex As Exception
                EscribirEventLog("Error al iniciar el proceso con explorer.exe: '" & dir & "'" & vbCrLf & ex.Message,
                                 EventLogEntryType.Error)
                MessageBox.Show("Error al iniciar el proceso con explorer.exe:" & vbCrLf &
                                ex.Message,
                                "Abrir directorio",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk)
            End Try
        End With
    End Sub

    Private Sub btnAbrirDir_EnabledChanged(ByVal sender As Object,
                                           ByVal e As EventArgs) _
                                           Handles btnAbrirDir.EnabledChanged
        Me.btnAbrirFic.Enabled = btnAbrirDir.Enabled
        Me.mnuFicAbrirFichero.Enabled = btnAbrirFic.Enabled
        Me.mnuFicAbrirDir.Enabled = btnAbrirDir.Enabled
        Me.btnAbrirCon.Enabled = btnAbrirDir.Enabled
    End Sub


    ''' <summary>
    ''' Operaciones de arrastrar y soltar (drag &amp; drop)
    ''' Esto es por si se suelta en cualquier parte del formulario
    ''' (no solo en el control de usuario)
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    Private Sub txtDir_DragDrop(ByVal sender As Object,
                                ByVal e As DragEventArgs) _
                                Handles MyBase.DragDrop, cboDir.DragDrop, grupoExp2.DragDrop
        If e.Data.GetDataPresent("FileDrop") Then
            '' Para asignar solo el fichero/directorio soltado
            'cboDir.Text = CType(e.Data.GetData("FileDrop", True), String())(0)

            ' Si quieres agregar el fichero soltado a lo que ya hubiera,
            ' puedes usar este otro código:
            Dim sFic As String

            ' Para solo tener en cuenta el primero de los soltados
            'sFic = CType(e.Data.GetData("FileDrop", True), String())(0)

            ' Para asignar todos los directorios soltados
            Dim dirs() As String
            dirs = CType(e.Data.GetData("FileDrop", True), String())
            sFic = String.Join(";", dirs)

            If String.IsNullOrEmpty(cboDir.Text) = False Then
                cboDir.Text &= ";" & sFic
            Else
                cboDir.Text = sFic
            End If

        End If
    End Sub

    Private Sub txtDir_DragEnter(ByVal sender As Object,
                                 ByVal e As DragEventArgs) _
                                 Handles MyBase.DragEnter, cboDir.DragEnter, grupoExp2.DragEnter
        ' Drag & Drop, comprobar con DataFormats
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    ''' <summary>
    ''' Si se pulsa en la opción Salir del menú
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuFicSalir_Click(ByVal sender As Object,
                                  ByVal e As System.EventArgs) _
                                  Handles mnuFicSalir.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' La opción de examinar (elegir el directorio) se hace usando el código del control de usuario
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuFicExaminar_Click(ByVal sender As Object,
                                     ByVal e As System.EventArgs) _
                                     Handles mnuFicExaminar.Click
        'Me.OpcionesBuscar1.btnExaminarClick()
        btnExaminarDir_Click(Nothing, Nothing)
    End Sub

    Private Sub pic1_Click(ByVal sender As Object,
                           ByVal e As EventArgs) _
                           Handles pic1.Click, pic2.Click
        ' El picture en el que se ha hecho click
        Dim pic As PictureBox = TryCast(sender, PictureBox)
        If pic Is Nothing Then Exit Sub

        ' El panel en el que está este picture
        Dim expanderPanel As Panel = TryCast(pic.Parent, Panel)
        If expanderPanel Is Nothing Then Exit Sub

        ' El GroupBox en el que está el picture
        Dim expanderGroup As GroupBox = TryCast(expanderPanel.Parent, GroupBox)
        If expanderGroup Is Nothing Then Exit Sub

        ' El índice será el final del nombre menos uno
        ' (los pictures deben llamarse nnnn1, nnnn2, etc.)
        Dim index As Integer = CInt(vb.Right(pic.Name, 1)) - 1

        Dim expanderExpanded As Boolean = expanded(index)
        Dim expanderSize As Size = grSize(index)

        expanderExpanded = Not expanderExpanded

        If expanderExpanded Then
            pic.Image = My.Resources.ExpanderUp
            expanderGroup.Size = expanderSize
            'toolTip1.SetToolTip(pic, " Ocultar las opciones ")
        Else
            pic.Image = My.Resources.ExpanderDown
            expanderGroup.Size = expanderPanel.Size
            'toolTip1.SetToolTip(pic, " Mostrar las opciones ")
        End If

        expanded(index) = expanderExpanded

        ' Ajustar el tamaño del listview
        Me.lvFics.Height = FlowLayoutPanel1.Height - lvFics.Top - 4

    End Sub

    ' Los que estaban en el control WPF
    ''' <summary>
    ''' Devuelve el contenido del combo indicado como una cadena (string)
    ''' con cada elemento del combo separado por la barra vertical
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' Esta función se usa internamente en este control
    ''' para devolver los contenidos de los diferentes controles
    ''' </remarks>
    Private Function cbo2String(ByVal cbo As ComboBox) As String
        Dim lista As New List(Of String)
        For Each s As String In cbo.Items
            lista.Add(s)
        Next
        Return String.Join("|", lista.ToArray())
    End Function

    ''' <summary>
    ''' Asigna la cadena con los elementos a asignar al combo indicado.
    ''' Cada elemento estará separado por una barra vertical
    ''' </summary>
    ''' <param name="datos">
    ''' La cadena con los elementos sepados por una barra vertical
    ''' </param>
    ''' <param name="cbo">
    ''' El comboBox al que se asignarán esos elementos
    ''' </param>
    ''' <remarks>
    ''' Este método se usa internamente en este control
    ''' para asignar una cadena a cada uno de los combos usados
    ''' </remarks>
    Private Sub string2Cbo(ByVal datos As String, ByVal cbo As ComboBox)
        Dim ar() As String = datos.Split("|".ToCharArray,
                                         StringSplitOptions.RemoveEmptyEntries)
        cbo.Items.Clear()
        For Each s As String In ar
            cbo.Items.Add(s)
        Next
    End Sub

    ''' <summary>
    ''' Devuelve el contenido del combo cboDir
    ''' </summary>
    ''' <returns>
    ''' Un string en el que cada elemento está separado por una barra vertical
    ''' </returns>
    ''' <remarks></remarks>
    Private Property directorios() As String
        Get
            Return cbo2String(cboDir)
        End Get
        Set(ByVal value As String)
            string2Cbo(value, cboDir)
        End Set
    End Property


    ''' <summary>
    ''' Devuelve el contenido del combo cboFiltro
    ''' </summary>
    ''' <value></value>
    ''' <returns>
    ''' Un string en el que cada elemento está separado por una barra vertical
    ''' </returns>
    ''' <remarks></remarks>
    Private Property filtros() As String
        Get
            Return cbo2String(cboFiltro)
        End Get
        Set(ByVal value As String)
            string2Cbo(value, cboFiltro)
        End Set
    End Property


    ''' <summary>
    ''' Devuelve el contenido del combo cboBuscar1
    ''' </summary>
    ''' <returns>
    ''' Un string en el que cada elemento está separado por una barra vertical
    ''' </returns>
    ''' <remarks></remarks>
    Private Property buscar1() As String
        Get
            Return cbo2String(cboBuscar1)
        End Get
        Set(ByVal value As String)
            string2Cbo(value, cboBuscar1)
        End Set
    End Property

    ''' <summary>
    ''' Devuelve el contenido del combo cboBuscar2
    ''' </summary>
    ''' <returns>
    ''' Un string en el que cada elemento está separado por una barra vertical
    ''' </returns>
    ''' <remarks></remarks>
    Private Property buscar2() As String
        Get
            Return cbo2String(cboBuscar2)
        End Get
        Set(ByVal value As String)
            string2Cbo(value, cboBuscar2)
        End Set
    End Property

    ''' <summary>
    ''' Devuelve el contenido del combo cboPoner1
    ''' </summary>
    ''' <returns>
    ''' Un string en el que cada elemento está separado por una barra vertical
    ''' </returns>
    ''' <remarks></remarks>
    Private Property poner1() As String
        Get
            Return cbo2String(cboPoner1)
        End Get
        Set(ByVal value As String)
            string2Cbo(value, cboPoner1)
        End Set
    End Property

    ''' <summary>
    ''' Devuelve el contenido del combo cboPoner2
    ''' </summary>
    ''' <returns>
    ''' Un string en el que cada elemento está separado por una barra vertical
    ''' </returns>
    ''' <remarks></remarks>
    Private Property poner2() As String
        Get
            Return cbo2String(cboPoner2)
        End Get
        Set(ByVal value As String)
            string2Cbo(value, cboPoner2)
        End Set
    End Property

    ''' <summary>
    ''' Actualizar el contenido de los combos
    ''' de forma que si el texto no está en los elementos (Items)
    ''' se añada a la lista
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub actualizarCombos()
        With cboDir
            If .Items.Contains(.Text) = False Then
                .Items.Add(.Text)
            End If
        End With

        With cboFiltro
            If .Items.Contains(.Text) = False Then
                .Items.Add(.Text)
            End If
        End With

        With cboBuscar1
            If .Items.Contains(.Text) = False Then
                .Items.Add(.Text)
            End If
        End With

        With cboBuscar2
            If .Items.Contains(.Text) = False Then
                .Items.Add(.Text)
            End If
        End With

        With cboPoner1
            If .Items.Contains(.Text) = False Then
                .Items.Add(.Text)
            End If
        End With

        With cboPoner2
            If .Items.Contains(.Text) = False Then
                .Items.Add(.Text)
            End If
        End With

    End Sub

    ''' <summary>
    ''' Seleccionar el directorio en el que se hará la búsqueda inicial
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExaminarDir_Click(ByVal sender As Object,
                                     ByVal e As EventArgs) _
                                     Handles btnExaminarDir.Click
        'If m_EnEjecucion = False Then Exit Sub

        Dim oFD As New System.Windows.Forms.FolderBrowserDialog
        With oFD
            .Description = "Seleccionar el directorio de búsqueda"
            .RootFolder = Environment.SpecialFolder.MyComputer
            ' Si el texto tiene varios directorios,
            ' usar solo el primero
            If Me.cboDir.Text.Contains(";") Then
                Dim i As Integer = Me.cboDir.Text.IndexOf(";")
                .SelectedPath = Me.cboDir.Text.Substring(0, i)
            Else
                .SelectedPath = Me.cboDir.Text
            End If
            If .ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ' Si ya había un texto en el combo, agregarlo al final
                If String.IsNullOrEmpty(Me.cboDir.Text) = False Then
                    Me.cboDir.Text &= "; " & .SelectedPath
                Else
                    Me.cboDir.Text = .SelectedPath
                End If
            End If
        End With

    End Sub


    ''' <summary>
    ''' Cuando se produce el evento Checked o Unchecked del chkPoner,
    ''' habilitar adecuadamente los combos del texto a poner 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkPoner_Checked(ByVal sender As Object,
                                 ByVal e As EventArgs) _
                                 Handles chkPoner.CheckedChanged
        If My.Settings.chkPermitirReemplazar = False Then
            chkPoner.Tag = False
            Exit Sub
        End If

        Dim b As Boolean = chkPoner.Checked
        cboPoner1.Enabled = b

        ' En poner, solo habilitar el segundo cuando sea AND u OR
        If cboTipoBuca.SelectedIndex = BuscarReemplazar.TiposBusqueda.And _
        OrElse cboTipoBuca.SelectedIndex = BuscarReemplazar.TiposBusqueda.Or Then
            cboPoner2.Enabled = b
        Else
            cboPoner2.Enabled = False
        End If
        chkPoner.Tag = b

        'cboPoner2.Enabled = b
    End Sub

    'Private Sub chkPoner_EnabledChanged(ByVal sender As Object, _
    '                                    ByVal e As EventArgs) _
    '                                    Handles chkPoner.EnabledChanged
    '    'chkPoner.Tag = chkPoner.Enabled
    '    cboPoner1.Enabled = chkPoner.Checked
    '    cboPoner2.Enabled = chkPoner.Checked
    'End Sub


    ''' <summary>
    ''' Cuando se produce el evento Checked o Unchecked del chkBuscar,
    ''' habilitar adecuadamente los combos del texto a buscar,
    ''' también se asigna el texto del expander para indicar si se busca texto o no
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkBuscar_Checked(ByVal sender As Object,
                                  ByVal e As EventArgs) _
                                  Handles chkBuscar.CheckedChanged
        Dim b As Boolean = chkBuscar.Checked
        cboBuscar1.Enabled = b
        cboBuscar2.Enabled = b
        cboTipoBuca.Enabled = b
        If cboTipoBuca.SelectedIndex = 0 Then
            cboBuscar2.Enabled = False
        End If
        chkDistinguirMay.Enabled = b
        chkBuscarMismaLinea.Enabled = b
        chkPalabrasCompletas.Enabled = b

        If My.Settings.chkPermitirReemplazar = False Then
            chkPoner.Enabled = False
        Else
            chkPoner.Enabled = b
        End If
        ' Esto se hace en el evento chkPoner_EnabledChange          (09/Feb/08)
        'cboPoner1.Enabled = chkPoner.Enabled
        'cboPoner2.Enabled = chkPoner.Enabled

        ' chkPoner.Tag tendrá el valor de Checked
        ' de forma que si es False, se debe deshabilitar
        If chkPoner.Tag IsNot Nothing AndAlso CBool(chkPoner.Tag) = False Then
            chkPoner.Checked = False
            cboPoner1.Enabled = False
            cboPoner2.Enabled = False
        End If

        If b Then
            chkPoner_Checked(Nothing, Nothing)
            header1.Text = "Texto a buscar"
        Else
            header1.Text = "Texto a buscar (sin buscar texto)"
        End If
    End Sub

    ''' <summary>
    ''' Cuando se produce el evento Checked o Unchecked del chkFecha,
    ''' habilitar adecuadamente el texto de la fecha a usar en la búsqueda,
    ''' si no hay fecha, se pone el cursor en el control de la fecha
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkFecha_Checked(ByVal sender As Object,
                                 ByVal e As EventArgs) _
                                 Handles chkFecha.CheckedChanged
        'If m_EnEjecucion = False Then Exit Sub

        Me.txtFecha.Enabled = chkFecha.Checked
        optFechaIgual.Enabled = chkFecha.Checked
        optFechaMayor.Enabled = chkFecha.Checked
        optfechaMenor.Enabled = chkFecha.Checked

        ' Si se indica usar la fecha y está en blanco
        ' asignar la fecha actual y posicionar el cursor en la caja de textos
        If txtFecha.Enabled AndAlso String.IsNullOrEmpty(txtFecha.Text) Then
            txtFecha.Text = DateTime.Now.ToShortDateString
            txtFecha.SelectAll()
            txtFecha.Focus()
        End If
    End Sub

    Private Sub FlowLayoutPanel1_Resize(ByVal sender As Object,
                                        ByVal e As EventArgs) _
                                        Handles FlowLayoutPanel1.Resize
        Dim w As Integer = FlowLayoutPanel1.ClientRectangle.Width
        grupoExp1.Width = w - 6
        grupoExp2.Width = w - 6
        lvFics.Width = w - 6
        Me.lvFics.Height = FlowLayoutPanel1.Height - lvFics.Top - 4

        If grSize Is Nothing OrElse grSize.Count = 0 Then
            Exit Sub
        End If
        ' El alto no se debe cambiar en grSize
        grSize(0) = New Size(grupoExp1.Width, grSize(0).Height)
        grSize(1) = New Size(grupoExp2.Width, grSize(1).Height)

    End Sub

    Private Sub cboTipoBuca_SelectedIndexChanged(ByVal sender As Object,
                                                 ByVal e As EventArgs) _
                                                 Handles cboTipoBuca.SelectedIndexChanged
        ' Si es Solo uno (0) no habilitar el segundo
        If cboTipoBuca.SelectedIndex = BuscarReemplazar.TiposBusqueda.SoloUno Then
            Me.cboBuscar2.Enabled = False
        Else
            Me.cboBuscar2.Enabled = True
        End If

        ' En poner, solo habilitar el segundo cuando sea AND u OR
        If cboTipoBuca.SelectedIndex = BuscarReemplazar.TiposBusqueda.And _
        OrElse cboTipoBuca.SelectedIndex = BuscarReemplazar.TiposBusqueda.Or Then
            cboPoner2.Enabled = chkPoner.Checked
        Else
            cboPoner2.Enabled = False
        End If

        ' Si se selecciona Not, no permitir cambiar                 (10/Feb/08)
        If cboTipoBuca.SelectedIndex = BuscarReemplazar.TiposBusqueda.Not Then
            chkPoner.Checked = False
        End If
    End Sub


    Friend directorioCmd As String = ""

    Private Function cuantosCaracteres(ByVal cadena As String, ByVal caracter As String) As Integer
        Dim arr() As String = cadena.Split(caracter.ToCharArray,
                                           StringSplitOptions.RemoveEmptyEntries)
        Return arr.Length
    End Function

    Friend Sub lineaComandos(ByVal argumentos() As String)
        If argumentos.Length > 1 Then
            Dim j As Integer = 0
            Dim sDir As String = ""
            For i As Integer = 1 To argumentos.Length - 1

                ' Algunas veces, al iniciarlo desde Computer        (11/Feb/08)
                ' (indicando con el disco en vez de una carpeta)
                ' salen caracteres no válidos: C:" /sub /nobuscar /nofecha /noerror
                Dim cuantos As Integer
                cuantos = argumentos(i).IndexOf(":" & ChrW(34))
                If cuantos > -1 Then
                    argumentos(i) = argumentos(i).Substring(0, cuantos + 1) & "\"
                End If
                cuantos = cuantosCaracteres(argumentos(i), ChrW(34))
                ' Si es impar...
                If (cuantos Mod 2) <> 0 Then
                    ' Buscar el primero y quitar lo que haya detrás
                    cuantos = argumentos(i).IndexOf(ChrW(34))
                    If cuantos > -1 Then
                        argumentos(i) = argumentos(i).Substring(0, cuantos)
                    End If
                End If

                ' No tener en cuenta los vacios
                argumentos(i) = Microsoft.VisualBasic.Trim(argumentos(i))
                If String.IsNullOrEmpty(argumentos(i)) Then
                    Continue For
                End If

                ' Para las opciones
                If argumentos(i).StartsWith("-") OrElse argumentos(i).StartsWith("/") Then
                    Select Case argumentos(i).ToLower
                        Case "/usardir", "-usardir" ' "/shell", "-shell"
                            'If String.IsNullOrEmpty(Me.cboDir.Text) = False Then
                            '    sDir = directorioCmd & ";"
                            'End If
                            If String.IsNullOrEmpty(directorioCmd) = False Then
                                sDir = directorioCmd & ";"
                            End If
                        Case "/nobuscar", "/nb", "-nobuscar", "-nb"
                            chkBuscar.Checked = False
                        Case "/buscar", "-buscar"
                            chkBuscar.Checked = True
                        Case "/h", "-h", "/help", "-help"
                            My.Forms.fHelpShell.Show()
                            My.Forms.fHelpShell.Mostrar(True)
                            Application.DoEvents()
                            My.Forms.fHelpShell.BringToFront()
                        Case "/nofecha", "/nf", "-nofecha", "-nf"
                            chkFecha.Checked = False
                        Case "/fecha", "-fecha"
                            chkFecha.Checked = True
                        Case "/sub", "-sub"
                            chkConSubDir.Checked = True
                        Case "/nosub", "-nosub"
                            chkConSubDir.Checked = False
                        Case "/noerror", "-noerror"
                            chkIgnorarErrores.Checked = True
                        Case "/error", "-error"
                            chkIgnorarErrores.Checked = False
                        Case "/reg+", "-reg+"
                            fBuscarCfg.CrearShell(True)
                        Case "/reg-", "-reg-"
                            fBuscarCfg.CrearShell(False)
                    End Select
                    Continue For
                End If

                ' Añadirlo al combo de directorios
                j += 1
                If j = 1 Then
                    Me.cboDir.Text = sDir
                Else
                    Me.cboDir.Text &= ";"
                End If
                Me.cboDir.Text &= argumentos(i)
            Next
            If j > 0 Then
                Me.cboDir.Focus()
            End If
        End If

    End Sub


    ' AcercaDe                                                      (07/Feb/08)
    Private Sub mnuFicAcerca_Click(ByVal sender As Object,
                                   ByVal e As EventArgs) _
                                   Handles mnuFicAcerca.Click
        'Dim sb As New StringBuilder
        'sb.Append(My.Application.Info.Title)
        'sb.AppendFormat(" v{0} (rev {1})", My.Application.Info.Version, Form1.FileVersion)
        'sb.AppendLine()
        'sb.AppendLine()
        'sb.AppendLine(My.Application.Info.Description.Replace("  ", vbCrLf))
        'sb.AppendLine()
        'sb.AppendLine("Compilado con: " & My.Application.Info.Trademark)
        'sb.AppendFormat("Ejecutándose en: {0}{1}", System.Environment.OSVersion.VersionString, vbCrLf)
        'sb.AppendLine()
        'sb.Append(My.Application.Info.Copyright)
        'MessageBox.Show(sb.ToString, _
        '                "Acerca de " & My.Application.Info.Title, _
        '                MessageBoxButtons.OK, _
        '                MessageBoxIcon.Asterisk)
        My.Forms.fAcercaDe.ShowDialog()
    End Sub

    '' Property FileVersion                                          (07/Feb/08)
    'Friend Shared ReadOnly Property FileVersion() As String
    '    Get
    '        ' Solo asignar la info, la primera vez que se solicite  (09/Feb/08)
    '        Static yaEstuve As Boolean
    '        Static laVersion As String

    '        If yaEstuve = False Then
    '            Dim ensamblado As System.Reflection.Assembly = _
    '                    System.Reflection.Assembly.GetExecutingAssembly
    '            Dim fvi As System.Diagnostics.FileVersionInfo = _
    '                    System.Diagnostics.FileVersionInfo.GetVersionInfo(ensamblado.Location)

    '            ' Asignar la cadena de la versión del fichero
    '            laVersion = fvi.FileVersion
    '            ' Esto hará que no se vuelva a ejecutar este código
    '            yaEstuve = True
    '        End If

    '        Return laVersion
    '    End Get
    'End Property

    '' Cuando se inicie la primera instancia,                        (07/Feb/08)
    '' asignar el valor de si es administrador
    'Shared Sub New()
    '    EsAdministrador = _EsAdministrador()
    '    NombreAplicacion = My.Application.Info.ProductName
    'End Sub

    '' Comprobar si se ejecuta como administrador                    (07/Feb/08)
    'Private Shared Function _EsAdministrador() As Boolean
    '    My.User.InitializeWithWindowsUser()

    '    Return My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator)
    'End Function

    Private Sub mnuFicCfg_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFicCfg.Click
        My.Forms.fBuscarCfg.Close()
        ' Guardar la configuración antes de mostrar la configuración
        guardarConfig()

        Using fCfg As New fBuscarCfg
            'fCfg.ShowDialog(Me) = Windows.Forms.DialogResult.OK
            'If My.Forms.fBuscarCfg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            If fCfg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

                '' TODO
                '' Esta opción aún no está implementada              (09/Feb/08)
                'My.Settings.chkPermitirReemplazar = False
                If EsAdministrador = False Then
                    My.Settings.chkPermitirReemplazar = False
                End If

                guardarConfig()
                ' Actualizar el estado de poner                     (09/Feb/08)
                chkPoner.Enabled = My.Settings.chkPermitirReemplazar

                ' Si se ha cambiado el path del fichero de configuración
                If m_Cfg.FileName <> My.Settings.dirConfig Then
                    Dim fic As String = ficheroCfg()
                    Dim ficCfg As String = m_Cfg.FileName
                    If fic = ficCfg Then
                        Exit Sub
                    End If

                    Try
                        m_Cfg = Nothing
                        GC.Collect()
                        Application.DoEvents()

                        File.Copy(ficCfg, fic, True)
                    Catch ex As Exception
                        EscribirEventLog("Error al copiar la configuración: " & vbCrLf & ex.Message,
                                         EventLogEntryType.Error)
                        MessageBox.Show(ex.Message,
                                        Me.Text,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation)
                    Finally
                        m_Cfg = New ConfigXml(fic, False)
                        leerCfg()
                    End Try
                End If
            End If
            'fCfg.Close()
        End Using
    End Sub

    Private Sub mnuFicOpcionesShell_Click(ByVal sender As Object,
                                          ByVal e As EventArgs) _
                                          Handles mnuFicOpcionesShell.Click
        My.Forms.fHelpShell.WindowState = FormWindowState.Normal
        My.Forms.fHelpShell.Visible = True
        My.Forms.fHelpShell.Mostrar()
    End Sub

    Private Sub tsbMostrarResultados_Click(ByVal sender As Object,
                                           ByVal e As EventArgs) _
                                           Handles tsbMostrarResultados.Click, tsbNoMostrarResultados.Click
        If sender Is tsbMostrarResultados Then
            tsbMostrarResultados.Checked = Not tsbMostrarResultados.Checked
            tsbNoMostrarResultados.Checked = Not tsbMostrarResultados.Checked
        Else
            tsbNoMostrarResultados.Checked = Not tsbNoMostrarResultados.Checked
            tsbMostrarResultados.Checked = Not tsbNoMostrarResultados.Checked
        End If
        If tsbMostrarResultados.Checked Then
            tsbBuscar.ToolTipText = " Iniciar la búsqueda (se mostrarán los ficheros conforme se encuentren, esto es más lento)"
        Else
            tsbBuscar.ToolTipText = " Iniciar la búsqueda (no se mostrarán los ficheros conforme se encuentren, recomendado)"
        End If
        toolTip1.SetToolTip(btnBuscar, tsbBuscar.ToolTipText)
    End Sub

    Private Function ficheroCfg() As String
        Dim fic As String
        Dim dirCfg As String

        ' Para guardar el fichero en el directorio del ejecutable
        With My.Application.Info
            If My.Settings.usarMisDocumentos Then
                ' Mis Documentos\<aplicacion>
                dirCfg = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & .ProductName
                If My.Computer.FileSystem.DirectoryExists(dirCfg) = False Then
                    My.Computer.FileSystem.CreateDirectory(dirCfg)
                End If
            Else
                dirCfg = My.Settings.dirConfig
                If String.IsNullOrEmpty(dirCfg) Then
                    dirCfg = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                End If
                If dirCfg.ToLower().Contains(.ProductName.ToLower()) = False Then
                    dirCfg = Path.Combine(dirCfg, .ProductName)
                End If
                Try
                    If My.Computer.FileSystem.DirectoryExists(dirCfg) = False Then
                        My.Computer.FileSystem.CreateDirectory(dirCfg)
                    End If
                    My.Settings.usarMisDocumentos = False
                Catch ex As Exception
                    EscribirEventLog("Error al crear el directorio para guardar la configuración: " &
                                     "'" & dirCfg & "'" &
                                     vbCrLf & ex.Message,
                                     EventLogEntryType.Error)

                    ' Si da error al crear el path indicado, usar el del programa
                    dirCfg = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & .ProductName
                    'dirCfg = .DirectoryPath
                    My.Settings.usarMisDocumentos = True
                End Try
            End If
            fic = dirCfg & "\" & .ProductName & ".cfg"
        End With
        ' Asignar los valores de la configuración
        My.Settings.dirConfig = dirCfg

        Return fic
    End Function

    ''' <summary>
    ''' Devuelve True si hubo error
    ''' </summary>
    ''' <remarks>28/Dic/12</remarks>
    Private Function guardarFichero(fi As FileInfo, sNuevo As String) As Boolean
        'Throw New NotImplementedException
        Try
            Using sw As New StreamWriter(fi.FullName, False, Encoding.Default)
                sw.Write(sNuevo)
                sw.Flush()
                sw.Close()
            End Using
            'Dim fw As New StreamWriter(fi.OpenWrite)
            'fw.Write(sNuevo)
            'fw.Flush()
            'fw.Close()
            Return False
        Catch ex As Exception
            MessageBox.Show("Error al guardar el fichero:" & vbCrLf & ex.Message,
                            "Reemplazar",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True
        End Try
    End Function

    Private Sub chkMultiple_CheckedChanged(sender As Object, e As EventArgs) Handles chkMultiple.CheckedChanged
        If iniciando Then Return

        ' Si se marca esta opción quitar estas otras:               (28/Oct/20)
        ' No cambiar el tipo busca                                  (29/Oct/20)
        If chkMultiple.Checked Then
            chkPalabrasCompletas.Checked = False
            chkBuscarMismaLinea.Checked = False
            chkPoner.Checked = False
            'cboTipoBuca.SelectedIndex = BuscarReemplazar.TiposBusqueda.SoloUno
        End If

    End Sub
End Class
