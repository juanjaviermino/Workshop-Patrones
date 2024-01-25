using DesignPatterns.Models;
using System;

// Espacio de nombres para los constructores de modelos.
namespace DesignPatterns.ModelBuilders
{
    // Clase CarBuilder que implementa el patrón de diseño Builder.
    public class CarBuilder
    {
        // Campos predeterminados para un coche.
        public string Brand = "Ford";
        public string Model = "Mustang";
        public string Color = "Red";
        public int Year = DateTime.Now.Year;

        // Método para establecer la marca del coche. Retorna la instancia actual para permitir encadenamiento.
        public CarBuilder SetBrand(string brand)
        {
            Brand = brand;
            return this;
        }

        // Método para establecer el modelo del coche. Retorna la instancia actual para permitir encadenamiento.
        public CarBuilder SetModel(string model)
        {
            Model = model;
            return this;
        }

        // Método para establecer el color del coche. Retorna la instancia actual para permitir encadenamiento.
        public CarBuilder SetColor(string color)
        {
            Color = color;
            return this;
        }

        // Método para establecer el año del coche. Retorna la instancia actual para permitir encadenamiento.
        public CarBuilder SetYear(int year)
        {
            Year = year;
            return this;
        }

        // Método para construir y retornar un objeto Car con los valores especificados.
        public Car Build()
        {
            // Crea un nuevo objeto Car usando los valores de los campos de la instancia.
            return new Car(Color, Brand, Model, Year);
        }
    }
}
