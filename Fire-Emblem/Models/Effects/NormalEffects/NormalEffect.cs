namespace Fire_Emblem.Effects;

public abstract class NormalEffect: Effect
{

    protected int Change;
    
    

    public override int GetPriority()
    {
        return 1;
    }
    

}