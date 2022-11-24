using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Src;

/// <summary>
/// Clase que se encarga de gestionar las demás clases.
/// </summary>
#pragma warning disable CS8625, CA1416, CS8618
class Manager
{
    /// <value> La ruta de la imagen a trabajar </value>
    private string _pathImage;

    /// <value> el bitmap asociado a la imagen a trabajar </value>
    private Bitmap _imageBitmap;
    
    /// <summary>
    /// Constructor que recibe los parámetros de la línea de comandos del Main.
    /// termina el programa si los argumentos exceden el límite de 1
    /// o en caso contrario, si no recibe parámetros
    /// </summary>
    /// 
    /// <param name="args"> Argumentos del main </param>

    public Manager(string[] args)
    {
        if (args.Length > 1)
        {
            Console.Error.WriteLine("Only one image to process at a time is allowed.");
            Environment.Exit(0);
        }
      
        if (args.Length == 0)
        {
            Console.Error.WriteLine("Introduce an image to process as an argument");
            Environment.Exit(0);
        }

        _pathImage = args[0];

    }

    /// <summary>
    /// Revisa si la imagen recibida por parámetros existe
    /// </summary>
    /// 
    /// <returns> true si la imagen existe, false en caso contrario </returns>
    private bool ValidateImage() 
    {
        return File.Exists(_pathImage);
    }

    /// <summary>
    /// Método inicial que se encarga de ejecutar toda la lógica del programa
    /// Antes de trabajar con una imagen, se asegura de que dicha imagen existe y que
    /// pueda ser convertida a la clase Bitmap, en caso contrario termina el programa
    /// </summary>
    public void Manage()
    {
        if (!ValidateImage())
        {
            Console.Error.WriteLine("Invalid Image");
            Environment.Exit(0);
        }

        try
        {
            _imageBitmap = new Bitmap(_pathImage);
        }
        catch (ArgumentException)
        {
            Console.Error.WriteLine("Invalid Image Format");
            Environment.Exit(0);
        }
        finally
        {
            FigureImage fullImage = Filter.FilterImage(_imageBitmap);
            fullImage.Clasificate();
            Console.WriteLine(fullImage.ToString());
        }
    }
}