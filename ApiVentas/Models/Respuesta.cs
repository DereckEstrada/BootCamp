﻿namespace ApiVentas.Models
{
    public class Respuesta
    {
        public string Cod { get; set; }
        public int Cantidad { get; set; }
        public dynamic Data { get; set; }
        public string Mensaje { get; set; }
    }
}