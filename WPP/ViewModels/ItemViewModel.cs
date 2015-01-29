using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Web.Mvc.Html;
using WPP.Models;

namespace WPP.ViewModels
{
    public class ItemViewModel
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public int ID { set; get; }
        public virtual Catagorie Catagorie { get; set; }

        [DisplayName("Название")]
        [Required(ErrorMessage = "Название обязательно")]
        [StringLength(160)]
        public string Name { get; set; }

        [DisplayName("Описание")]
        [StringLength(1024)]
        public string Info { get; set; }


        [DisplayName("Цена")]
        [Required(ErrorMessage = "Цена обязательна")]
        [Range(1, 1000000, ErrorMessage = "Цена должна быть между 1 и 1000000")]
        public decimal Price { get; set; }


        public byte[] InternalImage { get; set; }

        [Display(Name = "Файл")]
        [NotMapped]
        public HttpPostedFileBase File
        {
            get
            {
                return null;
            }

            set
            {
                try
                {
                    MemoryStream target = new MemoryStream();

                    if (value.InputStream == null)
                        return;

                    value.InputStream.CopyTo(target);
                    InternalImage = target.ToArray();
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    logger.Error(ex.StackTrace);
                }
            }
        }

    }
}