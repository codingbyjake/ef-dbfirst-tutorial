using System;
using System.Collections.Generic;

namespace ef_dbfirst_tutorial.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public DateTime Date { get; set; }

    public string? Description { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderLine> OrderLines { get; } = new List<OrderLine>();

    public override string ToString() {
        var message = $"ORDER: ID:{Id}, CustId: {CustomerId}, Date: {Date}, Desc:{Description}, " +
            $"Customer Name: {Customer.Name}";
            foreach(var ol in OrderLines) {
            message += $"\nORDERLINE: ID: {ol.Id} | PRODUCT: {ol.Product} " +
                       $" | PRICE: {ol.Price} | QUANTITY {ol.Quantity}";
        }
        return message;
    }
}
