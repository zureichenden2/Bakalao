using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;
using Common.Cache;

namespace DataAccess
{
    public class UserDao: ConnectionToSQL
    {

        public bool Login (string user, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select persona.id, persona.nombre, persona.apellidoPaterno, " +
                    " persona.apellidoMaterno, persona.usuario, persona.contraseña, " +
                    " persona.numeroCelular, persona.direccion, cargo_persona.cargo, cargo_persona.fk_departamento From persona " +
                    " Inner Join cargo_persona On cargo_persona.fk_persona = persona.id  where persona.usuario=@user and persona.contraseña=@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserLoginCache.id = reader.GetInt32(0);
                            UserLoginCache.Nombres = reader.GetString(1);
                            UserLoginCache.ApellidoPaterno = reader.GetString(2);
                            UserLoginCache.ApellidoMaterno = reader.GetString(3);
                            UserLoginCache.Usuario = reader.GetString(4);
                            UserLoginCache.Contraseña = reader.GetString(5);
                            UserLoginCache.NumeroCelular = reader.GetString(6);
                            UserLoginCache.Direccion = reader.GetString(7);
                            UserLoginCache.Cargo = reader.GetString(8);

                            if (reader.IsDBNull(9))
                            {
                                UserLoginCache.departamento = 0;
                            }

                            else
                            {
                                UserLoginCache.departamento = reader.GetInt32(9);

                            }
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

    }




}
