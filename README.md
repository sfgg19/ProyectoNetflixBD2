# 🎬 ProyectoFinalCINEPOLIS - Clon de Plataforma de Streaming (Netflix)

¡Bienvenidos al repositorio oficial del Proyecto CINEPOLIS! Esta aplicación es una plataforma de streaming bajo demanda, desarrollada como proyecto universitario para la materia de **Bases de Datos II**. 

El objetivo principal de esta entrega es la refactorización y migración de un sistema tradicional relacional (SQL Server) hacia una base de datos NoSQL (**MongoDB**), aplicando patrones de diseño avanzados de estructuración de documentos.

---

## 🚀 Requisitos Previos

Para poder ejecutar este proyecto en tu máquina local, asegúrate de tener instalado:
1. **Visual Studio 2019 o 2022** (con el entorno de desarrollo para escritorio de .NET).
2. **.NET Framework 4.7.2** o superior.
3. **MongoDB Community Server** corriendo en tu máquina (puerto por defecto `27017`).
4. **MongoDB Compass** o `mongosh` (opcional, pero muy recomendado para ejecutar los scripts de inserción).

---

## ⚙️ ¿Cómo ejecutar el proyecto en tu máquina?

Sigue estos pasos cuidadosamente para poner a funcionar la aplicación:

### 1. Clonar el repositorio
Abre tu terminal y clona el proyecto:
```bash
git clone https://github.com/sfgg19/ProyectoNetflixBD2.git
```

### 2. Preparar la Base de Datos (Muy Importante)
A diferencia de SQL Server, **NO se incluye un archivo de base de datos pesado en el repositorio**. En MongoDB, la base de datos se construye dinámicamente. Para tener datos con los cuales probar la aplicación:
1. Abre tu **MongoDB Compass** y conéctate a `mongodb://localhost:27017`.
2. En la raíz de este proyecto encontrarás un archivo llamado `Informe_Consultas_MongoDB.md`.
3. Abre ese archivo, busca la sección **"2. Inserción de Datos Semilla"** y copia los bloques de código JavaScript (`insertMany`).
4. Pega y ejecuta esos códigos en la terminal integrada de Mongo (mongosh) o en el área de scripts de tu Compass. 
> *¡Listo! Con esto tendrás cuentas de usuarios para iniciar sesión y películas en tu catálogo.*

### 3. Compilar y Ejecutar la App
1. Abre el archivo de solución (`.sln`) o el proyecto (`.csproj`) en **Visual Studio**.
2. Al abrirlo, Visual Studio automáticamente descargará (restaurará) la librería `MongoDB.Driver` mediante NuGet.
3. Haz clic en el botón de **"Iniciar" (Start)** o presiona `F5` para compilar y ejecutar el formulario WinForms.
4. Inicia sesión con alguno de los correos que insertaste en el paso de la base de datos (Ej: `juan@gmail.com`).

---

## 🗄️ Estructura y Arquitectura de la Base de Datos (MongoDB)

El esquema original constaba de **16 tablas relacionales** en SQL Server. Hemos rediseñado por completo la arquitectura para transformarla en **solo 4 colecciones ágiles** en MongoDB, justificando académicamente cada decisión de diseño:

### 1. Colección `Cuentas` (Patrón de Documento Embebido)
* **Lo que reemplaza:** Las antiguas tablas `CUENTA`, `PLAN`, `PERFIL` y `PAGO`.
* **Cómo funciona ahora:** En lugar de hacer `JOINs` costosos para armar el perfil del usuario al hacer Login, un solo documento de Cuenta guarda todo lo que le pertenece.
* **Estructura:**
  ```json
  {
    "_id": ObjectId("..."),
    "Email": "juan@gmail.com",
    "FechaRegistro": ISODate("2023-01-01..."),
    "Plan": { "NombrePlan": "Premium", "MaxDispositivos": 4, "Calidad": "4K" },
    "Perfiles": [
      { "NombrePerfil": "Juan", "Edad": 35 },
      { "NombrePerfil": "Kids", "Edad": 10 }
    ],
    "Pagos": [
      { "Monto": 13.99, "FechaPago": "2023-01-15" }
    ]
  }
  ```
