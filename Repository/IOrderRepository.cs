using MusicStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Repository
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
