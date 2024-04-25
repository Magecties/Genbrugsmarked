using Core;
using Serverapi.repositories;

namespace Serverapi.Repositories
{
    public interface IpostRepository
    {

        //Tildeler item en unik id og tilføjer den.
        void AddItem(Post item);

        // Fjerner item, hvor item.Id = id. Hvis den ikke
        // findes sker ingenting
        void DeleteById(int id);

        List<Post> GetAll();


        // Opdaterer element med Id = item.Id.
        void UpdateItem(Post item);
    }
}

