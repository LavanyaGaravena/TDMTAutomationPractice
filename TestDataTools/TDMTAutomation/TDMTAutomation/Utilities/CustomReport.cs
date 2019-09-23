using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TDMTAutomation;

namespace Util
{
    public class CustomReport
    {
        public static string htmlContent = "";
        public static string resultFolderPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string htmlFilePath;
        public static string htmlFileName;
        public void TestingReportAppend()
        {
            //Pick the Report template
            string date = BaseTest.GetDate("MM/dd/yyyy h:mm tt");
            htmlContent = System.IO.File.ReadAllText(@"C:\SampleAutomationProject\SampleAutomationProject\Template\datatools.html").Replace("{date}", date);
            ////Fill the content in the htnl file
            ////Assign the file name to the result report
            htmlFileName = "Report_" + DateTime.Now.ToString("yyyy_MM_ddThh_mm_ss") + ".html";
            ////Assign location to the result report
            htmlFilePath = resultFolderPath + "\\" + htmlFileName;
            ////Write the report in the provided location
            System.IO.File.WriteAllText(resultFolderPath + "\\" + htmlFileName, htmlContent);
        }
        //static int total = 0;
        //public static void WriteContent(string[] content)
        //{
        //    try
        //    {

        //        total++;
        //        string description = "";
        //        string testType = "";
        //        string actual = "";
        //        string expected = "";
        //        string status = "";

        //        if (content.Length > 0 && content[0] != null)
        //        { description = content[0]; }


        //        if (content.Length > 1 && content[1] != null)
        //        { testType = content[1]; }


        //        if (content.Length > 2 && content[2] != null)
        //        { actual = content[2]; }

        //        if (content.Length > 3 && content[3] != null)
        //        { expected = content[3]; }

        //        if (content.Length > 4 && content[4] != null)
        //        { status = content[4]; }

        //        //Create report file
        //        XmlDocument doc = new XmlDocument();
        //        string path = "Report.xml";
        //        if (!File.Exists(path))
        //        {
        //            //Add header and footer to the report file
        //            File.WriteAllText(path, "<Results></Results>");
        //        }
        //        //Load the report file
        //        doc.Load(path);

        //        //Fecth the parent node
        //        XmlNode results = doc.SelectSingleNode("//Results");
        //        //Create result node
        //        XmlNode result = doc.CreateNode(XmlNodeType.Element, "Result", null);

        //        //Create Description node
        //        XmlNode nodeDescription = doc.CreateNode(XmlNodeType.Element, "description", null);
        //        nodeDescription.InnerText = description;
        //        //Create testType node
        //        XmlNode nodeTestType = doc.CreateNode(XmlNodeType.Element, "testType", null);
        //        nodeTestType.InnerText = testType;
        //        //Create actual node
        //        XmlNode nodeActual = doc.CreateNode(XmlNodeType.Element, "actual", null);

        //        nodeActual.InnerText = actual;
        //        //Create expected node
        //        XmlNode nodeExpected = doc.CreateNode(XmlNodeType.Element, "expected", null);
        //        nodeExpected.InnerText = expected;
        //        //Create status node
        //        XmlNode nodeStatus = doc.CreateNode(XmlNodeType.Element, "status", null);
        //        nodeStatus.InnerText = status;

        //        //Append all noded to result node
        //        results.AppendChild(result);
        //        result.AppendChild(nodeDescription);
        //        result.AppendChild(nodeTestType);
        //        result.AppendChild(nodeActual);
        //        result.AppendChild(nodeExpected);
        //        result.AppendChild(nodeStatus);
        //        //Save the report file
        //        doc.Save(path);


        //    }
        //    catch (Exception ex)
        //    {
        //        CustomAssert.Fail($"At {MethodBase.GetCurrentMethod()} and below error message displayed<br/>{ex.Message}", false);
        //    }
        //}
    }
}
