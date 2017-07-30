using Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.IR
{
    public interface IPictureRepo
    {
        void RemoveRange(List<Picture> pictures);
        void AddPicture(Picture picture);

        void Remove(int pictureId);
        void SetAsDefault(int pictureId, int placeId);
    }
}
