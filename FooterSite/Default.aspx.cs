using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSBCHeaderFooter
{
    public partial class PX3Footer : System.Web.UI.Page
    {
        protected override void Render(HtmlTextWriter writer)
        {

            System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();

            using (StringWriter strWriter = new StringWriter(strBuilder))
            {
                using (HtmlTextWriter txtWriter = new HtmlTextWriter(strWriter))
                {
                    base.Render(txtWriter);
                }
            }

            var outputAsString = "document.write('" + strBuilder.Replace(System.Environment.NewLine, " ").Replace("'", "&#39;") + "');";

            Response.ContentType = "text/javascript";
            writer.Write(outputAsString);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}