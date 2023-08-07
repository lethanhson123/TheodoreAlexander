using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;

using CodeTool.DataAccess;

namespace CodeTool.Business
{
    public class CodeGeneration
    {
        CodeTool.DataAccess.CodeGenerationDB codeGenerationDB = new CodeGenerationDB();


        public CodeGeneration(string connectionString)
        {
            codeGenerationDB.ConnectionString = connectionString;
        }

        public CodeGeneration()
        {
        }
        public static string GetInitialCatalog(string connectionString)
        {
            return CodeGenerationDB.GetInitialCatalog(connectionString);
        }
        public static DataTable GetTableNames(string connectionString)
        {
            return CodeGenerationDB.GetTableNames(connectionString);
        }


        public DataTable GetTableItem(string tableName)
        {
            return codeGenerationDB.GetTableItems(tableName);
        }

        private string KeyType(string key, string tableName)
        {
            string keyType = "";
            DataTable dataTable = codeGenerationDB.GetTableItems(tableName);
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["COLUMN_NAME"].ToString() == key)
                {
                    keyType = row["DATA_TYPE"].ToString();
                }
            }

            return Convert(keyType);
        }

        private string Convert(string sqlDataType)
        {
            switch (sqlDataType)
            {
                case "char":
                case "nchar":
                case "ntext":
                case "text":
                case "varchar":
                case "nvarchar":
                    return "string";
                case "bit":
                    return "bool";
                case "int":
                case "smallint":
                case "tinyint":
                case "bigint":
                    return "int";
                case "datetime":
                case "smalldatetime":
                case "timestamp":
                    return "DateTime";
                case "real":
                    return "double";
                case "money":
                case "smallmoney":
                case "decimal":
                    return "decimal";
                case "float":
                    return "float";
                case "uniqueidentifier":
                    return "Guid";
                default: return "string";
            }
        }
        private string ConvertToTypescript(string sqlDataType)
        {
            switch (sqlDataType)
            {
                case "char":
                case "nchar":
                case "ntext":
                case "text":
                case "varchar":
                case "nvarchar":
                case "uniqueidentifier":
                    return "string";
                case "bit":
                    return "boolean";
                case "int":
                case "smallint":
                case "tinyint":
                case "bigint":
                case "real":
                case "money":
                case "smallmoney":
                case "decimal":
                case "float":
                    return "number";
                case "datetime":
                case "smalldatetime":
                case "timestamp":
                    return "Date";
                default: return "string";
            }
        }

        private string ConvertType(string sqlDataType)
        {
            switch (sqlDataType)
            {
                case "char":
                case "nchar":
                case "ntext":
                case "text":
                case "varchar":
                case "nvarchar":
                    return "InitializationString";
                case "bit":
                    return "InitializationBoolean";
                case "int":
                case "smallint":
                case "tinyint":
                case "bigint":
                    return "InitializationInt";
                case "datetime":
                case "smalldatetime":
                case "timestamp":
                    return "InitializationDateTime";
                case "real":
                    return "InitializationInt";
                case "money":
                case "smallmoney":
                case "decimal":
                    return "InitializationInt";
                case "float":
                    return "InitializationInt";
                case "uniqueidentifier":
                    return "Guid";
                default: return "InitializationString";
            }

        }

        private string ConvertToSqlDBType(string sqlDataType)
        {
            switch (sqlDataType)
            {
                case "nchar":
                    return "NChar";
                case "nvarchar":
                    return "NVarChar";
                case "varchar":
                    return "VarChar";
                case "ntext":
                    return "NText";
                case "text":
                    return "Text";
                case "money":
                    return "Money";
                case "bit":
                    return "Bit";
                case "int":
                    return "Int";
                case "real":
                    return "Real";
                case "float":
                    return "Float";
                case "datetime":
                    return "DateTime";
                case "uniqueidentifier":
                    return "UniqueIdentifier";
                case "decimal":
                    return "Decimal";
                default: return "NChar";
            }
        }

        private string ConvertGenerateBusinessConstrutors(string dataType)
        {
            switch (dataType)
            {
                case "string":
                    return @"""""";
                case "DateTime":
                    return "DateTime.Now";
                case "bool":
                    return "true";
                default: return "0";
            }
        }

        public StringBuilder GenerateModelFile(string nameClass, string nameSpace, DataTable dataTable)
        {
            StringBuilder modelString = new StringBuilder();
            modelString.AppendLine("using System;");
            modelString.AppendLine("namespace " + nameSpace + ".Data.Models");
            modelString.AppendLine("{");
            modelString.AppendLine("public partial class " + nameClass + ": BaseModel");
            modelString.AppendLine("{");
            foreach (DataRow row in dataTable.Rows)
            {
                string type = Convert(row["DATA_TYPE"].ToString());
                string columnName = row["COLUMN_NAME"].ToString();
                if (type.Contains("string"))
                {
                    modelString.AppendLine("public " + type + " " + columnName + " { get; set; }");
                }
                else
                {
                    modelString.AppendLine("public " + type + "? " + columnName + " { get; set; }");
                }
            }
            modelString.AppendLine("}");
            modelString.AppendLine("}");
            return modelString;
        }
        public StringBuilder GenerateControllerFile(string nameClass, string nameSpace)
        {
            string nameClassLowercase = nameClass.Substring(0, 1).ToLower() + nameClass.Substring(1, nameClass.Length - 1);
            StringBuilder modelString = new StringBuilder();
            modelString.AppendLine("using Microsoft.AspNetCore.Mvc;");
            modelString.AppendLine("using System.Collections.Generic;");
            modelString.AppendLine("using System.Threading.Tasks;");
            modelString.AppendLine("using " + nameSpace + ".Data.Models;");
            modelString.AppendLine("using " + nameSpace + ".Data.Repositories;");
            modelString.AppendLine("namespace " + nameSpace + ".API.Controllers");
            modelString.AppendLine("{");
            modelString.AppendLine("public class " + nameClass + "Controller: BaseController");
            modelString.AppendLine("{");
            modelString.AppendLine("private readonly I" + nameClass + "Repository _" + nameClassLowercase + "Repository;");
            modelString.AppendLine("public " + nameClass + "Controller(I" + nameClass + "Repository " + nameClassLowercase + "Repository) : base()");
            modelString.AppendLine("{");
            modelString.AppendLine("_" + nameClassLowercase + "Repository = " + nameClassLowercase + "Repository;");
            modelString.AppendLine("}");
            modelString.AppendLine("[HttpPost]");
            modelString.AppendLine("public int Add(" + nameClass + " " + nameClassLowercase + ")");
            modelString.AppendLine("{");
            modelString.AppendLine("var result = _" + nameClassLowercase + "Repository.Add(" + nameClassLowercase + ");");
            modelString.AppendLine(" return result;");
            modelString.AppendLine("}");
            modelString.AppendLine("[HttpPost]");
            modelString.AppendLine("public async Task<int> AsyncAdd(" + nameClass + " " + nameClassLowercase + ")");
            modelString.AppendLine("{");
            modelString.AppendLine("var result = await _" + nameClassLowercase + "Repository.AsyncAdd(" + nameClassLowercase + ");");
            modelString.AppendLine(" return result;");
            modelString.AppendLine("}");
            modelString.AppendLine("[HttpPost]");
            modelString.AppendLine("public int AddRange(List<" + nameClass + "> list)");
            modelString.AppendLine("{");
            modelString.AppendLine("var result = _" + nameClassLowercase + "Repository.AddRange(list);");
            modelString.AppendLine(" return result;");
            modelString.AppendLine("}");
            modelString.AppendLine("[HttpPost]");
            modelString.AppendLine("public async Task<int> AsyncAddRange(List<" + nameClass + "> list)");
            modelString.AppendLine("{");
            modelString.AppendLine("var result = await _" + nameClassLowercase + "Repository.AsyncAddRange(list);");
            modelString.AppendLine(" return result;");
            modelString.AppendLine("}");
            modelString.AppendLine("[HttpPut]");
            modelString.AppendLine("public int Update(" + nameClass + " " + nameClassLowercase + ")");
            modelString.AppendLine("{");
            modelString.AppendLine("var result = _" + nameClassLowercase + "Repository.Update(" + nameClassLowercase + ");");
            modelString.AppendLine(" return result;");
            modelString.AppendLine("}");
            modelString.AppendLine("[HttpPut]");
            modelString.AppendLine("public async Task<int> AsyncUpdate(" + nameClass + " " + nameClassLowercase + ")");
            modelString.AppendLine("{");
            modelString.AppendLine("var result = await _" + nameClassLowercase + "Repository.AsyncUpdate(" + nameClassLowercase + ");");
            modelString.AppendLine(" return result;");
            modelString.AppendLine("}");
            modelString.AppendLine("[HttpDelete]");
            modelString.AppendLine("public int RemoveRange(List<" + nameClass + "> list)");
            modelString.AppendLine("{");
            modelString.AppendLine("var result = _" + nameClassLowercase + "Repository.RemoveRange(list);");
            modelString.AppendLine(" return result;");
            modelString.AppendLine("}");
            modelString.AppendLine("[HttpDelete]");
            modelString.AppendLine("public async Task<int> AsyncRemoveRange(List<" + nameClass + "> list)");
            modelString.AppendLine("{");
            modelString.AppendLine("var result = await _" + nameClassLowercase + "Repository.AsyncRemoveRange(list);");
            modelString.AppendLine(" return result;");
            modelString.AppendLine("}");
            modelString.AppendLine("[HttpGet]");
            modelString.AppendLine("public List<" + nameClass + "> GetAllToList()");
            modelString.AppendLine("{");
            modelString.AppendLine("var result = _" + nameClassLowercase + "Repository.GetAllToList();");
            modelString.AppendLine(" return result;");
            modelString.AppendLine("}");
            modelString.AppendLine("[HttpGet]");
            modelString.AppendLine("public async Task<List<" + nameClass + ">> AsyncGetAllToList()");
            modelString.AppendLine("{");
            modelString.AppendLine("var result = await _" + nameClassLowercase + "Repository.AsyncGetAllToList();");
            modelString.AppendLine(" return result;");
            modelString.AppendLine("}");
            modelString.AppendLine("[HttpGet]");
            modelString.AppendLine("public List<" + nameClass + "> GetByPageAndPageSizeToList(int page, int pageSize)");
            modelString.AppendLine("{");
            modelString.AppendLine("var result = _" + nameClassLowercase + "Repository.GetByPageAndPageSizeToList(page,pageSize);");
            modelString.AppendLine(" return result;");
            modelString.AppendLine("}");
            modelString.AppendLine("[HttpGet]");
            modelString.AppendLine("public async Task<List<" + nameClass + ">> AsyncGetByPageAndPageSizeToList(int page, int pageSize)");
            modelString.AppendLine("{");
            modelString.AppendLine("var result = await _" + nameClassLowercase + "Repository.AsyncGetByPageAndPageSizeToList(page,pageSize);");
            modelString.AppendLine(" return result;");
            modelString.AppendLine("}");
            modelString.AppendLine("}");
            modelString.AppendLine("}");
            return modelString;
        }
        public StringBuilder GenerateModelTypescriptFile(string nameClass, DataTable dataTable)
        {
            StringBuilder modelString = new StringBuilder();
            modelString.AppendLine("export class " + nameClass + " {");
            foreach (DataRow row in dataTable.Rows)
            {
                string type = ConvertToTypescript(row["DATA_TYPE"].ToString());
                modelString.AppendLine(row["COLUMN_NAME"].ToString() + "?: " + type + ";");
            }
            modelString.AppendLine("}");
            return modelString;
        }

        public StringBuilder GenerateServiceTypescriptFile(string nameClass)
        {
            StringBuilder modelString = new StringBuilder();
            modelString.AppendLine("import { Injectable } from '@angular/core';");
            modelString.AppendLine("import { HttpClient, HttpParams } from '@angular/common/http';");
            modelString.AppendLine("import { environment } from 'src/environments/environment';");
            modelString.AppendLine("import { " + nameClass + " } from 'src/app/shared/" + nameClass + ".model';");
            modelString.AppendLine("@Injectable({");
            modelString.AppendLine("providedIn: 'root'");
            modelString.AppendLine("})");
            modelString.AppendLine("export class " + nameClass + "Service {");
            modelString.AppendLine("list: " + nameClass + "[];");
            modelString.AppendLine("formData: " + nameClass + ";");
            modelString.AppendLine("aPIURL: string = environment.APIURL;");
            modelString.AppendLine(@"controller: string = """ + nameClass + @""";");
            modelString.AppendLine("constructor(private httpClient: HttpClient) {");
            modelString.AppendLine("this.initializationFormData();");
            modelString.AppendLine("}");
            modelString.AppendLine("initializationFormData() {");
            modelString.AppendLine("this.formData = {");
            modelString.AppendLine("}");
            modelString.AppendLine("}");
            modelString.AppendLine("add(formData: " + nameClass + ") {");
            modelString.AppendLine("let url = this.aPIURL + this.controller + '/Add';");
            modelString.AppendLine("return this.httpClient.post(url, formData);");
            modelString.AppendLine("}");
            modelString.AppendLine("asyncAdd(formData: " + nameClass + ") {");
            modelString.AppendLine("let url = this.aPIURL + this.controller + '/AsyncAdd';");
            modelString.AppendLine("return this.httpClient.post(url, formData);");
            modelString.AppendLine("}");
            modelString.AppendLine("addRange(list: " + nameClass + "[]) {");
            modelString.AppendLine("let url = this.aPIURL + this.controller + '/AddRange';");
            modelString.AppendLine("return this.httpClient.post(url, list);");
            modelString.AppendLine("}");
            modelString.AppendLine("asyncAddRange(list: " + nameClass + "[]) {");
            modelString.AppendLine("let url = this.aPIURL + this.controller + '/AsyncAddRange';");
            modelString.AppendLine("return this.httpClient.post(url, list);");
            modelString.AppendLine("}");
            modelString.AppendLine("update(formData: " + nameClass + ") {");
            modelString.AppendLine("let url = this.aPIURL + this.controller + '/Update';");
            modelString.AppendLine("return this.httpClient.put(url, formData);");
            modelString.AppendLine("}");
            modelString.AppendLine("asyncUpdate(formData: " + nameClass + ") {");
            modelString.AppendLine("let url = this.aPIURL + this.controller + '/AsyncUpdate';");
            modelString.AppendLine("return this.httpClient.put(url, formData);");
            modelString.AppendLine("}");
            modelString.AppendLine("removeRange(list: " + nameClass + "[]) {");
            modelString.AppendLine("let url = this.aPIURL + this.controller + '/RemoveRange';");
            modelString.AppendLine("return this.httpClient.delete(url, list).toPromise();");
            modelString.AppendLine("}");
            modelString.AppendLine("asyncRemoveRange(list: " + nameClass + "[]) {");
            modelString.AppendLine("let url = this.aPIURL + this.controller + '/AsyncRemoveRange';");
            modelString.AppendLine("return this.httpClient.delete(url, list).toPromise();");
            modelString.AppendLine("}");
            modelString.AppendLine("getAllToList() {");
            modelString.AppendLine("let url = this.aPIURL + this.controller + '/GetAllToList';");
            modelString.AppendLine("return this.httpClient.get(url).toPromise();");
            modelString.AppendLine("}");
            modelString.AppendLine("asyncGetAllToList() {");
            modelString.AppendLine("let url = this.aPIURL + this.controller + '/AsyncGetAllToList';");
            modelString.AppendLine("return this.httpClient.get(url).toPromise();");
            modelString.AppendLine("}");
            modelString.AppendLine("getByPageAndPageSizeToList(page: number, pageSize: number) {");
            modelString.AppendLine("let url = this.aPIURL + this.controller + '/GetByPageAndPageSizeToList';");
            modelString.AppendLine("const params = new HttpParams()");
            modelString.AppendLine(".set('page', JSON.stringify(page))");
            modelString.AppendLine(".set('pageSize', JSON.stringify(pageSize))");
            modelString.AppendLine("return this.httpClient.get(url, { params }).toPromise();");
            modelString.AppendLine("}");
            modelString.AppendLine("asyncGetByPageAndPageSizeToList(page: number, pageSize: number) {");
            modelString.AppendLine("let url = this.aPIURL + this.controller + '/AsyncGetByPageAndPageSizeToList';");
            modelString.AppendLine("const params = new HttpParams()");
            modelString.AppendLine(".set('page', JSON.stringify(page))");
            modelString.AppendLine(".set('pageSize', JSON.stringify(pageSize))");
            modelString.AppendLine("return this.httpClient.get(url, { params }).toPromise();");
            modelString.AppendLine("}");
            modelString.AppendLine("}");
            return modelString;
        }
        public StringBuilder GenerateRepositoryFile(string nameClass, string nameSpace, string initialCatalog)
        {
            StringBuilder modelString = new StringBuilder();
            modelString.AppendLine("using " + nameSpace + ".Data.Models;");
            modelString.AppendLine("namespace " + nameSpace + ".Data.Repositories");
            modelString.AppendLine("{");
            modelString.AppendLine("public class " + nameClass + "Repository : Repository<" + nameClass + ">, I" + nameClass + "Repository");
            modelString.AppendLine("{");
            modelString.AppendLine("private readonly " + initialCatalog + "Context _context;");
            modelString.AppendLine("public " + nameClass + "Repository(" + initialCatalog + "Context context) : base(context)");
            modelString.AppendLine("{");
            modelString.AppendLine("_context = context;");
            modelString.AppendLine("}");
            modelString.AppendLine("}");
            modelString.AppendLine("}");
            return modelString;
        }

        public StringBuilder GenerateIRepositoryFile(string nameClass, string nameSpace)
        {
            StringBuilder modelString = new StringBuilder();
            modelString.AppendLine("using " + nameSpace + ".Data.Models;");
            modelString.AppendLine("namespace " + nameSpace + ".Data.Repositories");
            modelString.AppendLine("{");
            modelString.AppendLine("public interface I" + nameClass + "Repository : IRepository<" + nameClass + ">");
            modelString.AppendLine("{");
            modelString.AppendLine("}");
            modelString.AppendLine("}");
            return modelString;
        }
    }
}
