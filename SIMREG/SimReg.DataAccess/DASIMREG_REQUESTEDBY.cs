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
    public class DASIMREG_REQUESTEDBY
    {
        public void Save(SQLHelper sqlHelper, BESIMREG_REQUESTEDBY entity)
        {
            string sql = string.Empty;
            try
            {
                if (entity.IsNew)
                {
                    // update tblTableCode
                    DATableCode daTableCode = new DATableCode();
                    //entity.REQUESTEDBYID = daTableCode.GetTableId(sqlHelper, "REQUESTEDBYID", "SIMREG_REQUESTEDBY");

                    sql = sqlHelper.MakeSQL(@"INSERT INTO SIMREG_REQUESTEDBY(REQUESTEDBYID, TITLE, IDATE, IUSER, EDATE, EUSER)"
                                            + " VALUES(SQ_SIMREG_REQUESTEDBYID.Nextval, $s, SYSDATE, $n, SYSDATE, $n)",
                        //entity.REQUESTEDBYID,
                                            entity.TITLE,
                                            //entity.IDATE,
                                            entity.IUSER,
                                            //entity.EDATE,
                                            entity.EUSER);
                }
                else
                {
                    sql = sqlHelper.MakeSQL(@"UPDATE SIMREG_REQUESTEDBY SET TITLE=$s, EDATE=SYSDATE, EUSER=$n WHERE REQUESTEDBYID=$n",
                                            entity.TITLE,
                                            //entity.EDATE,
                                            entity.EUSER,
                                            entity.REQUESTEDBYID);
                }

                sqlHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BESIMREG_REQUESTEDBY GetSIMREG_REQUESTEDBY(SQLHelper sqlHelper, int SIMREG_REQUESTEDBYId)
        {
            string sql = string.Empty;
            BESIMREG_REQUESTEDBYs SIMREG_REQUESTEDBYs = new BESIMREG_REQUESTEDBYs();
            try
            {
                sql = sqlHelper.MakeSQL(@"SELECT * FROM SIMREG_REQUESTEDBY WHERE REQUESTEDBYID=$n ORDER BY REQUESTEDBYID", SIMREG_REQUESTEDBYId);
                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToSIMREG_REQUESTEDBYCollection(SIMREG_REQUESTEDBYs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (SIMREG_REQUESTEDBYs.Count > 0)
                return SIMREG_REQUESTEDBYs[0];
            else return new BESIMREG_REQUESTEDBY();
        }

        public BESIMREG_REQUESTEDBYs GetSIMREG_REQUESTEDBYs(SQLHelper sqlHelper)
        {
            string sql = string.Empty;
            BESIMREG_REQUESTEDBYs SIMREG_REQUESTEDBYs = new BESIMREG_REQUESTEDBYs();
            try
            {
                sql = sqlHelper.MakeSQL(@"SELECT * FROM SIMREG_REQUESTEDBY ORDER BY REQUESTEDBYID");

                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToSIMREG_REQUESTEDBYCollection(SIMREG_REQUESTEDBYs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return SIMREG_REQUESTEDBYs;
        }

        private BESIMREG_REQUESTEDBYs AddToSIMREG_REQUESTEDBYCollection(BESIMREG_REQUESTEDBYs SIMREG_REQUESTEDBYs, IDataReader reader)
        {
            NULLHandler nullHandler = new NULLHandler(reader);
            while (reader.Read())
            {
                SIMREG_REQUESTEDBYs.Add(PreaperSIMREG_REQUESTEDBYObject(nullHandler));
            }
            return SIMREG_REQUESTEDBYs;
        }

        private BESIMREG_REQUESTEDBY PreaperSIMREG_REQUESTEDBYObject(NULLHandler nullHandler)
        {
            BESIMREG_REQUESTEDBY SIMREG_REQUESTEDBY = new BESIMREG_REQUESTEDBY();

            SIMREG_REQUESTEDBY.IsNew = false;
            SIMREG_REQUESTEDBY.REQUESTEDBYID = nullHandler.GetInt("REQUESTEDBYID");
            SIMREG_REQUESTEDBY.TITLE = nullHandler.GetString("TITLE");

            SIMREG_REQUESTEDBY.IDATE = nullHandler.GetDateTime("IDATE");
            SIMREG_REQUESTEDBY.IUSER = nullHandler.GetInt("IUSER");
            SIMREG_REQUESTEDBY.EDATE = nullHandler.GetDateTime("EDATE");
            SIMREG_REQUESTEDBY.EUSER = nullHandler.GetInt("EUSER");

            return SIMREG_REQUESTEDBY;
        }

        public void Delete(SQLHelper sqlHelper, int ID)
        {
            string sql = string.Empty;
            try
            {
                sql = sqlHelper.MakeSQL(@"DELETE SIMREG_REQUESTEDBY WHERE REQUESTEDBYID=$n", ID);
                sqlHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
