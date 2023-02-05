using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpDamageButton : MonoBehaviour
{
    private float _currentDamage;
    private int _price;
    private int _addDamage;
    private PlayerData _playerData;

    [SerializeField] TextMeshProUGUI _cost;

    private void Start()
    {
        _playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        _currentDamage = _playerData.Damage;
        PriceFound();
    }

    public void PriceFound()
    {
        _currentDamage = _playerData.Damage;
        if (_currentDamage >= 0 && _currentDamage < 10)
        {
            _price = 20;
            _addDamage = 1;
            if(_cost != null)
                _cost.text = $"{_price}";
        }
        else if (_currentDamage >= 10 && _currentDamage < 100)
        {
            _price = 50;
            _addDamage = 3;
            if (_cost != null)
                _cost.text = $"{_price}";
        }
        else if (_currentDamage >= 100 && _currentDamage < 200)
        {
            _price = 100;
            _addDamage = 5;
            if (_cost != null)
                _cost.text = $"{_price}";
        }
        else if (_currentDamage >= 200 && _currentDamage < 500)
        {
            _price = 250;
            _addDamage = 10;
            if (_cost != null)
                _cost.text = $"{_price}";
        }
        else
        {
            _price = 1000;
            _addDamage = 20;
            if (_cost != null)
                _cost.text = $"{_price}";
        }
    }
    public void UpDamage()
    {
        if (_playerData.Score >= _price)
        {
            _playerData.AddDamage(_addDamage);
            _playerData.minusScore(_price);

            PriceFound();
        }
        else
        {
            print("У вас недостаточно сердец!");
        }
    }
}
