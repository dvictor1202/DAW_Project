using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DavShop.Data.Entities;
using DavShop.ViewModels;

namespace DavShop.Data
{
  public class DavMappingProfile : Profile
  {
    public DavMappingProfile()
    {
      CreateMap<Order, OrderViewModel>()
        .ForMember(o => o.OrderId, ex => ex.MapFrom(i => i.Id))
        .ReverseMap();

      CreateMap<OrderItem, OrderItemViewModel>()
        .ReverseMap();
    }
  }
}
