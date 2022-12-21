using Application.Presents.Queries;
using Domain.Presents;

namespace Application.Presents.Handlers
{
    internal class GetPresentsHandler : IQueryHandler<GetPresentsQuery, List<Present>>
    {
        private readonly IPresentRepository _presentRepository;

        public GetPresentsHandler(IPresentRepository presentRepository)
        {
            _presentRepository = presentRepository;
        }

        public ValueTask<Present?> Handle(GetPresentQuery query, CancellationToken cancellationToken)
        {
            var present = _presentRepository.FindById(query.PresentId);
            
            return ValueTask.FromResult(present);
        }

        public ValueTask<List<Present>> Handle(GetPresentsQuery query, CancellationToken cancellationToken)
        {
            var allPresents = _presentRepository.GetAll();

            return ValueTask.FromResult(allPresents);
        }
    }
}
