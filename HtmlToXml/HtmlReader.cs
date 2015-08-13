using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using HtmlAgilityPack;
using System.Collections;

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

		string HTML = "";
		//HTML = this.TidyHtml(FullFilePath);
		HTML = this.LoadFile(FullFilePath);

        this._FullFilePath = FullFilePath;

        this._LoadedHtmlDoc = new HtmlDocument();
        this._LoadedHtmlDoc.OptionFixNestedTags = true;
        this._LoadedHtmlDoc.OptionAutoCloseOnEnd = true;
		this._LoadedHtmlDoc.LoadHtml(HTML);

        return true;
    }

	private string LoadFile(string FullFilePath)
	{
		FileStream FileContentStream = File.Open(FullFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		StreamReader FileContentReader = new StreamReader(FileContentStream);

		string FileContent = "";
		FileContent = FileContentReader.ReadToEnd();

		//  clean up
		FileContentReader.Close();
		FileContentStream.Close();

		return FileContent;
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

		HtmlNodeCollection FoundNodes = this.GetHtmlContents(XpathExpression);

		if (FoundNodes == null)
			return retHtml;

		foreach (HtmlNode FoundNode in FoundNodes)
        {
            retHtml += FoundNode.InnerHtml;
        }

        return retHtml;
    }

	public string GetCSVInnerHtmlContent(string XpathExpression)
	{
		string retHtml = "";
		ArrayList ItemsArray = new ArrayList();

		if (string.IsNullOrEmpty(XpathExpression))
			return retHtml;

		HtmlNodeCollection FoundNodes = this.GetHtmlContents(XpathExpression);

		if (FoundNodes == null)
			return retHtml;

		foreach (HtmlNode FoundNode in FoundNodes)
		{
			ItemsArray.Add(FoundNode.InnerHtml);
		}

		retHtml = String.Join(",", ItemsArray.ToArray());

		return retHtml;
	}

	public string GetAttributeHtmlContent(string XpathExpression, string AttributeName)
	{
		string retHtml = "";

		if (string.IsNullOrEmpty(XpathExpression))
			return retHtml;

		HtmlNodeCollection FoundNodes = this.GetHtmlContents(XpathExpression);

		if (FoundNodes == null)
			return retHtml;

		foreach (HtmlNode FoundNode in FoundNodes)
		{
			retHtml += FoundNode.Attributes[AttributeName].Value;
		}

		return retHtml;
	}

    public string GetOuterHtmlContent(string XpathExpression)
    {
        string retHtml = "";

        if (string.IsNullOrEmpty(XpathExpression))
            return retHtml;

		HtmlNodeCollection FoundNodes = this.GetHtmlContents(XpathExpression);

		if (FoundNodes == null)
			return retHtml;

		foreach (HtmlNode FoundNode in FoundNodes)
        {
            retHtml += FoundNode.OuterHtml;
        }

        return retHtml;
    }
}
