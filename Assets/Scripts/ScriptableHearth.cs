using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hearth", menuName = "Hearth Data   ", order = 51)]
public class ScriptableHearth : ScriptableObject
{
    [SerializeField] private float _health;
    public float Health { get => _health; private set => _health = value; }

    [SerializeField] private Sprite sprite;
    public Sprite Sprite { get => sprite; private set => sprite = value; }

    [SerializeField] private int _givenReward;
    public int GivenReward { get => _givenReward; private set => _givenReward = value; }
}
