# rbdms-api-csharp
.Net/C# wrapper for RbDms REST API. The library uses OAuth2.0 authentication over HTTP protocol and interacts with the DMS rest API.

## Setup
Setup for new DMS REST API integration:

            options.uri = "http://rbdms-uat.cloudhub.io/";
            options.endpoint = "inventoryItems";
            options.oauthUri = "http://rboauth2.cloudhub.io/";
            options.client_id = "89412b6a67084fee872636e487e66970";
            options.client_secret = "a547facd634f454096D9ED83CB5FA9E4";
	        options.countryCode = "EA";
            options.dbName = "TES";
            Dms dms = new Dms();

## OAUTH2 Access Token
Retrieve Oauth2 Access Token

    Token token = dms.GetToken(options);

## Method GET
Provide api uri, endpoint, Oauth2 Uri, clientId, clientSecret, country code and Distributor code as parameters

    // Get the inventorylist from Newspage
    string inv= await dms.GetDataAsync(options);

## Method POST
Provide api uri, endpoint, Oauth2 Uri, clientId, clientSecret, country code, Distributor code and data as parameters

    // Create a new inventory list to post to New Page
    List<Inventory> inventory = new List<Inventory>();
    Inventory inv1 = new Inventory { distribtorCode = "119825", distribtorName = "TSTDB", warehouseCode = "TST_WHS", warehouseName = "TST_WHS_NAME", productCode = "p5", productDescription = "Cough Drops", status = "A", stockBalance = 25, allocateStock = 5, availableStock = 20, costPrice = 50.0001 };
    inventory.Add(inv1);
    Inventory inv2 = new Inventory { distribtorCode = "119825", distribtorName = "TSTDB", warehouseCode = "TST_WHS", warehouseName = "TST_WHS_NAME", productCode = "p6", productDescription = "Coladrine", status = "A", stockBalance = 25, allocateStock = 15, availableStock = 10, costPrice = 100.0001 };
    inventory.Add(inv2);

     //Post Inventory list
     var url = await dms.PostDataAsync(options, inventory);

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

