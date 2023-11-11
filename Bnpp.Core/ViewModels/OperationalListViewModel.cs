using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.ViewModels
{
    public class NormalOperationListViewModel
    {
        public int OperationalId { get; set; }

        [Display(Name = "NameOfCondition")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string NameOfCondition { get; set; }

        [Display(Name = "AllowableNumber")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string AllowableNumber { get; set; }

        [Display(Name = "Occurrances")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string Occurrances { get; set; }
        public DateTime CreateDate { get; set; }
        public string Dates { get; set; }
        public bool IsDelete { get; set; }
    }

    public class OccuranceListViewModel
    {
        public int OccuranceId { get; set; }

        [Display(Name = "NameOfCondition")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string NameOfCondition { get; set; }

        [Display(Name = "AllowableNumber")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string AllowableNumber { get; set; }

        [Display(Name = "Occurrances")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string Occurrances { get; set; }
        public DateTime CreateDate { get; set; }
        public string Date { get; set; }
    }

    public class DesignBasisListViewModel
    {
        public int DesigneId { get; set; }

        [Display(Name = "NameOfCondition")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string NameOfCondition { get; set; }

        [Display(Name = "AllowableNumber")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string AllowableNumber { get; set; }

        [Display(Name = "Occurrances")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string Occurrances { get; set; }
        public DateTime CreateDate { get; set; }
        public string Date { get; set; }
    }
}
