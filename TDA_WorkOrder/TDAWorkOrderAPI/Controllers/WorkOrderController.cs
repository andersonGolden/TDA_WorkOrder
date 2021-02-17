using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDAWorkOrderAPI.Services.Interfaces;
using TDAWorkOrderAPI.ViewModel;
using TDAWorkOrderAPI.ViewModel.SetUpViewModels;

namespace TDAWorkOrderAPI.Controllers
{
    public class WorkOrderController : BaseController
    {
        public IWorkOrderServices _workOrderServices;
        public WorkOrderController(IWorkOrderServices workOrderServices)
        {
            _workOrderServices = workOrderServices;
        }

        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpPost]
        public async Task<IActionResult> AddNewWorkOrder([FromBody] WorkOrderViewModel model)
        {
            try
            {
                return Ok(await _workOrderServices.AddNewWorkOrder(model));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<WorkOrderViewModel>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetWorkOrder([FromQuery] long id)
        {
            try
            {
                return Ok(await _workOrderServices.GetWorkOrder(id));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<List<WorkOrderViewModel>>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetAllWorkOrders([FromQuery] DateTime? from, DateTime? to, string phone = "", int status = 0)
        {
            try
            {
                return Ok(await _workOrderServices.GetAllWorkOrders(from, to, phone, status));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpPost]
        public async Task<IActionResult> UpdateWorkOrder([FromBody] WorkOrderViewModel model)
        {
            try
            {
                return Ok(await _workOrderServices.UpdateWorkOrder(model));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpGet]
        public async Task<IActionResult> DeleteWorkOrder([FromQuery] long id)
        {
            try
            {
                return Ok(await _workOrderServices.DeleteWorkOrder(id));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }
    }
}
