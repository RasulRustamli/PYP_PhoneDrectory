using PYP_PhoneDrectory.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYP_PhoneDrectory.Helpers.StringCheck
{
    public class TableNameCreate<T>where T : class,IEntity
    {
        public static string ConfigureTableName(T entity)
        {
            string tableName = entity.GetType().Name;
            if (tableName.EndsWith('y'))
            {
                return $"{tableName.Substring(0, tableName.Length - 1) + "ies"}";
            }

            return $"{tableName}s";
        }
    }
}
