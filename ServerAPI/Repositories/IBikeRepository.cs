using System;
using Shared;
namespace ServerAPI.Repositories
{
    public interface IBikeRepository
    {
        BEBike[] GetAll();
        void Add(BEBike bike);
        void DeleteById(int id);
    }
}