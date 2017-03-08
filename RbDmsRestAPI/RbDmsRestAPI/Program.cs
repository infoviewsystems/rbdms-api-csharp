using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RbDmsRestAPI
{
    class Program
    {
        static void Main()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            Options options = new Options();
            options.uri = "http://rbdms-uat.cloudhub.io/";
            options.endpoint = "inventoryItems";
            options.oauthUri = "http://rboauth2.cloudhub.io/";
            options.client_id = "89412b6a67084fee872636e487e66970";
            options.client_secret = "a547facd634f454096D9ED83CB5FA9E4";
            options.countryCode = "EA";
            options.dbName = "TEST";
            Dms dms = new Dms();
            
            try
            {
                //Retrieve Oauth Access Token
                Token token = dms.GetToken(options);
                
                // Create a new inventory list to post to New Page
                List<Inventory> inventory = new List<Inventory>();
                Inventory inv1 = new Inventory { distributorCode = "119825", distributorName = "TSTDB", warehouseCode = "TST_WHS", warehouseName = "TST_WHS_NAME", productCode = "p5", productDescription = "Cough Drops", status = "A", stockBalance = 25, allocateStock = 5, availableStock = 20, costPrice = 50.0001 };
                inventory.Add(inv1);
                Inventory inv2 = new Inventory { distributorCode = "119825", distributorName = "TSTDB", warehouseCode = "TST_WHS", warehouseName = "TST_WHS_NAME", productCode = "p6", productDescription = "Coladrine", status = "A", stockBalance = 25, allocateStock = 15, availableStock = 10, costPrice = 100.0001 };
                inventory.Add(inv2);

                Console.WriteLine($"Inventory Sample:\n");
                //Post Inventory list
                var url = await dms.PostDataAsync(options, inventory);
                
                // Get the inventorylist from Newspage
                string inv= await dms.GetDataAsync(options);
                
                /*----
                //Customers Sample
                */
                options.endpoint = "customers";
                // Create a new customer list to post to New Page
                List<Customer> customer = new List<Customer>();
                Customer cus1 = new Customer { distributorCode = "35100121", customerCode = "CT0000000075", customerName = "GCH RETAIL (M) SDN BHD", customerName2 = "", customerReferenceNo = "F23G0008", customerBarCode = "F23G0008", openAccountDate = "2016-09-09", registrationNo = "", type = "Q", communication = 0, relationship = 0, priceGroup = "1", groupDiscount = "", mrpBillingMethod = "", subDistributor = 0, geography = "MY", distributorChannel = "MY", outletTypeCode = "SMT", keyAccountGroup = "", keyAccountRegionalGroup = "", soldToAddress1 = "BANDAR BARU KENINGAU", soldToAddress2 = "JALAN APIN-APIN", soldToCity = "KENINGAU SABAH", soldToState = "", soldToAddress5 = "", postalCode = "89008", billToCode = "CT0000000060", contactPerson = "RICHARD VILUS", telephoneNumber = "198081945", extension = "", additionalTelephoneNumber = "", mobileNumber = "", faxNumber = "", emailAddress = "", terms = "60", creditLimit = 30000.0075, customerDiscount = 4.99, taxExemption = 1, exemptionNo = "", taxRegistrationNo = "GST 001952423936", municipalRegistrationNo = "", specialInstructions = "", bank = "", bankBranch = "", bankAccountNo = "", openingBalance = 100.0075, asOfDate = "2017-09-09", dkaCustomer = 0, seasonalCustomer = 0, seasonStartDate = "0101", seasonEndDate = "1231", longitude = "", latitude = "", userDefinedField1 = "", userDefinedField2 = "", userDefinedField3 = "", userDefinedField4 = "", userDefinedField5 = "", hqUserDefinedField1 = "", hqUserDefinedField2 = "", hqUserDefinedField3 = "", hqUserDefinedField4 = "", hqUserDefinedField5 = "", visionStore = 0, shelfReplenishment = 0, digitalFacing = 0, numberOfSKUsListed = 0 };
                customer.Add(cus1);
                Customer cus2 = new Customer { distributorCode = "35100121", customerCode = "CT0000000076", customerName = "GCH RETAIL (M) SDN BHD", customerName2 = "", customerReferenceNo = "F23G0009", customerBarCode = "F23G0009", openAccountDate = "2016-09-09", registrationNo = "", type = "Q", communication = 0, relationship = 0, priceGroup = "1", groupDiscount = "", mrpBillingMethod = "", subDistributor = 0, geography = "MY", distributorChannel = "MY", outletTypeCode = "SMT", keyAccountGroup = "", keyAccountRegionalGroup = "", soldToAddress1 = "BANDAR BARU KENINGAU", soldToAddress2 = "JALAN APIN-APIN", soldToCity = "KENINGAU SABAH", soldToState = "", soldToAddress5 = "", postalCode = "89008", billToCode = "CT0000000060", contactPerson = "RICHARD VILUS", telephoneNumber = "198081945", extension = "", additionalTelephoneNumber = "", mobileNumber = "", faxNumber = "", emailAddress = "", terms = "60", creditLimit = 30000.0075, customerDiscount = 4.99, taxExemption = 1, exemptionNo = "", taxRegistrationNo = "GST 001952423936", municipalRegistrationNo = "", specialInstructions = "", bank = "", bankBranch = "", bankAccountNo = "", openingBalance = 100.0075, asOfDate = "2017-09-09", dkaCustomer = 0, seasonalCustomer = 0, seasonStartDate = "0101", seasonEndDate = "1231", longitude = "", latitude = "", userDefinedField1 = "", userDefinedField2 = "", userDefinedField3 = "", userDefinedField4 = "", userDefinedField5 = "", hqUserDefinedField1 = "", hqUserDefinedField2 = "", hqUserDefinedField3 = "", hqUserDefinedField4 = "", hqUserDefinedField5 = "", visionStore = 0, shelfReplenishment = 0, digitalFacing = 0, numberOfSKUsListed = 0 };
                customer.Add(cus2);

                Console.WriteLine($"Customers Sample:\n");
                //Post customers list
                url = await dms.PostDataAsync(options, customer);

                // Get the customers list from Newspage
                string cust = await dms.GetDataAsync(options);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
        
    }
}
