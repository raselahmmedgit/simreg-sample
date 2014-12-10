using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMREG.Data.Repositories.Base;
using SIMREG.Models;
using System.Data;

namespace SIMREG.Data.Repositories
{
    public class SIMREG_REQUESTEDTYPERepository : ISIMREG_REQUESTEDTYPERepository
    {
        #region IRepositoryBase<SIMREG_REQUESTEDTYPE> Members

        public SIMREG_REQUESTEDTYPE GetById(int id)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                string strSQL = "SELECT * FROM SIMREG_REQUESTEDTYPE WHERE REQUESTEDTYPEID = " + id;

                DataTable dt = procedure.GetDataTable(strSQL);

                DataRow dr = dt.Rows[0];

                SIMREG_REQUESTEDTYPE result = new SIMREG_REQUESTEDTYPE();
                result.REQUESTEDTYPEID = dr.Field<int>("REQUESTEDTYPEID");
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

        public IQueryable<SIMREG_REQUESTEDTYPE> GetAll()
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                string strSQL = "SELECT * FROM SIMREG_REQUESTEDTYPE";

                DataTable dt = procedure.GetDataTable(strSQL);

                List<SIMREG_REQUESTEDTYPE> resultList = new List<SIMREG_REQUESTEDTYPE>();

                foreach (DataRow dr in dt.Rows)
                {
                    SIMREG_REQUESTEDTYPE model = new SIMREG_REQUESTEDTYPE();
                    model.REQUESTEDTYPEID = dr.Field<int>("REQUESTEDTYPEID");
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

        public int Insert(SIMREG_REQUESTEDTYPE entity)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                int tableId = GetTableId("REQUESTEDTYPEID", "SIMREG_REQUESTEDTYPE");

                string strSQL = "INSERT INTO SIMREG_REQUESTEDTYPE (REQUESTEDTYPEID, TITLE, IDATE, IUSER, EDATE, EUSER) VALUES (" +
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

        public int Update(SIMREG_REQUESTEDTYPE entity)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                string strSQL = "UPDATE SIMREG_REQUESTEDTYPE SET" +
                    "REQUESTEDTYPEID = " + entity.REQUESTEDTYPEID +
                    "TITLE = " + entity.TITLE +
                    "IDATE = " + entity.IDATE +
                    "IUSER = " + entity.IUSER +
                    "EDATE = " + entity.EDATE +
                    "EUSER = " + entity.EUSER +
                    " WHERE REQUESTEDTYPEID = " + entity.REQUESTEDTYPEID;

                int intResult = procedure.Edit(strSQL);

                return intResult;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int Delete(SIMREG_REQUESTEDTYPE entity)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure();

                string strSQL = "DELETE SIMREG_REQUESTEDTYPE WHERE REQUESTEDTYPEID = " + entity.REQUESTEDTYPEID;

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

    public interface ISIMREG_REQUESTEDTYPERepository : IRepositoryBase<SIMREG_REQUESTEDTYPE>
    {

    }
}