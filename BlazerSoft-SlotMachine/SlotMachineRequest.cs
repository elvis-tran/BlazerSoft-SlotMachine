using System;
using System.Reflection.Metadata;

public class SlotMachineRequest
{
	private double amountBet;
	private string playerId; //Consider using Guid
	public SlotMachineRequest()
	{ amountBet = 0; }

	public SlotMachineRequest(string playerId, double amountBet)
	{
		this.playerId = playerId;
		this.amountBet = amountBet;
	}
}
