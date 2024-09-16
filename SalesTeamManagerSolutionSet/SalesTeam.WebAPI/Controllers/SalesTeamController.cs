using GraphQL.AspNet.Controllers;
using Microsoft.AspNetCore.Mvc;

using SalesTeam.Common;
using SalesTeam.DataAccess;

namespace SalesTeam.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesTeamController : GraphController {
        private readonly ILogger<SalesTeamController> _logger;
        private readonly IDataAccessService _dataAccessService;

        public SalesTeamController(ILogger<SalesTeamController> logger, IDataAccessService dataAccessService)
        {
            _logger = logger;
            _dataAccessService = dataAccessService;
        }

        [HttpGet(Name = "GetSalesRecords")]
        public IEnumerable<SalesRecord> Get()
        {
            return new List<SalesRecord>();   
        }
    }
}
