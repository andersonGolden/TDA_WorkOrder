using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDADomain.DataObjects;
using TDAWorkOrderAPI.ViewModel;
using TDAWorkOrderAPI.ViewModel.SetUpViewModels;

namespace TDAWorkOrderAPI.Services.Interfaces
{
    public interface ISetUpServices
    {
        #region style
        Task<ApiResponse<string>> AddNewStyle(string name);
        Task<ApiResponse<Style>> GetStyle(long id);
        Task<ApiResponse<List<Style>>> GetAllStyles();
        Task<ApiResponse<string>> UpdateStyle(StyleViewModel model);
        Task<ApiResponse<string>> DeleteStyle(long id);
        #endregion

        #region cuffs
        Task<ApiResponse<string>> AddNewCuffs(string name);
        Task<ApiResponse<Cuffs>> GetCuff(long id);
        Task<ApiResponse<List<Cuffs>>> GetAllCuffs();
        Task<ApiResponse<string>> UpdateCuff(CuffsViewModel model);
        Task<ApiResponse<string>> DeleteCuff(long id);
        #endregion

        #region Sleeve
        Task<ApiResponse<string>> AddNewSleeve(string name);
        Task<ApiResponse<Sleeve>> GetSleeve(long id);
        Task<ApiResponse<List<Sleeve>>> GetAllSleeves();
        Task<ApiResponse<string>> UpdateSleeve(SleeveViewModel model);
        Task<ApiResponse<string>> DeleteSleeve(long id);
        #endregion

        #region Neck
        Task<ApiResponse<string>> AddNewNeck(string name);
        Task<ApiResponse<Neck>> GetNeck(long id);
        Task<ApiResponse<List<Neck>>> GetAllNecks();
        Task<ApiResponse<string>> UpdateNeck(NeckViewModel model);
        Task<ApiResponse<string>> DeleteNeck(long id);
        #endregion

        #region Flap
        Task<ApiResponse<string>> AddNewFlap(string name);
        Task<ApiResponse<Flap>> GetFlap(long id);
        Task<ApiResponse<List<Flap>>> GetAllFlaps();
        Task<ApiResponse<string>> UpdateFlap(FlapViewModel model);
        Task<ApiResponse<string>> DeleteFlap(long id);
        #endregion

        #region Embroidery
        Task<ApiResponse<string>> AddNewEmbroidery(string name);
        Task<ApiResponse<Embroidery>> GetEmbroidery(long id);
        Task<ApiResponse<List<Embroidery>>> GetAllEmbroideries();
        Task<ApiResponse<string>> UpdateEmbroidery(EmbroideryViewModel model);
        Task<ApiResponse<string>> DeleteEmbroidery(long id);
        #endregion

        #region ChestPocket
        Task<ApiResponse<string>> AddNewChestPocket(string name);
        Task<ApiResponse<ChestPocket>> GetChestPocket(long id);
        Task<ApiResponse<List<ChestPocket>>> GetAllChestPockets();
        Task<ApiResponse<string>> UpdateChestPocket(ChestPocketViewModel model);
        Task<ApiResponse<string>> DeleteChestPocket(long id);
        #endregion

        #region Trousers
        Task<ApiResponse<string>> AddNewTrousers(string name);
        Task<ApiResponse<Trousers>> GetTrousers(long id);
        Task<ApiResponse<List<Trousers>>> GetAllTrousers();
        Task<ApiResponse<string>> UpdateTrousers(TrousersViewModel model);
        Task<ApiResponse<string>> DeleteTrousers(long id);
        #endregion
    }
}
