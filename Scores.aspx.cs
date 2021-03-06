﻿using System;
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
                rptCats.DataSource = catsToDisplay.Where(c => c.nbmatchsnuls + c.nbvotesgagnants + c.nbvotesperdants > 0);
            rptCats.DataBind();
            int? nbVotesTotal = SessionHelper.Get<int>("nbVotesTotal");
            lblNbVotesTotal.Text = nbVotesTotal.HasValue ? " (" + nbVotesTotal.Value.ToString() + " votes au total" + ")" : string.Empty;
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
            lblCatScore.Text = Math.Round(cat.score, 2).ToString();
            var lblnbVotesGagnants = e.Item.FindControl("lblnbVotesGagnants") as Label;
            lblnbVotesGagnants.Text = cat.nbvotesgagnants.ToString();
            var lblnbVotesPerdants = e.Item.FindControl("lblnbVotesPerdants") as Label;
            lblnbVotesPerdants.Text = cat.nbvotesperdants.ToString();
            var lblnbMatchsNuls = e.Item.FindControl("lblnbMatchsNuls") as Label;
            lblnbMatchsNuls.Text = cat.nbmatchsnuls.ToString();
        }
    }
}