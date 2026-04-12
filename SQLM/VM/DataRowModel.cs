using System.Data;

namespace SQLM.VM
{
    public abstract class DataRowModel
    {
        protected DataRow Row { get; private set; }


        protected DataRowModel(DataRow row)
        {
            Row = row ?? throw new ArgumentNullException(nameof(row));
            LoadFromRow(row);
        }


        protected abstract void LoadFromRow(DataRow row);


        protected T Get<T>(string columnName)
        {
            if (!Row.Table.Columns.Contains(columnName) || Row[columnName] == DBNull.Value)
                return default;
            return (T)Convert.ChangeType(Row[columnName], typeof(T));
        }
    }
}