using Abstractions;
using UnityEngine;

namespace Core
{
    public sealed class MainBuilding : MonoBehaviour, IUnitProducer, ISelectable
    {
        [SerializeField] private GameObject _unitPrefab;
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private GameObject _markerPref;
        [SerializeField] private float _maxHealth;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Collider _collider;

        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        public GameObject Marker { get; private set; }

        private float _health;

        private void Start()
        {
            Marker = InitMarker();
            _health = _maxHealth;
        }

        public void ProduceUnit()
        {
            Instantiate(_unitPrefab,
                new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)),
                Quaternion.identity,
                _unitsParent);
        }

        private GameObject InitMarker()
        {
            var marker = Instantiate(_markerPref, transform);
            marker.transform.localPosition = Vector3.zero;
            var ps = marker.GetComponent<ParticleSystem>();
            ps.startSize = _collider.bounds.size.x * 2;
            marker.SetActive(false);
            return marker;
        }
    }
}