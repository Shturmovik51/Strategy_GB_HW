using Abstractions;
using UnityEngine;

public sealed class MainBuilding : MonoBehaviour, ISelectable, IAttackable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Transform PivotPoint => _pivotPoint;
    public Sprite Icon => _icon;
    public int HealthBarHeightPosition => _healthBarHeightPosition;

    public Vector3 RallyPoint { get; set; }

    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _pivotPoint;
    [SerializeField] private int _healthBarHeightPosition;

    private float _health = 1000;

    public void RecieveDamage(int amount)
    {
        if (_health <= 0)        
            return;
        
        _health -= amount;

        if (_health <= 0)        
            Destroy(gameObject);
        
    }

    public void RestoreHealth(int amount)
    {
        if (_health >= _maxHealth)        
            return;
        
        _health += amount;

        if (_health >= _maxHealth)
            _health = _maxHealth;
    }
}