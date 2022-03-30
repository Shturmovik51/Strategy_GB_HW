using System.Linq;
using Abstractions;
using Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UserControlSystem;
using Zenject;

public sealed class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private EventSystem _eventSystem;    
    [SerializeField] private Transform _groundTransform;
    
    private Vector3Value _groundClicksRMB;
    private GameObjectValue _targetClickRMB;
    private SelectableValue _selectedObject;
    private Plane _groundPlane;
    
    private void Start() => _groundPlane = new Plane(_groundTransform.up, 0);

    [Inject] 
    private void Init(Vector3Value groundClicksRMB, SelectableValue selectedObject, GameObjectValue gameObjectValue)
    {
        _groundClicksRMB = groundClicksRMB;
        _selectedObject = selectedObject;
        _targetClickRMB = gameObjectValue;
    }

    private void Update()
    {
        if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
        {
            return;
        }
        if (_eventSystem.IsPointerOverGameObject())
        {
            return;
        }
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonUp(0))
        {
            var hits = Physics.RaycastAll(ray);
            if (hits.Length == 0)
            {
                return;
            }
            var selectable = hits
                .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
                .FirstOrDefault(c => c != null);
            _selectedObject.SetValue(selectable);
        }
        else
        {
            if (Physics.Raycast(ray, out var hit))
            {
                var go = hit.collider.gameObject;
                if(go.TryGetComponent<MainBuilding>(out var building) || go.TryGetComponent<MainUnit>(out var unit))
                    _targetClickRMB.SetValue(go);
                else
                    _groundClicksRMB.SetValue(hit.point);
            }

            //if (_groundPlane.Raycast(ray, out var enter))
            //{
            //    Debug.Log("w");
            //    _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
            //    _targetClickRMB.SetValue(null);
            //}            
        }
    }
}