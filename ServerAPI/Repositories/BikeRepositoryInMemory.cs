using System;
using Shared;

namespace ServerAPI.Repositories
{
    public class BikeRepositoryInMemory : IBikeRepository
    {


        private List<BEBike> mBikes = new()
        {
            new BEBike
            {
                Id = 2, Brand = "Cannondale", Model = "Super Six", Description = "", Price = 32000,
                ImageUrl =
                    "https://cykelexperten.dk/media/b2/91/0c/1621238790/es.salsify.com_image_upload_s--ig-E1STy--_gkrk5jfl6olvdl9v8sxb.jpg"
            }
        };
        
        public void Add(BEBike bike)
        {
            bike.Id = mBikes.Count + 1;
            mBikes.Add(bike);  
        }

        public void DeleteById(int id)
        {
            mBikes.RemoveAll((b) => b.Id == id);
        }

        public BEBike[] GetAll()
        {
            return mBikes.ToArray();
        }
    }
}