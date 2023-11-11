using Bnpp.DataLayer.Entities.BasicData;
using Bnpp.DataLayer.Entities.ONOFF;
using Bnpp.DataLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.Services.Interfaces
{
    public interface IChangeService
    {

        List<ONOFFViewModel> GetAllChangeState();
		List<OFFViewModel> GetAllChangeStateForExport(int mechanicalId);
		int AddChangeState(ChangeState change);
        void UpdateChangeState(ChangeState change);
        ONOFFViewModel GetChangeStateById(int changeId);
		OFFViewModel GetChangeStateByIdForExport(int changeId);
		void DeleteChangeState(int changeId);




        List<States> GetAllStates();
        void AddStateToStaeChanges(int chngestateId, List<int> states);
        void EDitStateToStaeChanges(int chngestateId, List<int> statess);
    }
}
