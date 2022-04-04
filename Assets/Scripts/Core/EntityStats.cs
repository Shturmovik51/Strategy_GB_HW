using Abstractions;
using UnityEngine;

public sealed class EntityStats : MonoBehaviour, ISelectable
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _markerPref;
    [SerializeField] private Collider _collider;

    private float _health;
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public GameObject Marker { get; private set; }

    private void Start()
    {
        _health = _maxHealth;
        Marker = InitMarker();
    }

    private GameObject InitMarker()
    {
        var marker = Instantiate(_markerPref, transform);
        marker.transform.localPosition = Vector3.zero;
        var ps = marker.GetComponent<ParticleSystem>();
        var psMainModule = ps.main;
        psMainModule.startSizeMultiplier = _collider.bounds.size.x * 2;
        marker.SetActive(false);
        return marker;
    }
}
