using System;

namespace BlazerSoft_SlotMachine
{
	public class SlotMachineReponse
	{
		private int[,] resultMatrix;
		private int playerWinnings;
		private int currentBalance;
		public SlotMachineReponse(int[,] result, int playerWinnings, int currentBalance)
		{
			resultMatrix = result;
			this.playerWinnings = playerWinnings;
			this.currentBalance = currentBalance;
		}
	}
}