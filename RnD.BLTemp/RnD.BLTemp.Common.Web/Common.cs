using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using RnD.BLTemp.BusinessObject;
using RnD.BLTemp.BusinessEntity;
using System.Net.Mail;
using System.IO;

namespace RnD.BLTemp.Common.Web
{
    public class Common
    {
        public enum PageModeEnum
        {
            ReadOnly = 0,
            Edit = 1,
            Insert = 2,
        }

        static string[] MonthNames = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        public static Label InsertLineBreaks(int breaks)
        {
            Label lblLineBreak = new Label();
            for (int i = 0; i < breaks; i++)
            {
                lblLineBreak.Text += "<br/>";

            }
            return lblLineBreak;
        }

        public static void AddSelectOne(DropDownList ddl)
        {
            ddl.Items.Insert(0, new ListItem("Select One", "0"));
        }

        public static string GetSelectOneText()
        {
            return "Select One";
        }

        public static void AddSelectAll(ListControl ddl)
        {
            ddl.Items.Insert(0, new ListItem("Select All", "0"));
        }

        //public static void PopulateDistrict(ListControl control)
        //{
        //    control.Items.Clear();
        //    BODistrict _BODistrict = new BODistrict();
        //    BEDistricts districts = new BEDistricts();
        //    districts = _BODistrict.GetDistricts(0, 0, 0, String.Empty);
        //    control.DataSource = districts;
        //    control.DataTextField = "DistrictName";
        //    control.DataValueField = "DistrictId";
        //    control.DataBind();
        //}

        //public static void PopulateDataServiceTypeCategory(ListControl control)
        //{
        //    control.Items.Clear();
        //    BEDataServiceTypeCategorys dataServiceTypeCategorys = new BEDataServiceTypeCategorys();

        //    var cat1 = new BEDataServiceTypeCategory() { DataServiceTypeCategoryID = "2G", DataServiceTypeCategoryName = "2G" };
        //    var cat2 = new BEDataServiceTypeCategory() { DataServiceTypeCategoryID = "3G", DataServiceTypeCategoryName = "3G" };

        //    dataServiceTypeCategorys.Add(cat1);
        //    dataServiceTypeCategorys.Add(cat2);

        //    control.DataSource = dataServiceTypeCategorys;
        //    control.DataTextField = "DataServiceTypeCategoryName";
        //    control.DataValueField = "DataServiceTypeCategoryID";
        //    control.DataBind();
        //}

        //public static void PopulateEducationInstitute(ListControl control)
        //{
        //    control.Items.Clear();
        //    BOEducationInstitute boEducationInstitute = new BOEducationInstitute();
        //    control.DataSource = boEducationInstitute.GetEducationInstitutes();
        //    control.DataTextField = "EDUCATIONINSTITUTENAME";
        //    control.DataValueField = "EDUCATIONINSTITUTEID";
        //    control.DataBind();
        //}

        //public static void PopulateProfession(ListControl control)
        //{
        //    control.Items.Clear();
        //    BOProfession boProfession = new BOProfession();
        //    control.DataSource = boProfession.GetProfessions();
        //    control.DataTextField = "ProfessionName";
        //    control.DataValueField = "ProfessionID";
        //    control.DataBind();
        //}

        //public static void PopulateClub(ListControl control)
        //{
        //    control.Items.Clear();
        //    BOClub boClub = new BOClub();
        //    control.DataSource = boClub.GetClubs();
        //    control.DataTextField = "CLUBNAME";
        //    control.DataValueField = "CLUBID";
        //    control.DataBind();
        //}

        //public static void PopulateCategory(ListControl control)
        //{
        //    control.Items.Clear();
        //    BOCategory boCategory = new BOCategory();
        //    control.DataSource = boCategory.GetCategorys();
        //    control.DataTextField = "CategoryName";
        //    control.DataValueField = "CategoryId";
        //    control.DataBind();

        //}

        //public static void PopulateSubCategory(ListControl control, int categoryId)
        //{
        //    control.Items.Clear();
        //    BOSubCategory boSubCategory = new BOSubCategory();
        //    control.DataSource = boSubCategory.GetSubCategorys(0, 0, 0, categoryId, string.Empty);
        //    control.DataTextField = "SubCategoryName";
        //    control.DataValueField = "SubCategoryId";
        //    control.DataBind();
        //}

        //public static BESubCategorys GetSubCategorys(int categoryId)
        //{
        //    BESubCategorys subCats = new BESubCategorys();
        //    if (categoryId > 0)
        //    {
        //        BOSubCategory boSubCategory = new BOSubCategory();
        //        subCats = boSubCategory.GetSubCategorys(0, 0, 0, categoryId, string.Empty);
        //    }
        //    return subCats;
        //}

        //public static void PopulateLookupTable(ListControl control)
        //{
        //    control.Items.Clear();
        //    BOLookupTable _BOLookupTable = new BOLookupTable();
        //    control.DataSource = _BOLookupTable.GetLookupTables(0, 0, 0, string.Empty);
        //    control.DataTextField = "TableName";
        //    control.DataValueField = "TableId";
        //    control.DataBind();
        //}

        //public static void PopulateComplainType(ListControl control)
        //{
        //    control.Items.Clear();
        //    control.DataSource = GetComplainTypes();
        //    control.DataTextField = "COMMONCONFIGNAME";
        //    control.DataValueField = "COMMONCONFIGID";
        //    control.DataBind();
        //}

        //public static void PopulateIconServiceType(ListControl control)
        //{
        //    BOIconServiceType boIconServiceType = new BOIconServiceType();
        //    BEIconServiceTypes serviceTypes = boIconServiceType.GetIconServiceTypes(true);
        //    control.Items.Clear();
        //    control.DataSource = serviceTypes;
        //    control.DataTextField = "IconServiceTypeName";
        //    control.DataValueField = "IconServiceTypeID";
        //    control.DataBind();
        //}

        //public static void PopulateIconServiceName(ListControl control, int parentID)
        //{
        //    BOServiceName boServiceName = new BOServiceName();
        //    BEServiceNames serviceNames = boServiceName.GetServiceNames(parentID);
        //    control.Items.Clear();
        //    control.DataSource = serviceNames;
        //    control.DataTextField = "ServiceName";
        //    control.DataValueField = "ServiceNameID";
        //    control.DataBind();
        //}

        //public static void PopulatePassStatus(ListControl control)
        //{
        //    control.Items.Clear();

        //    foreach (Int32 val in Enum.GetValues(typeof(HVC.Common.Utility.RequisitionPassStatus)))
        //    {
        //        control.Items.Add(new ListItem(Enum.GetName(typeof(HVC.Common.Utility.RequisitionPassStatus), val), val.ToString()));
        //    }

        //    control.DataBind();
        //}

