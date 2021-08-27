using MISA.AMIS.Core.Atributes;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repositories;
using MISA.AMIS.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        IBaseRepository<MISAEntity> _baseRepository;
        ServiceResult _serviceResult;
        string _className;
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
            _className = typeof(MISAEntity).Name;
        }
        public ServiceResult Add(MISAEntity entity)
        {
            //validate dữ liệu, xử lí nghiệp vụ
            _serviceResult.IsValid = true;
            {
                var className = typeof(MISAEntity).Name;
                //kiểm tra
                //Đọc từng property của object:
                var properties = entity.GetType().GetProperties();

                //Duyệt qua các property
                foreach (var prop in properties)
                {
                    //lấy tên prop
                    var propName = prop.Name;

                    //lấy value của prop
                    var propvalue = prop.GetValue(entity);

                    //validate Email
                    var propMISAEmail = prop.GetCustomAttributes(typeof(MISAEmail), true);
                    if (propMISAEmail.Length > 0)
                    {
                        if (!validEmail(propvalue.ToString()))
                        {
                            _serviceResult.IsValid = false;
                            _serviceResult.Messenger = Properties.Resource.errEmail;
                        }
                    }

                    // check trùng mã
                    var propMISACode = prop.GetCustomAttributes(typeof(MISACode), true);
                    if (propMISACode.Length > 0)
                    {
                        if (!validCodeAdd(propvalue.ToString()))
                        {
                            _serviceResult.IsValid = false;
                            _serviceResult.Messenger = Properties.Resource.errDoubleCode;
                        }

                    }


                    //validate trường bắt buộc
                    var propMISARequired = prop.GetCustomAttributes(typeof(MISARequired), true);
                    if (propMISARequired.Length > 0)
                    {
                        if (!validRequired(propvalue.ToString()))
                        {
                            _serviceResult.IsValid = false;
                            _serviceResult.Messenger = Properties.Resource.nullString;
                        }
                    }
                }

            }
            if (_serviceResult.IsValid)
            {
                _serviceResult.IsValid = ValidateCustom(entity);
            }
            //thực hiện thêm mới
            if (_serviceResult.IsValid)
            {
                _serviceResult.Data = _baseRepository.Add(entity);
            }

            return _serviceResult;
        }

        public ServiceResult Delete(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Get()
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetById(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Update(MISAEntity entity, Guid entityId)
        {

            //validate dữ liệu, xử lí nghiệp vụ
            _serviceResult.IsValid = true;
            {
                var className = typeof(MISAEntity).Name;
                //kiểm tra
                //Đọc từng property của object:
                var properties = entity.GetType().GetProperties();

                //Duyệt qua các property
                foreach (var prop in properties)
                {
                    //lấy tên prop
                    var propName = prop.Name;

                    //lấy value của prop
                    var propvalue = prop.GetValue(entity);

                    //validate Email
                    var propMISAEmail = prop.GetCustomAttributes(typeof(MISAEmail), true);
                    if (propMISAEmail.Length > 0)
                    {
                        if (!validEmail(propvalue.ToString()))
                        {
                            _serviceResult.IsValid = false;
                            _serviceResult.Messenger = Properties.Resource.errEmail;
                        }
                    }

                    // check trùng mã
                    var propMISACode = prop.GetCustomAttributes(typeof(MISACode), true);
                    if (propMISACode.Length > 0)
                    {
                        if (!validCodeUpdate(propvalue.ToString(), entityId, _className))
                        {
                            _serviceResult.IsValid = false;
                            _serviceResult.Messenger = Properties.Resource.errDoubleCode;
                        }

                    }


                    //validate trường bắt buộc
                    var propMISARequired = prop.GetCustomAttributes(typeof(MISARequired), true);
                    if (propMISARequired.Length > 0)
                    {
                        if (!validRequired(propvalue.ToString()))
                        {
                            _serviceResult.IsValid = false;
                            _serviceResult.Messenger = Properties.Resource.nullString;
                        }
                    }
                }

            }
            if (_serviceResult.IsValid)
            {
                _serviceResult.IsValid = ValidateCustom(entity);
            }
            //thực hiện sửa
            if (_serviceResult.IsValid)
            {
                _serviceResult.Data = _baseRepository.Update(entity, entityId);
            }
            return _serviceResult;
        }
        /// <summary>
        /// Xử lí validate Email
        /// </summary>
        /// <param name="email">Email cần validate</param>
        /// <returns>true- hợp lệ, false-không hợp lệ</returns>
        /// createdby:dvlong(17/8/2021)

        private bool validEmail(string email)
        {
            var emailFormat = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var isMatch = Regex.IsMatch(email, emailFormat, RegexOptions.IgnoreCase);
            if (!isMatch)
            {

                return false;
                //_serviceResult.Messenger = Properties.Resource.errEmail;

            }
            return true;
        }
        private bool validCodeAdd(string code)
        {

            var isValidate = !_baseRepository.GetByCode(code);
            return isValidate;

        }
        private bool validCodeUpdate(string code, Guid entityId, string entityName)
        {
            var isCode = _baseRepository.GetByCode(code);
            var oldCode = _baseRepository.GetCode(entityId, entityName);
            if (isCode && code != oldCode)
            {
                return false;
            }
            return true;
        }
        private bool validRequired(string value)
        {
            if (value.ToString() == string.Empty || value.ToString() == "")
            {
                return false;
                //_serviceResult.Messenger = Properties.Resource.nullString;
            }
            return true;
        }
        /// <summary>
        /// Xử lí validate dữ liệu cho con ghi đè
        /// </summary>
        /// <param name="entity">đối tượng cần validate</param>
        /// <returns>true- hợp lệ, false-không hợp lệ</returns>
        /// createdby:dvlong(17/8/2021)
        protected virtual bool ValidateCustom(MISAEntity entity)
        {
            return true;
        }

        public ServiceResult GetNewCode()
        {
            var codeList = _baseRepository.GetAllCode();

            if (codeList is null)
            {
                
                _serviceResult.Data = codeList;
                _serviceResult.Messenger = "Không thể lấy danh sách mã";
                return _serviceResult;
            }

            var codeDigitList = new List<int>();
            foreach (var code in codeList)
            {
                var codeDigit = int.Parse(code[3..]);
                codeDigitList.Add(codeDigit);
            }

            codeDigitList.Sort((x, y) => y.CompareTo(x));

            _serviceResult.Data = codeList[0].Substring(0, 3) + (codeDigitList[0] + 1).ToString();
            return _serviceResult;
        }
    }
}
