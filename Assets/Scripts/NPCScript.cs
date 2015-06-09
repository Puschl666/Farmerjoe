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
		umaData.umaRecipe.slotDataList [0] = slotLibrary.InstantiateSlot ("FemaleEyes");
		umaData.umaRecipe.slotDataList [0].AddOverlay (overlayLibrary.InstantiateOverlay("EyeOverlay"));
		umaData.umaRecipe.slotDataList [0].AddOverlay(overlayLibrary.InstantiateOverlay("EyeOverlayAdjust", Color.blue));
		umaData.umaRecipe.slotDataList [1] = slotLibrary.InstantiateSlot ("FemaleInnerMouth");
		umaData.umaRecipe.slotDataList [1].AddOverlay (overlayLibrary.InstantiateOverlay("InnerMouth"));
		umaData.umaRecipe.slotDataList [2] = slotLibrary.InstantiateSlot ("FemaleFace");
		umaData.umaRecipe.slotDataList [2].AddOverlay (overlayLibrary.InstantiateOverlay("FemaleHead01"));
		umaData.umaRecipe.slotDataList [2].AddOverlay (overlayLibrary.InstantiateOverlay("FemaleLongHair01", hairColor));
		umaData.umaRecipe.slotDataList [2].AddOverlay (overlayLibrary.InstantiateOverlay("FemaleEyebrow01", hairColor));
		umaData.umaRecipe.slotDataList [2].AddOverlay (overlayLibrary.InstantiateOverlay("FemaleLipstick01", Color.red));
		umaData.umaRecipe.slotDataList [3] = slotLibrary.InstantiateSlot ("FemaleTorso");
		umaData.umaRecipe.slotDataList [3].AddOverlay (overlayLibrary.InstantiateOverlay("FemaleBody01"));
		umaData.umaRecipe.slotDataList [3].AddOverlay (overlayLibrary.InstantiateOverlay("FemaleUnderwear01", Color.black));
		umaData.umaRecipe.slotDataList [3].AddOverlay (overlayLibrary.InstantiateOverlay("FemaleShirt01", new Color32(255,105,180, 1)));
		umaData.umaRecipe.slotDataList [4] = slotLibrary.InstantiateSlot ("FemaleHands");
		umaData.umaRecipe.slotDataList [4].AddOverlay (overlayLibrary.InstantiateOverlay("FemaleBody01"));
		umaData.umaRecipe.slotDataList [5] = slotLibrary.InstantiateSlot ("FemaleLegs");
		umaData.umaRecipe.slotDataList [5].AddOverlay (overlayLibrary.InstantiateOverlay("FemaleBody01"));
		umaData.umaRecipe.slotDataList [5].AddOverlay (overlayLibrary.InstantiateOverlay("FemaleUnderwear01", Color.black));
		umaData.umaRecipe.slotDataList [5].AddOverlay (overlayLibrary.InstantiateOverlay("FemaleJeans01", new Color32(15, 74, 139, 1)));
		umaData.umaRecipe.slotDataList [6] = slotLibrary.InstantiateSlot ("FemaleFeet");
		umaData.umaRecipe.slotDataList [6].AddOverlay (overlayLibrary.InstantiateOverlay("FemaleBody01"));
		umaData.umaRecipe.slotDataList [7] = slotLibrary.InstantiateSlot ("FemaleLongHair01_Module");
		umaData.umaRecipe.slotDataList [7].AddOverlay (overlayLibrary.InstantiateOverlay("FemaleLongHair01_Module", hairColor));
	}
}
