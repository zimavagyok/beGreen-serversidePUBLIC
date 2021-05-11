using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using beGreen.Model;
using beGreen.Repositories;
using beGreen.Model.Entity;
using beGreen.Infrastructure.repository;
using beGreen.Infrastructure.service;
using beGreen.Model.Request;
using System.Globalization;
using beGreen.Services.Common;

namespace beGreen.Services
{
    public class RecyclingBankService : IRecyclingBankService
    {
        private readonly IRecyclingBankRepository _recyclingBankRepository;
        private readonly ILikeRepository _likeRepository;

        public RecyclingBankService(IRecyclingBankRepository recyclingBankRepository,ILikeRepository likeRepository)
        {
            _recyclingBankRepository = recyclingBankRepository;
            _likeRepository = likeRepository;
        }

        public ResponseMessage<RecyclingBank> Create(RecyclingBankCreateRequest data,string uniq)
        {
            ResponseMessage<RecyclingBank> response = new ResponseMessage<RecyclingBank>();

            try
            {
                RecyclingBank user = new RecyclingBank(data,uniq.Reverse());

                response.ResponseObject = _recyclingBankRepository.Create(user);
                response.IsSuccess = true;
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        public ResponseMessage Delete(string location)
        {
            ResponseMessage response = new ResponseMessage();

            try
            {
                bool deleted = _likeRepository.Delete(_recyclingBankRepository.GetByLocation(location));
                response.IsSuccess = _recyclingBankRepository.Delete(location);
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        public ResponseMessage<int> GetByLocation(string location)
        {
            ResponseMessage<int> response = new ResponseMessage<int>();

            try
            {
                response.ResponseObject = _recyclingBankRepository.GetByLocation(location);
                response.IsSuccess = true;
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        public ResponseMessage<List<RecyclingBank>> GetAll()
        {
            ResponseMessage<List<RecyclingBank>> response = new ResponseMessage<List<RecyclingBank>>();

            try
            {
                response.ResponseObject = _recyclingBankRepository.GetAll();
                response.IsSuccess = true;
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        public ResponseMessage<List<RecyclingBank>> GetAllClose(RecyclingBankRequest _recyclingBankRequest)
        {
            ResponseMessage<List<RecyclingBank>> response = new ResponseMessage<List<RecyclingBank>>();

            try
            {
                List<RecyclingBank> banks = _recyclingBankRepository.GetAll();
                var currentLocation = new GeoCoordinatePortable.GeoCoordinate(double.Parse(_recyclingBankRequest.Coordinate.Split(',')[0], CultureInfo.InvariantCulture), double.Parse(_recyclingBankRequest.Coordinate.Split(',')[1], CultureInfo.InvariantCulture));
                foreach (var item in banks)
                {
                    var bankLocation = new GeoCoordinatePortable.GeoCoordinate(double.Parse(item.Position.Split(',')[0], CultureInfo.InvariantCulture), double.Parse(item.Position.Split(',')[1], CultureInfo.InvariantCulture));
                    if(currentLocation.GetDistanceTo(bankLocation)< (_recyclingBankRequest.Radius*1000))
                    {
                        response.ResponseObject.Add(item);
                    }
                }
                response.IsSuccess = true;
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
    }
}
