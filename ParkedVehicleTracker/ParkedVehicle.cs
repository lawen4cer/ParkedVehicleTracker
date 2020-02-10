using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkedVehicleTracker
{
    class ParkedVehicle
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }
        
        public Vector3 VehicleCoords { get; set; }

        public float Heading { get; set; }
        public int VehicleHash { get; set; }



        public ParkedVehicle(string displayName, Vector3 coords, float heading, int vehicleHash)
        {
            DisplayName = displayName;
            VehicleCoords = coords;
            Heading = heading;
            VehicleHash = vehicleHash;
        }

        public ParkedVehicle()
        {

        }

    }
}
