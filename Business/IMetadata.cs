using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IMetadata
    {
        void SaveMetadata(Metadata metada);
        IEnumerable<Metadata> GetMetada(int movieId, string path);
    }
}
