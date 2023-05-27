using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Wolfife.Common.Extensions
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerSettings _serializerSettings;

        static JsonExtensions()
        {
            var timeFormat = new IsoDateTimeConverter
            {
                //时间转字符串
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
            };
            IList<JsonConverter> convertList = new List<JsonConverter>
            {
                timeFormat,

                new Json.TimestampConverter(),
            };
            _serializerSettings = new JsonSerializerSettings
            {
                // 设置为驼峰命名
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = convertList,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            };
        }
        /// <summary> 
        /// JSON文本转对象,泛型方法 
        /// </summary> 
        /// <typeparam name="T">类型</typeparam> 
        /// <param name="jsonText">JSON文本</param> 
        /// <returns>指定类型的对象</returns> 
        public static T ToT<T>(this string jsonText)
        {
            return JsonConvert.DeserializeObject<T>(jsonText);
        }

        /// <summary> 
        /// 对象转JSON (使用驼峰命名规则进行序列化)
        /// </summary> 
        /// <param name="obj">对象</param> 
        /// <returns>JSON格式的字符串</returns> 
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None, _serializerSettings);
        }

    }
}
