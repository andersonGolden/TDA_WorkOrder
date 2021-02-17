using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDADomain.DataAccess.RepoPatterns;
using TDADomain.DataObjects;
using TDAWorkOrderAPI.Services.Interfaces;
using TDAWorkOrderAPI.ViewModel;
using TDAWorkOrderAPI.ViewModel.SetUpViewModels;
using static TDADomain.BaseDataObjects.Enums;

namespace TDAWorkOrderAPI.Services
{
    public class WorkOrderServices : IWorkOrderServices
    {
        private readonly IRepository<Description> _descriptionRepository;
        private readonly IRepository<Measurement> _measurementRepository;
        private readonly IRepository<WorkOrder> _workOrderRepository;
        private readonly IRepository<Customer> _customerRepository;
        private ILogger<WorkOrderServices> _Logger;
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public WorkOrderServices(IRepository<Description> descriptionRepository, IRepository<Measurement> measurementRepository, IRepository<WorkOrder> workOrderRepository, ILogger<WorkOrderServices> logger, IUnitOfWork unitOfWork,
            IRepository<Customer> customerRepository, IMapper mapper)
        {
            _descriptionRepository = descriptionRepository;
            _measurementRepository = measurementRepository;
            _workOrderRepository = workOrderRepository;
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _mapper = mapper;
            _Logger = logger;
        }

