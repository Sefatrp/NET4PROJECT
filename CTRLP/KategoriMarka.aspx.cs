using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class CTRLP_KategoriMarka : System.Web.UI.Page
{
    DataAccessLayer content = new DataAccessLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            KategoriListesi();
            MarkaListesi();
        }
    }
    void KategoriListesi()
    {
        DataTable dt = content.GetDataTable("select * from Kategoriler order by KategoriAdi");
        ddlKategori.DataTextField = "KategoriAdi";
        ddlKategori.DataValueField = "KategoriID";
        ddlKategori.DataSource = dt;
        ddlKategori.DataBind();
    }
    /*
      select * from Markalar
where markaId not in
(select markaId from KategoriMarka where KategoriId=2)
     */

    void MarkaListesi()
    {
        List<Parametreler> pler = new List<Parametreler>();
        pler.Add(
            new Parametreler { IDName = "@id", Value = ddlKategori.SelectedValue }
            );
        DataTable dt = content.GetDataTable("select * from Markalar where markaId not in (select markaId from KategoriMarka where KategoriId=@id)",pler);
        ddlMarka.DataTextField = "MarkaAdi";
        ddlMarka.DataValueField = "MarkaID";
        ddlMarka.DataSource = dt;
        ddlMarka.DataBind();
    }
    protected void ddlKategori_SelectedIndexChanged(object sender, EventArgs e)
    {
        MarkaListesi();
    }
    protected void btnEslestir_Click(object sender, EventArgs e)
    {
        SqlCommand insert = new SqlCommand("insert KategoriMarka values(@kategoriId,@markaId)");
        List<Parametreler> pler = new List<Parametreler>();
        pler.Add(
            new Parametreler { IDName = "@kategoriId", Value = ddlKategori.SelectedValue }
            );
        pler.Add(
            new Parametreler { IDName = "@markaId", Value = ddlMarka.SelectedValue }
            );
        content.AddParametersToCommand(insert, pler);
        content.RunASqlStatementWithParameters(insert);

        KategoriListesi();
        MarkaListesi();
    }
}