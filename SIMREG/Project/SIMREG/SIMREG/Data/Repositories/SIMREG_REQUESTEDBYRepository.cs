using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMREG.Data.Repositories.Base;
using SIMREG.Models;
using System.Data;

namespace SIMREG.Data.Repositories
{
    public class SIMREG_REQUESTEDBYRepository : ISIMREG_REQUESTEDBYRepository
    {
        #region IRepositoryBase<SIMREG_REQUESTEDBY> Members

        public SIMREG_REQUESTEDBY GetById(int id)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                string strSQL = "SELECT * FROM SIMREG_REQUESTEDBY WHERE REQUESTEDBYID = " + id;

                DataTable dt = procedure.GetDataTable(strSQL);

                DataRow dr = dt.Rows[0];

                SIMREG_REQUESTEDBY result = new SIMREG_REQUESTEDBY();
                result.REQUESTEDBYID = dr.Field<int>("REQUESTEDBYID");
                result.TITLE = dr.Field<string>("TITLE");
                result.IDATE = dr.Field<DateTime>("IDATE");
                result.IUSER = dr.Field<int>("IUSER");
                result.EDATE = dr.Field<DateTime>("EDATE");
                result.EUSER = dr.Field<int>("EUSER");

                return result;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public IQueryable<SIMREG_REQUESTEDBY> GetAll()
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                string strSQL = "SELECT * FROM SIMREG_REQUESTEDBY";

                DataTable dt = procedure.GetDataTable(strSQL);

                List<SIMREG_REQUESTEDBY> resultList = new List<SIMREG_REQUESTEDBY>();

                foreach (DataRow dr in dt.Rows)
                {
                    SIMREG_REQUESTEDBY model = new SIMREG_REQUESTEDBY();
                    model.REQUESTEDBYID = dr.Field<int>("REQUESTEDBYID");
                    model.TITLE = dr.Field<string>("TITLE");
                    model.IDATE = dr.Field<DateTime>("IDATE");
                    model.IUSER = dr.Field<int>("IUSER");
                    model.EDATE = dr.Field<DateTime>("EDATE");
                    model.EUSER = dr.Field<int>("EUSER");

                    resultList.Add(model);
                }

                return resultList.AsQueryable();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int Insert(SIMREG_REQUESTEDBY entity)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                int tableId = GetTableId("REQUESTEDBYID", "SIMREG_REQUESTEDBY");

                string strSQL = "INSERT INTO SIMREG_REQUESTEDBY (REQUESTEDBYID, TITLE, IDATE, IUSER, EDATE, EUSER) VALUES (" +
                    tableId + "," +
                    entity.TITLE + "," +
                    entity.IDATE + "," +
                    entity.IUSER + "," +
                    entity.EDATE + "," +
                    entity.EUSER + "," +
                    ")";

                int intResult = procedure.Add(strSQL);

                return intResult;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int Update(SIMREG_REQUESTEDBY entity)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                string strSQL = "UPDATE SIMREG_REQUESTEDBY SET" +
                    "REQUESTEDBYID = " + entity.REQUESTEDBYID +
                    "TITLE = " + entity.TITLE +
                    "IDATE = " + entity.IDATE +
                    "IUSER = " + entity.IUSER +
                    "EDATE = " + entity.EDATE +
                    "EUSER = " + entity.EUSER +
                    " WHERE REQUESTEDBYID = " + entity.REQUESTEDBYID;

                int intResult = procedure.Edit(strSQL);

                return intResult;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int Delete(SIMREG_REQUESTEDBY entity)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                string strSQL = "DELETE SIMREG_REQUESTEDBY WHERE REQUESTEDBYID = " + entity.REQUESTEDBYID;

                int intResult = procedure.Delete(strSQL);

                return intResult;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion

        public int GetTableId(string idName, string tableName)
        {
            int tableId = 0;
            string strSQL = string.Empty;

            try
            {
                OracleProcedure procedure = new OracleProcedure();

                strSQL = "SELECT MAX(" + idName + ") FROM " + tableName.ToUpper();

                var sas = procedure.GetTableId(strSQL);

                return tableId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public interface ISIMREG_REQUESTEDBYRepository : IRepositoryBase<SIMREG_REQUESTEDBY>
    {

    }
}