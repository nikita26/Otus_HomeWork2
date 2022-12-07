using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Стоимость товара
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Комментарии
        /// </summary>
        public IEnumerable<CommentDto> Comments { get; set; }

    }
}
