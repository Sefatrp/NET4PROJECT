using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class CTRLP_KategoriEkle : System.Web.UI.Page
{
    DataAccessLayer content = new DataAccessLayer();

    protected void Page_Load(object sender, EventArgs e)
    {
        KategoriListesi();
    }
    
    protected void btnEkle_Click(object sender, EventArgs e)
    {
        List<Parametreler> pler = new List<Parametreler>();
        pler.Add(
            new Parametreler { IDName = "@name", Value = txtKategori.Text });

        SqlCommand insert = new SqlCommand("insert Kategoriler values(@name)");

        content.AddParametersToCommand(insert, pler);
        content.RunASqlStatementWithParameters(insert);

        txtKategori.Text = "";
        txtKategori.Focus();
        KategoriListesi();
    }

    void KategoriListesi()
    {
        DataTable dt = content.GetDataTable("select * from Kategoriler order by KategoriAdi");
        ddlKategori.DataTextField = "KategoriAdi";
        ddlKategori.DataValueField = "KategoriID";
        ddlKategori.DataSource = dt;
        ddlKategori.DataBind();
    }
}