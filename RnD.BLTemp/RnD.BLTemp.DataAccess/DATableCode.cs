using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLFactory;
using System.Data;
using RnD.BLTemp.BusinessEntity;

namespace RnD.BLTemp.DataAccess
{
    public class DATableCode
    {
        public void Update(SQLHelper sqlHelper, int maxId, string tableName)
        {
            string sql = string.Empty;
            try
            {
                sql = sqlHelper.MakeSQL("update tblTableCode set maxid = $n WHERE upper(TableName) = $s", maxId, tableName.ToUpper());

                sqlHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetTableCode(SQLHelper sqlHelper, string tableName)
        {
            string code = string.Empty;
            string sql = string.Empty;

            try
            {
                BETableCode beTableCode = new BETableCode();
                sql = sqlHelper.MakeSQL("SELECT maxid, CodeLength FROM tblTableCode "
                    + "WHERE upper(TableName) = $s", tableName.ToUpper());
                IDataReader reader = sqlHelper.ExecuteQuery(sql);

                AddToCollectionForGettingTableCode(beTableCode, reader);

                code = (beTableCode.MaxID + 1).ToString().PadLeft(beTableCode.CodeLength, '0');

                return code;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string UpdateTableCodeAtSave(SQLHelper sqlHelper, string tableName)
        {
            string code = string.Empty;
            string sql = string.Empty;

            try
            {

                object[] objParam = { tableName, code };

                sqlHelper.ExecuteProcedureReturnValue("Proc_TableCode", new string[] { "pTableName", "poCode|S|O" }, objParam);

                object obj = objParam[objParam.Length - 1];

                code = obj.ToString();

                return code;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private BETableCode AddToCollectionForGettingTableCode(BETableCode objs, IDataReader reader)
        {
            while (reader.Read())
            {
                NULLHandler nullHandler = new NULLHandler(reader);

                objs.MaxID = nullHandler.GetInt("maxid");
                objs.CodeLength = nullHandler.GetInt("CodeLength");
            }

            return objs;
        }
    }
}
