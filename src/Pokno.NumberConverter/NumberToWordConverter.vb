
Imports Microsoft.VisualBasic

Public Class NumberToWordConverter

    Public m_whole As String
    Public m_fraction As String

    Private Function units(ByVal num As String) As String
        Select Case num
            Case Is = "1"
                Return "ONE"
            Case Is = "2"
                Return "TWO"
            Case Is = "3"
                Return "THREE"
            Case Is = "4"
                Return "FOUR"
            Case Is = "5"
                Return "FIVE"
            Case Is = "6"
                Return "SIX"
            Case Is = "7"
                Return "SEVEN"
            Case Is = "8"
                Return "EIGHT"
            Case Is = "9"
                Return "NINE"
            Case Is = "0"
                Return ""
            Case Is = " "
                Return "******"
            Case Else
                Return "******"
        End Select
    End Function

    Private Function FigToWord(ByVal num1 As String) As String
        Dim AmtWord As Integer
        Dim i As Integer
        Dim num As String
        Dim AmtString As String
        Dim million As String
        Dim thousand As String
        Dim Hundred As String
        Dim Word As String = ""
        Dim billion As String

        'if string is empty, return an empty string
        If num1 = "" Then Return ""

        On Error GoTo ErrorHandler
        num = num1
        If Len(num) < 12 Then
            i = Len(num)
            Do
                num = "0" & num
                i = i + 1
            Loop Until i = 12
        End If
        billion = AnyHundredWord(Left(num, 3))
        million = AnyHundredWord(Mid(num, 4, 3))
        thousand = AnyHundredWord(Mid(num, 7, 3))
        Hundred = AnyHundredWord(Right(num, 3))
        If billion <> "" Then
            Word = billion & " billion "
        End If
        If million <> "" Then
            Word = Word & million & " million "
        End If
        If thousand <> "" Then
            If InStr(1, UCase(thousand), "HUNDRED") > 0 Then
                Word = Word & thousand & " THOUSAND "
            ElseIf InStr(1, UCase(thousand), "HUNDRED") = 0 And million = "" Then
                Word = Word & thousand & " THOUSAND "
            Else
                Word = Word & " AND " & thousand & " thousand "
            End If
        End If
        If Hundred <> "" Then
            If InStr(1, UCase(Hundred), "HUNDRED") > 0 Then
                Word = Word & Hundred
            ElseIf InStr(1, UCase(Hundred), "HUNDRED") = 0 And thousand = "" Then
                Word = Word & Hundred
            Else
                Word = Word & " AND " & Hundred
            End If
        End If

        'format words
        Word = LCase(Word)

        If Word <> "" Then
            Word = UCase(Left(Word, 1)) & Mid(Word, 2, Len(Word) - 1)
        End If

        FigToWord = Word '&"UNITS"
        Exit Function

ErrorHandler:
        MsgBox(Err.Description, vbInformation, "XtrackError")
        Exit Function
    End Function

    Private Function Hundreds(ByVal num As String) As String
        Select Case num
            Case Is = "1"
                Return "ONE HUNDRED"
            Case Is = "2"
                Return "TWO HUNDRED"
            Case Is = "3"
                Return "THREE HUNDRED"
            Case Is = "4"
                Return "FOUR HUNDRED"
            Case Is = "5"
                Return "FIVE HUNDRED"
            Case Is = "6"
                Return "SIX HUNDRED"
            Case Is = "7"
                Return "SEVEN HUNDRED"
            Case Is = "8"
                Return "EIGHT HUNDRED"
            Case Is = "9"
                Return "NINE HUNDRED"
            Case Is = "0"
                Return ""
        End Select
        Return ""
    End Function

    Private Function OverTen(ByVal num As String) As String
        Select Case num
            Case Is = "1"
                Return "ELEVEN"
            Case Is = "2"
                Return "TWELVE"
            Case Is = "3"
                Return "THIRTEEN"
            Case Is = "4"
                Return "FOURTEEN"
            Case Is = "5"
                Return "FIFTEEN"
            Case Is = "6"
                Return "SIXTEEN"
            Case Is = "7"
                Return "SEVENTEEN"
            Case Is = "8"
                Return "EIGHTEEN"
            Case Is = "9"
                Return "NINETEEN"
            Case Is = "0"
                Return "TEN"
        End Select
        Return ""
    End Function

    Private Function tens(ByVal num As String) As String
        Select Case num
            Case Is = "1"
                Return "TEN'"
            Case Is = "2"
                Return "TWENTY"
            Case Is = "3"
                Return "THIRTY"
            Case Is = "4"
                Return "FORTY"
            Case Is = "5"
                Return "FIFTY"
            Case Is = "6"
                Return "SIXTY"
            Case Is = "7"
                Return "SEVENTY"
            Case Is = "8"
                Return "EIGHTY"
            Case Is = "9"
                Return "NINETY"
            Case Is = "0"
                Return ""
        End Select
        Return ""
    End Function

    Private Function AnyHundredWord(ByVal num As String) As String
        Dim Numword As String
        Dim Leng As Integer
        Dim num1 As String
        Dim Wordunits As String
        Dim Wordtens As String
        'Dim Wordhundres As String
        Dim Wordhundreds As String
        Dim Word As String = ""

        'if number is 0 then retrun an empty string
        If Val(num) = 0 Then
            AnyHundredWord = ""
            Exit Function
        End If

        Numword = Trim(num)
        Leng = Len(Numword)
        num1 = Right(Numword, 3)
        Wordunits = ""
        Wordtens = ""
        Wordhundreds = ""
        If Leng = 1 Then
            num1 = "0" & num1
        ElseIf Leng = 2 Then
            num1 = "0" & num1
        End If
        If CType(Mid(num1, 2, 1), Double) >= 2 Or CType(Mid(num1, 2, 1), Double) = 0 Then
            Wordunits = units(Right(num1, 1))
            Wordtens = tens(Mid(num1, 2, 1))
            Wordhundreds = Hundreds(Left(num1, 1))
        Else
            Wordtens = OverTen(Right(num1, 1))
            Wordhundreds = Hundreds(Left(num1, 1))
        End If
        If Wordhundreds <> "" Then
            Word = Wordhundreds
        End If
        If Wordtens <> "" Then
            If Wordhundreds = "" Then
                Word = Word & Wordtens
            Else
                Word = Word & " AND " & Wordtens
            End If
        End If
        If Wordunits <> "" Then
            If Wordtens = "" And Wordhundreds <> "" Then
                Word = Word & " AND " & Wordunits
            Else
                Word = Word & " " & Wordunits
            End If
        End If
        AnyHundredWord = Word
        Exit Function

