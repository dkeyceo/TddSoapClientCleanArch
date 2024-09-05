svcutil https://www.dataaccess.com/webservicesserver/NumberConversion.wso?WSDL /out:Reference.cs

fix in Reference.cs ctor type endpointConfigurationName, replace string to ServiceEndpoint
remove another ctors with other params
