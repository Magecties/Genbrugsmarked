using Core;

namespace Serverapi.Repositories
{
    public interface IOrderRepository
    {
        //Tildeler item en unik id og tilføjer den.
        void AddItem(Order item);

        // Fjerner item, hvor item.Id = id. Hvis den ikke
        // findes sker ingenting
        void DeleteById(int id);

        List<Order> GetAll();


        // Opdaterer element med Id = item.Id.
        void UpdateItem(Order item);
    }
}
