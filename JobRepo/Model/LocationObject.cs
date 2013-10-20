using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.ComponentModel.DataAnnotations;

namespace JobRepo.Model
{
        public class LocationDto 
        {

           public string Description {get; set; } 

           [Key]
           public int LocationID {get; set; } 
        }



    [DataObject()]
    public class LocationObject : IDisposable 
    {

        JobRepoDataContext context = new JobRepoDataContext();
        public LocationObject()
        {   
            
        }


        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<LocationDto> GetLocations()
        {

            var query = from loc in context.Locations
                        join con in context.Countries on loc.CountryID equals con.CountryID
                        join cit in context.Cities on loc.CityID equals cit.CityID
                        join pro in context.Provinces on loc.ProvinceID equals pro.ProvinceID
                        select new LocationDto()
                        {
                            LocationID = loc.LocationID,
                            Description = loc.PostCode + " " + cit.CityName + " " + pro.ProvinceName + " " + con.CountryName
                        };

            return query.ToList();

        }


    }
}