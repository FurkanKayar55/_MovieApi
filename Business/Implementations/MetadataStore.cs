using CsvHelper;
using Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Business.Implementations
{
    public class MetadataStore : IMetadata
    {
        public void SaveMetadata(Metadata metada)
        {
            List<Metadata> database = new List<Metadata>();
            database.Add(metada);
        }

        public IEnumerable<Metadata> GetMetada(int movieId, string path)
        {
            try
            {
                List<Metadata> metadata = new List<Metadata>();
                using (TextReader reader = File.OpenText(path))
                {
                    CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                    while (csv.Read())
                    {
                        Metadata Record = csv.GetRecord<Metadata>();
                        metadata.Add(Record);
                    }
                    return metadata.Where(x => x.MovieId == movieId).OrderByDescending(s => s.Language);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
