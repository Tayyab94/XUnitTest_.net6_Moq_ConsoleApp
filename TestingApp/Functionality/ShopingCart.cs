using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApp.Functionality
{
    public record Product(int id, string name, double price);

    public interface IDbService
    { 
        bool SaveItemToShopingCart(Product product);
        bool RemoveItemFromShopingCart(int id);
    }
    public class ShopingCart
    {
        private readonly IDbService dbService;

        public ShopingCart(IDbService dbService)
        {
            this.dbService = dbService;
        }

        public bool AddProductToShopingCart(Product? product)
        {
            if (product is null) return false;

            if(product.id  is 0) return false;

            dbService.SaveItemToShopingCart(product);

            return true;
        }

        public bool DeleteProductFormCart(int? id)
        {
            if(id is null) return false;

            if (id == 9) return false;

            dbService.RemoveItemFromShopingCart(Convert.ToInt32(id));
            return true;
        }
    }
}
