using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.SocialMediaDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.Areas.MilkyAdmin.Controllers.Default
{
    [Area("MilkyAdmin")]
    [Route("MilkyAdmin/{controller=Home}/{action=Index}/{id?}")]
    public class SocialMediaController : Controller
    {
        private readonly DynamicConsume<ResultSocialMediaDto> _resultSocialMediaDto;
        private readonly DynamicConsume<CreateSocialMediaDto> _createSocialMediaDto;
        private readonly DynamicConsume<UpdateSocialMediaDto> _updateSocialMediaDto;
        private readonly DynamicConsume<object> _object;

        public SocialMediaController(DynamicConsume<ResultSocialMediaDto> resultSocialMediaDto, DynamicConsume<CreateSocialMediaDto> createSocialMediaDto, DynamicConsume<UpdateSocialMediaDto> updateSocialMediaDto, DynamicConsume<object> oobject)
        {
            _resultSocialMediaDto = resultSocialMediaDto;
            _createSocialMediaDto = createSocialMediaDto;
            _updateSocialMediaDto = updateSocialMediaDto;
            _object = oobject;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _resultSocialMediaDto.GetListAsync("SocialMedias/SocialMediaList");
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var values = await _createSocialMediaDto.PostAsync("SocialMedias/CreateSocialMedia", createSocialMediaDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var values = await _updateSocialMediaDto.GetByIdAsync("SocialMedias/GetSocialMediaById", id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var values = await _createSocialMediaDto.PutAsync("SocialMedias/UpdateSocialMedia", updateSocialMediaDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var values = await _object.DeleteAsync("SocialMedias/DeleteSocialMedia", id);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    } 
}
