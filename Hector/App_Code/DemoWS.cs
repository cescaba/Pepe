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

    [WebMethod]
    public List<Empresa> mostrarEmpresa(int id_distrito, int id_provincia, int id_departamento, int id_pais)
    {
        Empresa d = null;
        List<Empresa> lista_empresa = new List<Empresa>();
        clsDatosSQL oDatos = new clsDatosSQL();
        oListaParametros = new List<SqlParameter>();

        oListaParametros.Add(oDatos.RetornarParametro("dis", id_distrito));
        oListaParametros.Add(oDatos.RetornarParametro("pai", id_pais));
        oListaParametros.Add(oDatos.RetornarParametro("dep", id_departamento));
        oListaParametros.Add(oDatos.RetornarParametro("pro", id_provincia));
        //Si se necesitan traer datos consultados
        oDataTable = oDatos.TraerDataTable("sp_empresa", oListaParametros);
        foreach (DataRow oData in oDataTable.Rows)
        {
            d = new Empresa();
            d.Id_emp = int.Parse(oData["id_emp"].ToString());
            d.Nom_emp = oData["nom_emp"].ToString();
            d.Dir_emp = oData["dir_emp"].ToString();
            d.Img_emp = oData["img_emp"].ToString();
            lista_empresa.Add(d);

        }

        return lista_empresa;
    }

    public class Empresa
    {
        private string nom_emp = "";
        public string Nom_emp
        {
            get { return nom_emp; }
            set { nom_emp = value; }
        }

        private int id_emp;
        public int Id_emp
        {
            get { return id_emp; }
            set { id_emp = value; }
        }

        private string dir_emp = "";
        public string Dir_emp
        {
            get { return dir_emp; }
            set { dir_emp = value; }
        }

        private string img_emp = "";
        public string Img_emp
        {
            get { return img_emp; }
            set { img_emp = value; }
        }
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

    [WebMethod]
    public List<Balon> mostrarBalon(int id_emp, int id_dis)
    {
        Balon d = null;
        List<Balon> lista_balon = new List<Balon>();
        clsDatosSQL oDatos = new clsDatosSQL();
        oListaParametros = new List<SqlParameter>();

        oListaParametros.Add(oDatos.RetornarParametro("id_dis", id_dis));
        oListaParametros.Add(oDatos.RetornarParametro("id_emp", id_emp));

        //Si se necesitan traer datos consultados
        oDataTable = oDatos.TraerDataTable("sp_balon", oListaParametros);
        foreach (DataRow oData in oDataTable.Rows)
        {
            d = new Balon();
            d.Id_emp = int.Parse(oData["id_emp"].ToString());
            d.Id_dist = int.Parse(oData["id_dist"].ToString());
            d.Id_bal = int.Parse(oData["id_bal"].ToString());
            d.Nom_bal = oData["nom_bal"].ToString();
            d.Pre_bal = double.Parse(oData["pre_bal"].ToString());

            lista_balon.Add(d);

        }

        return lista_balon;
    }

    public class Balon
    {
        private int id_bal = 0;
        public int Id_bal
        {
            get { return id_bal; }
            set { id_bal = value; }
        }

        private int id_emp;
        public int Id_emp
        {
            get { return id_emp; }
            set { id_emp = value; }
        }

        private int id_dist;
        public int Id_dist
        {
            get { return id_dist; }
            set { id_dist = value; }
        }

        private string nom_bal = "";
        public string Nom_bal
        {
            get { return nom_bal; }
            set { nom_bal = value; }
        }

        private double pre_bal = 0;
        public double Pre_bal
        {
            get { return pre_bal; }
            set { pre_bal = value; }
        }

        private string des_bal = "";
        public string Des_bal
        {
            get { return des_bal; }
            set { des_bal = value; }
        }
    }

    [WebMethod]
    public void grabarDireccion(string detal_dist, int num_dist, string apa_dist , int id_dis, int id_prov, int id_dep, int id_pai, string ref_dist )
    {
        List<Balon> lista_balon = new List<Balon>();
        clsDatosSQL oDatos = new clsDatosSQL();
        oListaParametros = new List<SqlParameter>();

        oListaParametros.Add(oDatos.RetornarParametro("detal_dist", detal_dist));
        oListaParametros.Add(oDatos.RetornarParametro("num_dist", num_dist));
        oListaParametros.Add(oDatos.RetornarParametro("apa_dist", apa_dist));
        oListaParametros.Add(oDatos.RetornarParametro("id_dis", id_dis));
        oListaParametros.Add(oDatos.RetornarParametro("id_prov", id_prov));
        oListaParametros.Add(oDatos.RetornarParametro("id_dep", id_dep));
        oListaParametros.Add(oDatos.RetornarParametro("id_pai", id_pai));
        oListaParametros.Add(oDatos.RetornarParametro("ref_dist", ref_dist));

        //Si se necesitan traer datos consultados
        oDatos.ejecutaNonQuery("sp_grabar_dir", oListaParametros);
        
        /*foreach (DataRow oData in oDataTable.Rows)
        {
            d = new Balon();
            d.Id_emp = int.Parse(oData["id_emp"].ToString());
            d.Id_dist = int.Parse(oData["id_dist"].ToString());
            d.Id_bal = int.Parse(oData["id_bal"].ToString());
            d.Nom_bal = oData["nom_bal"].ToString();
            d.Pre_bal = double.Parse(oData["pre_bal"].ToString());

            lista_balon.Add(d);

        }*/

    }

    /*public class Pantalla_final
    {
        
        private int id_ped = 0;
        public int Id_ped
        {
            get { return id_ped; }
            set { id_ped = value; }
        }

        private string telf;
        public string Telf
        {
            get { return telf; }
            set { telf = value; }
        }

        private string tiem;
        public string Tiem
        {
            get { return tiem; }
            set { tiem = value; }
        }

    }
   
 }*/


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
