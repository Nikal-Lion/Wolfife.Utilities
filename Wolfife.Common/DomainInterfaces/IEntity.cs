namespace Wolfife.Common.DomainInterfaces
{

    public interface IEntity<T>
        where T : struct
    {
        /// <summary>
        /// 实体Id
        /// </summary>
        T Id { get; set; }
    }
}
