using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repositories;
using MISA.AMIS.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Services
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        IDepartmentRepository _departmentRepository;
        ServiceResult _serviceResult;
        public DepartmentService(IDepartmentRepository departmentRepository, IBaseRepository<Department> baseRepository) : base(baseRepository)
        {
            _departmentRepository = departmentRepository;
            _serviceResult = new ServiceResult();
        }
    }
}
