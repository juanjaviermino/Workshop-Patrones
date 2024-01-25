using DesignPatterns.Infraestructure.Singletons;
using DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Espacio de nombres que contiene las clases relacionadas con los repositorios.
namespace DesignPatterns.Repositories
{
    // Clase MyVehiclesRepository que implementa la interfaz IVehicleRepository.
    public class MyVehiclesRepository : IVehicleRepository
    {
        // Variable privada que hace referencia a la única instancia de VehicleMemoryCollection.
        private readonly VehicleMemoryCollection _memoryCollection = VehicleMemoryCollection.Instance;

        // Constructor vacío de la clase MyVehiclesRepository.
        public MyVehiclesRepository()
        {

        }

        // Método para agregar un nuevo vehículo al repositorio.
        public void AddVehicle(Vehicle vehicle)
        {
            // Añade el vehículo a la colección de vehículos en el Singleton VehicleMemoryCollection.
            _memoryCollection.Vehicles.Add(vehicle);
        }

        // Método para buscar un vehículo por su ID.
        public Vehicle Find(string id)
        {
            // Retorna el primer vehículo que coincida con el ID proporcionado o null si no se encuentra.
            return _memoryCollection.Vehicles.FirstOrDefault(v => v.ID.Equals(new Guid(id)));
        }

        // Método para obtener todos los vehículos almacenados en el repositorio.
        public ICollection<Vehicle> GetVehicles()
        {
            // Retorna la colección de vehículos del Singleton VehicleMemoryCollection.
            return _memoryCollection.Vehicles;
        }
    }
}
