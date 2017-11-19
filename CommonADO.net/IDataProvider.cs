using System.Data;

namespace CommonADO.net
{
    public interface IDataProvider
    {

        /// <summary>
        /// Thực thi câu lệnh truy vấn ;trả ra các giá trị truy vấn được vào bảng <see cref="DataTable"/>
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="query"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        DataTable ExecuteQuery(string connectionString, string query, object[] value = null);

        /// <summary>
        /// Trả về số dòng bị câu lệnh truy vấn ảnh hưởng 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="query"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string connectionString, string query, object[] value = null);

        /// <summary>
        /// Trả về dòng một cộng một của bảng dữ liệu
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="query"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        object ExecuteScalar(string connectionString, string query, object[] value = null);
    }
}