﻿using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial.Entidades
{
    public class Vendedores
    {
        [key]
        public int VendedorId { get; set; }
        public String Nombres { get; set; }
        public decimal Sueldo { get; set; }
        public decimal PorcientoRetencion { get; set; }
        public decimal Retencion { get; set; }


        public Vendedores()
        {
            VendedorId = 0;
            Nombres = string.Empty;
            Sueldo = 0;
            PorcientoRetencion = 0;
            Retencion = 0;
        }
    }

    internal class keyAttribute : Attribute
    {
    }
}