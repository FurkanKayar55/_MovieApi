using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IMovies
    {
        IEnumerable<Stats> GetStats(string path);
    }
}
