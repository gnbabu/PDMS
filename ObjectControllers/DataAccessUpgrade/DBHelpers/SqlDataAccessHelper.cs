
using MAXIMUS.Core.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MAXIMUS.Controllers.PDMS.DataAccessUpgrade.DBHelpers
{
    public class SqlDataAccessHelper
    {
        private readonly string _connectionString;

        public string ConnectionString { get { return _connectionString; } }

        public SqlDataAccessHelper()
        {
            var connectionString = AppSettings.GetConnectionString();

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Database connection string 'DefaultConnection' is not configured.");
            }

            _connectionString = connectionString;
        }
        
        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T ExecuteScalar<T>(string storedProcedure, SqlParameter[] parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                            command.Parameters.AddRange(parameters);

                        var result = command.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                            return default(T);

                        return (T)Convert.ChangeType(result, typeof(T));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing ExecuteScalar for {storedProcedure}", ex);
            }
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public int ExecuteNonQuery(string storedProcedure, SqlParameter[] parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                            command.Parameters.AddRange(parameters);

                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing ExecuteNonQuery for {storedProcedure}", ex);
            }
        }

        /// <summary>
        /// ExecuteReader (multiple rows)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public IEnumerable<T> ExecuteReader<T>(string storedProcedure, SqlParameter[] parameters, Func<SqlDataReader, T> map)
        {
            var results = new List<T>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                            command.Parameters.AddRange(parameters);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(map(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing ExecuteReader for {storedProcedure}", ex);
            }

            return results;
        }

        /// <summary>
        /// ExecuteSingle (single row)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T ExecuteSingle<T>(string storedProcedure, SqlParameter[] parameters, Func<SqlDataReader, T> map)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                            command.Parameters.AddRange(parameters);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return map(reader);
                            }
                        }
                    }
                }

                return default(T);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing ExecuteSingle for {storedProcedure}", ex);
            }
        }

        /// <summary>
        /// ExecuteDataTable
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public DataTable ExecuteDataTable(string storedProcedure, SqlParameter[] parameters = null)
        {
            var dataTable = new DataTable();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                            command.Parameters.AddRange(parameters);

                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing ExecuteDataTable for {storedProcedure}", ex);
            }

            return dataTable;
        }

        /// <summary>
        /// ExecuteDataSet
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public DataSet ExecuteDataSet(string storedProcedure, SqlParameter[] parameters = null)
        {
            var dataSet = new DataSet();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                            command.Parameters.AddRange(parameters);

                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataSet);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing ExecuteDataSet for {storedProcedure}", ex);
            }

            return dataSet;
        }
    }

}
