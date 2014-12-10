using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.OracleClient;
using System.Data;

namespace SIMREG.Data
{
    public class OracleProcedure
    {
        private string procedureName;

        public string ProcedureName
        {
            get { return procedureName; }
            set { procedureName = value; }
        }

        private ArrayList parameterList = new ArrayList();

        public OracleParameter[] ParameterList
        {
            get
            {
                return parameterList.ToArray(typeof(OracleParameter)) as OracleParameter[];
            }
        }

        public string ReturnMessage
        {
            get
            {
                return (parameterList[1] as OracleParameter).Value.ToString();
            }
        }

        public int ErrorCode
        {
            get
            {
                return Convert.ToInt32((parameterList[0] as OracleParameter).Value);
            }
        }

        public OracleProcedure()
        {
            OracleParameter param = new OracleParameter("po_errorcode", OracleType.Number);
            param.Direction = ParameterDirection.Output;
            parameterList.Add(param);

            param = new OracleParameter("po_errormessage", OracleType.VarChar, 200);
            param.Direction = ParameterDirection.Output;
            parameterList.Add(param);

            param = new OracleParameter("po_cursor", OracleType.Cursor);
            param.Direction = ParameterDirection.Output;
            parameterList.Add(param);

        }

        public OracleProcedure(string strSchemaName, string procedureName)
        {
            this.procedureName = strSchemaName + procedureName;
            OracleParameter param = new OracleParameter("po_errorcode", OracleType.Number);
            param.Direction = ParameterDirection.Output;
            parameterList.Add(param);

            param = new OracleParameter("po_errormessage", OracleType.VarChar, 200);
            param.Direction = ParameterDirection.Output;
            parameterList.Add(param);



        }

        public void AddInputParameter(string paramName, object Value, OracleType oracleType)
        {
            OracleParameter param = new OracleParameter(paramName, oracleType);
            if (oracleType == OracleType.DateTime)
            {
                if (Convert.ToDateTime(Value) == DateTime.MinValue)
                    Value = DBNull.Value;

                else if (Convert.ToDateTime(Value) == DateTime.MaxValue)
                    Value = DBNull.Value;
            }
            else if (oracleType == OracleType.Number && paramName.EndsWith("ID") && this.procedureName.ToUpper().Contains(".SAVE_"))
            {
                if (Convert.ToInt32(Value) <= 0)
                {
                    Value = DBNull.Value;
                }
            }
            param.Value = Value;
            parameterList.Add(param);
        }

        public void AddInputParameter(string paramName, object Value, OracleType oracleType, int size)
        {
            OracleParameter param = new OracleParameter(paramName, oracleType, size);
            if (oracleType == OracleType.DateTime)
            {
                if (Convert.ToDateTime(Value) == DateTime.MinValue)
                    Value = DBNull.Value;
            }
            param.Value = Value;
            parameterList.Add(param);
        }

        public void ExecuteNonQuery()
        {
            dllOracle _dllOracle = new dllOracle();
            _dllOracle.ExecuteNonQueryStoredProcedure(this.ProcedureName, this.ParameterList);
        }

        public void ExecuteNonQuery(DBTransaction transaction)
        {
            if (transaction == null)
            {
                ExecuteNonQuery();
            }
            else
            {

                dllOracle _dllOracle = new dllOracle();
                _dllOracle.ExecuteNonQueryStoredProcedure(this.ProcedureName, this.ParameterList, transaction.CurrentTransaction.Connection, transaction.CurrentTransaction);
            }
        }

        public DataTable ExecuteQueryToDataTable()
        {

            OracleParameter param = new OracleParameter("po_cursor", OracleType.Cursor);
            param.Direction = ParameterDirection.Output;
            parameterList.Add(param);


            dllOracle _dllOracle = new dllOracle();
            return _dllOracle.ExecuteStoredProcedureDataTable(this.ProcedureName, this.ParameterList);
        }

        public DataSet GetDataSet(string strSQL)
        {
            try
            {
                dllOracle _dllOracle = new dllOracle();
                return _dllOracle.GetDataSet(strSQL);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDataTable(string strSQL)
        {
            try
            {
                dllOracle _dllOracle = new dllOracle();
                return _dllOracle.GetDataTable(strSQL);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetTableId(string strSQL)
        {
            int intTableId = 0;
            try
            {
                dllOracle _dllOracle = new dllOracle();
                return _dllOracle.GetTableMaxId(strSQL);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Add(string strSQL)
        {
            int intReturn = 0;
            try
            {
                dllOracle _dllOracle = new dllOracle();
                return _dllOracle.AddData(strSQL);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Edit(string strSQL)
        {
            int intReturn = 0;
            try
            {
                dllOracle _dllOracle = new dllOracle();
                return _dllOracle.EditData(strSQL);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Delete(string strSQL)
        {
            int intReturn = 0;
            try
            {
                dllOracle _dllOracle = new dllOracle();
                return _dllOracle.DeleteData(strSQL);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}