Imports DevExpress.Xpf.Data
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Grid.Native
Imports System
Imports System.Collections.Generic

Namespace GroupFootersWPF

    Public Class MyTableView
        Inherits TableView

        Private _GroupFooterCollection As List(Of GroupFootersWPF.GroupFooter)

        Public Property GroupFooterCollection As List(Of GroupFooter)
            Get
                Return _GroupFooterCollection
            End Get

            Private Set(ByVal value As List(Of GroupFooter))
                _GroupFooterCollection = value
            End Set
        End Property

        Public Sub New()
            GroupFooterCollection = New List(Of GroupFooter)()
        End Sub

        Public Sub AddToCacheGroupFooter(ByVal groupFooter As GroupFooter)
            If Not GroupFooterCollection.Contains(groupFooter) Then GroupFooterCollection.Add(groupFooter)
        End Sub

        Public Function CreateGroupRowData(ByVal groupRowHandle As RowHandle) As MyGroupRowData
            Dim rowData As MyGroupRowData = New MyGroupRowData(visualDataTreeBuilder)
            UpdateGroupRowData(rowData, groupRowHandle)
            UpdateFixedNoneContentWidth(rowData)
            Return rowData
        End Function

        Public Sub UpdateGroupRowData(ByVal rowData As MyGroupRowData, ByVal rowHandle As RowHandle)
            rowData.UpdateRowHandle(rowHandle)
            UpdateCellData(rowData)
            rowData.UpdateMyGroupSummaryData()
        End Sub

        Protected Overrides Sub OnUpdateRowsCore()
            MyBase.OnUpdateRowsCore()
            ForeachMyGroupRowData(Sub(e) e.UpdateRowData(), Sub(f) f.RefreshContent())
        End Sub

        Protected Overrides Sub UpdateGroupSummary()
            MyBase.UpdateGroupSummary()
            ForeachMyGroupRowData(Sub(e) e.UpdateMyGroupSummaryData())
        End Sub

        Protected Overrides Sub UpdateCellData()
            MyBase.UpdateCellData()
            ForeachMyGroupRowData(Sub(e) UpdateCellData(e))
        End Sub

        Protected Overrides Sub UpdateRowData(ByVal updateMethod As UpdateRowDataDelegate, ByVal Optional updateInvisibleRows As Boolean = True, ByVal Optional updateFocusedRow As Boolean = True)
            MyBase.UpdateRowData(updateMethod, updateInvisibleRows, updateFocusedRow)
            ForeachMyGroupRowData(Sub(e) updateMethod(e))
        End Sub

        Private Sub ForeachMyGroupRowData(ByVal groupDataAction As Action(Of MyGroupRowData), ByVal Optional groupFooterAction As Action(Of GroupFooter) = Nothing)
            For Each groupFooter As GroupFooter In GroupFooterCollection
                If groupFooterAction IsNot Nothing Then groupFooterAction(groupFooter)
                If groupFooter.GroupRowData IsNot Nothing Then groupDataAction(groupFooter.GroupRowData)
            Next
        End Sub
    End Class

    Public Class MyGroupRowData
        Inherits GroupRowData

        Public Sub New(ByVal treeBuilder As DataTreeBuilder)
            MyBase.New(treeBuilder)
        End Sub

        Public Sub UpdateRowData()
            UpdateData()
        End Sub

        Public Sub UpdateRowHandle(ByVal rowHandle As RowHandle)
            SetRowHandle(rowHandle)
        End Sub

        Public Sub UpdateMyGroupSummaryData()
            UpdateGroupSummaryData()
        End Sub
    End Class
End Namespace
