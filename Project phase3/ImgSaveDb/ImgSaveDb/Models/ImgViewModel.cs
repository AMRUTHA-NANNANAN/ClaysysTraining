using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImgSaveDb.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using Helper_Code.Objects;

     
    public class ImgViewModel
    {
        #region Properties  

         
        [Required]
        [Display(Name = "Upload File")]
        public HttpPostedFileBase FileAttach { get; set; }

        
        public List<ImgObj> ImgLst { get; set; }

        #endregion
    }
}