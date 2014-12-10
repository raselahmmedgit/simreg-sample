using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLFactory;
using RnD.BLTemp.DataAccess;
using System.Data;
using RnD.BLTemp.BusinessEntity;

namespace RnD.BLTemp.BusinessObject
{
    public class BOCategory
    {
        SQLHelper sqlHelper = null;
        DACategory daCategory = new DACategory();

        public void Save(BECategory Category)
        {
            try
            {
                sqlHelper = new SQLHelper(true);
                daCategory.Save(sqlHelper, Category);
                sqlHelper.CommitTran();
            }
            catch (Exception ex)
            {
                RnD.BLTemp.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public void Delete(BECategory Category)
        {
            try
            {
                int CategoryId = Category.CategoryId;
                sqlHelper = new SQLHelper(true);
                daCategory.Delete(sqlHelper, CategoryId);
                sqlHelper.CommitTran();
            }
            catch (Exception ex)
            {
                RnD.BLTemp.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BECategorys GetCategorys()
        {
            return GetCategorys(0, 0, string.Empty);
        }

        public BECategorys GetCategorys(int startIndex, int maxRows)
        {
            try
            {
                BECategorys categorys = null;
                sqlHelper = new SQLHelper();
                categorys = daCategory.GetCategorys(sqlHelper, startIndex, maxRows);
                sqlHelper.CommitTran();
                return categorys;
            }
            catch (Exception ex)
            {
                RnD.BLTemp.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public BECategorys GetCategorys(int startIndex, int maxRows, string categoryName)
        {
            try
            {
                BECategorys categorys = null;
                sqlHelper = new SQLHelper();
                categorys = daCategory.GetCategorys(sqlHelper, startIndex, maxRows, categoryName);
                sqlHelper.CommitTran();
                return categorys;
            }
            catch (Exception ex)
            {
                RnD.BLTemp.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public int GetCategorysCount(int totalRow, string categoryName)
        {
            try
            {
                if (totalRow <= 0)
                {
                    sqlHelper = new SQLHelper();
                    totalRow = daCategory.GetCategorysCount(sqlHelper, categoryName);
                    sqlHelper.CommitTran();
                }
                else
                {
                    return totalRow;
                }
            }
            catch (Exception ex)
            {
                RnD.BLTemp.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
            return totalRow;
        }

        public BECategory GetCategory(int CategoryId)
        {
            try
            {
                BECategory category = null;
                sqlHelper = new SQLHelper();
                category = daCategory.GetCategory(sqlHelper, CategoryId);
                sqlHelper.CommitTran();
                return category;
            }
            catch (Exception ex)
            {
                RnD.BLTemp.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
                throw ex;
            }
        }

        public int DataCount()
        {
            int totalRow = 0;

            try
            {
                sqlHelper = new SQLHelper();
                totalRow = daCategory.DataCount(sqlHelper);
                sqlHelper.CommitTran();
            }
            catch (Exception ex)
            {
                RnD.BLTemp.Common.Utility.SaveErrorLog(this.GetType().ToString(), "", ex);
                if (sqlHelper != null) sqlHelper.Rollback();
            }
            finally
            {
                sqlHelper = null;
            }

            return totalRow;
        }
    }
}
