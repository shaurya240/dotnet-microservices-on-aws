using Model;

namespace Domain.Healthstatus
{
    public interface IHealthstatusService
    {
        Response<Model.Healthstatus> FullCheck();
    }
}
