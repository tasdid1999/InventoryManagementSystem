using Ecom.Infrastructure.Repository.UserRepository;
using IMS.Infrastructure.Repository.Auth;
using IMS.Infrastructure.Repository.product;
using IMS.Infrastructure.Repository.productBrand;
using IMS.Infrastructure.Repository.productCatagory;
using IMS.Infrastructure.Repository.productPrice;
using IMS.Infrastructure.Repository.purchase;
using IMS.Infrastructure.Repository.purchaseDetails;
using IMS.Infrastructure.Repository.requsition;
using IMS.Infrastructure.Repository.requsitionDetails;
using IMS.Infrastructure.Repository.shop;
using IMS.Infrastructure.Repository.shopBin;

using IMS.Infrastructure.Repository.shopRack;
using IMS.Infrastructure.Repository.shopRow;
using IMS.Infrastructure.Repository.shopToShopTransfer;
using IMS.Infrastructure.Repository.shopToShopTransferProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductBrandRepository ProductBrandRepository { get; }

        IProductCatagoryRepository ProductCatagoryRepository { get; }

        IProductPriceRepository ProductPriceRepository { get; }

        IProductRepository ProductRepository { get; }

        IUserRepository UserRepository { get; }

        IAuthRepository AuthRepository { get; }

        IShopRepository ShopRepository { get; }

        IShopRackRepository ShopRackRepository { get; }

        IShopRowRepository ShopRowRepository { get; }


        IShopBinRepository ShopBinRepository { get; }

        IRequsitionRepository RequsitionRepository { get; }

        IRequsitionDetailsRepository RequsitionDetailsRepository { get; }

        IPurchaseRepository PurchaseRepository { get; set; }

        IPurchasedProductRepository PurchasedProductRepository { get; set; }   

        IShopToShopTransferRepository ShopToShopTransferRepository { get; set; }

        IShopToShopTransferProductRepository ShopToShopTransferProductRepository { get; set; }
        
        Task<bool> SaveChangeAsync();
    }
}
