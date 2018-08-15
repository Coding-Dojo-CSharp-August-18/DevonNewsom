namespace GameFun
{
    public interface IDamageable
    {
        int Health {get;set;}
        bool TakeDamage(int dmg);
    }
}