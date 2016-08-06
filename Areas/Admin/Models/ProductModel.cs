using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopOnline5K.Areas.Admin.Models
{
    public class ProductModel
    {
        [Key]
        public int PRODUCT_ID { get; set; }

        public int? GROUP_PRODUCT_ID { get; set; }

        [Required]
        [StringLength(150)]
        public string NAME { get; set; }

        public int? TAG_ID { get; set; }

        [Column(TypeName = "ntext")]
        public string DETAIL { get; set; }

        public decimal PRICE { get; set; }

        public string IMAGE_LINK { get; set; }

        public string IMAGE_LIST1 { get; set; }
        public string IMAGE_LIST2 { get; set; }
        public string IMAGE_LIST3 { get; set; }

        [Column(TypeName = "xml")]
        public string IMAGE_LIST { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CREATED_DATE { get; set; }

        public decimal? DISCOUNT_PRICE { get; set; }

        public int? ORDER { get; set; }

        public bool STATUS { get; set; }

        public virtual GROUPPRODUCT GROUPPRODUCT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERDETAIL> ORDERDETAILs { get; set; }

        public virtual TAG TAG { get; set; }
    }
}