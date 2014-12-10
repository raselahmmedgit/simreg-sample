using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLFactory;
using RnD.BLTemp.BusinessEntity;
using System.Data;

namespace RnD.BLTemp.DataAccess
{
    public class DACommon
    {
        public void CloseDBLink(SQLHelper sqlHelper, string dbLinkName)
        {
            try
            {
                if (sqlHelper != null) sqlHelper.Rollback();
                string sql = sqlHelper.MakeSQL(@"alter session close database link $s", dbLinkName);
                sqlHelper.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
