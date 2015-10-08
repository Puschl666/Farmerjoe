using UnityEngine;
using System.Collections;
using UMA;
using Newtonsoft.Json;

public class AvatarScript : MonoBehaviour {
	public UMAGeneratorBase generator;
	public SlotLibrary slotLibrary;
	public OverlayLibrary overlayLibrary;
	public RaceLibrary racelibrary;
	public RuntimeAnimatorController animController;
	
	private UMADynamicAvatar umaDynamicAvatar;
	private UMAData umaData;
	private UMADnaHumanoid umaDna;
	
	private int numberOfSlots = 20;


	//private GameObject scripts;
	//private EnergyBarHandler ebh;
	//private Userinfo ui;
	//private Public pub;

	private bool isStart = false;
	private bool isLoad = false;
	
	public string UserScript = "user.php";
	public User user = null;
	
	//public UMAData umaData;
	//public UMADynamicAvatar umaAvatar;
	public bool UMACreated;

	// Use this for initialization
	void Start () {
		//DontDestroyOnLoad(gameObject);
		//isStart = true;
		//scripts = GameObject.Find("Scripts");
		//pub = scripts.GetComponent<Public>();
		//ebh = scripts.GetComponent<EnergyBarHandler>();
		//ui = scripts.GetComponent<Userinfo>();

		LoadUser (1);
	}
	
	// Update is called once per frame
	void Update () {

		/* if (!umaCrowd && GameObject.Find ("UMA")) {
			umaCrowd = GameObject.Find ("UMA").gameObject.GetComponentInChildren<UMACrowd> ();
			UMACreated = false;
		}
		//Debug.Log(UMACreated);
		if (umaCrowd && !UMACreated) {
			umaCrowd.name = user.name + user.id;
			umaCrowd.generateUMA = true;
			UMACreated = true;
		}
		if(UMACreated && !umaData){
			umaData = umaCrowd.gameObject.GetComponentInChildren<UMAData>();
			//Debug.Log(umaData);
		}
		if (isLoad)
			Load(); */
		/* if (ebh != null) {
			if (isStart == true) {
				ebh.setMaxEnergy (user.maxEnergy);
				ebh.setEnergy (user.energy);
				ebh.Init ();
				ui.ShowUsername (user.name);
				isStart = false;
			}
		} else {
			scripts = GameObject.Find("Scripts");
			ebh = scripts.GetComponent<EnergyBarHandler> ();
			ui = scripts.GetComponent<Userinfo>();
		} */
	}
	
	public void LoadAvatar(string assetData){
		/* if (assetData != null && assetData != "{}" && umaAvatar == null) {
			umaAvatar = gameObject.AddComponent<UMADynamicAvatar>();
			umaAvatar.umaGenerator = gameObject.GetComponentInChildren<UMAGenerator>();
			umaAvatar.context = gameObject.GetComponentInChildren<UMAContext>();
			umaAvatar.animationController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Locomotion", typeof(RuntimeAnimatorController )));
			umaAvatar.umaData = gameObject.GetComponentInChildren<UMAData>();
			var asset = ScriptableObject.CreateInstance<UMATextRecipe> ();
			asset.recipeString = assetData;
			umaAvatar.Load(asset);
			Destroy (asset);
		} */
		/* isLoad = true;
		if (umaData) {
			var avatarData = umaData.gameObject.GetComponent<UMAAvatarBase> ();
			if (avatarData != null && user.asset != null && user.asset != "{}") {
				Debug.Log(user.asset);
				var asset = ScriptableObject.CreateInstance<UMATextRecipe> ();
				asset.recipeString = user.asset;
				avatarData.Load (asset);
				Destroy (asset);
				isLoad = false;
			}
			umaData = null;
		} */


		if (racelibrary != null) {
			// Generate new GameObject and add UMA components to it
			GameObject GO = new GameObject ("Player");
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
		
			GenerateAvatar ();
			umaDynamicAvatar.animationController = animController;
		
			// Generate our UMA
			umaDynamicAvatar.UpdateNewRace ();
		
			GO.transform.parent = this.gameObject.transform;
			GO.transform.localPosition = Vector3.zero;
			GO.transform.localRotation = Quaternion.identity;

			//GameObject playerCamera = GameObject.Find ("PlayerCamera");
			//playerCamera.transform.parent = GO.transform;
			//playerCamera.transform.localPosition = new Vector3 (0.0f, 1.5f, -1.285f);
			//playerCamera.transform.localRotation = Quaternion.Euler (23.0f, 0.0f, 0.0f);
		}
	}

	void GenerateAvatar() {
		// Grab a reference to our recipe
		var umaRecipe = umaDynamicAvatar.umaData.umaRecipe;
		umaRecipe.SetRace (racelibrary.GetRace("HumanFemale"));
		
		var hairColor = new Color32 (250,240,190, 1);
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
		addOverlay(3, "FemaleUnderwear01", Color.white);
		addOverlay(3, "FemaleShirt01", new Color32(0,255,255, 1));
		linkOverlay(4, "FemaleHands");
		umaData.umaRecipe.slotDataList [4].SetOverlayList (umaData.umaRecipe.slotDataList [3].GetOverlayList());
		linkOverlay(5, "FemaleLegs");
		umaData.umaRecipe.slotDataList [5].SetOverlayList (umaData.umaRecipe.slotDataList [3].GetOverlayList());
		addOverlay(5, "FemaleJeans01", new Color32(15, 74, 139, 1));
		linkOverlay(6, "FemaleFeet");
		umaData.umaRecipe.slotDataList [6].SetOverlayList (umaData.umaRecipe.slotDataList [3].GetOverlayList());
		linkOverlay(7, "FemaleLongHair01_Module");
		addOverlay(7, "FemaleLongHair01_Module", hairColor);

		umaDna.height = 0.4f;
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
	
	// Use this for initialization
	public void LoadUser (int id) {
		GameObject scripts = GameObject.Find("Scripts");
		Public pub = scripts.GetComponent<Public>();
		WWW www = new WWW(pub.URL + UserScript + "?id=" + id);
		StartCoroutine(WaitForRequest(www));
	}
	
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		
		// check for errors
		if (www.error == null)
		{
			//Debug.Log("WWW Ok!: " + www.text + " - userId: " + user.id);
			//user = new User();
			user = JsonConvert.DeserializeObject<User> (www.text);
			LoadAvatar(user.asset);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}
	}
}
