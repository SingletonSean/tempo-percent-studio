using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempoPercentStudio.MAUI.Shared.Database;

namespace TempoPercentStudio.MAUI.Entities.PersonalBests
{
    public class PersonalBestRepository
    {
        private readonly SqliteConnectionFactory _sqliteConnectionFactory;

        public PersonalBestRepository(SqliteConnectionFactory sqliteConnectionFactory)
        {
            _sqliteConnectionFactory = sqliteConnectionFactory;
        }

        public async Task<IEnumerable<PersonalBest>> GetAll()
        {
            return null;
        }

        public async Task<PersonalBest> Create(NewPersonalBest newPersonalBest)
        {
            ISQLiteAsyncConnection database = _sqliteConnectionFactory.Connect();

            PersonalBestDto personalBestDto = new PersonalBestDto()
            {
                Distance = newPersonalBest.Distance,
                TimeMilliseconds = newPersonalBest.Time.TotalMilliseconds,
            };

            await database.InsertAsync(personalBestDto);

            return new PersonalBest(
                personalBestDto.Id,
                personalBestDto.Distance,
                TimeSpan.FromMilliseconds(personalBestDto.TimeMilliseconds));
        }

        public async Task Delete(int id)
        {

        }
    }
}