        //public static void PopulateTicketStatus(ListControl control)
        //{
        //    control.Items.Clear();
        //    BOTicketNew boTicket = new BOTicketNew();
        //    BETicketStatuses ticketStatuses = new BETicketStatuses();

        //    ticketStatuses = boTicket.GetTicketStatus();

        //    foreach (BETicketStatus status in ticketStatuses)
        //    {
        //        control.Items.Add(new ListItem(status.TicketStatus, status.TicketStatusId.ToString()));
        //    }
        //    control.DataBind();
        //}

        //public static BELookupTables GetLookupTables()
        //{

        //    BELookupTables LookupTables = new BELookupTables();
        //    BOLookupTable _BOLookupTable = new BOLookupTable();
        //    try
        //    {
        //        LookupTables = _BOLookupTable.GetLookupTables(0, 0, 0, string.Empty);
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return LookupTables;
        //}

        public static BECommonConfigs GetDataTypes()
        {
            string GroupName = "DataType";
            BECommonConfigs ComonConfigs = new BECommonConfigs();
            BOCommonConfig _BOCommonConfig = new BOCommonConfig();
            try
            {
                ComonConfigs = _BOCommonConfig.GetCommonConfigs(GroupName);
            }
            catch (Exception ex)
            {
            }
            return ComonConfigs;
        }

        public static BECommonConfigs GetComplainTypes()
        {
            string GroupName = "ComplainType";
            BECommonConfigs ComonConfigs = new BECommonConfigs();
            BOCommonConfig _BOCommonConfig = new BOCommonConfig();
            try
            {
                ComonConfigs = _BOCommonConfig.GetCommonConfigs(GroupName);
            }
            catch (Exception ex)
            {
            }
            return ComonConfigs;
        }

