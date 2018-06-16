using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCreation : MonoBehaviour {

	private Faction faction; //TODO for multiplayer, this likely needs to be a list of factions or a dictionary of factions (map IP to faction)
	private GameInformation.GameModes mode;
	public List<GameInformation.GameModifier> modifiers;
	public bool wasRead = false;
	public GameInformation.SoloII soloIIDifficulty;


	void Start() {
		modifiers = new List<GameInformation.GameModifier>();
	}

	void Update(){
		if (!wasRead) {
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}

    public void setFaction(Faction f) {
        faction = f;
    }

    public Faction getFaction() {
        return faction;
    }

    public void setMode(GameInformation.GameModes m) {
        mode = m;
    }

    public GameInformation.GameModes getMode() {
        return mode;
    }
}
