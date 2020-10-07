using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edura.Data;
using Edura.Data.UnitOfWork;
using Edura.Domain.Entity.Common;
using Edura.Repository.Common.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppResourcesController : ControllerBase
    {

        private readonly  IAppResourceRepository appResourceRepository;
      
        private readonly  IUnitOfWork<ApplicationDbContext>  unitOfWork;
        public AppResourcesController(IAppResourceRepository _appResourceRepository, IUnitOfWork<ApplicationDbContext> _unitOfWork)
        {
            appResourceRepository = _appResourceRepository;
            unitOfWork = _unitOfWork;
        }



        // GET: api/AppResources
        [HttpGet]
        public IEnumerable<AppResource> Get()
        {
            return appResourceRepository.Get().ToList();
        }

        // GET: api/AppResources/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AppResources
        [HttpPost]
        public AppResource Post([FromBody] AppResource value)
        {
            var x=  appResourceRepository.Insert(value);
            unitOfWork.Save();
            return x; 


        }

        // PUT: api/AppResources/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