        public static BECommonConfigs GetLookupColumnNames(string strDataType)
        {
            string GroupName = "LookupColumnName";
            BECommonConfigs ComonConfigs = new BECommonConfigs();
            BOCommonConfig _BOCommonConfig = new BOCommonConfig();
            try
            {
                BECommonConfigs tempConfigs = _BOCommonConfig.GetCommonConfigs(GroupName);

                foreach (BECommonConfig conf in tempConfigs)
                {
                    if (conf.CommonConfigName.ToUpper().StartsWith(strDataType.ToUpper()[0].ToString()))
                    {
                        ComonConfigs.Add(conf);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return ComonConfigs;
        }

        public static BECommonConfigs GetQuestionFor()
        {
            string GroupName = "QuestionFor";
            BECommonConfigs ComonConfigs = new BECommonConfigs();
            BOCommonConfig _BOCommonConfig = new BOCommonConfig();
            try
            {
                ComonConfigs = _BOCommonConfig.GetCommonConfigs(GroupName);
            }
            catch (Exception ex)
            {
            }
            return ComonConfigs;
        }

        public static void PopulateQuestionFor(ListControl control)
        {
            control.Items.Clear();
            control.DataSource = GetQuestionFor();
            control.DataTextField = "CommonConfigName";
            control.DataValueField = "CommonConfigId";
            control.DataBind();
        }

        public static BECommonConfigs GetQuestionTypes()
        {
            string GroupName = "QuestionType";
            BECommonConfigs ComonConfigs = new BECommonConfigs();
            BOCommonConfig _BOCommonConfig = new BOCommonConfig();
            try
            {
                ComonConfigs = _BOCommonConfig.GetCommonConfigs(GroupName);
            }
            catch (Exception ex)
            {
            }
            return ComonConfigs;
        }

        //public static BEThanas GetThanas(int districtID)
        //{
        //    BEThanas thanas = null;
        //    BOThana _BOThana = new BOThana();
        //    try
        //    {
        //        if (districtID > 0)
        //        {
        //            thanas = _BOThana.GetThanas(0, 0, 0, districtID, string.Empty);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    if (thanas == null) thanas = new BEThanas();

        //    return thanas;
        //}

        //public static void PopulateThanabyDistrict(ListControl control, int districtID)
        //{
        //    control.Items.Clear();
        //    control.DataSource = GetThanas(districtID);
        //    control.DataTextField = "ThanaName";
        //    control.DataValueField = "ThanaId";
        //    control.DataBind();
        //}

        //public static BEAreas GetAreas(int districtId, int thanaId)
        //{
        //    BEAreas areas = null;
        //    BOArea _boArea = new BOArea();
        //    try
        //    {
        //        areas = _boArea.GetAreas(0, 0, 0, districtId, thanaId, string.Empty);
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    if (areas == null) areas = new BEAreas();

        //    return areas;
        //}

        /// <summary>
        /// districtId - optional, thanaId - optional
        /// </summary>
        /// <param name="control"></param>
        /// <param name="districtId"></param>
        /// <param name="thanaId"></param>
        //public static void PopulateAreaByDistrictThana(ListControl control, int districtId, int thanaId)
        //{
        //    control.Items.Clear();
        //    control.SelectedIndex = -1; ;
        //    control.ClearSelection();
        //    control.DataSource = null;
        //    control.DataSource = GetAreas(districtId, thanaId);
        //    control.DataTextField = "AreaName";
        //    control.DataValueField = "AreaId";
        //    control.DataBind();
        //}

        //public static void PopulateIconManagersByParent(ListControl control, int parentId)
        //{
        //    control.Items.Clear();
        //    BOIconMngConfig boIconMngConfig = new BOIconMngConfig();
        //    BEIconMngConfigs IconManagers = boIconMngConfig.GetManagersByParent(parentId);
        //    control.DataSource = IconManagers;
        //    control.DataTextField = "UserName";
        //    control.DataValueField = "UserId";
        //    control.DataBind();
        //}

        //public static void PopulateIconManagers(ListControl control)
        //{
        //    control.Items.Clear();
        //    BOIconMngConfig boIconMngConfig = new BOIconMngConfig();
        //    BEIconMngConfigs IconManagers = boIconMngConfig.GetManagers();
        //    control.DataSource = IconManagers;
        //    control.DataTextField = "UserName";
        //    control.DataValueField = "UserId";
        //    control.DataBind();
        //}

        //public static void PopulateIconUsers(ListControl control)
        //{
        //    BOUserGroup boUserGroup = new BOUserGroup();
        //    string iconUserGroupName = ConfigurationManager.AppSettings["IconManagerUserGroup"].ToString();

        //    BEUserGroup userGroup = boUserGroup.GetUserGroup(iconUserGroupName);
        //    BOUser boUser = new BOUser();
        //    BEUsers users = boUser.GetUsers(0, 0, 0, userGroup.UserGroupId, 0, string.Empty, string.Empty);

        //    control.Items.Clear();
        //    control.DataSource = users;
        //    control.DataTextField = "UserName";
        //    control.DataValueField = "UserId";
        //    control.DataBind();
        //}

        //public static string GetSubCategoryByCategoryID(int categoryId)
        //{
        //    string result = "";
        //    if (categoryId > 0)
        //    {
        //        BOSubCategory boSubCategory = new BOSubCategory();
        //        BESubCategorys subCategorys = boSubCategory.GetSubCategorys(0, 0, 0, categoryId, string.Empty);

        //        StringBuilder sbJSON = new StringBuilder();
        //        sbJSON.Append("[");
        //        if (subCategorys.Count > 0)
        //        {
        //            foreach (BESubCategory subCat in subCategorys)
        //            {
        //                sbJSON.Append("{\"" + "SubCategoryId" + "\": ");
        //                sbJSON.Append(subCat.SubCategoryId);
        //                sbJSON.Append(",\"" + "SubCategoryName" + "\": ");
        //                sbJSON.Append("\"" + subCat.SubCategoryName + "\"},");
        //            }
        //            sbJSON.Remove(sbJSON.Length - 1, 1);
        //        }
        //        sbJSON.Append("]");
        //        result = sbJSON.ToString();
        //    }
        //    return result;
        //}

        //public static void PopulateCustomerSegment(ListControl control)
        //{
        //    control.Items.Clear();
        //    BOCustomerSegment boCustomerSegment = new BOCustomerSegment();
        //    control.DataSource = boCustomerSegment.GetCustomerSegments();
        //    control.DataTextField = "SegmentName";
        //    control.DataValueField = "CustomerSegmentId";
        //    control.DataBind();
        //}

        //public static void PopulateCustomerCategory(ListControl control)
        //{
        //    control.Items.Clear();
        //    BOCustomerCategory boCustoemerCategory = new BOCustomerCategory();
        //    control.DataSource = boCustoemerCategory.GetCustomerCategorys();
        //    control.DataTextField = "CategoryName";
        //    control.DataValueField = "CustomerCategoryId";
        //    control.DataBind();
        //}

        //public static void PopulateManagerGroupByManagerId(ListControl control, int managerId)
        //{
        //    control.Items.Clear();
        //    BOIconMngConfig boIconMngConfig = new BOIconMngConfig();
        //    var iconMgr = boIconMngConfig.GetManagerGroupByManagerId(managerId);
        //    control.DataSource = iconMgr.OrderBy(k => k.UserName).ToList();
        //    control.DataTextField = "UserName";
        //    control.DataValueField = "UserId";
        //    control.DataBind();
        //}

        //public static void PopulateManagerGroupByManagerId(ListControl control, int managerId, bool isBackOfficeUser)
        //{
        //    control.Items.Clear();
        //    BOIconMngConfig boIconMngConfig = new BOIconMngConfig();
        //    var iconMgr = boIconMngConfig.GetManagerGroupByManagerId(managerId, isBackOfficeUser);
        //    control.DataSource = iconMgr.OrderBy(k => k.UserName).ToList();
        //    control.DataTextField = "UserName";
        //    control.DataValueField = "UserId";
        //    control.DataBind();
        //}

        //public static void PopulateServiceTopLevelServiceList(ListControl control)
        //{
        //    control.Items.Clear();
        //    BOVasService boVasService = new BOVasService();
        //    control.DataSource = boVasService.PopulateServiceTopLevelServiceList();
        //    control.DataTextField = "Displaytext";
        //    control.DataValueField = "vasserviceid";
        //    control.DataBind();
        //}

        public static void PopulateApplicationType(ListControl control)
        {
            control.Items.Clear();
            control.DataSource = Enum.GetNames(typeof(RnD.BLTemp.Common.Utility.ApplicationTypeEnum));
            control.DataBind();
        }

        public static void PopulateReferenceType(ListControl control)
        {
            control.Items.Clear();

            foreach (RnD.BLTemp.Common.Utility.RequestType r in Enum.GetValues(typeof(RnD.BLTemp.Common.Utility.RequestType)))
            {
                ListItem item = new ListItem(Enum.GetName(typeof(RnD.BLTemp.Common.Utility.RequestType), r), Convert.ToInt32(r).ToString());
                control.Items.Add(item);
            }
            control.DataBind();
        }

        public static void PopulateYearUptoCurrent(ListControl control, int startYear)
        {
            control.Items.Clear();

            for (int i = startYear; i <= DateTime.Now.Year; i++)
            {
                ListItem item = new ListItem(i.ToString(), i.ToString());
                control.Items.Add(item);
            }

            control.DataBind();
        }

        public static void PopulateYearByRange(ListControl control, int startYear, int endYear)
        {
            control.Items.Clear();

            for (int i = endYear; i >= startYear; i--)
            {
                ListItem item = new ListItem(i.ToString(), i.ToString());
                control.Items.Add(item);
            }

            control.DataBind();
        }

        public static void PopulateMonthUptoCurrent(ListControl control, int endMonth)
        {
            control.Items.Clear();

            if (endMonth <= 0)
            {
                int i = 1;
                foreach (string month in MonthNames)
                {
                    ListItem item = new ListItem(month, i.ToString());
                    i++;
                    control.Items.Add(item);
                }
            }
            else
            {
                endMonth = endMonth > 12 ? 12 : endMonth;

                for (int i = 0; i < endMonth; i++)
                {
                    ListItem item = new ListItem(MonthNames[i], (i + 1).ToString());
                    control.Items.Add(item);
                }
            }

            control.DataBind();
        }

        public static void PopulateAllMonths(ListControl control)
        {
            int i = 1;
            foreach (string month in MonthNames)
            {
                ListItem item = new ListItem(month.Substring(0, 3), i.ToString());
                i++;
                control.Items.Add(item);
            }

            control.DataBind();
        }

        public static BECommonConfigs GetGenders()
        {
            string GroupName = "Gender";
            BECommonConfigs ComonConfigs = new BECommonConfigs();
            BOCommonConfig _BOCommonConfig = new BOCommonConfig();
            try
            {
                ComonConfigs = _BOCommonConfig.GetCommonConfigs(GroupName);
            }
            catch (Exception ex)
            {
            }
            return ComonConfigs;
        }

        public static void PopulateGenders(ListControl control)
        {
            control.Items.Clear();
            control.DataSource = GetGenders();
            control.DataTextField = "CommonConfigName";
            control.DataValueField = "CommonConfigId";
            control.DataBind();
        }

        public static BECommonConfigs GetProfessions()
        {
            string GroupName = "Profession";
            BECommonConfigs ComonConfigs = new BECommonConfigs();
            BOCommonConfig _BOCommonConfig = new BOCommonConfig();
            try
            {
                ComonConfigs = _BOCommonConfig.GetCommonConfigs(GroupName);
            }
            catch (Exception ex)
            {
            }
            return ComonConfigs;
        }

        public static void PopulateProfessions(ListControl control)
        {
            control.Items.Clear();
            control.DataSource = GetProfessions();
            control.DataTextField = "CommonConfigName";
            control.DataValueField = "CommonConfigId";
            control.DataBind();
        }

        public static BECommonConfigs GetMaritalStatus()
        {
            string GroupName = "MaritalStatus";
            BECommonConfigs ComonConfigs = new BECommonConfigs();
            BOCommonConfig _BOCommonConfig = new BOCommonConfig();
            try
            {
                ComonConfigs = _BOCommonConfig.GetCommonConfigs(GroupName);
            }
            catch (Exception ex)
            {
            }
            return ComonConfigs;
        }

        public static void PopulateMaritalStatus(ListControl control)
        {
            control.Items.Clear();
            control.DataSource = GetMaritalStatus();
            control.DataTextField = "CommonConfigName";
            control.DataValueField = "CommonConfigId";
            control.DataBind();
        }

        public static BECommonConfigs GetSalutations()
        {
            string GroupName = "Salutation";
            BECommonConfigs ComonConfigs = new BECommonConfigs();
            BOCommonConfig _BOCommonConfig = new BOCommonConfig();
            try
            {
                ComonConfigs = _BOCommonConfig.GetCommonConfigs(GroupName);
            }
            catch (Exception ex)
            {
            }
            return ComonConfigs;
        }

        //public static BETBLTYPEOFSALEs GetTypeOfSales()
        //{
        //    BETBLTYPEOFSALEs beTypeOfSales = new BETBLTYPEOFSALEs();
        //    BOTBLTYPEOFSALE boTypeOfSale = new BOTBLTYPEOFSALE();
        //    try
        //    {
        //        beTypeOfSales = boTypeOfSale.GetTBLTYPEOFSALEs();
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return beTypeOfSales;
        //}

        //public static BETBLPROFILETYPEs GetProfileType()
        //{
        //    BETBLPROFILETYPEs beProfileTypes = new BETBLPROFILETYPEs();
        //    BOTBLPROFILETYPE boProfileType = new BOTBLPROFILETYPE();
        //    try
        //    {
        //        beProfileTypes = boProfileType.GetTBLPROFILETYPEs();
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return beProfileTypes;
        //}

        //public static BETBLICONCATEGORYs GetIconCategory()
        //{
        //    BETBLICONCATEGORYs beiconCategorys = new BETBLICONCATEGORYs();
        //    BOTBLICONCATEGORY boIconCategory = new BOTBLICONCATEGORY();
        //    try
        //    {
        //        beiconCategorys = boIconCategory.GetTBLICONCATEGORYs();
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return beiconCategorys;
        //}

        public static void PopulateSalutations(ListControl control)
        {
            control.Items.Clear();
            control.DataSource = GetSalutations();
            control.DataTextField = "CommonConfigName";
            control.DataValueField = "CommonConfigId";
            control.DataBind();
        }

        //public static void PopulateTypeOfSale(ListControl control)
        //{
        //    control.Items.Clear();
        //    control.DataSource = GetTypeOfSales();
        //    control.DataTextField = "TYPEOFSALE";
        //    control.DataValueField = "TYPEOFSALEID";
        //    control.DataBind();
        //}

        //public static void PopulateProfileType(ListControl control)
        //{
        //    control.Items.Clear();
        //    control.DataSource = GetProfileType();
        //    control.DataTextField = "PROFILETYPE";
        //    control.DataValueField = "PROFILETYPEID";
        //    control.DataBind();
        //}

        //public static void PopulateIconCategory(ListControl control)
        //{
        //    control.Items.Clear();
        //    control.DataSource = GetIconCategory();
        //    control.DataTextField = "ICONCATEGORY";
        //    control.DataValueField = "ICONCATEGORYID";
        //    control.DataBind();
        //}

        public static BECommonConfigs GetPreferedAddress()
        {
            string GroupName = "PreferedAddress";
            BECommonConfigs ComonConfigs = new BECommonConfigs();
            BOCommonConfig _BOCommonConfig = new BOCommonConfig();
            try
            {
                ComonConfigs = _BOCommonConfig.GetCommonConfigs(GroupName);
            }
            catch (Exception ex)
            {
            }
            return ComonConfigs;
        }

        public static void PopulatePreferedAddress(ListControl control)
        {
            control.Items.Clear();
            control.DataSource = GetPreferedAddress();
            control.DataTextField = "CommonConfigName";
            control.DataValueField = "CommonConfigId";
            control.DataBind();
        }

        public static BECommonConfigs GetReligions()
        {
            string GroupName = "Religion";
            BECommonConfigs ComonConfigs = new BECommonConfigs();
            BOCommonConfig _BOCommonConfig = new BOCommonConfig();
            try
            {
                ComonConfigs = _BOCommonConfig.GetCommonConfigs(GroupName);
            }
            catch (Exception ex)
            {
            }
            return ComonConfigs;
        }

        public static void msg(string editMode, int ErrorCode, string PageCaption, Page PageName, Label lblMsg, string ArchiveMsg)
        {
            if (editMode.ToLower() == "edit")
            {
                if (ErrorCode >= 0)
                {
                    ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "refresh", "parent.refreshWindow();", true);
                    ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "close", "parent.tb_remove();", true);
                }
                else
                {
                    lblMsg.Font.Bold = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else if (editMode.ToLower() == "generate")
            {
                if (ErrorCode >= 0)
                {
                    ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "refresh", "parent.refreshWindow();", true);
                    ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "close", "parent.tb_remove();", true);
                }
                else
                {
                    lblMsg.Font.Bold = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else if (editMode.ToLower() == "add")
            {
                if (ErrorCode >= 0)
                {
                    lblMsg.ForeColor = System.Drawing.Color.DarkGreen;
                    lblMsg.Font.Bold = true;
                    ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "refresh", "parent.refreshWindow();", true);
                }
                else
                {
                    lblMsg.Font.Bold = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else if (editMode.ToLower() == "delete")
            {
                if (ErrorCode >= 0)
                {
                    ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "refresh", "parent.refreshWindow();", true);
                    ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "close", "parent.tb_remove();", true);
                }
                else
                {
                    lblMsg.Font.Bold = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else if (editMode.ToLower() == "search")
            {
                ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "refresh", "parent.advanceSearch();", true);
                ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "close", "parent.tb_remove();", true);
            }
            else
            {
                if (ErrorCode == 0)
                {
                    ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "refresh", "parent.refreshWindow();", true);
                    ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "close", "parent.tb_remove();", true);
                }
                else
                {
                    lblMsg.Font.Bold = true;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        public static string getConnectionString()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return connStr;
        }

        public static string getDataSource()
        {
            string connStr = getConnectionString();
            string[] strConn = connStr.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string strConn1 = strConn[0].Substring(12, strConn[0].Length - 12);
            return strConn1;
        }

        public static string getUserID()
        {
            string connStr = getConnectionString();
            string[] strConn = connStr.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] strConn1 = strConn[1].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

            return strConn1[1].Trim();
        }

        public static string getPassword()
        {
            string connStr = getConnectionString();
            string[] strConn = connStr.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] strConn1 = strConn[2].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

            return strConn1[1].Trim();
        }

