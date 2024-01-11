using DesignPatterns.Models;
using System.Collections;
using System.Collections.Generic;

// Singleton que permite guardar la lista de vehículos sin que se eliminen. Esta instancia podría estar en el servicor. 
// Esta misma instancia podría ser accedida por otros usuarios si la instancia está en el servidor.

namespace DesignPatterns.Infraestructure.Singletons
{
    public class VehicleMemoryCollection
    {
        private static VehicleMemoryCollection _instance;
        public ICollection<Vehicle> Vehicles { get; set; }

        public VehicleMemoryCollection()
        {
            Vehicles = new List<Vehicle>();
        }

        public static VehicleMemoryCollection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VehicleMemoryCollection();
                }

                return _instance;
            }
        }
    }
}
