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
    public class BOSIMREG_REQUESTEDTYPE
    {
        SQLHelper sqlHelper = null;
        DASIMREG_REQUESTEDTYPE daSIMREG_REQUESTEDTYPE = new DASIMREG_REQUESTEDTYPE();

        public void Save(BESIMREG_REQUESTEDTYPE entity)
        {
            try
            {
                sqlHelper = new SQLHelper(true);
                daSIMREG_REQUESTEDTYPE.Save(sqlHelper, entity);
                sqlHelper.CommitTran();
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public void Delete(BESIMREG_REQUESTEDTYPE entity)
        {
            try
            {
                int entityId = entity.REQUESTEDTYPEID;
                sqlHelper = new SQLHelper(true);
                daSIMREG_REQUESTEDTYPE.Delete(sqlHelper, entityId);
                sqlHelper.CommitTran();
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BESIMREG_REQUESTEDTYPEs GetSIMREG_REQUESTEDTYPEs()
        {
            try
            {
                BESIMREG_REQUESTEDTYPEs SIMREG_REQUESTEDTYPEs = null;
                sqlHelper = new SQLHelper();
                SIMREG_REQUESTEDTYPEs = daSIMREG_REQUESTEDTYPE.GetSIMREG_REQUESTEDTYPEs(sqlHelper);
                sqlHelper.CommitTran();
                return SIMREG_REQUESTEDTYPEs;
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BESIMREG_REQUESTEDTYPE GetSIMREG_REQUESTEDTYPE(int SIMREG_REQUESTEDTYPEId)
        {
            try
            {
                BESIMREG_REQUESTEDTYPE SIMREG_REQUESTEDTYPE = null;
                sqlHelper = new SQLHelper();
                SIMREG_REQUESTEDTYPE = daSIMREG_REQUESTEDTYPE.GetSIMREG_REQUESTEDTYPE(sqlHelper, SIMREG_REQUESTEDTYPEId);
                sqlHelper.CommitTran();
                return SIMREG_REQUESTEDTYPE;
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
