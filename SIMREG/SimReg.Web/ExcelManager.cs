using System;
using System.Web;
using System.Text;
using System.Data;
using System.Web.UI;



public class ExcelManager
{
    private string fileName;
    private bool isInExcel;

    public ExcelManager(string exportFileName, bool isExportInExcel)
    {
        fileName = exportFileName;
        isInExcel = isExportInExcel;
    }

    public void ExportData(DataTable dataTobeExported, HttpResponse response)
    {
        string content = string.Empty;
        if (this.isInExcel == true)
        {
            content = BuildExportContent(dataTobeExported, "\t", "\t");
            ExportToExcel(content, response);
        }
        else
        {
            content = BuildExportContent(dataTobeExported, "'", ",");
            ExportToCSV(content, response);
        }
        
    }

    public void ExportData(DataTable dataTobeExported, HttpResponseBase response)
    {
        string content = string.Empty;
        if (this.isInExcel == true)
        {
            content = BuildExportContent(dataTobeExported, "\t", "\t");
            ExportToExcel(content, response);
        }
        else
        {
            content = BuildExportContent(dataTobeExported, "'", ",");
            ExportToCSV(content, response);
        }

    }

    private void ExportToExcel(string exportContent, HttpResponse response)
    {
        response.Clear();
        response.AddHeader("content-disposition", "attachment;filename=" + fileName);
        response.Charset = "";
        response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        response.Write(exportContent);
        response.End();
    }

    private void ExportToCSV(string exportContent, HttpResponse response)
    {
        response.Clear();
        response.AddHeader("content-disposition", "attachment;filename=" + fileName);
        response.Charset = "";
        response.ContentType = "application/octet-stream";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        response.Write(exportContent);
        response.End();
    }



    private void ExportToExcel(string exportContent, HttpResponseBase response)
    {
        response.Clear();
        response.ClearContent();
        response.AddHeader("content-disposition", "attachment;filename=" + fileName);
        response.Charset = "";
        response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        response.Write(exportContent);
        response.End();
    }

    private void ExportToCSV(string exportContent, HttpResponseBase response)
    {
        response.Clear();
        response.ClearContent();
        response.AddHeader("content-disposition", "attachment;filename=" + fileName);
        response.Charset = "";
        response.ContentType = "application/octet-stream";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        response.Write(exportContent);
        response.End();
    }

    private string BuildExportContent(DataTable dataToExport, string delimiter, string seperator)
    {
        StringBuilder contentBuilder = new StringBuilder();

        //foreach (DataColumn dc in dataToExport.Columns)
        //{
        //    contentBuilder.Append(dc.ColumnName);
        //    contentBuilder.Append(seperator);
        //}
        string value = string.Empty;
        //contentBuilder.Append(Environment.NewLine);

        foreach (DataColumn col in dataToExport.Columns)
        {
             value = col.ColumnName.ToString().Replace(Environment.NewLine, "").Replace("\n", "");
                value = value.Replace("\t", "");
                contentBuilder.Append(value);
                contentBuilder.Append(seperator);
        }

        contentBuilder.Append(Environment.NewLine);
        foreach (DataRow dr in dataToExport.Rows)
        {
            foreach (DataColumn vc in dataToExport.Columns)
            {
                value = dr[vc.ColumnName].ToString().Replace(Environment.NewLine, "").Replace("\n", "");
                value = value.Replace("\t", "");
                contentBuilder.Append(value);
                contentBuilder.Append(seperator);
            }
            contentBuilder.Length = contentBuilder.Length - 1;
            contentBuilder.Append(Environment.NewLine);
        }

        //delay 5 seconds to write data in excel file properly
        System.Threading.Thread.Sleep(5000);

        return contentBuilder.ToString();
    }
}

