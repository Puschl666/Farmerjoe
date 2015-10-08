using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UMA;

public class CustomistionScript : MonoBehaviour {

	public UMAGeneratorBase generator;
	public SlotLibrary slotLibrary;
	public OverlayLibrary overlayLibrary;
	public RaceLibrary racelibrary;
	public RuntimeAnimatorController animController;
	
	private UMADynamicAvatar umaDynamicAvatar;
	private UMAData umaData;
	private UMADnaHumanoid umaDna;
	private UMADnaTutorial umaTutorialDna;
	
	private int numberOfSlots = 20;

	private Slider HeightSlider;
	private Slider UpperMuscleSlider;
	private Slider UpperWeightSlider;
	private Slider LowerMuscleSlider;
	private Slider LowerWeightSlider;
	private Slider ArmLengthSlider;
	private Slider ForearmLengthSlider;
	private Slider LegSeparationSlider;
	private Slider HandSizeSlider;
	private Slider FeetSizeSlider;
	private Slider LegSizeSlider;
	private Slider ArmWidthSlider;
	private Slider ForearmWidthSlider;
	private Slider BreastSlider;
	private Slider BellySlider;
	private Slider WaistSizeSlider;
	private Slider GlueteusSizeSlider;
	private Slider HeadSizeSlider;
	private Slider NeckThickSlider;
	private Slider EarSizeSlider;
	private Slider EarPositionSlider;
	private Slider EarRotationSlider;
	private Slider NoseSizeSlider;
	private Slider NoseCurveSlider;
	private Slider NoseWidthSlider;
	private Slider NoseInclinationSlider;
	private Slider NosePositionSlider;
	private Slider NosePronuncedSlider;
	private Slider NoseFlattenSlider;
	private Slider ChinSizeSlider;
	private Slider ChinPronouncedSlider;
	private Slider ChinPositionSlider;
	private Slider MandibleSizeSlider;
	private Slider JawSizeSlider;
	private Slider JawPositionSlider;
	private Slider CheekSizeSlider;
	private Slider CheekPositionSlider;
	private Slider lowCheekPronSlider;
	private Slider ForeHeadSizeSlider;
	private Slider ForeHeadPositionSlider;
	private Slider LipSizeSlider;
	private Slider MouthSlider;
	private Slider EyeSizeSlider;
	private Slider EyeRotationSlider;
	private Slider EyeSpacingSlider;
	private Slider LowCheekPosSlider;
	private Slider HeadWidthSlider;
	private Slider[] sliders;

    private Slider HairColorRSlider;
    private Slider HairColorGSlider;
    private Slider HairColorBSlider;
    private Slider ShirtColorRSlider;
    private Slider ShirtColorGSlider;
    private Slider ShirtColorBSlider;
    private Slider BeardColorRSlider;
    private Slider BeardColorGSlider;
    private Slider BeardColorBSlider;
    private Slider PantsColorRSlider;
    private Slider PantsColorGSlider;
    private Slider PantsColorBSlider;
    private Slider UnderwareColorRSlider;
    private Slider UnderwareColorGSlider;
    private Slider UnderwareColorBSlider;
    private Slider EyesColorRSlider;
    private Slider EyesColorGSlider;
    private Slider EyesColorBSlider;
    private Slider LipsColorRSlider;
    private Slider LipsColorGSlider;
    private Slider LipsColorBSlider;

    private enum Slots {
		Hair, LongHair, Beard, Underware, Shirt, Pants, Eyes, Lips
    }
    private enum ColorChanel
    {
        R, G, B
    }

    private Button MaleButton;
    private Button FemaleButton;
    private Button RandomButton;

    private bool underwareState = false;
	private bool shirtState = false;
	private bool pantsState = false;
	private bool hairState = false;
	
	private string actUnderwareName = "";
	private string actShirtName = "";
	private string actPantsName = "";
	private string actHairName = "";
    private string actLongHairName = "";
    private string actEyesName = "";
    private string actLipsName = "";

    private Button actUnderwareButton;
	private Button actShirtButton;
	private Button actPantsButton;
    private Button actHairButton;

    public Color UnderwareColor = Color.black;
	private Color lastUnderwareColor = Color.black;
	public Color ShirtColor = new Color32(255,105,180, 255);
	private Color lastShirtColor = new Color32(255,105,180, 255);
	public Color PantsColor = new Color32(15, 74, 139, 255);
	private Color lastPantsColor = new Color32(15, 74, 139, 255);
	public Color HairColor = new Color32(165, 42, 42, 255);
	private Color lastHairColor = new Color32(165, 42, 42, 255);
    public Color EyesColor = new Color32(165, 42, 42, 255);
    private Color lastEyesColor = new Color32(165, 42, 42, 255);
    public Color LipsColor = new Color32(165, 42, 42, 255);
    private Color lastLipsColor = new Color32(165, 42, 42, 255);

    //private Button Underware01Button;
	private Button FemaleShirt01Button;
	private Button FemaleShirt02Button;
	private Button FemaleTShirt01Button;
	private Button FemaleJeans01Button;
	private Button FemaleLongHair01Button;
    private Button MaleShirt01Button;
    private Button MaleJeans01Button;

    private Button HairColorButton;
    private Button BeardColorButton;
    private Button ShirtColorButton;
    private Button PantsColorButton;
    private Button UnderwareColorButton;
    private Button EyesColorButton;
    private Button LipsColorButton;

    private RectTransform HairColorPanel;
    private RectTransform BeardColorPanel;
    private RectTransform ShirtColorPanel;
    private RectTransform PantsColorPanel;
    private RectTransform UnderwareColorPanel;
    private RectTransform EyesColorPanel;
    private RectTransform LipsColorPanel;

    private Hashtable States = new Hashtable();

	public Color c;
	public LayerMask colorLayer;
	
