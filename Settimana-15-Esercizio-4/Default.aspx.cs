using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Settimana_15_Esercizio_4
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager
                .ConnectionStrings["ConnectionAutomobili"]
                .ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            string idAuto = Request.QueryString["idAuto"];
            if (idAuto != null)
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = $"SELECT * FROM Automobili WHERE IdAutomobile={idAuto}";

                    SqlDataReader readerDettagli = cmd.ExecuteReader();
                    dettagliAuto.InnerHtml = "";

                    while (readerDettagli.Read())
                    {
                        dettagliAuto.InnerHtml +=
                            $"<div class=\"d-flex justify-content-center\"><img src=\"{readerDettagli.GetString(4)}\" alt=\"{readerDettagli.GetString(1)} - {readerDettagli.GetString(2)}\" height=\"300px\" width=\"auto\"/></div>";
                        dettagliAuto.InnerHtml +=
                            $"<p class=\"fs-5 text-center m-0\">{readerDettagli.GetString(1)}</p><p class=\"fw-lighter fs-1 text-center mb-2 border-bottom\">{readerDettagli.GetString(2)}</p>";
                        dettagliAuto.InnerHtml +=
                            $"<p id=\"prezzoBase\" runat=\"server\">Prezzo di partenza: €{readerDettagli.GetSqlMoney(3)}</p>";
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }

                optional.Visible = true;
                garazia.Visible = true;
                recapDiv.Visible = true;
            }

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Automobili";

                SqlDataReader reader = cmd.ExecuteReader();
                string ContentListOfCars = "";

                while (reader.Read())
                {
                    ContentListOfCars +=
                        $"<a class=\"list-group-item\" href=\"default?idAuto={reader.GetInt32(0).ToString()}\">{reader.GetString(1)} - {reader.GetString(2)}</a>";
                }

                ListOfCars.InnerHtml = ContentListOfCars;
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Optional";

                SqlDataReader readerOptional = cmd.ExecuteReader();

                string ContentOptional =
                    "<p class=\"display-6\">Seleziona gli optional, puoi selezionarne più di uno</p>\r\n                <div class=\"d-flex flex-wrap\" id=\"optionalCheck\" runat=\"server\"></div>";

                while (readerOptional.Read())
                {
                    ContentOptional +=
                        $"<div class=\"form-check form-check-inline\"><input class=\"form-check-input\" type=\"checkbox\" id=\"{readerOptional.GetString(1)}\" value=\"{readerOptional.GetInt32(0)}\"><label class=\"form-check-label\" for=\"{readerOptional.GetString(1)}\">{readerOptional.GetString(1)}</label></div>";
                }

                optional.InnerHtml = ContentOptional;
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Change(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Response.Redirect($"default?id=\"{btn.CommandArgument}\"");
        }

        protected void Recap_Click(object sender, EventArgs e) { }
    }
}
