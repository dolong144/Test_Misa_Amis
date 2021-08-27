using MISA.AMIS.Core.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Entities
{
    public class Department : BaseEntity
    {
        #region Property

        /// <summary>
        /// Khóa chính
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        [MISARequired]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        [MISARequired,MISACode]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        [MISARequired]
        public string DepartmentName { get; set; }

        #endregion
    }
}
