using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class PlayerData : MonoBehaviour
{
    //Поставить private
    public int _score = 0;

    public int Score { get => _score; private set => _score = value; }
    [SerializeField] private float _damage = 1;
    public float Damage { get => _damage; private set => _damage = value; }

    //LVL Data (Change private)
    public int _lvlCount;
    public int _lvlNumber = 0;
    public int _countCollectedHearth;
    private bool _isCanGoToNextLVL;
    public bool IsCanGoToNextLVL { get => _isCanGoToNextLVL; private set => _isCanGoToNextLVL = value; }

    [SerializeField] private GameObject _lvlButton;


    private void Start()
    {
        _score = PlayerPrefs.GetInt("score");
        _damage = PlayerPrefs.GetFloat("damage");
        if (_damage <= 0)
        {
            _damage = 1;
            PlayerPrefs.SetFloat("damage", _damage);
        }
        if (_score < 0 || _score == 0)
        {
            _score = 0;
            PlayerPrefs.SetInt("score", Score);
        }
    }
    public void plusScore(int levelScore)
    {
        _countCollectedHearth++;
        _isCanGoToNextLVL = _countCollectedHearth >= 15;
        if (_isCanGoToNextLVL && _lvlNumber < _lvlCount-1)
        {
            _lvlButton.SetActive(true);
        }
        Score += levelScore;
        PlayerPrefs.SetInt("score", Score);
    }

    public void minusScore(int value)
    {
        Score -= value;
        PlayerPrefs.SetInt("score", Score);
    }

    public void AddDamage(int value)
    {
        _damage += value;
        PlayerPrefs.SetFloat("damage", _damage);
    }
    
    public void AddLvl()
    {
        _lvlNumber++;
        GameObject.FindGameObjectWithTag("Planet").GetComponent<PlanetScript>().DestoryPlanetWhitoutRewards();
        _countCollectedHearth = 0;
    }
}
