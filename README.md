# Solución del Taller Formativo Mejores Prácticas MVC

## Descripción del Problema

En Codificando Con Patrones Cía. Ltda., nos enfrentamos al desafío de desarrollar una aplicación de gestión de automóviles que permite a los usuarios agregar y gestionar diferentes tipos de vehículos. Los problemas principales incluyen:

1. La funcionalidad incompleta para agregar vehículos.
2. La falta de un esquema de base de datos para la persistencia de datos.
3. La necesidad de expandir las propiedades de los vehículos en el futuro.
4. La anticipación de la incorporación de nuevos modelos de vehículos.

## Solución Implementada

Para abordar estos desafíos, he implementado varias soluciones utilizando patrones de diseño:

### Patrones de Diseño Utilizados

1. **Factory Method**: Para la creación flexible de diferentes tipos de vehículos (Mustang, Explorer, Escape).
2. **Singleton**: En `VehicleMemoryCollection` para simular el almacenamiento de vehículos en memoria.
3. **Builder**: En `CarBuilder` para facilitar la expansión de propiedades de vehículos.

## Patrones de Diseño Implementados

En este proyecto, se han implementado varios patrones de diseño clave para abordar los desafíos específicos del desarrollo de la aplicación de gestión de automóviles. Cada patrón ha sido seleccionado por su capacidad para proporcionar soluciones efectivas y escalables a los problemas identificados.

### 1. Factory Method

- **Descripción**: Este patrón permite crear objetos sin especificar la clase exacta del objeto que será creado.
- **Implementación**: Utilizado en la creación de diferentes tipos de vehículos (como Mustang, Explorer y Escape).
- **Razón de Uso**: Proporciona flexibilidad en la creación de objetos y facilita la adición de nuevos tipos de vehículos en el futuro sin modificar el código existente.

### 2. Singleton

- **Descripción**: Asegura que una clase tiene solo una instancia y proporciona un punto de acceso global a ella.
- **Implementación**: Usado en `VehicleMemoryCollection` para mantener una lista única y global de vehículos.
- **Razón de Uso**: Ideal para manejar una colección centralizada de vehículos en ausencia de una base de datos real, permitiendo un fácil acceso y manipulación de los vehículos en toda la aplicación.

### 3. Builder

- **Descripción**: Permite la construcción de un objeto complejo paso a paso.
- **Implementación**: Implementado en `CarBuilder` para la construcción detallada de objetos `Car`.
- **Razón de Uso**: Facilita la expansión de las propiedades de los vehículos y minimiza los cambios necesarios para agregar nuevas propiedades en el futuro.


## Estructura del Proyecto

- **Controllers**: Contiene `HomeController` para gestionar las acciones del usuario.
- **Factories**: Implementa el Factory Method para la creación de vehículos.
- **Infraestructure**: Incluye Singletons y Dependency Injection.
- **ModelBuilders**: Contiene `CarBuilder` para la construcción de vehículos.
- **Models**: Define las entidades como `Vehicle`, `Car`, etc.
- **Repositories**: Implementa el patrón Repositorio con `MyVehiclesRepository`.
- **Views**: Vistas de la aplicación.

## Cómo Utilizar

Para ejecutar la aplicación:
1. Clone el repositorio.
2. Abra la solución en un entorno de desarrollo compatible con ASP.NET.
3. Ejecute la aplicación desde el entorno de desarrollo.


