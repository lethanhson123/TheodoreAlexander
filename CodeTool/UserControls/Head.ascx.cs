using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_Head : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    private string _thongTin001;
    public string ThongTin001
    {
        get { return _thongTin001; }
        set { _thongTin001 = value; }
    }
    private string _thongTin002;
    public string ThongTin002
    {
        get { return _thongTin002; }
        set { _thongTin002 = value; }
    }
    private string _thongTin003;
    public string ThongTin003
    {
        get { return _thongTin003; }
        set { _thongTin003 = value; }
    }
    private string _thongTin004;
    public string ThongTin004
    {
        get { return _thongTin004; }
        set { _thongTin004 = value; }
    }
    private string _thongTin005;
    public string ThongTin005
    {
        get { return _thongTin005; }
        set { _thongTin005 = value; }
    }
}