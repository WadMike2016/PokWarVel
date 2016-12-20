using PokWarVel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PokWarVel.Helpers
{
   public static class Customs
    {
        public static MvcHtmlString TopFive (this HtmlHelper Hm)
        {
            TagBuilder Title = new TagBuilder("h1");
            Title.SetInnerText("Top Five");
            TagBuilder ul = new TagBuilder("ul");
            ul.InnerHtml = Title.ToString();
            foreach (ResultModel item in ResultModel.GetTopFive())
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder div = new TagBuilder("div");
                div.AddCssClass("container-fluid");
                TagBuilder row = new TagBuilder("div");
                row.AddCssClass("row");
                TagBuilder col1 = new TagBuilder("div");
                col1.AddCssClass("col-lg-4");
                TagBuilder img = new TagBuilder("img");
                img.MergeAttribute("src", item.Avatar);
                img.AddCssClass("roundedImage");
                TagBuilder col2 = new TagBuilder("div");
                col2.AddCssClass("col-lg-8");
                col2.InnerHtml += "<br><b>" + item.Name + "</b>";

                          

                col1.InnerHtml += img.ToString();
                row.InnerHtml += col1.ToString();
                row.InnerHtml += col2.ToString();
                div.InnerHtml += row.ToString();
                li.InnerHtml += div.ToString();
              
                ul.InnerHtml += li.ToString();

            }

            return new MvcHtmlString(ul.ToString());
        }
    }
}
