|Languages|Productos|Nombre|Descripción|
|---------|---------|------|-----------|
|c#|dotnet|Trop E-Commerce|Aplicación de ventas de ropa|

# Trop E-Commerce

### En que consisten esta app?

## Pre-requisitos

* [.Net 9 Sdk]()
* [Docker]() o [Podman]()
  - `redis:alpine3.20` o superior
  - `postgres:17.0-alpine3`.20 0 superior
* Opcional [Vim]()

### Como ejecutar esta app

1. Necesitas inicializar `Podman` o `Docker` para proporcionar una base de datos estable rápida de utilizar y desechar

2. Inicializar 2 contenedores o un compose como prefieras o utilizar otros medios para ejecutar bases de datos , inicializar un motor de base de datos de `postgres` y `redis`

3. Configurar variables de entorno de conección a las bases de datos