using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMREG.Data.Repositories.Base;
using SIMREG.Models;
using System.Data;

namespace SIMREG.Data.Repositories
{
    public class SIMREG_DELIVEREDBYRepository : ISIMREG_DELIVEREDBYRepository
    {
        #region IRepositoryBase<SIMREG_DELIVEREDBY> Members

        public SIMREG_DELIVEREDBY GetById(int id)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                string strSQL = "SELECT * FROM SIMREG_DELIVEREDBY WHERE DELIVEREDBYID = " + id;

                DataTable dt = procedure.GetDataTable(strSQL);

                DataRow dr = dt.Rows[0];

                SIMREG_DELIVEREDBY result = new SIMREG_DELIVEREDBY();
                result.DELIVEREDBYID = dr.Field<int>("DELIVEREDBYID");
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

        public IQueryable<SIMREG_DELIVEREDBY> GetAll()
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                string strSQL = "SELECT * FROM SIMREG_DELIVEREDBY";

                DataTable dt = procedure.GetDataTable(strSQL);

                List<SIMREG_DELIVEREDBY> resultList = new List<SIMREG_DELIVEREDBY>();

                foreach (DataRow dr in dt.Rows)
                {
                    SIMREG_DELIVEREDBY model = new SIMREG_DELIVEREDBY();
                    model.DELIVEREDBYID = dr.Field<int>("DELIVEREDBYID");
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

        public int Insert(SIMREG_DELIVEREDBY entity)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                int tableId = GetTableId("ID", "SIMREG_NEWFORM");

                string strSQL = "INSERT INTO SIMREG_DELIVEREDBY (DELIVEREDBYID, TITLE, IDATE, IUSER, EDATE, EUSER) VALUES (" +
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

        public int Update(SIMREG_DELIVEREDBY entity)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                string strSQL = "UPDATE SIMREG_DELIVEREDBY SET" +
                    "DELIVEREDBYID = " + entity.DELIVEREDBYID +
                    "TITLE = " + entity.TITLE +
                    "IDATE = " + entity.IDATE +
                    "IUSER = " + entity.IUSER +
                    "EDATE = " + entity.EDATE +
                    "EUSER = " + entity.EUSER +
                    " WHERE DELIVEREDBYID = " + entity.DELIVEREDBYID;

                int intResult = procedure.Edit(strSQL);

                return intResult;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int Delete(SIMREG_DELIVEREDBY entity)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                string strSQL = "DELETE SIMREG_DELIVEREDBY WHERE DELIVEREDBYID = " + entity.DELIVEREDBYID;

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

    public interface ISIMREG_DELIVEREDBYRepository : IRepositoryBase<SIMREG_DELIVEREDBY>
    {

    }
}