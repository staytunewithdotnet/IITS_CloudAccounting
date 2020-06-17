// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.GenerateCaptcha
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace IITS_CloudAccounting
{
  public class GenerateCaptcha : Page
  {
    protected HtmlForm form1;

    protected void Page_Load(object sender, EventArgs e)
    {
      this.Response.Clear();
      int height = 30;
      int width = 100;
      Bitmap bitmap = new Bitmap(width, height);
      RectangleF layoutRectangle = new RectangleF(10f, 5f, 0.0f, 0.0f);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      graphics.Clear(Color.White);
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
      graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
      graphics.DrawString(this.Session["captcha"].ToString(), new Font("Thaoma", 12f, FontStyle.Italic), Brushes.Green, layoutRectangle);
      graphics.DrawRectangle(new Pen(ColorTranslator.FromHtml("#2E9A9C")), 1, 1, width - 2, height - 2);
      graphics.Flush();
      this.Response.ContentType = "image/jpeg";
      bitmap.Save(this.Response.OutputStream, ImageFormat.Jpeg);
      graphics.Dispose();
      bitmap.Dispose();
    }
  }
}
