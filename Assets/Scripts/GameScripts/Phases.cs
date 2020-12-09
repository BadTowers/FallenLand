
namespace FallenLand
{
	public enum Phases
	{
		Invalid,
		Any,
		Game_Start_Setup,

		Before_Effects_Phase,
			Before_Effects_Resolve_Subphase,
			Effects_Resolve_Subphase,
			After_Effects_Resolve_Subphase,
		After_Effects_Phase,

		Before_Town_Business_Phase,
			Before_Town_Business_Deal_Subphase,
			Town_Business_Deal,
			After_Town_Business_Deal_Subphase,

			Before_Town_Business_Resource_Production,
			Town_Business_Resource_Production,
			After_Town_Business_Resource_Production,

			Before_Town_Business_Auction_House,
			Town_Business_Auction_House,
			After_Town_Business_Auction_House,

			Before_Town_Business_Town_Events_Chart,
			Town_Business_Town_Events_Chart,
			After_Town_Business_Town_Events_Chart,

			Before_Town_Business_Financial_Sell,
			Town_Business_Financial_Sell,
			After_Town_Business_Financial_Sell,

			Before_Town_Business_Financial_Purchase,
			Town_Business_Financial_Purchase,
			After_Town_Business_Financial_Purchase,

			Before_Town_Business_Financial_Hire,
			Town_Business_Financial_Hire,
			After_Town_Business_Financial_Hire,
		After_Town_Business_Phase,

		Before_Party_Exploits_Phase,
			Before_Party_Exploits_NPCMs,
			Party_Exploits_NPCMs,
			After_Party_Exploits_NPCMs,

			Before_Party_Exploits_Party,
			Party_Exploits_Party,
			After_Party_Exploits_Party,
		After_Party_Exploits_Phase,

		Before_End_Turn_Phase,
			Before_End_Turn_Adjust_Turn_Marker,
			End_Turn_Adjust_Turn_Marker,
			After_End_Turn_Adjust_Turn_Marker,

			Before_End_Turn_Pass_First_Player,
			End_Turn_Pass_First_Player,
			After_End_Turn_Pass_First_Player,
		After_End_Turn_Phase
	}

