namespace Application
{
    public interface ICommandHandler<in T>
    {
        ValueTask Handle(T command, CancellationToken cancellationToken);
    }
}