        public async Task<ApiResponse<string>> AddNewWorkOrder(WorkOrderViewModel model)
        {
            try
            {
                _Logger.LogInformation($"About to create new workOrder for customer:{model.Customer.Phone}");

                //populate customer details for workorder
                Customer customer = _customerRepository.GetAsync(c => c.Phone == model.Customer.Phone).Result;
                if (customer == null)
                {
                    customer = new Customer
                    {
                        FirstName = model.Customer.FirstName,
                        LastName = model.Customer.LastName,
                        Phone = model.Customer.Phone,
                        DateCreated = DateTime.Now
                    };
                    _customerRepository.Add(customer);
                }

                _Logger.LogInformation($"populating description details on workOrder for customer:{model.Customer.Phone}");
                //populate description details for workorder
                Description newDescription = new Description
                {
                    Style = model.Description.Style,
                    Cuffs = model.Description.Cuffs,
                    Sleeve = model.Description.Sleeve,
                    Neck = model.Description.Neck,
                    Flap = model.Description.Flap,
                    Embroidery = model.Description.Embroidery,
                    Underlay = model.Description.Underlay,
                    MeasurementType = model.Description.MeasurementType,
                    BackDetailing = model.Description.BackDetailing,
                    ChestPocket = model.Description.ChestPocket,
                    SidePocket = model.Description.SidePocket,
                    Trousers = model.Description.Trousers,
                    DateCreated = DateTime.Now
                };

                _Logger.LogInformation($"populating measurement details on workOrder for customer:{model.Customer.Phone}");
                //populate measurement details for workOrder
                Measurement newMeasurement = new Measurement
                {
                    Neck = model.Measurement.Neck, //top section
                    Back = model.Measurement.Back,
                    Hand = model.Measurement.Hand,
                    Chest = model.Measurement.Chest,
                    Stomach = model.Measurement.Stomach,
                    TopLength = model.Measurement.TopLength,
                    Hips = model.Measurement.Hips,
                    R_S = model.Measurement.R_S,
                    Waist = model.Measurement.Waist, //trouser section
                    Thigh = model.Measurement.Thigh,
                    Sit = model.Measurement.Sit,
                    Bottom = model.Measurement.Bottom,
                    Calf = model.Measurement.Calf,
                    TrouserLength = model.Measurement.TrouserLength,
                    AgbadaLength = model.Measurement.AgbadaLength, //agbada section
                    AgbadaWidth = model.Measurement.AgbadaWidth,
                    Head = model.Measurement.Head,
                    DateCreated = DateTime.Now
                };

                //insert description and measurement records
                _descriptionRepository.Add(newDescription);
                _measurementRepository.Add(newMeasurement);
                await _unitOfWork.Complete();

                WorkOrder newWorkOrder = new WorkOrder
                {
                    CustomerId = customer.ID,
                    DescriptionId = newDescription.ID,
                    MeasurementId = newMeasurement.ID,
                    Status = (WorkOrderStatus)1,
                    Remarks = model.Remarks,
                    MC = model.MC,
                    Cut = model.Cut,
                    Top = model.Top,
                    Tro = model.Tro,
                    Others = model.Others,
                    Fin_Button = model.Fin_Button,
                    DateCreated = DateTime.Now
                };
                _workOrderRepository.Add(newWorkOrder);

                //persist to db
                await _unitOfWork.Complete();

                _Logger.LogInformation($"WorkOrder created successfully for: {model.Customer.Phone}");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordSaved);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while creating workOrder for: {model.Customer.Phone}. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<WorkOrderViewModel>> GetWorkOrder(long id)
        {
            try
            {
                _Logger.LogInformation($"About to retrieve workOrder detail");
                var existingWorkOrder = _workOrderRepository.GetAllIncludingAsync(wo => wo.Description ,wo => wo.Measurement, wo => wo.Customer).Result
                                        .FirstOrDefault(wo => wo.ID == id);
                if (existingWorkOrder == null)
                {
                    _Logger.LogInformation($"WorkOrder does not exist");
                    return ResponseMessage.ErrorResponse<WorkOrderViewModel>(StaticMessages.RecordNotFound);
                }
                ////get description detail for workOrder
                //Description description = _descriptionRepository.GetAsync(d => d.ID == existingWorkOrder.DescriptionId).Result;

                //populate viewmodel for workorder
                WorkOrderViewModel viewModel = new WorkOrderViewModel
                {
                    Id = existingWorkOrder.ID,
                    Customer = new CustomerViewModel 
                    { 
                        Id = existingWorkOrder.Customer.ID,
                        FirstName = existingWorkOrder.Customer.FirstName,
                        LastName = existingWorkOrder.Customer.LastName,
                        Phone = existingWorkOrder.Customer.Phone,
                    },
                    Description = new DescriptionViewModel
                    {
                        Id = existingWorkOrder.Description.ID,
                        Style = existingWorkOrder.Description.Style,
                        Cuffs = existingWorkOrder.Description.Cuffs,
                        Sleeve = existingWorkOrder.Description.Sleeve,
                        Neck = existingWorkOrder.Description.Neck,
                        Flap = existingWorkOrder.Description.Flap,
                        Embroidery = existingWorkOrder.Description.Embroidery,
                        Underlay = existingWorkOrder.Description.Underlay,
                        MeasurementType = existingWorkOrder.Description.MeasurementType,
                        BackDetailing = existingWorkOrder.Description.BackDetailing,
                        ChestPocket = existingWorkOrder.Description.ChestPocket,
                        SidePocket = existingWorkOrder.Description.SidePocket,
                        Trousers = existingWorkOrder.Description.Trousers
                    },
                    Measurement = new MeasurementsViewModel
                    {
                        Id = existingWorkOrder.Measurement.ID,
                        Neck = existingWorkOrder.Measurement.Neck,
                        Back = existingWorkOrder.Measurement.Back,
                        Hand = existingWorkOrder.Measurement.Hand,
                        Chest = existingWorkOrder.Measurement.Chest,
                        Stomach = existingWorkOrder.Measurement.Stomach,
                        TopLength = existingWorkOrder.Measurement.TopLength,
                        Hips = existingWorkOrder.Measurement.Hips,
                        R_S = existingWorkOrder.Measurement.R_S,
                        Waist = existingWorkOrder.Measurement.Waist,
                        Thigh = existingWorkOrder.Measurement.Thigh,
                        Sit = existingWorkOrder.Measurement.Sit,
                        Bottom = existingWorkOrder.Measurement.Bottom,
                        Calf = existingWorkOrder.Measurement.Calf,
                        TrouserLength = existingWorkOrder.Measurement.TrouserLength,
                        AgbadaLength = existingWorkOrder.Measurement.AgbadaLength,
                        AgbadaWidth = existingWorkOrder.Measurement.AgbadaWidth,
                        Head = existingWorkOrder.Measurement.Head,
                    },
                    Status = (int)existingWorkOrder.Status,
                    Remarks = existingWorkOrder.Remarks,
                    MC = existingWorkOrder.MC,
                    Cut = existingWorkOrder.Cut,
                    Top = existingWorkOrder.Top,
                    Tro = existingWorkOrder.Tro,
                    Others = existingWorkOrder.Others,
                    Fin_Button = existingWorkOrder.Fin_Button,
                    DateCreated = existingWorkOrder.DateCreated,
                    LastUpdated = existingWorkOrder.LastUpdated
                };

                _Logger.LogInformation($"WorkOrder found");
                return ResponseMessage.SuccessResponse<WorkOrderViewModel>(viewModel, StaticMessages.RecordRetreived);
                
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while retrieving workOrder. Details: {ex}");
                return ResponseMessage.ExceptionResponse<WorkOrderViewModel>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<List<WorkOrderViewModel>>> GetAllWorkOrders(DateTime? from, DateTime? to, string phone = "", int status = 0)
        {
            try
            {
                _Logger.LogInformation("About to get all workorders");
                List<WorkOrderViewModel> workOrdersModelList = new List<WorkOrderViewModel>();
                IEnumerable<WorkOrder> workOrders = new List<WorkOrder>();
                var workOrderStats = (WorkOrderStatus)status;
                if (from.HasValue & to == null)
                {
                    workOrders = _workOrderRepository.GetAllIncludingAsync(wo => wo.Description, wo => wo.Measurement, wo => wo.Customer).Result.
                    Where(wo => wo.DateCreated >= from.Value & (wo.Status == workOrderStats || workOrderStats == 0) & (wo.Customer.Phone == phone || phone == ""));
                }
                if (to.HasValue & from == null)
                {
                    workOrders = _workOrderRepository.GetAllIncludingAsync(wo => wo.Description, wo => wo.Measurement, wo => wo.Customer).Result.
                    Where(wo => wo.DateCreated <= to.Value & (wo.Status == workOrderStats || workOrderStats == 0) & (wo.Customer.Phone == phone || phone == ""));
                }
                if (from.HasValue & to.HasValue)
                {
                    workOrders = _workOrderRepository.GetAllIncludingAsync(wo => wo.Description, wo => wo.Measurement, wo => wo.Customer).Result.
                    Where(wo => wo.DateCreated >= from.Value & (wo.Status == workOrderStats || workOrderStats == 0) && (wo.DateCreated <= to.Value & wo.Customer.Phone == phone || phone == ""));
                }
                if (from == null & to == null)
                {
                    workOrders = _workOrderRepository.GetAllIncludingAsync(wo => wo.Description, wo => wo.Measurement, wo => wo.Customer).Result.
                    Where(wo => wo.DateCreated >= DateTime.Now.AddHours(-24) & (wo.Status == workOrderStats || workOrderStats == 0) & (wo.Customer.Phone == phone || phone == ""));
                }

                foreach (var workOrder in workOrders)
                {
                    WorkOrderViewModel workOrdersModel = _mapper.Map<WorkOrder, WorkOrderViewModel>(workOrder);
                    workOrdersModelList.Add(workOrdersModel);
                }

                _Logger.LogInformation($"Total workOrders retrieved: {workOrdersModelList.Count}");
                return ResponseMessage.SuccessResponse<List<WorkOrderViewModel>>(workOrdersModelList, StaticMessages.DefaultSuccess);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while retrieving trousers list. Details: {ex}");
                return ResponseMessage.ExceptionResponse<List<WorkOrderViewModel>>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<string>> UpdateWorkOrder(WorkOrderViewModel model)
        {
            try
            {
                _Logger.LogInformation("About to update workOrder details");
                var existingWorkOrder = _workOrderRepository.GetAllIncludingAsync(wo => wo.Description, wo => wo.Measurement, wo => wo.Customer).Result
                                        .FirstOrDefault(wo => wo.ID == model.Id);
                if (existingWorkOrder == null)
                {
                    _Logger.LogInformation($"WorkOrder does not exist");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordNotFound);
                }

                //update workOrder details
                _Logger.LogInformation($"updating customer info on workOrder for customer:{model.Customer.Phone}");
                existingWorkOrder.Customer.FirstName = model.Customer.FirstName;
                existingWorkOrder.Customer.LastName = model.Customer.LastName;
                
                _Logger.LogInformation($"updating description details on workOrder for customer:{model.Customer.Phone}");
                //update description details for workorder
                existingWorkOrder.Description.Style = model.Description.Style;
                existingWorkOrder.Description.Cuffs = model.Description.Cuffs;
                existingWorkOrder.Description.Sleeve = model.Description.Sleeve;
                existingWorkOrder.Description.Neck = model.Description.Neck;
                existingWorkOrder.Description.Flap = model.Description.Flap;
                existingWorkOrder.Description.Embroidery = model.Description.Embroidery;
                existingWorkOrder.Description.Underlay = model.Description.Underlay;
                existingWorkOrder.Description.MeasurementType = model.Description.MeasurementType;
                existingWorkOrder.Description.BackDetailing = model.Description.BackDetailing;
                existingWorkOrder.Description.ChestPocket = model.Description.ChestPocket;
                existingWorkOrder.Description.SidePocket = model.Description.SidePocket;
                existingWorkOrder.Description.Trousers = model.Description.Trousers;
                existingWorkOrder.Description.LastUpdated = DateTime.Now;

                _Logger.LogInformation($"updating measurement details on workOrder for customer:{model.Customer.Phone}");
                //update measurement details for workOrder
                existingWorkOrder.Measurement.Neck = model.Measurement.Neck; //top section
                existingWorkOrder.Measurement.Back = model.Measurement.Back;
                existingWorkOrder.Measurement.Hand = model.Measurement.Hand;
                existingWorkOrder.Measurement.Chest = model.Measurement.Chest;
                existingWorkOrder.Measurement.Stomach = model.Measurement.Stomach;
                existingWorkOrder.Measurement.TopLength = model.Measurement.TopLength;
                existingWorkOrder.Measurement.Hips = model.Measurement.Hips;
                existingWorkOrder.Measurement.R_S = model.Measurement.R_S;
                existingWorkOrder.Measurement.Waist = model.Measurement.Waist; //trouser section
                existingWorkOrder.Measurement.Thigh = model.Measurement.Thigh;
                existingWorkOrder.Measurement.Sit = model.Measurement.Sit;
                existingWorkOrder.Measurement.Bottom = model.Measurement.Bottom;
                existingWorkOrder.Measurement.Calf = model.Measurement.Calf;
                existingWorkOrder.Measurement.TrouserLength = model.Measurement.TrouserLength;
                existingWorkOrder.Measurement.AgbadaLength = model.Measurement.AgbadaLength; //agbada section
                existingWorkOrder.Measurement.AgbadaWidth = model.Measurement.AgbadaWidth;
                existingWorkOrder.Measurement.Head = model.Measurement.Head;
                existingWorkOrder.Measurement.LastUpdated = DateTime.Now;

                //update workoorder primary details
                existingWorkOrder.Status = (WorkOrderStatus)model.Status;
                existingWorkOrder.Remarks = model.Remarks;
                existingWorkOrder.MC = model.MC;
                existingWorkOrder.Cut = model.Cut;
                existingWorkOrder.Top = model.Top;
                existingWorkOrder.Tro = model.Tro;
                existingWorkOrder.Others = model.Others;
                existingWorkOrder.Fin_Button = model.Fin_Button;
                existingWorkOrder.LastUpdated = DateTime.Now;

                await _unitOfWork.Complete();

                _Logger.LogInformation($"WorkOrder updated successfully!");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordUpdate);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while updating workOrder details:{model.Customer.Phone}. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<string>> DeleteWorkOrder(long id)
        {
            try
            {
                _Logger.LogInformation("About to delete workOrder details");
                var existingWorkOrder = _workOrderRepository.GetAsync(c => c.ID == id).Result;
                if (existingWorkOrder == null)
                {
                    _Logger.LogInformation($"WorkOrder does not exist");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordNotFound);
                }
                //delete workorder record
                _workOrderRepository.Remove(existingWorkOrder);
                await _unitOfWork.Complete();

                _Logger.LogInformation($"WorkOrder deleted successfully!");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordDeleted);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while deleting workorder details. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }
    }
}
