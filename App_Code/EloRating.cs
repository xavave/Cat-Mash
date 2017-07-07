using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de EloRating
/// </summary>
public class EloRating
{
    /// 
    /// Updates the scores in the passed matchup. 
    /// 
    /// The Matchup to update
    /// Whether User 1 was the winner (false if User 2 is the winner)
    /// The desired Diff
    /// The desired KFactor
    public static Tuple<Cat, Cat> UpdateScores(Cat leftCat, Cat rightCat, bool user1WonMatch, int diff, int kFactor)

    {

        double est1 = 1 / Convert.ToDouble(1 + 10 ^ ((int)rightCat.score - (int)leftCat.score) / diff);
        double est2 = 1 / Convert.ToDouble(1 + 10 ^ ((int)leftCat.score - (int)rightCat.score) / diff);
        int sc1 = 0;
        int sc2 = 0;

        if (user1WonMatch)
        {
            leftCat.nbvotes++;
            sc1 = 1;
        }
        else
        {
            rightCat.nbvotes++;
            sc2 = 1;
        }

        leftCat.score = Convert.ToInt32(Math.Round((int)leftCat.score + kFactor * (sc1 - est1)));
        rightCat.score = Convert.ToInt32(Math.Round((int)rightCat.score + kFactor * (sc2 - est2)));
        return Tuple.Create<Cat, Cat>(leftCat, rightCat);
    }

  
}