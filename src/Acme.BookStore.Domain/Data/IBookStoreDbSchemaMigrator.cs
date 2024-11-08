using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BookStore.Domain.Data
{
    /// <summary>
    /// 数据库结构迁移接口
    /// </summary>
    public interface IBookStoreDbSchemaMigrator
    {
        // 异步迁移数据库架构
        Task MigrateAsync();
    }
}
