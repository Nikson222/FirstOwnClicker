using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class VoiceMassageButton : MonoBehaviour
{
    [SerializeField] VoiceMassageScriptable voiceMassageScriptable;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] TextMeshProUGUI _textMeshPro;
    private PlayerData _playerData;

    private AudioClip _voiceMassageAudioClip;
    private int _price;

    private bool _isLocked;

    private void Update()
    {
        if (!_audioSource.isPlaying && !_audioSource.mute)
            _audioSource.mute = true;
    }

    private void Start()
    {
        _isLocked = true;

        LoadBool();
        if (_isLocked)
        {
            this.gameObject.GetComponent<Image>().color = new Color((float)0.7, 1, 1, 1);
        }
        else
        {
            this.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
            
        _playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        _voiceMassageAudioClip = voiceMassageScriptable.AudioClip;
        _audioSource.mute = true;
        _audioSource.clip = _voiceMassageAudioClip;
        _price = voiceMassageScriptable.Price;
        if(_textMeshPro != null)
            _textMeshPro.text = $"{_price}";
    }

    public void PlayVoiceMassage()
    {
        if (_isLocked)
        {
            BuyVoiceMassage();
        }
        else
        {
            _audioSource.mute = false;
            _audioSource.Play();
        }
    }

    public void BuyVoiceMassage()
    {
        if (_playerData.Score >= _price)
        {
            _isLocked = false;

            SaveBool();

            _playerData.minusScore(_price);

            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            print("У вас недостаточно сердец!");
        }
    }

    private void SaveBool()
    {
        SavedData.SetButtonState(gameObject.name, _isLocked);
    }

    private void LoadBool()
    {
        _isLocked = SavedData.GetButtonState(gameObject.name, true);
    }

}
