using MISA.AMIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces.Services
{
    public interface IBaseService<MISAEntity>
    {
        /// <summary>
        /// Lấy toàn bộ thông tin đối tượng
        /// </summary>
        /// <returns></returns>
        ServiceResult Get();
        /// <summary>
        /// Lấy thông tin đối tượng theo Id
        /// </summary>
        /// <returns></returns>
        ServiceResult GetById(Guid entityId);
        /// <summary>
        /// thêm mới đối tượng
        /// </summary>
        /// <param name="customer">Thông tin đối tượng</param>
        /// <returns>ServiceResult- kết quả xử lý qua nghiệp vụ</returns>
        /// Createby:dvlong(14/8/2021)
        ServiceResult Add(MISAEntity entity);
        /// <summary>
        /// Cập nhật đối tượng
        /// </summary>
        /// <param name="entity">thông tin đối tượngparam>
        /// <returns>ServiceResult- kết quả xử lí qua nghiệp vụ</returns>
        /// Createby:dvlong(14/8/2021)
        ServiceResult Update(MISAEntity entity, Guid entityId);
        /// <summary>
        /// Xoá đối tượng theo Id
        /// </summary>
        /// <param name="entityId">ID đối tượng</param>
        /// <returns></returns>
        ServiceResult Delete(Guid entityId);
        /// <summary>
        /// Sinh mã mới
        /// </summary>
        /// <returns></returns>
        ServiceResult GetNewCode();
    }
}
