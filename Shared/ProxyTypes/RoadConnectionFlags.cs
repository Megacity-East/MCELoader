
namespace MCELoader.Shared.ProxyTypes;

#if MCEEditor
public enum RoadConnectionFlags
{
	LeftTurn = 1,
	RightTurn = 2,
	EndConnection = 4,
	StartConnection = 8,
	DiscontinueAndConnect = 16,
}
#endif
