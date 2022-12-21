using Domain.Presents;

namespace Application.Presents
{
    public interface IPresentRepository
    {
        public List<Present> GetAll();
        public Present? FindById(int presentId);
        public void Save(Present present);
    }
}
