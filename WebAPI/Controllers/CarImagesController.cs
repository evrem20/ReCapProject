using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public static IWebHostEnvironment _webHostEnvironment;


        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }

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

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId( int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);
            //foreach (var item in result.Data)
            //{
            //    item.ImagePath=item.ImagePath.Remove(0,63 );
            //}
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage carImage, [FromForm] IFormFile file)
        {
            if (file == null)
            {
                return BadRequest(Messages.MustPicture);
            }
            var result = _carImageService.Add(carImage, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //public IActionResult Add([FromForm(Name = ("CarImage"))] IFormFile objectFile, [FromForm] CarImage carImage)
        //{
        //    string path = _webHostEnvironment.WebRootPath + "\\images\\";
        //    var newGuidPath = Guid.NewGuid().ToString() + Path.GetExtension(objectFile.FileName);


        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }
        //    using (FileStream fileStream = System.IO.File.Create(path + newGuidPath))
        //    {
        //        objectFile.CopyTo(fileStream);
        //        fileStream.Flush();
        //    }
        //    if (objectFile == null)
        //    {
        //        carImage.ImagePath = path + "default.png";
        //    }
        //    var result = _carImageService.Add(new CarImage
        //    {
        //        CarId = carImage.CarId,
        //        Date = DateTime.Now,
        //        ImagePath = newGuidPath
        //    });
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] CarImage carImage, [FromForm] IFormFile file)
        {
            var result = _carImageService.Update(carImage, file);
            if (file == null)
            {
                return BadRequest(Messages.MustPicture);
            }
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
