using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data
{
    public class UsuarioData
    {
        public static bool Registrar(Usuario empleado)
        {

            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                SqlCommand cmd = new SqlCommand("ep_agregar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cedula", empleado.Cedula);
                cmd.Parameters.AddWithValue("@nombre", empleado.Nombre);
                cmd.Parameters.AddWithValue("@apellido", empleado.Apellido);
                cmd.Parameters.AddWithValue("@fechaNacimiento", empleado.fechaNacimiento);
                cmd.Parameters.AddWithValue("@cargo", empleado.Cargo);
                cmd.Parameters.AddWithValue("@departamento", empleado.Departamento);
                cmd.Parameters.AddWithValue("@horarioTrabajo", empleado.HorarioTrabajo);
                cmd.Parameters.AddWithValue("@telefono", empleado.Telefono);
                cmd.Parameters.AddWithValue("@correo", empleado.correo);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }

                catch (Exception ex)
                {
                    return false;
                }

            }

        }

        //Metodo modificar

        public static bool Modificar(Usuario empleado)
        {

            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {

                SqlCommand cmd = new SqlCommand("ep_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", empleado.Id);
                cmd.Parameters.AddWithValue("@cedula", empleado.Cedula);
                cmd.Parameters.AddWithValue("@nombre", empleado.Nombre);
                cmd.Parameters.AddWithValue("@telefono", empleado.Apellido);
                cmd.Parameters.AddWithValue("@fechaNacimiento", empleado.fechaNacimiento);
                cmd.Parameters.AddWithValue("@cargo", empleado.Cargo);
                cmd.Parameters.AddWithValue("@departamento", empleado.Departamento);
                cmd.Parameters.AddWithValue("@horarioTrabajo", empleado.HorarioTrabajo);
                cmd.Parameters.AddWithValue("@telefono", empleado.Telefono);
                cmd.Parameters.AddWithValue("@correo", empleado.correo);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }

                catch (Exception ex)
                {
                    return false;
                }

            }

        }

        //Metodo Listar

        public static List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                SqlCommand cmd = new SqlCommand("ep_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {

                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {


                            lista.Add(new Usuario()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Cedula = dr["Cedula"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                fechaNacimiento = dr["FechaNacimiento"].ToString(),
                                Cargo = dr["cargo"].ToString(),
                                Departamento = dr["departamento"].ToString(),
                                HorarioTrabajo = dr["horarioTrabajo"].ToString(),
                                Telefono = dr["telefono"].ToString(),
                                correo = dr["correo"].ToString(),


                            });

                        }
                    }

                    return lista;
                }
                catch (Exception ex)
                {
                    return lista;
                }


            }
        }

        public static Usuario Obtener(int id)
        {
            Usuario oEmpleados = new Usuario();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                SqlCommand cmd = new SqlCommand("ep_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                try
                {

                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {


                            oEmpleados = new Usuario()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Cedula = dr["Cedula"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                fechaNacimiento = dr["FechaNacimiento"].ToString(),
                                Cargo = dr["cargo"].ToString(),
                                Departamento = dr["departamento"].ToString(),
                                HorarioTrabajo = dr["horarioTrabajo"].ToString(),
                                Telefono = dr["telefono"].ToString(),
                                correo = dr["correo"].ToString(),


                            };

                        }
                    }

                    return oEmpleados;
                }
                catch (Exception ex)
                {
                    return oEmpleados;
                }

            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                SqlCommand cmd = new SqlCommand("ep_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                try
                {

                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }


    }
}
