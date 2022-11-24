# Proyecto02 - Procesamiento de imágenes (detección de figuras).
[![License](https://img.shields.io/badge/license-GPLv2-blue.svg)](https://wordpress.org/about/license/)

Programa de detección de figuras geométricas. Desarrollado con _C#_ haciendo uso de _.NET_ (versión 6.0).   

## Pre-requisitos.
**_El programa solo es funcional en el sistema operativo Windows (versión 10 o superior)_**

Tener instalado .NET (versión 6.0 o superior)

* Windows
```sh
   https://dotnet.microsoft.com/en-us/download
```

Dependencias del programa:

* System.Drawing (versión 7).

```sh
   https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only
```

Dependencias de desarrollo:

* xunit (versión 2.4.2).
* xunit.runner.visualstudio (versión 0.4.5).

```sh
   https://learn.microsoft.com/es-es/dotnet/core/testing/unit-testing-with-dotnet-test
```

## Instalación

1. Clonar el repositorio
 ```sh
   git clone https://github.com/SrSujeto55/Proyecto02.git
```
 ```sh
   cd Proyecto02
```

## Pruebas unitarias
```sh
   dotnet test
```

## Ejecución 
Al momento de ejecutar, las dependencias se instalan automáticamente.
```sh
   dotnet run [A]
```

donde:

[A] - Ruta relativa o absoluta de la imagen a procesar.

**NOTA: La imagen a procesar debe contener figuras geométricas (regulares o irregulares) de colores distintos, y con fondo de color fijo. Además de que debe tener extensión _.bmp_** 

### PDF con mas detalles del proyecto
 * https://drive.google.com/file/d/1pJyAcMRbkrQlQ6HuIE65QSrejXKPPqk1/view 

## Contacto 
Julián Rosas Scull - julian.rosas@ciencias.unam.mx

Ricardo Flores Mata - ricardo_fm77@ciencias.unam.mx

Emiliano López Prado - emilianolp@ciencias.unam.mx

Link del proyecto - https://github.com/SrSujeto55/Proyecto02
