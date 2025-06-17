using MediatR;
using RestarauntMenu.Application.ViewModels;

namespace RestarauntMenu.Application.UseCases.RestarauntSerivices.Commands
{
    public class DeleteRestarauntCommand : IRequest<ResponseModel>
    {
        public long Id { get; set; }
    }
}
