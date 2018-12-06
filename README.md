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
    * To get refresh token and access token(expired after 2 hours) with using provided clientId and clientSecret
```
var result = await authorization.GetClientCredentials(clientId, clientSecret, "sandbox");
```

* Refresh Token (Authentication)
    * To get new access token(expired after 2 hours) with using provided clientId and clientSecret (recommended to schedule to run this fucntion on every less than 2 hours) in order to avoid expired access token error.
```
var result = await authorization.RefreshToken(clientId, clientSecret, refreshToken, "sandbox");
```

* Payment (Quick Pay) - Payment
    * To make payment by scanning barcode/authcode from user
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
var result = await payment.QuickPay(data, accessToken, privateKey, "sandbox");
```

* Payment (Quick Pay) - Refund
    * To refund the successful transactions 
```
var data = new
{
   transactionId = "181203100634010427614646", // get from user's transaction 
   refund = new { type = "FULL", currencyType = "MYR", amount = 100 },
   reason = "test",
};
var result = await payment.Refund(data, accessToken, privateKey, "sandbox");
```

* Payment (Quick Pay) - Reverse
    * To reverse time-out or problematic transaction
```
var data = new
{
    orderId = "12345678131",
};
var result = await payment.Reverse(data, accessToken, privateKey, "sandbox");
```

* Give Loyalty Point 
    * To give certain loyalty points to a loyalty member
```
var data = new
{
    point = 100,
    type = "ID",
    memberId = "7265269757706630308",
    // type = "PHONENUMBER",
    // countryCode = "60",
    // phoneNumber = "123456789",
};
var result = await loyalty.GiveLoyaltyPoint(data, accessToken, privateKey, "sandbox");
```

* Get Loyalty Members 
    * To get details of every loyalty members
```
var result = await loyalty.GetLoyaltyMembers(accessToken, privateKey, "sandbox");
```

* Get Loyalty Member
    * To get details of a certain loyalty member
```
string memberId = "7265269757706630308";
var result = await loyalty.GetLoyaltyMembers(memberId, accessToken, privateKey, "sandbox");
```

* Get Loyalty Member Point History
    * To get details of point history of a certain loyalty member
```
string memberId = "7265269757706630308";
var result = await loyalty.GetLoyaltyMemberPointHistory(memberId, accessToken, privateKey, "sandbox");
```

* Issue Voucher
    * To issue voucher to customer
```
var batchKey = "EhQKCB1lcoNoYw50EBXVzd3RraqTDRIYCgxWb5VjaGVy6mF0Y2gQ55azPp_qz6xK";
var result = await voucher.IssueVoucher(batchKey, accessToken, privateKey, "sandbox");
```

* Void Voucher
    * To void voucher of customer
```
var code = "BcHeTSMoz";
var result = await voucher.VoidVoucher(code, accessToken, privateKey, "sandbox");
```

* Get Voucher By Code
    * To get detail of a single voucher by code
```
var code = "BcHeTSMoz";
var result = await voucher.GetVoucherByCode(code, accessToken, privateKey, "sandbox");
```

* Get Voucher Batches
    * To get detail of a multiple voucher batches
```
var result = await voucher.GetVoucherBatches(accessToken, privateKey, "sandbox");
```

* Get Voucher Batch By Key
    * To get detail of a voucher batch by batch key
```
var batchKey = "EhQKCB1lcoNoYw50EBXVzd3RraqTDRIYCgxWb5VjaGVy6mF0Y2gQ55azPp_qz6xK";
var result = await voucher.GetVoucherBatchByKey(batchKey, accessToken, privateKey, "sandbox");
```

### Sample
Sample can be found [here](https://github.com/simonlim94/API-SDK-CsharpSample)
