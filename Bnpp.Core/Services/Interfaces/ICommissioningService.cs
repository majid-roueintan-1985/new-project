using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Entities;

namespace Bnpp.Core.Services.Interfaces
{
    public interface ICommissioningService
    {
        List<Commissioning> GetAllCommissioning(int mechanicalId);
        List<CommissioningViewModel> GetAllCommissioningForExport(int mechanicalId);

        int AddCommissioning(Commissioning commissioning);

        void UpdateCommissioning(Commissioning commissioning);
        Commissioning GetCommissioningById(int commissioningId);
        CommissioningViewModel GetCommissioningByIdForExport(int commissioningId);

        void DeleteCommissioning(int commissioningId);
    }
}
