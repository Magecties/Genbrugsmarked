using Core;

namespace Serverapi.Repositories
{
    public interface IRoomRepository
    {
        //Tildeler item en unik id og tilføjer den.
        void AddItem(Room item);

        // Fjerner item, hvor item.Id = id. Hvis den ikke
        // findes sker ingenting
        void DeleteById(int id);

        List<Room> GetAll();


        // Opdaterer element med Id = item.Id.
        void UpdateItem(Room item);
    }
}

