using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImgSaveDb.Helper_Code.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>  
    /// Image object class.  
    /// </summary>  
    public class ImgObj
    {
        #region Properties  

        /// <summary>  
        /// Gets or sets Image ID.  
        /// </summary>  
        public int FileId { get; set; }

        /// <summary>  
        /// Gets or sets Image name.  
        /// </summary>  
        public string FileName { get; set; }

        /// <summary>  
        /// Gets or sets Image extension.  
        /// </summary>  
        public string FileContentType { get; set; }

        #endregion
    }
}