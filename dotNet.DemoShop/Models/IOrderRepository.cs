using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet.DemoShop.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
