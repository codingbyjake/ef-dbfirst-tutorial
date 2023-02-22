
using ef_dbfirst_tutorial.Models;

var dbc = new SalesDbContext();

var orderWithCustomers = from o in dbc.Orders
                         join c in dbc.Customers
                            on o.CustomerId equals c.Id
                         orderby c.Name
                         select new {
                             Id = o.Id,
                             Desc = o.Description,
                             Customer = c.Name
                         };

foreach(var oc in orderWithCustomers) {
    Console.WriteLine($"{oc.Id,2} | {oc.Desc,-30} | {oc.Customer,-30}");
}

//var orders = from o in dbc.Orders
//             select o;

//foreach(var order in orders) {
//    Console.WriteLine(order.Description);
//}

//var customers = dbc.Customers.Where(x => x.City == "Cincinnati")
//                             .OrderByDescending(x => x.Sales)
//                             .ToList();

//foreach(var customer in customers) {
//    Console.WriteLine(customer.Name);
//}