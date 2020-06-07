
namespace FallenLand
{
	public enum Phases
	{
		Invalid,
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
			//TODO
			return phase.ToString();
		}

        public static bool IsAsyncPhase(Phases phase)
        {
			return phase == Phases.Town_Business_Auction_House;

		}
	}
}