# API-SDK-Csharp
This is an C# SDK that maps some of the RESTful methods of Open API that are documented at [doc.revenuemonster.my](https://doc.revenuemonster.my/).

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. 

### Prerequisites

The external library u need to install in order to use this library:

* [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)

The .NET framework you would need for this project is 4.5 or above

### Installing

* Download this project and open it at local machine
* Right click "References" and find 'Newtonsoft.Json' to install the library
* Right click Project Name("RevenueMonsterOpenAPI") and click Build
* The RevenueMonsterOpenAPI.dll file is in bin/Debug folder

### Or simply download the dll file here
[Google Drive](https://drive.google.com/open?id=1-eDde0nrf2AJ6zZDifM_23_n1HxGJ8r2)

### Covered Functions
* Signature Algorithm
* Client Credentials (Authentication)
* Refresh Token (Authentication)
* Payment (Quick Pay) - Payment
* Payment (Quick Pay) - Refund
* Payment (Quick Pay) - Reverse

### Usage
1. "sandbox" is for sandbox environment.
2. "production" is for production environment.
3. Get Client ID and Client Secret from portal.
![ClientIDClientSecret](https://storage.googleapis.com/rm-portal-assets/img/rm-landing/clientIDclientSecret.png)
4. Generate private key and publci key from portal. 
![PrivateKeyPublicKey](https://storage.googleapis.com/rm-portal-assets/img/rm-landing/privateKeypublicKey.PNG)
5. Store private key for own use and public key at portal.
![PastePublicKey](https://storage.googleapis.com/rm-portal-assets/img/rm-landing/pastePublicKey.png)

* Client Credentials (Authentication)
```
var clientId = Properties.Settings.Default["clientId"].ToString();
var clientSecret = Properties.Settings.Default["clientSecret"].ToString();
var result = await authorization.GetClientCredentials(clientId, clientSecret, "sandbox");
Properties.Settings.Default["accessToken"] = result.accessToken;
Properties.Settings.Default["refreshToken"] = result.refreshToken;
Properties.Settings.Default.Save();
```

* Refresh Token (Authentication)
```
var clientId = Properties.Settings.Default["clientId"].ToString();
var clientSecret = Properties.Settings.Default["clientSecret"].ToString();
var refreshToken = Properties.Settings.Default["refreshToken"].ToString();
var result = await authorization.RefreshToken(clientId, clientSecret, refreshToken, "sandbox");
Properties.Settings.Default["accessToken"] = result.accessToken;
Properties.Settings.Default.Save();
```

* Payment (Quick Pay) - Payment
```
var data = new
{
    authCode = "161583080660761280", //get from user payment barcode
    order = new { 
                  amount = 100, currencyType = "MYR", id = "12345678131", 
                  title = "title", detail = "desc", additionalData = "API Test" 
                },
   ipAddress = "127.0.0.1",
   storeId = "123412341234", 
};
var accessToken = Properties.Settings.Default["accessToken"].ToString();
string privateKey;
var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\\privateKey.txt"; //storing private key in a text file, you might use alternative way
var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
{
   privateKey = streamReader.ReadToEnd();
}
var result = await payment.QuickPay(data, accessToken, privateKey, "sandbox");
```

* Payment (Quick Pay) - Refund
```
var data = new
{
   transactionId = "181203100634010427614646", // get from user's transaction 
   refund = new { type = "FULL", currencyType = "MYR", amount = 100 },
   reason = "test",
};
var accessToken = Properties.Settings.Default["accessToken"].ToString();
string privateKey;
var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\\privateKey.txt"; //storing private key in a text file, you might use alternative way
var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
{
   privateKey = streamReader.ReadToEnd();
}
var result = await payment.Refund(data, accessToken, privateKey, "sandbox");
```

* Payment (Quick Pay) - Reverse
```
var data = new
{
    orderId = "12345678131",
};
var accessToken = Properties.Settings.Default["accessToken"].ToString();
string privateKey;
var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\\privateKey.txt"; //storing private key in a text file, you might use alternative way
var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
{
   privateKey = streamReader.ReadToEnd();
}
var result = await payment.Reverse(data, accessToken, privateKey, "sandbox");
```

### Sample
Sample can be found [here](https://github.com/simonlim94/API-SDK-CsharpSample)
