Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraTreeList
Imports System.Data

Namespace E3597
    Friend Class VirtualMasterDetailTree
        Private _dataSource As DataTable
        Public Property DataSource() As DataTable
            Get
                Return _dataSource
            End Get
            Set(ByVal value As DataTable)
                If _dataSource Is value Then
                    Return
                End If
                _dataSource = value
                _masterTreeList.RefreshDataSource()
            End Set
        End Property
        Private _masterTreeList As treelist
        Private Property MasterTreeList() As treelist
            Get
                Return _masterTreeList
            End Get
            Set(ByVal value As treelist)
                If _masterTreeList Is value Then
                    Return
                End If
                Detach()
                Attach(value)
            End Set
        End Property
        Private RootObject As Object
        Public Sub New(ByVal masterTreeList As treelist, ByVal dt As DataTable)
            RootObject = New Object()
            Me.MasterTreeList = masterTreeList
            _dataSource = dt
        End Sub

        Private Sub Detach()
            If _masterTreeList Is Nothing Then
                Return
            End If
            _masterTreeList.DataSource = Nothing
            RemoveHandler _masterTreeList.VirtualTreeGetCellValue, AddressOf VirtualTreeGetCellValue
            RemoveHandler _masterTreeList.VirtualTreeGetChildNodes, AddressOf VirtualTreeGetChildNodes
            RemoveHandler _masterTreeList.VirtualTreeSetCellValue, AddressOf VirtualTreeSetCellValue

        End Sub
        Private Sub Attach(ByVal treeList As treelist)
            If treeList Is Nothing Then
                Return
            End If
            _masterTreeList = treeList
            _masterTreeList.DataSource = RootObject
            AddHandler _masterTreeList.VirtualTreeGetCellValue, AddressOf VirtualTreeGetCellValue
            AddHandler _masterTreeList.VirtualTreeGetChildNodes, AddressOf VirtualTreeGetChildNodes
            AddHandler _masterTreeList.VirtualTreeSetCellValue, AddressOf VirtualTreeSetCellValue
        End Sub

        Private Sub VirtualTreeGetChildNodes(ByVal sender As Object, ByVal e As VirtualTreeGetChildNodesInfo)
            If e.Node Is RootObject Then
                e.Children = _dataSource.Select()
            ElseIf TypeOf e.Node Is DataRow Then
                Dim row As DataRow = TryCast(e.Node, DataRow)
                If row.Table.ChildRelations.Count = 0 Then
                    Return
                End If


                e.Children = (TryCast(e.Node, DataRow)).GetChildRows(row.Table.ChildRelations(0))
            End If
        End Sub

        Private Sub VirtualTreeGetCellValue(ByVal sender As Object, ByVal e As VirtualTreeGetCellValueInfo)
            If (TryCast(e.Node, DataRow)).Table.Columns(e.Column.FieldName) IsNot Nothing Then
                Dim value As Object = (TryCast(e.Node, DataRow))(e.Column.FieldName)
                If value IsNot Nothing Then
                    e.CellData = value
                End If
            End If
        End Sub

        Private Sub VirtualTreeSetCellValue(ByVal sender As Object, ByVal e As VirtualTreeSetCellValueInfo)
            If (TryCast(e.Node, DataRow)).Table.Columns(e.Column.FieldName) IsNot Nothing Then
                TryCast(e.Node, DataRow)(e.Column.FieldName) = e.NewCellData
            End If
        End Sub

    End Class
End Namespace
