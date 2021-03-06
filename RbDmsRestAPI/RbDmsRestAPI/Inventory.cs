﻿namespace RbDmsRestAPI
{
    public class Inventory
    {
        public string distributorCode { get; set; }
        public string distributorName { get; set; }
        public string warehouseCode { get; set; }
        public string warehouseName { get; set; }
        public string productCode { get; set; }
        public string productDescription { get; set; }
        public string status { get; set; }
        public int stockBalance { get; set; }
        public int allocateStock { get; set; }
        public int availableStock { get; set; }
        public double costPrice { get; set; }
    }
}