using UnityEngine;
using System.Collections;
using UMA;

public class NPCScript : MonoBehaviour {

	public UMAGeneratorBase generator;
	public SlotLibrary slotLibrary;
	public OverlayLibrary overlayLibrary;
	public RaceLibrary racelibrary;
	public RuntimeAnimatorController animController;

	private UMADynamicAvatar umaDynamicAvatar;
	private UMAData umaData;
	private UMADnaHumanoid umaDna;

	private int numberOfSlots = 20;

	// Use this for initialization
	void Start () {
		GenerateUMA ();
	}

	void GenerateUMA() {
		// Generate new GameObject and add UMA components to it
		GameObject GO = new GameObject("NPC");
		umaDynamicAvatar = GO.AddComponent<UMADynamicAvatar> ();

		// Initialise Avatar and grab a reference to it's data component
		umaDynamicAvatar.Initialize ();
		umaData = umaDynamicAvatar.umaData;

		// Attach our generator
		umaDynamicAvatar.umaGenerator = generator;
		umaData.umaGenerator = generator;

		// Set up slot Array
		umaData.umaRecipe.slotDataList = new SlotData[numberOfSlots];

		// Set up our Morph references
		umaDna = new UMADnaHumanoid ();
		umaData.umaRecipe.AddDna (umaDna);

		GenerateNPC ();
		umaDynamicAvatar.animationController = animController;

		// Generate our UMA
		umaDynamicAvatar.UpdateNewRace ();

		GO.transform.parent = this.gameObject.transform;
		GO.transform.localPosition = Vector3.zero;
		GO.transform.localRotation = Quaternion.identity;
	}

	void GenerateNPC() {
		// Grab a reference to our recipe
		var umaRecipe = umaDynamicAvatar.umaData.umaRecipe;
		umaRecipe.SetRace (racelibrary.GetRace("HumanFemale"));

		var hairColor = new Color32 (165,42,42, 1);
		linkOverlay(0, "FemaleEyes");
		addOverlay(0, "EyeOverlay");
		addOverlay(0, "EyeOverlayAdjust", Color.blue);
		linkOverlay(1, "FemaleInnerMouth");
		addOverlay(1, "InnerMouth");
		linkOverlay(2, "FemaleFace");
		addOverlay(2, "FemaleHead01");
		addOverlay(2, "FemaleLongHair01", hairColor);
		addOverlay(2, "FemaleEyebrow01", hairColor);
		addOverlay(2, "FemaleLipstick01", Color.red);
		linkOverlay(3, "FemaleTorso");
		addOverlay(3, "FemaleBody01");
		addOverlay(3, "FemaleUnderwear01", Color.black);
		addOverlay(3, "FemaleShirt01", new Color32(255,105,180, 1));
		linkOverlay(4, "FemaleHands");
		umaData.umaRecipe.slotDataList [4].SetOverlayList (umaData.umaRecipe.slotDataList [3].GetOverlayList());
		linkOverlay(5, "FemaleLegs");
		umaData.umaRecipe.slotDataList [5].SetOverlayList (umaData.umaRecipe.slotDataList [3].GetOverlayList());
		addOverlay(5, "FemaleJeans01", new Color32(15, 74, 139, 1));
		linkOverlay(6, "FemaleFeet");
		umaData.umaRecipe.slotDataList [6].SetOverlayList (umaData.umaRecipe.slotDataList [3].GetOverlayList());
		linkOverlay(7, "FemaleLongHair01_Module");
		addOverlay(7, "FemaleLongHair01_Module", hairColor);
	}
	
	void linkOverlay(int slot, string name) {
		umaData.umaRecipe.slotDataList [slot] = slotLibrary.InstantiateSlot (name);
	}
	
	void addOverlay(int slot, string name) {
		umaData.umaRecipe.slotDataList [slot].AddOverlay (overlayLibrary.InstantiateOverlay(name));
	}
	
	void addOverlay(int slot, string name, Color color) {
		umaData.umaRecipe.slotDataList [slot].AddOverlay (overlayLibrary.InstantiateOverlay(name, color));
	}
	
	void removeOverlay(int slot, string name) {
		umaData.umaRecipe.slotDataList [slot].RemoveOverlay(name);
	}
	
	void colorOverlay(int slot, string name, Color color) {
		umaData.umaRecipe.slotDataList [slot].SetOverlayColor (color, name);
	}
}
