using Microsoft.AspNetCore.Mvc;
using MilkyCow.DataTransferObjectLayer.Concrete.SliderDtos;
using MilkyCow.EntityLayer.Concrete;
using MilkyCow.WebUserInterfaceLayer.Extensions.DynamicBaseConsume;

namespace MilkyCow.WebUserInterfaceLayer.ViewComponents.LayoutViewComponents
{
    public class LayoutSliderViewComponentPartial : ViewComponent
    {
        private readonly DynamicConsume<ResultSliderDto> _resultSliderDto;

        public LayoutSliderViewComponentPartial(DynamicConsume<ResultSliderDto> resultSliderDto)
        {
            _resultSliderDto = resultSliderDto;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _resultSliderDto.GetListAsync("Sliders/SliderList");
            var filteredValues = values.Where(x => x.Status).ToList();

            #region option 1
            //List<ResultSliderDto> sliderValues = new();
            //foreach (var value in values)
            //{
            //    if (value.Status)
            //    {
            //        sliderValues.Add(value);
            //    }
            //}
            #endregion

            #region option 2
            //List<ResultSliderDto> sliderValues = new();
            //values.ForEach(x => {
            //    if (x.Status)
            //    {
            //        sliderValues.Add(x);
            //    }
            //});
            #endregion  
            
            #region option 3
            //var filteredValues = new List<ResultSliderDto>();

            //foreach (var value in values)
            //{
            //    if (value.Status)
            //    {
            //        filteredValues.Add(value);
            //    }
            //}
            #endregion

            #region option 4
            //// Filter the list in place
            //values.RemoveAll(x => !x.Status);
            #endregion        

            return View(filteredValues);
        }
    }
}
