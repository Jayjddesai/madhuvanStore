using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Madhuvan.Businesslayer
{
    public static class JsonHelper
    {
        #region Constant
        public const string DateFormat = "dd MMM yyyy";
        #endregion

        #region Methods
        public static string BindDatasourceInJsonFormat<T>(string dateForamtString, IEnumerable<T> objects)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            var enumerable = objects as T[] ?? objects.ToArray();

            StringBuilder dataSource = new StringBuilder();
            for (int i = 0; i < enumerable.Count(); i++)
            {
                dataSource.Append("{");
                for (int k = 0; k < properties.Count(); k++)
                {
                    dataSource.Append(properties[k].Name + ":");
                    var propertyValue = properties[k].GetValue(enumerable.ElementAt(i), null);
                    dataSource.Append(GetJsonValue(dateForamtString, propertyValue));
                }
                if (properties.Any()) dataSource.Length--;
                dataSource.Append("},");
            }
            if (enumerable.Any())
                dataSource.Length--;
            return dataSource.ToString();
        }

        public static string BindDatasourceInJsonFormat<T>(IEnumerable<T> objects, List<string> columnsToIncludeInJson, string dateForamtString = DateFormat)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            var enumerable = objects as T[] ?? objects.ToArray();

            StringBuilder dataSource = new StringBuilder();
            for (int i = 0; i < enumerable.Count(); i++)
            {
                dataSource.Append("{");
                for (int k = 0; k < properties.Count(); k++)
                {
                    if (!columnsToIncludeInJson.Contains(properties[k].Name)) continue;

                    dataSource.Append(properties[k].Name + ":");
                    var propertyValue = properties[k].GetValue(enumerable.ElementAt(i), null);
                    dataSource.Append(GetJsonValue(dateForamtString, propertyValue));
                }
                if (properties.Any()) dataSource.Length--;
                dataSource.Append("},");
            }
            if (enumerable.Any())
                dataSource.Length--;
            return dataSource.ToString();
        }

        private static string GetJsonValue(string dateForamtString, object propertyValue)
        {

            StringBuilder dataSource = new StringBuilder();
            if (propertyValue is string || propertyValue is DateTime)
            {
                if (String.IsNullOrEmpty(propertyValue.ToString()))
                {
                    dataSource.Append(@"""" + "" + @""",");
                }
                else if (propertyValue is DateTime)
                {
                    dataSource.Append(@"""" + ((DateTime)propertyValue).ToString(dateForamtString) + @""",");
                }
                else
                {
                    propertyValue = propertyValue.ToString().Replace("'", "");
                    propertyValue = propertyValue.ToString().Replace("\"", "");
                    propertyValue = propertyValue.ToString().Replace(",", "");
                    propertyValue = propertyValue.ToString().Replace("[", "");
                    propertyValue = propertyValue.ToString().Replace("]", "");
                    propertyValue = propertyValue.ToString().Replace("{", "");
                    propertyValue = propertyValue.ToString().Replace("}", "");
                    dataSource.Append(@"""" + propertyValue + @""",");
                }
            }
            else if (propertyValue is bool)
            {
                dataSource.Append(@"""" + propertyValue.ToString().ToLower() + @""",");
            }
            else if (propertyValue == null)
            {
                dataSource.Append(@"""" + "" + @""",");
            }
            else
            {
                dataSource.Append(propertyValue + ",");
            }

            return dataSource.ToString();
        }

        public static bool CheckJson(JsonResult jResult)
        {
            try
            {
                var serializer = new JavaScriptSerializer();
                serializer.DeserializeObject(jResult.Data.ToString());
                return true;
            }
            catch (ArgumentException exArgu)
            {
                if (exArgu.ToString().Contains("Invalid JSON primitive"))
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Function returns JSON with error message
        /// </summary>
        /// <param name="message">message</param>
        /// <returns></returns>
        public static JsonResult JsonWithError(string message)
        {
            var json = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data =
                    string.Format(@"[{{'error': '{0} {1}'}}]", "Error occurred. Please contact On-IT1.",
                                  "Web service method exception: " + message)
            };
            return json;
        }

        /// <summary>
        /// Function returns JSON with success message
        /// </summary>
        /// <param name="message">message</param>
        /// <returns></returns>
        public static JsonResult JsonWithSuccess(string message)
        {
            var json = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = string.Format(@"[{{'success': '{0}'}}]", message)
            };
            return json;
        }

        /// <summary>
        /// Function returns JSON with Fail message
        /// </summary>
        /// <param name="message">message</param>
        /// <returns></returns>
        public static JsonResult JsonWithFail(string message)
        {
            var json = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = string.Format(@"[{{'fail': '{0}'}}]", message)
            };
            return json;
        }
        #endregion
    }
}
