using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TheCodeCamp.Data;
using TheCodeCamp.Models;

namespace TheCodeCamp.Controllers
{
    public class CampsController  : ApiController
    {
        private readonly ICampRepository _repository;
        private readonly IMapper _mapper;

        public CampsController(ICampRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllCampsAsync();
                var mappedResult = _mapper.Map<IEnumerable<CampModel>>(result);

                //return BadRequest("just learning..");



                return Ok(mappedResult);
            }
            catch (Exception ex)
            {
                // DO LOG EXCEPTION
                return InternalServerError(ex);
            }
        }
    }
}