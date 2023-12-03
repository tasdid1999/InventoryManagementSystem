using Ecom.Entity.Domain;
using IMS.Entity.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Data
{
    public class Context : IdentityDbContext<IdentityUser<int>,IdentityRole<int>,int>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

       
        public DbSet<Product> Product { get; set; }

        public DbSet<ProductBrand> ProductBrand { get; set; }

        public DbSet<ProductCatagory> ProductCatagory { get; set;}

        public DbSet<ProductPrice> ProductPrice { get; set; }

        public DbSet<Shop> shops { get; set; }

        public DbSet<ShopRack> shopsRack { get; set; }

        public DbSet<ShopRow> shopsRow { get; set; }

        public DbSet<ShopBin> shopsBin { get; set; }

        public DbSet<Store> store { get; set; }

        public DbSet<StoreBin> storeBin { get; set; }

        public DbSet<StoreRoom> storeRoom { get; set; }

        public DbSet<StoreRack> storeRacks { get; set; }

        public DbSet<StoreRow> storeRows { get; set; }

        public DbSet<StoreStock> storeStocks { get; set; }

        public DbSet<StoreProductStock> storeProductsStock { get; set; }

        public DbSet<StoreStockHistory> storeStockHistory { get; set; }

        public DbSet<Purchase> purchases { get; set; }

        public DbSet<ShopToShopTransfer> shopToShopTransfer { get; set;}

        public DbSet<ShopToShopTransferProduct> shopToShopTranferProduct { get; set; }

        public DbSet<RequsitionDetails> requsitionDetails { get; set;}

        public DbSet<Requsition> requsitions {  get; set; } 

        public DbSet<PurchasedProduct> purchasedProducts { get; set; }

       
       
    }
}
