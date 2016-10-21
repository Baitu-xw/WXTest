using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;


namespace WX_TennisAssociation.Common
{
    #region  DataTable转换成List的类
    /// <summary>
    /// DataTable转换成List的类
    /// </summary>
    public class ConvertDataTableToList
    {
        /// <summary>
        /// DataTable转换成List的方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static List<T> DataTableToList<T>(DataTable dataTable)
        {
            List<T> list = new List<T>();
            Type targetType = typeof(T);
            PropertyInfo[] allPropertyArray = targetType.GetProperties();
            foreach (DataRow rowElement in dataTable.Rows)
            {
                T element = Activator.CreateInstance<T>();
                foreach (DataColumn columnElement in dataTable.Columns)
                {
                    foreach (PropertyInfo property in allPropertyArray)
                    {
                        if (property.Name.Equals(columnElement.ColumnName))
                        {
                            if (rowElement[columnElement.ColumnName] == DBNull.Value)
                            {
                                property.SetValue(element, null, null);
                            }
                            else
                            {
                                property.SetValue(element, rowElement[columnElement.ColumnName], null);
                            }
                        }
                    }
                }
                list.Add(element);
            }
            return list;
        }
    }
    #endregion
}
