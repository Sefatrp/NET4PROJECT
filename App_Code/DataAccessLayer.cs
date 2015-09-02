using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataAccessLayer
/// </summary>
public class DataAccessLayer
{
    //sürekli yapılacak işlemlerin saklanacağı bölge.

    public DataAccessLayer()
    {

    }

    public SqlConnection Connect()
    {
        SqlConnection con = new SqlConnection("server=.; database=toolshop; integrated security=sspi");
        con.Open();
        return con;
    }
    public SqlConnection Connect(string dbName)
    {
        SqlConnection con = new SqlConnection(string.Format("server=.; database={0}; integrated security=sspi", dbName));
        con.Open();
        return con;
    }

    //executenonquery için
    public int RunASqlStatement(string stament)
    {
        SqlConnection con = Connect();
        SqlCommand command = new SqlCommand(stament, con);
        int result = command.ExecuteNonQuery();
        return result;
    }

    public int RunASqlStatement(string stament, string dbName)
    {
        SqlConnection con = Connect(dbName);
        SqlCommand command = new SqlCommand(stament, con);
        int result = command.ExecuteNonQuery();
        return result;
    }

    //eğer sql komutları parametreler içeriyorsa buna uygun br yapı belirlenmelidir.

    public void AddParametersToCommand(SqlCommand command, List<Parametreler> parameters)
    {
        foreach (var item in parameters)
        {
            command.Parameters.Add(item.IDName, item.Type).Value = item.Value;
        }
    }

    public void AddParametersToCommandWithValue(SqlCommand command, List<Parametreler> parameters)
    {
        foreach (var item in parameters)
        {
            command.Parameters.AddWithValue(item.IDName, item.Value);
        }
    }

    public int RunASqlStatementWithParameters(SqlCommand command)
    {
        SqlConnection con = Connect();
        command.Connection = con;
        int result = command.ExecuteNonQuery();
        con.Close();
        return result;
    }

    //veri çekmek istiyorum

    public DataTable GetDataTable(string statement)
    {
        SqlConnection con = Connect();
        SqlDataAdapter adaptor = new SqlDataAdapter(statement, con);
        DataTable dt = new DataTable();
        adaptor.Fill(dt);
        con.Close();
        return dt;
    }


    //eğer bilgi çekerken bir takım parametreler kullanıyorsak
    public DataTable GetDataTable(string statement, List<Parametreler> parameters)
    {
        DataTable dt = new DataTable();
        SqlConnection con = Connect();
        SqlCommand command = new SqlCommand(statement, con);
        AddParametersToCommand(command, parameters);
        SqlDataAdapter adaptor = new SqlDataAdapter(command);
        adaptor.Fill(dt);
        return dt;
    }
    //Belirli Bir ID değerine göre bilgi istenirse
    public DataRow GetDataRow(string statement)
    {
        DataTable dt = GetDataTable(statement);
        if (dt.Rows.Count != 0)//dt boş değilse
        {
            return dt.Rows[0];
        }
        else
            return null;//sorgu sonucunda bir resultset yoksa null dönüş olur.
    }
    //parametreli versiyon
    public DataRow GetDataRow(string statement, List<Parametreler> parameters)
    {
        DataTable dt = GetDataTable(statement, parameters);
        if (dt.Rows.Count != 0)//dt boş değilse
        {
            return dt.Rows[0];
        }
        else
            return null;
    }


    //scalar veri getirmek
    public string GetAScalarValue(string statement)
    {
        DataTable dt = GetDataTable(statement);
        if (dt.Rows.Count == 0)
        {
            return null;
        }
        else
            return dt.Rows[0][0].ToString(); ;
    }

    public string GetAScalarValue(string statement, List<Parametreler> parameters)
    {
        DataTable dt = GetDataTable(statement, parameters);
        if (dt.Rows.Count == 0)
        {
            return null;
        }
        else
            return dt.Rows[0][0].ToString(); ;
    }

    public string ToCurrency(string input)
    {
        input = input.Replace(".", ",");
        return input;
    }

    public string ClearText(string input)
    {
        input = input.Trim('-', '\'', '.', ',', '?', '<', '>', '=', ';');
        return input;
    }

}
public class Parametreler
{
    public string IDName { get; set; }//gelen parametrenin adını saklayacak
    public object Value { get; set; }//parametrelerin taşıyacakları veri
    public SqlDbType? Type { get; set; }//AddWithParameters dediğimizde SqlDbType vermiyorduk ancak Parameters nesnesi oluşturunca SqlDbType bilgisi isteniyordu. Nullable olunca verinin türüne yönelik bir bilgi istenirse eklenebilir.

    public Parametreler()
    {
        IDName = null;
        Value = null;
        Type = null;
    }
}