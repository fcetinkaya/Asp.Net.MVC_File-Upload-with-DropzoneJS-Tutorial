using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetMvc_Fileupload_DropzoneJs.Models
{
    public class ProductPicture
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(80), Required]
        public string FileName { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        // Id auto make
        public ProductPicture()
        {
            Id = Guid.NewGuid();
        }
    }
}