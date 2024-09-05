using Infrastructure.SoapHelper;
using Core.DTOs;
using System.Text;
using System.Xml;
using System.ServiceModel;

namespace Infrastructure;

public class NumberConversionClientV2
{
    private readonly HttpClient _httpClient;

    public NumberConversionClientV2()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> NumberToWords(int num)
    {
        var request = new NumberToWordsRequest { number = num };
        var soapEnvelope = SoapEnvelope.CreateSoapEnvelope(request);

        var content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");

        var response = await _httpClient.PostAsync("https://www.dataaccess.com/webservicesserver/NumberConversion.wso", content);
        var responseContent = await response.Content.ReadAsStringAsync();

        return ParseSoapResponse(responseContent);
    }

    private string ParseSoapResponse(string responseContent)
    {
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(responseContent);

        XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
        nsmgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
        nsmgr.AddNamespace("ns", "http://www.dataaccess.com/webservicesserver/");

        XmlNode? resultNode = xmlDoc.SelectSingleNode("//soap:Body/ns:NumberToWordsResponse/ns:NumberToWordsResult", nsmgr);

        return resultNode?.InnerText ?? string.Empty;
    }
}
