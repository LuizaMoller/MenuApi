using MenuItens.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuTestProject
{
    //Performing tests for Product Controller using the Memory Data
    public class ProductControllerTest 
    {
        private readonly ProductController _productController;

        public ProductControllerTest()
        {
            var bdInMemory = new InMemoryBD();
            var context = bdInMemory.GetContext();
            _productController = new ProductController(context);
        }

        [Fact] //Test for the GET all task
        public async Task Get_All()
        {
            //act
            var product = _productController.GetProduct();

            //assert
            Assert.NotNull(product);

        }

        [Fact] //Test for the GET Id task
        public async Task Get_Id()
        {
            //act
            var product = _productController.GetProduct(1);

            //assert
            Assert.NotNull(product);

        }


        [Fact] //Test for confirmation of active items according to the rule for type 2 product
        public async Task Active_Components_Confirmation_Type2()
        {
            //act
            var product = _productController.Active_Components_Confirmation_Type2(6);

            //assert
            Assert.False(product);

        }

        [Fact] //Test for confirmation of active items according to the rule for type 3 product
        public async Task Active_Components_Confirmation_Type3()
        {
            //act
            var product = _productController.Active_Components_Confirmation_Type3(8);

            //assert
            Assert.False(product);

        }

    }

}