        public static void SendMail(string toAddr, string subj, string msgBody)
        {
            try
            {
                MailMessage mail = new MailMessage();
                MailAddress toAddress = new MailAddress(toAddr);
                mail.To.Add(toAddress);
                mail.Subject = subj;
                mail.Body = msgBody;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
            }
        }

        public static void PopulateMonthDays(int year, int month, ListControl control)
        {
            control.Items.Clear();

            int numOfDays = DateTime.DaysInMonth(year, month);

            for (int i = 1; i <= numOfDays; i++)
            {
                control.Items.Add(new ListItem(i.ToString("00"), i.ToString()));
            }
            control.DataBind();
        }

        //public static void SaveLog(string msisdn, string message, int adminUserId, string browserInfo, string sessionId)
        //{
        //    try
        //    {
        //        BOAppAuditTrail boAppAuditTrail = new BOAppAuditTrail();
        //        BEAppAuditTrail auditTrail = new BEAppAuditTrail();
        //        auditTrail.BrowseUrl = message;
        //        auditTrail.BrowseDt = DateTime.Now;
        //        auditTrail.Msisdn = msisdn;
        //        auditTrail.UserIpAddress = System.Web.HttpContext.Current.Request.UserHostAddress;
        //        auditTrail.UserID = adminUserId;
        //        auditTrail.BrowserInfo = browserInfo;
        //        auditTrail.SessionId = sessionId;
        //        boAppAuditTrail.Save(auditTrail);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static string GetAdvanceSearchString(BEIconPersonalInformationSearch IconSearch)
        //{
        //    string sql = string.Empty;
        //    string subQryIcon = string.Empty;
        //    string subQryIconSpouse = string.Empty;
        //    string subQryIconChildren = string.Empty;
        //    string subQryIconFriend = string.Empty;
        //    string subQryIconIconQuestion = string.Empty;
        //    string subQryMngCode = string.Empty;
        //    string subQryIconUsage = string.Empty;

