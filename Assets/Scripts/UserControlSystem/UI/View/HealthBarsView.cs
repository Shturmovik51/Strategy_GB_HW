using System.Collections;
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
            for (int i = 0; i < _healthBars.Count; i++)            
            {                
                var pos = _mainCamera.WorldToScreenPoint(_healthBars[i].Owner.position);
                _healthBars[i].transform.position = pos + 50 * Vector3.up;
            }
        }
    }

    public void AddBar(Transform ownerTransform)
    {
        var bar = Instantiate(_healthBarPref, _healthBarsHolder.transform);
        var barComponent = bar.GetComponent<HealthBar>();
        barComponent.SetOwner(ownerTransform);
        _healthBars.Add(barComponent);
    }

}
