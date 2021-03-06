﻿using System.Data;
using System.Data.SqlClient;

namespace CommonADO.net
{
    public class DataProvider : IDataProvider
    {
        /// <summary>
        /// Thực thi câu lệnh truy vấn ;trả ra các giá trị truy vấn được vào bảng <see cref="DataTable"/>
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="query"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string connectionString, string query, object[] value = null)
        {
            try
            {

                int count = -1;
                using (var objConn = new SqlConnection(connectionString))
                {
                    objConn.Open();
                    using (var objCommand = new SqlCommand(query, objConn))
                    {

                        if (value != null)
                        {
                            var storeQuery = query.Split(' ');
                            int i = 0;
                            foreach (var item in storeQuery)
                            {
                                if (item.StartsWith("@"))
                                {
                                    objCommand.Parameters.AddWithValue(item, value[i]);
                                    i++;
                                }
                            }
                        }
                        count = objCommand.ExecuteNonQuery();
                        objConn.Close();
                    }
                }
                return count;
            }
            catch (System.Exception ex)
            {

                System.Diagnostics.Debug.WriteLine($"{ex.ToString() }");

                throw ex;
            }
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Trả về số dòng bị câu lệnh truy vấn ảnh hưởng 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="query"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string connectionString, string query, object[] value = null)
        {
            try
            {

                DataTable dataTable = new DataTable();
                using (SqlConnection objConn = new SqlConnection(connectionString))
                {
                    objConn.Open();
                    using (SqlCommand objCommand = new SqlCommand(query, objConn))
                    {

                        if (value != null)
                        {
                            var storeQuery = query.Split(' ');
                            int i = 0;
                            foreach (var item in storeQuery)
                            {
                                if (item.StartsWith("@"))
                                {
                                    objCommand.Parameters.AddWithValue(item, value[i]);
                                    i++;

                                }
                            }

                        }
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(objCommand);
                        sqlDataAdapter.Fill(dataTable);
                    }

                    objConn.Close();
                }
                return dataTable;
                //throw new NotImplementedException();
            }
            catch (System.Exception ex)
            {

                System.Diagnostics.Debug.WriteLine($"{ex.ToString() }");

                throw ex;
            }
        }

        /// <summary>
        /// Trả về dòng một cộng một của bảng dữ liệu
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="query"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public object ExecuteScalar(string connectionString, string query, object[] value = null)
        {
            try
            {

                object data = -1;
                using (var objConn = new SqlConnection(connectionString))
                {
                    objConn.Open();
                    using (var objCommand = new SqlCommand(query, objConn))
                    {

                        if (value != null)
                        {
                            var storeQuery = query.Split(' ');
                            int i = 0;
                            foreach (var item in storeQuery)
                            {
                                if (item.StartsWith("@"))
                                {
                                    objCommand.Parameters.AddWithValue(item, value[i]);
                                    i++;
                                }
                            }
                        }
                        data = objCommand.ExecuteScalar();
                        objConn.Close();
                    }
                }
                return data;
            }
            catch (System.Exception ex)
            {

                System.Diagnostics.Debug.WriteLine($"{ex.ToString() }");

                throw ex;
            }
        }
    }
}
