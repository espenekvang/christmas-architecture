using Application.Presents;
using Domain.Presents;

namespace Infrastructure.Presents
{
    internal class PresentRepository : IPresentRepository
    {
        private readonly IDictionary<int, Present> _presents;

        public PresentRepository()
        {
            _presents = new Dictionary<int, Present>();
        }

        public List<Present> GetAll()
        {
            return _presents.Values.ToList();
        }

        public Present? FindById(int presentId)
        {
            _presents.TryGetValue(presentId, out var present);
            return present;
        }

        public void Save(Present present)
        {
            var presentId = new Random().Next();
            present = present with { Id = presentId };

            _presents.Add(presentId, present);
        }
    }
}
