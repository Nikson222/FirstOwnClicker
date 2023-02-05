using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Lean.Common;
using Lean.Touch;

public class PlanetScript : MonoBehaviour
{
    private bool _isCanGoToNextLVL;
    public bool IsCanGoToNextLVL { get => _isCanGoToNextLVL; private set => _isCanGoToNextLVL = value; }
    //stats
    private float _health;
    public float Health { get => _health; private set => _health = value; }
    private float _saveHealth;
    public float SaveHealth { get => _saveHealth; private set => _saveHealth = value; }

    //effects
    [SerializeField] GameObject effect;
    [SerializeField] GameObject[] hitSounds;

    //animator
    private Animator animator;

    //Player Data
    private GameObject _player;
    private PlayerData _playerData;

    //UI Data
    [SerializeField] Image _hpImage;
    [SerializeField] Canvas _canvas;
    private Material _material;

    [SerializeField] private ScriptableHearth[] _scriptableHearth;
    //LVL Data (Change private)
    private int _lvlNumber;

    private void Awake()
    {
        animator = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        _hpImage.fillAmount = 1;
        _material = this.GetComponent<SpriteRenderer>().material;
        _canvas.worldCamera = Camera.main;
        
        _player = GameObject.FindWithTag("Player");
        _playerData = _player.GetComponent<PlayerData>();
        _playerData._lvlCount = _scriptableHearth.Length;
        _lvlNumber = _playerData._lvlNumber;

        if (_scriptableHearth[_lvlNumber] != null)
        {
            _health = _scriptableHearth[_lvlNumber].Health;
            _saveHealth = _health;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = _scriptableHearth[_lvlNumber].Sprite;
        }
        else
        {
            _health = 10f;
            _saveHealth = _health;
        }

    }
    private void Update()
    {
        if (_health <= 0)
            DestroyPlanet();
    }

    public void TakeDamage()
    {
        int rand = Random.Range(0, hitSounds.Length);
        Instantiate(hitSounds[rand], transform.position, Quaternion.identity);
        _material.color = new Color(Random.value, Random.value, Random.Range((float)0.6, 1), 1);
        _health -= _playerData.Damage;
        _hpImage.fillAmount -= _playerData.Damage / _saveHealth;
    }

    private void DestroyPlanet()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        animator.SetTrigger("Shake");
        Destroy(this.gameObject);
        _playerData.plusScore(_scriptableHearth[_lvlNumber].GivenReward);
    }

    public void DestoryPlanetWhitoutRewards()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        animator.SetTrigger("Shake");
        Destroy(this.gameObject);
    }
}
