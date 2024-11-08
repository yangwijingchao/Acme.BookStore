using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BookStore.Domain.Shared.Books
{
    // 定义一个枚举类型，表示书籍的类型
    public enum BookType
    {
        /// <summary>
        /// 未定义
        /// </summary>
        Undefined,
        /// <summary>
        /// 冒险
        /// </summary>
        Adventure,
        /// <summary>
        /// 传记
        /// </summary>
        Biography,
        /// <summary>
        /// 反乌托邦
        /// </summary>
        Dystopia,
        /// <summary>
        /// 奇幻
        /// </summary>
        Fantastic,
        /// <summary>
        /// 恐怖
        /// </summary>
        Horror,
        /// <summary>
        /// 科学
        /// </summary>
        Science,
        /// <summary>
        /// 科幻
        /// </summary>
        ScienceFiction,
        /// <summary>
        /// 诗歌
        /// </summary>
        Poetry
    }
}
