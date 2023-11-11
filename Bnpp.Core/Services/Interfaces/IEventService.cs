using Bnpp.Core.ViewModels;
using Bnpp.DataLayer.Entities;
using Bnpp.DataLayer.Entities.BasicData;
using Bnpp.DataLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.Services.Interfaces
{
    public interface IEventService
    {
        List<Events> GetAllEvents(int mechanicalId);

		List<InternalEventsViewModel> GetAllEventsForExport(int mechanicalId);

		int AddEvents(Events events, IFormFile imgEvents);
        void UpdateEvents(Events events, IFormFile imgEvents);
        Events GetEventsById(int eventsId);
		InternalEventsViewModel GetEventsByIdForExport(int evenId);

		void DeleteEvents(int eventsId);

        #region Before After

        BeforeStatusViewModel GetBeforStatusForShow(int eventsId);
        void BeforeStatusEvents(BeforeStatusViewModel beforeEvents, int eventsId);

        AfterStatusViewModel GetAfterStatusForShow(int eventsId);
        void AfterStatusEvents(AfterStatusViewModel afterEvents, int eventsId);

		#endregion

		#region External Events
		List<ExternalEvents> GetAllExternalEvents(int mechanicalId);
        List<ExternalEventsViewModel> GetAllExternalEventsForExport(int mechanicalId);
        int AddExternalEvents(ExternalEvents external, IFormFile imgEvents);
        void DeleteExternaEvents(int eventsId);
        ExternalEvents GetExternalEventsById(int eventsId);
        ExternalEventsViewModel GetExternalEventsByIdForExport(int eventId);
        void UpdateExternalEvents(ExternalEvents events, IFormFile imgEvents);
        #endregion

        #region Related Ageing Mechanism

        List<RelatedAgeingMechanism> GetAllRelatedAgeingMechanism();

        List<SelectListItem> GetRelatedAgeingMechanism();

        int AddRelatedAgeingMechanism(RelatedAgeingMechanism ageingMechanism);
        void DeleteAgeingMechanism(int ageingMechanismId);
        RelatedAgeingMechanism GetRelatedAgeingMechanismById(int ageingMechanismId);

        void UpdateRelatedAgeingMechanism(RelatedAgeingMechanism ageingMechanism);

        #endregion
        #region Responsible Unit

        List<ResponsibleUnit> GetAllResponsibleUnit();
        List<SelectListItem> GetResponsibleUnit();
        int AddResponsibleUnit(ResponsibleUnit responsibleUnit);
        ResponsibleUnit GetResponsibleUnitById(int responsibleId);
        void UpdateResponsibleUnit(ResponsibleUnit responsibleUnit);
        void DeleteResponsibleUnit(int responsibleUnitId);
        #endregion
    }
}
