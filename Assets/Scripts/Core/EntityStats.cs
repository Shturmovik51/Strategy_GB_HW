using Abstractions;
using UnityEngine;

public sealed class EntityStats : MonoBehaviour, ISelectable
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private Sprite _icon;
    private float _health;

    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;

    private void Start()
    {
        _health = _maxHealth;
    }
}
