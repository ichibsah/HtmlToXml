using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using HtmlAgilityPack;

class HtmlReader
{
    HtmlDocument _LoadedHtmlDoc = null;
    string _FullFilePath = null;

    public HtmlReader()
    {

    }

    public string FullFilePath
    {
        get
        {
            return _FullFilePath;
        }
    }

    public bool LoadHtml(string FullFilePath)
    {
        if (!File.Exists(FullFilePath))
            return false;

        this._FullFilePath = FullFilePath;

        this._LoadedHtmlDoc = new HtmlDocument();
        this._LoadedHtmlDoc.OptionFixNestedTags = true;
        this._LoadedHtmlDoc.OptionAutoCloseOnEnd = true;
        this._LoadedHtmlDoc.LoadHtml(this.TidyHtml(FullFilePath));

        return true;
    }

    private string TidyHtml(string FullFilePath)
    {
        TidyManaged.Document TidyDocObj = TidyManaged.Document.FromFile(FullFilePath);
        TidyDocObj.OutputHtml = true;
        TidyDocObj.ShowWarnings = false;
        TidyDocObj.Quiet = true;
        TidyDocObj.ForceOutput = true;
        TidyDocObj.CleanAndRepair();
        string TidyHtml = TidyDocObj.Save();
        TidyDocObj.Dispose();
        return TidyHtml;
    }

    private HtmlNodeCollection GetHtmlContents(string XpathExpression)
    {
        return this._LoadedHtmlDoc.DocumentNode.SelectNodes(XpathExpression);
    }

    public string GetInnerHtmlContent(string XpathExpression)
    {
        string retHtml = "";

        if (string.IsNullOrEmpty(XpathExpression))
            return retHtml;

        foreach (HtmlNode FoundNode in this.GetHtmlContents(XpathExpression))
        {
            retHtml += FoundNode.InnerHtml;
        }

        return retHtml;
    }

    public string GetOuterHtmlContent(string XpathExpression)
    {
        string retHtml = "";

        if (string.IsNullOrEmpty(XpathExpression))
            return retHtml;

        foreach (HtmlNode FoundNode in this.GetHtmlContents(XpathExpression))
        {
            retHtml += FoundNode.OuterHtml;
        }

        return retHtml;
    }
}
