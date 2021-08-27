using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.AMIS.Core.Atributes;
using MISA.AMIS.Core.Interfaces.Repositories;
using MISA.AMIS.Core.Interfaces.Services;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Infrastructure.Repositories
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>
    {
        public readonly string _connectionString;
        string _className;
        public BaseRepository(IConfiguration configuration)
        {
            _className = typeof(MISAEntity).Name;
            _connectionString = configuration.GetConnectionString("MyDatabase");
        }

        /// <summary>
        /// Thêm đối tượng
        /// </summary>
        /// <param name="entity">thông tin đối tượng</param>
        /// <returns></returns>
        /// CreatedBy: dvlong(19/8/2021)
        public int Add(MISAEntity entity)
        {

            // khai báo dynamic param
            var dynamicParam = new DynamicParameters();


            //Thêm dữu liệu vào database
            var columnsName = string.Empty;
            var columnsParam = string.Empty;

            //Đọc từng property của object:
            var properties = entity.GetType().GetProperties();

            //Duyệt qua các property
            foreach (var prop in properties)
            {
                var propertyAttributeNotMap = prop.GetCustomAttributes(typeof(MISANotMap), true);
                if (propertyAttributeNotMap.Length == 0)
                {
                    //lấy tên prop
                    var propName = prop.Name;

                    //lấy value của prop
                    var propvalue = prop.GetValue(entity);

                    //Khởi tạo id mới
                    if (propName == $"{_className}Id" && prop.PropertyType == typeof(Guid))
                    {
                        propvalue = Guid.NewGuid();
                    }

                    // lấy kiểu dữ liệu của prop
                    var propType = prop.PropertyType;

                    //Thêm param tương ứng với prop
                    dynamicParam.Add($"@{propName}", propvalue);

                    columnsName += $"{propName},";
                    columnsParam += $"@{propName},";
                }
            }
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                columnsName = columnsName.Remove(columnsName.Length - 1, 1);
                columnsParam = columnsParam.Remove(columnsParam.Length - 1, 1);
                var sqlCommand = $"INSERT INTO {_className}({columnsName}) VALUES({columnsParam})";

                var rowEffects = dbConnection.Execute(sqlCommand, param: dynamicParam);
                return rowEffects;
            }

        }
        /// <summary>
        /// Xoá đối tượng theo Id
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns></returns>
        /// CreatedBy:DVLong(27/8/2021)
        public int Delete(Guid entityId)
        {


            var sqlCommand = $"DELETE FROM {_className} WHERE {_className}Id = @EntityIdParam";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EntityIdParam", entityId);
            //Khởi tạo đới tượng kết nối với database

            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                //Xoá dữu liệu

                var rowEffects = dbConnection.Execute(sqlCommand, param: parameters);

                //Trả về cho client
                return rowEffects;
            }

        }

        public int DeleteList(List<Guid> entityCodes)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Lấy toàn bộ đối tượng
        /// </summary>
        /// <returns>danh sách đối tượng</returns>
        /// CreatedBy:DVLong(27/8/2021)
        public List<MISAEntity> GetAll()
        {


            //Khởi tạo đới tượng kết nối với database

            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                //Lấy dữu liệu
                var sqlCommand = $"SELECT * FROM {_className}";
                var entities = dbConnection.Query<MISAEntity>(sqlCommand).ToList();
                return entities;
            }

        }

        /// <summary>
        /// Lấy về danh sách mã
        /// </summary>
        /// createdBy:dvlong(27/8/2021)
        public List<string> GetAllCode()
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                var codeList = dbConnection.Query<string>($"Proc_{_className}GetAllCode", commandType: CommandType.StoredProcedure);

                return codeList.ToList();
            }
        }

        /// <summary>
        /// check xem mã đối tương đã tồn tại chưa
        /// </summary>
        /// <param name="code"></param>
        /// <returns>true-đã tồn tại, false- không tồn tại</returns>
        /// createdBy:dvlong(27/8/2021)
        public bool GetByCode(string code)
        {
            //thông tin kết nối
            var sqlCommand = $"SELECT * FROM {_className} WHERE {_className}Code = @EntityIdParam";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EntityIdParam", code);

            //Khởi tạo đới tượng kết nối với database
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                var entity = dbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, param: parameters);
                if (entity is not null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Lấy thông tin đối tượng theo Id
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns></returns>
        /// createdby:dvlong(27/8/2021)
        public MISAEntity GetById(Guid entityId)
        {
            //thông tin kết nối
            var sqlCommand = $"SELECT * FROM {_className} WHERE {_className}Id = @EntityIdParam";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EntityIdParam", entityId);

            //Khởi tạo đới tượng kết nối với database
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                var entity = dbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, param: parameters);
                return (MISAEntity)entity;
            }

        }
        /// <summary>
        /// Lấy Mã đối tượng theo Id
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns></returns>
        /// createdby:dvlong(27/8/2021)
        public string GetCode(Guid entityId, string entityName)
        {
            //Lấy dữu liệu
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@{entityName}Id", entityId);
            parameters.Add($"@{entityName}Code", "");

            //Khởi tạo đới tượng kết nối với database
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                var entityCode = dbConnection.QueryFirstOrDefault<string>($"PROC_{_className}GetCodeById", param: parameters, commandType: CommandType.StoredProcedure);
                return entityCode;
            }
        }
        /// <summary>
        /// Cập nhật thông tin đối tượng
        /// </summary>
        /// <param name="entity">thông tin cập nhật đối tượng</param>
        /// <param name="entityId">Id đối tượng</param>
        /// <returns></returns>
        /// CreatedBy:dvlong(27/8/2021)
        public int Update(MISAEntity entity, Guid entityId)
        {



            // khai báo dynamic param
            var dynamicParam = new DynamicParameters();


            //Sửa dữ liệu database
            var columnsName = string.Empty;
            var columnsParam = string.Empty;

            //Đọc từng property của object:
            var properties = entity.GetType().GetProperties();

            //Duyệt qua các property
            foreach (var prop in properties)
            {
                var propertyAttributeNotMap = prop.GetCustomAttributes(typeof(MISANotMap), true);
                if (propertyAttributeNotMap.Length == 0)
                {
                    //lấy tên prop
                    var propName = prop.Name;

                    //lấy value của prop
                    var propvalue = prop.GetValue(entity);

                    // lấy kiểu dữ liệu của prop
                    var propType = prop.PropertyType;

                    //Thêm param tương ứng với prop
                    dynamicParam.Add($"@{propName}", propvalue);



                }
            }

            dynamicParam.Add($"@{_className}Id", entityId);

            // truy vấn sửa dữ liệu

            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                var rowEffects = dbConnection.Execute($"PROC_{_className}Update", param: dynamicParam, commandType: CommandType.StoredProcedure);
                return rowEffects;
            }

        }
    }
}
