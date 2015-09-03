using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    public class DataSet
    {
        public static object[] getTables()
        {
            return new[]{ 
                new []{
                    "NODO_IEC",
                    "ALIMENTADOR"
                }, 
                new []{
                    "CONEXION_NODO_IEC"
                }, 
                new[]{
                    "ALIMENTADOR_RURALIDAD",
                    "BAJADA",
                    "BOVEDA",
                    "CAMARA",
                    "CANALIZACION",                
                    "EMPALME",
                    "ENMALLE",
                    "EQUIPO",
                    "ESTRUCTURA",
                    "MARCA",
                    "MEDIDOR",                
                    "NODO_IEC_CABECERA",
                    "NODO_IEC_EXTERNO",
                    "NODO_SUBESTACION",
                    "POSTE",
                    "PUNTO_CONSUMO",
                    "SUBESTACION_DISTRIBUCION",
                    "TIRANTE",
                    "TOMA_TIERRA",
                    "TRAMO",
                    "TRANSFORMADOR",
                    "VERTICE_CANALIZACION",
                    "VERTICE_EMPALME",
                    "VERTICE_TRAMO"
                }                
            };
        }
    }
}
