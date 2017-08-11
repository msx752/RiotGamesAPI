using RiotGamesApi.Enums;

namespace RiotGamesApi.Interfaces
{
    public interface IRSelectApi<T> where T : new() { IFor<T> SelectApi(LolApiName apiType, double version = 3.0); }
}