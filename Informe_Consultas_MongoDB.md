# Informe de Consultas MongoDB - Proyecto CINEPOLIS

## 1. Creación de Colecciones
En MongoDB no es estrictamente necesario crear las colecciones explícitamente ya que se crean al insertar el primer documento, sin embargo, podemos crearlas de la siguiente manera para estructurar el diseño:

```javascript
use CinepolisDB;

db.createCollection("Cuentas");
db.createCollection("Contenidos");
db.createCollection("Interacciones_Historial");
db.createCollection("Interacciones_Calificaciones");
```

## 2. Inserción de Datos Semilla (InsertMany complejos)

### Inserción de Cuentas (con Perfiles y Pagos embebidos)
```javascript
db.Cuentas.insertMany([
  {
    Email: "juan@gmail.com",
    FechaRegistro: new Date(),
    TarjetaEnmascarada: "****-****-****-1234",
    Plan: {
      NombrePlan: "Premium (4 Pantallas + 4K)",
      MaxDispositivos: 4,
      Calidad: "4K",
      DescargasPermitidas: 10
    },
    Perfiles: [
      { NombrePerfil: "Juan", Edad: 35 },
      { NombrePerfil: "Kids", Edad: 10 }
    ],
    Pagos: [
      { FechaPago: new Date("2023-01-15"), Monto: 13.99, MetodoPago: "Tarjeta" },
      { FechaPago: new Date("2023-02-15"), Monto: 13.99, MetodoPago: "Tarjeta" }
    ]
  },
  {
    Email: "maria@yahoo.com",
    FechaRegistro: new Date(),
    TarjetaEnmascarada: "****-****-****-5678",
    Plan: {
      NombrePlan: "Básico (1 Pantalla)",
      MaxDispositivos: 1,
      Calidad: "HD",
      DescargasPermitidas: 1
    },
    Perfiles: [
      { NombrePerfil: "Maria", Edad: 28 }
    ],
    Pagos: []
  }
]);
```

### Inserción de Contenidos (Películas y Series con episodios embebidos)
```javascript
db.Contenidos.insertMany([
  {
    Titulo: "Inception",
    Resumen: "Un ladrón que roba secretos corporativos a través del uso de la tecnología de compartir sueños.",
    TipoContenido: "Pelicula",
    Director: "Christopher Nolan",
    Anio: 2010,
    Duracion: 148,
    ClasificacionEdad: { NombreClasificacion: "PG-13" },
    Generos: ["Sci-Fi", "Action"],
    Vigencias: [
      { FechaInicio: new Date("2020-01-01"), FechaFin: new Date("2025-01-01"), Proveedor: "Warner Bros" }
    ],
    Temporadas: []
  },
  {
    Titulo: "Breaking Bad",
    Resumen: "Un profesor de química diagnosticado con cáncer inoperable se convierte en productor de metanfetamina.",
    TipoContenido: "Serie",
    Director: "Vince Gilligan",
    Anio: 2008,
    Duracion: 0,
    ClasificacionEdad: { NombreClasificacion: "TV-MA" },
    Generos: ["Crime", "Drama"],
    Vigencias: [
      { FechaInicio: new Date("2015-01-01"), FechaFin: new Date("2030-01-01"), Proveedor: "Sony Pictures" }
    ],
    Temporadas: [
      {
        NumeroTemporada: 1,
        ResumenTemporada: "Temporada 1 de Breaking Bad",
        Episodios: [
          { NumeroEpisodio: 1, TituloEpisodio: "Pilot", Resumen: "Walter White descubre su cáncer.", Duracion: 58 },
          { NumeroEpisodio: 2, TituloEpisodio: "Cat's in the Bag...", Resumen: "Walt y Jesse intentan deshacerse de los cuerpos.", Duracion: 48 }
        ]
      }
    ]
  }
]);
```

## 3. Consultas CRUD completas para operaciones de la app

**1. Buscar cuenta por Email (Login)**
```javascript
db.Cuentas.findOne({ Email: "juan@gmail.com" });
```

**2. Actualizar el plan de una cuenta**
```javascript
db.Cuentas.updateOne(
  { Email: "maria@yahoo.com" },
  { $set: { "Plan.NombrePlan": "Estándar (2 Pantallas)", "Plan.MaxDispositivos": 2 } }
);
```

**3. Buscar contenido por categoría/género (Buscador)**
```javascript
db.Contenidos.find({ Generos: "Sci-Fi" });
```

**4. Obtener los 10 últimos estrenos**
```javascript
db.Contenidos.find().sort({ Anio: -1 }).limit(10);
```

**5. Registrar un historial de visualización**
```javascript
// Sustituir con ObjectIds reales según corresponda
db.Interacciones_Historial.insertOne({
  IDPerfil: "Juan_ID",
  IDContenido: ObjectId("..."),
  FechaVisualizacion: new Date(),
  Progreso: 80
});
```

## 4. Consultas Analíticas (Aggregate)

**1. Obtener la calificación promedio de una película (Mejor Calificada)**
```javascript
db.Interacciones_Calificaciones.aggregate([
  {
    $group: {
      _id: "$IDContenido",
      PromedioEstrellas: { $avg: "$Estrellas" },
      TotalVotos: { $sum: 1 }
    }
  },
  {
    $lookup: {
      from: "Contenidos",
      localField: "_id",
      foreignField: "_id",
      as: "DetallePelicula"
    }
  },
  {
    $unwind: "$DetallePelicula"
  },
  {
    $project: {
      Titulo: "$DetallePelicula.Titulo",
      PromedioEstrellas: 1,
      TotalVotos: 1
    }
  },
  { $sort: { PromedioEstrellas: -1 } }
]);
```

**2. Mostrar la lista de perfiles y cuántas visualizaciones tienen en su historial**
```javascript
db.Interacciones_Historial.aggregate([
  {
    $group: {
      _id: "$IDPerfil",
      TotalVisualizaciones: { $sum: 1 }
    }
  },
  { $sort: { TotalVisualizaciones: -1 } }
]);
```

**3. Obtener el número de películas por cada género (Cantidad por Género)**
```javascript
db.Contenidos.aggregate([
  { $match: { TipoContenido: "Pelicula" } },
  { $unwind: "$Generos" },
  {
    $group: {
      _id: "$Generos",
      CantidadPeliculas: { $sum: 1 }
    }
  },
  { $sort: { CantidadPeliculas: -1 } }
]);
```
