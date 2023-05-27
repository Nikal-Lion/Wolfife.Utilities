namespace Wolfife.Common.Enums
{
    /// <summary>
    /// 日志级别
    /// </summary>
    public enum ELogLevel
    {
        /// <summary>
        /// 用于调试。级别最低
        /// </summary>
        Debug = 1,
        /// <summary>
        /// 用于显示信息给用户。级别高于<see cref="Debug"/>
        /// </summary>
        Info = 2,
        /// <summary>
        /// 用于发出警告，但系统可以正常执行。级别高于<see cref="Info"/>
        /// </summary>
        Warn = 3,
        /// <summary>
        /// 用于发出错误，但不确定系统能否正常执行。级别高于<see cref="Warn"/>
        /// </summary>
        Error = 4,
        /// <summary>
        /// 用于发出失控，但系统已经不能正常执行了。级别最高
        /// </summary>
        Fatal = 5,
    }
}
