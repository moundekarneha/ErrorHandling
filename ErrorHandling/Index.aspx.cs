using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ErrorHandling
{
    public partial class index : System.Web.UI.Page
    {
        DataSet ds;
        SqlDataAdapter da;
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mcon"].ConnectionString);
            da = new SqlDataAdapter("select * from mydata", conn);
            ds = new DataSet();
            da.Fill(ds,"Emp");
            GridView1.DataSource = ds.Tables["Emp"];
            GridView1.DataBind();

        }
        ////page level error handling
        protected void Page_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            Server.Transfer("demo.aspx");
            Server.ClearError();
        }
    }
}