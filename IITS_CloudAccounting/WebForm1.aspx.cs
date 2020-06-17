// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.WebForm1
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting
{
  public class WebForm1 : Page
  {
    protected HtmlForm form1;
    protected TextBox txtValue;
    protected Button btnValue;
    protected Label lblNextValue;
    protected FileUpload FileUpload1;
    protected Button Button1;
    protected Label lblMessage;
    protected GridView GridView1;

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void BtnValueClick(object sender, EventArgs e)
    {
      if (this.txtValue.Text.Trim().Length > 1)
      {
        char ch1 = this.txtValue.Text[this.txtValue.Text.Length - 1];
        string str = this.txtValue.Text.Remove(this.txtValue.Text.Length - 1, 1);
        char ch2;
        switch (ch1)
        {
          case '0':
          case '1':
          case '2':
          case '3':
          case '4':
          case '5':
          case '6':
          case '7':
          case '8':
          case '9':
            str += (int.Parse(ch1.ToString()) + 1).ToString();
            ch2 = Convert.ToChar(" ");
            break;
          case 'Z':
            ch2 = 'A';
            str += "1";
            break;
          case 'z':
            ch2 = 'a';
            str += "1";
            break;
          default:
            ch2 = (char) ((uint) ch1 + 1U);
            break;
        }
        this.txtValue.Text = this.lblNextValue.Text = str + (object) ch2;
        this.txtValue.Text = this.txtValue.Text.Trim();
      }
      else
      {
        string str1 = string.Empty;
        char ch1 = this.txtValue.Text[this.txtValue.Text.Length - 1];
        string str2;
        switch (ch1)
        {
          case '0':
          case '1':
          case '2':
          case '3':
          case '4':
          case '5':
          case '6':
          case '7':
          case '8':
            str2 = (int.Parse(ch1.ToString()) + 1).ToString();
            break;
          case '9':
            str2 = "10";
            break;
          case 'Z':
            str2 = str1 + "1A";
            break;
          case 'z':
            str2 = str1 + "1a";
            break;
          default:
            char ch2;
            str2 = str1 + (object) (ch2 = (char) ((uint) ch1 + 1U));
            break;
        }
        this.txtValue.Text = this.lblNextValue.Text = str2;
      }
    }

    private void Bindgrid(DataTable csvdt)
    {
      this.GridView1.DataSource = (object) csvdt;
      this.GridView1.DataBind();
    }

    protected void Button1Click(object sender, EventArgs e)
    {
      this.lblMessage.Text = "";
      if (this.FileUpload1.HasFile)
      {
        string fileName = Path.GetFileName(this.FileUpload1.FileName);
        if (fileName != null && fileName.Contains(".csv"))
        {
          DataTable csvdt = new DataTable();
          this.FileUpload1.SaveAs(this.Server.MapPath("~/UploadCSVFile/") + fileName);
          string str1 = File.ReadAllText(this.Server.MapPath("~/UploadCSVFile/") + fileName);
          int num = 0;
          string str2 = str1;
          char[] chArray1 = new char[1]
          {
            '\n'
          };
          foreach (string str3 in str2.Split(chArray1))
          {
            if (!string.IsNullOrEmpty(str3) && num == 0)
            {
              string str4 = str3;
              char[] chArray2 = new char[1]
              {
                ','
              };
              foreach (string columnName in str4.Split(chArray2))
                csvdt.Columns.Add(columnName);
            }
            if (!string.IsNullOrEmpty(str3) && num != 0)
            {
              csvdt.Rows.Add();
              int index = 0;
              string str4 = str3;
              char[] chArray2 = new char[1]
              {
                ','
              };
              foreach (string str5 in str4.Split(chArray2))
              {
                csvdt.Rows[csvdt.Rows.Count - 1][index] = (object) str5;
                ++index;
              }
            }
            ++num;
          }
          this.Bindgrid(csvdt);
          File.Delete(this.Server.MapPath("~/UploadCSVFile/") + fileName);
          this.lblMessage.Text = "CSV Successfully Read And Ready To Import.";
          this.lblMessage.ForeColor = Color.Green;
        }
        else
        {
          this.lblMessage.Text = "The CSV file is invalid. OR file is not CSV";
          this.lblMessage.ForeColor = Color.Red;
        }
      }
      else
      {
        this.lblMessage.Text = "No File Selected. Please Select CSV file.";
        this.lblMessage.ForeColor = Color.Red;
      }
    }
  }
}
