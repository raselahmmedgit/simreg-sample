using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLFactory;
using RnD.BLTemp.DataAccess;
using System.Data;
using RnD.BLTemp.BusinessEntity;

namespace RnD.BLTemp.BusinessObject
{
    public class BOTableCode
    {
        SQLHelper sqlHelper = null;

        public string GetTableCode(string tableName)
        {
            try
            {
                string code = string.Empty;
                DATableCode datTableCode = new DATableCode();

                sqlHelper = new SQLHelper(true);
                code = datTableCode.GetTableCode(sqlHelper, tableName);
                sqlHelper.CommitTran();

                return code;
            }
            catch (Exception ex)
            {
                RnD.BLTemp.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
            finally
            {
                sqlHelper = null;
            }
        }
    }
}
