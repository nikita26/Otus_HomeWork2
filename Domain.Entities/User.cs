using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : IEntity<Guid> 
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronimic { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Товары
        /// </summary>
        public IEnumerable<Product> Products{ get; set; }

        /// <summary>
        /// Комментарии
        /// </summary>
        public IEnumerable<Comment> Comments{ get; set; }
    }
}
