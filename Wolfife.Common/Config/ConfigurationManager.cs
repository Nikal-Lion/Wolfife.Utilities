using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace Wolfife.Common.Config
{
    public sealed class ConfigurationManager
    {

        /// <summary>
        /// current environment
        /// </summary>
        public static string CurrentEnvironment
        {
            get
            {
                string _environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                return string.IsNullOrWhiteSpace(_environment) ? "Product" : _environment;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private static readonly Dictionary<string, string> _environmentDictionary =
            new Dictionary<string, string>(2) {
                {"Development" , "appsettings.Development.json" },
                {"Product" , "appsettings.json" },
            };

        /// <summary>
        /// 各个环境对应配置文件
        /// </summary>
        internal static string EnvironmentJsonPath
            => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _environmentDictionary[CurrentEnvironment]);

        ~ConfigurationManager()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        internal static IConfiguration Configuration { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public static void InitConfiguration(IConfiguration configuration)
            => ConfigurationManager.Configuration ??= configuration;

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        internal static string GetConnectionString(string key) => Configuration.GetConnectionString(key);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string AppSettings(params string[] keys) => AppSettings<string>(keys);

        /// <summary>
        /// get object data from configuration
        /// </summary>
        /// <typeparam name="T">the section in configuration's type</typeparam>
        /// <param name="keys"></param>
        /// <returns></returns>
        public T AppSettings<T>(params string[] keys)
        {
            var key = string.Join(":", keys);
            try
            {
                var section = Configuration.GetSection(key);
                var data = section.Get<T>();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }
    }
}