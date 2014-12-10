using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimReg.BusinessEntity;
using SimReg.DataAccess;
using SQLFactory;
using System.Data;

namespace SimReg.BusinessObject
{
    public class BOSIMREG_NEWFORM
    {
        SQLHelper sqlHelper = null;
        DASIMREG_NEWFORM daSIMREG_NEWFORM = new DASIMREG_NEWFORM();

        public void Save(BESIMREG_NEWFORM entity)
        {
            try
            {
                sqlHelper = new SQLHelper(true);
                daSIMREG_NEWFORM.Save(sqlHelper, entity);
                sqlHelper.CommitTran();
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public int TotalDataCount()
        {
            int totalRow = 0;

            try
            {
                sqlHelper = new SQLHelper();
                totalRow = daSIMREG_NEWFORM.TotalDataCount(sqlHelper);
                sqlHelper.CommitTran();
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
            }
            finally
            {
                sqlHelper = null;
            }

            return totalRow;
        }

        public void Delete(BESIMREG_NEWFORM entity)
        {
            try
            {
                int entityId = entity.ID;
                sqlHelper = new SQLHelper(true);
                daSIMREG_NEWFORM.Delete(sqlHelper, entityId);
                sqlHelper.CommitTran();
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BESIMREG_NEWFORMs GetSIMREG_NEWFORMs()
        {
            try
            {
                BESIMREG_NEWFORMs SIMREG_NEWFORMs = null;
                sqlHelper = new SQLHelper();
                SIMREG_NEWFORMs = daSIMREG_NEWFORM.GetSIMREG_NEWFORMs(sqlHelper);
                sqlHelper.CommitTran();
                return SIMREG_NEWFORMs;
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BESIMREG_NEWFORMs GetSIMREG_NEWFORMs(string msisdnTitle, int requestById, int requestTypeId, int deliverById, string fromDate, string toDate, DataSet ds)
        //public BESIMREG_NEWFORMs GetSIMREG_NEWFORMs(DataSet ds)
        {
            try
            {
                BESIMREG_NEWFORMs SIMREG_NEWFORMs = null;
                sqlHelper = new SQLHelper();
                SIMREG_NEWFORMs = daSIMREG_NEWFORM.GetSIMREG_NEWFORMs(msisdnTitle, requestById, requestTypeId, deliverById, fromDate, toDate, sqlHelper, ds);
                //SIMREG_NEWFORMs = daSIMREG_NEWFORM.GetSIMREG_NEWFORMs(sqlHelper, ds);
                sqlHelper.CommitTran();
                return SIMREG_NEWFORMs;
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BESIMREG_NEWFORM GetSIMREG_NEWFORM(int SIMREG_NEWFORMId)
        {
            try
            {
                BESIMREG_NEWFORM SIMREG_NEWFORM = null;
                sqlHelper = new SQLHelper();
                SIMREG_NEWFORM = daSIMREG_NEWFORM.GetSIMREG_NEWFORM(sqlHelper, SIMREG_NEWFORMId);
                sqlHelper.CommitTran();
                return SIMREG_NEWFORM;
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BESIMREG_NEWFORMs GetSIMREG_NEWFORMs(string msisdnTitle, string requestById, string requestTypeId, string deliverById, string requestFromDate, string requestToDate, string deliverFromDate, string deliverToDate)
        {
            try
            {
                BESIMREG_NEWFORMs SIMREG_NEWFORMs = null;
                sqlHelper = new SQLHelper();
                SIMREG_NEWFORMs = daSIMREG_NEWFORM.GetSIMREG_NEWFORMs(msisdnTitle, requestById, requestTypeId, deliverById, requestFromDate, requestToDate, deliverFromDate, deliverToDate, sqlHelper);
                sqlHelper.CommitTran();
                return SIMREG_NEWFORMs;
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        //For Paging
        public BESIMREG_NEWFORMs GetSIMREG_NEWFORMs(string sidx, string sord, int page, int rows, string msisdnTitle, string requestById, string requestTypeId, string deliverById, string requestFromDate, string requestToDate, string deliverFromDate, string deliverToDate)
        {
            try
            {
                BESIMREG_NEWFORMs SIMREG_NEWFORMs = null;
                sqlHelper = new SQLHelper();
                SIMREG_NEWFORMs = daSIMREG_NEWFORM.GetSIMREG_NEWFORMs(sidx, sord, page, rows, msisdnTitle, requestById, requestTypeId, deliverById, requestFromDate, requestToDate, deliverFromDate, deliverToDate, sqlHelper);
                sqlHelper.CommitTran();
                return SIMREG_NEWFORMs;
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BESIMREG_NEWFORMs GetSIMREG_NEWFORMs(string msisdnTitle, string requestById, string requestFromDate, string requestToDate, string deliverFromDate, string deliverToDate)
        {
            try
            {
                BESIMREG_NEWFORMs SIMREG_NEWFORMs = null;
                sqlHelper = new SQLHelper();
                SIMREG_NEWFORMs = daSIMREG_NEWFORM.GetSIMREG_NEWFORMs(msisdnTitle, requestById, requestFromDate, requestToDate, deliverFromDate, deliverToDate, sqlHelper);
                sqlHelper.CommitTran();
                return SIMREG_NEWFORMs;
            }
            catch (Exception ex)
            {
                //SimReg.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        //For Paging
        public BESIMREG_NEWFORMs GetSIMREG_NEWFORMs(string sidx, string sord, int page, int rows, string msisdnTitle, string requestById, string requestFromDate, string requestToDate, string deliverFromDate, string deliverToDate)
        {
            try
            {
                BESIMREG_NEWFORMs SIMREG_NEWFORMs = null;
                sqlHelper = new SQLHelper();
                SIMREG_NEWFORMs = daSIMREG_NEWFORM.GetSIMREG_NEWFORMs(sidx, sord, page, rows, msisdnTitle, requestById, requestFromDate, requestToDate, deliverFromDate, deliverToDate, sqlHelper);
                sqlHelper.CommitTran();
                return SIMREG_NEWFORMs;
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
