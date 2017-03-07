# rbdms-api-csharp
.Net/C# wrapper for RbDms REST API. The library uses OAuth2.0 authentication over HTTP protocol and interacts with the DMS rest API.

## Setup
Setup for new DMS REST API integration:

    options.uri = "http://rbdms-uat.cloudhub.io/";
    options.apiPath = "npapi/inventoryItems?countryCode=EA&dbName=TEST";
    options.oauthUrl =    "http://rboauth2.cloudhub.io/tokengrant_type=CLIENT_CREDENTIALS&client_id=89412b6a67084fee872636e487e66970&client_secret=a547facd634f454096D9ED83CB5FA9E4";
    Dms dms = new Dms();

## OAUTH2 Access Token
Retrieve Oauth2 Access Token

    Token token = dms.GetToken(options);

## Method GET
Provide Path including country code and Distributor code as parameters

    // Get the inventorylist from Newspage
    string inv= await dms.GetInventoryAsync(options.apiPath);

## Method POST
Provide Data and Path along with country code and Distributor code as parameters

    // Create a new inventory list to post to New Page
    List<Inventory> inventory = new List<Inventory>();
    Inventory inv1 = new Inventory { distribtorCode = "119825", distribtorName = "TSTDB", warehouseCode = "TST_WHS", warehouseName = "TST_WHS_NAME", productCode = "p5", productDescription = "Cough Drops", status = "A", stockBalance = 25, allocateStock = 5, availableStock = 20, costPrice = 50.0001 };
    inventory.Add(inv1);
    Inventory inv2 = new Inventory { distribtorCode = "119825", distribtorName = "TSTDB", warehouseCode = "TST_WHS", warehouseName = "TST_WHS_NAME", productCode = "p6", productDescription = "Coladrine", status = "A", stockBalance = 25, allocateStock = 15, availableStock = 10, costPrice = 100.0001 };
    inventory.Add(inv2);

     //Post Inventory list
     var url = await dms.CreateInventoryAsync(inventory, options);

## Endpoints
The following are the endpoints available:
-	orders
-	invoices
-	inventoryItems
-	creditNotes
-	debitNotes
-	orderStatuses
-	customers
-	customerContacts
-	customerShipToAddresses
-	returns
-	productPrices
-	companyInvoices

