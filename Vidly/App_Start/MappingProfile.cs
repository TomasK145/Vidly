﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>().ForMember(c => c.Id, opt => opt.Ignore()); //ignorovanie pre Id property
            Mapper.CreateMap<CustomerDto, Customer>();
            //automapper vyuziva refection pre ziskanie properties v objektoch a mapuje ich podla nazvov
            //Automapper je convention-based mapping tool
        }
    }
}