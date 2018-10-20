using Languages.Data.Entity;
using System.Collections.Generic;

namespace Languages.Data.Query.Interfaces
{
    public interface ICategoriesProcedures
    {
        int Create(CategoriesDTO request);
        bool Update(CategoriesDTO request);
        bool Delete(IEnumerable<int> ids);
        CategoriesDTO GetById(int id);
        IEnumerable<CategoriesDTO> GetActiveCategories();
    }
}
