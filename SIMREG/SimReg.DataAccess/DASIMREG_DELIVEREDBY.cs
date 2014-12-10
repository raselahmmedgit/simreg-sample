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
    public class DASIMREG_DELIVEREDBY
    {
        public void Save(SQLHelper sqlHelper, BESIMREG_DELIVEREDBY entity)
        {
            string sql = string.Empty;
            try
            {
                if (entity.IsNew)
                {
                    // update tblTableCode
                    DATableCode daTableCode = new DATableCode();
                    //entity.DELIVEREDBYID = daTableCode.GetTableId(sqlHelper, "DELIVEREDBYID", "SIMREG_DELIVEREDBY");

                    sql = sqlHelper.MakeSQL(@"INSERT INTO SIMREG_DELIVEREDBY(DELIVEREDBYID, TITLE, USERNAME, IDATE, IUSER, EDATE, EUSER)"
                                            + " VALUES(SQ_SIMREG_DELIVEREDID.Nextval, $s, $s, SYSDATE, $n, SYSDATE, $n)",
                        //entity.DELIVEREDBYID,
                                            entity.TITLE, entity.USERNAME,
                        //entity.IDATE,
                                            entity.IUSER,
                        //entity.EDATE,
                                            entity.EUSER);
                }
                else
                {
                    sql = sqlHelper.MakeSQL(@"UPDATE SIMREG_DELIVEREDBY SET TITLE=$s, USERNAME=$s, EDATE=SYSDATE, EUSER=$n WHERE DELIVEREDBYID=$n",
                                            entity.TITLE, entity.USERNAME,
                        //entity.EDATE,
                                            entity.EUSER,
                                            entity.DELIVEREDBYID);
                }

                sqlHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BESIMREG_DELIVEREDBY GetSIMREG_DELIVEREDBY(SQLHelper sqlHelper, int SIMREG_DELIVEREDBYId)
        {
            string sql = string.Empty;
            BESIMREG_DELIVEREDBYs SIMREG_DELIVEREDBYs = new BESIMREG_DELIVEREDBYs();
            try
            {
                sql = sqlHelper.MakeSQL(@"SELECT * FROM SIMREG_DELIVEREDBY WHERE DELIVEREDBYID=$n ORDER BY DELIVEREDBYID", SIMREG_DELIVEREDBYId);
                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToSIMREG_DELIVEREDBYCollection(SIMREG_DELIVEREDBYs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (SIMREG_DELIVEREDBYs.Count > 0)
                return SIMREG_DELIVEREDBYs[0];
            else return new BESIMREG_DELIVEREDBY();
        }

        public BESIMREG_DELIVEREDBY GetSIMREG_DELIVEREDBYbyUSERNAME(SQLHelper sqlHelper, string userName)
        {
            string sql = string.Empty;
            BESIMREG_DELIVEREDBYs SIMREG_DELIVEREDBYs = new BESIMREG_DELIVEREDBYs();
            try
            {
                sql = sqlHelper.MakeSQL(@"SELECT * FROM SIMREG_DELIVEREDBY WHERE USERNAME=$s", userName);
                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToSIMREG_DELIVEREDBYCollection(SIMREG_DELIVEREDBYs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (SIMREG_DELIVEREDBYs.Count > 0)
                return SIMREG_DELIVEREDBYs[0];
            else return new BESIMREG_DELIVEREDBY();
        }

        public BESIMREG_DELIVEREDBYs GetSIMREG_DELIVEREDBYs(SQLHelper sqlHelper)
        {
            string sql = string.Empty;
            BESIMREG_DELIVEREDBYs SIMREG_DELIVEREDBYs = new BESIMREG_DELIVEREDBYs();
            try
            {
                sql = sqlHelper.MakeSQL(@"SELECT * FROM SIMREG_DELIVEREDBY ORDER BY DELIVEREDBYID");

                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToSIMREG_DELIVEREDBYCollection(SIMREG_DELIVEREDBYs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return SIMREG_DELIVEREDBYs;
        }

        private BESIMREG_DELIVEREDBYs AddToSIMREG_DELIVEREDBYCollection(BESIMREG_DELIVEREDBYs SIMREG_DELIVEREDBYs, IDataReader reader)
        {
            NULLHandler nullHandler = new NULLHandler(reader);
            while (reader.Read())
            {
                SIMREG_DELIVEREDBYs.Add(PreaperSIMREG_DELIVEREDBYObject(nullHandler));
            }
            return SIMREG_DELIVEREDBYs;
        }

        private BESIMREG_DELIVEREDBY PreaperSIMREG_DELIVEREDBYObject(NULLHandler nullHandler)
        {
            BESIMREG_DELIVEREDBY SIMREG_DELIVEREDBY = new BESIMREG_DELIVEREDBY();

            SIMREG_DELIVEREDBY.IsNew = false;
            SIMREG_DELIVEREDBY.DELIVEREDBYID = nullHandler.GetInt("DELIVEREDBYID");
            SIMREG_DELIVEREDBY.TITLE = nullHandler.GetString("TITLE");
            SIMREG_DELIVEREDBY.USERNAME = nullHandler.GetString("USERNAME");
            SIMREG_DELIVEREDBY.CANEDIT = nullHandler.GetBoolean("CANEDIT");

            SIMREG_DELIVEREDBY.IDATE = nullHandler.GetDateTime("IDATE");
            SIMREG_DELIVEREDBY.IUSER = nullHandler.GetInt("IUSER");
            SIMREG_DELIVEREDBY.EDATE = nullHandler.GetDateTime("EDATE");
            SIMREG_DELIVEREDBY.EUSER = nullHandler.GetInt("EUSER");

            return SIMREG_DELIVEREDBY;
        }

        public void Delete(SQLHelper sqlHelper, int ID)
        {
            string sql = string.Empty;
            try
            {
                sql = sqlHelper.MakeSQL(@"DELETE SIMREG_DELIVEREDBY WHERE DELIVEREDBYID=$n", ID);
                sqlHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
