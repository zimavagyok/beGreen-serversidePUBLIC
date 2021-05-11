using beGreen.Infrastructure.service;
using beGreen.Model;
using beGreen.Model.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beGreen.WebApplication.Controllers
{
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost("api/like/create")]
        public Like Create([FromBody] Like entity)
        {
            entity.ProfileId = User.Identity.Name;
            ResponseMessage<Like> request = _likeService.Create(entity);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }
        [HttpGet("api/like/{id}")]
        public bool Delete([FromRoute] int id)
        {
            ResponseMessage request = _likeService.Delete(id);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.IsSuccess;
        }

        [HttpPost("api/deleteLike")]
        public bool DeleteByBoth([FromBody] Like entity)
        {
            entity.ProfileId = User.Identity.Name;
            ResponseMessage request = _likeService.DeleteByBoth(entity);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.IsSuccess;
        }
        [HttpPost("api/like/get")]
        public Like GetByBoth([FromBody] Like entity)
        {
            entity.ProfileId = User.Identity.Name;
            ResponseMessage<Like> request = _likeService.GetByBoth(entity);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }

        [HttpGet("api/like/count/{id}")]
        public int Count([FromRoute] int id)
        {
            ResponseMessage<int> request = _likeService.Count(id);

            if (!request.IsSuccess)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.ResponseObject;
        }
    }
}
