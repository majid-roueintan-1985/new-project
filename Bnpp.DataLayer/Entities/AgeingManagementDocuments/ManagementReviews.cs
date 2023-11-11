using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bnpp.DataLayer.Entities.AgeingManagementDocuments
{
    public class ManagementReviews
    {
        [Key]
        public int ReviewsId { get; set; }

        public string Type { get; set; }

        public string Frequency { get; set; }

        public string Prepared { get; set; }

        public string Authorized { get; set; }
        public string Approved { get; set; }

        public DateTime Date { get; set; }

        public DateTime  CreateDate { get; set; }
        public bool  IsDelete { get; set; }
    }
}
