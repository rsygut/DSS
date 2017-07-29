using Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.IR
{
    public interface IPlaceRepo
    {
        IQueryable<Place> DownloadPlace();
        Place GetPlaceById(int id);
        bool DeletePlace(int id);
        void SaveChanges();
        void AddPlace(Place place);
        void UpdatePlace(Place place);

    }
}
