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

namespace TDAWorkOrderAPI.Services
{
    public class SetUpServices : ISetUpServices
    {
        private readonly IRepository<Cuffs> _cuffsRepository;
        private readonly IRepository<Style> _styleRepository;
        private readonly IRepository<Sleeve> _sleeveRepository;
        private readonly IRepository<Neck> _neckRepository;
        private readonly IRepository<Flap> _flapRepository;
        private readonly IRepository<Embroidery> _embroideryRepository;
        private readonly IRepository<ChestPocket> _chestPokectRepository;
        private readonly IRepository<Trousers> _trousersRepository;
        private ILogger<SetUpServices> _Logger;
        private readonly IUnitOfWork _unitOfWork;
        public SetUpServices(IRepository<Cuffs> cuffsRespository, ILogger<SetUpServices> logger, IUnitOfWork unitOfWork, IRepository<Style> styleRespository,
            IRepository<Sleeve> sleeveRepository, IRepository<Neck> neckRepository, IRepository<Flap> flapRepository, IRepository<Embroidery>  embroideryRepository, 
            IRepository<ChestPocket> chestPokectRepository, IRepository<Trousers> trousersRepository)
        {
            _cuffsRepository = cuffsRespository;
            _Logger = logger;
            _unitOfWork = unitOfWork;
            _styleRepository = styleRespository;
            _sleeveRepository = sleeveRepository;
            _neckRepository = neckRepository;
            _flapRepository = flapRepository;
            _embroideryRepository = embroideryRepository;
            _chestPokectRepository = chestPokectRepository;
            _trousersRepository = trousersRepository;
        }

