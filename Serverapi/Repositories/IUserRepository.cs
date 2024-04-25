using Core;

namespace Serverapi.Repositories
{
    public interface IUserRepository
    {
        //Tildeler item en unik id og tilføjer den.
        void AddItem(User item);

        // Fjerner item, hvor item.Id = id. Hvis den ikke
        // findes sker ingenting
        void DeleteById(int id);

        List<User> GetAll();


        // Opdaterer element med Id = item.Id.
        void UpdateItem(User item);
    }
}

