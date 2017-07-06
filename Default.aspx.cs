using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreLinq;

public partial class _Default : Page
{
    public int nbCats { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCats();
           
        }
        DisplayTwoCats();
    }

    private void DisplayTwoCats()
    {
        if ((Session["Cats"] as Cats) != null)
        {
            var twoRandomCats = (Session["Cats"] as Cats).images.RandomSubset(2);
            leftCat.ImageUrl = twoRandomCats.Select(t => t.url).First();
            leftCatId.Value = twoRandomCats.Select(t => t.id).First();
            rightCat.ImageUrl = twoRandomCats.Select(t => t.url).Last();
            rightCatId.Value = twoRandomCats.Select(t => t.id).Last();
        }
    }

    private void LoadCats()
    {
        Session["Cats"] = JsonHelper.GetCats("https://latelier.co/data/cats.json");
        nbCats = (Session["Cats"] as Cats).images.Where(c=>!c.voted).Count();


    }

    protected void leftCat_Click(object sender, ImageClickEventArgs e)
    {
        ScoreCat(WhichCat.Left, 10);
        
    }

    protected void rightCat_Click(object sender, ImageClickEventArgs e)
    {
        ScoreCat(WhichCat.Right, 10);
       

    }

    public void ScoreCat(WhichCat whichCat, double score)
    {
        var allCats = Session["Cats"] as Cats;
        var leftCat = allCats.images.Find(c => c.id == leftCatId.Value);
        var rightCat = allCats.images.Find(c => c.id == rightCatId.Value);
        if (whichCat == WhichCat.Left)
        {
            EloRating.Score(leftCat, rightCat,10,0);
           (Session["Cats"] as Cats).images.Where(i => i.id == leftCatId.Value).First().voted=true;
           
        }
        else
        {
            EloRating.Score(leftCat, rightCat, 0, 10);
            (Session["Cats"] as Cats).images.Where(i => i.id == rightCatId.Value).First().voted = true;
        }
        nbCats = (Session["Cats"] as Cats).images.Where(c => !c.voted).Count();


    }

}
public enum WhichCat
{
    Left,
    Right
}