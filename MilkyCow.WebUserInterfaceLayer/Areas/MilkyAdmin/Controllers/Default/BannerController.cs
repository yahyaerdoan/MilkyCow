using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.BannerDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.Areas.MilkyAdmin.Controllers.Default
{
    [Area("MilkyAdmin")]
    [Route("MilkyAdmin/{controller=Home}/{action=Index}/{id?}")]
    public class BannerController : Controller
    {
        private readonly DynamicConsume<ResultBannerDto> _resultBannerDto;
        private readonly DynamicConsume<CreateBannerDto> _createBannerDto;
        private readonly DynamicConsume<UpdateBannerDto> _updateBannerDto;
        private readonly DynamicConsume<object> _object;

        public BannerController(DynamicConsume<ResultBannerDto> resultBannerDto, DynamicConsume<CreateBannerDto> createBannerDto, DynamicConsume<UpdateBannerDto> updateBannerDto, DynamicConsume<object> oobject)
        {
            _resultBannerDto = resultBannerDto;
            _createBannerDto = createBannerDto;
            _updateBannerDto = updateBannerDto;
            _object = oobject;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _resultBannerDto.GetListAsync("Banners/BannerList");
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            var values = await _createBannerDto.PostAsync("Banneres/CreateBanner", createBannerDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var values = await _updateBannerDto.GetByIdAsync("Banners/GetBannerById", id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            var values = await _createBannerDto.PutAsync("Banners/UpdateBanner", updateBannerDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteBanner(int id)
        {
            var values = await _object.DeleteAsync("Banners/DeleteBanner", id);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    } 
}
