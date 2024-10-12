# Prueba Técnica para desarrollador .NET

La solución de la prueba técnica consiste en un servidor REST monolítico desaclopado del frontend y
elaborado con **.NET** y **C#** usando el Framework **.NET 8** con **Entity Framework** y **ASP.NET Core Web API**
y una base de datos relacional **Microsoft SQL Server**. Por otra parte, la API
cuenta con autenticación basada **JWT**, es decir, **JSON Web Tokens** donde
cada enpoint se encuentra protegido, por lo que deberá registrar un usuario
con un correo y contraseña para posteriormente iniciar su sesión con el usuario dado
por usted en conjunto con su respectiva contraseña.

Para una mayor facilidad de testeo, se ha habilitado la documentación automática de
**Swagger** en conjunto con la autenticación basada en **JWT** por lo que podrá probar
que los enpoints se encuentran protegidos bajo autenticación al momento de hacer uso de
los mismos. Se recomienda entonces, referirse a la documentación generada por **Swagger** al
momento de levantar el proyecto.

## Guía de instalación y despliegue

1. Se recomienda clonar el proyecto directamente desde Visual Studio usando la url de repositorio, de esta forma se prepará de forma casi automática.
2. Instalar las dependencias en caso de que las mismas no sean instaladas automáticamente por Visual Studio, puede usar `nuget restore` desde su terminal.
3. Configure la URL para el servidor de SQL Server en el archivo **appsetting.json**, puede usar la siguiente cambiando el
   nombre del servidor al que está instalado en su equipo local:
   `server=NOMBRE-SERVIDOR\\SQLEXPRESS;Database=DotNetAssessmentDB;Trusted_connection=true;TrustServerCertificate=true`
   Mantenga el campo Database y los restantes iguales, solo modifique el servidor, copie y pegue la url en el archivo appsettings.json.
4. En Visual Studio, abra una ventana del **package manager console** o consola para manejar de paquetes de Nuget, luego ejecute
   los dos siguientes comandos en el orden que se muestran para crear las tablas:

- `add-migration "restore all tables"`
- `update-database`

5. Una vez creadas las tablas, puede ejecutar el siguiente **script SQL** para hacer un seed de la base de datos

```
USE [DotNetAssessmentDB]
GO
Insert into [DotNetAssessmentDB].[dbo].[Products] ([Id], [Name], [Faulty], [Dispatched], [ManufacturingProcessId]) VALUES (N'14ceba71-4b51-4777-9b17-46602cf66153', 'Zapatos Nike', 0, 0, N'D321CE3E-CD2F-4CE0-B8BD-16C28D06E13A')
GO
Insert into [DotNetAssessmentDB].[dbo].[Products] ([Id], [Name], [Faulty], [Dispatched], [ManufacturingProcessId]) VALUES (N'8D1C829A-C36E-40E7-AD8E-08DCEA59831B', 'Zapatos Adidas', 1, 0, N'D321CE3E-CD2F-4CE0-B8BD-16C28D06E13A')
GO
Insert into [DotNetAssessmentDB].[dbo].[Products] ([Id], [Name], [Faulty], [Dispatched], [ManufacturingProcessId]) VALUES (N'4FA7F9F7-46D2-4612-AD8D-08DCEA59831B', 'Zapatos Umbro', 0, 1, N'A8FE47FD-0B62-49AE-A229-2790FF04C4D9')
GO
Insert into [DotNetAssessmentDB].[dbo].[Products] ([Id], [Name], [Faulty], [Dispatched], [ManufacturingProcessId]) VALUES (N'437BBD6E-328E-44E5-AD90-08DCEA59831B', 'Zapatos YouCanFly', 1, 1, N'A8FE47FD-0B62-49AE-A229-2790FF04C4D9');
```

6. En base a lo anterior, puede iniciar el proyecto desde visual studio usando http.

7. Esto levantará la documentación automática de **Swagger**, donde podrá visualizar todos los enpoints, recuerde
   registrarse y tomar token que se le suministra en la respuesta y presionar el botón de autorización en **Swagger**
   para suministrar el token al mismo, de esta formá tendrá acceso al resto de recursos.

8. Es importante aclarar que los enpoints están documentados con **Swagger**, así mismo se creó una tabla adicional
   para los valores que corresponden al tipo de fabricación de un producto, por ello observará dos enpoints dedicados
   a obtener los id de los mismo, de este modo cuando cree un nuevo producto, suministre el ID que corresponde y no el
   nombre del método de fabricación.

## Formato JSON de ejemplo para realizar inserción masiva de productos en la base de datos mediante el enpoint creado

```.json
{
  "products": [
    {
      "name": "Camisa Adidas",
      "faulty": false,
      "dispatched": true,
      "manufacturingProcessId": "d321ce3e-cd2f-4ce0-b8bd-16c28d06e13a"
    },
    {
      "name": "Camisa Nike",
      "faulty": false,
      "dispatched": true,
      "manufacturingProcessId": "d321ce3e-cd2f-4ce0-b8bd-16c28d06e13a"
    },
    {
      "name": "Camisa Lacoste",
      "faulty": false,
      "dispatched": false,
      "manufacturingProcessId": "d321ce3e-cd2f-4ce0-b8bd-16c28d06e13a"
    },
      {
      "name": "Pantalon Levis",
      "faulty": true,
      "dispatched": false,
      "manufacturingProcessId": "a8fe47fd-0b62-49ae-a229-2790ff04c4d9"
    }
  ]
}
```
