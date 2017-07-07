using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreLinq;

public partial class _Default : Page
{
    public int nbVotes { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((SessionHelper.Get<List<Cat>>("Cats")) == null)
        {
            LoadCats();

        }
        if (!IsPostBack)
            DisplayTwoCats();
    }

    private void DisplayTwoCats()
    {
        nbVotes = getNbCats();

        if ((SessionHelper.Get<List<Cat>>("Cats")) != null)
        {
            var catsForVote = SessionHelper.Get<List<Cat>>("Cats");
            if (catsForVote != null)
            {
                var twoCats = CatsHelper.Random<Cat>(catsForVote);
                btnLeftCat.ImageUrl = twoCats.First().url;
                leftCatId.Value = twoCats.First().id;

                var rightCat = CatsHelper.Random<Cat>(catsForVote);
                btnRightCat.ImageUrl = twoCats.Last().url;
                rightCatId.Value = twoCats.Last().id;


            }
        }
    }

    private void LoadCats()
    {
        SessionHelper.Set<List<Cat>>("Cats", CatsHelper.GetCats("https://latelier.co/data/cats.json"));



    }

    private int getNbCats()
    {
        if (SessionHelper.Get<List<Cat>>("Cats") != null)
            return SessionHelper.Get<List<Cat>>("Cats").Sum(c => c.nbvotes);
        return 0;
    }
    protected void leftCat_Click(object sender, ImageClickEventArgs e)
    {
        ScoreCat(WhichCat.Left);
        DisplayTwoCats();

    }

    protected void rightCat_Click(object sender, ImageClickEventArgs e)
    {
        ScoreCat(WhichCat.Right);
        DisplayTwoCats();


    }

    public void ScoreCat(WhichCat whichCat)
    {
        var allCats = SessionHelper.Get<List<Cat>>("Cats");
        var leftCat = allCats.Find(c => c.id == leftCatId.Value);
        var rightCat = allCats.Find(c => c.id == rightCatId.Value);

        EloRating.UpdateScores(leftCat, rightCat, whichCat == WhichCat.Left, 400, 10);

    }




    protected void nextCats_Click(object sender, EventArgs e)
    {
        //var allCats = SessionHelper.Get<List<Cat>>("Cats");
        //var leftCat = allCats.Find(c => c.id == leftCatId.Value);
        //var rightCat = allCats.Find(c => c.id == rightCatId.Value);
        //leftCat.voted = true;
        //rightCat.voted = true;
        DisplayTwoCats();

    }
}
public enum WhichCat
{
    Left,
    Right
}