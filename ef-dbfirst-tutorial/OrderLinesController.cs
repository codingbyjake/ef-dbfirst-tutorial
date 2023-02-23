using ef_dbfirst_tutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_dbfirst_tutorial
{
    internal class OrderLinesController {//start of class

        private readonly SalesDbContext _context;

        public OrderLinesController() {
            _context = new SalesDbContext();
        }

        public async Task<List<OrderLine>> GetAllAsync() {
            return await _context.OrderLines.ToListAsync();
        }

        public async Task<OrderLine?> GetByIdAsync(int id) {
            return await _context.OrderLines.FindAsync(id);
        }

        public async Task<bool> InsertAsync(OrderLine ordline) {
            _context.OrderLines.Add(ordline);
            return await SaveDb();
        }

        public async Task<bool> UpdateAsync(OrderLine orderLine) {
            var ordLine = await GetByIdAsync(orderLine.Id);
            if (ordLine == null) {
                return false;
            }
            _context.Entry(orderLine).State = EntityState.Modified;
            return await SaveDb();
        }

        public async Task<bool> DeleteAsync(int id) {
            var ordline = await GetByIdAsync(id);
            if (ordline is null) {
                return false;
            }
            _context.OrderLines.Remove(ordline);
            return await SaveDb();
        }

        private async Task<bool> SaveDb() {
            var changes = await _context.SaveChangesAsync();
            return (changes == 1) ? true : false;
        }
    }//end of class
}
