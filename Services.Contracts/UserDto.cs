using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Товары
        /// </summary>
        public IEnumerable<ProductDto> Products { get; set; }

        /// <summary>
        /// Комментарии
        /// </summary>
        public IEnumerable<CommentDto> Comments { get; set; }

    }
}
