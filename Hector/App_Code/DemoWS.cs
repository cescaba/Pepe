using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for DemoWS
/// </summary>
[WebService(Namespace = "http://demo.suma.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class DemoWS : System.Web.Services.WebService {

    public DemoWS () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //clsDatosSQL oDatos; //llamado a la clase
    List<SqlParameter> oListaParametros;
    DataSet oDataSet;
    DataTable oDataTable;
    Boolean logExiste;

    protected void Button1_Click(object sender, EventArgs e)
    {
        /*
        string Login = String.Empty;

        string Nrodocumento = String.Empty;

        string usuario = "";
        string contraseña = "";

        usuario = txtusuario.Text;
        contraseña = txtcontraseña.Text;
        clsDatosSQL oDatos = new clsDatosSQL();
        oListaParametros = new List<SqlParameter>();

        oListaParametros.Add(oDatos.RetornarParametro("user", txtusuario.Text));
        oListaParametros.Add(oDatos.RetornarParametro("password", txtcontraseña.Text));

        //Si se necesitan traer datos consultados
        oDataTable = oDatos.TraerDataTable("usr_login", oListaParametros);

        foreach (DataRow oData in oDataTable.Rows)
        {
            Login = oData["nom_cli"].ToString() + " " + oData["ape_clie"].ToString();
            logExiste = true;
        }

        if (logExiste)
        {
            Session["x"] = new Cliente(Login);
            Server.Transfer("~/index.aspx");

        }
        else
        {
            //lblError.Visible = true;
            txtusuario.Focus();
        }
        */
    }

   [WebMethod]
    public Cliente iniciarSesion(string usuario, string contraseña)
    {
       Cliente c = null;
        clsDatosSQL oDatos = new clsDatosSQL();
        oListaParametros = new List<SqlParameter>();

        oListaParametros.Add(oDatos.RetornarParametro("user", usuario));
        oListaParametros.Add(oDatos.RetornarParametro("password", contraseña));
        //Si se necesitan traer datos consultados
        oDataTable = oDatos.TraerDataTable("usr_login", oListaParametros);
        foreach (DataRow oData in oDataTable.Rows)
        {
           c = new Cliente();
           c.Nombre = oData["nom_cli"].ToString() + " " + oData["ape_clie"].ToString();
        }

    
       return c;
    }

    public class Cliente{
       private string nombre="";
       public string Nombre{
            get{return nombre;}
            set{nombre = value;}
        }
       
    }

    [WebMethod]
    public List<Distrito> mostrarDistrito(int id_provincia, int id_departamento, int id_pais)
    {
        Distrito d = null;
        List<Distrito> lista_distri = new List<Distrito>();
        clsDatosSQL oDatos = new clsDatosSQL();
        oListaParametros = new List<SqlParameter>();

        oListaParametros.Add(oDatos.RetornarParametro("pai", id_pais));
        oListaParametros.Add(oDatos.RetornarParametro("dep", id_departamento));
        oListaParametros.Add(oDatos.RetornarParametro("prov", id_provincia));
        //Si se necesitan traer datos consultados
        oDataTable = oDatos.TraerDataTable("sp_distrito", oListaParametros);
        foreach (DataRow oData in oDataTable.Rows)
        {
            d = new Distrito();
            d.Nom_dis = oData["nom_dis"].ToString();
            d.Id_dis = int.Parse(oData["id_dis"].ToString());
            d.Id_prov = id_provincia;
            d.Id_dep = id_departamento;
            d.Id_pai = id_pais;
            lista_distri.Add(d);

        }

        return lista_distri;
    }

    public class Distrito
    {
        private string nom_dis = "";
        public string Nom_dis
        {get { return nom_dis; }
         set { nom_dis = value; }}

        private int id_dis;
        public int Id_dis
        {get { return id_dis; }
         set { id_dis = value; }}

        private int id_prov;
        public int Id_prov
        {
            get { return id_prov; }
            set { id_prov = value; }
        }

        private int id_dep;
        public int Id_dep
        {
            get { return id_dep; }
            set { id_dep = value; }
        }

        private int id_pai;
        public int Id_pai
        {get { return id_pai; }
         set { id_pai = value; }}
    }

    //public Category GetCategoryById(Category C);
    [WebMethod]
    public Matematica ejercicios(int num1, int num2)
    {
        Matematica Ma = new Matematica();
        
        //int numero1 = M.Num1;
        //int numero2 = M.Num2;
        int suma = num1 + num2;
        int resta = num1 - num2;
        int mult = num1 * num2;
        double div = num1 / num2;

        Ma.Num1 = num1;
        Ma.Num2 = num2;
        Ma.Suma = ""+suma;
        Ma.Resta = ""+resta;
        Ma.Multiplicacion = ""+mult;
        Ma.Division = ""+div;
        
        //int num1 = M.Num1();
        
        return Ma;
    }


    public class Matematica
    {

        private int num1;
        public int Num1
        {
            get
            {
                return num1;
            }
            set
            {
                num1 = value;
            }
        }

        private int num2;
        public int Num2
        {
            get
            {
                return num2;
            }
            set
            {
                num2 = value;
            }
        }

        private string suma;
        public string Suma
        {
            get
            {
                return suma;
            }
            set
            {
                suma = value;
            }
        }

        private string resta;
        public string Resta
        {
            get
            {
                return resta;
            }
            set
            {
                resta = value;
            }
        }

        private string multiplicacion;
        public string Multiplicacion
        {
            get
            {
                return multiplicacion;
            }
            set
            {
                multiplicacion = value;
            }
        }

        private string division;
        public string Division
        {
            get
            {
                return division;
            }
            set
            {
                division = value;
            }

        }
    }
    
}