    public class PhasesHelpers
    {
		public static string PhaseToString(Phases phase)
		{
			string toReturn = "";

			switch(phase)
            {
				case Phases.Invalid:
					toReturn = "Invalid Phase";
					break;
				case Phases.Any:
					toReturn = "Any Phase";
					break;
				case Phases.Game_Start_Setup:
					toReturn = "Game Start Setup";
					break;
				case Phases.Before_Effects_Phase:
					toReturn = "Before the Effects Phase";
					break;
				case Phases.Before_Effects_Resolve_Subphase:
					toReturn = "Before the Effects Resolve Subphase";
					break;
				case Phases.Effects_Resolve_Subphase:
					toReturn = "During the Effects Resolve Subphase";
					break;
				case Phases.After_Effects_Resolve_Subphase:
					toReturn = "After the Effects Resolve Subphase";
					break;
				case Phases.After_Effects_Phase:
					toReturn = "After the Effects Phase";
					break;
				case Phases.Before_Town_Business_Phase:
					toReturn = "Before the Town Business Phase";
					break;
				case Phases.Before_Town_Business_Deal_Subphase:
					toReturn = "Before the Town Business Deal Subphase";
					break;
				case Phases.Town_Business_Deal:
					toReturn = "During the Town Business Deal Subphase";
					break;
				case Phases.After_Town_Business_Deal_Subphase:
					toReturn = "After the Town Business Deal Subphase";
					break;
				case Phases.Before_Town_Business_Resource_Production:
					toReturn = "Before the Town Business Resource Production Subphase";
					break;
				case Phases.Town_Business_Resource_Production:
					toReturn = "During the Town Business Resource Production Subphase";
					break;
				case Phases.After_Town_Business_Resource_Production:
					toReturn = "After the Town Business Resource Production Subphase";
					break;
				case Phases.Before_Town_Business_Auction_House:
					toReturn = "Before the Town Business Auction House Subphase";
					break;
				case Phases.Town_Business_Auction_House:
					toReturn = "During the Town Business Auction House Subphase";
					break;
				case Phases.After_Town_Business_Auction_House:
					toReturn = "After the Town Business Auction House Subphase";
					break;
				case Phases.Before_Town_Business_Town_Events_Chart:
					toReturn = "Before the Town Business Town Events Chart Subphase";
					break;
                case Phases.Town_Business_Town_Events_Chart:
					toReturn = "During the Town Business Town Events Chart Subphase";
					break;
				case Phases.After_Town_Business_Town_Events_Chart:
					toReturn = "After the Town Business Town Events Chart Subphase";
					break;
				case Phases.Before_Town_Business_Financial_Sell:
					toReturn = "Before the Town Business Financial Sell Subphase";
					break;
				case Phases.Town_Business_Financial_Sell:
					toReturn = "During the Town Business Financial Sell Subphase";
					break;
				case Phases.After_Town_Business_Financial_Sell:
					toReturn = "After the Town Business Financial Sell Subphase";
					break;
				case Phases.Before_Town_Business_Financial_Purchase:
					toReturn = "Before the Town Business Financial Purchase Subphase";
					break;
				case Phases.Town_Business_Financial_Purchase:
					toReturn = "During the Town Business Financial Purchase Subphase";
					break;
				case Phases.After_Town_Business_Financial_Purchase:
					toReturn = "After the Town Business Financial Purchase Subphase";
					break;
				case Phases.Before_Town_Business_Financial_Hire:
					toReturn = "Before the Town Business Financial Hire Subphase";
					break;
				case Phases.Town_Business_Financial_Hire:
					toReturn = "During the Town Business Financial Hire Subphase";
					break;
				case Phases.After_Town_Business_Financial_Hire:
					toReturn = "After the Town Business Financial Hire Subphase";
					break;
				case Phases.After_Town_Business_Phase:
					toReturn = "After the Town Business Phase";
					break;
				case Phases.Before_Party_Exploits_Phase:
					toReturn = "Before the Party Exploits Phase";
					break;
				case Phases.Before_Party_Exploits_NPCMs:
					toReturn = "Before the Party Exploits NPCMs Subphase";
					break;
				case Phases.Party_Exploits_NPCMs:
					toReturn = "During the Party Exploits NPCMs Subphase";
					break;
				case Phases.After_Party_Exploits_NPCMs:
					toReturn = "After the Party Exploits NPCMs Subphase";
					break;
				case Phases.Before_Party_Exploits_Party:
					toReturn = "Before the Party Exploits Party Subphase";
					break;
				case Phases.Party_Exploits_Party:
					toReturn = "During the Party Exploits Party Subphase";
					break;
				case Phases.After_Party_Exploits_Party:
					toReturn = "After the Party Exploits Party Subphase";
					break;
				case Phases.After_Party_Exploits_Phase:
					toReturn = "After the Party Exploits Phase";
					break;
				case Phases.Before_End_Turn_Phase:
					toReturn = "Before the End Turn Phase";
					break;
				case Phases.Before_End_Turn_Adjust_Turn_Marker:
					toReturn = "Before the End Turn Adjust Turn Marker Subphase";
					break;
				case Phases.End_Turn_Adjust_Turn_Marker:
					toReturn = "During the End Turn Adjust Turn Marker Subphase";
					break;
				case Phases.After_End_Turn_Adjust_Turn_Marker:
					toReturn = "After the End Turn Adjust Turn Marker Subphase";
					break;
				case Phases.Before_End_Turn_Pass_First_Player:
					toReturn = "Before the End Turn Pass First Player Subphase";
					break;
				case Phases.End_Turn_Pass_First_Player:
					toReturn = "During the End Turn Pass First Player Subphase";
					break;
				case Phases.After_End_Turn_Pass_First_Player:
					toReturn = "After the End Turn Pass First Player Subphase";
					break;
				case Phases.After_End_Turn_Phase:
					toReturn = "After the End Turn Phase";
					break;
				default:
					toReturn = "Invalid Phase";
					break;
			}
			return toReturn;
		}

        public static bool IsAsyncPhase(Phases phase)
        {
			return phase == Phases.Town_Business_Auction_House || phase == Phases.Game_Start_Setup;

		}
	}
}