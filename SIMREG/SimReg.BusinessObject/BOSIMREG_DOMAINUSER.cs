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
    public class BOSIMREG_DOMAINUSER
    {
        SQLHelper sqlHelper = null;
        DASIMREG_DOMAINUSER daSIMREG_DOMAINUSER = new DASIMREG_DOMAINUSER();

        public void Save(BESIMREG_DOMAINUSER entity)
        {
            try
            {
                sqlHelper = new SQLHelper(true);
                daSIMREG_DOMAINUSER.Save(sqlHelper, entity);
                sqlHelper.CommitTran();
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BESIMREG_DOMAINUSERs GetSIMREG_DOMAINUSERs()
        {
            try
            {
                BESIMREG_DOMAINUSERs SIMREG_DOMAINUSERs = null;
                sqlHelper = new SQLHelper();
                SIMREG_DOMAINUSERs = daSIMREG_DOMAINUSER.GetSIMREG_DOMAINUSERs(sqlHelper);
                sqlHelper.CommitTran();
                return SIMREG_DOMAINUSERs;
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BESIMREG_DOMAINUSER GetSIMREG_DOMAINUSER(int UserId)
        {
            try
            {
                BESIMREG_DOMAINUSER SIMREG_DOMAINUSER = null;
                sqlHelper = new SQLHelper();
                SIMREG_DOMAINUSER = daSIMREG_DOMAINUSER.GetSIMREG_DOMAINUSER(sqlHelper, UserId);
                sqlHelper.CommitTran();
                return SIMREG_DOMAINUSER;
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BESIMREG_DOMAINUSER GetSIMREG_DOMAINUSER(string UserName)
        {
            try
            {
                BESIMREG_DOMAINUSER SIMREG_DOMAINUSER = null;
                sqlHelper = new SQLHelper();
                SIMREG_DOMAINUSER = daSIMREG_DOMAINUSER.GetSIMREG_DOMAINUSER(sqlHelper, UserName);
                sqlHelper.CommitTran();
                return SIMREG_DOMAINUSER;
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BESIMREG_DELIVEREDBY GetSIMREG_DOMAINUSERbyDELIVER(string UserName)
        {
            try
            {
                BESIMREG_DELIVEREDBY SIMREG_DELIVEREDBY = null;
                sqlHelper = new SQLHelper();
                SIMREG_DELIVEREDBY = daSIMREG_DOMAINUSER.GetSIMREG_DOMAINUSERbyDELIVER(sqlHelper, UserName);
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