        #region style
        public async Task<ApiResponse<string>> AddNewStyle(string name)
        {
            try
            {
                _Logger.LogInformation("About to create new style");
                var existingStyle = _styleRepository.GetAsync(c => c.Name == name).Result;
                if (existingStyle != null)
                {
                    _Logger.LogInformation($"Style already exists: {name}");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordExists);
                }

                //add new cuff style
                Style newStyle = new Style
                {
                    Name = name,
                    DateCreated = DateTime.Now,
                    LastUpdated = DateTime.Now
                };
                _styleRepository.Add(newStyle);
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Style created successfully: {name}");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordSaved);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while creating style: {name}. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<Style>> GetStyle(long id)
        {
            try
            {
                _Logger.LogInformation("About to get style details");
                var existingStyle = _styleRepository.GetAsync(c => c.ID == id).Result;
                if (existingStyle == null)
                {
                    _Logger.LogInformation($"Style does not exists");
                    return ResponseMessage.ErrorResponse<Style>(StaticMessages.RecordNotFound);
                }

                _Logger.LogInformation($"Style found");
                return ResponseMessage.SuccessResponse<Style>(existingStyle, StaticMessages.RecordRetreived);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while retrieving style details. Details: {ex}");
                return ResponseMessage.ExceptionResponse<Style>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<List<Style>>> GetAllStyles()
        {
            try
            {
                _Logger.LogInformation("About to get all styles");
                List<Style> styles = new List<Style>();
                styles = _styleRepository.GetAllAsync().Result;

                _Logger.LogInformation($"Total styles retrieved: {styles.Count}");
                return ResponseMessage.SuccessResponse<List<Style>>(styles, StaticMessages.DefaultSuccess);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while retrieving style list. Details: {ex}");
                return ResponseMessage.ExceptionResponse<List<Style>>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<string>> UpdateStyle(StyleViewModel model)
        {
            try
            {
                _Logger.LogInformation("About to update style details");
                var existingStyle = _styleRepository.GetAsync(c => c.ID == model.id).Result;
                if (existingStyle == null)
                {
                    _Logger.LogInformation($"Style does not exists");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordNotFound);
                }

                //update cuff details
                existingStyle.Name = model.name;
                existingStyle.LastUpdated = DateTime.Now;
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Style updated successfully!");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordUpdate);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while updating style details:{model.name}. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<string>> DeleteStyle(long id)
        {
            try
            {
                _Logger.LogInformation("About to delete style details");
                var existingStyle = _cuffsRepository.GetAsync(c => c.ID == id).Result;
                if (existingStyle == null)
                {
                    _Logger.LogInformation($"Style does not exists");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordNotFound);
                }
                //delete cuff record
                _cuffsRepository.Remove(existingStyle);
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Style deleted successfully!");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordDeleted);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while deleting style details. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }
        #endregion

        #region cuffs
        public async Task<ApiResponse<string>> AddNewCuffs(string name)
        {
            try
            {
                _Logger.LogInformation("About to create new cuff style");
                var existingCuffs = _cuffsRepository.GetAsync(c => c.Name == name).Result;
                if (existingCuffs != null)
                {
                    _Logger.LogInformation($"Cuffs style already exists: {name}");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordExists);
                }

                //add new cuff style
                Cuffs newCuffs = new Cuffs
                {
                    Name = name,
                    DateCreated = DateTime.Now,
                    LastUpdated = DateTime.Now
                };
                _cuffsRepository.Add(newCuffs);
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Cuffs style created successfully: {name}");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordSaved);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while creating cuff: {name}. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<Cuffs>> GetCuff(long id)
        {
            try
            {
                _Logger.LogInformation("About to get cuff detail");
                var existingCuffs = _cuffsRepository.GetAsync(c => c.ID == id).Result;
                if (existingCuffs == null)
                {
                    _Logger.LogInformation($"Cuffs style does not exists");
                    return ResponseMessage.ErrorResponse<Cuffs>(StaticMessages.RecordNotFound);
                }

                _Logger.LogInformation($"Cuffs style found");
                return ResponseMessage.SuccessResponse<Cuffs>(existingCuffs, StaticMessages.RecordRetreived);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while retrieving cuff details. Details: {ex}");
                return ResponseMessage.ExceptionResponse<Cuffs>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<List<Cuffs>>> GetAllCuffs()
        {
            try
            {
                _Logger.LogInformation("About to get all cuffs");
                List<Cuffs> cuffs = new List<Cuffs>();
                cuffs = _cuffsRepository.GetAllAsync().Result;

                _Logger.LogInformation($"Total cuffs retrieved: {cuffs.Count}");
                return ResponseMessage.SuccessResponse<List<Cuffs>>(cuffs, StaticMessages.DefaultSuccess);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while retrieving cuff list. Details: {ex}");
                return ResponseMessage.ExceptionResponse<List<Cuffs>>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<string>> UpdateCuff(CuffsViewModel model)
        {
            try
            {
                _Logger.LogInformation("About to update cuff details");
                var existingCuffs = _cuffsRepository.GetAsync(c => c.ID == model.id).Result;
                if (existingCuffs == null)
                {
                    _Logger.LogInformation($"Cuffs style does not exists");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordNotFound);
                }

                //update cuff details
                existingCuffs.Name = model.name;
                existingCuffs.LastUpdated = DateTime.Now;
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Cuffs style updated successfully!");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordUpdate);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while updating cuff details:{model.name}. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<string>> DeleteCuff(long id)
        {
            try
            {
                _Logger.LogInformation("About to delete cuff details");
                var existingCuffs = _cuffsRepository.GetAsync(c => c.ID == id).Result;
                if (existingCuffs == null)
                {
                    _Logger.LogInformation($"Cuffs style does not exists");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordNotFound);
                }
                //delete cuff record
                _cuffsRepository.Remove(existingCuffs);
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Cuffs style deleted successfully!");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordDeleted);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while deleting cuff details. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }
        #endregion

        #region Sleeve
        public async Task<ApiResponse<string>> AddNewSleeve(string name)
        {
            try
            {
                _Logger.LogInformation("About to create new sleeve");
                var existingSleeve = _sleeveRepository.GetAsync(c => c.Name == name).Result;
                if (existingSleeve != null)
                {
                    _Logger.LogInformation($"Sleeve already exists: {name}");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordExists);
                }

                //add new sleeve
                Sleeve newSleeve = new Sleeve
                {
                    Name = name,
                    DateCreated = DateTime.Now,
                    LastUpdated = DateTime.Now
                };
                _sleeveRepository.Add(newSleeve);
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Sleeve created successfully: {name}");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordSaved);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while creating sleeve: {name}. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<Sleeve>> GetSleeve(long id)
        {
            try
            {
                _Logger.LogInformation("About to get sleeve detail");
                var existingSleeve = _sleeveRepository.GetAsync(c => c.ID == id).Result;
                if (existingSleeve == null)
                {
                    _Logger.LogInformation($"Sleeve does not exists");
                    return ResponseMessage.ErrorResponse<Sleeve>(StaticMessages.RecordNotFound);
                }

                _Logger.LogInformation($"Sleeve found");
                return ResponseMessage.SuccessResponse<Sleeve>(existingSleeve, StaticMessages.RecordRetreived);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while retrieving sleeve details. Details: {ex}");
                return ResponseMessage.ExceptionResponse<Sleeve>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<List<Sleeve>>> GetAllSleeves()
        {
            try
            {
                _Logger.LogInformation("About to get all sleeve");
                List<Sleeve> sleeves = new List<Sleeve>();
                sleeves = _sleeveRepository.GetAllAsync().Result;

                _Logger.LogInformation($"Total sleeve retrieved: {sleeves.Count}");
                return ResponseMessage.SuccessResponse<List<Sleeve>>(sleeves, StaticMessages.DefaultSuccess);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while retrieving sleeve list. Details: {ex}");
                return ResponseMessage.ExceptionResponse<List<Sleeve>>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<string>> UpdateSleeve(SleeveViewModel model)
        {
            try
            {
                _Logger.LogInformation("About to update sleeve details");
                var existingSleeve = _sleeveRepository.GetAsync(c => c.ID == model.id).Result;
                if (existingSleeve == null)
                {
                    _Logger.LogInformation($"Sleeve does not exists");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordNotFound);
                }

                //update sleeve details
                existingSleeve.Name = model.name;
                existingSleeve.LastUpdated = DateTime.Now;
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Sleeve updated successfully!");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordUpdate);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while updating sleeve details:{model.name}. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<string>> DeleteSleeve(long id)
        {
            try
            {
                _Logger.LogInformation("About to delete sleeve details");
                var existingSleeve = _sleeveRepository.GetAsync(c => c.ID == id).Result;
                if (existingSleeve == null)
                {
                    _Logger.LogInformation($"Sleeve does not exists");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordNotFound);
                }
                //delete sleeve record
                _sleeveRepository.Remove(existingSleeve);
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Sleeve deleted successfully!");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordDeleted);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while deleting sleeve details. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }
        #endregion

        #region Neck
        public async Task<ApiResponse<string>> AddNewNeck(string name)
        {
            try
            {
                _Logger.LogInformation("About to create new neck");
                var existingNeck = _neckRepository.GetAsync(c => c.Name == name).Result;
                if (existingNeck != null)
                {
                    _Logger.LogInformation($"Neck already exists: {name}");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordExists);
                }

                //add new neck
                Neck newSleeve = new Neck
                {
                    Name = name,
                    DateCreated = DateTime.Now,
                    LastUpdated = DateTime.Now
                };
                _neckRepository.Add(newSleeve);
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Neck created successfully: {name}");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordSaved);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while creating neck: {name}. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<Neck>> GetNeck(long id)
        {
            try
            {
                _Logger.LogInformation("About to get neck detail");
                var existingNeck = _neckRepository.GetAsync(c => c.ID == id).Result;
                if (existingNeck == null)
                {
                    _Logger.LogInformation($"Neck does not exists");
                    return ResponseMessage.ErrorResponse<Neck>(StaticMessages.RecordNotFound);
                }

                _Logger.LogInformation($"Neck found");
                return ResponseMessage.SuccessResponse<Neck>(existingNeck, StaticMessages.RecordRetreived);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while retrieving neck details. Details: {ex}");
                return ResponseMessage.ExceptionResponse<Neck>(StaticMessages.ErrorMessage);
            }
        }
        public async Task<ApiResponse<List<Neck>>> GetAllNecks()
        {
            try
            {
                _Logger.LogInformation("About to get all neck");
                List<Neck> necks = new List<Neck>();
                necks = _neckRepository.GetAllAsync().Result;

                _Logger.LogInformation($"Total neck retrieved: {necks.Count}");
                return ResponseMessage.SuccessResponse<List<Neck>>(necks, StaticMessages.DefaultSuccess);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while retrieving neck list. Details: {ex}");
                return ResponseMessage.ExceptionResponse<List<Neck>>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<string>> UpdateNeck(NeckViewModel model)
        {
            try
            {
                _Logger.LogInformation("About to update neck details");
                var existingNeck = _neckRepository.GetAsync(c => c.ID == model.id).Result;
                if (existingNeck == null)
                {
                    _Logger.LogInformation($"Neck does not exists");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordNotFound);
                }

                //update neck details
                existingNeck.Name = model.name;
                existingNeck.LastUpdated = DateTime.Now;
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Neck updated successfully!");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordUpdate);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while updating neck details:{model.name}. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<string>> DeleteNeck(long id)
        {
            try
            {
                _Logger.LogInformation("About to delete neck details");
                var existingNeck = _neckRepository.GetAsync(c => c.ID == id).Result;
                if (existingNeck == null)
                {
                    _Logger.LogInformation($"Neck does not exists");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordNotFound);
                }
                //delete neck record
                _neckRepository.Remove(existingNeck);
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Neck deleted successfully!");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordDeleted);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while deleting neck details. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }
        #endregion

        #region Flap
        public async Task<ApiResponse<string>> AddNewFlap(string name)
        {
            try
            {
                _Logger.LogInformation("About to create new flap");
                var existingFlap = _flapRepository.GetAsync(c => c.Name == name).Result;
                if (existingFlap != null)
                {
                    _Logger.LogInformation($"Flap already exists: {name}");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordExists);
                }

                //add new flap
                Flap newFlap = new Flap
                {
                    Name = name,
                    DateCreated = DateTime.Now,
                    LastUpdated = DateTime.Now
                };
                _flapRepository.Add(newFlap);
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Flap created successfully: {name}");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordSaved);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while creating flap: {name}. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<Flap>> GetFlap(long id)
        {
            try
            {
                _Logger.LogInformation("About to get flap detail");
                var existingFlap = _flapRepository.GetAsync(c => c.ID == id).Result;
                if (existingFlap == null)
                {
                    _Logger.LogInformation($"Flap does not exists");
                    return ResponseMessage.ErrorResponse<Flap>(StaticMessages.RecordNotFound);
                }

                _Logger.LogInformation($"Flap found");
                return ResponseMessage.SuccessResponse<Flap>(existingFlap, StaticMessages.RecordRetreived);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while retrieving flap details. Details: {ex}");
                return ResponseMessage.ExceptionResponse<Flap>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<List<Flap>>> GetAllFlaps()
        {
            try
            {
                _Logger.LogInformation("About to get all flaps");
                List<Flap> flaps = new List<Flap>();
                flaps = _flapRepository.GetAllAsync().Result;

                _Logger.LogInformation($"Total flaps retrieved: {flaps.Count}");
                return ResponseMessage.SuccessResponse<List<Flap>>(flaps, StaticMessages.DefaultSuccess);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while retrieving flap list. Details: {ex}");
                return ResponseMessage.ExceptionResponse<List<Flap>>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<string>> UpdateFlap(FlapViewModel model)
        {
            try
            {
                _Logger.LogInformation("About to update flap details");
                var existingFlap = _flapRepository.GetAsync(c => c.ID == model.id).Result;
                if (existingFlap == null)
                {
                    _Logger.LogInformation($"Flap does not exists");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordNotFound);
                }

                //update flap details
                existingFlap.Name = model.name;
                existingFlap.LastUpdated = DateTime.Now;
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Flap updated successfully!");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordUpdate);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while updating flap details:{model.name}. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<string>> DeleteFlap(long id)
        {
            try
            {
                _Logger.LogInformation("About to delete flap details");
                var existingFlap = _flapRepository.GetAsync(c => c.ID == id).Result;
                if (existingFlap == null)
                {
                    _Logger.LogInformation($"Flap does not exists");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordNotFound);
                }
                //delete flap record
                _flapRepository.Remove(existingFlap);
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Flap deleted successfully!");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordDeleted);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while deleting flap details. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }
        #endregion

        #region Embroidery
        public async Task<ApiResponse<string>> AddNewEmbroidery(string name)
        {
            try
            {
                _Logger.LogInformation("About to create new embroidery");
                var existingEmbroidery = _embroideryRepository.GetAsync(c => c.Name == name).Result;
                if (existingEmbroidery != null)
                {
                    _Logger.LogInformation($"Embroidery already exists: {name}");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordExists);
                }

                //add new embroidery
                Embroidery newEmbroidery = new Embroidery
                {
                    Name = name,
                    DateCreated = DateTime.Now,
                    LastUpdated = DateTime.Now
                };
                _embroideryRepository.Add(newEmbroidery);
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Embroidery created successfully: {name}");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordSaved);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while creating embroidery: {name}. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<Embroidery>> GetEmbroidery(long id)
        {
            try
            {
                _Logger.LogInformation("About to get embroidery detail");
                var existingEmbroidery = _embroideryRepository.GetAsync(c => c.ID == id).Result;
                if (existingEmbroidery == null)
                {
                    _Logger.LogInformation($"Embroidery does not exists");
                    return ResponseMessage.ErrorResponse<Embroidery>(StaticMessages.RecordNotFound);
                }

                _Logger.LogInformation($"Embroidery found");
                return ResponseMessage.SuccessResponse<Embroidery>(existingEmbroidery, StaticMessages.RecordRetreived);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while retrieving embroidery details. Details: {ex}");
                return ResponseMessage.ExceptionResponse<Embroidery>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<List<Embroidery>>> GetAllEmbroideries()
        {
            try
            {
                _Logger.LogInformation("About to get all embroidery");
                List<Embroidery> embroideries = new List<Embroidery>();
                embroideries = _embroideryRepository.GetAllAsync().Result;

                _Logger.LogInformation($"Total embroideries retrieved: {embroideries.Count}");
                return ResponseMessage.SuccessResponse<List<Embroidery>>(embroideries, StaticMessages.DefaultSuccess);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while retrieving embroidery list. Details: {ex}");
                return ResponseMessage.ExceptionResponse<List<Embroidery>>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<string>> UpdateEmbroidery(EmbroideryViewModel model)
        {
            try
            {
                _Logger.LogInformation("About to update embroidery details");
                var existingEmbroidery = _embroideryRepository.GetAsync(c => c.ID == model.id).Result;
                if (existingEmbroidery == null)
                {
                    _Logger.LogInformation($"Embroidery does not exist");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordNotFound);
                }

                //update embroidery details
                existingEmbroidery.Name = model.name;
                existingEmbroidery.LastUpdated = DateTime.Now;
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Embroidery updated successfully!");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordUpdate);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while updating embroidery details:{model.name}. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<string>> DeleteEmbroidery(long id)
        {
            try
            {
                _Logger.LogInformation("About to delete embroidery details");
                var existingEmbroidery = _embroideryRepository.GetAsync(c => c.ID == id).Result;
                if (existingEmbroidery == null)
                {
                    _Logger.LogInformation($"Embroidery does not exists");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordNotFound);
                }
                //delete embroidery record
                _embroideryRepository.Remove(existingEmbroidery);
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Embroidery deleted successfully!");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordDeleted);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while deleting embroidery details. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }
        #endregion

        #region ChestPocket
        public async Task<ApiResponse<string>> AddNewChestPocket(string name)
        {
            try
            {
                _Logger.LogInformation("About to create new chestpocket");
                var existingChestPocket = _chestPokectRepository.GetAsync(c => c.Name == name).Result;
                if (existingChestPocket != null)
                {
                    _Logger.LogInformation($"Chestpocket already exists: {name}");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordExists);
                }

                //add new chestpocket
                ChestPocket newChestpocket = new ChestPocket
                {
                    Name = name,
                    DateCreated = DateTime.Now,
                    LastUpdated = DateTime.Now
                };
                _chestPokectRepository.Add(newChestpocket);
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Chestpocket created successfully: {name}");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordSaved);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while creating chestpocket: {name}. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<ChestPocket>> GetChestPocket(long id)
        {
            try
            {
                _Logger.LogInformation("About to get chestpocket detail");
                var existingChestPocket = _chestPokectRepository.GetAsync(c => c.ID == id).Result;
                if (existingChestPocket == null)
                {
                    _Logger.LogInformation($"ChestPocket does not exists");
                    return ResponseMessage.ErrorResponse<ChestPocket>(StaticMessages.RecordNotFound);
                }

                _Logger.LogInformation($"ChestPocket found");
                return ResponseMessage.SuccessResponse<ChestPocket>(existingChestPocket, StaticMessages.RecordRetreived);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while retrieving chestpocket details. Details: {ex}");
                return ResponseMessage.ExceptionResponse<ChestPocket>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<List<ChestPocket>>> GetAllChestPockets()
        {
            try
            {
                _Logger.LogInformation("About to get all chestpockets");
                List<ChestPocket> chestPockets = new List<ChestPocket>();
                chestPockets = _chestPokectRepository.GetAllAsync().Result;

                _Logger.LogInformation($"Total chestpockets retrieved: {chestPockets.Count}");
                return ResponseMessage.SuccessResponse<List<ChestPocket>>(chestPockets, StaticMessages.DefaultSuccess);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while retrieving chestpocket list. Details: {ex}");
                return ResponseMessage.ExceptionResponse<List<ChestPocket>>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<string>> UpdateChestPocket(ChestPocketViewModel model)
        {
            try
            {
                _Logger.LogInformation("About to update chestpocket details");
                var existingChestPocket = _chestPokectRepository.GetAsync(c => c.ID == model.id).Result;
                if (existingChestPocket == null)
                {
                    _Logger.LogInformation($"Chestpocket does not exist");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordNotFound);
                }

                //update chestpocket details
                existingChestPocket.Name = model.name;
                existingChestPocket.LastUpdated = DateTime.Now;
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Chestpocket updated successfully!");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordUpdate);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while updating chestpocket details:{model.name}. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<string>> DeleteChestPocket(long id)
        {
            try
            {
                _Logger.LogInformation("About to delete chestpocket details");
                var existingChestPocket = _chestPokectRepository.GetAsync(c => c.ID == id).Result;
                if (existingChestPocket == null)
                {
                    _Logger.LogInformation($"Chestpocket does not exists");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordNotFound);
                }
                //delete chestpocket record
                _chestPokectRepository.Remove(existingChestPocket);
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Chestpocket deleted successfully!");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordDeleted);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while deleting chestpocket details. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }
        #endregion

        #region Trousers
        public async Task<ApiResponse<string>> AddNewTrousers(string name)
        {
            try
            {
                _Logger.LogInformation("About to create new trouser");
                var existingTrousers = _trousersRepository.GetAsync(c => c.Name == name).Result;
                if (existingTrousers != null)
                {
                    _Logger.LogInformation($"Trousers already exists: {name}");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordExists);
                }

                //add new trousers
                Trousers newTrousers = new Trousers
                {
                    Name = name,
                    DateCreated = DateTime.Now,
                    LastUpdated = DateTime.Now
                };
                _trousersRepository.Add(newTrousers);
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Trousers created successfully: {name}");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordSaved);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while creating tousers: {name}. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<Trousers>> GetTrousers(long id)
        {
            try
            {
                _Logger.LogInformation("About to get trousers detail");
                var existingTrousers = _trousersRepository.GetAsync(c => c.ID == id).Result;
                if (existingTrousers == null)
                {
                    _Logger.LogInformation($"Trousers does not exists");
                    return ResponseMessage.ErrorResponse<Trousers>(StaticMessages.RecordNotFound);
                }

                _Logger.LogInformation($"Trousers found");
                return ResponseMessage.SuccessResponse<Trousers>(existingTrousers, StaticMessages.RecordRetreived);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while retrieving trousers details. Details: {ex}");
                return ResponseMessage.ExceptionResponse<Trousers>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<List<Trousers>>> GetAllTrousers()
        {
            try
            {
                _Logger.LogInformation("About to get all trousers");
                List<Trousers> trousers = new List<Trousers>();
                trousers = _trousersRepository.GetAllAsync().Result;

                _Logger.LogInformation($"Total trousers retrieved: {trousers.Count}");
                return ResponseMessage.SuccessResponse<List<Trousers>>(trousers, StaticMessages.DefaultSuccess);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while retrieving trousers list. Details: {ex}");
                return ResponseMessage.ExceptionResponse<List<Trousers>>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<string>> UpdateTrousers(TrousersViewModel model)
        {
            try
            {
                _Logger.LogInformation("About to update trousers details");
                var existingTrousers = _trousersRepository.GetAsync(c => c.ID == model.id).Result;
                if (existingTrousers == null)
                {
                    _Logger.LogInformation($"Trousers does not exist");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordNotFound);
                }

                //update trosuers details
                existingTrousers.Name = model.name;
                existingTrousers.LastUpdated = DateTime.Now;
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Trousers updated successfully!");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordUpdate);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while updating trousers details:{model.name}. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }

        public async Task<ApiResponse<string>> DeleteTrousers(long id)
        {
            try
            {
                _Logger.LogInformation("About to delete trousers details");
                var existingTrousers = _trousersRepository.GetAsync(c => c.ID == id).Result;
                if (existingTrousers == null)
                {
                    _Logger.LogInformation($"Trousers does not exists");
                    return ResponseMessage.ErrorResponse<string>(StaticMessages.RecordNotFound);
                }
                //delete trousers record
                _trousersRepository.Remove(existingTrousers);
                await _unitOfWork.Complete();

                _Logger.LogInformation($"Trousers deleted successfully!");
                return ResponseMessage.SuccessResponse<string>(StaticMessages.RecordDeleted);
            }
            catch (Exception ex)
            {
                _Logger.LogInformation($"Exception occurred while deleting trousers details. Details: {ex}");
                return ResponseMessage.ExceptionResponse<string>(StaticMessages.ErrorMessage);
            }
        }
        #endregion
    }
}
