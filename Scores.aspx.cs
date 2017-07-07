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
        var cats = SessionHelper.Get<List<Cat>>("Cats");
        if (cats != null)
        {
            var catsToDisplay = cats.OrderByDescending(s => s.score);

            if (chkAll.Checked)
                rptCats.DataSource = catsToDisplay;
            else
                rptCats.DataSource = catsToDisplay.Where(c => c.score > 0);
            rptCats.DataBind();
        }
    }

    protected void rptCats_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        var cat = e.Item.DataItem as Cat;
        if (cat != null)
        {
            var imgCat = e.Item.FindControl("imgCat") as Image;
            imgCat.ImageUrl = cat.url;
            var lblCatScore = e.Item.FindControl("lblCatScore") as Label;
            lblCatScore.Text = cat.score.ToString();
            var lblnbVotes = e.Item.FindControl("lblnbVotes") as Label;
            lblnbVotes.Text = cat.nbvotes.ToString();
        }
    }
}