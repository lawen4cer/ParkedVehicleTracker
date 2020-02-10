using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CitizenFX.Core.Native.API;
using CitizenFX.Core;

namespace ParkedVehicleTracker
{
    public class VehicleTracker : BaseScript
    {
        ParkedVehicle vehicleModel;
        List<ParkedVehicle> parkedVehicles;
        public VehicleTracker()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
            parkedVehicles = new List<ParkedVehicle>();
        }

        private void OnClientResourceStart(string resource)
        {
            if (GetCurrentResourceName() != resource) return;

            RegisterCommand("park", new Action<int, List<object>, string>((source, args, raw) =>
            {
                Util.SendMessage("[Debug]", "Park Command is registered", 255, 0, 0);
           
                var vehicleModel = Game.Player.LastVehicle;
                var vehiclePosition = new ParkedVehicle(vehicleModel.DisplayName, vehicleModel.Position, vehicleModel.Heading, vehicleModel.Handle);
                parkedVehicles.Add(vehiclePosition);

                
                Util.SendMessage("Vehicle X", vehiclePosition.VehicleCoords.X.ToString(), 255,0,0);
                Util.SendMessage("Vehicle Y", vehiclePosition.VehicleCoords.Y.ToString(), 255, 0, 0);
                Util.SendMessage("Vehicle Z", vehiclePosition.VehicleCoords.Z.ToString(), 255, 0, 0);
                Util.SendMessage("Vehicle Heading", vehiclePosition.Heading.ToString(), 255, 0, 0);
                Util.SendMessage("Vehicle Model", vehiclePosition.DisplayName, 255, 0, 0);
            }), false);

            RegisterCommand("spawn", new Action<int, List<object>, string>((source, args, raw) =>
            {
                foreach (var vehModel in parkedVehicles)
                {
                    World.CreateVehicle(vehModel.DisplayName, vehModel.VehicleCoords, vehModel.Heading);
                }
            }), false);
        }

        
    }

}
