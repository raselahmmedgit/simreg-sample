using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.BLTemp.Web.Models;

namespace RnD.BLTemp.Web.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public BaseController()
        {
            HttpContext context = System.Web.HttpContext.Current;
            var contextWrapper = new HttpContextWrapper(context);

            #region Popup and Page Request Check

            string ajaxRequest = string.Empty;
            string statusCode = string.Empty;
            string authenticated = string.Empty;

            if (contextWrapper.Request.IsAjaxRequest())
            {
                ajaxRequest = "Yes";
                Response.Redirect("~/Category/LogIn");
            }
            else
            {
                ajaxRequest = "No";
            }

            //Do a direct 401 unautorized
            if (contextWrapper.Response.StatusCode == 302)
            {
                statusCode = contextWrapper.Response.StatusCode.ToString();
            }
            else
            {
                statusCode = contextWrapper.Response.StatusCode.ToString();
            }

            if (context.Request.IsAuthenticated)
            {
                authenticated = "Yes";
            }
            else
            {
                authenticated = "No";
            }

            //if (Session["categories"] != null)
            //{
            //    Response.Redirect("~/Category/Index", true);
            //}
            //else
            //{
            //    Response.Redirect("~/Category/Index", true);
            //}

            #endregion

        }

        public void SetPager(int pageIndex, int pageSize, int totalRow)
        {
            HttpContext context = System.Web.HttpContext.Current;
            var contextWrapper = new HttpContextWrapper(context);

            #region Paging Code

            PageViewModel pageViewModel = new PageViewModel();

            //int totalRowCount = ViewBag.TotalRowCount != null ? Convert.ToInt32(ViewBag.TotalRowCount) : 0;
            int totalRowCount = totalRow;
            int size = pageSize;
            int index = pageIndex;

            pageViewModel.PageSize = Convert.ToString(size);
            pageViewModel.Index = Convert.ToString(index);

            if (size == 10)
                pageViewModel.PageNumber10Class = " current";
            else if (size == 20)
                pageViewModel.PageNumber20Class = " current";
            else if (size == 30)
                pageViewModel.PageNumber30Class = " current";
            else if (size == 40)
                pageViewModel.PageNumber40Class = " current";
            else if (size == 50)
                pageViewModel.PageNumber50Class = " current";
            else if (size == 60)
                pageViewModel.PageNumber60Class = " current";
            else if (size == 70)
                pageViewModel.PageNumber70Class = " current";
            else if (size == 80)
                pageViewModel.PageNumber80Class = " current";
            else if (size == 90)
                pageViewModel.PageNumber90Class = " current";
            else if (size == 100)
                pageViewModel.PageNumber100Class = " current";

            #region get url

            string area = contextWrapper.Request.RequestContext.RouteData.DataTokens.ContainsKey("area") ? contextWrapper.Request.RequestContext.RouteData.DataTokens["area"].ToString() : null;
            string controller = contextWrapper.Request.RequestContext.RouteData.Values["controller"].ToString();
            string action = contextWrapper.Request.RequestContext.RouteData.Values["action"].ToString();

            string strActionUrl = string.Empty;

            if (!String.IsNullOrEmpty(area))
            {
                strActionUrl += "/" + area;
            }
            if (!String.IsNullOrEmpty(controller))
            {
                strActionUrl += "/" + controller;
            }
            if (!String.IsNullOrEmpty(action))
            {
                strActionUrl += "/" + action;
            }

            #endregion

            #region get page url by area, controller, action

            string url = strActionUrl;

            //string templates for links
            string link = "<a  href='" + url + "?Index=##Index##&amp;Size=##Size##'><span class='page-numbers'>##Text##</span></a>";
            string link_pre = "<a href='" + url + "?Index=##Index##&amp;Size=##Size##'><span class='page-numbers prev'>##Text##</span></a>";
            string link_next = "<a href='" + url + "?Index=##Index##&amp;Size=##Size##'><span class='page-numbers next'>##Text##</span></a>";


            #endregion

            #region get the n number of record

            decimal n = Convert.ToDecimal(totalRowCount) / size;
            n = Math.Ceiling(n);

            #endregion

            #region setting page numbers with links

            if (index != 1)
                pageViewModel.LinkPre = link_pre.Replace("##Size##", size.ToString()).Replace("##Index##", (index - 1).ToString()).Replace("##Text##", "prev");
            else
                pageViewModel.LinkPre = "<span class='page-numbers prev'>prev</span>";

            if (index != Convert.ToInt32(n))
                pageViewModel.LinkNext = link_next.Replace("##Size##", size.ToString()).Replace("##Index##", (index + 1).ToString()).Replace("##Text##", "next");
            else
                pageViewModel.LinkNext = "<span class='page-numbers next'>next</span>";

            #endregion

            #region generate dynamic paging

            string strLinkDynamicPage = "<div id='pl'>";

            int start;
            if (index <= 5) start = 1;
            else start = index - 4;
            for (int i = start; i < start + 7; i++)
            {
                if (i > n) continue;

                //create dynamic HyperLinks 
                string lnk = string.Empty;

                lnk += "<a ";

                lnk += "id='lnk_" + i.ToString() + "' ";

                if (i == index)//current page
                {
                    lnk += "class='page-numbers current' ";
                    lnk += ">" + i.ToString() + "</a>";
                }
                else
                {
                    lnk += "class='page-numbers' ";
                    lnk += "href='" + url + "?Index=" + i + "&Size=" + size + "' ";
                    lnk += ">" + i.ToString() + "</a>"; ;
                }

                //add links to page
                strLinkDynamicPage += lnk;
            }

            strLinkDynamicPage += "</div>";

            pageViewModel.LinkDynamicPage = strLinkDynamicPage;

            //------------------------------------------------------------------
            //set up the ist page and the last page
            if (n > 7)
            {
                if (index <= Convert.ToInt32(n / 2))
                {
                    pageViewModel.LinkIstPage = string.Empty;
                    pageViewModel.LinkLastPage = link.Replace("##Index##", n.ToString()).Replace("##Size##", size.ToString()).Replace("##Text##", n.ToString());

                    pageViewModel.Link2ndDot = "<span class='page-numbers prev'>...</span>";
                    pageViewModel.LinkIstDot = string.Empty;
                }
                else
                {
                    pageViewModel.LinkLastPage = string.Empty;
                    pageViewModel.LinkIstPage = link.Replace("##Index##", (n - n + 1).ToString()).Replace("##Size##", size.ToString()).Replace("##Text##", (n - n + 1).ToString());

                    pageViewModel.Link2ndDot = string.Empty;
                    pageViewModel.LinkIstDot = "<span class='page-numbers prev'>...</span>";
                }
            }

            #endregion

            #region Keep Model To ViewBag

            ViewBag.PageViewModel = pageViewModel;

            #endregion

            #endregion

        }

    }
}