* **Justificación académica:** Como una cuenta tiene un límite natural de crecimiento (un máximo estricto de 5 perfiles) y los pagos/planes siempre se consultan junto con la cuenta principal en la vista "Mi Cuenta", incrustarlos (embeberlos) mejora drásticamente la velocidad de lectura (`Read-heavy optimization`).

### 2. Colección `Contenidos` (Patrón Polimórfico y Embebido)
* **Lo que reemplaza:** Las tablas `CONTENIDO`, `SERIE`, `TEMPORADA`, `EPISODIO`, `GENERO`, `CONTENIDO_GENERO` y `CLASIFICACION_EDAD`.
* **Cómo funciona ahora:** Catálogo centralizado y polimórfico. Un documento puede ser una "Película" sencilla o una "Serie" inmensa que contiene internamente sus propias temporadas y episodios.
* **Estructura (Ejemplo de Serie):**
  ```json
  {
    "_id": ObjectId("..."),
    "Titulo": "Breaking Bad",
    "TipoContenido": "Serie",
    "ClasificacionEdad": { "NombreClasificacion": "TV-MA" },
    "Generos": ["Crime", "Drama"],
    "Temporadas": [
      {
        "NumeroTemporada": 1,
        "Episodios": [
          { "NumeroEpisodio": 1, "TituloEpisodio": "Pilot", "Duracion": 58 }
        ]
      }
    ]
  }
  ```
* **Justificación académica:** Cargar la información de una serie entera con todos sus capítulos haciendo una sola consulta a la BD es ideal para plataformas de streaming. Evita el cruce (JOIN) simultáneo de 5 a 6 tablas distintas, acelerando el despliegue del catálogo al usuario.

### 3. Colecciones `Interacciones_Historial` e `Interacciones_Calificaciones` (Patrón de Referencia / Outlier)
* **Lo que reemplaza:** Las tablas `HISTORIAL_VISUALIZACION` y `CALIFICACION`.
* **Cómo funciona ahora:** Son colecciones separadas de forma lógica que simplemente referencian (guardan el ID de tipo String/ObjectId) al `IDPerfil` y al `IDContenido`.
* **Estructura:**
  ```json
  {
    "_id": ObjectId("..."),
    "IDPerfil": "Juan_ID_String",
    "IDContenido": ObjectId("ID_De_La_Pelicula"),
    "FechaVisualizacion": ISODate("..."),
    "Progreso": 80 
  }
  ```
* **Justificación académica:** A diferencia de los perfiles que tienen un tope (5), un usuario activo puede ver decenas de miles de películas o capítulos a lo largo de los años. Si incrustáramos este "Historial" dentro de su documento `Cuenta`, sufriríamos el problema de **Unbounded Growth** (Crecimiento descontrolado) y superaríamos el límite estricto de **16MB** de tamaño máximo por documento que impone el motor de MongoDB. Por eso, estas interacciones siempre se referencian en colecciones por separado.

---

## 📝 Documentación para el Informe Universitario

Si necesitas presentar un informe escrito a la universidad sobre esta refactorización, puedes extraer todo el código necesario del archivo `Informe_Consultas_MongoDB.md` incluido en este repositorio. 

Dicho archivo contiene la sintaxis pura de JavaScript para:
- Crear las colecciones.
- Insertar la "data semilla" completa.
- Ejecutar consultas **CRUD**.
- Operaciones analíticas avanzadas utilizando el framework de **Aggregation Pipeline** (`$group`, `$lookup`, `$unwind`, `$project`).

---
*Desarrollado para la materia de Bases de Datos II - UCB*
