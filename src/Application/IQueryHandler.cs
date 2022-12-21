namespace Application
{
    public interface IQueryHandler<in T, TResult>
    {
        ValueTask<TResult> Handle(T query, CancellationToken cancellationToken);
    }
}
