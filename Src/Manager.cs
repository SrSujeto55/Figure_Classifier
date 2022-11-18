using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Src;
//Clase que se encarga de gestionar las demás clases.

class Manager
{

    private string _pathImage;

    private Bitmap _imageBitmap;
    
    // Constructor que recibe los parámetros de la línea de comandos del Main.
    public Manager(string[] args)
    {

        // si se introdujo mas de una imagen a analizar.
        if (args.Length > 1)
        {
            Console.Error.WriteLine("Only one image to process at a time is allowed.");
            Environment.Exit(0);
        }


        // si se introdujo mas de una imagen a analizar       
        if (args.Length == 0)
        {
            Console.Error.WriteLine("Introduce an image to process as an argument");
            Environment.Exit(0);
        }

        _pathImage = args[0];

    }

    private bool ValidateImage() 
    {
        return File.Exists(_pathImage);
    }

    public void Manage()
    {
        // aqui se llama toda la logica 

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
            FigureImage fullImage =  Filter.FilterImage(_imageBitmap);

        }



    }
}