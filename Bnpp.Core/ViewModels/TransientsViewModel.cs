using Bnpp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.ViewModels
{
    public class SaveTransientsViewModel
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string AllowableNumber { get; set; }

        public DateTime TransientDate { get; set; }

        public string TransientTime { get; set; }
    }
}
