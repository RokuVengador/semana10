using System;
using System.Collections.Generic;

namespace Semana10.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripción { get; set; }

    public double? Precio { get; set; }

    public int? Stock { get; set; }
}
