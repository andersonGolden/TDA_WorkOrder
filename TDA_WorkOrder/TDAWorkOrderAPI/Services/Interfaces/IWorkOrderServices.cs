using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDAWorkOrderAPI.ViewModel;
using TDAWorkOrderAPI.ViewModel.SetUpViewModels;

namespace TDAWorkOrderAPI.Services.Interfaces
{
    public interface IWorkOrderServices
    {
        Task<ApiResponse<string>> AddNewWorkOrder(WorkOrderViewModel model);
        Task<ApiResponse<WorkOrderViewModel>> GetWorkOrder(long id);
        Task<ApiResponse<List<WorkOrderViewModel>>> GetAllWorkOrders(DateTime? from, DateTime? to, string phone = "", int status = 0);
        Task<ApiResponse<string>> UpdateWorkOrder(WorkOrderViewModel model);
        Task<ApiResponse<string>> DeleteWorkOrder(long id);
    }
}
