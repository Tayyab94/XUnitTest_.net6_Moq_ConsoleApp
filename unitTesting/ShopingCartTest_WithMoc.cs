using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApp.Functionality;
using Xunit;

namespace unitTesting
{
   

    public class ShopingCartTest_WithMoc
    {
        private readonly Mock<IDbService> _dbServiceMock = new();

        [Fact]
        public void AddProduct_Success()
        {
            //Given
            var shopingCart = new ShopingCart(_dbServiceMock.Object);

            // When 
            var product = new Product(1, "First Product", 44.3);
            var result= shopingCart.AddProductToShopingCart(product);

            //Assert
            Assert.True(result);
            _dbServiceMock.Verify(S => S.SaveItemToShopingCart(It.IsAny<Product>()), Times.Once);


        }

        [Fact]
        public void AddProduct_Failure_DueToInvalidPayload()
        {
            // Arrange
            
            var shopingCart = new ShopingCart(_dbServiceMock.Object);

            // Act 
            var result = shopingCart.AddProductToShopingCart(null);

            Assert.False(result);
            _dbServiceMock.Verify(S => S.SaveItemToShopingCart(It.IsAny<Product>()), Times.Never);

        }

        [Fact]

        public void DeleteProduct_Success()
        {
            // Arrange 
         
            var shopingCart = new ShopingCart(_dbServiceMock.Object);

            // Act
            var product = new Product(1, "First Product", 44.3);
            var result = shopingCart.DeleteProductFormCart(product.id);

            //Assert

            Assert.True(result);
            _dbServiceMock.Verify(S => S.RemoveItemFromShopingCart(It.IsAny<int>()), Times.Once);
        }
    }
}
