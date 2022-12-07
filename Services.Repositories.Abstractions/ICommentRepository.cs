using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// Репозиторий для работы с отзывами
    /// </summary>
    public interface ICommentRepository:IRepository<Comment,Guid>
    {
    }
}
