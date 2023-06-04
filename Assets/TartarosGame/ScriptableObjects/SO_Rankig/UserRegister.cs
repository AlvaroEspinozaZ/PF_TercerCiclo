using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[CreateAssetMenu(fileName = "UserRegister", menuName = "ScriptableObject/Score/UserRegister", order = 2)]
public class UserRegister : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private float _score;
    public void SetName(TMP_InputField name)
    {
        this._name = name.text;
    }
    public void SetName(string name)
    {
        this._name = name;
    }
    public void SetScore(float score)
    {
        this._score = score;
    }
    public string GetName()
    {
        return _name;
    }
    public float GetScore()
    {
        return _score;
    }
    public UserRegister Vacioooo()
    {
        UserRegister tmp = new UserRegister();
        tmp._name = "";
        tmp._score = 0;
        return tmp;
    }
}
