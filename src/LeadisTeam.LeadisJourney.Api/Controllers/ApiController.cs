using LeadisTeam.LeadisJourney.Repositories.NHibernate;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LeadisTeam.LeadisJourney.Api.Controllers {
    [EnableCors("AllowAll")]
    public abstract class ApiController : Controller {
        private readonly IScopeFactory _scopeFactory;

        protected ApiController(IScopeFactory scopeFactory) {
            _scopeFactory = scopeFactory;
        }

        public override void OnActionExecuting(ActionExecutingContext context) {
            _scopeFactory.BeginTransaction();
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context) {
            _scopeFactory.Commit();
            base.OnActionExecuted(context);
        }
    }
}