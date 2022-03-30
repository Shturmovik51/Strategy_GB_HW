using System.Linq;
using Abstractions;
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
    private SelectableValue _selectedObject;
    private Plane _groundPlane;
    
    private void Start() => _groundPlane = new Plane(_groundTransform.up, 0);

    [Inject] 
    private void Init(Vector3Value groundClicksRMB, SelectableValue selectedObject)
    {
        _groundClicksRMB = groundClicksRMB;
        _selectedObject = selectedObject;
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
            if (_groundPlane.Raycast(ray, out var enter))
            {
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
            }
        }
    }
}