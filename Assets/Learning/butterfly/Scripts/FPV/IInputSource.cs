namespace fpv
{
    public interface IInputSource
    {
        FlightInput GetInput();
        
        event System.Action<IInputSource> OnBecameActive;
        
        
    }
}
