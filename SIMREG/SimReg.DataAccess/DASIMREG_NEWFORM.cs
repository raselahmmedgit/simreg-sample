using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimReg.BusinessEntity;
using SQLFactory;

namespace SimReg.DataAccess
{
    public class DASIMREG_NEWFORM
    {
        public void Save(SQLHelper sqlHelper, BESIMREG_NEWFORM entity)
        {
            string sql = string.Empty;
            try
            {
                if (entity.IsNew)
                {
                    // update tblTableCode
                    DATableCode daTableCode = new DATableCode();
                    //entity.ID = daTableCode.GetTableId(sqlHelper, "ID", "SIMREG_NEWFORM");

                    sql = sqlHelper.MakeSQL(@"INSERT INTO SIMREG_NEWFORM(ID, MSISDNTITLE, REQUESTEDDATE, REQUESTEDBYID, REQUESTEDTYPEID, DELIVEREDBYDATE, DELIVEREDBYID, IDATE, IUSER, EDATE, EUSER)"
                                            + " VALUES(SQ_SIMREG_NEWFORMID.Nextval, $s, $d, $n, $n, $d, $n, SYSDATE, $n, SYSDATE, $n)",
                        //entity.ID,
                        //entity.MSISDNID,
                                            entity.MSISDNTITLE,
                                            entity.REQUESTEDDATE,
                                            entity.REQUESTEDBYID,
                                            entity.REQUESTEDTYPEID,
                                            entity.DELIVEREDBYDATE,
                                            entity.DELIVEREDBYID,
                        //entity.IDATE,
                                            entity.IUSER,
                        //entity.EDATE,
                                            entity.EUSER);
                }
                else
                {
                    sql = sqlHelper.MakeSQL(@"UPDATE SIMREG_NEWFORM SET MSISDNTITLE=$s, REQUESTEDDATE=$d, REQUESTEDBYID=$n, REQUESTEDTYPEID=$n, DELIVEREDBYDATE=$d, DELIVEREDBYID=$n, EDATE=SYSDATE, EUSER=$n WHERE ID=$n",
                        //entity.MSISDNID,
                                            entity.MSISDNTITLE,
                                            entity.REQUESTEDDATE,
                                            entity.REQUESTEDBYID,
                                            entity.REQUESTEDTYPEID,
                                            entity.DELIVEREDBYDATE,
                                            entity.DELIVEREDBYID,
                        //entity.EDATE,
                                            entity.EUSER,
                                            entity.ID);
                }

                sqlHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int TotalDataCount(SQLHelper sqlHelper)
        {
            string sql = string.Empty;
            int rowCount = 0;

            try
            {
                sql = sqlHelper.MakeSQL("SELECT COUNT(ID) FROM SIMREG_NEWFORM");
                object obj = sqlHelper.ExecuteScalar(sql);

                rowCount = Convert.ToInt32(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return rowCount;
        }

        public BESIMREG_NEWFORM GetSIMREG_NEWFORM(SQLHelper sqlHelper, int SIMREG_NEWFORMId)
        {
            string sql = string.Empty;
            BESIMREG_NEWFORMs SIMREG_NEWFORMs = new BESIMREG_NEWFORMs();
            try
            {
                sql = sqlHelper.MakeSQL(@"SELECT * FROM SIMREG_NEWFORM WHERE ID=$n ORDER BY ID", SIMREG_NEWFORMId);
                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToSIMREG_NEWFORMCollection(SIMREG_NEWFORMs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (SIMREG_NEWFORMs.Count > 0)
                return SIMREG_NEWFORMs[0];
            else return new BESIMREG_NEWFORM();
        }

        public BESIMREG_NEWFORMs GetSIMREG_NEWFORMs(SQLHelper sqlHelper)
        {
            string sql = string.Empty;
            BESIMREG_NEWFORMs SIMREG_NEWFORMs = new BESIMREG_NEWFORMs();
            try
            {
                sql = sqlHelper.MakeSQL(@"SELECT * FROM SIMREG_NEWFORM ORDER BY ID");

                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToSIMREG_NEWFORMCollection(SIMREG_NEWFORMs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return SIMREG_NEWFORMs;
        }

        public BESIMREG_NEWFORMs GetSIMREG_NEWFORMs(string msisdnTitle, string requestById, string requestTypeId, string deliverById, string requestFromDate, string requestToDate, string deliverFromDate, string deliverToDate, SQLHelper sqlHelper)
        {
            string sql = string.Empty;
            string whereSql = string.Empty;
            BESIMREG_NEWFORMs SIMREG_NEWFORMs = new BESIMREG_NEWFORMs();
            try
            {

                whereSql += sqlHelper.MakeSQL(sql + " MSISDNTITLE=nvl($s,MSISDNTITLE)", msisdnTitle);

                if (Convert.ToInt32(requestById) > 0)
                {
                    whereSql += sqlHelper.MakeSQL(sql + " AND REQUESTEDBYID=$n", requestById);
                }

                if (Convert.ToInt32(requestTypeId) > 0)
                {
                    whereSql += sqlHelper.MakeSQL(sql + " AND REQUESTEDTYPEID=$n", requestTypeId);
                }

                if (Convert.ToInt32(deliverById) > 0)
                {
                    whereSql += sqlHelper.MakeSQL(sql + " AND DELIVEREDBYID=$n", deliverById);
                }

                if (!String.IsNullOrEmpty(requestFromDate))
                {
                    whereSql += sqlHelper.MakeSQL(sql + " AND REQUESTEDDATE>=$s", requestFromDate);
                }

                if (!String.IsNullOrEmpty(requestToDate))
                {
                    whereSql += sqlHelper.MakeSQL(sql + "   AND REQUESTEDDATE<=$s", requestToDate);
                }

                if (!String.IsNullOrEmpty(deliverFromDate))
                {
                    whereSql += sqlHelper.MakeSQL(sql + " AND DELIVEREDBYDATE>=$s", deliverFromDate);
                }

                if (!String.IsNullOrEmpty(deliverToDate))
                {
                    whereSql += sqlHelper.MakeSQL(sql + "   AND DELIVEREDBYDATE<=$s", deliverToDate);
                }

                sql = sqlHelper.MakeSQL(@"SELECT * FROM SIMREG_NEWFORM WHERE $q ORDER BY ID", whereSql);

                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToSIMREG_NEWFORMCollection(SIMREG_NEWFORMs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return SIMREG_NEWFORMs;
        }

        //For Paging
        public BESIMREG_NEWFORMs GetSIMREG_NEWFORMs(string sidx, string sord, int page, int rows, string msisdnTitle, string requestById, string requestTypeId, string deliverById, string requestFromDate, string requestToDate, string deliverFromDate, string deliverToDate, SQLHelper sqlHelper)
        {
            string sql = string.Empty;
            string whereSql = string.Empty;

            int startRow = (page - 1) * rows + 1;
            int endRow = startRow + rows - 1;

            BESIMREG_NEWFORMs SIMREG_NEWFORMs = new BESIMREG_NEWFORMs();
            try
            {

                whereSql += sqlHelper.MakeSQL(sql + " MSISDNTITLE=nvl($s,MSISDNTITLE)", msisdnTitle);

                if (Convert.ToInt32(requestById) > 0)
                {
                    whereSql += sqlHelper.MakeSQL(sql + " AND REQUESTEDBYID=$n", requestById);
                }

                if (Convert.ToInt32(requestTypeId) > 0)
                {
                    whereSql += sqlHelper.MakeSQL(sql + " AND REQUESTEDTYPEID=$n", requestTypeId);
                }

                if (Convert.ToInt32(deliverById) > 0)
                {
                    whereSql += sqlHelper.MakeSQL(sql + " AND DELIVEREDBYID=$n", deliverById);
                }

                if (!String.IsNullOrEmpty(requestFromDate))
                {
                    whereSql += sqlHelper.MakeSQL(sql + " AND REQUESTEDDATE>=$s", requestFromDate);
                }

                if (!String.IsNullOrEmpty(requestToDate))
                {
                    whereSql += sqlHelper.MakeSQL(sql + "   AND REQUESTEDDATE<=$s", requestToDate);
                }

                if (!String.IsNullOrEmpty(deliverFromDate))
                {
                    whereSql += sqlHelper.MakeSQL(sql + " AND DELIVEREDBYDATE>=$s", deliverFromDate);
                }

                if (!String.IsNullOrEmpty(deliverToDate))
                {
                    whereSql += sqlHelper.MakeSQL(sql + "   AND DELIVEREDBYDATE<=$s", deliverToDate);
                }

                sql = sqlHelper.MakeSQL(@"SELECT * FROM SIMREG_NEWFORM WHERE $q ORDER BY ID", whereSql);


                if (rows > 0)
                {
                    sql = DBUtility.GetPagingSQL(sql, startRow, endRow);
                }

                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToSIMREG_NEWFORMCollection(SIMREG_NEWFORMs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return SIMREG_NEWFORMs;
        }

        public BESIMREG_NEWFORMs GetSIMREG_NEWFORMs(string msisdnTitle, string requestById, string requestFromDate, string requestToDate, string deliverFromDate, string deliverToDate, SQLHelper sqlHelper)
        {
            string sql = string.Empty;
            string whereSql = string.Empty;
            BESIMREG_NEWFORMs SIMREG_NEWFORMs = new BESIMREG_NEWFORMs();
            try
            {

                whereSql += sqlHelper.MakeSQL(sql + " MSISDNTITLE=nvl($s,MSISDNTITLE)", msisdnTitle);

                if (Convert.ToInt32(requestById) > 0)
                {
                    whereSql += sqlHelper.MakeSQL(sql + " AND REQUESTEDBYID=$n", requestById);
                }

                if (!String.IsNullOrEmpty(requestFromDate))
                {
                    whereSql += sqlHelper.MakeSQL(sql + " AND REQUESTEDDATE>=$s", requestFromDate);
                }

                if (!String.IsNullOrEmpty(requestToDate))
                {
                    whereSql += sqlHelper.MakeSQL(sql + "   AND REQUESTEDDATE<=$s", requestToDate);
                }

                if (!String.IsNullOrEmpty(deliverFromDate))
                {
                    whereSql += sqlHelper.MakeSQL(sql + " AND DELIVEREDBYDATE>=$s", deliverFromDate);
                }

                if (!String.IsNullOrEmpty(deliverToDate))
                {
                    whereSql += sqlHelper.MakeSQL(sql + "   AND DELIVEREDBYDATE<=$s", deliverToDate);
                }

                sql = sqlHelper.MakeSQL(@"SELECT * FROM SIMREG_NEWFORM WHERE $q ORDER BY ID", whereSql);

                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToSIMREG_NEWFORMCollection(SIMREG_NEWFORMs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return SIMREG_NEWFORMs;
        }

        //For Paging
        public BESIMREG_NEWFORMs GetSIMREG_NEWFORMs(string sidx, string sord, int page, int rows, string msisdnTitle, string requestById, string requestFromDate, string requestToDate, string deliverFromDate, string deliverToDate, SQLHelper sqlHelper)
        {
            string sql = string.Empty;
            string whereSql = string.Empty;

            int startRow = (page - 1) * rows + 1;
            int endRow = startRow + rows - 1;

            BESIMREG_NEWFORMs SIMREG_NEWFORMs = new BESIMREG_NEWFORMs();
            try
            {

                whereSql += sqlHelper.MakeSQL(sql + " MSISDNTITLE=nvl($s,MSISDNTITLE)", msisdnTitle);

                if (Convert.ToInt32(requestById) > 0)
                {
                    whereSql += sqlHelper.MakeSQL(sql + " AND REQUESTEDBYID=$n", requestById);
                }

                if (!String.IsNullOrEmpty(requestFromDate))
                {
                    whereSql += sqlHelper.MakeSQL(sql + " AND REQUESTEDDATE>=$s", requestFromDate);
                }

                if (!String.IsNullOrEmpty(requestToDate))
                {
                    whereSql += sqlHelper.MakeSQL(sql + "   AND REQUESTEDDATE<=$s", requestToDate);
                }

                if (!String.IsNullOrEmpty(deliverFromDate))
                {
                    whereSql += sqlHelper.MakeSQL(sql + " AND DELIVEREDBYDATE>=$s", deliverFromDate);
                }

                if (!String.IsNullOrEmpty(deliverToDate))
                {
                    whereSql += sqlHelper.MakeSQL(sql + "   AND DELIVEREDBYDATE<=$s", deliverToDate);
                }

                sql = sqlHelper.MakeSQL(@"SELECT * FROM SIMREG_NEWFORM WHERE $q ORDER BY ID", whereSql);

                if (rows > 0)
                {
                    sql = DBUtility.GetPagingSQL(sql, startRow, endRow);
                }

                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToSIMREG_NEWFORMCollection(SIMREG_NEWFORMs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return SIMREG_NEWFORMs;
        }

        public BESIMREG_NEWFORMs GetSIMREG_NEWFORMs(string msisdnTitle, int requestById, int requestTypeId, int deliverById, string fromDate, string toDate, SQLHelper sqlHelper, DataSet ds)
        {
            string sql = string.Empty;
            string whereSql = string.Empty;
            BESIMREG_NEWFORMs SIMREG_NEWFORMs = new BESIMREG_NEWFORMs();
            try
            {

                whereSql += sqlHelper.MakeSQL(sql + " N.MSISDNTITLE=nvl($s,MSISDNTITLE)", msisdnTitle);

                if (Convert.ToInt32(requestById) > 0)
                {
                    whereSql += sqlHelper.MakeSQL(sql + " OR N.REQUESTEDBYID=$n", requestById);
                }

                if (Convert.ToInt32(requestTypeId) > 0)
                {
                    whereSql += sqlHelper.MakeSQL(sql + " OR N.REQUESTEDTYPEID=$n", requestTypeId);
                }

                if (Convert.ToInt32(deliverById) > 0)
                {
                    whereSql += sqlHelper.MakeSQL(sql + " OR N.DELIVEREDBYID=$n", deliverById);
                }

                if (!String.IsNullOrEmpty(fromDate))
                {
                    whereSql += sqlHelper.MakeSQL(sql + " OR N.REQUESTEDDATE=$d", fromDate);
                }

                if (!String.IsNullOrEmpty(toDate))
                {
                    whereSql += sqlHelper.MakeSQL(sql + "   OR N.DELIVEREDBYDATE=$d", toDate);
                }

                //SELECT N.MSISDNTITLE, N.REQUESTEDDATE, Rby.TITLE REQUESTEDBY,  RType.TITLE REQUESTEDTYPE, N.DELIVEREDBYDATE, Dby.TITLE DELIVEREDBY  FROM SIMREG_NEWFORM N INNER JOIN SIMREG_DELIVEREDBY Dby ON Dby.DELIVEREDBYID = N.DELIVEREDBYID INNER JOIN SIMREG_REQUESTEDBY Rby ON Rby.REQUESTEDBYID = N.REQUESTEDBYID INNER JOIN SIMREG_REQUESTEDTYPE RType ON RType.REQUESTEDTYPEID = N.REQUESTEDTYPEID WHERE N.MSISDNTITLE = '01926662002' ORDER BY n.ID

                //sql = sqlHelper.MakeSQL(@"SELECT * FROM SIMREG_NEWFORM ORDER BY ID", whereSql);
                //sql = sqlHelper.MakeSQL(@"SELECT * FROM SIMREG_NEWFORM WHERE $q ORDER BY ID", whereSql);

                sql = sqlHelper.MakeSQL(@"SELECT N.MSISDNTITLE, N.REQUESTEDDATE, Rby.TITLE REQUESTEDBY,  RType.TITLE REQUESTEDTYPE, N.DELIVEREDBYDATE, Dby.TITLE DELIVEREDBY  FROM SIMREG_NEWFORM N INNER JOIN SIMREG_DELIVEREDBY Dby ON Dby.DELIVEREDBYID = N.DELIVEREDBYID INNER JOIN SIMREG_REQUESTEDBY Rby ON Rby.REQUESTEDBYID = N.REQUESTEDBYID INNER JOIN SIMREG_REQUESTEDTYPE RType ON RType.REQUESTEDTYPEID = N.REQUESTEDTYPEID WHERE $q ORDER BY ID", whereSql);

                //IDataReader reader = sqlHelper.ExecuteQuery(sql);
                //AddToSIMREG_NEWFORMCollection(SIMREG_NEWFORMs, reader);
                //reader.Close();

                sqlHelper.ExecuteQuery(sql, ds);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return SIMREG_NEWFORMs;
        }

        //For Paging
        public BESIMREG_NEWFORMs GetSIMREG_NEWFORMs(string sidx, string sord, int page, int rows, string msisdnTitle, int requestById, int requestTypeId, int deliverById, string fromDate, string toDate, SQLHelper sqlHelper, DataSet ds)
        {
            string sql = string.Empty;
            string whereSql = string.Empty;

            int startRow = (page - 1) * rows + 1;
            int endRow = startRow + rows - 1;

            BESIMREG_NEWFORMs SIMREG_NEWFORMs = new BESIMREG_NEWFORMs();
            try
            {

                whereSql += sqlHelper.MakeSQL(sql + " MSISDNTITLE=nvl($s,MSISDNTITLE)", msisdnTitle);

                if (Convert.ToInt32(requestById) > 0)
                {
                    whereSql += sqlHelper.MakeSQL(sql + " OR REQUESTEDBYID=$n", requestById);
                }

                if (Convert.ToInt32(requestTypeId) > 0)
                {
                    whereSql += sqlHelper.MakeSQL(sql + " OR REQUESTEDTYPEID=$n", requestTypeId);
                }

                if (Convert.ToInt32(deliverById) > 0)
                {
                    whereSql += sqlHelper.MakeSQL(sql + " OR DELIVEREDBYID=$n", deliverById);
                }

                if (!String.IsNullOrEmpty(fromDate))
                {
                    whereSql += sqlHelper.MakeSQL(sql + " OR REQUESTEDDATE=$d", fromDate);
                }

                if (!String.IsNullOrEmpty(toDate))
                {
                    whereSql += sqlHelper.MakeSQL(sql + "   OR DELIVEREDBYDATE=$d", toDate);
                }

                sql = sqlHelper.MakeSQL(@"SELECT * FROM SIMREG_NEWFORM WHERE $q ORDER BY ID", whereSql);

                if (rows > 0)
                {
                    sql = DBUtility.GetPagingSQL(sql, startRow, endRow);
                }

                //sql = sqlHelper.MakeSQL(@"SELECT * FROM SIMREG_NEWFORM ORDER BY ID", whereSql);

                //IDataReader reader = sqlHelper.ExecuteQuery(sql);
                //AddToSIMREG_NEWFORMCollection(SIMREG_NEWFORMs, reader);
                //reader.Close();

                sqlHelper.ExecuteQuery(sql, ds);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return SIMREG_NEWFORMs;
        }

        private BESIMREG_NEWFORMs AddToSIMREG_NEWFORMCollection(BESIMREG_NEWFORMs SIMREG_NEWFORMs, IDataReader reader)
        {
            NULLHandler nullHandler = new NULLHandler(reader);
            while (reader.Read())
            {
                SIMREG_NEWFORMs.Add(PreaperSIMREG_NEWFORMObject(nullHandler));
            }
            return SIMREG_NEWFORMs;
        }

        private BESIMREG_NEWFORM PreaperSIMREG_NEWFORMObject(NULLHandler nullHandler)
        {
            BESIMREG_NEWFORM SIMREG_NEWFORM = new BESIMREG_NEWFORM();

            SIMREG_NEWFORM.IsNew = false;
            SIMREG_NEWFORM.ID = nullHandler.GetInt("ID");
            SIMREG_NEWFORM.MSISDNID = nullHandler.GetInt("MSISDNID");
            SIMREG_NEWFORM.MSISDNTITLE = nullHandler.GetString("MSISDNTITLE");
            SIMREG_NEWFORM.REQUESTEDDATE = nullHandler.GetDateTime("REQUESTEDDATE");
            SIMREG_NEWFORM.REQUESTEDBYID = nullHandler.GetInt("REQUESTEDBYID");
            SIMREG_NEWFORM.REQUESTEDTYPEID = nullHandler.GetInt("REQUESTEDTYPEID");
            SIMREG_NEWFORM.DELIVEREDBYDATE = nullHandler.GetDateTime("DELIVEREDBYDATE");
            SIMREG_NEWFORM.DELIVEREDBYID = nullHandler.GetInt("DELIVEREDBYID");

            SIMREG_NEWFORM.IDATE = nullHandler.GetDateTime("IDATE");
            SIMREG_NEWFORM.IUSER = nullHandler.GetInt("IUSER");
            SIMREG_NEWFORM.EDATE = nullHandler.GetDateTime("EDATE");
            SIMREG_NEWFORM.EUSER = nullHandler.GetInt("EUSER");

            return SIMREG_NEWFORM;
        }

        public void Delete(SQLHelper sqlHelper, int ID)
        {
            string sql = string.Empty;
            try
            {
                sql = sqlHelper.MakeSQL(@"DELETE SIMREG_NEWFORM WHERE ID =$n", ID);
                sqlHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
