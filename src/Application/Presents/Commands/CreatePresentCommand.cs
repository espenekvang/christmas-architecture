namespace Application.Presents.Commands
{
    public record CreatePresentCommand(string To, string From)
    {
        public static CreatePresentCommand With(string to, string from)
        {
            return new CreatePresentCommand(to, from);
        }
    }
}