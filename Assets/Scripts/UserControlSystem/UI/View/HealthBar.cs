using Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Action<HealthBar> OnEndHealth;
    [SerializeField] private Image _healthBarImg;
    public Image HealthBarImg => _healthBarImg;
    public Transform OwnerTransform { get; private set; }
    public int HealthBarHeightPosition { get; private set; }

    public void SetOwner(Transform ownerTransform, IHealthHolder ownerHeals)
    {
        OwnerTransform = ownerTransform;
        Observable.EveryUpdate().Subscribe(_ => HealthMonitor(ownerHeals.Health, ownerHeals.MaxHealth));
        HealthBarHeightPosition = ownerHeals.HealthBarHeightPosition;
        
    }
    void HealthMonitor(float health, float maxHealth)
    {
        HealthBarImg.fillAmount = health / maxHealth;
        if (health <= 0)
            OnEndHealth.Invoke(this);
    }
}