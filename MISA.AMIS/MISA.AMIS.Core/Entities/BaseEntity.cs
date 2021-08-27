using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// ngày tạo
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người sửa
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        public string ModifiedBy { get; set; }
    }
}
