using System.Web.Mvc;
using Kendo.Mvc.UI;

namespace Madhuvan.Businesslayer
{
    public interface IGenericKendoController<in T> where T : class
    {
        ActionResult Index();

        ActionResult KendoRead([DataSourceRequest] DataSourceRequest request);

        [AcceptVerbs(HttpVerbs.Post)]
        ActionResult KendoSave([DataSourceRequest] DataSourceRequest request, T model);

        [AcceptVerbs(HttpVerbs.Post)]
        ActionResult KendoDestroy([DataSourceRequest] DataSourceRequest request, T model);
    }
}
