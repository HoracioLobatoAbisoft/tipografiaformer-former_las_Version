Module mdlBarCode

    Public Function FromEan13(ByVal CodiceLetto As String) As String

        Return CodiceLetto.Substring(0, 12)

    End Function

    Public Function EAN13(ByVal chaine As String) As String
        'Cette fonction est r�gie par la Licence G�n�rale Publique Amoindrie GNU (GNU LGPL)
        'This function is governed by the GNU Lesser General Public License (GNU LGPL)
        'V 1.1.1
        'Param�tres : une chaine de 12 chiffres
        'Parameters : a 12 digits length string
        'Retour : * une chaine qui, affich�e avec la police EAN13.TTF, donne le code barre
        '         * une chaine vide si param�tre fourni incorrect
        'Return : * a string which give the bar code when it is dispayed with EAN13.TTF font
        '         * an empty string if the supplied parameter is no good
        Dim i As Integer, checksum As Integer, first As Integer, CodeBarre As String = String.Empty, tableA As Boolean

        'V�rifier qu'il y a 12 caract�res
        'Check for 12 characters
        If chaine.Length = 12 Then
            'Et que ce sont bien des chiffres
            'And they are really digits
            For i = 1 To 12
                If Asc(Mid$(chaine, i, 1)) < 48 Or Asc(Mid$(chaine, i, 1)) > 57 Then
                    i = 0
                    Exit For
                End If
            Next
            If i = 13 Then
                'Calcul de la cl� de contr�le
                'Calculation of the checksum
                For i = 12 To 1 Step -2
                    checksum = checksum + Val(Mid$(chaine, i, 1))
                Next
                checksum = checksum * 3
                For i = 11 To 1 Step -2
                    checksum = checksum + Val(Mid$(chaine, i, 1))
                Next
                chaine = chaine & (10 - checksum Mod 10) Mod 10
                'Le premier chiffre est pris tel quel, le deuxi�me vient de la table A
                'The first digit is taken just as it is, the second one come from table A
                CodeBarre = Left$(chaine, 1) & Chr(65 + Val(Mid(chaine, 2, 1)))
                first = Val(Left$(chaine, 1))
                For i = 3 To 7
                    tableA = False
                    Select Case i
                        Case 3
                            Select Case first
                                Case 0 To 3
                                    tableA = True
                            End Select
                        Case 4
                            Select Case first
                                Case 0, 4, 7, 8
                                    tableA = True
                            End Select
                        Case 5
                            Select Case first
                                Case 0, 1, 4, 5, 9
                                    tableA = True
                            End Select
                        Case 6
                            Select Case first
                                Case 0, 2, 5, 6, 7
                                    tableA = True
                            End Select
                        Case 7
                            Select Case first
                                Case 0, 3, 6, 8, 9
                                    tableA = True
                            End Select
                    End Select
                    If tableA Then
                        CodeBarre = CodeBarre & Chr(65 + Val(Mid(chaine, i, 1)))
                    Else
                        CodeBarre = CodeBarre & Chr(75 + Val(Mid(chaine, i, 1)))
                    End If
                Next
                CodeBarre = CodeBarre & "*"   'Ajout s�parateur central / Add middle separator
                For i = 8 To 13
                    CodeBarre = CodeBarre & Chr(97 + Val(Mid(chaine, i, 1)))
                Next
                CodeBarre = CodeBarre & "+"   'Ajout de la marque de fin / Add end mark

            End If
        End If
        Return CodeBarre
    End Function


End Module
