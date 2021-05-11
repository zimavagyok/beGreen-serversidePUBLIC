using beGreen.Infrastructure.repository;
using beGreen.Infrastructure.service;
using beGreen.Model;
using beGreen.Model.Entity;
using beGreen.Services.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace beGreen.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;

        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public ResponseMessage<Like> Create(Like entity)
        {
            ResponseMessage<Like> response = new ResponseMessage<Like>();

            try
            {
                entity.ProfileId = entity.ProfileId.Reverse();
                response.ResponseObject = _likeRepository.Create(entity);
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

        public ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            try
            {
                response.IsSuccess = _likeRepository.Delete(id);
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public ResponseMessage DeleteByBoth(Like entity)
        {
            ResponseMessage response = new ResponseMessage();

            try
            {
                entity.ProfileId = entity.ProfileId.Reverse();
                response.IsSuccess = _likeRepository.DeleteByBoth(entity);
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public ResponseMessage<Like> GetByBoth(Like entity)
        {
            ResponseMessage<Like> response = new ResponseMessage<Like>();

            try
            {
                entity.ProfileId = entity.ProfileId.Reverse();
                response.ResponseObject = _likeRepository.GetByBoth(entity);
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

        public ResponseMessage<int> Count(int id)
        {
            ResponseMessage<int> response = new ResponseMessage<int>();

            try
            {
                response.ResponseObject = _likeRepository.Count(id);
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