	void Awake()
	{
		// get the sliders and store for later use
		HeightSlider = GameObject.Find("HeightSlider").GetComponent<Slider>();
		UpperMuscleSlider = GameObject.Find("UpperMuscleSlider").GetComponent<Slider>();
		UpperWeightSlider = GameObject.Find("UpperWeightSlider").GetComponent<Slider>();
		LowerMuscleSlider = GameObject.Find("LowerMuscleSlider").GetComponent<Slider>();
		LowerWeightSlider = GameObject.Find("LowerWeightSlider").GetComponent<Slider>();
		ArmLengthSlider = GameObject.Find("ArmLengthSlider").GetComponent<Slider>();
		ForearmLengthSlider = GameObject.Find("ForearmLengthSlider").GetComponent<Slider>();
		LegSeparationSlider = GameObject.Find("LegSepSlider").GetComponent<Slider>();
		HandSizeSlider = GameObject.Find("HandSizeSlider").GetComponent<Slider>();
		FeetSizeSlider = GameObject.Find("FeetSizeSlider").GetComponent<Slider>();
		LegSizeSlider = GameObject.Find("LegSizeSlider").GetComponent<Slider>();
		ArmWidthSlider = GameObject.Find("ArmWidthSlider").GetComponent<Slider>();
		ForearmWidthSlider = GameObject.Find("ForearmWidthSlider").GetComponent<Slider>();
		BreastSlider = GameObject.Find("BreastSizeSlider").GetComponent<Slider>();
		BellySlider = GameObject.Find("BellySlider").GetComponent<Slider>();
		WaistSizeSlider = GameObject.Find("WaistSizeSlider").GetComponent<Slider>();
		GlueteusSizeSlider = GameObject.Find("GluteusSlider").GetComponent<Slider>();
		HeadSizeSlider = GameObject.Find("HeadSizeSlider").GetComponent<Slider>();
		HeadWidthSlider = GameObject.Find("HeadWidthSlider").GetComponent<Slider>();
		NeckThickSlider = GameObject.Find("NeckSlider").GetComponent<Slider>();
		EarSizeSlider = GameObject.Find("EarSizeSlider").GetComponent<Slider>();
		EarPositionSlider = GameObject.Find("EarPosSlider").GetComponent<Slider>();
		EarRotationSlider = GameObject.Find("EarRotSlider").GetComponent<Slider>();
		NoseSizeSlider = GameObject.Find("NoseSizeSlider").GetComponent<Slider>();
		NoseCurveSlider = GameObject.Find("NoseCurveSlider").GetComponent<Slider>();
		NoseWidthSlider = GameObject.Find("NoseWidthSlider").GetComponent<Slider>();
		NoseInclinationSlider = GameObject.Find("NoseInclineSlider").GetComponent<Slider>();
		NosePositionSlider = GameObject.Find("NosePosSlider").GetComponent<Slider>();
		NosePronuncedSlider = GameObject.Find("NosePronSlider").GetComponent<Slider>();
		NoseFlattenSlider = GameObject.Find("NoseFlatSlider").GetComponent<Slider>();
		ChinSizeSlider = GameObject.Find("ChinSizeSlider").GetComponent<Slider>();
		ChinPronouncedSlider = GameObject.Find("ChinPronSlider").GetComponent<Slider>();
		ChinPositionSlider = GameObject.Find("ChinPosSlider").GetComponent<Slider>();
		MandibleSizeSlider = GameObject.Find("MandibleSizeSlider").GetComponent<Slider>();
		JawSizeSlider = GameObject.Find("JawSizeSlider").GetComponent<Slider>();
		JawPositionSlider = GameObject.Find("JawPosSlider").GetComponent<Slider>();
		CheekSizeSlider = GameObject.Find("CheekSizeSlider").GetComponent<Slider>();
		CheekPositionSlider = GameObject.Find("CheekPosSlider").GetComponent<Slider>();
		lowCheekPronSlider = GameObject.Find("LowCheekPronSlider").GetComponent<Slider>();
		ForeHeadSizeSlider = GameObject.Find("ForeheadSizeSlider").GetComponent<Slider>();
		ForeHeadPositionSlider = GameObject.Find("ForeheadPosSlider").GetComponent<Slider>();
		LipSizeSlider = GameObject.Find("LipSizeSlider").GetComponent<Slider>();
		MouthSlider = GameObject.Find("MouthSizeSlider").GetComponent<Slider>();
		EyeSizeSlider = GameObject.Find("EyeSizeSlider").GetComponent<Slider>();
		EyeRotationSlider = GameObject.Find("EyeRotSlider").GetComponent<Slider>();
		EyeSpacingSlider = GameObject.Find("EyeSpaceSlider").GetComponent<Slider>();
		LowCheekPosSlider = GameObject.Find("LowCheekPosSlider").GetComponent<Slider>();
        
        MaleButton = GameObject.Find("MaleButton").GetComponent<Button>();
        FemaleButton = GameObject.Find("FemaleButton").GetComponent<Button>();
        RandomButton = GameObject.Find("RandomButton").GetComponent<Button>();

        // get the buttons and store for later use
        //Underware01Button = GameObject.Find("Underware01Button").GetComponent<Button>();
        FemaleShirt01Button = GameObject.Find("FemaleShirt01Button").GetComponent<Button>();
        FemaleShirt02Button = GameObject.Find("FemaleShirt02Button").GetComponent<Button>();
        FemaleTShirt01Button = GameObject.Find("FemaleTShirt01Button").GetComponent<Button>();
        FemaleJeans01Button = GameObject.Find("FemaleJeans01Button").GetComponent<Button>();
		FemaleLongHair01Button = GameObject.Find("FemaleLongHair01Button").GetComponent<Button>();
        MaleShirt01Button = GameObject.Find("MaleShirt01Button").GetComponent<Button>();
        MaleJeans01Button = GameObject.Find("MaleJeans01Button").GetComponent<Button>();

        // Initialize the States of all used Overlays
        States["FemaleShirt01"] = "false";
		States["FemaleShirt02"] = "false";
		States["FemaleTshirt01"] = "false";
		States["FemaleUnderwear01"] = "false";
		States["FemaleJeans01"] = "false";
		States["FemaleLongHair01"] = "false";
        States["MaleShirt01"] = "false";
        States["MaleJeans01"] = "false";
    }
	
	// Use this for initialization
	void Start () {
		GenerateUMA ();
	}

    void initializeColorPanel(string name, Color color, ref Button button, ref RectTransform panel, ref Slider rSliter, ref Slider gSlider, ref Slider bSlider)
    {
        button = GameObject.Find(name + "ColorButton").GetComponent<Button>();
        var colors = button.colors;
        colors.normalColor = color;
        colors.disabledColor = color;
        colors.highlightedColor = color;
        colors.pressedColor = color;
        button.colors = colors;

        if (panel == null)
        {
            panel = GameObject.Find(name + "ColorPanel").GetComponent<RectTransform>();
        }
        panel.gameObject.SetActive(false);
        panel.transform.Find("ColorPanel").GetComponent<Image>().color = color;
        rSliter = panel.transform.Find("R-Slider").GetComponent<Slider>();
        rSliter.value = color.r;
        rSliter.transform.Find("Value").gameObject.GetComponent<Text>().text = (color.r * 255).ToString("F0");
        gSlider = panel.transform.Find("G-Slider").GetComponent<Slider>();
        gSlider.value = color.g;
        gSlider.transform.Find("Value").gameObject.GetComponent<Text>().text = (color.g * 255).ToString("F0");
        bSlider = panel.transform.Find("B-Slider").GetComponent<Slider>();
        bSlider.value = color.b;
        bSlider.transform.Find("Value").gameObject.GetComponent<Text>().text = (color.b * 255).ToString("F0");
    }
	
