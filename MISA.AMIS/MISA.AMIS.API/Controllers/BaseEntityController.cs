using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Interfaces.Repositories;
using MISA.AMIS.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<MISAEntity> : ControllerBase
    {
        #region Declage
        IBaseService<MISAEntity> _baseService;
        IBaseRepository<MISAEntity> _baseRepository;
        #endregion
        #region constructor
        public BaseEntityController(IBaseService<MISAEntity> baseService, IBaseRepository<MISAEntity> baseRepository)
        {
            _baseService = baseService;
            _baseRepository = baseRepository;
        }
        #endregion
        /// <summary>
        /// lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy:DVLong(27/8/2021)
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var entities = _baseRepository.GetAll();
                return Ok(entities);
            }
            catch (Exception e)
            {
                var errorObject = new
                {
                    userMsg = Core.Properties.Resource.errServe,
                    devMsg = e.Message,
                    errorCode = "ms_001",

                };
                var response = StatusCode(500, errorObject);
                return response;
            }
        }
        /// <summary>
        /// Xoá dữ liệu theo Id
        /// </summary>
        /// <returns></returns>
        /// CreatedBy:DVLong(27/8/2021)
        [HttpDelete("{entityId}")]
        public IActionResult DeleteById(Guid entityId)
        {
            try
            {
                var rowEffect = _baseRepository.Delete(entityId);
                return Ok(rowEffect);
            }
            catch (Exception e)
            {
                var errorObject = new
                {
                    devMsg = e.Message,
                    userMsg = Core.Properties.Resource.errServe,
                };
                return StatusCode(500, errorObject);
            }

        }

        /// <summary>
        /// lấy dữ liệu theo Id
        /// </summary>
        /// <returns></returns>
        /// CreatedBy:DVLong(27/8/2021)
        [HttpGet("{entityId}")]
        public IActionResult GetById(Guid entityId)
        {
            try
            {
                var entity = _baseRepository.GetById(entityId);
                return Ok(entity);
            }
            catch (Exception e)
            {
                var errorObject = new
                {
                    devMsg = e.Message,
                    userMsg = Core.Properties.Resource.errServe,
                };
                return StatusCode(500, errorObject);
            }
        }

        /// <summary>
        /// thêm mới dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy:DVLong(27/8/2021)
        [HttpPost]
        public IActionResult InsertEmployee(MISAEntity entity)
        {
            try
            {
                var res = _baseService.Add(entity);
                if (res.IsValid == true)
                {
                    res.Messenger = Core.Properties.Resource.addSuccess;
                    return StatusCode(201, res);
                }
                else
                {
                    return BadRequest(res);
                }
            }
            catch (Exception e)
            {
                var errorObject = new
                {
                    devMsg = e.Message,
                    userMsg = Core.Properties.Resource.errServe,
                };
                return StatusCode(500, errorObject);
            }
        }

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy:DVLong(27/8/2021)
        [HttpPut("{entityId}")]
        public IActionResult Update(MISAEntity entity, Guid entityId)
        {
            try
            {
                var rowEffect = _baseService.Update(entity, entityId);
                return Ok(rowEffect);

            }
            catch (Exception e)
            {
                var errorObject = new
                {
                    devMsg = e.Message,
                    userMsg = Core.Properties.Resource.errServe,
                };
                return StatusCode(500, errorObject);
            }

        }

        /// <summary>
        /// Lấy mã mới để thêm đối tượng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy:DVLong(27/8/2021)
        [HttpGet("newCode")]
        public IActionResult GetNewCode()
        {
            try
            {
                var newCode = _baseService.GetNewCode();

                if (newCode.IsValid)
                {
                    return Ok(newCode.Data);
                }
                else
                {
                    return NoContent();
                }
            }
            catch(Exception e)
            {
                var errorObject = new
                {
                    devMsg = e.Message,
                    userMsg = Core.Properties.Resource.errServe,
                };
                return StatusCode(500, errorObject);
            }
        }


    }
}
