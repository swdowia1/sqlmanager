using SQLM.Klasy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLM.ModalWindow
{
    public partial class DefTable : Form
    {
        TableInfo def;
        public DefTable(TableInfo _def)
        {
            InitializeComponent();
            def = _def;
            dgKolumny.SetStyle();
            string query = @" SELECT TABLE_SCHEMA,TABLE_NAME,COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE  TABLE_NAME ='" + def.nazwa + "' and TABLE_SCHEMA='" + def.schemat + "' ORDER BY ORDINAL_POSITION";
            DataTable dtKolumny = classData.FillData(query, def.POL,"lista kolumn");
            dgKolumny.DataSource = dtKolumny;


            dgProcedury.SetStyle();
            query = @" SELECT 
    s.name + '.' + o.name AS ObjectName,   -- np. dbo.TruncateMessagesQueue
    o.type_desc AS ObjectType,
    m.definition
FROM sys.sql_modules m
JOIN sys.objects o ON m.object_id = o.object_id
JOIN sys.schemas s ON o.schema_id = s.schema_id
              WHERE m.definition LIKE '%" + def.schemat+"%" + def.nazwa + "%'";
            DataTable dtproce = classData.FillData(query, def.POL,"lista procedur dla tabeli");
            dgProcedury.DataSource = dtproce;


            dgPowiazania.SetStyle();
            query = @"SELECT 
    fk.name AS ForeignKey,
    s1.name + '.' + tp.name AS ParentTable,
    c1.name AS ParentColumn,
    s2.name + '.' + ref.name AS ReferencedTable,
    c2.name AS ReferencedColumn
FROM sys.foreign_keys fk
JOIN sys.foreign_key_columns fkc 
    ON fkc.constraint_object_id = fk.object_id
JOIN sys.tables tp 
    ON fkc.parent_object_id = tp.object_id
JOIN sys.schemas s1 
    ON tp.schema_id = s1.schema_id
JOIN sys.columns c1 
    ON fkc.parent_object_id = c1.object_id AND fkc.parent_column_id = c1.column_id
JOIN sys.tables ref 
    ON fkc.referenced_object_id = ref.object_id
JOIN sys.schemas s2 
    ON ref.schema_id = s2.schema_id
JOIN sys.columns c2 
    ON fkc.referenced_object_id = c2.object_id AND fkc.referenced_column_id = c2.column_id
WHERE s1.name ='"+def.schemat+ "' AND tp.name = '"+def.nazwa+"' ORDER BY fk.name";

            DataTable dtPow = classData.FillData(query, def.POL,"powiazania");
            dgPowiazania.DataSource = dtPow;


            this.Text=def.ToString();
        }
    }
}
