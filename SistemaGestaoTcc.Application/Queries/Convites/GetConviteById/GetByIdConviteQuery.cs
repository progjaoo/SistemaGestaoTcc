using MediatR;
using SistemaGestaoTcc.Application.ViewModels;

namespace SistemaGestaoTcc.Application.Queries.Convites
{
    public class GetByIdConviteQuery : IRequest<ConviteViewModel>
    {
        public GetByIdConviteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}