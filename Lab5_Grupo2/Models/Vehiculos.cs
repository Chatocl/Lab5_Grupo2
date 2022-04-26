using System;
using Lab5_Grupo2.Models.Datos;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Lab5_Grupo2.Models
{
    public class Vehiculos: IComparable<Vehiculos>
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(6)]
        public int Placa { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Color { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Propietario { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Latitud { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Longitud { get; set; }

        public int CompareTo(Vehiculos Otro)
        {
            if (Otro==null)
            {
                return 0;
            }
            else
            {
                return this.Placa.CompareTo(Otro.Placa);
            }
        }
    }
}
