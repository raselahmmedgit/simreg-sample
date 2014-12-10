using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RnD.BLTemp.BusinessEntity;
using SQLFactory;
using System.Data;

namespace RnD.BLTemp.DataAccess
{
    public class DACommonConfig
    {
        public BECommonConfigs GetCommonConfigs(SQLHelper sqlHelper, string GroupName)
        {
            string sql = string.Empty;
            BECommonConfigs CommonConfigs = new BECommonConfigs();
            try
            {
                sql = sqlHelper.MakeSQL("SELECT * FROM TblCommonConfig");

                if (GroupName != "")
                {
                    sql = sqlHelper.MakeSQL(sql + " WHERE GroupName=$s", GroupName);
                }

                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToCommonConfigCollection(CommonConfigs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return CommonConfigs;
        }

        public BECommonConfig GetCommonConfig(SQLHelper sqlHelper, string GroupName, int id)
        {
            string sql = string.Empty;
            BECommonConfigs CommonConfigs = new BECommonConfigs();
            try
            {
                sql = sqlHelper.MakeSQL("SELECT * FROM TblCommonConfig");

                if (GroupName != "")
                {
                    sql = sqlHelper.MakeSQL(sql + " WHERE GroupName=$s", GroupName);
                }

                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToCommonConfigCollection(CommonConfigs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (CommonConfigs.Count > 0)
                return CommonConfigs[0];
            else
                return new BECommonConfig();
        }

        private BECommonConfigs AddToCommonConfigCollection(BECommonConfigs CommonConfigs, IDataReader reader)
        {
            NULLHandler nullHandler = new NULLHandler(reader);
            while (reader.Read())
            {
                CommonConfigs.Add(PreaperCommonConfigObject(nullHandler));
            }
            return CommonConfigs;
        }

        private BECommonConfig PreaperCommonConfigObject(NULLHandler nullHandler)
        {
            BECommonConfig CommonConfig = new BECommonConfig();
            CommonConfig.CommonConfigId = nullHandler.GetInt("CommonConfigId");
            CommonConfig.CommonConfigName = nullHandler.GetString("CommonConfigName");
            CommonConfig.GroupName = nullHandler.GetString("GroupName");
            return CommonConfig;
        }
    }
}
