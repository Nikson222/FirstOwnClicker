using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _playerScore;
    [SerializeField] TextMeshProUGUI _playerDamage;
    [SerializeField] TextMeshProUGUI _hpHearth;

    [SerializeField] PlayerData _playerData;
    [SerializeField] PlanetScript _planetData;



    private void Update()
    {
        if(_playerScore != null)
            _playerScore.text = $"Твои сердечки: {_playerData.Score}";
        if (_playerDamage != null)
            _playerDamage.text = $"Твой урон: {_playerData.Damage}";
        if (_hpHearth != null)
        {
            if (_planetData == null)
            {
                try
                {
                    _planetData = GameObject.FindGameObjectWithTag("Planet").GetComponent<PlanetScript>();
                }
                catch
                {
                    _hpHearth.gameObject.SetActive(false);
                    print("Planet not found on scene");
                }
            }
            else
            {
                _hpHearth.gameObject.SetActive(true);
                _hpHearth.text = $"{_planetData.Health}/{_planetData.SaveHealth}";
            }

        }
    }
}
