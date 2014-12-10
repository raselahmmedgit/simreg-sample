using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimReg.BusinessEntity;
using SimReg.DataAccess;
using SQLFactory;

namespace SimReg.BusinessObject
{
    public class BOSIMREG_DELIVEREDBY
    {
        SQLHelper sqlHelper = null;
        DASIMREG_DELIVEREDBY daSIMREG_DELIVEREDBY = new DASIMREG_DELIVEREDBY();

        public void Save(BESIMREG_DELIVEREDBY entity)
        {
            try
            {
                sqlHelper = new SQLHelper(true);
                daSIMREG_DELIVEREDBY.Save(sqlHelper, entity);
                sqlHelper.CommitTran();
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public void Delete(BESIMREG_DELIVEREDBY entity)
        {
            try
            {
                int entityId = entity.DELIVEREDBYID;
                sqlHelper = new SQLHelper(true);
                daSIMREG_DELIVEREDBY.Delete(sqlHelper, entityId);
                sqlHelper.CommitTran();
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BESIMREG_DELIVEREDBYs GetSIMREG_DELIVEREDBYs()
        {
            try
            {
                BESIMREG_DELIVEREDBYs SIMREG_DELIVEREDBYs = null;
                sqlHelper = new SQLHelper();
                SIMREG_DELIVEREDBYs = daSIMREG_DELIVEREDBY.GetSIMREG_DELIVEREDBYs(sqlHelper);
                sqlHelper.CommitTran();
                return SIMREG_DELIVEREDBYs;
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BESIMREG_DELIVEREDBY GetSIMREG_DELIVEREDBY(int SIMREG_DELIVEREDBYId)
        {
            try
            {
                BESIMREG_DELIVEREDBY SIMREG_DELIVEREDBY = null;
                sqlHelper = new SQLHelper();
                SIMREG_DELIVEREDBY = daSIMREG_DELIVEREDBY.GetSIMREG_DELIVEREDBY(sqlHelper, SIMREG_DELIVEREDBYId);
                sqlHelper.CommitTran();
                return SIMREG_DELIVEREDBY;
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BESIMREG_DELIVEREDBY GetSIMREG_DELIVEREDBYbyUSERNAME(string userName)
        {
            try
            {
                BESIMREG_DELIVEREDBY SIMREG_DELIVEREDBY = null;
                sqlHelper = new SQLHelper();
                SIMREG_DELIVEREDBY = daSIMREG_DELIVEREDBY.GetSIMREG_DELIVEREDBYbyUSERNAME(sqlHelper, userName);
                sqlHelper.CommitTran();
                return SIMREG_DELIVEREDBY;
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }
    }
}
