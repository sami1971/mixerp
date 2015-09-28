// ReSharper disable All
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MixERP.Net.Api.Framework;
using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Extensions;
using MixERP.Net.EntityParser;
using MixERP.Net.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PetaPoco;

namespace MixERP.Net.Api.HRM
{
    /// <summary>
    ///     Provides a direct HTTP access to perform various tasks such as adding, editing, and removing Provident Fund Expense Account Selector Views.
    /// </summary>
    [RoutePrefix("api/v1.5/hrm/provident-fund-expense-account-selector-view")]
    public class ProvidentFundExpenseAccountSelectorViewController : ApiController
    {
        /// <summary>
        ///     The ProvidentFundExpenseAccountSelectorView data context.
        /// </summary>
        private readonly MixERP.Net.Core.Modules.HRM.Data.ProvidentFundExpenseAccountSelectorView ProvidentFundExpenseAccountSelectorViewContext;

        public ProvidentFundExpenseAccountSelectorViewController()
        {
            this._LoginId = AppUsers.GetCurrent().View.LoginId.ToLong();
            this._UserId = AppUsers.GetCurrent().View.UserId.ToInt();
            this._OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();
            this._Catalog = AppUsers.GetCurrentUserDB();

            this.ProvidentFundExpenseAccountSelectorViewContext = new MixERP.Net.Core.Modules.HRM.Data.ProvidentFundExpenseAccountSelectorView
            {
                _Catalog = this._Catalog,
                _LoginId = this._LoginId,
                _UserId = this._UserId
            };
        }

        public long _LoginId { get; }
        public int _UserId { get; private set; }
        public int _OfficeId { get; private set; }
        public string _Catalog { get; }

        /// <summary>
        ///     Counts the number of provident fund expense account selector views.
        /// </summary>
        /// <returns>Returns the count of the provident fund expense account selector views.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count")]
        [Route("~/api/hrm/provident-fund-expense-account-selector-view/count")]
        public long Count()
        {
            try
            {
                return this.ProvidentFundExpenseAccountSelectorViewContext.Count();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (MixERPException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }


        /// <summary>
        ///     Creates a paginated collection containing 10 provident fund expense account selector views on each page, sorted by the property .
        /// </summary>
        /// <returns>Returns the first page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("")]
        [Route("~/api/hrm/provident-fund-expense-account-selector-view")]
        public IEnumerable<MixERP.Net.Entities.HRM.ProvidentFundExpenseAccountSelectorView> GetPagedResult()
        {
            try
            {
                return this.ProvidentFundExpenseAccountSelectorViewContext.GetPagedResult();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (MixERPException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Creates a paginated collection containing 10 provident fund expense account selector views on each page, sorted by the property .
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <returns>Returns the requested page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("page/{pageNumber}")]
        [Route("~/api/hrm/provident-fund-expense-account-selector-view/page/{pageNumber}")]
        public IEnumerable<MixERP.Net.Entities.HRM.ProvidentFundExpenseAccountSelectorView> GetPagedResult(long pageNumber)
        {
            try
            {
                return this.ProvidentFundExpenseAccountSelectorViewContext.GetPagedResult(pageNumber);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (MixERPException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Displayfield is a lightweight key/value collection of provident fund expense account selector views.
        /// </summary>
        /// <returns>Returns an enumerable key/value collection of provident fund expense account selector views.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("display-fields")]
        [Route("~/api/hrm/provident-fund-expense-account-selector-view/display-fields")]
        public IEnumerable<DisplayField> GetDisplayFields()
        {
            try
            {
                return this.ProvidentFundExpenseAccountSelectorViewContext.GetDisplayFields();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (MixERPException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Counts the number of provident fund expense account selector views using the supplied filter(s).
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns the count of filtered provident fund expense account selector views.</returns>
        [AcceptVerbs("POST")]
        [Route("count-where")]
        [Route("~/api/hrm/provident-fund-expense-account-selector-view/count-where")]
        public long CountWhere([FromBody]JArray filters)
        {
            try
            {
                List<EntityParser.Filter> f = filters.ToObject<List<EntityParser.Filter>>(JsonHelper.GetJsonSerializer());
                return this.ProvidentFundExpenseAccountSelectorViewContext.CountWhere(f);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (MixERPException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Creates a filtered and paginated collection containing 10 provident fund expense account selector views on each page, sorted by the property .
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns the requested page from the collection using the supplied filters.</returns>
        [AcceptVerbs("POST")]
        [Route("get-where/{pageNumber}")]
        [Route("~/api/hrm/provident-fund-expense-account-selector-view/get-where/{pageNumber}")]
        public IEnumerable<MixERP.Net.Entities.HRM.ProvidentFundExpenseAccountSelectorView> GetWhere(long pageNumber, [FromBody]JArray filters)
        {
            try
            {
                List<EntityParser.Filter> f = filters.ToObject<List<EntityParser.Filter>>(JsonHelper.GetJsonSerializer());
                return this.ProvidentFundExpenseAccountSelectorViewContext.GetWhere(pageNumber, f);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (MixERPException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Counts the number of provident fund expense account selector views using the supplied filter name.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns the count of filtered provident fund expense account selector views.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count-filtered/{filterName}")]
        [Route("~/api/hrm/provident-fund-expense-account-selector-view/count-filtered/{filterName}")]
        public long CountFiltered(string filterName)
        {
            try
            {
                return this.ProvidentFundExpenseAccountSelectorViewContext.CountFiltered(filterName);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (MixERPException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }


        /// <summary>
        ///     Creates a filtered and paginated collection containing 10 provident fund expense account selector views on each page, sorted by the property .
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns the requested page from the collection using the supplied filters.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("get-filtered/{pageNumber}/{filterName}")]
        [Route("~/api/hrm/provident-fund-expense-account-selector-view/get-filtered/{pageNumber}/{filterName}")]
        public IEnumerable<MixERP.Net.Entities.HRM.ProvidentFundExpenseAccountSelectorView> GetFiltered(long pageNumber, string filterName)
        {
            try
            {
                return this.ProvidentFundExpenseAccountSelectorViewContext.GetFiltered(pageNumber, filterName);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (MixERPException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

    }
}