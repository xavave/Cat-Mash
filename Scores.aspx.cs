using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Scores : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Title = "Scores";
        var cats = Session["Cats"] as Cats;
        if (cats != null)
        {
            var catsToDisplay = cats.images.OrderByDescending(s => s.score);

            if (chkAll.Checked)
                rptCats.DataSource = catsToDisplay;
            else
                rptCats.DataSource = catsToDisplay.Where(c => c.score > 0);
            rptCats.DataBind();
        }
    }

    protected void rptCats_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        var catImage = e.Item.DataItem as CatImage;
        if (catImage != null)
        {
            var imgCat = e.Item.FindControl("imgCat") as Image;
            imgCat.ImageUrl = catImage.url;
            var score = (Session["Cats"] as Cats).images.Where(i => i.id == catImage.id).Select(s => s.score).First();
            imgCat.ImageUrl = catImage.url;
            var lblCatScore = e.Item.FindControl("lblCatScore") as Label;
            lblCatScore.Text = score.ToString();
        }
    }
}