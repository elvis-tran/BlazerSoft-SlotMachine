using BlazerSoft_SlotMachine.BlazerSoft_SlotMachine_Infrastructure.Interfaces;
using BlazerSoft_SlotMachine.Models;
using BlazerSoft_SlotMachine_Infrastructure;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;


namespace BlazerSoft_SlotMachine
{
    public class SlotMachineService
    {
        private readonly IPlayerInfoRepository _playerRepository;
        private readonly IConfigurationRepository _configurationRepository;
        private int reelWidth = 5;
        private int reelHeight = 3;
        private int defaultReelWidth = 5;
        private int defaultReelHeight = 3;
        public SlotMachineService(IPlayerInfoRepository playerRepository, IConfigurationRepository configurationRepository)
        {
            _playerRepository = playerRepository;
            _configurationRepository = configurationRepository;
        }

        public SlotMachineReponse? Spin(string playerName, int bet = 5)
        {
            //If the player has enough funds, the funds are deducted and returns true
            if (_playerRepository.EnoughFunds(playerName, bet).Result)
            {
                int[,] slotReels = FillSlotReels();
                //int[,] slotReels = { { 0, 0, 0, 0, 0 },
                //                 { 1, 1, 1, 1, 1 },
                //                 { 2, 2, 2, 2, 2 }
                //};
                var winnings = TestWinLines(slotReels, bet);

                SlotMachineReponse result = new SlotMachineReponse(slotReels, winnings, _playerRepository.GetBalance(playerName));
                return result;
            }
            return null;
        }

        public async Task<bool> UpdateBalance(string playerName, int addFunds)
        {
            var player = await _playerRepository.GetPlayer(playerName);
            if (player != null)
            {
                player.UpdateBalance(addFunds);
                return await _playerRepository.UpdatePlayer(player);
            }
            else
            {
                return false;
            }
        }

        public int[,] FillSlotReels()
        {
            //Call Repository here to retrieve configuration
            //Set reelWidth and reelHeight using those values
            var slotConfiguration = _configurationRepository.GetSlotConfiguration();

            reelHeight = slotConfiguration.reelHeight;
            reelWidth = slotConfiguration.reelWidth;

            int[,] reelMatrix = new int[reelHeight, reelWidth];
            Random rand = new Random();
            for (int i = 0; i < reelWidth; i++)
            {
                for (int j = 0; j < reelHeight; j++)
                {
                    reelMatrix[i, j] = rand.Next(0, 10);
                }
            }

            return reelMatrix;
        }

        /// <summary>
        /// New Win Lines must have their own function call
        /// Those calls are then made in the below function
        /// </summary>
        /// <param name="slotReels"></param>
        /// <param name="bet"></param>
        /// <returns></returns>
        public int TestWinLines(int[,] slotReels, int bet)
        {
            int seriesValue = 0;

            seriesValue += StraightAcrossWinLine(slotReels);
            seriesValue += DiagonalDownWinLine(slotReels);

            return seriesValue * bet;
        }

        public int StraightAcrossWinLine(int[,] slotReels)
        {
            int totalConsecutiveCounts = 0;
            int consecutiveCount = 0;
            int startDigit = 0;

            //This will handle all 3 rows (Sample 1-3)
            for(int i = 0; i < reelHeight; i++)
            {
                startDigit = slotReels[i,0];
                for(int j = 1; j < reelWidth; j++)
                {
                    if(startDigit == slotReels[i,j])
                    {
                        consecutiveCount++;
                    }
                    else
                    {
                        if(consecutiveCount > 2)
                        {
                            totalConsecutiveCounts += consecutiveCount;
                        }
                    }
                }
                consecutiveCount = 0;
            }
            return totalConsecutiveCounts;
        }

        public int DiagonalDownWinLine(int[,] slotReels)
        {
            int totalConsecutiveCounts = 0;
            int consecutiveCount = 0;
            int startDigit = slotReels[0,0];
            int row = 1;
            int col = 1;
            bool goDown = true;

            // i < reelHeight-1 because the last row can't be the start point
            for(int i = 0; i < reelHeight-1;i++)
            {
                while (col < reelWidth)
                {
                    if (startDigit == slotReels[row, col])
                    {
                        consecutiveCount++;
                        col++;

                        //Hit the bottom of the Reel
                        if (row == reelHeight - 1 && goDown)
                        {
                            goDown = false;
                        }
                        //Hit the Top of the Reel
                        else if (row == 0 && !goDown)
                        {
                            goDown = true;
                        }

                        if (goDown)
                        {
                            row++;
                        }
                        else
                        {
                            row--;
                        }
                    }
                    else
                    {
                        if (consecutiveCount > 2)
                        {
                            totalConsecutiveCounts += consecutiveCount;
                        }
                        row = i+1;
                        col = 1;
                        break;
                    }
                }
            }

            return totalConsecutiveCounts;
        }
    }
}
