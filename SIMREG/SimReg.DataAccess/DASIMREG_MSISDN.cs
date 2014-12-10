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
    public class DASIMREG_MSISDN
    {
        public void Save(SQLHelper sqlHelper, BESIMREG_MSISDN entity)
        {
            string sql = string.Empty;
            try
            {
                if (entity.IsNew)
                {
                    // update tblTableCode
                    DATableCode daTableCode = new DATableCode();
                    //entity.MSISDNID = daTableCode.GetTableId(sqlHelper, "MSISDNID", "SIMREG_MSISDN");

                    sql = sqlHelper.MakeSQL(@"INSERT INTO SIMREG_MSISDN(MSISDNID, TITLE, IDATE, IUSER, EDATE, EUSER)"
                                            + " VALUES(SQ_SIMREG_MSISDNID.Nextval, $s, SYSDATE, $n, SYSDATE, $n)",
                                            //entity.MSISDNID,
                                            entity.TITLE,
                                            //entity.IDATE,
                                            entity.IUSER,
                                            //entity.EDATE,
                                            entity.EUSER);
                }
                else
                {
                    sql = sqlHelper.MakeSQL(@"UPDATE SIMREG_MSISDN SET TITLE=$s, EDATE=SYSDATE, EUSER=$n WHERE MSISDNID=$n",
                                            entity.TITLE,
                                            //entity.EDATE,
                                            entity.EUSER,
                                            entity.MSISDNID);
                }

                sqlHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BESIMREG_MSISDN GetSIMREG_MSISDN(SQLHelper sqlHelper, int SIMREG_MSISDNId)
        {
            string sql = string.Empty;
            BESIMREG_MSISDNs SIMREG_MSISDNs = new BESIMREG_MSISDNs();
            try
            {
                sql = sqlHelper.MakeSQL(@"SELECT * FROM SIMREG_MSISDN WHERE MSISDNID=$n ORDER BY MSISDNID", SIMREG_MSISDNId);
                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToSIMREG_MSISDNCollection(SIMREG_MSISDNs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (SIMREG_MSISDNs.Count > 0)
                return SIMREG_MSISDNs[0];
            else return new BESIMREG_MSISDN();
        }

        public BESIMREG_MSISDNs GetSIMREG_MSISDNs(SQLHelper sqlHelper)
        {
            string sql = string.Empty;
            BESIMREG_MSISDNs SIMREG_MSISDNs = new BESIMREG_MSISDNs();
            try
            {
                sql = sqlHelper.MakeSQL(@"SELECT * FROM SIMREG_MSISDN ORDER BY MSISDNID");

                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToSIMREG_MSISDNCollection(SIMREG_MSISDNs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return SIMREG_MSISDNs;
        }

        private BESIMREG_MSISDNs AddToSIMREG_MSISDNCollection(BESIMREG_MSISDNs SIMREG_MSISDNs, IDataReader reader)
        {
            NULLHandler nullHandler = new NULLHandler(reader);
            while (reader.Read())
            {
                SIMREG_MSISDNs.Add(PreaperSIMREG_MSISDNObject(nullHandler));
            }
            return SIMREG_MSISDNs;
        }

        private BESIMREG_MSISDN PreaperSIMREG_MSISDNObject(NULLHandler nullHandler)
        {
            BESIMREG_MSISDN SIMREG_MSISDN = new BESIMREG_MSISDN();

            SIMREG_MSISDN.IsNew = false;
            SIMREG_MSISDN.MSISDNID = nullHandler.GetInt("MSISDNID");
            SIMREG_MSISDN.TITLE = nullHandler.GetString("TITLE");

            SIMREG_MSISDN.IDATE = nullHandler.GetDateTime("IDATE");
            SIMREG_MSISDN.IUSER = nullHandler.GetInt("IUSER");
            SIMREG_MSISDN.EDATE = nullHandler.GetDateTime("EDATE");
            SIMREG_MSISDN.EUSER = nullHandler.GetInt("EUSER");

            return SIMREG_MSISDN;
        }

        public void Delete(SQLHelper sqlHelper, int ID)
        {
            string sql = string.Empty;
            try
            {
                sql = sqlHelper.MakeSQL(@"DELETE SIMREG_MSISDN WHERE MSISDNID=$n", ID);
                sqlHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
