namespace Wolfife.Common.DomainInterfaces
{
    /// <summary>
    /// 是否删除
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
