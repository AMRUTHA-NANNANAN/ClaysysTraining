using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImgSaveDb.Controllers
{using ImgSaveDb.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Helper_Code.Objects;
    using Models;

    /// <summary>  
    /// Image controller class.  
    /// </summary>  
    public class ImgController : Controller
    {
        #region Private Properties  

        /// <summary>  
        /// Gets or sets database manager property.  
        /// </summary>  
        private db_imgEntities1 databaseManager = new db_imgEntities1();

        #endregion

        #region Index view method.  

        #region Get: /Img/Index method.  

        /// <summary>  
        /// Get: /Img/Index method.  
        /// </summary>          
        /// <returns>Return index view</returns>  
        public ActionResult Index()
        {
            // Initialization.  
            ImgViewModel model = new ImgViewModel { FileAttach = null, ImgLst = new List<ImgObj>() };

            try
            {
                // Settings.  
                model.ImgLst = this.databaseManager.sp_get_all_files().Select(p => new ImgObj
                {
                    FileId = p.file_id,
                    FileName = p.file_name,
                    FileContentType = p.file_ext
                }).ToList();
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            // Info.  
            return this.View(model);
        }

        #endregion

        #region POST: /Img/Index  

        /// <summary>  
        /// POST: /Img/Index  
        /// </summary>  
        /// <param name="model">Model parameter</param>  
        /// <returns>Return - Response information</returns>  
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ImgViewModel model)
        {
            // Initialization.  
            string fileContent = string.Empty;
            string fileContentType = string.Empty;

            try
            {
                // Verification  
                if (ModelState.IsValid)
                {
                    // Converting to bytes.  
                    byte[] uploadedFile = new byte[model.FileAttach.InputStream.Length];
                    model.FileAttach.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

                    // Initialization.  
                    fileContent = Convert.ToBase64String(uploadedFile);
                    fileContentType = model.FileAttach.ContentType;

                    // Saving info.  
                    this.databaseManager.sp_insert_file(model.FileAttach.FileName, fileContentType, fileContent);
                }

                // Settings.  
                model.ImgLst = this.databaseManager.sp_get_all_files().Select(p => new ImgObj
                {
                    FileId = p.file_id,
                    FileName = p.file_name,
                    FileContentType = p.file_ext
                }).ToList();
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            // Info  
            return this.View(model);
        }

        #endregion

        #endregion

        #region Download file methods  

        #region GET: /Img/DownloadFile  

        /// <summary>  
        /// GET: /Img/DownloadFile  
        /// </summary>  
        /// <param name="fileId">File Id parameter</param>  
        /// <returns>Return download file</returns>  
        public ActionResult DownloadFile(int fileId)
        {
            // Model binding.  
            ImgViewModel model = new ImgViewModel { FileAttach = null, ImgLst = new List<ImgObj>() };

            try
            {
                // Loading dile info.  
                var fileInfo = this.databaseManager.sp_get_file_details(fileId).First();

                // Info.  
                return this.GetFile(fileInfo.file_base6, fileInfo.file_ext);
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            // Info.  
            return this.View(model);
        }

        #endregion

        #endregion

        #region Helpers  

        #region Get file method.  

        /// <summary>  
        /// Get file method.  
        /// </summary>  
        /// <param name="fileContent">File content parameter.</param>  
        /// <param name="fileContentType">File content type parameter</param>  
        /// <returns>Returns - File.</returns>  
        private FileResult GetFile(string fileContent, string fileContentType)
        {
            // Initialization.  
            FileResult file = null;

            try
            {
                // Get file.  
                byte[] byteContent = Convert.FromBase64String(fileContent);
                file = this.File(byteContent, fileContentType);
            }
            catch (Exception ex)
            {
                // Info.  
                throw ex;
            }

            // info.  
            return file;
        }

        #endregion

        #endregion
    }
}