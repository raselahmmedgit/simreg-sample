using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using RnD.BLTemp.BusinessEntity;
using SQLFactory;
using System.Data.OracleClient;
using System.Collections;

namespace RnD.BLTemp.DataAccess
{
    public class DBUtility
    {
        public static DateTime DBNullDateTime
        {
            get
            {
                return (DateTime)OracleDateTime.Null;
            }
        }

        public static DateTime GetOracleDateTime(DateTime dt)
        {
            return dt == DateTime.MinValue ? DBNullDateTime : dt;
        }

        public static string GetPagingSQL(string sql, int startIndex, int endIndex)
        {
            sql = "SELECT * FROM (SELECT ROWNUM AS ROWINDEX,T.* FROM (" + sql + ") T) WHERE ROWINDEX BETWEEN " + startIndex + " AND " + endIndex;
            return sql;
        }

        public static Int32 GetSequenceNextValue(SQLHelper sqlHelper, string seqName)
        {
            string sql = string.Empty;
            try
            {
                sql = "SELECT " + seqName + ".NEXTVAL FROM dual";
                return Convert.ToInt32(sqlHelper.ExecuteScalar(sql));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static BEBase MapItem(BEBase obj, IDataReader reader)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (ReaderContainsColumn(reader, property.Name))
                {
                    if (property.PropertyType == typeof(System.String))
                    {
                        property.SetValue(obj, reader[property.Name] == DBNull.Value ? "" : Convert.ToString(reader[property.Name]), null);
                    }
                    else if (property.PropertyType == typeof(System.Int32))
                    {
                        property.SetValue(obj, reader[property.Name] == DBNull.Value ? 0 : Convert.ToInt32(reader[property.Name]), null);
                    }
                    else if (property.PropertyType == typeof(System.Int64))
                    {
                        property.SetValue(obj, reader[property.Name] == DBNull.Value ? 0 : Convert.ToInt64(reader[property.Name]), null);
                    }
                    else if (property.PropertyType == typeof(System.Double))
                    {
                        property.SetValue(obj, reader[property.Name] == DBNull.Value ? 0 : Convert.ToDouble(reader[property.Name]), null);
                    }
                    else if (property.PropertyType == typeof(System.Decimal))
                    {
                        property.SetValue(obj, reader[property.Name] == DBNull.Value ? 0 : Convert.ToDecimal(reader[property.Name]), null);
                    }
                    else if (property.PropertyType == typeof(System.Boolean))
                    {
                        property.SetValue(obj, reader[property.Name] == DBNull.Value ? false : Convert.ToBoolean(reader[property.Name]), null);
                    }
                    else if (property.PropertyType == typeof(System.DateTime))
                    {
                        property.SetValue(obj, reader[property.Name] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader[property.Name]), null);
                    }
                    else if (property.PropertyType.ToString().Contains("Enum"))
                    {
                        property.SetValue(obj, reader[property.Name] == DBNull.Value ? 0 : Convert.ToInt32(reader[property.Name]), null);
                    }
                }
            }
            obj.IsNew = false;
            return obj;
        }

        private static bool ReaderContainsColumn(IDataReader reader, string name)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(name, StringComparison.CurrentCultureIgnoreCase)) return true;
            }
            return false;
        }
    }
}
