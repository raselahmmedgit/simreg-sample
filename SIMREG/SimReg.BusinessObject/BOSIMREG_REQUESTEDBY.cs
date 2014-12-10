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
    public class BOSIMREG_REQUESTEDBY
    {
        SQLHelper sqlHelper = null;
        DASIMREG_REQUESTEDBY daSIMREG_REQUESTEDBY = new DASIMREG_REQUESTEDBY();

        public void Save(BESIMREG_REQUESTEDBY entity)
        {
            try
            {
                sqlHelper = new SQLHelper(true);
                daSIMREG_REQUESTEDBY.Save(sqlHelper, entity);
                sqlHelper.CommitTran();
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public void Delete(BESIMREG_REQUESTEDBY entity)
        {
            try
            {
                int entityId = entity.REQUESTEDBYID;
                sqlHelper = new SQLHelper(true);
                daSIMREG_REQUESTEDBY.Delete(sqlHelper, entityId);
                sqlHelper.CommitTran();
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BESIMREG_REQUESTEDBYs GetSIMREG_REQUESTEDBYs()
        {
            try
            {
                BESIMREG_REQUESTEDBYs SIMREG_REQUESTEDBYs = null;
                sqlHelper = new SQLHelper();
                SIMREG_REQUESTEDBYs = daSIMREG_REQUESTEDBY.GetSIMREG_REQUESTEDBYs(sqlHelper);
                sqlHelper.CommitTran();
                return SIMREG_REQUESTEDBYs;
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BESIMREG_REQUESTEDBY GetSIMREG_REQUESTEDBY(int SIMREG_REQUESTEDBYId)
        {
            try
            {
                BESIMREG_REQUESTEDBY SIMREG_REQUESTEDBY = null;
                sqlHelper = new SQLHelper();
                SIMREG_REQUESTEDBY = daSIMREG_REQUESTEDBY.GetSIMREG_REQUESTEDBY(sqlHelper, SIMREG_REQUESTEDBYId);
                sqlHelper.CommitTran();
                return SIMREG_REQUESTEDBY;
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