	void GenerateUMA() {
		// Generate new GameObject and add UMA components to it
		GameObject GO = new GameObject("CustomAvatar");
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
        umaDna = new UMADnaHumanoid();
        umaData.umaRecipe.AddDna(umaDna);

        //GenerateMale();
        //GenerateFemale();
        OnRandomGenderChanged();
        if (umaTutorialDna != null)
			EyeSpacingSlider.interactable = true;
		else
			EyeSpacingSlider.interactable = false;
		SetSliders();
		umaDynamicAvatar.animationController = animController;
		
		// Generate our UMA
		umaDynamicAvatar.UpdateNewRace ();
		
		GO.transform.parent = this.gameObject.transform;
		GO.transform.localPosition = Vector3.zero;
		GO.transform.localRotation = Quaternion.identity;
	}
	
	void GenerateNPC() {
        UnderwareColor = Color.black;
        ShirtColor = new Color32(255, 105, 180, 255);
        PantsColor = new Color32(15, 74, 139, 255);
        HairColor = new Color32(165, 42, 42, 255);
        EyesColor = Color.blue;
        LipsColor = Color.red;

        initializePanels();

        // Grab a reference to our recipe
        var umaRecipe = umaDynamicAvatar.umaData.umaRecipe;
		umaRecipe.SetRace (racelibrary.GetRace ("HumanFemale"));

		SetSlot(0, "FemaleEyes");
		addOverlay(0, "EyeOverlay");
		addOverlay(0, "EyeOverlayAdjust", EyesColor, (int)Slots.Eyes);
		SetSlot(1, "FemaleInnerMouth");
		addOverlay(1, "InnerMouth");
		SetSlot(2, "FemaleFace");
		addOverlay(2, "FemaleHead01");
		addOverlay(2, "FemaleEyebrow01", HairColor);
		addOverlay(2, "FemaleLipstick01", LipsColor, (int)Slots.Lips);
		SetSlot(3, "FemaleTorso");
		addOverlay(3, "FemaleBody01");
        addOverlay(3, "FemaleUnderwear01", UnderwareColor, (int)Slots.Underware);
        addOverlayWithButton(3, "FemaleShirt01", ref ShirtColor, ref FemaleShirt01Button, ref shirtState, (int)Slots.Shirt);
		SetSlot(4, "FemaleHands");
		linkOverlay(4, 3);
		SetSlot(5, "FemaleLegs");
		linkOverlay(5, 3);
		addOverlayWithButton(5, "FemaleJeans01", ref PantsColor, ref FemaleJeans01Button, ref pantsState, (int)Slots.Pants);
		SetSlot(6, "FemaleFeet");
		linkOverlay(6, 3);
		SetSlot(7, "FemaleLongHair01");
		addOverlayWithButton(7, "FemaleLongHair01", ref HairColor, ref FemaleLongHair01Button, ref hairState, (int)Slots.Hair);
		SetSlot(8, "FemaleLongHair01_Module");
		addOverlay(8, "FemaleLongHair01_Module", HairColor, (int)Slots.LongHair);
    }

    void GenerateFemale()
    {
        SetButtonInactive(ref MaleButton);
        SetButtonActive(ref FemaleButton);
        SetOverlayButtonsActive(true);

        initializeRandomColors();
        initializePanels();

        // Grab a reference to our recipe
        var umaRecipe = umaDynamicAvatar.umaData.umaRecipe;
        umaRecipe.SetRace(racelibrary.GetRace("HumanFemale"));
        
        if (actEyesName != "") { removeOverlay(0, actEyesName); }
        SetSlot(0, "FemaleEyes");
        addOverlay(0, "EyeOverlay");
        addOverlay(0, "EyeOverlayAdjust", EyesColor, (int)Slots.Eyes);
        SetSlot(1, "FemaleInnerMouth");
        addOverlay(1, "InnerMouth");
        SetSlot(2, "FemaleFace");
        addOverlay(2, "FemaleHead01");
        addOverlay(2, "FemaleEyebrow01", HairColor);
        if (actLipsName != "") { removeOverlay(2, actLipsName); }
        addOverlay(2, "FemaleLipstick01", LipsColor, (int)Slots.Lips);
        SetSlot(3, "FemaleTorso");
        addOverlay(3, "FemaleBody01");
        if (actUnderwareName != "") { removeOverlay(3, actUnderwareName); }
        addOverlay(3, "FemaleUnderwear01", UnderwareColor, (int)Slots.Underware);
        if (actShirtName != "") { removeOverlayWithButton(3, actShirtName, ref actShirtButton, ref shirtState); }
        addOverlayWithButton(3, "FemaleShirt01", ref ShirtColor, ref FemaleShirt01Button, ref shirtState, (int)Slots.Shirt);
        SetSlot(4, "FemaleHands");
        linkOverlay(4, 3);
        SetSlot(5, "FemaleLegs");
        linkOverlay(5, 3);
        if (actPantsName != "") { removeOverlayWithButton(5, actPantsName, ref actPantsButton, ref pantsState); }
        addOverlayWithButton(5, "FemaleJeans01", ref PantsColor, ref FemaleJeans01Button, ref pantsState, (int)Slots.Pants);
        SetSlot(6, "FemaleFeet");
        linkOverlay(6, 3);
        SetSlot(7, "FemaleLongHair01");
        if (actHairName != "") { removeOverlayWithButton(7, actHairName, ref actHairButton, ref hairState); }
        addOverlayWithButton(7, "FemaleLongHair01", ref HairColor, ref FemaleLongHair01Button, ref hairState, (int)Slots.Hair);
        SetSlot(8, "FemaleLongHair01_Module");
        if (actLongHairName != "") { removeOverlay(8, actLongHairName); }
        addOverlay(8, "FemaleLongHair01_Module", HairColor, (int)Slots.LongHair);
    }

    void GenerateMale()
    {
        SetButtonInactive(ref FemaleButton);
        SetButtonActive(ref MaleButton);
        SetOverlayButtonsActive(false);

        initializeRandomColors();
        initializePanels();

        // Grab a reference to our recipe
        var umaRecipe = umaDynamicAvatar.umaData.umaRecipe;
        umaRecipe.SetRace(racelibrary.GetRace("HumanMale"));

        if (actEyesName != "") { removeOverlay(0, actEyesName); }
        SetSlot(0, "MaleEyes");
        addOverlay(0, "EyeOverlay");
        addOverlay(0, "EyeOverlayAdjust", EyesColor, (int)Slots.Eyes);
        SetSlot(1, "MaleInnerMouth");
        addOverlay(1, "InnerMouth");
        SetSlot(2, "MaleFace");
        addOverlay(2, "MaleHead01");
        addOverlay(2, "MaleEyebrow01", HairColor);
        if (actLipsName != "") { removeOverlay(2, actLipsName); }
        //addOverlay(2, "FemaleLipstick01", LipsColor, (int)Slots.Lips);
        SetSlot(3, "MaleTorso");
        addOverlay(3, "MaleBody01");
        if (actUnderwareName != "") { removeOverlay(3, actUnderwareName); }
        addOverlay(3, "MaleUnderwear01", UnderwareColor, (int)Slots.Underware);
        if (actShirtName != "") { removeOverlayWithButton(3, actShirtName, ref actShirtButton, ref shirtState); }
        addOverlayWithButton(3, "MaleShirt01", ref ShirtColor, ref MaleShirt01Button, ref shirtState, (int)Slots.Shirt);
        SetSlot(4, "MaleHands");
        linkOverlay(4, 3);
        SetSlot(5, "MaleLegs");
        linkOverlay(5, 3);
        if (actPantsName != "") { removeOverlayWithButton(5, actPantsName, ref actPantsButton, ref pantsState); }
        addOverlayWithButton(5, "MaleJeans01", ref PantsColor, ref MaleJeans01Button, ref pantsState, (int)Slots.Pants);
        SetSlot(6, "MaleFeet");
        linkOverlay(6, 3);
        //SetSlot(7, "FemaleLongHair01");
        if (actHairName != "") { removeOverlayWithButton(7, actHairName, ref actHairButton, ref hairState); }
        //addOverlayWithButton(7, "FemaleLongHair01", ref HairColor, ref FemaleLongHair01Button, ref hairState, (int)Slots.Hair);
        //SetSlot(8, "FemaleLongHair01_Module");
        if (actLongHairName != "") { removeOverlay(8, actLongHairName); }
        //addOverlay(8, "FemaleLongHair01_Module", HairColor, (int)Slots.LongHair);
    }

