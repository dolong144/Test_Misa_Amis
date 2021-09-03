using MISA.AMIS.Core.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Entities
{
    public class Employee : BaseEntity
    {
        #region Property

        /// <summary>
        /// Khóa chính
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        [MISARequired,MISACode]

        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        ///CreatedBy:DVLong(27/8/2021)
        [MISARequired]

        public string FullName { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        public string Address { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        public int? Gender { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        [MISAEmail]
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        public string MobiePhoneNumber { get; set; }
        /// <summary>
        /// Số điện thoại bàn
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        public string TelePhoneNumber { get; set; }

        /// <summary>
        /// Số cmnd/cccd
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày làm cmnd/cccd
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi làm cmnd/cccd
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Id phòng ban
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        [MISARequired]
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        [MISANotMap]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Tên vị tri
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        public string PositionName { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        public string BankName { get; set; }

        /// <summary>
        /// Tên chi nhanh ngân hàng
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        public string BankBranch { get; set; }

        /// <summary>
        /// Số tài khoản
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        public string BankAcount { get; set; }

        #endregion
    }
}
