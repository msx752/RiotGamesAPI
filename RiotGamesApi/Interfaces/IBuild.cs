using RiotGamesApi.Libraries.Enums;

namespace RiotGamesApi.Interfaces
{
    public interface IBuild<T> where T : new()
    {
        IRequestMethod<T> Build(ServicePlatform platform);

        IRequestMethod<T> Build(PhysicalRegion platform);
    }
}