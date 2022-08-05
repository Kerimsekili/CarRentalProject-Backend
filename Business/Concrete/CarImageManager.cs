using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac;
using Core.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;


namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IUploadService _uploadService;

        public CarImageManager(ICarImageDal carImageDal, IUploadService uploadService)
        {
            _carImageDal = carImageDal;
            _uploadService = uploadService;
        }
        //resim ekle
        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Add(CarImageForAddDto carImageForAddDto)
        {
            IResult result = BusinessRules.Run(
                CheckIfCarImageLimit(carImageForAddDto.CarId)
            );
            if (result != null)
            {
                return result;
            }

            CarImage carImage = new CarImage();
            carImage.CarId = carImageForAddDto.CarId;
            carImage.ImagePath = _uploadService.AddFromBase64(carImageForAddDto.Image);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }
        //resim sil
        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Delete(int id)
        {
            var carImage = _carImageDal.Get(c => c.Id == id);
            if (carImage == null) return new ErrorResult();
            _uploadService.Remove(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }
        //resim güncelle
        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Update(CarImageForUpdateDto carImageForUpdateDto)
        {
            var carImage = _carImageDal.Get(c => c.Id == carImageForUpdateDto.CarId);
            string newPath = _uploadService.UpdateFromBase64(carImage.ImagePath, carImageForUpdateDto.Image);
            carImage.ImagePath = newPath;
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        //resimlerin car-id lerini getir
        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }
        //resimlerin idlerini getir
        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
        }
        //resimlerin hepsini listele
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }
        //CarImage Limitini Kontrol Edin
        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        //Varsayılan Resmi Al
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {

            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }
        //CarImage'ı Kontrol Et
        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

    }
}
