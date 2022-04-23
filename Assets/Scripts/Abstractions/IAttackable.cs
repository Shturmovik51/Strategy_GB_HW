using Abstractions;

public interface IAttackable : IHealthHolder
{
    void RecieveDamage(int amount);
    void RestoreHealth(int amount);
}