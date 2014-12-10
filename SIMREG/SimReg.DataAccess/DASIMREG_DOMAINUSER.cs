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
    public class DASIMREG_DOMAINUSER
    {
        public void Save(SQLHelper sqlHelper, BESIMREG_DOMAINUSER entity)
        {
            try
            {
                string sql = string.Empty;

                if (entity.IsNew)
                {
                    sql = sqlHelper.MakeSQL("INSERT INTO tbldomainuser1(userid, loginname, username, IsDeleted, IsActive, CreatedBy,"
                        + " CreatedDate, Serial) VALUES ($n, $s, $s, $b, $b, $n, $D, $n)", entity.userid, entity.loginname,
                         entity.username);

                }
                else
                {
                    sql = sqlHelper.MakeSQL("UPDATE tbldomainuser1 SET userid = $n, loginname = $s, username = $s, UpdatedDate = $D,"
                        + " UpdatedBy = $n"
                        + " WHERE userid=$n", entity.userid, entity.loginname, entity.username, entity.EDATE,
                         entity.EUSER, entity.userid);
                }

                sqlHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BESIMREG_DOMAINUSER GetSIMREG_DOMAINUSER(SQLHelper sqlHelper, int UserId)
        {
            string sql = string.Empty;
            BESIMREG_DOMAINUSERs SIMREG_DOMAINUSERs = new BESIMREG_DOMAINUSERs();

            try
            {
                sql = sqlHelper.MakeSQL("SELECT userid, loginname, username FROM SIMREG_DOMAINUSER WHERE userid=$n", UserId);
                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToCollection(SIMREG_DOMAINUSERs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (SIMREG_DOMAINUSERs.Count > 0)
            {
                return SIMREG_DOMAINUSERs[0];
            }
            else return new BESIMREG_DOMAINUSER();
        }

        public BESIMREG_DOMAINUSER GetSIMREG_DOMAINUSER(SQLHelper sqlHelper, string UserName)
        {
            string sql = string.Empty;
            BESIMREG_DOMAINUSERs SIMREG_DOMAINUSERs = new BESIMREG_DOMAINUSERs();

            try
            {
                sql = sqlHelper.MakeSQL("SELECT * FROM SIMREG_DOMAINUSER WHERE username=$s", UserName);
                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToCollection(SIMREG_DOMAINUSERs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (SIMREG_DOMAINUSERs.Count > 0)
            {
                return SIMREG_DOMAINUSERs[0];
            }
            else return new BESIMREG_DOMAINUSER();
        }

        public BESIMREG_DELIVEREDBY GetSIMREG_DOMAINUSERbyDELIVER(SQLHelper sqlHelper, string UserName)
        {
            string sql = string.Empty;
            BESIMREG_DELIVEREDBYs SIMREG_DELIVEREDBYs = new BESIMREG_DELIVEREDBYs();

            try
            {
                sql = sqlHelper.MakeSQL("SELECT * FROM SIMREG_DELIVEREDBY WHERE username=$s", UserName);
                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToSIMREG_DELIVEREDBYCollection(SIMREG_DELIVEREDBYs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (SIMREG_DELIVEREDBYs.Count > 0)
            {
                return SIMREG_DELIVEREDBYs[0];
            }
            else return new BESIMREG_DELIVEREDBY();
        }

        public BESIMREG_DOMAINUSERs GetSIMREG_DOMAINUSERs(SQLHelper sqlHelper)
        {
            string sql = string.Empty;
            BESIMREG_DOMAINUSERs SIMREG_DOMAINUSERs = new BESIMREG_DOMAINUSERs();

            try
            {
                sql = sqlHelper.MakeSQL("SELECT userid, loginname, username FROM SIMREG_DOMAINUSER WHERE IsDeleted=$b", false);
                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToCollection(SIMREG_DOMAINUSERs, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return SIMREG_DOMAINUSERs;
        }

        private BESIMREG_DOMAINUSERs AddToCollection(BESIMREG_DOMAINUSERs SIMREG_DOMAINUSERs, IDataReader reader)
        {
            try
            {
                NULLHandler nullHandler = new NULLHandler(reader);
                while (reader.Read())
                {
                    SIMREG_DOMAINUSERs.Add(PreaperObject(nullHandler));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return SIMREG_DOMAINUSERs;
        }

        private BESIMREG_DOMAINUSER PreaperObject(NULLHandler nullHandler)
        {
            BESIMREG_DOMAINUSER SIMREG_DOMAINUSER = new BESIMREG_DOMAINUSER();

            try
            {
                SIMREG_DOMAINUSER.IsNew = false;
                SIMREG_DOMAINUSER.userid = nullHandler.GetInt("userid");
                SIMREG_DOMAINUSER.loginname = nullHandler.GetString("loginname");
                SIMREG_DOMAINUSER.username = nullHandler.GetString("username");
                SIMREG_DOMAINUSER.IsDeleted = nullHandler.GetBoolean("IsDeleted");
                SIMREG_DOMAINUSER.IsActive = nullHandler.GetBoolean("IsActive");
                SIMREG_DOMAINUSER.IDATE = nullHandler.GetDateTime("IDATE");
                SIMREG_DOMAINUSER.IUSER = nullHandler.GetInt("IUSER");
                SIMREG_DOMAINUSER.EDATE = nullHandler.GetDateTime("EDATE");
                SIMREG_DOMAINUSER.EUSER = nullHandler.GetInt("EUSER");
                SIMREG_DOMAINUSER.DeletedBy = nullHandler.GetInt("DeletedBy");
                SIMREG_DOMAINUSER.DeletedDate = nullHandler.GetDateTime("DeletedDate");
                SIMREG_DOMAINUSER.Serial = nullHandler.GetInt("Serial");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return SIMREG_DOMAINUSER;
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

    }

}
