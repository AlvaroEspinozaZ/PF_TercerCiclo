using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score_SO", menuName = "ScriptableObject/Score/Score_SO", order = 1)]

public class Score_SO : ScriptableObject
{
    [SerializeField] public UserRegister[] maxScore;

    private void OnEnable()
    {        
        if (maxScore == null)
        {
            maxScore = new UserRegister[10];           
        }        
    }

    public void RegistryNewScore(UserRegister newScore)
    {
        UserRegister[] newMaxScore = new UserRegister[10];
        for (int i = 0;i<newMaxScore.Length;i++)
        {
            newMaxScore[i] = maxScore[0].Vacioooo();
        }
        bool isCHanged = false;
        for (int i = 0; i < maxScore.Length; i++)
        {
            UserRegister safePrevius = maxScore[i];
            if (newScore.GetScore() > maxScore[i].GetScore() && !isCHanged)
            {
                newMaxScore[i].SetName(newScore.GetName());
                newMaxScore[i].SetScore(newScore.GetScore());
                //newMaxScore[i] = newScore;
                i++;
                isCHanged = true;
            }
            newMaxScore[i] = safePrevius;
        }
        maxScore = newMaxScore; 
    }
}
