using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DevFramework.Norhwind.Entities.Concrete;

namespace DevFramework.Norhwind.Business.Mappings.AutoMapper.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            // product profile
            CreateMap<Product, Product>();
        }
    }
}
