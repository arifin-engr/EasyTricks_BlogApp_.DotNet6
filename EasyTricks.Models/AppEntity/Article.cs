using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EasyTricks.Models.AppEntity
{
    public class Article: BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [AllowHtml]
        public string Description { get; set; }
        [Display(Name ="Image")]
        [ValidateNever]
        public  string ImagePath { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category? Category { get; set; }
        [Required]
        [Display(Name = "Sub Category")]
        public int SubCategoryId { get; set; }
  
    }
}
