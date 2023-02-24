using ef_dbfirst_tutorial;
using ef_dbfirst_tutorial.Models;
using System.Security.Cryptography;


namespace Test_ef_dbfirst {
    [Collection("Sequential")]
    public class TestCustomersController {//start of class

        private readonly CustomersController custCtrl;

        private Customer NewCustomer = new Customer() {
            Id = 0, Name = "TEST CUSTOMER",
            City = "Mason", State = "OH",
            Sales = 1234.56m, Active = false
        };

        public TestCustomersController() {
            custCtrl = new CustomersController();
        }
        [Fact]
        public async void TestUpdateAsync() {
            var keycorp = await custCtrl.GetByIdAsync(18);
            keycorp.Sales = 44444.44m;
            await custCtrl.UpdateAsync(keycorp);
            keycorp = await custCtrl.GetByIdAsync(18);
            Assert.Equal(44444.44m, keycorp.Sales);
        }

        [Theory]
        [InlineData(1, 97230)]
        [InlineData(17, 91395)]
        [InlineData(35, 79482)]
        public async void TestGetByIdAsync(int id, decimal sales) {
            var customer = await custCtrl.GetByIdAsync(id);
            Assert.NotNull(customer);
            Assert.Equal(sales, customer.Sales);
        }
        [Fact]
        public async void TestGetAllAsync() {
            var customers = await custCtrl.GetAllAsync();
            Assert.Equal(36, customers.Count);
            var kroger = customers.First();
            Assert.Equal("Kroger", kroger.Name);
            Assert.Equal(1, kroger.Id);
            var deleteme = customers.Last();
            Assert.Equal("DELETE ME", deleteme.Name);
            Assert.Equal(36, deleteme.Id);
        }

    
    }//end of class
}