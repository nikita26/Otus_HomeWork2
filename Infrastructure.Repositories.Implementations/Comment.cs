using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Services.Repositories.Abstractions;
using Infrastructure.EntityFramework;

namespace Infrastructure.Repositories.Implementations
{
    public class CommentRepository:Repository<Comment,Guid>,ICommentRepository
    {
        public CommentRepository(DataBaseContext context) : base(context)
        {

        }
    }
}
