using Microsoft.Data.SqlClient;
using PYP_PhoneDrectory.Abstractions.Repositories;
using PYP_PhoneDrectory.Entities.Abstract;
using PYP_PhoneDrectory.Helpers.StringCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PYP_PhoneDrectory.Repositories
{
    public class AdoNetRepository<T> : IRepository<T> where T : class, IEntity
    {
        const string connectionString = "Server=DESKTOP-FHK353D;Database=PhoneDirectory;Integrated Security=True; MultipleActiveResultSets=true";

        public bool Add(T entity)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string sqlQuery = string.Empty;
            string tableName = TableNameCreate<T>.ConfigureTableName(entity);


            sqlQuery = $"insert into {tableName} (";
            foreach (var property in entity.GetType().GetProperties())
            {
                if (property.Name.ToLower().Contains("ıd") || property.Name.ToLower().Contains("id")) continue;
                sqlQuery += property.Name + ",";

            }
            sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 1);
            sqlQuery += ") values(";
            foreach (var property in entity.GetType().GetProperties())
            {
                if (property.Name.ToLower().Contains("ıd") || property.Name.ToLower().Contains("id")) continue;
                sqlQuery += "'" + property.GetValue(entity) + "'" + ",";
            }
            sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 1);
            sqlQuery += ")";
            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, connection);
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            if (result == 0) return false;
            return true;

        }

        public bool Delete(T entity)
        {
            string sqlQuery = string.Empty;
            string tableName = TableNameCreate<T>.ConfigureTableName(entity);
            sqlQuery = $"Delete {tableName} ";
            PropertyInfo property = entity.GetType().GetProperties().FirstOrDefault(c => c.Name.ToLower().Contains("ıd") || c.Name.ToLower().Contains("id"));
            if (property == null)
            {
                return false;
            }
            sqlQuery += $"where {property.Name}={property.GetValue(entity)}";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, connection);
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            if (result == 0) return false;
            return true;
        }

        public T Get(Expression<Func<T, bool>> filter=null)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            string sqlQuery = String.Empty;
            sqlQuery = $"select * from =N'{typeof(T).Name}s'";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, connection);
            SqlDataReader reader = cmd.ExecuteReader();
             int i=0;
            List<T> list = new List<T>();
            while(reader.Read())
            {
                var tableName=reader[i++].ToString();
                //comming sooon :D
            }
            return list;

        }

        public bool Update(int id,T entity)
        {
            string sqlQuery = String.Empty;
            string tableName = TableNameCreate<T>.ConfigureTableName(entity);
            sqlQuery += $"update {tableName} set ";
            foreach (var property in entity.GetType().GetProperties())
            {
                if ( property.Name.ToLower().Contains("ıd") || property.Name.ToLower().Contains("id")) continue;
                sqlQuery += $"{property.Name} = '{property.GetValue(entity)}',";
            }
            sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 1);


            PropertyInfo propertyInfo = entity.GetType().GetProperties().FirstOrDefault(c => c.Name.ToLower().Contains("ıd") || c.Name.ToLower().Contains("id")); 
            if (propertyInfo == null) throw new Exception();
            sqlQuery += $" where {propertyInfo.Name}={propertyInfo.GetValue(entity)}";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, connection);
            var result = cmd.ExecuteNonQuery();
            if (result == 0) return false;
            return true;

        }
    }
}
