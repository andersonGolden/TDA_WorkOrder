using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TDADomain.DataObjects;
using TDAWorkOrderAPI.Services.Interfaces;
using TDAWorkOrderAPI.ViewModel;
using TDAWorkOrderAPI.ViewModel.SetUpViewModels;

namespace TDAWorkOrderAPI.Controllers
{
    public class SetUpController : BaseController
    {
        public ISetUpServices _setUpServices;
        public SetUpController(ISetUpServices setUpServices)
        {
            _setUpServices = setUpServices;
        }

        #region cuffs
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpGet]
        public async Task<IActionResult> AddNewCuffs([FromQuery] string cuffName)
        {
            try
            {
                return Ok(await _setUpServices.AddNewCuffs(cuffName));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<Cuffs>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetCuff([FromQuery] long id)
        {
            try
            {
                return Ok(await _setUpServices.GetCuff(id));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<List<Cuffs>>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetAllCuffs()
        {
            try
            {
                return Ok(await _setUpServices.GetAllCuffs());
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpPost]
        public async Task<IActionResult> UpdateCuffs([FromBody] CuffsViewModel model)
        {
            try
            {
                return Ok(await _setUpServices.UpdateCuff(model));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpGet]
        public async Task<IActionResult> DeleteCuffs([FromQuery] long id)
        {
            try
            {
                return Ok(await _setUpServices.DeleteCuff(id));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }
        #endregion

        #region style
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpGet]
        public async Task<IActionResult> AddNewStyle([FromQuery] string styleName)
        {
            try
            {
                return Ok(await _setUpServices.AddNewStyle(styleName));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<Style>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetStyle([FromQuery] long id)
        {
            try
            {
                return Ok(await _setUpServices.GetStyle(id));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<List<Style>>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetAllStyles()
        {
            try
            {
                return Ok(await _setUpServices.GetAllStyles());
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpPost]
        public async Task<IActionResult> UpdateStyle([FromBody] StyleViewModel model)
        {
            try
            {
                return Ok(await _setUpServices.UpdateStyle(model));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpGet]
        public async Task<IActionResult> DeleteStyle([FromQuery] long id)
        {
            try
            {
                return Ok(await _setUpServices.DeleteStyle(id));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }
        #endregion

        #region Sleeve
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpGet]
        public async Task<IActionResult> AddNewSleeve([FromQuery] string sleeveName)
        {
            try
            {
                return Ok(await _setUpServices.AddNewSleeve(sleeveName));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<Sleeve>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetSleeve([FromQuery] long id)
        {
            try
            {
                return Ok(await _setUpServices.GetSleeve(id));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<List<Sleeve>>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetAllSleeves()
        {
            try
            {
                return Ok(await _setUpServices.GetAllSleeves());
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpPost]
        public async Task<IActionResult> UpdateSleeve([FromBody] SleeveViewModel model)
        {
            try
            {
                return Ok(await _setUpServices.UpdateSleeve(model));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpGet]
        public async Task<IActionResult> DeleteSleeve([FromQuery] long id)
        {
            try
            {
                return Ok(await _setUpServices.DeleteSleeve(id));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }
        #endregion

        #region Neck
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpGet]
        public async Task<IActionResult> AddNewNeck([FromQuery] string neckName)
        {
            try
            {
                return Ok(await _setUpServices.AddNewNeck(neckName));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<Neck>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetNeck([FromQuery] long id)
        {
            try
            {
                return Ok(await _setUpServices.GetNeck(id));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<List<Neck>>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetAllNecks()
        {
            try
            {
                return Ok(await _setUpServices.GetAllNecks());
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpPost]
        public async Task<IActionResult> UpdateNeck([FromBody] NeckViewModel model)
        {
            try
            {
                return Ok(await _setUpServices.UpdateNeck(model));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpGet]
        public async Task<IActionResult> DeleteNeck([FromQuery] long id)
        {
            try
            {
                return Ok(await _setUpServices.DeleteNeck(id));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }
        #endregion

        #region Flap
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpGet]
        public async Task<IActionResult> AddNewFlap([FromQuery] string flapName)
        {
            try
            {
                return Ok(await _setUpServices.AddNewFlap(flapName));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<Flap>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetFlap([FromQuery] long id)
        {
            try
            {
                return Ok(await _setUpServices.GetFlap(id));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<List<Flap>>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetAllFlaps()
        {
            try
            {
                return Ok(await _setUpServices.GetAllFlaps());
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpPost]
        public async Task<IActionResult> UpdateFlap([FromBody] FlapViewModel model)
        {
            try
            {
                return Ok(await _setUpServices.UpdateFlap(model));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpGet]
        public async Task<IActionResult> DeleteFlap([FromQuery] long id)
        {
            try
            {
                return Ok(await _setUpServices.DeleteFlap(id));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }
        #endregion

        #region Embroidery
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpGet]
        public async Task<IActionResult> AddNewEmbroidery([FromQuery] string embroideryName)
        {
            try
            {
                return Ok(await _setUpServices.AddNewEmbroidery(embroideryName));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<Embroidery>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetEmbroidery([FromQuery] long id)
        {
            try
            {
                return Ok(await _setUpServices.GetEmbroidery(id));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<List<Embroidery>>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetAllEmbroideries()
        {
            try
            {
                return Ok(await _setUpServices.GetAllEmbroideries());
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpPost]
        public async Task<IActionResult> UpdateEmbroidery([FromBody] EmbroideryViewModel model)
        {
            try
            {
                return Ok(await _setUpServices.UpdateEmbroidery(model));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpGet]
        public async Task<IActionResult> DeleteEmbroidery([FromQuery] long id)
        {
            try
            {
                return Ok(await _setUpServices.DeleteEmbroidery(id));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }
        #endregion

        #region ChestPocket
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpGet]
        public async Task<IActionResult> AddNewChestPocket([FromQuery] string chestPocketName)
        {
            try
            {
                return Ok(await _setUpServices.AddNewChestPocket(chestPocketName));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<ChestPocket>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetChestPocket([FromQuery] long id)
        {
            try
            {
                return Ok(await _setUpServices.GetChestPocket(id));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<List<ChestPocket>>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetAllChestPockets()
        {
            try
            {
                return Ok(await _setUpServices.GetAllChestPockets());
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpPost]
        public async Task<IActionResult> UpdateChestPocket([FromBody] ChestPocketViewModel model)
        {
            try
            {
                return Ok(await _setUpServices.UpdateChestPocket(model));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpGet]
        public async Task<IActionResult> DeleteChestPocket([FromQuery] long id)
        {
            try
            {
                return Ok(await _setUpServices.DeleteChestPocket(id));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }
        #endregion

        #region Trousers
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpGet]
        public async Task<IActionResult> AddNewTrousers([FromQuery] string trousersName)
        {
            try
            {
                return Ok(await _setUpServices.AddNewTrousers(trousersName));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<Trousers>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetTrousers([FromQuery] long id)
        {
            try
            {
                return Ok(await _setUpServices.GetTrousers(id));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<List<Trousers>>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetAllTrousers()
        {
            try
            {
                return Ok(await _setUpServices.GetAllTrousers());
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpPost]
        public async Task<IActionResult> UpdateTrousers([FromBody] TrousersViewModel model)
        {
            try
            {
                return Ok(await _setUpServices.UpdateTrousers(model));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [HttpGet]
        public async Task<IActionResult> DeleteTrousers([FromQuery] long id)
        {
            try
            {
                return Ok(await _setUpServices.DeleteTrousers(id));
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }
        #endregion
    }
}
