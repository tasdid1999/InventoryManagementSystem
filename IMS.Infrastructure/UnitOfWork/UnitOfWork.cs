using Ecom.Infrastructure.Repository.UserRepository;
using IMS.Infrastructure.Data;
using IMS.Infrastructure.Repository.Auth;
using IMS.Infrastructure.Repository.product;
using IMS.Infrastructure.Repository.productBrand;
using IMS.Infrastructure.Repository.productCatagory;
using IMS.Infrastructure.Repository.productPrice;
using IMS.Infrastructure.Repository.purchase;
using IMS.Infrastructure.Repository.purchaseDetails;
using IMS.Infrastructure.Repository.purchasedProduct;
using IMS.Infrastructure.Repository.requsition;
using IMS.Infrastructure.Repository.requsitionDetails;
using IMS.Infrastructure.Repository.shop;
using IMS.Infrastructure.Repository.shopBin;

using IMS.Infrastructure.Repository.shopRack;
using IMS.Infrastructure.Repository.shopRow;
using IMS.Infrastructure.Repository.shopToShopTransfer;
using IMS.Infrastructure.Repository.shopToShopTransferProduct;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductBrandRepository ProductBrandRepository { get; set; }

        public IProductCatagoryRepository ProductCatagoryRepository {  get; set; }

        public IProductPriceRepository ProductPriceRepository {  get; set; }

        public IProductRepository ProductRepository {  get; set; }

        public IUserRepository UserRepository { get; set; }

        public IAuthRepository AuthRepository { get; set; }

        public IShopRepository ShopRepository {  get; set; }

        public IShopRackRepository ShopRackRepository {  get; set; }

        public IShopRowRepository ShopRowRepository { get; set; }

        public IShopBinRepository ShopBinRepository {  get; set; }

        public IRequsitionRepository RequsitionRepository { get; set; }

        public IRequsitionDetailsRepository RequsitionDetailsRepository {  get; set; }
        public IPurchaseRepository PurchaseRepository { get; set; }
        public IPurchasedProductRepository PurchasedProductRepository { get; set; }

        public IShopToShopTransferRepository ShopToShopTransferRepository { get; set; }
        public IShopToShopTransferProductRepository ShopToShopTransferProductRepository { get; set; }

        private readonly Context _context;
        private readonly SqlConnectionFactory _connectionFactory;

        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;


        public UnitOfWork(Context context, SqlConnectionFactory connectionFactory, UserManager<IdentityUser<int>> userManager, SignInManager<IdentityUser<int>> signInManager = null, RoleManager<IdentityRole<int>> roleManager = null)
        {
            _context = context;
            _connectionFactory = connectionFactory;
            ProductBrandRepository = new ProductBrandRepository(_context);
            ProductCatagoryRepository = new ProductCatagoryRepository(_context);
            ProductPriceRepository = new ProductPriceRepository(_context);
            ProductRepository = new ProductRepository(_context, _connectionFactory);
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            AuthRepository = new AuthRepository(_userManager, _signInManager, _roleManager);
            UserRepository = new UserRepository(_userManager,_roleManager);
            ShopRepository = new ShopRepository(_context);
            ShopRowRepository = new ShopRowRepository(_context);
            ShopRackRepository = new ShopRackRepository(_context);
            ShopBinRepository = new ShopBinRepository(_context);
            RequsitionDetailsRepository = new RequsitionDetailsRepository(_context);
            RequsitionRepository = new RequsitionRepository(_context, _connectionFactory);
            PurchasedProductRepository = new PurchasedProductRepository(_context, _connectionFactory);
            PurchaseRepository = new PurchaseRepository(_context, _connectionFactory);
            ShopToShopTransferRepository = new ShopToShopTransferRespository(_context, _connectionFactory);

            ShopToShopTransferProductRepository = new ShopToShopTransferProductRepository(_context);

         

        }

        public async Task<bool> SaveChangeAsync()
        {
            return await  _context.SaveChangesAsync() > 0;
        }
    }
}
