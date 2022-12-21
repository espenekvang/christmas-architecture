using Application.Presents.Queries;
using Domain.Presents;

namespace Application.Presents.Handlers
{
    internal class GetPresentHandler : IQueryHandler<GetPresentQuery, Present?>
    {
        private readonly IPresentRepository _presentRepository;

        public GetPresentHandler(IPresentRepository presentRepository)
        {
            _presentRepository = presentRepository;
        }

        public ValueTask<Present?> Handle(GetPresentQuery query, CancellationToken cancellationToken)
        {
            var present = _presentRepository.FindById(query.PresentId);
            
            return ValueTask.FromResult(present);
        }
    }
}
