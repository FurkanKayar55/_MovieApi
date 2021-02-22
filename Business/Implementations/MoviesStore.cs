using CsvHelper;
using Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Implementations
{
    public class MoviesStore : IMovies
    {
        public IEnumerable<Stats> GetStats(string path)
        {
            try
            {
                List<Stats> metadata = new List<Stats>();
                using (TextReader reader = File.OpenText(path))
                {
                    CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                    while (csv.Read())
                    {
                        Stats Record = csv.GetRecord<Stats>();
                        metadata.Add(Record);
                    }
                    return metadata.OrderByDescending(s => s.watchDurationMs);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
