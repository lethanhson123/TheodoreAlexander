using System;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using CodeTool.Business;
using Ionic.Zip;


public partial class _Default : Page
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
        txtConnectionString.Text = @"Persist Security Info=True;User ID=sa;Password=Passw0rd4WEB;database=TheodoreAlexander_New;data source=172.18.0.25";
        txtNameSpace.Text = "TA";
    }
    protected void btnCreateCode_OnClick(object sender, EventArgs e)
    {
        string connectionString = txtConnectionString.Text.Trim();
        string nameClass = txtNameClass.Text;
        string nameSpace = txtNameSpace.Text;
        string initialCatalog = txtInitialCatalog.Text;
        CodeTool.Business.CodeGeneration codeGeneration = new CodeGeneration(connectionString);
        DataTable dt = codeGeneration.GetTableItem(ddlTable.Text);
        string folderName = HttpContext.Current.Server.MapPath("~/") + @"Download\";
        string pathString = System.IO.Path.Combine(folderName, nameClass);
        System.IO.Directory.CreateDirectory(pathString);

        StringBuilder sb001 = new CodeTool.Business.CodeGeneration().GenerateModelFile(nameClass, nameSpace, dt);        
        StreamWriter sw001 = File.CreateText(HttpContext.Current.Server.MapPath("~/") + @"Download\" + nameClass + @"\" + nameClass + ".cs");
        sw001.WriteLine(sb001);
        sw001.Close();

        StringBuilder sb002 = new CodeTool.Business.CodeGeneration().GenerateRepositoryFile(nameClass, nameSpace, initialCatalog);
        StreamWriter sw002 = File.CreateText(HttpContext.Current.Server.MapPath("~/") + @"Download\" + nameClass + @"\" + nameClass + "Repository.cs");
        sw002.WriteLine(sb002);
        sw002.Close();

        StringBuilder sb003 = new CodeTool.Business.CodeGeneration().GenerateIRepositoryFile(nameClass, nameSpace);
        StreamWriter sw003 = File.CreateText(HttpContext.Current.Server.MapPath("~/") + @"Download\" + nameClass + @"\I" + nameClass + "Repository.cs");
        sw003.WriteLine(sb003);
        sw003.Close();

        StringBuilder sb004 = new CodeTool.Business.CodeGeneration().GenerateControllerFile(nameClass, nameSpace);
        StreamWriter sw004 = File.CreateText(HttpContext.Current.Server.MapPath("~/") + @"Download\" + nameClass + @"\" + nameClass + "Controller.cs");
        sw004.WriteLine(sb004);
        sw004.Close();

        StringBuilder sb005 = new CodeTool.Business.CodeGeneration().GenerateModelTypescriptFile(nameClass, dt);
        StreamWriter sw005 = File.CreateText(HttpContext.Current.Server.MapPath("~/") + @"Download\" + nameClass + @"\" + nameClass + ".model.ts");
        sw005.WriteLine(sb005);
        sw005.Close();

        StringBuilder sb006 = new CodeTool.Business.CodeGeneration().GenerateServiceTypescriptFile(nameClass);
        StreamWriter sw006 = File.CreateText(HttpContext.Current.Server.MapPath("~/") + @"Download\" + nameClass + @"\" + nameClass + ".service.ts");
        sw006.WriteLine(sb006);
        sw006.Close();

        DownloadForder(nameClass);
    }

    public void DownloadFile(string fileName)
    {
        string strURL = "Download/" + fileName;
        WebClient req = new WebClient();
        HttpResponse response = HttpContext.Current.Response;
        response.Clear();
        response.ClearContent();
        response.ClearHeaders();
        response.Buffer = true;
        response.AddHeader("Content-Disposition", "attachment;filename=\"" + fileName + "\"");
        byte[] data = req.DownloadData(Server.MapPath(strURL));
        response.BinaryWrite(data);
        response.End();
    }

    public void DownloadForder(string forderName)
    {
        using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
        {
            zip.AlternateEncodingUsage = ZipOption.AsNecessary;
            zip.AddDirectoryByName(forderName);
            string filePaths = HttpContext.Current.Server.MapPath("~/Download/") + forderName + @"\";
            string[] fileEntries = Directory.GetFiles(filePaths);
            foreach (string fileName in fileEntries)
                zip.AddFile(fileName, forderName);
            Response.Clear();
            Response.BufferOutput = false;
            string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition", "attachment; filename=" + forderName + ".zip");
            zip.Save(Response.OutputStream);
            Response.End();
        }
    }

    public void Download001(string forderName)
    {
        string BackupAddressInput = HttpContext.Current.Server.MapPath("~/Download/") + forderName;
        string fileName = forderName + ".zip";
        string BackupAddressOutputDefault = HttpContext.Current.Server.MapPath("~/Download/") + fileName;
        lbl.Text = BackupAddressInput + ";" + BackupAddressOutputDefault;
        System.IO.Compression.ZipFile.CreateFromDirectory(BackupAddressInput, BackupAddressOutputDefault, CompressionLevel.Fastest, true);
    }
    protected void tbnGetTable_OnClick(object sender, EventArgs e)
    {
        string connectionString = txtConnectionString.Text.Trim();
        ddlTable.DataSource = CodeTool.Business.CodeGeneration.GetTableNames(connectionString);
        ddlTable.DataValueField = "name";
        ddlTable.DataTextField = "name";
        ddlTable.DataBind();
        ddlTable_OnSelectedIndexChanged_(null, null);

        txtInitialCatalog.Text= CodeTool.Business.CodeGeneration.GetInitialCatalog(connectionString); 
    }

    protected void ddlTable_OnSelectedIndexChanged_(object sender, EventArgs e)
    {
        string tableName = ddlTable.Text;
        txtNameClass.Text = tableName;
        string connectionString = txtConnectionString.Text.Trim();
        CodeTool.Business.CodeGeneration codeGeneration = new CodeGeneration(connectionString);
        ddlKey.DataSource = codeGeneration.GetTableItem(tableName);
        ddlKey.DataValueField = "COLUMN_NAME";
        ddlKey.DataTextField = "COLUMN_NAME";
        ddlKey.DataBind();
    }
}