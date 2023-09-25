using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;

namespace Modelo
{
    public class RepositorioOrigen
    {
        private static RepositorioOrigen instancia;
        private List<Origen> origenes;
        private IConfigurationRoot configuration;

        private RepositorioOrigen()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            origenes = new List<Origen>();
            ListarOrigenes();
        }

        public static RepositorioOrigen Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new RepositorioOrigen();
                }

                return instancia;
            }
        }

        public ReadOnlyCollection<Origen> RecuperarOrigenes()
        {
            try
            {
                return origenes.AsReadOnly();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Agregar(Origen origen)
        {
            if (AgregarOrigen(origen))
            {
                origenes.Add(origen);
                return true;
            }
            return false;
        }

        private bool AgregarOrigen(Origen origen)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();

            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_AGREGARORIGEN";
                command.Connection = connection;
                command.Transaction = sqlTransaction;

                command.Parameters.Add("@NombreHistoria", System.Data.SqlDbType.NVarChar, 50).Value = origen.NombreHistoria;
                command.Parameters.Add("@Lugar", System.Data.SqlDbType.NVarChar, 50).Value = origen.Lugar;
                command.Parameters.Add("@Historia", System.Data.SqlDbType.NVarChar, -1).Value = origen.Historia;

                command.ExecuteNonQuery();
                sqlTransaction.Commit();
                connection.Close();
                ok = true;
            }
            catch (SqlException ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return ok;
        }

        public bool Eliminar(Origen origen)
        {
            if (EliminarOrigen(origen))
            {
                origenes.Remove(origen);
                return true;
            }
            return false;
        }

        private bool EliminarOrigen(Origen origen)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();

            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ELIMINARORIGEN";
                command.Connection = connection;
                command.Transaction = sqlTransaction;

                command.Parameters.Add("@NombreHistoria", System.Data.SqlDbType.NVarChar, 20).Value = origen.NombreHistoria;

                command.ExecuteNonQuery();
                sqlTransaction.Commit();
                connection.Close();
                ok = true;
            }
            catch (SqlException ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return ok;
        }

        public bool Modificar(Origen origen)
        {
            if (ModificarOrigen(origen))
            {
                var OrigenModificado = origenes.FirstOrDefault(o => o.NombreHistoria == origen.NombreHistoria);
                OrigenModificado.Lugar = origen.Lugar;
                OrigenModificado.Historia = origen.Historia;
                return true;
            }
            return false;
        }

        private bool ModificarOrigen(Origen origen)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();

            try
            {
                using SqlCommand command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_MODIFICARORIGEN";
                command.Connection = connection;
                command.Transaction = sqlTransaction;

                command.Parameters.Add("@NombreHistoria", System.Data.SqlDbType.NVarChar, 50).Value = origen.NombreHistoria;
                command.Parameters.Add("@Lugar", System.Data.SqlDbType.NVarChar, 50).Value = origen.Lugar;
                command.Parameters.Add("@Historia", System.Data.SqlDbType.NVarChar, 500).Value = origen.Historia;

                command.ExecuteNonQuery();
                sqlTransaction.Commit();
                connection.Close();
                ok = true;
            }
            catch (SqlException ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return ok;
        }

        private void ListarOrigenes()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    using var command = new SqlCommand();

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_RECUPERARORIGEN";
                    command.Connection = connection;

                    connection.Open();

                    using var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var origen = new Origen();
                        origen.NombreHistoria = reader["NombreHistoria"].ToString();
                        origen.Lugar = reader["Lugar"].ToString();
                        origen.Historia = reader["Historia"].ToString();

                        origenes.Add(origen);
                    }
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                }
        }

        internal Origen RecuperarOrigen(string nombreHistoria)
        {
            var origen = origenes.FirstOrDefault(o => o.NombreHistoria == nombreHistoria);
            return origen;
        }
    }
}
