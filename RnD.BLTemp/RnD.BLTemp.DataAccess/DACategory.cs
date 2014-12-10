using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLFactory;
using System.Data;
using RnD.BLTemp.BusinessEntity;

namespace RnD.BLTemp.DataAccess
{
    public class DACategory
    {
        public void Save(SQLHelper sqlHelper, BECategory category)
        {
            string sql = string.Empty;
            try
            {
                if (category.IsNew)
                {
                    // update tblTableCode
                    DATableCode daTableCode = new DATableCode();
                    category.Code = daTableCode.UpdateTableCodeAtSave(sqlHelper, "TblCategory");

                    sql = sqlHelper.MakeSQL(@"INSERT INTO TblCategory(CategoryName,Code,CreatedBy,CreatedDate)"
                                            + " VALUES($s,$s,$n, SYSDATE)", category.CategoryName, category.Code, category.CreatedBy);
                }
                else
                {
                    sql = sqlHelper.MakeSQL(@"UPDATE TblCategory SET CategoryName=$s,Code=$s,UpdatedBy=$n,UpdatedDate=SYSDATE WHERE CATEGORYID=$n",
                                            category.CategoryName, category.Code, category.UpdatedBy, category.CategoryId);
                }

                sqlHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BECategory GetCategory(SQLHelper sqlHelper, int categoryId)
        {
            string sql = string.Empty;
            BECategorys categorys = new BECategorys();
            try
            {
                sql = sqlHelper.MakeSQL(@"SELECT * FROM TblCategory WHERE CategoryId =$n ORDER BY Code, CategoryName", categoryId);
                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToCategoryCollection(categorys, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (categorys.Count > 0)
                return categorys[0];
            else return new BECategory();
        }

        public BECategorys GetCategorys(SQLHelper sqlHelper, int startIndex, int maxRows)
        {

            string sql = string.Empty;

            int startRow = (startIndex - 1) * maxRows + 1;
            int endRow = startRow + maxRows - 1;

            BECategorys Categorys = new BECategorys();
            try
            {
                sql = sqlHelper.MakeSQL(@"SELECT * FROM TblCategory WHERE IsDeleted=$b ORDER BY CATEGORYID", false);
                if (maxRows > 0)
                {
                    sql = DBUtility.GetPagingSQL(sql, startRow, endRow);
                }

                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToCategoryCollection(Categorys, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Categorys;
        }

        public BECategorys GetCategorys(SQLHelper sqlHelper, int startIndex, int maxRows, string categoryName)
        {

            string sql = string.Empty;
            string subQuery = string.Empty;
            int startRow = (startIndex - 1) * maxRows + 1;
            int endRow = startIndex + maxRows - 1;

            BECategorys Categorys = new BECategorys();
            try
            {
                subQuery = GetSubQuery(sqlHelper, categoryName);
                sql = sqlHelper.MakeSQL(@"SELECT * FROM TblCategory WHERE IsDeleted=$b $q ORDER BY CATEGORYID", false, subQuery);
                if (maxRows > 0)
                {
                    sql = DBUtility.GetPagingSQL(sql, startRow, endRow);
                }

                IDataReader reader = sqlHelper.ExecuteQuery(sql);
                AddToCategoryCollection(Categorys, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Categorys;
        }

        private string GetSubQuery(SQLHelper sqlHelper, string categoryName)
        {
            string strSubQry = String.Empty;

            if (!string.IsNullOrEmpty(categoryName))
            {
                strSubQry = sqlHelper.MakeSQL(" AND UPPER(CATEGORYNAME) like $s", "%" + categoryName.ToUpper() + "%");
            }

            return strSubQry;
        }

        public int GetCategorysCount(SQLHelper sqlHelper, string categoryName)
        {
            string sql = string.Empty;
            string subQuery = string.Empty;
            BECategorys Categorys = new BECategorys();
            int rowCount = 0;
            try
            {
                subQuery = GetSubQuery(sqlHelper, categoryName);
                sql = sqlHelper.MakeSQL("SELECT COUNT(CATEGORYID) FROM TblCategory WHERE IsDeleted=$b $q", false, subQuery);
                IDataReader reader = sqlHelper.ExecuteQuery(sql);

                if (reader.Read())
                {
                    rowCount = Convert.ToInt32(reader[0].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rowCount;
        }

        private BECategorys AddToCategoryCollection(BECategorys categorys, IDataReader reader)
        {
            NULLHandler nullHandler = new NULLHandler(reader);
            while (reader.Read())
            {
                categorys.Add(PreaperCategoryObject(nullHandler));
            }
            return categorys;
        }

        private BECategory PreaperCategoryObject(NULLHandler nullHandler)
        {
            BECategory category = new BECategory();
            category.IsNew = false;
            category.CategoryName = nullHandler.GetString("CategoryName");
            category.CategoryId = nullHandler.GetInt("CategoryId");
            category.Code = nullHandler.GetString("Code");
            category.CreatedBy = nullHandler.GetInt("CreatedBy");
            category.CreatedDate = nullHandler.GetDateTime("CreatedDate");
            category.UpdatedBy = nullHandler.GetInt("UpdatedBy");
            category.UpdatedDate = nullHandler.GetDateTime("UpdatedDate");
            category.IsDeleted = nullHandler.GetBoolean("IsDeleted");

            return category;
        }

        public void Delete(SQLHelper sqlHelper, int CategoryID)
        {
            string sql = string.Empty;
            try
            {
                sql = sqlHelper.MakeSQL(@"UPDATE TblCategory SET IsDeleted=$b WHERE CategoryId=$n", true, CategoryID);
                sqlHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int DataCount(SQLHelper sqlHelper)
        {
            string sql = string.Empty;
            int rowCount = 0;

            try
            {
                sql = sqlHelper.MakeSQL("SELECT COUNT(CategoryId) FROM TblCategory WHERE IsDeleted=$b", false);
                object obj = sqlHelper.ExecuteScalar(sql);

                rowCount = Convert.ToInt32(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return rowCount;
        }
    }
}
