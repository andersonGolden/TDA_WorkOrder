using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDADomain.DataObjects;
using TDAWorkOrderAPI.ViewModel.SetUpViewModels;

namespace TDAWorkOrderAPI.Mapping
{
    public class WorkOrderMapping : Profile
    {
        public WorkOrderMapping()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Description, DescriptionViewModel>();
            CreateMap<Measurement, MeasurementsViewModel>();
            CreateMap<WorkOrder, WorkOrderViewModel>();
        }
    }
}
