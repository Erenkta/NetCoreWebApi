﻿using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class Product
    {
        public int Id { get; set; }

        // Reference Type'lar nullable olabilir bundan required olup olmadığını belirtmek bir best practice'dir
        // public required string Name => Bu constructor ile Product oluşturunca isim atanmasını zorunlu kılar
        // default! ise buna bir default değer atanmamasını söyler. Yani null olmasın demektir.
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
