Imports DevExpress.Xpf.Core
Imports System.Collections.Generic

Namespace GroupFootersWPF

    Public Partial Class MainWindow
        Inherits DXWindow

        Public Sub New()
            Me.InitializeComponent()
            Dim list As List(Of TestData) = New List(Of TestData)()
            For i As Integer = 0 To 200 - 1
                list.Add(New TestData() With {.Text = "Text0 Row" & i, .Number0 = i, .Number1 = 100 - i, .Number2 = i Mod 10, .Group = i Mod 10})
            Next

            DataContext = list
        End Sub
    End Class

    Public Class TestData

        Public Property Text As String

        Public Property Number0 As Integer

        Public Property Number1 As Integer

        Public Property Number2 As Integer

        Public Property Group As Integer
    End Class
End Namespace
