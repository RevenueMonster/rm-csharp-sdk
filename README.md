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
- [x] Signature Algorithm
- [x] Client Credentials (Authentication)
- [x] Refresh Token (Authentication)
- [ ] Get Merchant Profile
- [ ] Get Merchant Subscriptions
- [ ] Get Stores
- [ ] Get Stores By ID
- [ ] Create Store
- [ ] Update Store
- [ ] Delete Store
- [ ] Get User Profile
- [x] Payment (Transaction QR) - Create Transaction QRCode/URL
- [x] Payment (Transaction QR) - Get Transaction QRCode/URL
- [x] Payment (Transaction QR) - Get Transaction QRCode/URL By Code
- [x] Payment (Transaction QR) - Get Transactions By Code
- [x] Payment (Quick Pay) - Payment
- [x] Payment (Quick Pay) - Refund
- [x] Payment (Quick Pay) - Reverse
- [ ] Payment (Quick Pay) - Get All Payment Transactions
- [x] Payment (Quick Pay) - Get All Payment Transaction By ID
- [x] Payment (Quick Pay) - Get All Payment Transaction By OID
- [ ] Payment (Quick Pay) - Daily Settlement Report
- [x] Give Loyalty Point
- [x] Get Loyalty Members 
- [x] Get Loyalty Member
- [x] Get Loyalty Member Point History
- [x] Issue Voucher
- [x] Void Voucher
- [x] Get Voucher By Code
- [x] Get Voucher Batches
- [x] Get Voucher Batch By Key
- [ ] Send Notification (Merchant)
- [ ] Send Notification (Store)
- [ ] Send Notification (User)

### Usage
1. "sandbox" is for sandbox environment.
2. "production" is for production environment.
3. Get Client ID and Client Secret from portal.
![ClientIDClientSecret](https://storage.googleapis.com/rm-portal-assets/img/rm-landing/clientIDclientSecret.png)
4. Generate private key and public key from portal. 
![PrivateKeyPublicKey](https://storage.googleapis.com/rm-portal-assets/img/rm-landing/privateKeypublicKey.PNG)
5. Store private key for own use and public key at portal.
![PastePublicKey](https://storage.googleapis.com/rm-portal-assets/img/rm-landing/pastePublicKey.png)

* Setting up environment variables
	* To set up client id, client secret and production/sandbox environment so that all of these are not needed to be mentioned later
```
 ProjectEnvironment projectEnv = new ProjectEnvironment();
 projectEnv.setEnvironment(clientId, clientSecret, "sandbox");
```


* Client Credentials (Authentication)
    * To get refresh token and access token(expired after 2 hours) with using provided clientId and clientSecret
```
var result = await authorization.GetClientCredentials();
ProjectEnvironment.accessToken = result.accessToken;
ProjectEnvironment.refreshToken = result.refreshToken;
```

* Refresh Token (Authentication)
    * To get new access token(expired after 2 hours) with using provided clientId and clientSecret (recommended to schedule to run this fucntion on every less than 2 hours) in order to avoid expired access token error.
```
var result = await authorization.RefreshToken();
ProjectEnvironment.accessToken = result.accessToken;
```

- Create Transaction QRCode/URL (TransactionQR)
  - To create static/dynamic QR code for user scanning merchant's displayed QR
```
var data = new 
{
	amount = 100,
	currencyType = "MYR",
	method = ["WECHATPAY"],
	expiry = new {
		type = "PERMANENT"
	},
	order = new {
		details = "1 x Coffee",
		title = "Sales",
	},
	redirectUrl = "https://www.google.com",
	type = "DYNAMIC",
	storeId = "123412341234",
	isPreFillAmount = true
}
var result = await payment.CreateTransactionQRCodeUrl(data);
```

- Get Transaction QRCode/URL (TransactionQR)
  - To get all QR Code(s) generated previously in the system

```
var result = payment.GetTransactionQrCodeUrl("10","STATIC","PERMANENT");
```

- Get Transaction QRCode/URL By Code (TransactionQR)
  - To get specific QR Code generated previously in the system, by passing in code in query parameter (/qrcode/...)

```
var result = payment.GetTransactionQrCodeUrlByCode(code);
```

- Get Transactions By Code (TransactionQR)
  - To get all transactions under existing QR code, by passing in code in query parameter (/qrcode/.../transactions)

```
var result = payment.GetTransactionsByCode(code);
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
var result = await payment.QuickPay(data);
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
var result = await payment.Refund(data);
```

* Payment (Quick Pay) - Reverse
    * To reverse time-out or problematic transaction
```
var data = new
{
    orderId = "12345678131",
};
var result = await payment.Reverse(data);
```

- Payment (Quick Pay) - Get Payment Transaction By ID
  - To get details of a transaction by using transactionId

```
var result = payment.GetPaymentTransactionByID(transactionId);
```

- Payment (Quick Pay) - Get Payment Transaction By Order ID
  - To get details of a transaction by using orderId

```
var result = payment.GetPaymentTransactionByOrderID(orderId);
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
var result = await loyalty.GiveLoyaltyPoint(data);
```

* Get Loyalty Members 
    * To get details of every loyalty members
```
var result = await loyalty.GetLoyaltyMembers();
```

* Get Loyalty Member
    * To get details of a certain loyalty member
```
string memberId = "7265269757706630308";
var result = await loyalty.GetLoyaltyMembers(memberId);
```

* Get Loyalty Member Point History
    * To get details of point history of a certain loyalty member
```
string memberId = "7265269757706630308";
var result = await loyalty.GetLoyaltyMemberPointHistory(memberId);
```

* Issue Voucher
    * To issue voucher to customer
```
var batchKey = "EhQKCB1lcoNoYw50EBXVzd3RraqTDRIYCgxWb5VjaGVy6mF0Y2gQ55azPp_qz6xK";
var result = await voucher.IssueVoucher(batchKey);
```

* Void Voucher
    * To void voucher of customer
```
var code = "BcHeTSMoz";
var result = await voucher.VoidVoucher(code);
```

* Get Voucher By Code
    * To get detail of a single voucher by code
```
var code = "BcHeTSMoz";
var result = await voucher.GetVoucherByCode(code);
```

* Get Voucher Batches
    * To get detail of a multiple voucher batches
```
var result = await voucher.GetVoucherBatches();
```

* Get Voucher Batch By Key
    * To get detail of a voucher batch by batch key
```
var batchKey = "EhQKCB1lcoNoYw50EBXVzd3RraqTDRIYCgxWb5VjaGVy6mF0Y2gQ55azPp_qz6xK";
var result = await voucher.GetVoucherBatchByKey(batchKey);
```

### Sample
Sample can be found [here](https://github.com/simonlim94/API-SDK-CsharpSample)

### Nuget
[Nuget Package](https://www.nuget.org/packages/RevenueMonsterOpenAPI/)
