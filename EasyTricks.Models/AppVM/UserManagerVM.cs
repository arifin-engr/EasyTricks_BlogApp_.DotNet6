using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTricks.Models.AppVM
{
    public class UserManagerVM
    {
        public IdentityUser User { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Roles { get; set; }
        public string Role { get; set; }
    }
}
