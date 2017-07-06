using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de EloRating
/// </summary>
public class EloRating
{

    public static Tuple<CatImage, CatImage> Score(CatImage cat1, CatImage cat2, double Score1 = 0, double Score2 = 0)
    {

        double FinalResult1 = 0;
        double FinalResult2 = 0;
        /*
        double CurrentR1 = 1500.0;
        double CurrentR2 = 1500.0;

        double Score1 = 20.0;
        double Score2 = 10;
        */
        double CurrentRating1 = cat1.score;
        double CurrentRating2 = cat2.score;
        double E = 0;

        if (Score1 != Score2)
        {
            if (Score1 > Score2)
            {
                E = 120 - Math.Round(1 / (1 + Math.Pow(10, ((CurrentRating2 - CurrentRating1) / 400))) * 120);
                FinalResult1 = CurrentRating1 + E;
                FinalResult2 = CurrentRating2 - E;
            }
            else
            {
                E = 120 - Math.Round(1 / (1 + Math.Pow(10, ((CurrentRating1 - CurrentRating2) / 400))) * 120);
                FinalResult1 = CurrentRating1 - E;
                FinalResult2 = CurrentRating2 + E;
            }
        }
        else
        {
            if (CurrentRating1 == CurrentRating2)
            {
                FinalResult1 = CurrentRating1;
                FinalResult2 = CurrentRating2;
            }
            else
            {
                if (CurrentRating1 > CurrentRating2)
                {
                    E = (120 - Math.Round(1 / (1 + Math.Pow(10, ((CurrentRating1 - CurrentRating2) / 400))) * 120)) - (120 - Math.Round(1 / (1 + Math.Pow(10, ((CurrentRating2 - CurrentRating1) / 400))) * 120));
                    FinalResult1 = CurrentRating1 - E;
                    FinalResult2 = CurrentRating2 + E;
                }
                else
                {
                    E = (120 - Math.Round(1 / (1 + Math.Pow(10, ((CurrentRating2 - CurrentRating1) / 400))) * 120)) - (120 - Math.Round(1 / (1 + Math.Pow(10, ((CurrentRating1 - CurrentRating2) / 400))) * 120));
                    FinalResult1 = CurrentRating1 + E;
                    FinalResult2 = CurrentRating2 - E;
                }
            }
        }
        cat1.score += (((FinalResult1 - CurrentRating1) > 0) ? (FinalResult1 - CurrentRating1) : (FinalResult1 - CurrentRating1));
        cat2.score += (((FinalResult2 - CurrentRating2) > 0) ? (FinalResult2 - CurrentRating2) : (FinalResult2 - CurrentRating2));
        return Tuple.Create<CatImage, CatImage>(cat1, cat2);

    }
}