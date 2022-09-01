using System.Collections.Generic;
using DavShop.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DavShop.Data
{
  public interface IDavRepository
  {
    IEnumerable<Product> GetAllProducts();
    IEnumerable<Product> GetProductsByCategory(string category);

    IEnumerable<Order> GetAllOrders(bool includeItems);
    IEnumerable<Order> GetOrdersByUser(string username, bool includeItems);
    Order GetOrderById(string username, int id);

    void AddEntity(object entity);
    bool SaveAll();
  }
}