using System.Linq;

namespace BrauerNetApp.Models
{
    public interface IResponseRepository
    {
        IQueryable<Response> Responses { get; }
        IQueryable<Project> Projects { get; }
        Response Save(Response response);
        Response Edit(Response response);
        void Remove(Response response);
    }
}
