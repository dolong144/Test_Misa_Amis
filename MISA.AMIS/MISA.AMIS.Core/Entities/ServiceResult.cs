using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Entities
{
    public class ServiceResult
    {
        /// <summary>
        /// Dữ liệu có hợp lệ-true _ không hợp lệ-false
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        public bool IsValid { get; set; } = true;

        /// <summary>
        /// thông tin trả về
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        public object Data { get; set; }

        /// <summary>
        /// Tin nhắn trả về
        /// </summary>
        /// CreatedBy:DVLong(27/8/2021)
        public string Messenger { get; set; }
    }
}
