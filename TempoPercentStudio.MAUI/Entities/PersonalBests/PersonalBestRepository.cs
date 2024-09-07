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
            ISQLiteAsyncConnection database = _sqliteConnectionFactory.Connect();

            List<PersonalBestDto> personalBestDtos = await database.Table<PersonalBestDto>().ToListAsync();

            return personalBestDtos.Select(dto => new PersonalBest(
                dto.Id, 
                dto.Distance, 
                TimeSpan.FromMilliseconds(dto.TimeMilliseconds)));
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
            ISQLiteAsyncConnection database = _sqliteConnectionFactory.Connect();

            await database.Table<PersonalBestDto>().DeleteAsync(dto => dto.Id == id);
        }
    }
}
