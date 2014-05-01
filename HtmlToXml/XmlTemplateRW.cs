using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Collections;
using System.Text.RegularExpressions;

class XmlTemplateRW
{
    XmlDocument _LoadedXmlDoc = null;

    public struct TemplatePlacholderInternal
    {
        public const string FileName = "{{filename}}";
        public const string FilePath = "{{filepath}}";
    }

    public XmlTemplateRW()
    {

    }

    public bool LoadXmlTemplate(string FullFilePath)
    {
        if (!File.Exists(FullFilePath))
            return false;

        this._LoadedXmlDoc = new XmlDocument();
        this._LoadedXmlDoc.Load(FullFilePath);

        return true;
    }

    public void ExecutePlaceholderReplacement(HtmlReader LoadedHtmlReader)
    {

        XmlNodeList FoundNodes = _LoadedXmlDoc.DocumentElement.SelectNodes("//*");
        foreach (XmlNode FoundNode in FoundNodes)
        {
            foreach (XmlNode ChildNode in FoundNode.ChildNodes)
            {
                if (ChildNode.NodeType == XmlNodeType.Text || ChildNode.NodeType == XmlNodeType.CDATA)
                {
                    List<String> FoundPlaceholderNames = this.ParseForPlaceholder(ChildNode);

                    foreach (string FoundPlaceholderName in FoundPlaceholderNames)
                    {
                        string PlaceholderValue = this.GetPlaceholdContent(FoundPlaceholderName, LoadedHtmlReader);

                        ChildNode.InnerText = ChildNode.InnerText.Replace(FoundPlaceholderName, PlaceholderValue);
                    }
                }
            }
        }
    }

    public void Save(string FullFilePath)
    {
        this._LoadedXmlDoc.Save(FullFilePath);
    }

    private List<String> ParseForPlaceholder(XmlNode ParsableNode)
    {
        List<String> RetPlaceholdNames = new List<String>();

        if (ParsableNode == null)
            return RetPlaceholdNames;

        string InnerPlaceholderRegexPattern = @"{{.+?}}";
        foreach (Match MatchedPlaceholder in Regex.Matches(ParsableNode.Value, InnerPlaceholderRegexPattern))
        {
            RetPlaceholdNames.Add(MatchedPlaceholder.Value);
        }

        string OuterPlaceholderRegexPattern = @"\[\[.+?\]\]";
        foreach (Match MatchedPlaceholder in Regex.Matches(ParsableNode.Value, OuterPlaceholderRegexPattern))
        {
            RetPlaceholdNames.Add(MatchedPlaceholder.Value);
        }

        return RetPlaceholdNames;
    }

    private string GetPlaceholdContent(string PlaceholderName, HtmlReader LoadedHtmlReader)
    {
        string RetPlaceholderContent = "";

        switch (PlaceholderName)
        {
            case TemplatePlacholderInternal.FileName:
                RetPlaceholderContent = Path.GetFileName(LoadedHtmlReader.FullFilePath);
                break;
            case TemplatePlacholderInternal.FilePath:
                RetPlaceholderContent = Path.GetDirectoryName(LoadedHtmlReader.FullFilePath);
                break;
            default:
                string PlaceholderRegex = PlaceholderName.TrimStart(new char[] { '{', '[' }).TrimEnd(new char[] { '}', ']' });
                if (PlaceholderName[0] == '{')
                {
                    RetPlaceholderContent = LoadedHtmlReader.GetOuterHtmlContent(PlaceholderRegex);
                }
                else if (PlaceholderName[0] == '[')
                {
                    RetPlaceholderContent = LoadedHtmlReader.GetInnerHtmlContent(PlaceholderRegex);
                }
                
                break;
        }

        return RetPlaceholderContent;
    }
}
