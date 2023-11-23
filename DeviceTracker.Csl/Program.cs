
using System.Xml;
using System.Xml.Linq;

string path = @"C:\Proj\FlashDrive.xml";

//XDocument doc = XDocument.Load();

XmlDocument xml = new();
xml.Load(path);

var xList = xml.SelectNodes("/propertiesmap/key/tSTRING[@name='DcTrustedDeviceComment']");

foreach (XmlNode x in xList)
{
    Console.WriteLine(x.InnerText);
}

// See https://aka.ms/new-console-template for more information
//Console.WriteLine(doc);
