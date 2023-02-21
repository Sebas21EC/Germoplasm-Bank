namespace GermoBank.Models.ModelsPersonalizados
{
    public class AccesionesModel
    {
        public string nombre_local_accesion { get; set; }
        public string id_accesion_pk { get; set; }
        public DateTime fecha_ingreso { get; set; }

        /*taxonomia*/
        public string nombre_familia { get; set; }
        public string nombre_genero { get; set; }
        public string nombre_especie { get; set; }
        public string nombre_subespecie { get; set; }

        /*recolector*/
        public string nombre_instituto { get; set; }
        public string detalle_instituto { get; set; }
        public string primer_nombre_colector { get; set; }
        public string primer_apellido_colector { get; set; }
        public string telefono_colecto { get; set; }
        public string email_colector { get; set; }

        /*antecedentes*/
        public string nombre_uso { get; set; }
        public string nombre_practica_cultural { get; set; }
        public string nombre_plaga_enfermedad { get; set; }
        public DateTime fecha_siembra { get; set; }
        public DateTime fecha_cosecha { get; set; }
        public DateTime fecha_floracion { get; set; }
        public DateTime fecha_fructuacion { get; set; }
        public string observacion_antecedente { get; set; }


        /*propiedad*/
        public string nombre_propiedad { get; set; }
        public string nombre_propietario { get; set; }
        public string apellido_propietario { get; set; }
        public string telefono_propietario { get; set; }
        public string email_propietario { get; set; }


        /*ubicacion*/
        public string nombre_pais { get; set; }
        public string nombre_provincia { get; set; }
        public string nombre_canton { get; set; }
        public string nombre_parroquia { get; set; }
        public string calle_principal { get; set; }
        public string calle_secundaria { get; set; }
        public string referencia_direcion { get; set; }

        /*detalles de la localidad*/
        public string latitud_propiedad { get; set; }
        public string altitud_propiedad { get; set; }
        public string longitud_propiedad { get; set; }
        public string nombre_forma_geografica { get; set; }
        public string luz { get; set; }
        public string temperatura_clima { get; set; }
        public string humedad_clima { get; set; }

        /*suelo*/
        public string nombre_textura_suelo { get; set; }
        public string color { get; set; }
        public bool drenaje_suelo { get; set; }
        public bool erosion_suelo { get; set; }
        public bool pedregosidad_suelo { get; set; }

        /*mas detalles */
        public string nombre_estado_germoplasma { get; set; }
        public string nombre_metodo_muestra { get; set; }
    }
}
