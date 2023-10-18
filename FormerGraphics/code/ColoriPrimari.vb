Imports System.Drawing

Public Class ColoriPrimari

    Private Shared lColorPrimari As List(Of Color) = Nothing
    Private Shared lColorPrimariEx As List(Of ColoreEx) = Nothing

    Shared Sub New()

        lColorPrimari = New List(Of Color)
        lColorPrimariEx = New List(Of ColoreEx)

        CaricaColori()

    End Sub

    Private Shared Sub CaricaColori()

        Dim singC As Color = Color.FromArgb(255, 0, 0)
        lColorPrimari.Add(singC)
        lColorPrimariEx.Add(New ColoreEx(singC, "Rosso"))

        'singC = Color.FromArgb(255, 0, 0, 0)
        'lColorPrimari.Add(singC)
        'lColorPrimariEx.Add(New ColoreEx(singC, "Trasparente"))

        singC = Color.FromArgb(255, 255, 255)
        lColorPrimari.Add(singC)
        lColorPrimariEx.Add(New ColoreEx(singC, "Bianco"))

        singC = Color.FromArgb(0, 0, 0)
        lColorPrimari.Add(singC)
        lColorPrimariEx.Add(New ColoreEx(singC, "Nero"))

        singC = Color.FromArgb(0, 255, 0)
        lColorPrimari.Add(singC)
        lColorPrimariEx.Add(New ColoreEx(singC, "Verde"))

        singC = Color.FromArgb(0, 0, 255)
        lColorPrimari.Add(singC)
        lColorPrimariEx.Add(New ColoreEx(singC, "Blu"))

        'SECONDARI
        singC = Color.FromArgb(255, 255, 0)
        lColorPrimari.Add(singC)
        lColorPrimariEx.Add(New ColoreEx(singC, "Giallo"))

        singC = Color.FromArgb(255, 0, 255)
        lColorPrimari.Add(singC)
        lColorPrimariEx.Add(New ColoreEx(singC, "Magenta"))

        singC = Color.FromArgb(0, 255, 255)
        lColorPrimari.Add(singC)
        lColorPrimariEx.Add(New ColoreEx(singC, "Ciano"))

        'TERZIARI
        singC = Color.FromArgb(255, 130, 0)
        lColorPrimari.Add(singC)
        lColorPrimariEx.Add(New ColoreEx(singC, "Arancio"))

        singC = Color.FromArgb(255, 0, 130)
        lColorPrimari.Add(singC)
        lColorPrimariEx.Add(New ColoreEx(singC, "Rosa"))

        singC = Color.FromArgb(130, 0, 255)
        lColorPrimari.Add(singC)
        lColorPrimariEx.Add(New ColoreEx(singC, "Viola"))

        singC = Color.FromArgb(0, 130, 255)
        lColorPrimari.Add(singC)
        lColorPrimariEx.Add(New ColoreEx(singC, "Azzurro"))

        singC = Color.FromArgb(0, 128, 0)
        lColorPrimari.Add(singC)
        lColorPrimariEx.Add(New ColoreEx(singC, "Verde"))

        singC = Color.FromArgb(0, 255, 130)
        lColorPrimari.Add(singC)
        lColorPrimariEx.Add(New ColoreEx(singC, "Verde Acqua"))

        singC = Color.FromArgb(130, 255, 0)
        lColorPrimari.Add(singC)
        lColorPrimariEx.Add(New ColoreEx(singC, "Verde Chiaro"))

        singC = Color.FromArgb(153, 153, 153)
        lColorPrimari.Add(singC)
        lColorPrimariEx.Add(New ColoreEx(singC, "Grigio"))

        'TERZIARI
        singC = Color.FromArgb(128, 0, 128)
        lColorPrimari.Add(singC)
        lColorPrimariEx.Add(New ColoreEx(singC, "Violetto"))

        'singC = Color.FromArgb(150, 75, 0) 'marrone
        'lColorPrimari.Add(singC)
        'lColorPrimariEx.Add(New ColoreEx(singC, "Marrone"))

    End Sub

    'Private Shared Sub CaricaColori()

    '    Dim singC As Color = Color.FromArgb(255, 0, 0) 'rosso
    '    lColorPrimari.Add(singC)
    '    lColorPrimariEx.Add(New ColoreEx(singC, "Rosso"))

    '    singC = Color.FromArgb(0, 0, 0) 'nero
    '    lColorPrimari.Add(singC)
    '    lColorPrimariEx.Add(New ColoreEx(singC, "Nero"))

    '    singC = Color.FromArgb(255, 255, 255) ' bianco
    '    lColorPrimari.Add(singC)
    '    lColorPrimariEx.Add(New ColoreEx(singC, "Bianco"))

    '    singC = Color.FromArgb(128, 0, 0) 'dark red
    '    lColorPrimari.Add(singC)
    '    lColorPrimariEx.Add(New ColoreEx(singC, "Rosso scuro"))

    '    singC = Color.FromArgb(255, 0, 255)
    '    lColorPrimari.Add(singC)
    '    lColorPrimariEx.Add(New ColoreEx(singC, "Rosa"))

    '    singC = Color.FromArgb(0, 128, 128)
    '    lColorPrimari.Add(singC)
    '    lColorPrimariEx.Add(New ColoreEx(singC, "Teal"))

    '    singC = Color.FromArgb(0, 128, 0)
    '    lColorPrimari.Add(singC)
    '    lColorPrimariEx.Add(New ColoreEx(singC, "Verde"))

    '    'SECONDARI
    '    singC = Color.FromArgb(0, 255, 0)
    '    lColorPrimari.Add(singC)
    '    lColorPrimariEx.Add(New ColoreEx(singC, "Verde chiaro"))

    '    singC = Color.FromArgb(0, 255, 255) 'turchese
    '    lColorPrimari.Add(singC)
    '    lColorPrimariEx.Add(New ColoreEx(singC, "Turchese"))

    '    singC = Color.FromArgb(0, 0, 128) 'blu scuro
    '    lColorPrimari.Add(singC)
    '    lColorPrimariEx.Add(New ColoreEx(singC, "Blu scuro"))

    '    'TERZIARI
    '    singC = Color.FromArgb(128, 0, 128) 'arancio
    '    lColorPrimari.Add(singC)
    '    lColorPrimariEx.Add(New ColoreEx(singC, "Violetto"))


    '    singC = Color.FromArgb(0, 0, 255) 'viola
    '    lColorPrimari.Add(singC)
    '    lColorPrimariEx.Add(New ColoreEx(singC, "Blu"))

    '    singC = Color.FromArgb(192, 192, 192) 'azzurro
    '    lColorPrimari.Add(singC)
    '    lColorPrimariEx.Add(New ColoreEx(singC, "Grigio 25%"))

    '    singC = Color.FromArgb(128, 128, 128) 'verde acqua
    '    lColorPrimari.Add(singC)
    '    lColorPrimariEx.Add(New ColoreEx(singC, "Grigio 50%"))

    '    singC = Color.FromArgb(128, 128, 0) 'verde chiaro
    '    lColorPrimari.Add(singC)
    '    lColorPrimariEx.Add(New ColoreEx(singC, "Giallo scuro"))

    '    singC = Color.FromArgb(255, 255, 0) 'grigio
    '    lColorPrimari.Add(singC)
    '    lColorPrimariEx.Add(New ColoreEx(singC, "Giallo"))

    '    'singC = Color.FromArgb(150, 75, 0) 'marrone
    '    'lColorPrimari.Add(singC)
    '    'lColorPrimariEx.Add(New ColoreEx(singC, "Marrone"))

    'End Sub

    Public Shared ReadOnly Property ListaColori As List(Of Color)
        Get
            Return lColorPrimari
        End Get
    End Property

    Public Shared ReadOnly Property ListaColoriEx As List(Of ColoreEx)
        Get
            Return lColorPrimariEx

        End Get
    End Property

End Class