    void initializeRandomColors()
    {
        UnderwareColor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        ShirtColor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        PantsColor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        HairColor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        EyesColor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        LipsColor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
    }

    void initializePanels()
    {
        initializeColorPanel("Hair", HairColor, ref HairColorButton, ref HairColorPanel, ref HairColorRSlider, ref HairColorGSlider, ref HairColorBSlider);
        //initializeColorPanel("Beard", BeardColor, ref BeardColorButton, ref BeardColorPanel, ref BeardColorRSlider, ref BeardColorGSlider, ref BeardColorBSlider);
        initializeColorPanel("Shirt", ShirtColor, ref ShirtColorButton, ref ShirtColorPanel, ref ShirtColorRSlider, ref ShirtColorGSlider, ref ShirtColorBSlider);
        initializeColorPanel("Pants", PantsColor, ref PantsColorButton, ref PantsColorPanel, ref PantsColorRSlider, ref PantsColorGSlider, ref PantsColorBSlider);
        initializeColorPanel("Underware", UnderwareColor, ref UnderwareColorButton, ref UnderwareColorPanel, ref UnderwareColorRSlider, ref UnderwareColorGSlider, ref UnderwareColorBSlider);
        initializeColorPanel("Eyes", EyesColor, ref EyesColorButton, ref EyesColorPanel, ref EyesColorRSlider, ref EyesColorGSlider, ref EyesColorBSlider);
        initializeColorPanel("Lips", LipsColor, ref LipsColorButton, ref LipsColorPanel, ref LipsColorRSlider, ref LipsColorGSlider, ref LipsColorBSlider);
    }

    void SetOverlayButtonsActive(bool isFemale)
    {
        FemaleShirt01Button.gameObject.SetActive(isFemale);
        FemaleShirt02Button.gameObject.SetActive(isFemale);
        FemaleTShirt01Button.gameObject.SetActive(isFemale);
        FemaleJeans01Button.gameObject.SetActive(isFemale);
        FemaleLongHair01Button.gameObject.SetActive(isFemale);
        MaleShirt01Button.gameObject.SetActive(!isFemale);
        MaleJeans01Button.gameObject.SetActive(!isFemale);
    }

    void linkOverlay(int slot, int slotToLink) {
		umaData.umaRecipe.slotDataList [slot].SetOverlayList (umaData.umaRecipe.slotDataList [slotToLink].GetOverlayList());
	}

	void addOverlay(int slot, string name) {
		umaData.umaRecipe.slotDataList [slot].AddOverlay (overlayLibrary.InstantiateOverlay(name));
	}
	
	void addOverlay(int slot, string name, Color color) {
        //Debug.Log ("addOverlay: " + name + ", " + color);
        umaData.umaRecipe.slotDataList [slot].AddOverlay (overlayLibrary.InstantiateOverlay(name, color));
    }

    void addOverlay(int slot, string name, Color color, int globalSlot)
    {
        //Debug.Log ("addOverlay: " + name + ", " + color);
        if (globalSlot == (int)Slots.LongHair)
        {
            actLongHairName = name;
        }
        else if (globalSlot == (int)Slots.Eyes)
        {
            actEyesName = name;
        }
        else if (globalSlot == (int)Slots.Lips)
        {
            actLipsName = name;
        }
        else if (globalSlot == (int)Slots.Underware)
        {
            actUnderwareName = name;
        }
            umaData.umaRecipe.slotDataList[slot].AddOverlay(overlayLibrary.InstantiateOverlay(name, color));
    }

    void removeOverlay(int slot, string name) {
		//Debug.Log ("removeOverlay: " + name);
		umaData.umaRecipe.slotDataList [slot].RemoveOverlay(name);
	}

	void colorOverlay(int slot, string name, Color color) {
		umaData.umaRecipe.slotDataList [slot].SetOverlayColor (color, name);
	}

	void addOverlayWithButton(int slot, string name, ref Color color, ref Button button, ref bool globalState, int globalSlot) {
		//Debug.Log ("addOverlayWithButton: " + name + ", state: " + States [name] + ", button: " + button.name + ", globalState: " + globalState + ", globalSlot: " + globalSlot);
		addOverlay(slot, name, color);
		if (globalSlot == (int)Slots.Underware) {
			actUnderwareName = name;
			actUnderwareButton = button;
			if (shirtState == true) {
				removeOverlay(slot, actShirtName);
				addOverlay(slot, actShirtName, ShirtColor);
			}
			if (pantsState == true) {
				removeOverlay(slot, actPantsName);
				addOverlay(slot, actPantsName, PantsColor);
			}
		} else if (globalSlot == (int)Slots.Shirt) {
			if (shirtState == true) {
				removeOverlayWithButton(slot, actShirtName, ref actShirtButton, ref globalState);
			}
			actShirtName = name;
			actShirtButton = button;
		} else if (globalSlot == (int)Slots.Pants) {
			actPantsName = name;
			actPantsButton = button;
        } else if (globalSlot == (int)Slots.Hair) {
            actHairName = name;
            actHairButton = button;
        }
        States [name] = "true";
		globalState = true;
        SetButtonActive(ref button);
    }
	
	void removeOverlayWithButton(int slot, string name, ref Button button, ref bool globalState) {
		//Debug.Log ("removeOverlayWithButton: " + name + ", state: " + States [name] + ", button: " + button.name + ", globalState: " + globalState);
		removeOverlay(slot, name);
		States [name] = "false";
		globalState = false;
        SetButtonInactive(ref button);
    }

	void SetSlot(int number, string name) {
		umaData.umaRecipe.slotDataList [number] = slotLibrary.InstantiateSlot (name);
	}
	
	void RemoveSlot(int number) {
		umaData.umaRecipe.slotDataList [number] = null;
	}

