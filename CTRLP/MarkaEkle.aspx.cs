using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class CTRLP_MarkaEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        MarkaListesi();
    }
    DataAccessLayer content = new DataAccessLayer();
    protected void btnEkle_Click(object sender, EventArgs e)
    {
        List<Parametreler> pler = new List<Parametreler>();
        pler.Add(
            new Parametreler { IDName = "@name", Value = txtMarka.Text });

        SqlCommand insert = new SqlCommand("insert Markalar values(@name)");

        content.AddParametersToCommand(insert, pler);
        content.RunASqlStatementWithParameters(insert);

        txtMarka.Text = "";
        txtMarka.Focus();
        MarkaListesi();
    }
    void MarkaListesi()
    {
        DataTable dt = content.GetDataTable("select * from Markalar order by MarkaAdi");
        ddlMarka.DataTextField = "MarkaAdi";
        ddlMarka.DataValueField = "MarkaID";
        ddlMarka.DataSource = dt;
        ddlMarka.DataBind();
    }
}