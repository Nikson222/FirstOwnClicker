using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Voice Massage", menuName = "Voice massage", order = 52)]
public class VoiceMassageScriptable : ScriptableObject
{
    [SerializeField] private AudioClip audioClip;
    public AudioClip AudioClip { get => audioClip; private set => audioClip = value; }

    [SerializeField] private int _price;
    public int Price { get => _price; set => _price = value; }

}
