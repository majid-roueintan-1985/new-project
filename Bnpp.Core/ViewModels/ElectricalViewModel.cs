using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.ViewModels
{
    public class CableListViewModel
    {
        public int CableId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string Name { get; set; }

        [Display(Name = "Azk")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string Azk { get; set; }

        [Display(Name = "InstalationPosition")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string InstalationPosition { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class ElectromotorsListViewModel
    {
        public int electromotorId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string Name { get; set; }

        [Display(Name = "Azk")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string Azk { get; set; }

        [Display(Name = "InstalationPosition")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string InstalationPosition { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class ElectromotorsExportViewModel
    {
        public string Name { get; set; }

        public string Azk { get; set; }

        public string InstalationPosition { get; set; }
    }

    public class GeneratorListViewModel
    {
        public int generatorId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string Name { get; set; }

        [Display(Name = "Azk")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string Azk { get; set; }

        [Display(Name = "InstalationPosition")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string InstalationPosition { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class GeneratorExportViewModel
    {
        public string Name { get; set; }

        public string Azk { get; set; }

        public string InstalationPosition { get; set; }
    }

    public class TransformerListViewModel
    {
        public int transformerId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string Name { get; set; }

        [Display(Name = "Azk")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string Azk { get; set; }

        [Display(Name = "InstalationPosition")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string InstalationPosition { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class TransformerExportViewModel
    {
        public string Name { get; set; }

        public string Azk { get; set; }

        public string InstalationPosition { get; set; }
    }

    public class ValvesListViewModel
    {
        public int ValveId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string Name { get; set; }

        [Display(Name = "Azk")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string Azk { get; set; }

        [Display(Name = "InstalationPosition")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string InstalationPosition { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class ValvesExportViewModel
    {
        public string Name { get; set; }

        public string Azk { get; set; }

        public string InstalationPosition { get; set; }
    }

    public class DieselListViewModel
    {
        public int DieselId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string Name { get; set; }

        [Display(Name = "Azk")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string Azk { get; set; }

        [Display(Name = "InstalationPosition")]
        [Required(ErrorMessage = "please insert  {0}")]
        public string InstalationPosition { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class DieselExportViewModel
    {
        public string Name { get; set; }

        public string Azk { get; set; }

        public string InstalationPosition { get; set; }
    }
}
