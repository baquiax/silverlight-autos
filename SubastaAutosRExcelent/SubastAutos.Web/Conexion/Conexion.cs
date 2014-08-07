using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//MySQL
using System.Data;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace CapaDeDatos{
    public class Conexion{
        private MySqlConnection conexionMySQL;
        private MySqlCommand sentenciasMySQL;
        private static Conexion instancia;
        public static Conexion getInstancia(){
            if (instancia == null){
                instancia = new Conexion();
            }
            return instancia;
        }
        public MySqlConnection getConexion(){
            if (conexionMySQL == null){
                conexionMySQL = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString);
            }
            return conexionMySQL;
        }
        public DataSet hacerConsulta(String consulta){
            DataSet dsResultado = new DataSet();
            try{
                MySqlDataAdapter daResultadoConsulta = new MySqlDataAdapter(consulta, getConexion());
                daResultadoConsulta.Fill(dsResultado, "Consulta");

            }catch (Exception e){
                Console.WriteLine(e.Message);
            }
            return dsResultado;
        }

    }
}