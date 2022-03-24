using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApp.Functionality;
using Xunit;

namespace unitTesting
{
    public class DbService : IDbService
    {
        public bool ProcessResult { get; set; }
        public Product ProductBeingProcessed { get; set; }
        public int ProductIdBeingProcessed { get; set; }
        public bool RemoveItemFromShopingCart(int id)
        {   
            if(id==0)
                return false;
            ProductIdBeingProcessed = id;

            return ProcessResult;
        }

        public bool SaveItemToShopingCart(Product product)
        {
            if(product is null) return false;

            ProductBeingProcessed = product;

            return ProcessResult;
        }
    }

    public class ShopingCartTest
    {
        [Fact]
        public void AddProduct_Success()
        {
            //Given
            var dbMock = new DbService();

            dbMock.ProcessResult = true;

            var shopingCart = new ShopingCart(dbMock);

            // When 
            var product = new Product(1, "First Product", 44.3);
            var result= shopingCart.AddProductToShopingCart(product);

            //Assert
            Assert.True(result);
            Assert.Equal(result, dbMock.ProcessResult);
            Assert.Equal("First Product", dbMock.ProductBeingProcessed.name);

        }

        [Fact]
        public void AddProduct_Failure_DueToInvalidPayload()
        {
            // Arrange
            var dbMock= new DbService();
            dbMock.ProcessResult = false;

            var shopingCart = new ShopingCart(dbMock);

            // Act 
            var result = shopingCart.AddProductToShopingCart(null);

            Assert.False(result);
            Assert.Equal(result, dbMock.ProcessResult);
        }

        [Fact]

        public void DeleteProduct_Success()
        {
            // Arrange 
            var dbMock =new  DbService();
            dbMock.ProcessResult = true;
            var shopingCart = new ShopingCart(dbMock);

            // Act
            var product = new Product(1, "First Product", 44.3);
            var result = shopingCart.DeleteProductFormCart(product.id);

            //Assert

            Assert.True(result);
            Assert.Equal(result, dbMock.ProcessResult);



        }
    }
}
