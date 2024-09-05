using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;

namespace Infrastructure.SoapHelper
{
    public class SoapEnvelope
    {
        public static string CreateSoapEnvelope(NumberToWordsRequest request)
        {
            return $@"<?xml version=""1.0"" encoding=""utf-8""?>
    <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
                   xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
                   xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
      <soap:Body>
        <NumberToWords xmlns=""http://www.dataaccess.com/webservicesserver/"">
          <ubiNum>{request.number}</ubiNum>
        </NumberToWords>
      </soap:Body>
    </soap:Envelope>";
        }

    }
}