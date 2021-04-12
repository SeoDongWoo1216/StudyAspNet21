using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _210412_ValidationWebApp
{
    public partial class FrmInputValid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.SetFocus(TxtuserId);
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //Response.Write("<script>alert('통과');</script>");
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alertMsg", "<script>alert('통과!');</script>");
            }
        }
    }
}