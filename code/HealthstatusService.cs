using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Domain.Healthstatus
{
    public class HealthstatusService : IHealthstatusService
    {
        private readonly DataContext _context;
        private readonly ILogger<HealthstatusService> _log;

        public HealthstatusService(DataContext context, ILogger<HealthstatusService> log)
        {
            _context = context;
            _log = log;
        }

        public Response<Model.Healthstatus> FullCheck()
        {
            try
            {
                _log.LogInformation("Healthstatus FullCheck v1");

                if (!_context.Database.IsNpgsql())
                {
                    throw new Exception("Configured database is not postgres");
                }

                var result = _context.HealthStatuses
                    .FromSqlRaw("select 1 as id, now() as timestamp")
                    .ToList()
                    .Select(r => new Model.Healthstatus
                    {
                        Status = "Health status FullCheck v2",
                        DbSystemDate = r.Timestamp,
                    }).First();

                return Response<Model.Healthstatus>.Ok(result);
            }
            catch (Exception e)
            {
                // log it
                Log.Logger.Error(e, "Error Health status FullCheck");

                // return it
                return new Response<Model.Healthstatus>
                {
                    Status = ResponseStatus.ERROR,
                    Error = new ResponseError
                    {
                        ErrorMessage = "Something bad happened"
                    }
                };
            }
        }
    }
}