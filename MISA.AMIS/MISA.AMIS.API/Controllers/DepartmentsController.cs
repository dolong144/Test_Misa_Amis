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
    public class DepartmentsController : BaseEntityController<Department>
    {
        IDepartmentRepository _departmentRepository;
        IDepartmentService _departmentService;
        public DepartmentsController(IDepartmentService departmentService, IDepartmentRepository departmentRepository) : base(departmentService, departmentRepository)
        {
            _departmentRepository = departmentRepository;
            _departmentService = departmentService;
        }
    }
}
