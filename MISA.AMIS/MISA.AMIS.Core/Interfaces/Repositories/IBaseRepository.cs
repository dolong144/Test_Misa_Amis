using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces.Repositories
{
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        /// CreatedBy:DVLong(27/8/2021)
        List<MISAEntity> GetAll();

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy:DVLong(27/8/2021)
        int Add(MISAEntity entity);

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy:DVLong(27/8/2021)
        int Update(MISAEntity entity, Guid entityId);

        /// <summary>
        /// Lấy đối tượng theo Id
        /// </summary>
        /// <returns></returns>
        /// CreatedBy:DVLong(27/8/2021)
        MISAEntity GetById(Guid entityId);

        /// <summary>
        /// Xoá dữ liêu theo Id
        /// </summary>
        /// <returns></returns>
        /// CreatedBy:DVLong(27/8/2021)
        int Delete(Guid entityId);

        /// <summary>
        /// Kiểm tra xem mã đã tồn tại
        /// </summary>
        /// <returns>true-đã tồn tại, false-chưa có mã</returns>
        /// CreatedBy:DVLong(27/8/2021)
        bool GetByCode(string code);

        /// <summary>
        /// Lấy mã đối tượng theo Id
        /// </summary>
        /// <returns>mã đối tượng</returns>
        /// CreatedBy:DVLong(27/8/2021)
        string GetCode(Guid entityId, string entityName);

        /// <summary>
        /// Xoá nhiều đối tượng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy:DVLong(27/8/2021)
        int DeleteList(List<Guid> entityCodes);

        /// <summary>
        /// Lấy toàn bộ mã
        /// </summary>
        /// <returns>Danh sách mã </returns>
        /// CreatedBy:DVLong(27/8/2021)
        List<string> GetAllCode();
    }
}
