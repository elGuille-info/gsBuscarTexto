'------------------------------------------------------------------------------
' BuscarReemplazar                                                  (10/Feb/08)
' Para las opciones de buscar y reemplazar
'
' ©Guillermo 'guille' Som, 2008
'------------------------------------------------------------------------------
Option Strict On
Option Infer On
'' Esto afectará solo a las funciones de Visual Basic
'Option Compare Text

Imports Microsoft.VisualBasic
Imports vb = Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports elGuille.BuscarTexto.elGuille.info.Util.Utilidades

Public Class BuscarReemplazar

    Public Enum TiposBusqueda
        SoloUno
        [Not]
        [And]
        [Or]
    End Enum

    Public Const Separadores As String = " .,;:¿?¡!()[]/-{}\_<>@#$%&=|+*'^€ºª" & _
                                         vb.vbTab & vb.ChrW(34) & vb.vbCr & vb.vbLf

    ''' <summary>
    ''' Comprueba si el texto indicado tiene la palabra como palabra completa
    ''' </summary>
    ''' <param name="texto">
    ''' Texto en el que se buscará la palabra
    ''' </param>
    ''' <param name="palabra">
    ''' Palabra que se quiere comprobar si está y es completa
    ''' </param>
    ''' <param name="ignorarMays">
    ''' False para distinguir mayúsculas de minúsculas
    ''' True para ignorar la comparación exacta
    ''' </param>
    ''' <returns>
    ''' True si es completa, false si no es completa (o no está)
    ''' </returns>
    ''' <remarks>
    ''' 10/Feb/08
    ''' </remarks>
    Public Shared Function PalabraCompleta(ByVal texto As String, _
                                           ByVal palabra As String, _
                                           Optional ByVal ignorarMays As Boolean = False _
                                           ) As Boolean
        Return (PosicionPalabraCompleta(texto, palabra, ignorarMays) > -1)

        'Dim pos As Integer
        'If ignorarMays Then
        '    pos = texto.IndexOf(palabra, StringComparison.OrdinalIgnoreCase)
        'Else
        '    pos = texto.IndexOf(palabra, StringComparison.Ordinal)
        'End If
        'If pos < 0 Then Return False

        '' El separador anterior
        'Dim i As Integer = texto.LastIndexOfAny(Separadores.ToCharArray, pos)

        '' El separador siguiente
        'Dim j As Integer = texto.IndexOfAny(Separadores.ToCharArray, pos + palabra.Length)

        '' Si no hay separadores delante ni detrás es que es una palabra completa
        'If i = -1 AndAlso j = -1 Then
        '    Return True
        'End If

        '' La palabra completa (o frase)
        'Dim laPalabra As String = texto.Substring(i + 1, j - i - 1)

        'Return (String.Compare(palabra, laPalabra, ignorarMays) = 0)
    End Function

    Public Shared Function PosicionPalabraCompleta(ByVal texto As String, _
                                                   ByVal palabra As String, _
                                                   Optional ByVal ignorarMays As Boolean = False _
                                                   ) As Integer
        Dim pos As Integer = -1
        Dim iPos As Integer = 0
        While pos = -1 AndAlso iPos < texto.Length
            If ignorarMays Then
                pos = texto.IndexOf(palabra, iPos, StringComparison.OrdinalIgnoreCase)
            Else
                pos = texto.IndexOf(palabra, iPos, StringComparison.Ordinal)
            End If
            If pos < 0 Then Return -1

            ' El separador anterior
            Dim i As Integer = texto.LastIndexOfAny(Separadores.ToCharArray, pos)

            ' El separador siguiente
            Dim j As Integer
            If pos + palabra.Length > texto.Length Then
                j = texto.Length
            Else
                j = texto.IndexOfAny(Separadores.ToCharArray, pos + palabra.Length)
            End If

            ' Si no hay separadores delante ni detrás es que es una palabra completa,
            ' o no hay delante y el que hay detrás es una posición más,
            ' o no hay detrás y el que hay delante es una posición menos,
            ' o el que hay delante está una posición antes y el que está detrás es una posición más
            If (i = -1 AndAlso j = -1) _
            OrElse (i = -1 AndAlso j = pos + palabra.Length) _
            OrElse (j = -1 AndAlso i = pos - 1) _
            OrElse (i = pos - 1 AndAlso j = pos + palabra.Length) Then
                Return pos
            End If

            iPos = pos + 1
            pos = -1
        End While

        Return -1
    End Function


    ''' <summary>
    ''' Comprueba si el texto indicado tiene la palabra a buscar
    ''' </summary>
    ''' <param name="texto"></param>
    ''' <param name="palabra"></param>
    ''' <param name="ignorarMays">
    ''' Opcional, si no se indica es False
    ''' </param>
    ''' <param name="esCompleta">
    ''' Opcional, si se buscan palabras completas
    ''' </param>
    ''' <returns>
    ''' True si está la palabra,
    ''' False en otro caso
    ''' </returns>
    ''' <remarks></remarks>
    Public Shared Function ContienePalabra(ByVal texto As String, _
                                           ByVal palabra As String, _
                                           Optional ByVal ignorarMays As Boolean = False, _
                                           Optional ByVal esCompleta As Boolean = False _
                                           ) As Boolean
        If esCompleta Then
            Return PalabraCompleta(texto, palabra, ignorarMays)
        End If

        If ignorarMays Then
            Return texto.ToLower().Contains(palabra.ToLower())
        Else
            Return texto.Contains(palabra)
        End If
    End Function

    ''' <summary>
    ''' Comprueba si el texto tiene las dos palabras indicadas
    ''' </summary>
    ''' <param name="texto"></param>
    ''' <param name="palabra1"></param>
    ''' <param name="palabra2"></param>
    ''' <param name="tipoBusqueda"></param>
    ''' <param name="ignorarMays"></param>
    ''' <param name="esCompleta"></param>
    ''' <returns>
    ''' True coincide con lo indicado,
    ''' False en otro caso
    ''' </returns>
    ''' <remarks></remarks>
    Public Shared Function ContienePalabras(ByVal texto As String, _
                                            ByVal palabra1 As String, ByVal palabra2 As String, _
                                            ByVal tipoBusqueda As TiposBusqueda, _
                                            Optional ByVal ignorarMays As Boolean = False, _
                                            Optional ByVal esCompleta As Boolean = False _
                                            ) As Boolean
        Return ContienePalabras(texto, tipoBusqueda, ignorarMays, esCompleta, New String() {palabra1, palabra2})
    End Function

    ''' <summary>
    ''' Comprueba si todas las palabras indicadas están en el texto
    ''' Se tiene en cuenta si se distingue mayúsculas de minúsculas
    ''' y el tipo de comparación a hacer
    ''' </summary>
    ''' <param name="texto"></param>
    ''' <param name="tipoBusqueda"></param>
    ''' <param name="ignorarMays"></param>
    ''' <param name="esCompleta"></param>
    ''' <param name="palabras"></param>
    ''' <returns>
    ''' True coincide con lo indicado,
    ''' False en otro caso
    ''' </returns>
    ''' <remarks></remarks>
    Public Shared Function ContienePalabras(ByVal texto As String, _
                                            ByVal tipoBusqueda As TiposBusqueda, _
                                            ByVal ignorarMays As Boolean, _
                                            ByVal esCompleta As Boolean, _
                                            ByVal ParamArray palabras() As String) As Boolean
        Dim veces As Integer = 0
        If ignorarMays Then
            texto = texto.ToLower
        End If

        Dim bHallado As Boolean = False

        For Each s As String In palabras
            bHallado = False
            If esCompleta Then
                bHallado = PalabraCompleta(texto, s, ignorarMays)
            Else
                If ignorarMays Then
                    s = s.ToLower
                End If
                bHallado = texto.Contains(s)
            End If
            If bHallado Then
                veces += 1
                ' Si la comparación es OR con que haya una, es suficiente
                If tipoBusqueda <> TiposBusqueda.And Then
                    Exit For
                End If
            Else
                ' Si la comparación es AND deben estar todas las palabras
                If tipoBusqueda = TiposBusqueda.And Then
                    ' Si no está, salir
                    veces = -1
                    Exit For
                End If
            End If
        Next
        ' Si la comparación es AND deben estar todas las palabras
        ' Si la comparación es OR con que haya una, es suficiente
        Select Case tipoBusqueda
            Case TiposBusqueda.And
                Return (veces = palabras.Length)
            Case Else 'TiposBusquedaAndOr.Or
                Return (veces > 0)
        End Select

        Return False
    End Function

    '''' <summary>
    '''' Reemplaza la palabra buscada por la indicada
    '''' </summary>
    '''' <param name="texto"></param>
    '''' <param name="buscar"></param>
    '''' <param name="poner"></param>
    '''' <param name="ignorarMays"></param>
    '''' <param name="esCompleta"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Shared Function ReemplazaPalabra(ByVal texto As String, _
    '                                        ByVal buscar As String, _
    '                                        ByVal poner As String, _
    '                                        Optional ByVal ignorarMays As Boolean = False, _
    '                                        Optional ByVal esCompleta As Boolean = False _
    '                                        ) As Boolean
    'End Function

    ''' <summary>
    ''' El número máximo de palabras que se pueden buscar o reemplazar
    ''' </summary>
    ''' <remarks></remarks>
    Public Const MaximoPalabrasBuscarReemplazar As Integer = 2

    ''' <summary>
    ''' Reemplaza cada una de las palabras indicadas en buscar() 
    ''' por las correspondientes en poner()
    ''' Si se indica AND se reemplazarán todas (si están todas),
    ''' si se indica OR solo las que coincidan.
    ''' Si poner solo tiene una palabra,
    ''' se reemplazarán todas las indicadas en buscar por esa palabra.
    ''' Solo se permite un máximo de dos palabras en buscar o poner
    ''' (el valor indicado en <seealso cref="MaximoPalabrasBuscarReemplazar">MaximoPalabrasBuscarReemplazar</seealso>).
    ''' </summary>
    ''' <param name="texto">El texto donde se hará la búsqueda</param>
    ''' <param name="buscar">Array con las palabras a buscar</param>
    ''' <param name="poner">Array con las palabras a poner</param>
    ''' <param name="tipoBusqueda">Un valor del tipo <see cref="TiposBusqueda"/></param>
    ''' <param name="ignorarMays">Si la comparación es sin distinguir mayúsculas de minúscuals</param>
    ''' <param name="esCompleta">Si se debe buscar palabra completa</param>
    ''' <returns>El texto, modificado o no</returns>
    ''' <remarks></remarks>
    Public Shared Function ReemplazaPalabras(ByVal texto As String, _
                                             ByVal buscar() As String, _
                                             ByVal poner() As String, _
                                             ByVal tipoBusqueda As TiposBusqueda, _
                                             Optional ByVal ignorarMays As Boolean = False, _
                                             Optional ByVal esCompleta As Boolean = False _
                                             ) As String
        If String.IsNullOrEmpty(texto) Then
            EscribirEventLog("Se ha indicado una cadena vacía en el texto donde buscar" & _
                             " en ReemplazarPalabras", EventLogEntryType.Warning)
            Return texto
        End If
        If buscar Is Nothing OrElse buscar.Length = 0 Then
            EscribirEventLog("Se ha indicado un array vacio en las palabras a buscar" & _
                             " en ReemplazarPalabras", EventLogEntryType.Warning)
            Return texto
        End If
        If poner Is Nothing OrElse poner.Length = 0 Then
            EscribirEventLog("Se ha indicado un array vacio en las palabras a poner" & _
                             " en ReemplazarPalabras", EventLogEntryType.Warning)
            Return texto
        End If
        If poner.Length > buscar.Length Then
            EscribirEventLog("El número de palabras a poner debe ser menor o igual al de buscar." & _
                             " En ReemplazarPalabras.", _
                             EventLogEntryType.Warning)
            'Throw New ArgumentException("El número de palabras a poner debe ser menor o igual al de buscar.", "poner()")
            'Return False
        End If
        If tipoBusqueda <> TiposBusqueda.SoloUno Then
            If buscar.Length < 2 Then
                EscribirEventLog("Se ha indicado un array de menos de 2 palabras" & _
                                 " y se ha indicado TiposBusqueda." & tipoBusqueda.ToString & _
                                 ". En ReemplazarPalabras", EventLogEntryType.Warning)
                Return texto
            End If
        End If

        ' Buscar el máximo de palabras indicadas
        Dim n As Integer = buscar.Length
        If n > MaximoPalabrasBuscarReemplazar Then
            n = MaximoPalabrasBuscarReemplazar
        End If

        ' Si solo se busca una palabra
        ' el valor debe ser SoloUno
        If n = 1 Then
            If tipoBusqueda <> TiposBusqueda.SoloUno Then
                'Return texto
                tipoBusqueda = TiposBusqueda.SoloUno
            End If
        End If

        ' Las posiciones de las palabras halladas
        Dim posiciones As New System.Collections.Generic.List(Of Integer)

        ' Recorrer todas las palabras de buscar
        ' si la primera no está, no aceptar este fichero            (03/Nov/20)
        For i As Integer = 0 To n - 1
            Dim sBusc As String = buscar(i)
            Dim pos As Integer = -1
            If esCompleta Then
                pos = PosicionPalabraCompleta(texto.ToString, sBusc, ignorarMays)
            Else
                If ignorarMays Then
                    pos = texto.ToString.IndexOf(sBusc, StringComparison.OrdinalIgnoreCase)
                Else
                    pos = texto.ToString.IndexOf(sBusc, StringComparison.Ordinal)
                End If
            End If
            ' si la primera no se encuentra y NO es tipoBusqueda OR (03/Nov/20)
            ' no hay que reemplazar
            ' Ya que:
            ' Si es SoloUno debe estar la primera coincidencia
            ' Si es And     deben estar las 2 coincidencias
            ' Si es Not     debe estar al menos la primera coincidencia
            ' Si es Or      puede estar la primera o la segunda
            If i = 0 AndAlso pos = -1 AndAlso tipoBusqueda <> TiposBusqueda.Or Then
                posiciones.Clear()
                Exit For
            End If
            posiciones.Add(pos)
        Next

        If posiciones.Count = 0 Then
            Return texto
        End If

        '----------------------------------------------------------------------
        ' Las acciones a realizar son:
        ' Si se indica AND:
        '   En buscar debe haber 2 palabras
        '       Solo se cambia si las dos están
        '       Si hay una en poner, se cambian las dos
        '       Si hay dos en poner, se cambia cada una por la correspondiente
        '           b1 -> p1, b2 -> p2
        ' Si se indica OR:
        '   En buscar debe haber 2 palabras
        '       Se cambiará si alguna está
        '       Si hay una en poner, se cambia con esa
        '       Si hay dos en poner, b1 -> p1, b2 -> p2
        ' Si se indica "Solo una"
        '   En buscar hay una palabra
        '       Se tiene en cuenta solo la primera de poner
        '       Se cambia b1 -> p1
        '----------------------------------------------------------------------

        ' Si no se ha hallado ninguna palabra
        Dim cuantasMal As Integer = 0
        For i As Integer = 0 To posiciones.Count - 1
            If posiciones(i) = -1 Then
                cuantasMal += 1
            End If
        Next
        ' Si es AND, se deben cumplir las dos
        If tipoBusqueda = TiposBusqueda.And AndAlso cuantasMal > 0 Then
            Return texto
        End If
        ' Si se busca NOT debe haber 1 mal y 1 bien                 (03/Nov/20)
        ' pero la primera debe ser "bien" (se comprueba más arriba)
        If tipoBusqueda = TiposBusqueda.Not AndAlso cuantasMal <> 1 Then
            Return texto
        End If
        ' Si es soloUno solo debe haber una coincidencia            (03/Nov/20)
        ' y ninguna mal, pero esto último no comprobarlo
        If tipoBusqueda = TiposBusqueda.SoloUno AndAlso posiciones.Count <> 1 Then
            Return texto
        End If
        ' Si todas están mal, salir
        If cuantasMal = posiciones.Count Then
            Return texto
        End If

        ' Si es AND, deben estar las dos palabras
        If tipoBusqueda = TiposBusqueda.And Then
            If buscar.Length = 1 Then
                Return texto
            End If
            ' Sustituir las dos
            If poner.Length = 1 Then
                For i As Integer = 0 To buscar.Length - 1
                    If posiciones(i) < 0 Then Continue For
                    texto = texto.Substring(0, posiciones(i)) & poner(0) & texto.Substring(posiciones(i) + buscar(i).Length)
                Next
                Return ReemplazaPalabras(texto.ToString, buscar, poner, tipoBusqueda, ignorarMays, esCompleta)
            Else
                ' Sustituir cada una
                For i As Integer = 0 To buscar.Length - 1
                    If posiciones(i) < 0 Then Continue For
                    texto = texto.Substring(0, posiciones(i)) & poner(i) & texto.Substring(posiciones(i) + buscar(i).Length)
                Next
                Return ReemplazaPalabras(texto.ToString, buscar, poner, tipoBusqueda, ignorarMays, esCompleta)
            End If

            ' Si es OR
        ElseIf tipoBusqueda = TiposBusqueda.Or Then
            If buscar.Length = 1 Then
                If posiciones(0) > -1 Then
                    texto = texto.Substring(0, posiciones(0)) & poner(0) & texto.Substring(posiciones(0) + buscar(0).Length)
                    Return ReemplazaPalabras(texto.ToString, buscar, poner, tipoBusqueda, ignorarMays, esCompleta)
                End If
                Return texto
            Else
                If poner.Length = 1 Then
                    For i As Integer = 0 To buscar.Length - 1
                        If posiciones(i) < 0 Then Continue For
                        texto = texto.Substring(0, posiciones(i)) & poner(0) & texto.Substring(posiciones(i) + buscar(i).Length)
                    Next
                    Return ReemplazaPalabras(texto.ToString, buscar, poner, tipoBusqueda, ignorarMays, esCompleta)
                Else
                    ' Hay más de una palabra a poner
                    For i As Integer = 0 To buscar.Length - 1
                        If posiciones(i) < 0 Then Continue For
                        texto = texto.Substring(0, posiciones(i)) & poner(i) & texto.Substring(posiciones(i) + buscar(i).Length)
                    Next
                    Return ReemplazaPalabras(texto.ToString, buscar, poner, tipoBusqueda, ignorarMays, esCompleta)
                End If
            End If

            ' Si se indica NOT, que la segunda palabara de buscar no esté
        ElseIf tipoBusqueda = TiposBusqueda.Not Then
            ' solo debe haber 1 en poner, si hay más se ignora la segunda
            For i As Integer = 0 To buscar.Length - 1
                If posiciones(i) < 0 Then Continue For
                texto = texto.Substring(0, posiciones(i)) & poner(0) & texto.Substring(posiciones(i) + buscar(i).Length)
            Next
            Return ReemplazaPalabras(texto.ToString, buscar, poner, tipoBusqueda, ignorarMays, esCompleta)

            ' Si solo se indica una palabra a buscar (SoloUno)
        Else
            For i As Integer = 0 To n - 1
                Dim sBusc As String = buscar(i)
                Dim pos As Integer = posiciones(i)
                ' Si se ha encontrado la palabra
                If pos > -1 Then
                    ' Si solo hay una palabra a poner
                    If poner.Length = 1 Then
                        texto = texto.Substring(0, pos) & poner(0) & texto.Substring(pos + sBusc.Length)
                    Else
                        texto = texto.Substring(0, pos) & poner(i) & texto.Substring(pos + sBusc.Length)
                    End If
                End If
            Next
            Return ReemplazaPalabras(texto, buscar, poner, tipoBusqueda, ignorarMays, esCompleta)
        End If

        Return texto
    End Function
End Class
