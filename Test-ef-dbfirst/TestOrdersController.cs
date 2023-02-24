using ef_dbfirst_tutorial;
using ef_dbfirst_tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_ef_dbfirst {

    [Collection("Sequential")]
    public class TestOrdersController {//start of class
        
        private readonly OrdersController ordCtrl;
        public TestOrdersController() {
            ordCtrl = new OrdersController();
        }

        //Test Order "TestNewOrder" for Method input
        private Order TestNewOrder = new Order() {
            Id = 0,
            CustomerId = null,
            Date = DateTime.Now,
            Description = "HERE ARE SOME WORDS"
        };

        [Theory]
        [InlineData(1, "My 1st order")]
        [InlineData(14, "My 15th order")]
        [InlineData(27, "My 99th order")]
        public async void Test1GetById(int id, string desc) {
            var order = await ordCtrl.GetByIdAsync(id);
            Assert.NotNull(order);
            Assert.Equal(desc, order.Description);
        }

        [Fact]
        public async void Test2GetAllAsync() {
            var orders = await ordCtrl.GetAllAsync();
            Assert.Equal(27, orders.Count);
            var firstord = orders.First();
            Assert.Equal("My 1st order", firstord.Description);
            Assert.Equal(1, firstord.Id);
            var lastord = orders.Last();
            Assert.Equal("My 99th order", lastord.Description);
            Assert.Equal(27, lastord.Id);
        }

        [Fact]
        public async void Test3UpdateAsync() {
            var seventh = await ordCtrl.GetByIdAsync(7);
            seventh.Description = "7777777";
            await ordCtrl.UpdateAsync(seventh);
            Assert.Equal("7777777", seventh.Description);
        }

        [Fact]
        public async void Test4InsterAsync() {
            await ordCtrl.InsertAsync(TestNewOrder);
            var orders = await ordCtrl.GetAllAsync();
            Assert.Equal(28, orders.Count);
        }

        [Fact]
        public async void Test5DeleteAsync() {
            var _orders = await ordCtrl.GetAllAsync();
            var lastord = _orders.Last();
            await ordCtrl.DeleteAsync(lastord.Id);
            var orders = await ordCtrl.GetAllAsync();
            Assert.Equal(27, orders.Count);
        }



    }//end of class
}
