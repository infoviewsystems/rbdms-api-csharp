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
            options.apiPath = "npapi/inventoryItems?countryCode=EA&dbName=TEST";
            options.oauthUrl = "http://rboauth2.cloudhub.io/token?grant_type=CLIENT_CREDENTIALS&client_id=89412b6a67084fee872636e487e66970&client_secret=a547facd634f454096D9ED83CB5FA9E4";
            Dms dms = new Dms();
            
            try
            {
                //Retrieve Oauth Access Token
                Token token = dms.GetToken(options);
                
                // Create a new inventory list to post to New Page
                List<Inventory> inventory = new List<Inventory>();
                Inventory inv1 = new Inventory { distribtorCode = "119825", distribtorName = "TSTDB", warehouseCode = "TST_WHS", warehouseName = "TST_WHS_NAME", productCode = "p5", productDescription = "Cough Drops", status = "A", stockBalance = 25, allocateStock = 5, availableStock = 20, costPrice = 50.0001 };
                inventory.Add(inv1);
                Inventory inv2 = new Inventory { distribtorCode = "119825", distribtorName = "TSTDB", warehouseCode = "TST_WHS", warehouseName = "TST_WHS_NAME", productCode = "p6", productDescription = "Coladrine", status = "A", stockBalance = 25, allocateStock = 15, availableStock = 10, costPrice = 100.0001 };
                inventory.Add(inv2);

                //Post Inventory list
                var url = await dms.CreateInventoryAsync(inventory, options);
                
                // Get the inventorylist from Newspage
                string inv= await dms.GetInventoryAsync(options.apiPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
        
    }
}
