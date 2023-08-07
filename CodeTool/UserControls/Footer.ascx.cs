using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_Footer : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialization();
        }
    }
    private void Initialization()
    {
      
    }
    private string _content01;
    public string Content01
    {
        get { return _content01; }
        set { _content01 = value; }
    }
}