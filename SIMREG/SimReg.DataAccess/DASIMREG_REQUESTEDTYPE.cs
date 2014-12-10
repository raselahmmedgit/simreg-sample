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
    public class DASIMREG_REQUESTEDTYPE
    {
        public void Save(SQLHelper sqlHelper, BESIMREG_REQUESTEDTYPE entity)
        {
            string sql = string.Empty;
            try
            {
                if (entity.IsNew)
                {
                    // update tblTableCode
                    DATableCode daTableCode = new DATableCode();
                    //entity.REQUESTEDTYPEID = daTableCode.GetTableId(sqlHelper, "REQUESTEDTYPEID", "SIMREG_REQUESTEDTYPE");

                    sql = sqlHelper.MakeSQL(@"INSERT INTO SIMREG_REQUESTEDTYPE(REQUESTEDTYPEID, TITLE, IDATE, IUSER, EDATE, EUSER)"
                                            + " VALUES(SQ_SIMREG_REQUESTEDTYPEID.Nextval, $s, SYSDATE, $n, SYSDATE, $n)",
                                            //entity.REQUESTEDTYPEID,
                                            entity.TITLE,
                                            //entity.IDATE,
                                            entity.IUSER,
                                            //entity.EDATE,
                                            entity.EUSER);
                }
                else
                {
                    sql = sqlHelper.MakeSQL(@"UPDATE SIMREG_REQUESTEDTYPE SET TITLE=$s, EDATE=SYSDATE, EUSER=$n WHERE REQUESTEDTYPEID=$n",
                                            entity.TITLE,
                                            //entity.EDATE,
                                            entity.EUSER,
                                            entity.REQUESTEDTYPEID);
                }

                sqlHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BESIMREG_REQUESTEDTYPE GetSIMREG_REQUESTEDTYPE(SQLHelper sqlHelper, int SIMREG_REQUESTEDTYPEId)
        {
            string sql = string.Empty;
            BESIMREG_REQUESTEDTYPEs SIMREG_REQUESTEDTYPEs = new BESIMREG_REQUESTEDTYPEs();
            try
            {
                sql = sqlHelper.MakeSQL(@"SELECT * FROM SIMREG_REQUESTEDTYPE WHERE REQUESTEDTYPEID=$n ORDER BY REQUESTEDTYPEID", SIMREG_REQUESTEDTYPEId);
                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToSIMREG_REQUESTEDTYPECollection(SIMREG_REQUESTEDTYPEs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (SIMREG_REQUESTEDTYPEs.Count > 0)
                return SIMREG_REQUESTEDTYPEs[0];
            else return new BESIMREG_REQUESTEDTYPE();
        }

        public BESIMREG_REQUESTEDTYPEs GetSIMREG_REQUESTEDTYPEs(SQLHelper sqlHelper)
        {
            string sql = string.Empty;
            BESIMREG_REQUESTEDTYPEs SIMREG_REQUESTEDTYPEs = new BESIMREG_REQUESTEDTYPEs();
            try
            {
                sql = sqlHelper.MakeSQL(@"SELECT * FROM SIMREG_REQUESTEDTYPE ORDER BY REQUESTEDTYPEID");

                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToSIMREG_REQUESTEDTYPECollection(SIMREG_REQUESTEDTYPEs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return SIMREG_REQUESTEDTYPEs;
        }

        private BESIMREG_REQUESTEDTYPEs AddToSIMREG_REQUESTEDTYPECollection(BESIMREG_REQUESTEDTYPEs SIMREG_REQUESTEDTYPEs, IDataReader reader)
        {
            NULLHandler nullHandler = new NULLHandler(reader);
            while (reader.Read())
            {
                SIMREG_REQUESTEDTYPEs.Add(PreaperSIMREG_REQUESTEDTYPEObject(nullHandler));
            }
            return SIMREG_REQUESTEDTYPEs;
        }

        private BESIMREG_REQUESTEDTYPE PreaperSIMREG_REQUESTEDTYPEObject(NULLHandler nullHandler)
        {
            BESIMREG_REQUESTEDTYPE SIMREG_REQUESTEDTYPE = new BESIMREG_REQUESTEDTYPE();

            SIMREG_REQUESTEDTYPE.IsNew = false;
            SIMREG_REQUESTEDTYPE.REQUESTEDTYPEID = nullHandler.GetInt("REQUESTEDTYPEID");
            SIMREG_REQUESTEDTYPE.TITLE = nullHandler.GetString("TITLE");

            SIMREG_REQUESTEDTYPE.IDATE = nullHandler.GetDateTime("IDATE");
            SIMREG_REQUESTEDTYPE.IUSER = nullHandler.GetInt("IUSER");
            SIMREG_REQUESTEDTYPE.EDATE = nullHandler.GetDateTime("EDATE");
            SIMREG_REQUESTEDTYPE.EUSER = nullHandler.GetInt("EUSER");

            return SIMREG_REQUESTEDTYPE;
        }

        public void Delete(SQLHelper sqlHelper, int ID)
        {
            string sql = string.Empty;
            try
            {
                sql = sqlHelper.MakeSQL(@"DELETE SIMREG_REQUESTEDTYPE WHERE REQUESTEDTYPEID=$n", ID);
                sqlHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
