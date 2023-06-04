using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOverController : MonoBehaviour
{
    [SerializeField] private TMP_Text[] listRankin;
    [SerializeField] private Score_SO ranki;
    public Button btnPlay;
    // Start is called before the first frame update
    void Start()
    {
        btnPlay.onClick.AddListener(() => ReturnMenu());
        for (int i = 0; i < listRankin.Length; i++)
        {
            listRankin[i].text = i + "). " + ranki.maxScore[i].GetName() + ": " + ranki.maxScore[i].GetScore() + " pnts";
        }
    }

    void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
