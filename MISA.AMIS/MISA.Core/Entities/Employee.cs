using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Employee : BaseEntity
    {
        #region Property

        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>

        public string FullName { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Email
        /// </summary>

        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        public string MobiePhoneNumber { get; set; }
        /// <summary>
        /// Số điện thoại bàn
        /// </summary>
        public string TelePhoneNumber { get; set; }

        /// <summary>
        /// Số cmnd/cccd
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày làm cmnd/cccd
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi làm cmnd/cccd
        /// </summary>
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Id phòng ban
        /// </summary>
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// Tên vị tri
        /// </summary>
        public Guid? PositionName { get; set; }

        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string PersonalTaxCode { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Tên chi nhanh ngân hàng
        /// </summary>
        public string BankBranch { get; set; }

        /// <summary>
        /// Số tài khoản
        /// </summary>
        public string BankAcount { get; set; }



        #endregion
    }
}
