using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GUIController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private TMP_Text barLife;
    [SerializeField] public TMP_Text score;
    [SerializeField] public int pnts = 0;
    [SerializeField] private Score_SO rankings;
    [SerializeField] public UserRegister user;
    private float _distanceScore = 0;
    private int _totalScore = 0;

    void Update()
    {
        _distanceScore += Time.deltaTime;
        _totalScore = (int)_distanceScore + _playerController._weaponController.score;
        barLife.text = _playerController._healthBarController.currentValue+ " / " + _playerController._healthBarController.maxValue;
        score.text = "Score: " + _totalScore;

        if (_playerController._healthBarController.currentValue <= 0)
        {
            user.SetScore(_totalScore);
            rankings.RegistryNewScore(user);
            SceneManager.LoadScene("GameOver");
        }
    }
}
