using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thoth.Business.Abstract;
using Thoth.Business.Concrete.Managers;
using Thoth.Entity.Concrete;

namespace Thoth.Business.ValidationRules
{
    public class List
    {
        IBeaconsService beacons = new BeaconsManager();
        IBuildingClassBeaconsService buildingClassBeacons = new BuildingClassBeaconsManager();
        IUsersService users = new UsersManager();
        IRefCountriesService counts = new RefCountriesManager();
        public List<Beacons> GetBeacons()
        {
            var beacon = beacons.GetAll();
            if (beacon != null)
            {
                foreach (var item in beacon)
                {
                    return beacon;
                }
            }
            else
            {
                return null;
            }
            return beacon;
        }

        public List<BuildingClassBeacons> GetBuildingClassBeacons()
        {
            var buildingClassBeacon = buildingClassBeacons.GetAll();
            if (buildingClassBeacon != null)
            {
                foreach (var item in buildingClassBeacon)
                {
                    return buildingClassBeacon;
                }
            }
            else
            {
                return null;
            }
            return buildingClassBeacon;
        }

        public List<Users> GetUsers()
        {
            var user = users.GetAll();
            if (user != null)
            {
                foreach (var item in user)
                {
                    return user;
                }
            }
            else
            {
                return null;
            }
            return user;
        }

        public List<RefCountries> GetCounts()
        {
            var count = counts.GetAll();
            if (count != null)
            {
                foreach (var item in count)
                {
                    return count;
                }
            }
            else
            {
                return null;
            }
            return count;
        }
    }
}
