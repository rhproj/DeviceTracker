
using DeviceModel;
using System.Xml;
using System.Xml.Linq;

string path = @"C:\Proj\FlashDrive.xml";


List<RegistryModel> devicesRegistry = new();

XmlDocument xml = new();
xml.Load(path);

var xList = xml.SelectNodes("/propertiesmap/key");  //(" / propertiesmap/key/tSTRING[@name='DcTrustedDeviceComment']");



foreach (XmlNode node in xList)
{
    RegistryModel deviceModel = new()
    {
        DeviceName = ExtractXMLValue(node, "tSTRING[@name='DcTrustedDeviceName']"),
        DeviceID = ExtractXMLValue(node, "tSTRING[@name='DcTrustedDeviceID']"),
        UserInfo = new User(ExtractXMLValue(node, "tSTRING[@name='DcTrustedDeviceComment']")) 
    };

    devicesRegistry.Add(deviceModel);

    //deviceModel.DeviceName = ExtractXMLValue(node, "tSTRING[@name='DcTrustedDeviceName']");

    //deviceModel.DeviceID = ExtractXMLValue(node, "tSTRING[@name='DcTrustedDeviceID']");

    //deviceModel.User.UserName = ExtractXMLValue(node, "tSTRING[@name='DcTrustedDeviceComment']");

    //var deviceNameNode = node.SelectSingleNode("tSTRING[@name='DcTrustedDeviceName']").InnerXml;
    //if (!string.IsNullOrEmpty(deviceNameNode))
    //{
    //    deviceModel.DeviceName = deviceNameNode;
    //}
    //else
    //{
    //    deviceModel.DeviceName = "Не указан";
    //}

    //var deviceIdNode = node.SelectSingleNode("tSTRING[@name='DcTrustedDeviceID']").InnerXml;
    //if (!string.IsNullOrEmpty(deviceIdNode))
    //{
    //    deviceModel.DeviceID = deviceIdNode;
    //}
    //else
    //{
    //    deviceModel.DeviceID = "Не указан";
    //}

    //var userNameNode = node.SelectSingleNode("tSTRING[@name='DcTrustedDeviceComment']").InnerXml;
    //if (!string.IsNullOrEmpty(userNameNode))
    //{
    //    deviceModel.User.UserName = userNameNode;
    //}
    //else
    //{
    //    deviceModel.User.UserName = "Не указан";
    //}
}


foreach (var deviceInfo in devicesRegistry)
{
    // deviceModel.User.UserName

    Console.WriteLine($"{deviceInfo.DeviceName} - {deviceInfo.DeviceID} - {deviceInfo.UserInfo.UserName}");
}


string ExtractXMLValue(XmlNode node, string attribute)
{
    var deviceNameNode = node.SelectSingleNode(attribute).InnerXml;

    if (string.IsNullOrEmpty(deviceNameNode))
    {
        return "Значение не указано";
    }

    return deviceNameNode;
}


// See https://aka.ms/new-console-template for more information
//Console.WriteLine(doc);
