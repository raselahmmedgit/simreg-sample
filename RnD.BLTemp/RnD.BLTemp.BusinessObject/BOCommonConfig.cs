using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RnD.BLTemp.BusinessEntity;
using SQLFactory;
using RnD.BLTemp.DataAccess;

namespace RnD.BLTemp.BusinessObject
{
    public class BOCommonConfig
    {
        SQLHelper sqlHelper = null;
        DACommonConfig daCommonConfig = new DACommonConfig();

        public BECommonConfigs GetCommonConfigs(string GroupName)
        {
            try
            {
                BECommonConfigs commonConfigs = null;
                sqlHelper = new SQLHelper();
                commonConfigs = daCommonConfig.GetCommonConfigs(sqlHelper, GroupName);
                sqlHelper.CommitTran();
                return commonConfigs;
            }
            catch (Exception ex)
            {
                RnD.BLTemp.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BECommonConfig GetCommonConfigs(string GroupName, int id)
        {
            try
            {
                BECommonConfig commonConfigs = null;
                sqlHelper = new SQLHelper();
                commonConfigs = daCommonConfig.GetCommonConfig(sqlHelper, GroupName, id);
                sqlHelper.CommitTran();
                return commonConfigs;
            }
            catch (Exception ex)
            {
                RnD.BLTemp.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }
    }
}
