using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraTreeList;
using System.Data;

namespace treelist
{
    class VirtualMasterDetailTree
    {
        DataTable _dataSource;
        public DataTable DataSource
        {
            get { return _dataSource; }
            set
            {
                if (_dataSource == value)
                    return;
                _dataSource = value;
                _masterTreeList.RefreshDataSource();
            }
        }
        TreeList _masterTreeList;
        TreeList MasterTreeList
        {
            get { return _masterTreeList; }
            set
            {
                if (_masterTreeList == value)
                    return;
                Detach();
                Attach(value);
            }
        }
        object RootObject;
        public VirtualMasterDetailTree(TreeList masterTreeList, DataTable dt)
        {
            RootObject = new object();
            MasterTreeList = masterTreeList;
            _dataSource = dt;
        }

        void Detach()
        {
            if (_masterTreeList == null)
                return;
            _masterTreeList.DataSource = null;
            _masterTreeList.VirtualTreeGetCellValue -= new VirtualTreeGetCellValueEventHandler(VirtualTreeGetCellValue);
            _masterTreeList.VirtualTreeGetChildNodes -= new VirtualTreeGetChildNodesEventHandler(VirtualTreeGetChildNodes);
            _masterTreeList.VirtualTreeSetCellValue -= new VirtualTreeSetCellValueEventHandler(VirtualTreeSetCellValue);

        }
        void Attach(TreeList treeList)
        {
            if (treeList == null)
                return;
            _masterTreeList = treeList;
            _masterTreeList.DataSource = RootObject;
            _masterTreeList.VirtualTreeGetCellValue +=new VirtualTreeGetCellValueEventHandler(VirtualTreeGetCellValue);
            _masterTreeList.VirtualTreeGetChildNodes += new VirtualTreeGetChildNodesEventHandler(VirtualTreeGetChildNodes);
            _masterTreeList.VirtualTreeSetCellValue+=new VirtualTreeSetCellValueEventHandler(VirtualTreeSetCellValue);
        }

        private void VirtualTreeGetChildNodes(object sender, VirtualTreeGetChildNodesInfo e)
        {
            if (e.Node == RootObject)
                e.Children = _dataSource.Select();
            else if (e.Node is DataRow)
            {
                DataRow row = e.Node as DataRow;
                if (row.Table.ChildRelations.Count == 0) return;


                e.Children = (e.Node as DataRow).GetChildRows(row.Table.ChildRelations[0]);
            }
        }

        private void VirtualTreeGetCellValue(object sender, VirtualTreeGetCellValueInfo e)
        {
            if ((e.Node as DataRow).Table.Columns[e.Column.FieldName] != null)
            {
                object value = (e.Node as DataRow)[e.Column.FieldName];
                if (value != null)
                    e.CellData = value;
            }
        }

        private void VirtualTreeSetCellValue(object sender, VirtualTreeSetCellValueInfo e)
        {
            if ((e.Node as DataRow).Table.Columns[e.Column.FieldName] != null)
            {
                (e.Node as DataRow)[e.Column.FieldName] = e.NewCellData;
            }
        }

    }
}