ErrorHandler:
        'MsgBox Error.description, vbInformation, "Xtrack Error"
        Exit Function
    End Function

    Public Function ConvertTo(ByVal num As String) As String
        Return "vbgv..."
    End Function

    'Public Function ConvertToWords(ByVal num As String) As String
    Public Function Convert(ByVal num As String) As String
        Dim i As Integer
        Dim WholeNum As String = ""
        Dim FractionNum As String
        Dim temp1 As String
        Dim temp2 As String
        Dim word As String
        'Dim strWords As String

        'Check for empty and zero strings
        If num = "" Then Return ""
        If Val(num) = 0 Then Return ""

        'Check for decimal
        i = InStr(num, ".")
        If i <> 0 Then
            temp1 = Right(num, Len(num) - i + 1) 'decimal
            temp1 = Decimal.Round(CType(temp1, Decimal), 2).ToString()
            temp1 = Right(CStr(temp1), 2)
            temp2 = Left(num, Len(num) - 3) 'whole num
        Else
            temp1 = ""
            temp2 = num 'whole num
        End If

        'convert whole number
        If Val(temp2) <> 0 Then 'when not emty or zero
            WholeNum = FigToWord(temp2)
        End If
        'convert decimal if present
        FractionNum = FigToWord(temp1)
        Dim iffValue1 As String
        Dim iffValue2 As String
        Dim iffValue3 As String

        If WholeNum <> "" Then
            iffValue1 = " naira only"
        Else
            iffValue1 = ""
        End If

        If (FractionNum <> "" And WholeNum <> "") Then

            iffValue2 = " and "
        Else
            iffValue2 = ""
        End If

        If (FractionNum <> "") Then
            iffValue3 = FractionNum & "%"
        Else
            iffValue3 = ""
        End If

        m_whole = WholeNum
        m_fraction = FractionNum


        If FractionNum <> "" Then
            word = WholeNum & IIf(WholeNum <> "", " naira,", "") & IIf(FractionNum <> "" And WholeNum <> "", " and ", "") & IIf(FractionNum <> "", FractionNum & " kobo only", "")
        Else
            word = WholeNum & IIf(WholeNum <> "", " naira only", "") '& IIf(FractionNum <> "" And WholeNum <> "", " and ", "") & IIf(FractionNum <> "", FractionNum & " kobo only", "")
        End If

        'Return WholeNum & IIf(WholeNum <> "", "@", "") & IIf(FractionNum <> "" And WholeNum <> "", " and ", "") & IIf(FractionNum <> "", FractionNum & "%", "")
        'Return WholeNum & iffValue1 & iffValue2 & iffValue3

        word = word.Replace("  ", " ").Trim()
        Dim firstChar As String = Mid(word, 1, 1)
        Dim otherChar As String = Mid(word, 2, word.Length - 1)

        'word = firstChar.ToUpper() & otherChar
        Return firstChar.ToUpper() & otherChar
    End Function

End Class