        //    subQryIcon = GetSubQueryForIcon(IconSearch);
        //    subQryIconSpouse = GetSubQueryForIconSpouse(IconSearch);
        //    subQryIconChildren = GetSubQueryForIconChildren(IconSearch);
        //    subQryIconFriend = GetSubQueryForIconFriend(IconSearch);
        //    subQryIconIconQuestion = GetSubQueryForIconQuestion(IconSearch);
        //    subQryMngCode = GetSubQryMngCode(IconSearch);
        //    subQryIconUsage = GetSubQryIconUsage(IconSearch);

        //    sql = HVC.Common.Utility.MakeSQL(@"SELECT DISTINCT I_T.IconId FROM TBLICONPERSONALINFORMATION I_T ");
        //    sql += HVC.Common.Utility.MakeSQL(@" INNER JOIN TBLICONMNGCONFIG MNG_T ON MNG_T.USERID=I_T.ICONMANAGERID AND MNG_T.ISDELETED = 0 $q", subQryMngCode);
        //    sql += HVC.Common.Utility.MakeSQL(@" INNER JOIN TblUserInfo U_T ON U_T.USERID= I_T.ICONMANAGERID AND U_T.ISDELETED = 0");

        //    if (!string.IsNullOrEmpty(subQryIconSpouse))
        //    {
        //        sql += HVC.Common.Utility.MakeSQL(@" INNER JOIN TBLICONSPOUSE SP_T ON SP_T.ICONID = I_T.ICONID AND SP_T.ISDELETED = $b $q", false, subQryIconSpouse);
        //    }

        //    if (!string.IsNullOrEmpty(subQryIconChildren))
        //    {
        //        sql += HVC.Common.Utility.MakeSQL(@" INNER JOIN TBLICONCHILDREN CH_T ON CH_T.ICONID = I_T.ICONID AND CH_T.ISDELETED = $b $q", false, subQryIconChildren);
        //    }

        //    if (!string.IsNullOrEmpty(subQryIconFriend))
        //    {
        //        sql += HVC.Common.Utility.MakeSQL(@" INNER JOIN TBLICONFRIEND FR_T ON FR_T.ICONID = I_T.ICONID AND FR_T.ISDELETED = $b $q", false, subQryIconFriend);
        //    }
        //    if (!string.IsNullOrEmpty(subQryIconIconQuestion))
        //    {
        //        sql += HVC.Common.Utility.MakeSQL(@" INNER JOIN TBLICONINFORMATIONANSWER ANS_T ON ANS_T.ICONID = I_T.ICONID $q", subQryIconIconQuestion);
        //    }
        //    if (!string.IsNullOrEmpty(subQryIconUsage))
        //    {
        //        sql += HVC.Common.Utility.MakeSQL(@" ILEFT JOIN TBLICONUSAGE IU_T ON IU_T.ICONID = I_T.ICONID $q", subQryIconUsage);
        //    }

        //    sql += HVC.Common.Utility.MakeSQL(@" Where I_T.IsDeleted=$b  $q", false, subQryIcon);
        //    return sql;
        //}

        //private static string GetSubQueryForIcon(BEIconPersonalInformationSearch IconSearch)
        //{
        //    string strSubQry = string.Empty;

        //    if (!string.IsNullOrEmpty(IconSearch.MSISDN))
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.MSISDN = $s", IconSearch.MSISDN);
        //    }
        //    if (!string.IsNullOrEmpty(IconSearch.PrevMSISDN))
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.PREVMSISDN = $s", IconSearch.PrevMSISDN);
        //    }
        //    if (IconSearch.Salutation > 0)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.SALUTATION = $n", IconSearch.Salutation);
        //    }
        //    if (!string.IsNullOrEmpty(IconSearch.IconFullName))
        //    {
        //        if (IconSearch.IsLikeFullName)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.FIRSTNAME ||' ' || I_T.MIDDLENAME ||' ' || I_T.LASTNAME LIKE $s", "%" + IconSearch.IconFullName + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.FIRSTNAME ||' ' || I_T.MIDDLENAME ||' ' || I_T.LASTNAME = $s", IconSearch.IconFullName);
        //        }
        //    }

