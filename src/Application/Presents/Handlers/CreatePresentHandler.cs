using Application.Presents.Commands;
using Domain.Presents;

namespace Application.Presents.Handlers
{
    internal class CreatePresentHandler : ICommandHandler<CreatePresentCommand>
    {
        private readonly IPresentRepository _presentRepository;

        public CreatePresentHandler(IPresentRepository presentRepository)
        {
            _presentRepository = presentRepository;
        }

        public ValueTask Handle(CreatePresentCommand command, CancellationToken cancellationToken)
        {
            _presentRepository.Save(new Present(command.To, command.From));
            return ValueTask.CompletedTask;
        }
    }
}
