# Productos API

Esta es una API REST en .NET 9 para gestionar productos con operaciones básicas como crear, leer, actualizar y eliminar (CRUD).

## Requisitos

- .NET 9 instalado  
- SQL Server  
- Visual Studio
- Postman (opcional, para pruebas)  

## Instalación

### Clonar el repositorio
```bash
git clone https://github.com/RomanNaimanSocius/ProductosApi
git cd ProductosApi
```

### Configurar la base de datos
Abrir `appsettings.json` y editar la configuración del servidor:
```json
"DefaultConnection": "Server=Halfdan;Database=WebApiProductosDB;Integrated Security=True;TrustServerCertificate=True"
```
Es necesario cambiar el host del servidor y es opcional cambiar le nombre del servidor.

### Ejecutar migraciones
```bash
Add-Migration Inicio
Updatate-Database
```

### Ejecutar la API
Rn visual estudio code precionar CTRL + F5

## Endpoints principales

### Obtener todos los productos
```http
GET /api/productos
```

### Obtener un producto por ID
```http
GET /api/productos/{id}
```

### Crear un nuevo producto
```http
POST /api/productos
```

### Actualizar un producto
```http
PUT /api/productos/{id}
```

### Eliminar un producto
```http
DELETE /api/productos/{id}
```

## Pruebas 

se pueden probar los endpoints con Postman o con Swagger(agregar "/swagger" luego del localhost que te de al correr la app":

[https://localhost:xxxx/swagger)




