using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;

namespace Modelo
{
    public class RepositorioHeroe
    {
        private static RepositorioHeroe instancia;
        private List<Heroe> heroes;
        private IConfigurationRoot configuration;

        private RepositorioHeroe()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            heroes = new List<Heroe>();
            ListarHeroes();
        }

        public static RepositorioHeroe Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new RepositorioHeroe();
                }

                return instancia;
            }
        }

        public ReadOnlyCollection<Heroe> RecuperarHeroes()
        {
            try
            {
                return heroes.AsReadOnly();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Agregar(Heroe heroe)
        {
            if (AgregarHeroe(heroe))
            {
                heroes.Add(heroe);
                return true;
            }
            return false;
        }

        private bool AgregarHeroe(Heroe heroe)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();

            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_AGREGARHEROE";
                command.Connection = connection;
                command.Transaction = sqlTransaction;

                command.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 50).Value = heroe.Nombre;
                command.Parameters.Add("@Clase", System.Data.SqlDbType.NVarChar, 50).Value = heroe.Clase;
                command.Parameters.Add("@Nivel", System.Data.SqlDbType.Int).Value = heroe.Nivel;
                command.Parameters.Add("@NombreHistoria", System.Data.SqlDbType.NVarChar, 50).Value = heroe.Origen.NombreHistoria;

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

        public bool Eliminar(Heroe heroe)
        {
            if (EliminarHeroe(heroe))
            {
                heroes.Remove(heroe);
                return true;
            }
            return false;
        }

        private bool EliminarHeroe(Heroe heroe)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();

            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ELIMINARHEROE";
                command.Connection = connection;
                command.Transaction = sqlTransaction;

                command.Parameters.Add("@Nombre", System.Data.SqlDbType.Int).Value = heroe.Nombre;

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

        public bool Modificar(Heroe heroe)
        {
            if (ModificarHeroe(heroe))
            {
                var HeroeModificado = heroes.FirstOrDefault(h => h.Nombre == heroe.Nombre);
                HeroeModificado.Clase = heroe.Clase;
                HeroeModificado.Nivel = heroe.Nivel;
                HeroeModificado.Origen = heroe.Origen;
                return true;
            }
            return false;
        }

        private bool ModificarHeroe(Heroe heroe)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();

            try
            {
                using SqlCommand command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_MODIFICARHEROE";
                command.Connection = connection;
                command.Transaction = sqlTransaction;

                command.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 50).Value = heroe.Nombre;
                command.Parameters.Add("@Clase", System.Data.SqlDbType.NVarChar, 50).Value = heroe.Clase;
                command.Parameters.Add("@Nivel", System.Data.SqlDbType.Int).Value = heroe.Nivel;
                command.Parameters.Add("@NombreHistoria", System.Data.SqlDbType.NVarChar, 50).Value = heroe.Origen.NombreHistoria;

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

        private void ListarHeroes()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var command = new SqlCommand();

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_RECUPERARHEROE";
                    command.Connection = connection;

                    connection.Open();

                    using var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var heroe = new Heroe();
                        heroe.Nombre = reader["Nombre"].ToString();
                        heroe.Clase = reader["Clase"].ToString();
                        heroe.Nivel = (int)(reader["Nivel"]);
                        heroe.Origen = RepositorioOrigen.Instancia.RecuperarOrigen(reader["NombreHistoria"].ToString());

                        heroes.Add(heroe);
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
    }
}
