using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace ModuloCompras.Repositories.BD
{
    public abstract class MySqlRepository<T> where T : class
    {
        private static MySqlConnection _conn;

        public MySqlRepository(IConfiguration config)
        {
            _conn = new MySqlConnection(config.GetConnectionString("ConexaoPadrao"));
        }

        public virtual T PopularDados(MySqlDataReader dr)
        {
            return null;
        }

        protected IEnumerable<T> ObterRegistros(MySqlCommand cmd)
        {
            var lista = new List<T>();
            cmd.Connection = _conn;
            _conn.Open();
            try
            {
                var dr = cmd.ExecuteReader();
                try
                {
                    while (dr.Read())
                        lista.Add(PopularDados(dr));
                }
                finally
                {
                    dr.Close();
                }
            }
            finally
            {
                _conn.Close();
            }
            return lista;
        }

        protected T ObterRegistro(MySqlCommand cmd)
        {
            T registro = null;
            cmd.Connection = _conn;
            _conn.Open();
            try
            {
                var dr = cmd.ExecuteReader();
                try
                {
                    if (dr.Read())
                        registro = PopularDados(dr);
                }
                finally
                {
                    dr.Close();
                }
            }
            finally
            {
                _conn.Close();
            }
            return registro;
        }

        protected int ObterLastID(MySqlCommand cmd)
        {
            var id = 0;
            cmd.Connection = _conn;
            _conn.Open();
            try
            {
                id = Convert.ToInt32(cmd.ExecuteScalar());                       
            }
            finally
            {
                _conn.Close();
            }
            return id;
        }

        protected void ExecutarComando(MySqlCommand cmd)
        {
            cmd.Connection = _conn;
            cmd.CommandType = CommandType.Text;
            _conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
