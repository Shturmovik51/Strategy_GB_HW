using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarImg;
    public Image HealthBarImg => _healthBarImg;
    public Transform Owner { get; private set; }

    public void SetOwner(Transform owner)
    {
        Owner = owner;
    }
}
