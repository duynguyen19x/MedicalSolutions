using MedicalSolutions.DataAccess.Common;
using MedicalSolutions.DataAccess.IDAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSolutions.DataAccess.DAO
{
    public class BaseDao : IBaseDao
    {
        public T Make<T>(IDataRecord record) where T : new()
        {
            T obj = new T();
            Type myType = obj.GetType();
            for (int i = 0; i < record.FieldCount; i++)
            {
                string fieldName = record.GetName(i).Replace("ID", "Id");
                if (!string.IsNullOrEmpty(fieldName))
                {
                    System.Reflection.PropertyInfo pro = myType.GetProperty(fieldName);
                    if (pro != null)
                    {
                        var proType = pro.PropertyType;
                        var value = record[i];

                        if (proType.Equals(typeof(string)))
                            value = value.AsString(string.Empty);
                        else if (proType.Equals(typeof(bool)))
                            value = value.AsBool();
                        else if (proType.Equals(typeof(bool?)))
                            value = value.AsBoolForNull();
                        else if (proType.Equals(typeof(int)))
                            value = value.AsInt();
                        else if (proType.Equals(typeof(int?)))
                            value = value.AsIntForNull();
                        else if (proType.Equals(typeof(long)))
                            value = value.AsLong();
                        else if (proType.Equals(typeof(byte)))
                            value = value.AsByte();
                        else if (proType.Equals(typeof(short)))
                            value = value.AsShort();
                        else if (proType.Equals(typeof(short?)))
                            value = value.AsShortForNull();
                        else if (proType.Equals(typeof(double)))
                            value = value.AsDouble();
                        else if (proType.Equals(typeof(decimal)))
                            value = value.AsDecimal();
                        else if (proType.Equals(typeof(decimal?)))
                            value = value.AsDecimalForNull();
                        else if (proType.Equals(typeof(float)))
                            value = value.AsFloat();
                        else if (proType.Equals(typeof(float?)))
                            value = value.AsFloatForNull();
                        else if (proType.Equals(typeof(DateTime)))
                            value = value.AsDateTime();
                        else if (proType.Equals(typeof(DateTime?)))
                            value = value.AsDateTimeForNull();
                        else if (proType.Equals(typeof(Guid)))
                            value = value.AsGuid();
                        else
                            continue;

                        pro.SetValue(obj, value, null);
                    }
                }
            }

            return obj;
        }
    }
}
