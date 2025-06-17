using MediatR;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.RestarauntSerivices.Queries
{
    public class GetRestarauntByIdQuery : IRequest<RestarauntViewModel>
    {
        public long Id { get; set; }
    }
}
