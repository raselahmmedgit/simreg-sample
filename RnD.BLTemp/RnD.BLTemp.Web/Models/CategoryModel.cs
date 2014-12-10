using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RnD.BLTemp.Web.Models
{
    public class CategoryModel : BaseModel
    {
        [Key]
        [Required]
        [Display(Name = "Category Id")]
        public Int32 CategoryId { set; get; }
        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { set; get; }
    }
}