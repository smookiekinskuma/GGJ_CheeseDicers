using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public player_controls PControls;

    //Bubble Cooldown UI
    [Header("Bubble Cooldown")]
    public Image cooldownIndicator;
    public Sprite activeSprite;
    public Sprite cooldownSprite;

    //Breath Bar UI Mechanics
    [Header("Breath Bar")]
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    //Tutorial Related Stuff
    [Header("Tutorial Related Objects")]
    public bool isStartGame;
    public GameObject tutorialObj;

    //Crystal Related Stuff
    [Header("UI Slots")]
    public Image YellowCrystalUI;
    public Image PurpleCrystalUI;
    public Image RedCrystalUI;
    public Image BlueCrystalUI;

    [Header("Sprites")]
    public Sprite EmptyCrystal;
    public Sprite YellowCrystal;
    public Sprite PurpleCrystal;
    public Sprite RedCrystal;
    public Sprite BlueCrystal;

    void Awake()
    {
        //Crystal Initializatiom
        YellowCrystalUI.sprite = EmptyCrystal;
        PurpleCrystalUI.sprite = EmptyCrystal;
        RedCrystalUI.sprite = EmptyCrystal;
        BlueCrystalUI.sprite = EmptyCrystal;
    }
    void Start()
    {
        isStartGame = true;
    }

    void Update()
    {
        if (isStartGame)
        {
            tutorialObj.SetActive(true);
            isStartGame = false;
        }
    }
    
    public void CrystalGrab(string gemName)
    {
        if(gemName == "yellow crystal") YellowCrystalUI.sprite = YellowCrystal;
        if(gemName == "purple crystal") PurpleCrystalUI.sprite = PurpleCrystal;
        if(gemName == "red crystal") RedCrystalUI.sprite = RedCrystal;
        if(gemName == "blue crystal") BlueCrystalUI.sprite = BlueCrystal;
    }

    public void CrystalTesting()
    {
        if (YellowCrystalUI.sprite == EmptyCrystal)
        {
            YellowCrystalUI.sprite = YellowCrystal;
            Debug.Log("Yellow Crystal Obtained");
        }

        if (YellowCrystalUI.sprite == YellowCrystal)
        {
            if (PurpleCrystalUI.sprite == EmptyCrystal)
            {
                PurpleCrystalUI.sprite = PurpleCrystal;
                Debug.Log("Purple Crystal Obtained");
            }

            if (PurpleCrystalUI.sprite == PurpleCrystal)
            {
                if (RedCrystalUI.sprite == EmptyCrystal)
                {
                    RedCrystalUI.sprite = RedCrystal;
                    Debug.Log("Red Crystal Obtained");

                }

                if (RedCrystalUI.sprite == RedCrystal)
                {
                    if (BlueCrystalUI.sprite == EmptyCrystal)
                    {
                        BlueCrystalUI.sprite = BlueCrystal;
                        Debug.Log("Blue Crystal Obtained");
                    }
                }
            }
        }
    }

    public void SetStartingBreath()
    {
        slider.maxValue = PControls.playerBreath;
        slider.value = PControls.playerBreath;

        fill.color = gradient.Evaluate(1f);
    }

    public void UpdateBreathBar()
    {
        slider.value = PControls.playerBreath;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void CloseTutorial()
    {
        tutorialObj.SetActive(false);
        Debug.Log("Button Clicked");
        Cursor.lockState = CursorLockMode.Locked;
    }
}
