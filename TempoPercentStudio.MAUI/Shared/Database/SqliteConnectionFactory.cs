using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempoPercentStudio.MAUI.Shared.Database
{
    public class SqliteConnectionFactory
    {
        public ISQLiteAsyncConnection Connect()
        {
            return new SQLiteAsyncConnection(
                Path.Combine(FileSystem.Current.AppDataDirectory, "TempoPercentStudio.db3"),
                SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
        }
    }
}
