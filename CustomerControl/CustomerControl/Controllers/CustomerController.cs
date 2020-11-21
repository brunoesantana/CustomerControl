using CustomerControl.Auth;
using CustomerControl.Business.Interface;
using CustomerControl.Controllers.Base;
using CustomerControl.CrossCutting.Dto.Customer;
using CustomerControl.CrossCutting.Filter;
using CustomerControl.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace CustomerControl.Controllers
{
    [Route("api/v1/customers")]
    public class CustomerController : BaseController<Customer, CustomerFilter, CustomerDTO, CustomerInsertDTO, CustomerUpdateDTO>
    {
        public CustomerController(ICustomerService customerService) : base(customerService)
        {
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [TokenRequestValidation]
        public ActionResult GetAll(string term)
        {
            var filter = new CustomerFilter(term);
            return GetAll(filter);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [TokenRequestValidation]
        public ActionResult Get(Guid id)
        {
            return Find(id);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [TokenRequestValidation]
        public new ActionResult Add([FromBody] CustomerInsertDTO model)
        {
            return base.Add(model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [TokenRequestValidation]
        public new ActionResult Update([FromRoute] Guid id, [FromBody] CustomerUpdateDTO model)
        {
            return base.Update(id, model);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [TokenRequestValidation]
        public new ActionResult Delete(Guid id)
        {
            return base.Delete(id);
        }
    }
}