namespace Domain.Presents
{
    public record Present(string To, string From)
    {
        public long Id { get; init; }
    }
}
