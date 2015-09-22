﻿using KeysightMOR.Assets;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KeysightMOR
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();

            }
        }

        private void LoadData()
        {
            // lblCurrentMonth.Text = DateTime.Now.ToString("MMMM");
            // Label2.Text = DateTime.Now.AddMonths(-1).ToString("MMMM");

            Session["MonthNow"] = DateTime.Now.Month.ToString();
            Session["MonthPrevious"] = DateTime.Now.AddMonths(-1).ToString();
            Session["YearNow"] = DateTime.Now.Year.ToString();

            sqlEvalTableFetchData.ConnectionString = "KeysightMORDB";
            sqlEvalTableFetchData.SelectCommand = "";
        }

        private void FetchDb()
        {
            using (SqlConnection conn = new SqlConnection(Shared.SqlConnString))
            {
                try
                {
                    conn.Open();
                }
                catch(Exception ex)
                {
                    Response.Write(ex.ToString());
                }
            }
        }
    }
}