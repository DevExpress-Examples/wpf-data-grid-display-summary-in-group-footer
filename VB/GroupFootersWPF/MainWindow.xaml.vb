Imports DevExpress.Xpf.Core
Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace GroupFootersWPF
    Partial Public Class MainWindow
        Inherits DXWindow

        Public Sub New()
            InitializeComponent()
            Dim list As New List(Of TestData)()
            For i As Integer = 0 To 199
                list.Add(New TestData() With {.Text = "Text0 Row" & i, .Number0 = i, .Number1 = 100 - i, .Number2 = i Mod 10, .Group = i Mod 10})
            Next i
            DataContext = list
        End Sub
    End Class

    Public Class TestData
        Public Property Text() As String
        Public Property Number0() As Integer
        Public Property Number1() As Integer
        Public Property Number2() As Integer
        Public Property Group() As Integer
    End Class
End Namespace