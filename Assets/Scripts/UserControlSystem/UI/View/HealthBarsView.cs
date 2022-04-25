using Abstractions;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class HealthBarsView : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBarPref;
    [SerializeField] private GameObject _healthBarsHolder;
    [SerializeField] private Camera _mainCamera;

    private List<HealthBar> _healthBars;

    [Inject]

    private void Init()
    {
        _healthBars = new List<HealthBar>();

        Observable.EveryUpdate().Subscribe(_ => UpdateBarPosition());
    }

    private void UpdateBarPosition()
    {
        if(_healthBars.Count != 0)
        {
            for (int i = _healthBars.Count-1; i >= 0; i--)            
            { 
                var pos = _mainCamera.WorldToScreenPoint(_healthBars[i].OwnerTransform.position);
                _healthBars[i].transform.position = pos + _healthBars[i].HealthBarHeightPosition * Vector3.up;
            }
        }  
    }

    public void AddBar(Transform ownerTransform, IHealthHolder ownerHeals)
    {
        var bar = Instantiate(_healthBarPref, _healthBarsHolder.transform);
        var barComponent = bar.GetComponent<HealthBar>();
        barComponent.SetOwner(ownerTransform, ownerHeals);
        barComponent.OnEndHealth += RemoveBar;
        _healthBars.Add(barComponent);
        
    }

    private void RemoveBar(HealthBar bar)
    {
        _healthBars.Remove(bar);
        if(bar != null) Destroy(bar.gameObject);
    }
}
