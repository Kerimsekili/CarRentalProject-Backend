using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DTOs;
using Microsoft.AspNetCore.Routing;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //aa
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }
        //resim ekle
        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImageForAddDto carImageForAddDto,IFormFile image)
        {
            var result = _carImageService.Add(carImageForAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //resim sil
        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {

            var result = _carImageService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //resim güncelle
        [HttpPost("update")]
        public IActionResult Update(CarImageForUpdateDto carImageForUpdateDto)
        {

            var result = _carImageService.Update(carImageForUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //resimleri listele
        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //resimlerin car-id lerini getir
        [HttpGet("getallbycarid")]
        public IActionResult GetAllByCarId(int carId)
        {
            var result = _carImageService.GetAllByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //resimlerin idlerini getir
        [HttpGet("getbyimageid")]
        public IActionResult GetByImageId([FromForm(Name = ("CarId"))] int imageId)
        {
            var result = _carImageService.GetByImageId(imageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}