﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Chocolates.Models
{
    public partial class Chocolate
    {
        public int IdChocolate { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Imagen { get; set; }
        public decimal Precio { get; set; }
        public int IdCategoria { get; set; }

        public virtual Categoria? Categoria { get; set; }
    }

}
