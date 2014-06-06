using UnityEngine;
using System.Collections;

public interface INetworkTransfer
{
	void ReceivedResponse(string response);
}
