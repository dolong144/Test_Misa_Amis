using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Entities;
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
    public class EmployeesController : BaseEntityController<Employee>
    {
        IEmployeeRepository _employeeRepository;
        IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService, IEmployeeRepository employeeRepository) : base(employeeService, employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
        }

        /// <summary>
        /// Hàm xử lý phân trang cho nhân viên
        /// </summary>
        /// <param name="employeeFilter">Dữ liệu cần lọc</param>
        /// <param name="pageIndex">Trang hiện tại</param>
        /// <param name="pageSize">Số bản ghi một trang</param>
        /// <returns>Dữ liệu phân trang</returns>
        /// CreateBy:dvlong(19/08/2021)
        [HttpGet("paging")]
        public IActionResult EmployeePagination([FromQuery] string employeeFilter, [FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            try
            {
                var serviceResponse = _employeeRepository.Pagination(employeeFilter, pageIndex, pageSize);

                if ((int)serviceResponse.GetType().GetProperty("totalRecord").GetValue(serviceResponse) != 0)
                {
                    return StatusCode(200, serviceResponse);
                }
                else
                {
                    return NoContent();
                }

            }
            catch (Exception)
            {
                var errorObj = new
                {
                    devMsg = "",
                    userMsg = "",
                };
                return StatusCode(500, errorObj);
            }

        }
    }
}
