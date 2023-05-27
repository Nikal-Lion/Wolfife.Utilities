using System.ComponentModel.DataAnnotations;

namespace Wolfife.Common
{
    /// <summary>
    /// 分页参数
    /// </summary>
    public interface IPagination
    {
        /// <summary>
        /// 条数
        /// </summary>
        [Required]
        int PageIndex { get; set; }
        /// <summary>
        /// 第几页
        /// </summary>
        [Required]
        int PageSize { get; set; }
    }
    /// <summary>
    /// 分页查询必须参数
    /// </summary>
    public class Pagination : IPagination
    {
        public Pagination()
        {
            this.PageIndex = 1;
            this.PageSize = 20;
        }
        public Pagination(int index, int size) : this()
        {
            this.PageIndex = index;
            this.PageSize = size;
        }
        /// <summary>
        /// 条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 第几页
        /// </summary>
        public int PageIndex { get; set; }
    }
}
