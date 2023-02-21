using Microsoft.AspNetCore.Http;
using Npgsql;
using System.Drawing;
using System;
using GermoBank.Models.ModelsPersonalizados;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.Data.SqlClient;

using System.Data;

namespace GermoBank.Datos.DatosPersonalizados
{
    public class AccesionDatos
    {






        public List<AccesionesModel> ListarAccesiones() { 
        
            var oLista = new List<AccesionesModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSql())) { 
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ACCESION_VIEW",conexion);
                cmd.CommandType= CommandType.StoredProcedure;
                using(var reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        oLista.Add(new AccesionesModel()
                        {
                            nombre_local_accesion = reader["nombre_local_accesion"].ToString(),
                            id_accesion_pk = reader["id_accesion_pk"].ToString(),
                            fecha_ingreso = Convert.ToDateTime(reader["fecha_ingreso"]),

                            /*taxonomia*/
                            nombre_familia = reader["nombre_familia"].ToString(),
                            nombre_genero = reader["nombre_genero"].ToString(),
                            nombre_especie = reader["nombre_especie"].ToString(),
                            nombre_subespecie = reader["nombre_subespecie"].ToString(),

                            /*recolector*/
                            nombre_instituto = reader["nombre_instituto"].ToString(),
                            detalle_instituto = reader["detalle_instituto"].ToString(),
                            primer_nombre_colector = reader["primer_nombre_colector"].ToString(),
                            primer_apellido_colector = reader["primer_apellido_colector"].ToString(),
                            telefono_colecto = reader["telefono_colecto"].ToString(),
                            email_colector = reader["email_colector"].ToString(),

                            /*antecedentes*/
                            nombre_uso = reader["nombre_uso"].ToString(),
                            nombre_practica_cultural = reader["nombre_practica_cultural"].ToString(),
                            nombre_plaga_enfermedad = reader["nombre_plaga_enfermedad"].ToString(),
                            fecha_siembra = Convert.ToDateTime(reader["fecha_siembra"]),
                            fecha_cosecha = Convert.ToDateTime(reader["fecha_cosecha"]),
                            fecha_floracion = Convert.ToDateTime(reader["fecha_floracion"]),
                            fecha_fructuacion = Convert.ToDateTime(reader["fecha_fructuacion"]),
                            observacion_antecedente = reader["observacion_antecedente"].ToString(),


                            /*propiedad*/
                            nombre_propiedad = reader["nombre_propiedad"].ToString(),
                            nombre_propietario = reader["nombre_propietario"].ToString(),
                            apellido_propietario = reader["apellido_propietario"].ToString(),
                            telefono_propietario = reader["telefono_propietario"].ToString(),
                            email_propietario = reader["email_propietario"].ToString(),


                            /*ubicacion*/
                            nombre_pais = reader["nombre_pais"].ToString(),
                            nombre_provincia = reader["nombre_provincia"].ToString(),
                            nombre_canton = reader["nombre_canton"].ToString(),
                            nombre_parroquia = reader["nombre_parroquia"].ToString(),
                            calle_principal = reader["calle_principal"].ToString(),
                            calle_secundaria = reader["calle_secundaria"].ToString(),
                            referencia_direcion = reader["referencia_direcion"].ToString(),

                            /*detalles de la localidad*/
                            latitud_propiedad = reader["latitud_propiedad"].ToString(),
                            altitud_propiedad = reader["altitud_propiedad"].ToString(),
                            longitud_propiedad = reader["longitud_propiedad"].ToString(),
                            nombre_forma_geografica = reader["nombre_forma_geografica"].ToString(),
                            luz = reader["luz"].ToString(),
                            temperatura_clima = reader["temperatura_clima"].ToString(),
                            humedad_clima = reader["humedad_clima"].ToString(),

                            /*suelo*/
                            nombre_textura_suelo = reader["nombre_textura_suelo"].ToString(),
                            color = reader["color"].ToString(),
                            drenaje_suelo = Convert.ToBoolean(reader["drenaje_suelo"]),
                            erosion_suelo = Convert.ToBoolean(reader["erosion_suelo"]),
                            pedregosidad_suelo = Convert.ToBoolean(reader["pedregosidad_suelo"]),

                            /*mas detalles */
                            nombre_estado_germoplasma = reader["nombre_estado_germoplasma"].ToString(),
                            nombre_metodo_muestra = reader["nombre_metodo_muestra"].ToString()

                        });
                    }
                }

