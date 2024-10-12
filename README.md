# Prueba Técnica para desarrollador .NET

La solución de la prueba técnica consiste en un servidor REST monolítico desaclopado del frontend y
elaborado con **.NET** y **C#** usando el SDK **.NET 8** en conjunto con **Entity Framework**
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

## Script para realizar seed de la base de datos

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

## Formato JSON de ejemplo para realizar inserción masiva de productos en la base de datos

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
