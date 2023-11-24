using DeviceModel;
using OfficeOpenXml.Style;
using System.Xml;
using System.Xml.Linq;
using XMLWorker.ReportService;
using XMLWorker.XmlService;

string path = @"C:\Proj\FlashDrive.xml";


//List<RegistryModel> devicesRegistry = new();

XmlDocument xml = new();
xml.Load(path);

var xList = xml.SelectNodes("/propertiesmap/key");  //(" / propertiesmap/key/tSTRING[@name='DcTrustedDeviceComment']");



//foreach (XmlNode node in xList)
//{

//    RegistryModel deviceModel = new()
//    {
//        Number = 
//        DeviceName = XmlParser.ExtractXMLValue(node, "tSTRING[@name='DcTrustedDeviceName']"),
//        DeviceID = XmlParser.ExtractXMLValue(node, "tSTRING[@name='DcTrustedDeviceID']"),
//        UserInfo = XmlParser.ExtractXMLValue(node, "tSTRING[@name='DcTrustedDeviceComment']") 
//    };

//    devicesRegistry.Add(deviceModel);
//}
//int devicesCount = xList.Count;

RegistryModel[] devicesRegistry = new RegistryModel[xList.Count];

for (int i = 0; i < xList.Count; i++)
{
    devicesRegistry[i] = new()
    {
        Number = i + 1,
        DeviceName = XmlParser.ExtractXMLValue(xList[i], "tSTRING[@name='DcTrustedDeviceName']"),
        DeviceID = XmlParser.ExtractXMLValue(xList[i], "tSTRING[@name='DcTrustedDeviceID']"),
        UserInfo = XmlParser.ExtractXMLValue(xList[i], "tSTRING[@name='DcTrustedDeviceComment']")
    };
}


//foreach (var deviceInfo in devicesRegistry)
//{
//    Console.WriteLine($"{deviceInfo.DeviceName} - {deviceInfo.DeviceID} - {deviceInfo.UserInfo.UserName}");
//}

EPPlusService excelService = new();

FileInfo fI = new FileInfo(@"C:\Proj\flashDrives.xlsx");
if (fI.Exists)
{
	try
	{
		fI.Delete();
	}
	catch (Exception ex)
	{
        Console.WriteLine($"Убедитесь что файл отчета закрыт: {ex.Message}");
    }
}

//excelService.SaveToExcel(devicesRegistry, fI);
excelService.CreateSpreadSheet(devicesRegistry, fI);


//string ExtractXMLValue(XmlNode node, string attribute)
//{
//    var deviceNameNode = node.SelectSingleNode(attribute).InnerXml;

//    if (string.IsNullOrEmpty(deviceNameNode))
//    {
//        return "Значение не указано";
//    }

//    return deviceNameNode;
//}