                conexion.Close();
            
            }
            return oLista;
        }

        public AccesionesModel ObtenerAccesion()
        {

            var oAccesion = new AccesionesModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ACCESION_ULTIMA_VIEW", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        oAccesion.nombre_local_accesion = reader["nombre_local_accesion"].ToString();
                        oAccesion.id_accesion_pk = reader["id_accesion_pk"].ToString();
                        oAccesion.fecha_ingreso = Convert.ToDateTime(reader["fecha_ingreso"]);

                        /*taxonomia*/
                        oAccesion.nombre_familia = reader["nombre_familia"].ToString();
                        oAccesion.nombre_genero = reader["nombre_genero"].ToString();
                        oAccesion.nombre_especie = reader["nombre_especie"].ToString();
                        oAccesion.nombre_subespecie = reader["nombre_subespecie"].ToString();

                        /*recolector*/
                        oAccesion.nombre_instituto = reader["nombre_instituto"].ToString();
                        oAccesion.detalle_instituto = reader["detalle_instituto"].ToString();
                        oAccesion.primer_nombre_colector = reader["primer_nombre_colector"].ToString();
                        oAccesion.primer_apellido_colector = reader["primer_apellido_colector"].ToString();
                        oAccesion.telefono_colecto = reader["telefono_colecto"].ToString();
                        oAccesion.email_colector = reader["email_colector"].ToString();

                        /*antecedentes*/
                        oAccesion.nombre_uso = reader["nombre_uso"].ToString();
                        oAccesion.nombre_practica_cultural = reader["nombre_practica_cultural"].ToString();
                        oAccesion.nombre_plaga_enfermedad = reader["nombre_plaga_enfermedad"].ToString();
                        oAccesion.fecha_siembra = Convert.ToDateTime(reader["fecha_siembra"]);
                        oAccesion.fecha_cosecha = Convert.ToDateTime(reader["fecha_cosecha"]);
                        oAccesion.fecha_floracion = Convert.ToDateTime(reader["fecha_floracion"]);
                        oAccesion.fecha_fructuacion = Convert.ToDateTime(reader["fecha_fructuacion"]);
                        oAccesion.observacion_antecedente = reader["observacion_antecedente"].ToString();


                        /*propiedad*/
                        oAccesion.nombre_propiedad = reader["nombre_propiedad"].ToString();
                        oAccesion.nombre_propietario = reader["nombre_propietario"].ToString();
                        oAccesion.apellido_propietario = reader["apellido_propietario"].ToString();
                        oAccesion.telefono_propietario = reader["telefono_propietario"].ToString();
                        oAccesion.email_propietario = reader["email_propietario"].ToString();


                        /*ubicacion*/
                        oAccesion.nombre_pais = reader["nombre_pais"].ToString();
                        oAccesion.nombre_provincia = reader["nombre_provincia"].ToString();
                        oAccesion.nombre_canton = reader["nombre_canton"].ToString();
                        oAccesion.nombre_parroquia = reader["nombre_parroquia"].ToString();
                        oAccesion.calle_principal = reader["calle_principal"].ToString();
                        oAccesion.calle_secundaria = reader["calle_secundaria"].ToString();
                        oAccesion.referencia_direcion = reader["referencia_direcion"].ToString();

                        /*detalles de la localidad*/
                        oAccesion.latitud_propiedad = reader["latitud_propiedad"].ToString();
                        oAccesion.altitud_propiedad = reader["altitud_propiedad"].ToString();
                        oAccesion.longitud_propiedad = reader["longitud_propiedad"].ToString();
                        oAccesion.nombre_forma_geografica = reader["nombre_forma_geografica"].ToString();
                        oAccesion.luz = reader["luz"].ToString();
                        oAccesion.temperatura_clima = reader["temperatura_clima"].ToString();
                        oAccesion.humedad_clima = reader["humedad_clima"].ToString();

                        /*suelo*/
                        oAccesion.nombre_textura_suelo = reader["nombre_textura_suelo"].ToString();
                        oAccesion.color = reader["color"].ToString();
                            oAccesion.drenaje_suelo = Convert.ToBoolean(reader["drenaje_suelo"]);
                        oAccesion.erosion_suelo = Convert.ToBoolean(reader["erosion_suelo"]);
                        oAccesion.pedregosidad_suelo = Convert.ToBoolean(reader["pedregosidad_suelo"]);

                        /*mas detalles */
                        oAccesion.nombre_estado_germoplasma = reader["nombre_estado_germoplasma"].ToString();
                        oAccesion.nombre_metodo_muestra = reader["nombre_metodo_muestra"].ToString();
                            


                    }
                }

                conexion.Close();

            }
            return oAccesion;
        }












    }
}
