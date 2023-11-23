namespace Ohce.Services.Interfaces;

public interface IOhceService
{
    public string DoStep(string input);

    public bool ShouldStop();
}