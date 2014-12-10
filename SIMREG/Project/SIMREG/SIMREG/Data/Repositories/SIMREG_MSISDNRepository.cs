using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMREG.Models;
using SIMREG.Data.Repositories.Base;
using SIMREG.Helpers;
using System.Data;
using System.Data.OracleClient;

namespace SIMREG.Data.Repositories
{
    public class SIMREG_MSISDNRepository : ISIMREG_MSISDNRepository
    {

        #region IRepositoryBase<SIMREG_MSISDN> Members

        public SIMREG_MSISDN GetById(int id)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                string strSQL = "SELECT * FROM SIMREG_MSISDN WHERE ID = " + id;

                DataTable dt = procedure.GetDataTable(strSQL);

                DataRow dr = dt.Rows[0];

                SIMREG_MSISDN result = new SIMREG_MSISDN();
                result.MSISDNID = dr.Field<int>("MSISDNID");
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

        public IQueryable<SIMREG_MSISDN> GetAll()
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                string strSQL = "SELECT * FROM SIMREG_MSISDN";

                DataTable dt = procedure.GetDataTable(strSQL);

                List<SIMREG_MSISDN> resultList = new List<SIMREG_MSISDN>();

                foreach (DataRow dr in dt.Rows)
                {
                    SIMREG_MSISDN model = new SIMREG_MSISDN();
                    model.MSISDNID = dr.Field<int>("MSISDNID");
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

        public int Insert(SIMREG_MSISDN entity)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                int tableId = GetTableId("MSISDNID", "SIMREG_MSISDN");

                string strSQL = "INSERT INTO SIMREG_MSISDN (MSISDNID, TITLE, IDATE, IUSER, EDATE, EUSER) VALUES (" +
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

        public int Update(SIMREG_MSISDN entity)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                string strSQL = "UPDATE SIMREG_MSISDN SET" +
                    "MSISDNID = " + entity.MSISDNID +
                    "TITLE = " + entity.TITLE +
                    "IDATE = " + entity.IDATE +
                    "IUSER = " + entity.IUSER +
                    "EDATE = " + entity.EDATE +
                    "EUSER = " + entity.EUSER +
                    " WHERE MSISDNID = " + entity.MSISDNID;

                int intResult = procedure.Edit(strSQL);

                return intResult;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int Delete(SIMREG_MSISDN entity)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                string strSQL = "DELETE SIMREG_MSISDN WHERE ID = " + entity.MSISDNID;

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

    public interface ISIMREG_MSISDNRepository : IRepositoryBase<SIMREG_MSISDN>
    {

    }
}