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
        [StringLength(6,MinimumLength = 6,ErrorMessage ="El tamaño de la placas es de 6 caracteres")]
        public int Placa { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Color { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Propietario { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Range(-90,90,ErrorMessage ="El rango de entrada es de -90 a 90 grados")]
        public int Latitud { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Range(-180,180, ErrorMessage = "El rango de entrada es de -180 a 180 grados")]
        public int Longitud { get; set; }

        public int CompareTo(Vehiculos Otro)
        {
            if(Otro==null)
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
