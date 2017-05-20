using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuShop.Models.Abstracts
{
    public abstract class CommonInfo : ICommonInfo
    {
        [MaxLength(256)]
        public string CreatedBy
        {
            get;

            set;
        }

        public DateTime CreatedDate
        {
            get;
            set;
        }
        [MaxLength(256)]
        public string UpdatedBy
        {
            get;

            set;
        }

        public DateTime? UpdatedDate
        {
            get;
            set;
        }

        public bool Status
        {
            get;
            set;
        }

        [MaxLength(256)]
        public string MetaDescription
        {
            get;

            set;
        }

        [MaxLength(256)]
        public string MetaKeyword
        {
            get;
            set;
        }


    }
}