    void SetButtonActive(ref Button button)
    {
        var colors = button.colors;
        colors.normalColor = new Color32(194, 248, 253, 255);
        button.colors = colors;
    }

    void SetButtonInactive(ref Button button)
    {
        var colors = button.colors;
        colors.normalColor = Color.white;
        button.colors = colors;
    }

    public void SetSliders()
	{
		HeightSlider.value = umaDna.height;
		HeightSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.height.ToString("F2");
		UpperMuscleSlider.value = umaDna.upperMuscle;
		UpperMuscleSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.upperMuscle.ToString("F2");
		UpperWeightSlider.value = umaDna.upperWeight;
		UpperWeightSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.upperWeight.ToString("F2");
		LowerMuscleSlider.value = umaDna.lowerMuscle;
		LowerMuscleSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.lowerMuscle.ToString("F2");
		LowerWeightSlider.value = umaDna.lowerWeight;
		LowerWeightSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.lowerWeight.ToString("F2");
		ArmLengthSlider.value = umaDna.armLength;
		ArmLengthSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.armLength.ToString("F2");
		ForearmLengthSlider.value = umaDna.forearmLength;
		ForearmLengthSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.forearmLength.ToString("F2");
		LegSeparationSlider.value = umaDna.legSeparation;
		LegSeparationSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.legSeparation.ToString("F2");
		HandSizeSlider.value = umaDna.handsSize;
		HandSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.handsSize.ToString("F2");
		FeetSizeSlider.value = umaDna.feetSize;
		FeetSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.feetSize.ToString("F2");
		LegSizeSlider.value = umaDna.legsSize;
		LegSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.legsSize.ToString("F2");
		ArmWidthSlider.value = umaDna.armWidth;
		ArmWidthSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.armWidth.ToString("F2");
		ForearmWidthSlider.value = umaDna.forearmWidth;
		ForearmWidthSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.forearmWidth.ToString("F2");
		BreastSlider.value = umaDna.breastSize;
		BreastSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.breastSize.ToString("F2");
		BellySlider.value = umaDna.belly;
		BellySlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.belly.ToString("F2");
		WaistSizeSlider.value = umaDna.waist;
		WaistSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.waist.ToString("F2");
		GlueteusSizeSlider.value = umaDna.gluteusSize;
		GlueteusSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.gluteusSize.ToString("F2");
		HeadSizeSlider.value = umaDna.headSize;
		HeadSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.headSize.ToString("F2");
		HeadWidthSlider.value = umaDna.headWidth;
		HeadWidthSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.headWidth.ToString("F2");
		NeckThickSlider.value = umaDna.neckThickness;
		NeckThickSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.neckThickness.ToString("F2");
		EarSizeSlider.value = umaDna.earsSize;
		EarSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.earsSize.ToString("F2");
		EarPositionSlider.value = umaDna.earsPosition;
		EarPositionSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.earsPosition.ToString("F2");
		EarRotationSlider.value = umaDna.earsRotation;
		EarRotationSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.earsRotation.ToString("F2");
		NoseSizeSlider.value = umaDna.noseSize;
		NoseSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.noseSize.ToString("F2");
		NoseCurveSlider.value = umaDna.noseCurve;
		NoseCurveSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.noseCurve.ToString("F2");
		NoseWidthSlider.value = umaDna.noseWidth;
		NoseWidthSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.noseWidth.ToString("F2");
		NoseInclinationSlider.value = umaDna.noseInclination;
		NoseInclinationSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.noseInclination.ToString("F2");
		NosePositionSlider.value = umaDna.nosePosition;
		NosePositionSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.nosePosition.ToString("F2");
		NosePronuncedSlider.value = umaDna.nosePronounced;
		NosePronuncedSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.nosePronounced.ToString("F2");
		NoseFlattenSlider.value = umaDna.noseFlatten;
		NoseFlattenSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.noseFlatten.ToString("F2");
		ChinSizeSlider.value = umaDna.chinSize;
		ChinSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.chinSize.ToString("F2");
		ChinPronouncedSlider.value = umaDna.chinPronounced;
		ChinPronouncedSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.chinPronounced.ToString("F2");
		ChinPositionSlider.value = umaDna.chinPosition;
		ChinPositionSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.chinPosition.ToString("F2");
		MandibleSizeSlider.value = umaDna.mandibleSize;
		MandibleSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.mandibleSize.ToString("F2");
		JawSizeSlider.value = umaDna.jawsSize;
		JawSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.jawsSize.ToString("F2");
		JawPositionSlider.value = umaDna.jawsPosition;
		JawPositionSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.jawsPosition.ToString("F2");
		CheekSizeSlider.value = umaDna.cheekSize;
		CheekSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.cheekSize.ToString("F2");
		CheekPositionSlider.value = umaDna.cheekPosition;
		CheekPositionSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.cheekPosition.ToString("F2");
		lowCheekPronSlider.value = umaDna.lowCheekPronounced;
		lowCheekPronSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.lowCheekPronounced.ToString("F2");
		ForeHeadSizeSlider.value = umaDna.foreheadSize;
		ForeHeadSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.foreheadSize.ToString("F2");
		ForeHeadPositionSlider.value = umaDna.foreheadPosition;
		ForeHeadPositionSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.foreheadPosition.ToString("F2");
		LipSizeSlider.value = umaDna.lipsSize;
		LipSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.lipsSize.ToString("F2");
		MouthSlider.value = umaDna.mouthSize;
		MouthSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.mouthSize.ToString("F2");
		EyeSizeSlider.value = umaDna.eyeSize;
		EyeSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.eyeSize.ToString("F2");
		EyeRotationSlider.value = umaDna.eyeRotation;
		EyeRotationSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.eyeRotation.ToString("F2");
		LowCheekPosSlider.value = umaDna.lowCheekPosition;
		LowCheekPosSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = umaDna.lowCheekPosition.ToString("F2");
		if (umaTutorialDna != null) {
			EyeSpacingSlider.value = umaTutorialDna.eyeSpacing; 
			EyeSpacingSlider.transform.Find ("ValueText").gameObject.GetComponent<Text> ().text = umaTutorialDna.eyeSpacing.ToString ("F2");
		}
	}
	
	public void UpdateUMAAtlas()
	{
		if (umaData != null)
		{
			umaData.isTextureDirty = true;
			umaData.Dirty();
		}
	}
	
	public void UpdateUMAShape()
	{
		if (umaData != null)
		{
			umaData.isShapeDirty = true;
			umaData.Dirty();
		}
	}

