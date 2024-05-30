using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.GalleryDtos;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.Areas.MilkyAdmin.Controllers.Default
{
    [Area("MilkyAdmin")]
    [Route("MilkyAdmin/{controller=Home}/{action=Index}/{id?}")]
    public class GalleryController : Controller
    {
        private readonly DynamicConsume<ResultGalleryDto> _resultGalleryDto;
        private readonly DynamicConsume<CreateGalleryDto> _createGalleryDto;
        private readonly DynamicConsume<UpdateGalleryDto> _updateGalleryDto;
        private readonly DynamicConsume<object> _object;

        public GalleryController(DynamicConsume<ResultGalleryDto> resultGalleryDto, DynamicConsume<CreateGalleryDto> createGalleryDto, DynamicConsume<UpdateGalleryDto> updateGalleryDto, DynamicConsume<object> oobject)
        {
            _resultGalleryDto = resultGalleryDto;
            _createGalleryDto = createGalleryDto;
            _updateGalleryDto = updateGalleryDto;
            _object = oobject;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _resultGalleryDto.GetListAsync("Galleries/GalleryList");
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateGallery()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGallery(CreateGalleryDto createGalleryDto)
        {
            var values = await _createGalleryDto.PostAsync("Galleries/CreateGallery", createGalleryDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateGallery(int id)
        {
            var values = await _updateGalleryDto.GetByIdAsync("Galleries/GetGalleryById", id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGallery(UpdateGalleryDto updateGalleryDto)
        {
            var values = await _createGalleryDto.PutAsync("Galleries/UpdateGallery", updateGalleryDto);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteGallery(int id)
        {
            var values = await _object.DeleteAsync("Galleries/DeleteGallery", id);
            if (values > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    } 
}
