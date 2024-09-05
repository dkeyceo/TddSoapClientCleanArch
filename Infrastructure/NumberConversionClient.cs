using Infrastructure.SoapHelper;
using Core.DTOs;
using System.Text;
using System.Xml;
using System.ServiceModel;

namespace Infrastructure;

public class NumberConversionClient
{
    public string NumberToWords(int number)
    {
        var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
        var endpoint = new EndpointAddress("https://www.dataaccess.com/webservicesserver/NumberConversion.wso");

        var client = new NumberConversionSoapTypeClient(binding, endpoint);


        var response = client.NumberToWords(number);

        return response;
    }
}
