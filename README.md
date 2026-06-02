# 🎬 ProyectoFinalCINEPOLIS - Clon de Plataforma de Streaming (Netflix)

¡Bienvenidos al repositorio oficial del Proyecto CINEPOLIS! Esta aplicación es una plataforma de streaming bajo demanda, desarrollada como proyecto universitario para la materia de **Bases de Datos II** en la UCB.

El objetivo principal de esta entrega final fue la **refactorización y migración** de un sistema tradicional relacional (SQL Server) hacia una base de datos NoSQL (**MongoDB**), aplicando patrones de diseño avanzados de estructuración de documentos, agregaciones analíticas complejas y mejoras sustanciales en la interfaz de usuario (UI/UX).

---

## 🚀 Requisitos Previos

Para poder ejecutar este proyecto en tu máquina local, asegúrate de tener instalado:
1. **Visual Studio 2019 o 2022** (con el entorno de desarrollo para escritorio de .NET / WinForms).
2. **.NET Framework 4.7.2** o superior.
3. **MongoDB Community Server** corriendo en tu máquina local (puerto por defecto `27017`).
4. **MongoDB Compass** o `mongosh` (estrictamente necesario para ejecutar los scripts de inserción masiva).

---

## ⚙️ ¿Cómo ejecutar el proyecto en tu máquina?

Sigue estos pasos cuidadosamente para poner a funcionar la aplicación con todos los datos de prueba:

### 1. Preparar la Base de Datos con Datos de Prueba (Semilla)
A diferencia de SQL Server, **NO se incluye un archivo `.bak` ni `.mdf` pesado en el repositorio**. En MongoDB, la base de datos se construye dinámicamente y hemos preparado un script robusto para llenarla:
1. Abre tu **MongoDB Compass** o la consola **mongosh**.
2. Conéctate a tu servidor local: `mongodb://localhost:27017`.
3. Abre el archivo `script_mongosh.md` que se encuentra en la documentación o los anexos del proyecto.
4. **Copia todo el bloque de código Javascript** que se encuentra dentro de ese archivo.
5. Pégalo en tu terminal `mongosh` y presiona Enter.
> *¡Listo! Este script creará automáticamente las cuentas (con contraseñas, perfiles y pagos), el catálogo completo (series con temporadas/episodios y películas), historiales y calificaciones.*

### 2. Compilar y Ejecutar la App
1. Abre el archivo de solución (`.sln`) o el proyecto (`.csproj`) en **Visual Studio**.
2. Al abrirlo, Visual Studio automáticamente restaurará los paquetes NuGet, incluyendo el fundamental `MongoDB.Driver`.
3. Presiona **`F5`** o haz clic en el botón de **"Iniciar" (Start)**.
4. En la pantalla de Login, puedes usar la cuenta generada por defecto en el script:
   - **Correo:** `admin@cinepolis.com`
   - **Contraseña:** `admin`

---

## 🌟 ¿Qué se cambió y agregó en esta versión final?

Hemos transformado un MVP básico en una aplicación de gestión completa y funcional:

### 1. Sistema de Seguridad y Registro Profesional
- **Contraseñas implementadas:** Las cuentas ahora exigen y validan contraseñas seguras, dejando de lado el antiguo login que solo pedía el email.
- **Formulario de Registro Renovado:** Se construyó una interfaz de registro moderna donde se captura toda la información vital del usuario desde el primer momento (Email, Contraseña, Edad del perfil inicial, Plan seleccionado).
- **Control de Excepciones:** La aplicación ahora es tolerante a campos extras (`[BsonIgnoreExtraElements]`), evitando crasheos si la base de datos MongoDB evoluciona y recibe datos inesperados.

### 2. Panel de Administración y Reportes (Agregaciones MongoDB)
- **Botón de Admin:** Un nuevo portal protegido para los administradores que permite acceder a las métricas del negocio.
- **Poderosos Reportes NoSQL:** Se reemplazaron todas las vistas SQL antiguas por potentes _Aggregation Pipelines_ ejecutados directamente desde C#.
  - **Películas más vistas:** Uso de `$group` y `$lookup` para cruzar la colección de Historial con Contenidos y ordenar de mayor a menor.
  - **Ingresos Totales por Mes:** Extracción del mes con `$month` en los pagos embebidos utilizando `$unwind`.
  - **Calificación Promedio:** Cálculo de `$avg` de las estrellas dadas a las películas.

### 3. Gestión Integral de "Mi Cuenta"
- **Edición Completa:** Ahora un usuario logueado puede hacer clic en "Mi Cuenta" para ver su información enmascarada (Contraseña `********`, Tarjeta `****-1234`). Se habilitó un panel modal dinámico para editar su email, tarjeta o contraseña y actualizarlo inmediatamente en MongoDB.
- **Historial de Facturación:** El sistema extrae correctamente el sub-documento de `Pagos` y lo mapea automáticamente en un `DataGridView`.
- **Eliminar Cuenta:** Cumpliendo con estándares de privacidad, el usuario ahora puede dar de baja permanentemente su cuenta, eliminando el documento raíz de la base de datos de forma limpia.

### 4. Mejoras de Interfaz de Usuario (UI)
- **Rediseño del Inicio de Sesión:** Alineación elegante y simétrica de los controles. Un contenedor oscuro estilizado envuelve los botones de "Registrarse" y "Admin", que ahora están perfectamente centrados.
- **Navegación Intuitiva:** Implementación funcional del botón "Cerrar Sesión" en la pantalla principal para regresar al Login reseteando el contexto del usuario.

---

## 🗄️ Arquitectura MongoDB (Del Mundo Relacional al NoSQL)

El esquema original constaba de **16 tablas relacionales** en SQL Server. Lo hemos rediseñado para convertirlo en **solo 4 colecciones** en MongoDB, justificando cada decisión:

### 1. Colección `Cuentas` (Patrón de Documento Embebido)
* **Lo que reemplaza:** Las antiguas tablas `CUENTA`, `PLAN`, `PERFIL` y `PAGO`.
* **Justificación:** Los pagos, los planes y los perfiles (que tienen un límite estricto de 5) siempre se consultan junto con la cuenta. Al embeberlos en un solo gran documento, optimizamos las lecturas y evitamos operaciones de `JOIN` (`Read-heavy optimization`).

### 2. Colección `Contenidos` (Patrón Polimórfico y Embebido)
* **Lo que reemplaza:** Las tablas `CONTENIDO`, `SERIE`, `TEMPORADA`, `EPISODIO`, `GENERO` y `CLASIFICACION`.
* **Justificación:** Es un catálogo híbrido. Una "Serie" embebe todas sus temporadas, y cada temporada embebe sus episodios. Esto permite cargar la estructura jerárquica de toda una serie de televisión en un solo milisegundo mediante una única consulta.

### 3. Colecciones `Interacciones_Historial` e `Interacciones_Calificaciones` (Patrón de Referencia / Outlier)
* **Lo que reemplaza:** Las tablas `HISTORIAL_VISUALIZACION` y `CALIFICACION`.
* **Justificación:** Un usuario puede ver miles de episodios a lo largo de los años. Si embebemos esto en la `Cuenta`, la base de datos sufriría el temido **Unbounded Growth** (crecimiento descontrolado), superando el límite de los 16MB por documento que impone MongoDB. Por ello, es obligatorio mantenerlos en colecciones referenciadas.

---
*Desarrollado para la materia de Bases de Datos II - UCB (Proyecto Final).*