        //    if (!string.IsNullOrEmpty(IconSearch.FirstName))
        //    {
        //        if (IconSearch.IsLikeFirstName)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.FIRSTNAME LIKE $s", "%" + IconSearch.FirstName + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.FIRSTNAME = $s", IconSearch.FirstName);
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(IconSearch.MiddleName))
        //    {
        //        if (IconSearch.IsLikeMiddleName)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.MiddleName LIKE $s", "%" + IconSearch.MiddleName + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.MiddleName = $s", IconSearch.MiddleName);
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(IconSearch.LastName))
        //    {
        //        if (IconSearch.IsLikeLastName)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.LastName LIKE $s", "%" + IconSearch.LastName + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.LastName = $s", IconSearch.LastName);
        //        }
        //    }
        //    if (IconSearch.DOB != DateTime.MinValue)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" and TO_DATE(I_T.DOB) = $d", IconSearch.DOB);
        //    }
        //    if (IconSearch.Gender > 0)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.GENDER = $n", IconSearch.Gender);
        //    }
        //    if (!string.IsNullOrEmpty(IconSearch.Nationality1))
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.NATIONALITY1 = $s", IconSearch.Nationality1);
        //    }
        //    if (!string.IsNullOrEmpty(IconSearch.Nationality2))
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.NATIONALITY2 = $s", IconSearch.Nationality2);
        //    }
        //    if (IconSearch.ActivationDateForm != DateTime.MinValue)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" and TO_DATE(I_T.ACTIVATIONDATE) >= $d", IconSearch.ActivationDateForm);
        //    }
        //    if (IconSearch.ActivationDateTo != DateTime.MinValue)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" and TO_DATE(I_T.ACTIVATIONDATE) <= $d", IconSearch.ActivationDateTo);
        //    }
        //    if (!string.IsNullOrEmpty(IconSearch.PresentAddress))
        //    {
        //        if (IconSearch.IsLikePresentAddress)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.PRESENTADDRESS LIKE $s", "%" + IconSearch.PresentAddress + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.PRESENTADDRESS = $s", IconSearch.PresentAddress);
        //        }
        //    }

        //    if (!string.IsNullOrEmpty(IconSearch.PermanentAddress))
        //    {
        //        if (IconSearch.IsLikePermanentAddress)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.PERMANENTADDRESS LIKE $s", "%" + IconSearch.PermanentAddress + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.PERMANENTADDRESS = $s", IconSearch.PermanentAddress);
        //        }
        //    }


        //    if (!string.IsNullOrEmpty(IconSearch.OfficeAddress))
        //    {
        //        if (IconSearch.IsLikeOfficeAddress)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.OFFICEADDRESS LIKE $s", "%" + IconSearch.OfficeAddress + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.OFFICEADDRESS = $s", IconSearch.OfficeAddress);
        //        }
        //    }
        //    if (IconSearch.PresentDistrict > 0)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.PRESENTDISTRICT = $n", IconSearch.PresentDistrict);
        //    }
        //    if (IconSearch.PermanentDistrict > 0)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.PERMANENTDISTRICT = $n", IconSearch.PermanentDistrict);
        //    }
        //    if (IconSearch.OfficeDistrict > 0)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.OFFICEDISTRICT = $n", IconSearch.OfficeDistrict);
        //    }
        //    if (IconSearch.PresentThana > 0)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.PRESENTThana = $n", IconSearch.PresentThana);
        //    }
        //    if (IconSearch.PermanentThana > 0)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.PERMANENTThana = $n", IconSearch.PermanentThana);
        //    }
        //    if (IconSearch.OfficeThana > 0)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.OFFICEThana = $n", IconSearch.OfficeThana);
        //    }

        //    if (IconSearch.PreferredMailingAddress > 0)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.PREFERREDMAILINGADDRESS = $n", IconSearch.PreferredMailingAddress);
        //    }

        //    if (!string.IsNullOrEmpty(IconSearch.EmailAddress))
        //    {
        //        if (IconSearch.IsLikeEmail)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.EMAILADDRESS LIKE $s", "%" + IconSearch.EmailAddress + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.EMAILADDRESS = $s", IconSearch.EmailAddress);
        //        }
        //    }

        //    if (!string.IsNullOrEmpty(IconSearch.AlternateContactno))
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" and I_T.AlternateContactno = $s", IconSearch.AlternateContactno);
        //    }

        //    if (!string.IsNullOrEmpty(IconSearch.Education))
        //    {
        //        if (IconSearch.IsLikeEducation)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.Education LIKE $s", "%" + IconSearch.Education + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.Education = $s", IconSearch.Education);
        //        }
        //    }

        //    if (IconSearch.IsActiveForSearch.HasValue)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" and I_T.isActive = $b", IconSearch.IsActiveForSearch.Value);
        //    }

        //    if (IconSearch.NumOfDays > 0)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.ACTIVATIONDATE >= (SYSDATE-$n)", IconSearch.NumOfDays);
        //    }

        //    if (IconSearch.MaritalStatus > 0)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND I_T.MARITALSTATUS = $n", IconSearch.MaritalStatus);
        //    }
        //    if (IconSearch.MarriageAnniversary != null && IconSearch.MarriageAnniversary != DateTime.MinValue)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND TO_DATE(I_T.MARRIAGEANNIVERSARY) = $d", IconSearch.MarriageAnniversary);
        //    }

        //    if (IconSearch.TypeOfSaleID > 0)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" and I_T.TypeOfSaleID = $n", IconSearch.TypeOfSaleID);
        //    }

        //    if (IconSearch.ProfileTypeID > 0)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" and I_T.ProfileTypeID = $n", IconSearch.ProfileTypeID);
        //    }

        //    if (IconSearch.IconCategoryID > 0)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" and I_T.IconCategoryID = $n", IconSearch.IconCategoryID);
        //    }


        //    return strSubQry;
        //}

        //private static string GetSubQueryForIconSpouse(BEIconPersonalInformationSearch IconSearch)
        //{
        //    string strSubQry = string.Empty;

        //    if (!string.IsNullOrEmpty(IconSearch.SpouseFullName))
        //    {
        //        if (IconSearch.IsLikeSpouseFullName)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND SP_T.FIRSTNAME || ' ' || SP_T.MiddleName || ' ' || SP_T.LastName LIKE $s", "%" + IconSearch.SpouseFullName + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND SP_T.FIRSTNAME || ' ' || SP_T.MiddleName || ' ' || SP_T.LastName = $s", IconSearch.SpouseFullName);
        //        }
        //    }

        //    if (!string.IsNullOrEmpty(IconSearch.SpouseFirstName))
        //    {
        //        if (IconSearch.IsLikeSpouseFirstName)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND SP_T.FIRSTNAME LIKE $s", "%" + IconSearch.SpouseFirstName + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND SP_T.FIRSTNAME = $s", IconSearch.SpouseFirstName);
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(IconSearch.SpouseMiddleName))
        //    {
        //        if (IconSearch.IsLikeSpouseMiddleName)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND SP_T.MiddleName LIKE $s", "%" + IconSearch.SpouseMiddleName + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND SP_T.MiddleName = $s", IconSearch.SpouseMiddleName);
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(IconSearch.SpouseLastName))
        //    {
        //        if (IconSearch.IsLikeSpouseLastName)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND SP_T.LastName LIKE $s", "%" + IconSearch.SpouseLastName + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND SP_T.LastName = $s", IconSearch.SpouseLastName);
        //        }
        //    }
        //    if (IconSearch.SpouseDOB != DateTime.MinValue)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" and TO_DATE(SP_T.DOB) = $d", IconSearch.SpouseDOB);
        //    }

        //    if (IconSearch.SpouseProfession > 0)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND SP_T.PROFESSION = $n", IconSearch.SpouseProfession);
        //    }

        //    if (!string.IsNullOrEmpty(IconSearch.SpouseContactNo))
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND SP_T.CONTACTNO = $s", IconSearch.SpouseContactNo);
        //    }


        //    return strSubQry;
        //}

        //private static string GetSubQueryForIconChildren(BEIconPersonalInformationSearch IconSearch)
        //{
        //    string strSubQry = string.Empty;

        //    if (!string.IsNullOrEmpty(IconSearch.ChildrenFullName))
        //    {
        //        if (IconSearch.IsLikeChildrenFullName)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND CH_T.FIRSTNAME || ' ' || CH_T.MiddleName || ' ' || CH_T.LastName LIKE $s", "%" + IconSearch.ChildrenFullName + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND CH_T.FIRSTNAME || ' ' || CH_T.MiddleName || ' ' || CH_T.LastName = $s", IconSearch.ChildrenFullName);
        //        }
        //    }

        //    if (!string.IsNullOrEmpty(IconSearch.ChildrenFirstName))
        //    {
        //        if (IconSearch.IsLikeChildrenFirstName)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND CH_T.FIRSTNAME LIKE $s", "%" + IconSearch.ChildrenFirstName + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND CH_T.FIRSTNAME = $s", IconSearch.ChildrenFirstName);
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(IconSearch.ChildrenMiddleName))
        //    {
        //        if (IconSearch.IsLikeChildrenMiddleName)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND CH_T.MiddleName LIKE $s", "%" + IconSearch.ChildrenMiddleName + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND CH_T.MiddleName = $s", IconSearch.ChildrenMiddleName);
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(IconSearch.ChildrenLastName))
        //    {
        //        if (IconSearch.IsLikeChildrenLastName)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND CH_T.LastName LIKE $s", "%" + IconSearch.ChildrenLastName + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND CH_T.LastName = $s", IconSearch.ChildrenLastName);
        //        }
        //    }
        //    if (IconSearch.ChildrenDOB != DateTime.MinValue)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" and TO_DATE(CH_T.DOB) = $d", IconSearch.ChildrenDOB);
        //    }

        //    if (IconSearch.ChildrenProfession > 0)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND CH_T.PROFESSION = $n", IconSearch.ChildrenProfession);
        //    }

        //    if (!string.IsNullOrEmpty(IconSearch.ChildrenContactNo))
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND CH_T.CONTACTNO = $s", IconSearch.ChildrenContactNo);
        //    }


        //    return strSubQry;
        //}

        //private static string GetSubQueryForIconFriend(BEIconPersonalInformationSearch IconSearch)
        //{
        //    string strSubQry = string.Empty;

        //    if (!string.IsNullOrEmpty(IconSearch.FriendFullName))
        //    {
        //        if (IconSearch.IsLikeFriendFullName)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND FR_T.FIRSTNAME || ' ' || FR_T.MiddleName || ' ' || FR_T.LastName LIKE $s", "%" + IconSearch.FriendFullName + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND FR_T.FIRSTNAME || ' ' || FR_T.MiddleName || ' ' || FR_T.LastName = $s", IconSearch.FriendFullName);
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(IconSearch.FriendFirstName))
        //    {
        //        if (IconSearch.IsLikeFriendFirstName)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND FR_T.FIRSTNAME LIKE $s", "%" + IconSearch.FriendFirstName + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND FR_T.FIRSTNAME = $s", IconSearch.FriendFirstName);
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(IconSearch.FriendMiddleName))
        //    {
        //        if (IconSearch.IsLikeFriendMiddleName)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND FR_T.MiddleName LIKE $s", "%" + IconSearch.FriendMiddleName + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND FR_T.MiddleName = $s", IconSearch.FriendMiddleName);
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(IconSearch.FriendLastName))
        //    {
        //        if (IconSearch.IsLikeFriendLastName)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND FR_T.LastName LIKE $s", "%" + IconSearch.FriendLastName + "%");
        //        }
        //        else
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" AND FR_T.LastName = $s", IconSearch.FriendLastName);
        //        }
        //    }
        //    if (IconSearch.FriendDOB != DateTime.MinValue)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" and TO_DATE(FR_T.DOB) = $d", IconSearch.FriendDOB);
        //    }

        //    if (IconSearch.FriendProfession > 0)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND FR_T.PROFESSION = $n", IconSearch.FriendProfession);
        //    }

        //    if (!string.IsNullOrEmpty(IconSearch.FriendContactNo))
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND FR_T.CONTACTNO = $s", IconSearch.FriendContactNo);
        //    }


        //    return strSubQry;
        //}

        //private static string GetSubQueryForIconQuestion(BEIconPersonalInformationSearch IconSearch)
        //{
        //    string strSubQry = string.Empty;
        //    string tbl = "";
        //    int count = 1;

        //    if (IconSearch.Answers == null)
        //    {
        //        return string.Empty;
        //    }

        //    foreach (BEAnswer ANS_T in IconSearch.Answers)
        //    {
        //        string joinStmt = string.Empty;
        //        if (string.IsNullOrEmpty(strSubQry))
        //        {
        //            tbl = "ANS_T";
        //            joinStmt = string.Empty;
        //        }
        //        else
        //        {
        //            tbl = "ANS_T" + count.ToString();
        //            count++;

        //            joinStmt = HVC.Common.Utility.MakeSQL(" INNER JOIN TBLICONINFORMATIONANSWER $q ON $q.ICONID=I_T.ICONID ", tbl, tbl);
        //        }

        //        if (!string.IsNullOrEmpty(ANS_T.AnswerText))
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" $q AND ($q.ANSWERTEXT LIKE $s AND $q.QUESTIONID=$n)", joinStmt, tbl, "%" + ANS_T.AnswerText + "%", tbl, ANS_T.QuestionId);
        //        }
        //        else if (ANS_T.AnswerNumeric > 0)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" $q AND ($q.ANSWERNUMERIC = $n AND $q.QUESTIONID=$n)", joinStmt, tbl, ANS_T.AnswerNumeric, tbl, ANS_T.QuestionId);
        //        }
        //        else if (ANS_T.AnswerDate != DateTime.MinValue)
        //        {
        //            strSubQry += HVC.Common.Utility.MakeSQL(" $q AND (TO_DATE($q.ANSWERDATE) = $d AND $q.QUESTIONID=$n)", joinStmt, tbl, ANS_T.AnswerDate, tbl, ANS_T.QuestionId);
        //        }

        //    }

        //    return strSubQry;
        //}

        //private static string GetSubQryMngCode(BEIconPersonalInformationSearch IconSearch)
        //{
        //    string strSubQry = string.Empty;

        //    BEIconMngConfig mngCong = new BEIconMngConfig();
        //    BOIconMngConfig boIconMngConfig = new BOIconMngConfig();

        //    mngCong = boIconMngConfig.GetIconConfigByManagerId(IconSearch.IconManagerId); ;

        //    if (IconSearch.IsOnlyMe == true)
        //    {
        //        strSubQry = HVC.Common.Utility.MakeSQL(" AND MNG_T.CODE = $s", mngCong.Code);
        //    }
        //    else
        //    {
        //        strSubQry = HVC.Common.Utility.MakeSQL(" AND MNG_T.CODE LIKE $s", mngCong.Code + "%");
        //    }

        //    return strSubQry;
        //}

        //private static string GetSubQryIconUsage(BEIconPersonalInformationSearch IconSearch)
        //{
        //    string strSubQry = string.Empty;
        //    if (IconSearch.Usage > 0)
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL("  AND IU_T.AMOUNT >= $n", IconSearch.Usage);
        //    }
        //    return strSubQry;
        //}

        //public static string GetSelectedSearchString(BEIconPersonalInformationSearchLimited IconSearchLimited)
        //{
        //    string strSubQry = string.Empty;

        //    if (!string.IsNullOrEmpty(IconSearchLimited.MSISDN))
        //    {
        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND I.MSISDN = $s", IconSearchLimited.MSISDN);
        //    }

        //    if (!string.IsNullOrEmpty(IconSearchLimited.Address))
        //    {
        //        string address = "%" + IconSearchLimited.Address + "%";

        //        strSubQry += HVC.Common.Utility.MakeSQL(" AND (I.PRESENTADDRESS like $s", address);
        //        strSubQry += HVC.Common.Utility.MakeSQL(" OR I.PERMANENTADDRESS like $s", address);
        //        strSubQry += HVC.Common.Utility.MakeSQL("  OR I.OFFICEADDRESS like  $s )", address);
        //    }

        //    if (IconSearchLimited.DistrictId > 0)
        //    {
        //        int district = IconSearchLimited.DistrictId;

        //        strSubQry += HVC.Common.Utility.MakeSQL("  AND (I.PRESENTDISTRICT = $n", district);
        //        strSubQry += HVC.Common.Utility.MakeSQL("  OR I.PERMANENTDISTRICT = $n", district);
        //        strSubQry += HVC.Common.Utility.MakeSQL("  OR I.OFFICEDISTRICT = $n)", district);
        //    }

        //    if (IconSearchLimited.ThanaId > 0)
        //    {
        //        int thana = IconSearchLimited.ThanaId;

        //        strSubQry += HVC.Common.Utility.MakeSQL("  AND (I.PRESENTTHANA = $n", thana);
        //        strSubQry += HVC.Common.Utility.MakeSQL("  OR I.PERMANENTTHANA = $n", thana);
        //        strSubQry += HVC.Common.Utility.MakeSQL("  OR I.OFFICETHANA = $n)", thana);
        //    }

        //    if (IconSearchLimited.Usage > 0)
        //    {
        //        double usage = IconSearchLimited.Usage;
        //        strSubQry += HVC.Common.Utility.MakeSQL("  AND IU.AMOUNT >= $n", usage);
        //    }

        //    if (IconSearchLimited.DOB != null && IconSearchLimited.DOB != DateTime.MinValue)
        //    {
        //        DateTime dt = IconSearchLimited.DOB;

        //        strSubQry += HVC.Common.Utility.MakeSQL("   AND TO_DATE(I.DOB) = $d", dt);
        //    }

        //    if (IconSearchLimited.IconStatus > 0)
        //    {
        //        int iconStatus = IconSearchLimited.IconStatus;

        //        strSubQry += HVC.Common.Utility.MakeSQL("  AND (I.ISACTIVE = $n)", (IconSearchLimited.IconStatus == 1 ? 1 : 0));
        //    }

        //    return strSubQry;
        //}

        public static string GenerateRandomNo(int length)
        {
            string randomNoGeneratingString = ConfigurationManager.AppSettings["RandomNumberGeneratingString"];
            char[] chars = randomNoGeneratingString.ToCharArray();
            string randomNo = string.Empty;
            Random random = new Random();

            while (randomNo.Length < length)
            {
                int x = random.Next(1, chars.Length);
                if (!randomNo.Contains(chars.GetValue(x).ToString()))
                    randomNo += chars.GetValue(x);
            }

            return randomNo;
        }

        public static bool IsPasswordStringInvalid(string originalPassword)
        {
            bool passwordIsInvalid = false;
            string invalidPasswordCharacters = ConfigurationManager.AppSettings["InvalidPasswordCharacters"];
            char[] chars = invalidPasswordCharacters.ToCharArray();

            foreach (char chr in chars)
            {
                if (originalPassword.Contains(chr))
                {
                    passwordIsInvalid = true;
                    break;
                }
            }

            return passwordIsInvalid;
        }

        public static DataTable ReadExcelSheet(string fileExtension, string mapPath)
        {
            DataTable dtExcelRecords = new DataTable();

            try
            {
                string connectionString = string.Empty;

                if (fileExtension == ".xls")
                {
                    connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mapPath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }
                else if (fileExtension == ".xlsx")
                {
                    connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mapPath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                }

                //Create OleDB Connection and OleDb Command
                OleDbConnection con = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string getExcelSheetName = dtExcelSheetName.Rows[0]["Table_Name"].ToString();
                cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
                dAdapter.SelectCommand = cmd;
                dAdapter.Fill(dtExcelRecords);

                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dtExcelRecords;
        }

        //public static string GetTableCode(string tableName)
        //{
        //    try
        //    {
        //        string code = string.Empty;
        //        BOTableCode boTableCode = new BOTableCode();
        //        code = boTableCode.GetTableCode(tableName);

        //        return code;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
