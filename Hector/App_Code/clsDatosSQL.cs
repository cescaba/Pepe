using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public class clsDatosSQL
{
    private string Connection;
    
    public clsDatosSQL()
    {
        if (ConfigurationManager.ConnectionStrings["conexion"].ConnectionString != String.Empty)
        {
            Connection = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        }
    }

    public DataSet TraerDataSet(string procedimientoAlmacenado, List<SqlParameter> parametros) {
        string StoredProcedure = procedimientoAlmacenado;
        DataSet mDataSet = new DataSet();
 
        //SqlConnection using con = new SqlConnection(Connection);
        // SqlCommand using cmd = new SqlCommand();
        using (SqlConnection con = new SqlConnection(Connection))
        {
              using(SqlCommand cmd = new SqlCommand()){
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                    {
                        foreach (SqlParameter param in parametros)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(mDataSet);
              }
        }

        return mDataSet;
    }

    public DataTable TraerDataTable(string procedimientoAlmacenado, List<SqlParameter> parametros)
    {
        return TraerDataSet(procedimientoAlmacenado, parametros).Tables[0].Copy();
    }

    public void ejecutaNonQuery(string StoredProcedure, List<SqlParameter> parametros) {
        
         using (SqlConnection con = new SqlConnection(Connection))
        {
              using(SqlCommand cmd = new SqlCommand()){
                    cmd.Connection = con;
                cmd.CommandText = StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
 
                if( parametros != null ){
                    foreach(SqlParameter param in parametros){
                        cmd.Parameters.Add(param);
                    }
                }
                con.Open();
                cmd.ExecuteNonQuery();
              }
        }
        

    }

    public SqlParameter RetornarParametro(string NombreParametro, object Valor)
    {
        SqlParameter parametro = new SqlParameter();

        parametro.ParameterName = String.Format("@{0}", NombreParametro);
        parametro.Value = Valor;

        return parametro;
    }

}