namespace UnitMan
{
    public interface IUnitManager
    {
        TUnit Use<TUnit>() where TUnit : IUnit;
    }
}