	// Slider callbacks 
	public void OnHeightChange() { if (umaDna != null) umaDna.height = HeightSlider.value; HeightSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = HeightSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnUpperMuscleChange() { if (umaDna != null) umaDna.upperMuscle = UpperMuscleSlider.value; UpperMuscleSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = UpperMuscleSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnUpperWeightChange() { if (umaDna != null) umaDna.upperWeight = UpperWeightSlider.value; UpperWeightSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = UpperWeightSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnLowerMuscleChange() { if (umaDna != null) umaDna.lowerMuscle = LowerMuscleSlider.value; LowerMuscleSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = LowerMuscleSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnLowerWeightChange() { if (umaDna != null) umaDna.lowerWeight = LowerWeightSlider.value; LowerWeightSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = LowerWeightSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnArmLengthChange() { if (umaDna != null) umaDna.armLength = ArmLengthSlider.value; ArmLengthSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = ArmLengthSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnForearmLengthChange() { if (umaDna != null) umaDna.forearmLength = ForearmLengthSlider.value; ForearmLengthSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = ForearmLengthSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnLegSeparationChange() { if (umaDna != null) umaDna.legSeparation = LegSeparationSlider.value; LegSeparationSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = LegSeparationSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnHandSizeChange() { if (umaDna != null) umaDna.handsSize = HandSizeSlider.value; HandSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = HandSizeSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnFootSizeChange() { if (umaDna != null) umaDna.feetSize = FeetSizeSlider.value; FeetSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = FeetSizeSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnLegSizeChange() { if (umaDna != null) umaDna.legsSize = LegSizeSlider.value; LegSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = LegSizeSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnArmWidthChange() { if (umaDna != null) umaDna.armWidth = ArmWidthSlider.value; ArmWidthSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = ArmWidthSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnForearmWidthChange() { if (umaDna != null) umaDna.forearmWidth = ForearmWidthSlider.value; ForearmWidthSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = ForearmWidthSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnBreastSizeChange() { if (umaDna != null) umaDna.breastSize = BreastSlider.value; BreastSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = BreastSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnBellySizeChange() { if (umaDna != null) umaDna.belly = BellySlider.value; BellySlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = BellySlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnWaistSizeChange() { if (umaDna != null) umaDna.waist = WaistSizeSlider.value; WaistSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = WaistSizeSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnGluteusSizeChange() { if (umaDna != null) umaDna.gluteusSize = GlueteusSizeSlider.value; GlueteusSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = GlueteusSizeSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnHeadSizeChange() { if (umaDna != null) umaDna.headSize = HeadSizeSlider.value; HeadSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = HeadSizeSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnHeadWidthChange() { if (umaDna != null) umaDna.headWidth = HeadWidthSlider.value; HeadWidthSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = HeadWidthSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnNeckThicknessChange() { if (umaDna != null) umaDna.neckThickness = NeckThickSlider.value; NeckThickSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = NeckThickSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnEarSizeChange() { if (umaDna != null) umaDna.earsSize = EarSizeSlider.value; EarSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = EarSizeSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnEarPositionChange() { if (umaDna != null) umaDna.earsPosition = EarPositionSlider.value; EarPositionSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = EarPositionSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnEarRotationChange() { if (umaDna != null) umaDna.earsRotation = EarRotationSlider.value; EarRotationSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = EarRotationSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnNoseSizeChange() { if (umaDna != null) umaDna.noseSize = NoseSizeSlider.value; NoseSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = NoseSizeSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnNoseCurveChange() { if (umaDna != null) umaDna.noseCurve = NoseCurveSlider.value; NoseCurveSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = NoseCurveSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnNoseWidthChange() { if (umaDna != null) umaDna.noseWidth = NoseWidthSlider.value; NoseWidthSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = NoseWidthSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnNoseInclinationChange() { if (umaDna != null) umaDna.noseInclination = NoseInclinationSlider.value; NoseInclinationSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = NoseInclinationSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnNosePositionChange() { if (umaDna != null) umaDna.nosePosition = NosePositionSlider.value; NosePositionSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = NosePositionSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnNosePronouncedChange() { if (umaDna != null) umaDna.nosePronounced = NosePronuncedSlider.value; NosePronuncedSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = NosePronuncedSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnNoseFlattenChange() { if (umaDna != null) umaDna.noseFlatten = NoseFlattenSlider.value; NoseFlattenSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = NoseFlattenSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnChinSizeChange() { if (umaDna != null) umaDna.chinSize = ChinSizeSlider.value; ChinSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = ChinSizeSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnChinPronouncedChange() { if (umaDna != null) umaDna.chinPronounced = ChinPronouncedSlider.value; ChinPronouncedSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = ChinPronouncedSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnChinPositionChange() { if (umaDna != null) umaDna.chinPosition = ChinPositionSlider.value; ChinPositionSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = ChinPositionSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnMandibleSizeChange() { if (umaDna != null) umaDna.mandibleSize = MandibleSizeSlider.value; MandibleSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = MandibleSizeSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnJawSizeChange() { if (umaDna != null) umaDna.jawsSize = JawSizeSlider.value; JawSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = JawSizeSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnJawPositionChange() { if (umaDna != null) umaDna.jawsPosition = JawPositionSlider.value; JawPositionSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = JawPositionSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnCheekSizeChange() { if (umaDna != null) umaDna.cheekSize = CheekSizeSlider.value; CheekSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = CheekSizeSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnCheekPositionChange() { if (umaDna != null) umaDna.cheekPosition = CheekPositionSlider.value; CheekPositionSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = CheekPositionSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnCheekLowPronouncedChange() { if (umaDna != null) umaDna.lowCheekPronounced = lowCheekPronSlider.value; lowCheekPronSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = lowCheekPronSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnForeheadSizeChange() { if (umaDna != null) umaDna.foreheadSize = ForeHeadSizeSlider.value; ForeHeadSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = ForeHeadSizeSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnForeheadPositionChange() { if (umaDna != null) umaDna.foreheadPosition = ForeHeadPositionSlider.value; ForeHeadPositionSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = ForeHeadPositionSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnLipSizeChange() { if (umaDna != null) umaDna.lipsSize = LipSizeSlider.value; LipSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = LipSizeSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnMouthSizeChange() { if (umaDna != null) umaDna.mouthSize = MouthSlider.value; MouthSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = MouthSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnEyeSizechange() { if (umaDna != null) umaDna.eyeSize = EyeSizeSlider.value; EyeSizeSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = EyeSizeSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnEyeRotationChange() { if (umaDna != null) umaDna.eyeRotation = EyeRotationSlider.value; EyeRotationSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = EyeRotationSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnLowCheekPositionChange() { if (umaDna != null) umaDna.lowCheekPosition = LowCheekPosSlider.value; LowCheekPosSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = LowCheekPosSlider.value.ToString("F2"); UpdateUMAShape(); }
	public void OnEyeSpacingChange() { if (umaTutorialDna != null) umaTutorialDna.eyeSpacing = EyeSpacingSlider.value; EyeSpacingSlider.transform.Find("ValueText").gameObject.GetComponent<Text>().text = EyeSpacingSlider.value.ToString("F2"); UpdateUMAShape(); }

    public void OnHairRColorChange()
    {
        changeColor(ref HairColorPanel, ref HairColorButton, ref HairColor, ref HairColorRSlider, (int)ColorChanel.R);
        if (actHairName != "") {
            colorOverlay(7, actHairName, HairColor);
            colorOverlay(2, "FemaleEyebrow01", HairColor);
            if (actLongHairName != "")
                colorOverlay(8, actLongHairName, HairColor);
            umaData.isTextureDirty = true;
            umaData.Dirty();
        }
    }
    public void OnHairGColorChange()
    {
        changeColor(ref HairColorPanel, ref HairColorButton, ref HairColor, ref HairColorGSlider, (int)ColorChanel.G);
        if (actHairName != "")
        {
            colorOverlay(7, actHairName, HairColor);
            colorOverlay(2, "FemaleEyebrow01", HairColor);
            if (actLongHairName != "")
                colorOverlay(8, actLongHairName, HairColor);
            umaData.isTextureDirty = true;
            umaData.Dirty();
        }
    }
    public void OnHairBColorChange()
    {
        changeColor(ref HairColorPanel, ref HairColorButton, ref HairColor, ref HairColorBSlider, (int)ColorChanel.B);
        if (actHairName != "")
        {
            colorOverlay(7, actHairName, HairColor);
            colorOverlay(2, "FemaleEyebrow01", HairColor);
            if (actLongHairName != "")
                colorOverlay(8, actLongHairName, HairColor);
            umaData.isTextureDirty = true;
            umaData.Dirty();
        }
    }
    public void OnBeardRColorChange()
    {
        //changeColor(ref BeardColorPanel, ref BeardColorButton, ref BeardColor, ref BeardColorRSlider, (int)ColorChanel.R);
        //if (actBeardName != "")
        //{
        //    colorOverlay(7, actBeardName, BeardColor);
        //    umaData.isTextureDirty = true;
        //    umaData.Dirty();
        //}
    }
    public void OnBeardGColorChange()
    {
        //changeColor(ref BeardColorPanel, ref BeardColorButton, ref BeardColor, ref BeardColorGSlider, (int)ColorChanel.G);
        //if (actBeardName != "")
        //{
        //    colorOverlay(7, actBeardrName, BeardColor);
        //    umaData.isTextureDirty = true;
        //    umaData.Dirty();
        //}
    }
    public void OnBeardBColorChange()
    {
        //changeColor(ref BeardColorPanel, ref BeardColorButton, ref BeardColor, ref BeardColorBSlider, (int)ColorChanel.B);
        //if (actBeardName != "")
        //{
        //    colorOverlay(7, actBeardName, HairColor);
        //    umaData.isTextureDirty = true;
        //    umaData.Dirty();
        //}
    }
    public void OnShirtRColorChange()
    {
        changeColor(ref ShirtColorPanel, ref ShirtColorButton, ref ShirtColor, ref ShirtColorRSlider, (int)ColorChanel.R);
        if (actShirtName != "")
        {
            colorOverlay(3, actShirtName, ShirtColor);
            umaData.isTextureDirty = true;
            umaData.Dirty();
        }
    }
    public void OnShirtGColorChange()
    {
        changeColor(ref ShirtColorPanel, ref ShirtColorButton, ref ShirtColor, ref ShirtColorGSlider, (int)ColorChanel.G);
        if (actShirtName != "")
        {
            colorOverlay(3, actShirtName, ShirtColor);
            umaData.isTextureDirty = true;
            umaData.Dirty();
        }
    }
    public void OnShirtBColorChange()
    {
        changeColor(ref ShirtColorPanel, ref ShirtColorButton, ref ShirtColor, ref ShirtColorBSlider, (int)ColorChanel.B);
        if (actShirtName != "")
        {
            colorOverlay(3, actShirtName, ShirtColor);
            umaData.isTextureDirty = true;
            umaData.Dirty();
        }
    }
    public void OnPantsRColorChange()
    {
        changeColor(ref PantsColorPanel, ref PantsColorButton, ref PantsColor, ref PantsColorRSlider, (int)ColorChanel.R);
        if (actPantsName != "")
        {
            colorOverlay(3, actPantsName, PantsColor);
            umaData.isTextureDirty = true;
            umaData.Dirty();
        }
    }
    public void OnPantsGColorChange()
    {
        changeColor(ref PantsColorPanel, ref PantsColorButton, ref PantsColor, ref PantsColorGSlider, (int)ColorChanel.G);
        if (actPantsName != "")
        {
            colorOverlay(3, actPantsName, PantsColor);
            umaData.isTextureDirty = true;
            umaData.Dirty();
        }
    }
    public void OnPantsBColorChange()
    {
        changeColor(ref PantsColorPanel, ref PantsColorButton, ref PantsColor, ref PantsColorBSlider, (int)ColorChanel.B);
        if (actPantsName != "")
        {
            colorOverlay(3, actPantsName, PantsColor);
            umaData.isTextureDirty = true;
            umaData.Dirty();
        }
    }
    public void OnUnderwareRColorChange()
    {
        changeColor(ref UnderwareColorPanel, ref UnderwareColorButton, ref UnderwareColor, ref UnderwareColorRSlider, (int)ColorChanel.R);
        if (actUnderwareName != "")
        {
            colorOverlay(3, actUnderwareName, UnderwareColor);
            umaData.isTextureDirty = true;
            umaData.Dirty();
        }
    }
    public void OnUnderwareGColorChange()
    {
        changeColor(ref UnderwareColorPanel, ref UnderwareColorButton, ref UnderwareColor, ref UnderwareColorGSlider, (int)ColorChanel.G);
        if (actUnderwareName != "")
        {
            colorOverlay(3, actUnderwareName, UnderwareColor);
            umaData.isTextureDirty = true;
            umaData.Dirty();
        }
    }
    public void OnUnderwareBColorChange()
    {
        changeColor(ref UnderwareColorPanel, ref UnderwareColorButton, ref UnderwareColor, ref UnderwareColorBSlider, (int)ColorChanel.B);
        if (actUnderwareName != "")
        {
            colorOverlay(3, actUnderwareName, UnderwareColor);
            umaData.isTextureDirty = true;
            umaData.Dirty();
        }
    }
    public void OnEyesRColorChange()
    {
        changeColor(ref EyesColorPanel, ref EyesColorButton, ref EyesColor, ref EyesColorRSlider, (int)ColorChanel.R);
        if (actEyesName != "")
        {
            colorOverlay(0, actEyesName, EyesColor);
            umaData.isTextureDirty = true;
            umaData.Dirty();
        }
    }
    public void OnEyesGColorChange()
    {
        changeColor(ref EyesColorPanel, ref EyesColorButton, ref EyesColor, ref EyesColorGSlider, (int)ColorChanel.G);
        if (actEyesName != "")
        {
            colorOverlay(0, actEyesName, EyesColor);
            umaData.isTextureDirty = true;
            umaData.Dirty();
        }
    }
    public void OnEyesBColorChange()
    {
        changeColor(ref EyesColorPanel, ref EyesColorButton, ref EyesColor, ref EyesColorBSlider, (int)ColorChanel.B);
        if (actEyesName != "")
        {
            colorOverlay(0, actEyesName, EyesColor);
            umaData.isTextureDirty = true;
            umaData.Dirty();
        }
    }
    public void OnLipsRColorChange()
    {
        changeColor(ref LipsColorPanel, ref LipsColorButton, ref LipsColor, ref LipsColorRSlider, (int)ColorChanel.R);
        if (actLipsName != "")
        {
            colorOverlay(2, actLipsName, LipsColor);
            umaData.isTextureDirty = true;
            umaData.Dirty();
        }
    }
    public void OnLipsGColorChange()
    {
        changeColor(ref LipsColorPanel, ref LipsColorButton, ref LipsColor, ref LipsColorGSlider, (int)ColorChanel.G);
        if (actLipsName != "")
        {
            colorOverlay(2, actLipsName, LipsColor);
            umaData.isTextureDirty = true;
            umaData.Dirty();
        }
    }
    public void OnLipsBColorChange()
    {
        changeColor(ref LipsColorPanel, ref LipsColorButton, ref LipsColor, ref LipsColorBSlider, (int)ColorChanel.B);
        if (actLipsName != "")
        {
            colorOverlay(2, actLipsName, LipsColor);
            umaData.isTextureDirty = true;
            umaData.Dirty();
        }
    }

    private void changeColor(ref RectTransform panel, ref Button button, ref Color color, ref Slider slider, int chanel)
    {
        if (chanel == (int)ColorChanel.R)
            color.r = slider.value;
        if (chanel == (int)ColorChanel.G)
            color.g = slider.value;
        if (chanel == (int)ColorChanel.B)
            color.b = slider.value;
        slider.transform.Find("Value").gameObject.GetComponent<Text>().text = (slider.value * 255).ToString("F0");
        panel.transform.Find("ColorPanel").GetComponent<Image>().color = color;
        var colors = button.colors;
        colors.normalColor = color;
        colors.disabledColor = color;
        colors.highlightedColor = color;
        colors.pressedColor = color;
        button.colors = colors;

    }

    // Button callbacks
    public void OnFemaleUnderware01Change() {
		//if (States ["FemaleUnderwear01"] == "false") {
		//	addOverlayWithButton(3, "FemaleUnderwear01", ref UnderwareColor, ref Underware01Button, ref underwareState, (int)Slots.Underware);
		//} else {
		//	removeOverlayWithButton(3, "FemaleUnderwear01", ref Underware01Button, ref underwareState);
		//}
		//umaData.isTextureDirty = true;
		//umaData.Dirty();
	}
	public void OnFemaleShirt01Change() {
		//Debug.Log ("Shirt01State: " + States ["FemaleShirt01"]);
		if (States ["FemaleShirt01"] == "false") {
			addOverlayWithButton(3, "FemaleShirt01", ref ShirtColor, ref FemaleShirt01Button, ref shirtState, (int)Slots.Shirt);
		} else {
			removeOverlayWithButton(3, "FemaleShirt01", ref FemaleShirt01Button, ref shirtState);
		}
		umaData.isTextureDirty = true;
		umaData.Dirty();
	}
	public void OnFemaleShirt02Change() {
		//Debug.Log ("Shirt02State: " + States ["FemaleShirt02"]);
		if (States ["FemaleShirt02"] == "false") {
			addOverlayWithButton(3, "FemaleShirt02", ref ShirtColor, ref FemaleShirt02Button, ref shirtState, (int)Slots.Shirt);
		} else {
			removeOverlayWithButton(3, "FemaleShirt02", ref FemaleShirt02Button, ref shirtState);
		}
		umaData.isTextureDirty = true;
		umaData.Dirty();
	}
	public void OnFemaleTShirt01Change() {
		//Debug.Log ("TShirt01State: " + States ["FemaleTshirt01"]);
		if (States ["FemaleTshirt01"] == "false") {
			addOverlayWithButton(3, "FemaleTshirt01", ref ShirtColor, ref FemaleTShirt01Button, ref shirtState, (int)Slots.Shirt);
		} else {
			removeOverlayWithButton(3, "FemaleTshirt01", ref FemaleTShirt01Button, ref shirtState);
		}
		umaData.isTextureDirty = true;
		umaData.Dirty();
	}
	public void OnFemaleJeans01Change() {
		//Debug.Log ("Jeans01State: " + States ["FemaleJeans01"]);
		if (States ["FemaleJeans01"] == "false") {
			addOverlayWithButton(3, "FemaleJeans01", ref PantsColor, ref FemaleJeans01Button, ref pantsState, (int)Slots.Pants);
		} else {
			removeOverlayWithButton(3, "FemaleJeans01", ref FemaleJeans01Button, ref pantsState);
		}
		umaData.isTextureDirty = true;
		umaData.Dirty();
	}
	public void OnFemaleLongHair01Change() {
		//Debug.Log ("FemaleLongHair01: " + States ["FemaleLongHair01"]);
		if (States ["FemaleLongHair01"] == "false") {
			SetSlot(7, "FemaleLongHair01");
			addOverlayWithButton(7, "FemaleLongHair01", ref HairColor, ref FemaleLongHair01Button, ref hairState, (int)Slots.Hair);
			SetSlot(8, "FemaleLongHair01_Module");
			addOverlay(8, "FemaleLongHair01_Module", HairColor, (int)Slots.LongHair);
		} else {
			removeOverlayWithButton(7, "FemaleLongHair01", ref FemaleLongHair01Button, ref hairState);
			RemoveSlot(7);
			RemoveSlot(8);
		}
		umaData.isMeshDirty = true;
		umaData.isTextureDirty = true;
		umaData.isShapeDirty = true;
		umaData.Dirty();
    }
    public void OnMaleShirt01Change()
    {
        //Debug.Log ("Shirt01State: " + States ["FemaleShirt01"]);
        if (States["MaleShirt01"] == "false")
        {
            addOverlayWithButton(3, "MaleShirt01", ref ShirtColor, ref MaleShirt01Button, ref shirtState, (int)Slots.Shirt);
        }
        else
        {
            removeOverlayWithButton(3, "MaleShirt01", ref MaleShirt01Button, ref shirtState);
        }
        umaData.isTextureDirty = true;
        umaData.Dirty();
    }
    public void OnMaleJeans01Change()
    {
        //Debug.Log ("Jeans01State: " + States ["MaleJeans01"]);
        if (States["MaleJeans01"] == "false")
        {
            addOverlayWithButton(3, "MaleJeans01", ref PantsColor, ref MaleJeans01Button, ref pantsState, (int)Slots.Pants);
        }
        else
        {
            removeOverlayWithButton(3, "MaleJeans01", ref MaleJeans01Button, ref pantsState);
        }
        umaData.isTextureDirty = true;
        umaData.Dirty();
    }

    public void OnFemaleChanged()
    {
        GenerateFemale();
    }

    public void OnMaleChanged()
    {
        GenerateMale();
    }

    public void OnRandomGenderChanged()
    {
        if (Random.Range(0, 100) > 50)
        {
            GenerateFemale();
        } else
        {
            GenerateMale();
        }
    }
}
