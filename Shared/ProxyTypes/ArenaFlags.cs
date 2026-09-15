namespace MCELoader.Shared.ProxyTypes;

#if MCEEditor
[Flags]
public enum ArenaFlags
{
    StopWarning = 1,
    EnterAndExitSameWay = 2,
    Stealth = 4,
    OpenExit = 8,
    BikesWaitingOutsideWhileFighting = 16,
    TriggerPoliceAfter = 32,
}
#endif
