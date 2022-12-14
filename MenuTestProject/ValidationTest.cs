using MenuItens.Context;
using MenuItens.Models;
using MenuItens.Validations;
using Microsoft.EntityFrameworkCore;

namespace MenuTestProject
{
    public class ValidationTest 
    {
        [Fact]
        public void Status_Validation() //Unit Test for product change status validation input
        {
            //arrange
            int val1 = 0;
            int val2 = 1;
            int val3 = 2;
            var attribute = new StatusValidation();

            //act
            var result1  = attribute.IsValid(val1);
            var result2 = attribute.IsValid(val2);
            var result3 = attribute.IsValid(val3);

            // assert
            Assert.True(result1);
            Assert.True(result2);
            Assert.False(result3);

        }
        [Fact]
        public void Type_Validation() //Unit Test for product type validation input
        {
            //arrange
            int val0 = 0;
            int val1 = 1;
            int val2 = 2;
            int val3 = 3;
            var attribute = new TypeValidation();

            //act
            var result0 = attribute.IsValid(val0);
            var result1 = attribute.IsValid(val1);
            var result2 = attribute.IsValid(val2);
            var result3 = attribute.IsValid(val3);

            //assert
            Assert.False(result0);
            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);

        }

    }
}