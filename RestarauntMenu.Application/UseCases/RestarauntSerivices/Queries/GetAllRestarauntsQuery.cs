using MediatR;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.RestarauntSerivices.Queries
{
    public class GetAllRestarauntsQuery : IRequest<IEnumerable<RestarauntViewModel>>
    {
    }
}
