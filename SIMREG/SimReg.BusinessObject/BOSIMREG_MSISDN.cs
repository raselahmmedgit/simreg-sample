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
    public class BOSIMREG_MSISDN
    {
        SQLHelper sqlHelper = null;
        DASIMREG_MSISDN daSIMREG_MSISDN = new DASIMREG_MSISDN();

        public void Save(BESIMREG_MSISDN entity)
        {
            try
            {
                sqlHelper = new SQLHelper(true);
                daSIMREG_MSISDN.Save(sqlHelper, entity);
                sqlHelper.CommitTran();
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public void Delete(BESIMREG_MSISDN entity)
        {
            try
            {
                int entityId = entity.MSISDNID;
                sqlHelper = new SQLHelper(true);
                daSIMREG_MSISDN.Delete(sqlHelper, entityId);
                sqlHelper.CommitTran();
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BESIMREG_MSISDNs GetSIMREG_MSISDNs()
        {
            try
            {
                BESIMREG_MSISDNs SIMREG_MSISDNs = null;
                sqlHelper = new SQLHelper();
                SIMREG_MSISDNs = daSIMREG_MSISDN.GetSIMREG_MSISDNs(sqlHelper);
                sqlHelper.CommitTran();
                return SIMREG_MSISDNs;
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BESIMREG_MSISDN GetSIMREG_MSISDN(int SIMREG_MSISDNId)
        {
            try
            {
                BESIMREG_MSISDN SIMREG_MSISDN = null;
                sqlHelper = new SQLHelper();
                SIMREG_MSISDN = daSIMREG_MSISDN.GetSIMREG_MSISDN(sqlHelper, SIMREG_MSISDNId);
                sqlHelper.CommitTran();
                return SIMREG_MSISDN;
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
