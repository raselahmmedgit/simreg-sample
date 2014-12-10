using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLFactory;

namespace SimReg.DataAccess
{
    public class DATableCode
    {
        public int GetTableId(SQLHelper sqlHelper, string idName, string tableName)
        {
            int tableId = 0;
            string strSQL = string.Empty;

            try
            {
                strSQL = sqlHelper.MakeSQL("SELECT MAX($s) FROM " + tableName.ToUpper(), idName);
                IDataReader reader = sqlHelper.ExecuteQuery(strSQL);

                if (reader.Read())
                {
                    tableId = Convert.ToInt32(reader[0]);
                }

                return tableId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
