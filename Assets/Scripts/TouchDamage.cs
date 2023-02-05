using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDamage : MonoBehaviour
{
    private PlanetScript planet;
    private Camera _mainCam;
    private Collider2D _collider;

    private void Start()
    {
        _mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    private void OnEnable()
    {
        Lean.Touch.LeanTouch.OnFingerTap += HandleFingerTap;
    }
    private void OnDisable()
    {
        Lean.Touch.LeanTouch.OnFingerTap -= HandleFingerTap;
    }
    void HandleFingerTap(Lean.Touch.LeanFinger finger)
    {
        _collider = Physics2D.OverlapPoint(_mainCam.ScreenToWorldPoint(finger.ScreenPosition));
        if (_collider != null && _collider.CompareTag("Planet"))
        {
            if (planet == null)
                planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<PlanetScript>();
            planet.TakeDamage();
        }
    }
}
