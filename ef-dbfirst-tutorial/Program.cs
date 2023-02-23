
using ef_dbfirst_tutorial;
using ef_dbfirst_tutorial.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;


//***********testing DeleteAsync
//var ordCtrl = new OrdersController();
//bool success = await ordCtrl.DeleteAsync(27);
//Console.WriteLine(success ? "It deleted" : "Failure!!!");

//***********testing UpdateAsync
//var ordCtrl = new OrdersController();

//var order = await ordCtrl.GetByIdAsync(28);

//order.Description += " by JW";

//bool success = await ordCtrl.UpdateAsync(order);

//Console.WriteLine(success ? "It updated" : "Failure!!!");


//*********testing InsertAsync 
//var ordCtrl = new OrdersController();

//var order = new Order() {
//    Id = 0,
//    Date = new DateTime(2023, 2, 23),
//    Description = "New New Kroger Order",
//    CustomerId = 1
//};
//bool success = await ordCtrl.InsertAsync(order);

//Console.WriteLine(success ? "It added" : "Failure!!!");
//Console.WriteLine(order);

//var custCtrl = new CustomersController();

//Console.WriteLine(success ? "OK" : "Failed");


//Delete a row by Id asynchronously
//var success = await custCtrl.DeleteAsync(390);

//
//var bootcamp = await custCtrl.GetByIdAsync(39);
//bootcamp.Sales = 5000;
//var success = await custCtrl.UpdateAsync(bootcamp);

//var cust = new Customer() {
//    Id = 0,
//    Name = "Bootcamp",
//    City = "Mason",
//    State = "OH",
//    Sales = 0,
//    Active = true
//};

//var success = await custCtrl.InsertAsync(cust);





//var cust = await custCtrl.GetByIdAsync(1);

//Console.WriteLine(cust.Name);

//foreach(var cust in await custCtrl.GetAllAsync()) {
//    Console.WriteLine(cust.Name);
//}


//var dbc = new SalesDbContext();

////var customer = await GetById(5);

//var customers = await GetAll();

//foreach(var cust in customers) {
//    Console.WriteLine(cust.Name);
//}


//async Task<Customer> GetById(int id) {
//    return await dbc.Customers.FindAsync(id);
//}

//async Task<List<Customer>> GetAll() {
//    return await dbc.Customers.ToListAsync();
//}

//linq query syntax with join
//var orderWithCustomers = from o in dbc.Orders
//                         join c in dbc.Customers
//                            on o.CustomerId equals c.Id
//                         orderby c.Name
//                         select new {
//                             Id = o.Id,
//                             Desc = o.Description,
//                             Customer = c.Name
//                         };

//foreach(var oc in orderWithCustomers) {
//    Console.WriteLine($"{oc.Id,2} | {oc.Desc,-30} | {oc.Customer,-30}");
//}

//linq query syntax
//var orders = from o in dbc.Orders
//             select o;

//foreach(var order in orders) {
//    Console.WriteLine(order.Description);
//}

//linq method syntax
//var customers = dbc.Customers.Where(x => x.City == "Cincinnati")
//                             .OrderByDescending(x => x.Sales)
//                             .ToList();

//foreach(var customer in customers) {
//    Console.WriteLine(customer.Name);
//}

//*************Asynchronous program flow example: correct ver on greg's github
//var _context = new DbContext(); // <<<< not right
//var startingNumber = 100;
//var sum = await SumNumber1to10();

//var total = sum + startingNumber;

//Console.WriteLine("Done...");

//async Task<int> SumNumber1to10() {
//   // await _context.Customers.ToListAsync();
//    int sum = 0;
//    sum += 1;
//    sum += 2;
//    sum += 3;
//    sum += 4;
//    sum += 5;
//    sum += 6;     
//    sum += 7;
//    sum += 8;
//    sum += 9;
//    sum += 10;
//    return sum;
//}