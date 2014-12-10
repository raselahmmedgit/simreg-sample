using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMREG.Data.Repositories.Base;
using SIMREG.Models;
using System.Data;

namespace SIMREG.Data.Repositories
{
    public class SIMREG_NEWFORMRepository : ISIMREG_NEWFORMRepository
    {
        #region IRepositoryBase<SIMREG_NEWFORM> Members

        public SIMREG_NEWFORM GetById(int id)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                string strSQL = "SELECT * FROM SIMREG_NEWFORM WHERE ID = " + id;

                DataTable dt = procedure.GetDataTable(strSQL);

                DataRow dr = dt.Rows[0];

                SIMREG_NEWFORM result = new SIMREG_NEWFORM();
                result.ID = dr.Field<int>("ID");
                result.MSISDNID = dr.Field<int>("MSISDNID");
                result.REQUESTEDDATE = dr.Field<DateTime>("REQUESTEDDATE");
                result.REQUESTEDBYID = dr.Field<int>("REQUESTEDBYID");
                result.REQUESTEDTYPEID = dr.Field<int>("REQUESTEDTYPEID");
                result.REQUESTEDDATE = dr.Field<DateTime>("DELIVEREDBYDATE");
                result.DELIVEREDBYID = dr.Field<int>("DELIVEREDBYID");
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

        public IQueryable<SIMREG_NEWFORM> GetAll()
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                string strSQL = "SELECT * FROM SIMREG_NEWFORM";

                DataTable dt = procedure.GetDataTable(strSQL);

                List<SIMREG_NEWFORM> resultList = new List<SIMREG_NEWFORM>();

                foreach (DataRow dr in dt.Rows)
                {
                    SIMREG_NEWFORM model = new SIMREG_NEWFORM();
                    model.ID = dr.Field<int>("ID");
                    model.MSISDNID = dr.Field<int>("MSISDNID");
                    model.REQUESTEDDATE = dr.Field<DateTime>("REQUESTEDDATE");
                    model.REQUESTEDBYID = dr.Field<int>("REQUESTEDBYID");
                    model.REQUESTEDTYPEID = dr.Field<int>("REQUESTEDTYPEID");
                    model.REQUESTEDDATE = dr.Field<DateTime>("DELIVEREDBYDATE");
                    model.DELIVEREDBYID = dr.Field<int>("DELIVEREDBYID");
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

        public int Insert(SIMREG_NEWFORM entity)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                int tableId = GetTableId("ID", "SIMREG_NEWFORM");

                string strSQL = "INSERT INTO SIMREG_NEWFORM (ID, MSISDNID, REQUESTEDDATE, REQUESTEDBYID, REQUESTEDTYPEID, DELIVEREDBYDATE, DELIVEREDBYID, IDATE, IUSER, EDATE, EUSER) VALUES (" +
                    tableId + "," +
                    entity.MSISDNID + "," +
                    entity.REQUESTEDDATE + "," +
                    entity.REQUESTEDBYID + "," +
                    entity.REQUESTEDTYPEID + "," +
                    entity.DELIVEREDBYDATE + "," +
                    entity.DELIVEREDBYID + "," +
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

        public int Update(SIMREG_NEWFORM entity)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                string strSQL = "UPDATE SIMREG_NEWFORM SET" +
                    "MSISDNID = " + entity.MSISDNID +
                    "REQUESTEDDATE = " + entity.REQUESTEDDATE +
                    "REQUESTEDBYID = " + entity.REQUESTEDBYID +
                    "REQUESTEDTYPEID = " + entity.REQUESTEDTYPEID +
                    "DELIVEREDBYDATE = " + entity.DELIVEREDBYDATE +
                    "DELIVEREDBYID = " + entity.DELIVEREDBYID +
                    "IDATE = " + entity.IDATE +
                    "IUSER = " + entity.IUSER +
                    "EDATE = " + entity.EDATE +
                    "EUSER = " + entity.EUSER +
                    " WHERE ID = " + entity.ID;

                int intResult = procedure.Edit(strSQL);

                return intResult;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int Delete(SIMREG_NEWFORM entity)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                string strSQL = "DELETE SIMREG_NEWFORM WHERE ID = " + entity.ID;

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

    public interface ISIMREG_NEWFORMRepository : IRepositoryBase<SIMREG_NEWFORM>
    {

    }
}