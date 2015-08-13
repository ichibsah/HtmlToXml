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
		string[] lines = File.ReadAllLines(FullFilePath);
		File.WriteAllLines(FullFilePath, lines);
    }

    private List<String> ParseForPlaceholder(XmlNode ParsableNode)
    {
        List<String> RetPlaceholdNames = new List<String>();

        if (ParsableNode == null)
            return RetPlaceholdNames;

        string InnerPlaceholderRegexPattern = @"{.+}";
        foreach (Match MatchedPlaceholder in Regex.Matches(ParsableNode.Value, InnerPlaceholderRegexPattern))
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
                string PlaceholderRegex = PlaceholderName.TrimStart(new char[] { '{' }).TrimEnd(new char[] { '}' });
                if (PlaceholderName.StartsWith("{{{"))
                {
                    RetPlaceholderContent = LoadedHtmlReader.GetOuterHtmlContent(PlaceholderRegex);
                }
				else if (PlaceholderName.StartsWith("{{"))
				{
					RetPlaceholderContent = LoadedHtmlReader.GetInnerHtmlContent(PlaceholderRegex);
				}
				else if (PlaceholderName.StartsWith("{"))
				{
					string[] PlaceholderRegexArray = PlaceholderRegex.Split(',');

					if (PlaceholderRegexArray.Length == 1)
					{
						RetPlaceholderContent = LoadedHtmlReader.GetCSVInnerHtmlContent(PlaceholderRegexArray[0]);
					}
					else if (PlaceholderRegexArray.Length == 2)
					{
						RetPlaceholderContent = LoadedHtmlReader.GetAttributeHtmlContent(PlaceholderRegexArray[0], PlaceholderRegexArray[1]);

						string[] RetPlaceholderContentArray = RetPlaceholderContent.Split('/');
						RetPlaceholderContent = RetPlaceholderContentArray[RetPlaceholderContentArray.Length - 1];
					}	
				}
                break;
        }

        return RetPlaceholderContent;
    }
}
