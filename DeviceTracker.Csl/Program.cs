
using System.Xml;
using System.Xml.Linq;

string path = @"C:\Proj\FlashDrive.xml";

XDocument doc = XDocument.Load(path);
string Name = "";
var namesList = doc.Descendants("tSTRING").Select(s => (string)s.Attribute("DcTrustedDeviceComment"));

Console.WriteLine(namesList.Count());

foreach (var node in namesList)
{
    Console.WriteLine(node);
}


#region XML
//XmlDocument xml = new();
//xml.Load(path);

//var xList = xml.SelectNodes("/propertiesmap/key/tSTRING[@name='DcTrustedDeviceComment']");

//foreach (XmlNode x in xList)
//{
//    Console.WriteLine(x.InnerText);
//} 
#endregion

// See https://aka.ms/new-console-template for more information
//Console.WriteLine(doc);
