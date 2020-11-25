using System;
using System.Collections.Generic;
using System.Text;

namespace Incubator
{
    class CBot
    {

        public const int MAX_DNA_SIZE = 64;
        public BotType Type;
        public List<DnaCommands> DNA;
        public int CurrentCommand;
        public int XCoord;
        public int YCoord;
        public int Health;
        public int Minerals;
        public int CRed;
        public int CGreen;
        public int CBlue;
        public BotDirect Direct;

        public CBot()
        {
            this.Type = BotType.LV_ALIVE;
            this.DNA = new List<DnaCommands>();
            this.Direct = BotDirect.Right;
            for(int i=0; i < MAX_DNA_SIZE; i++)
            {
                DNA.Add(DnaCommands.Photosynthesis);
            }

        }

        public void EatSun(Seasons currentSeason)
        {
            var t = 0;
            if (Minerals < 100)
            {
                t = 0;
            }
            else
            {
                if (Minerals < 400) t = 1;
                else t = 2;
            }

            int hlt = (int)currentSeason - ((YCoord - 1) / 6) + t;

            if (hlt > 0)
            {
                Health += hlt;
                // todo:дальше сделать бота зеленее
            }
        }
        public void NextCommand()
        {
            if (CurrentCommand == MAX_DNA_SIZE - 1)
            {
                CurrentCommand = 0;
                return;
            }
            CurrentCommand++;
        }
        public void ExecuteCommnad()
        {
            switch (DNA[CurrentCommand])
            {
                case DnaCommands.Photosynthesis:

                    break;
                case DnaCommands.ChangeDirectRel:
                    break;
                case DnaCommands.ChangeDirectAbs:
                    break;
                case DnaCommands.StepDirectRel:
                    break;
                case DnaCommands.StepDirectAbs:
                    break;
                case DnaCommands.EatDirectRel:
                    break;
                case DnaCommands.EatDirectAbs:
                    break;
                case DnaCommands.LookDirectRel:
                    break;
                case DnaCommands.LookDirectAbs:
                    break;
                case DnaCommands.DivDirectRel:
                    break;
                case DnaCommands.DivDirectAbs:
                    break;
                case DnaCommands.AligDirectRel:
                    break;
                case DnaCommands.AligDirectAbs:
                    break;
                case DnaCommands.QLevel:
                    break;
                case DnaCommands.QHealth:
                    break;
                case DnaCommands.QMinerals:
                    break;
                case DnaCommands.Div:
                    break;
                case DnaCommands.QSurrounded:
                    break;
                case DnaCommands.QAddEnergy:
                    break;
                case DnaCommands.QAddMinerals:
                    break;
                case DnaCommands.MineralsToE:
                    break;
                case DnaCommands.Mutation:
                    break;
                case DnaCommands.DnaAttac:
                    break;
            }
        }
    }
}
