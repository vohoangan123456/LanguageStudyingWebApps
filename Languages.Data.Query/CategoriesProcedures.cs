using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Languages.Data.Query
{
    public class CategoriesProcedures : ConnectionBase, ILanguagesProcedures
    {
        public CategoriesProcedures(IConnectionFactory factory) : base(factory)
        {
        }

        public int Create(LanguagesDTO request)
        {
            return Execute(
                    connection => connection.Query<int>("[dbo].[CreateLanguage]",
                    new
                    {
                        LanguageName = request.LanguageName
                    },
                    commandType: CommandType.StoredProcedure)
                ).First();
        }

        public bool Update(LanguagesDTO request)
        {
            try
            {
                Execute(connection => connection.Execute("[dbo].[UpdateLanguages]",
                    new
                    {
                        Id = request.Id,
                        LanguageName = request.LanguageName
                    },
                    commandType: CommandType.StoredProcedure));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(IEnumerable<int> ids)
        {
            DataTable idsTable = ids.ConvertToDataTable();
            try
            {
                Execute(connection => connection.Execute("[dbo].[DeleteLanguages]",
                    new
                    {
                        Ids = idsTable
                    },
                    commandType: CommandType.StoredProcedure));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LanguagesDTO GetById(int id)
        {
            return Execute(connection => connection.Query<LanguagesDTO>("[dbo].[GetLanguagesById]",
                new
                {
                    Id = id
                },
                commandType: CommandType.StoredProcedure)).First();
        }

        public IEnumerable<LanguagesDTO> GetActiveLanguages()
        {
            return Execute(connection => connection.Query<LanguagesDTO>("[dbo].[GetActiveLanguages]",
                new { },
                commandType: CommandType.StoredProcedure));
        }
    }
}
