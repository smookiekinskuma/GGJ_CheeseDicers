/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class DialogueScript : MonoBehaviour
{
    [Header("Imported Scripts")]
    public player_controls Player;
    public UIScript Ui;
    public crystal_pickup CTracker;

    [Header("TMP")]
    [SerializeField]
    public TMP_Text nameText;
    public TMP_Text diaText;
    public GameObject diaBox;
    public GameObject nameBox;

    [Header("Checksum")]
    int DialogueProg;
    int DialogueSegment1;
    int DialogueSegment2;
    int DialogueSegment3;
    int Crystal2;
    int Crystal3;
    int Crystal4;
    int TutorialProg1;
    int TutorialProg2;
    int TutorialProg3;
    int TutorialEnd;

    private void Update()
    {
        ContinueDialogue();
    }

    public void ContinueDialogue()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!Ui.tutorialObj.activeInHierarchy)
        {
            if (!Input.GetKeyDown(KeyCode.F2))
            {
                diaBox.SetActive(true);
                nameText.text = "Kid";
                diaText.text = "Mephy?! Mephy! Where are you?!";
            }
        }

            switch (DialogueProg)
            {
                case 0:
                    switch (DialogueSegment1)
                    {
                        case 0:
                            switch (TutorialProg1)
                            {
                                case 0:
                                    nameText.text = "Mephy";
                                    diaText.text = "Meow.";
                                    TutorialProg1++;
                                    break;
                                case 1:
                                    nameBox.SetActive(false);
                                    diaText.text = "(The meowing could be heard nearby)";
                                    TutorialProg1++;
                                    break;
                                case 2:
                                    nameBox.SetActive(true);
                                    nameText.text = "Kid";
                                    diaText.text = "Mephy?! IÅfm coming!";
                                    TutorialProg1++;
                                    DialogueSegment1++;
                                    diaBox.SetActive(false);
                                    break;
                            }
                            break;

                        case 1:
                            diaBox.SetActive(true);
                            switch (TutorialProg2)
                            {
                                case 0:
                                    nameText.text = "Kid";
                                    diaText.text = "Mephy? Is that you?! Where are you?! Please, Mephy, this darkness is scaryÅc";
                                    TutorialProg2++;
                                    break;
                                case 1:
                                    nameText.text = "Mephy";
                                    diaText.text = "Meow~";
                                    TutorialProg2++;
                                    break;
                                case 2:
                                    nameBox.SetActive(false);
                                    diaText.text = "(The meowing is getting closer)";
                                    TutorialProg2++;
                                    break;
                                case 3:
                                    nameBox.SetActive(true);
                                    nameText.text = "Kid";
                                    diaText.text = "Mephy?! Stay there, IÅ'm on my way!";
                                    TutorialProg2++;
                                    DialogueSegment1++;
                                    diaBox.SetActive(false);
                                    break;
                            }
                            break;
                        case 2:
                            diaBox.SetActive(true);
                            switch (TutorialProg3)
                            {
                                case 0:
                                    nameText.text = "Kid";
                                    diaText.text = "Mephy?! Please, IÅ'm scaredÅ... come back to meÅ already.";
                                    TutorialProg3++;
                                    break;
                                case 1:
                                    nameText.text = "Mephy";
                                    diaText.text = "Mew!";
                                    TutorialProg3++;
                                    break;
                                case 2:
                                    nameText.text = "Kid";
                                    diaText.text = "Mephy! IÅfm comi-";
                                    TutorialProg3++;
                                    break;
                                case 3:
                                    nameBox.SetActive(false);
                                    diaText.text = "(Growling Noises)";
                                    //Note: Play enemy detection audio here.
                                    TutorialProg3++;
                                    break;
                                case 4:
                                    nameBox.SetActive(true);
                                    nameText.text = "Kid";
                                    diaText.text = "Eek! What-";
                                    TutorialProg3++;
                                    break;
                                case 5:
                                    nameText.text = "Kid";
                                    diaText.text = "Ahh! DonÅ't eat me!";
                                    TutorialProg3++;
                                    break;
                                case 6:
                                    nameText.text = "Kid";
                                    diaText.text = "H-huh?";
                                    TutorialProg3++;
                                    DialogueSegment1++;
                                    diaBox.SetActive(false);
                                    break;
                            }
                            break;
                            if (CTracker.crystalCount = 1)
                            {
                            case 3:

                                    diaBox.SetActive(true);
                                    switch (TutorialEnd)
                                    {
                                        case 0:
                                            nameText.text = "Kid";
                                            diaText.text = "There you are MephyÅ...";
                                            TutorialEnd++;
                                            break;
                                        case 1:
                                            nameText.text = "Mephy";
                                            diaText.text = "MewÅ...";
                                            TutorialEnd++;
                                            break;
                                        case 2:
                                            nameBox.SetActive(false);
                                            diaText.text = "(Mephy slowly fades away, with a crystal taking his place with many small bubbles floating upward coming from the ground)";
                                            TutorialEnd++;
                                            break;
                                        case 3:
                                            nameBox.SetActive(true);
                                            nameText.text = "Kid";
                                            diaText.text = "M-Mephy?! Where did you go?!";
                                            TutorialEnd++;
                                            break;
                                        case 4:
                                            nameText.text = "???";
                                            diaText.text = "Calm yourself, child.";
                                            TutorialEnd++;
                                            break;
                                        case 5:
                                            nameText.text = "Kid";
                                            diaText.text = "Wh-who?!";
                                            TutorialEnd++;
                                            break;
                                        case 6:
                                            nameBox.SetActive(false);
                                            diaText.text = "(The voice is coming from the crystal)";
                                            TutorialEnd++;
                                            break;
                                        case 7:
                                            nameBox.SetActive(true);
                                            nameText.text = "???";
                                            diaText.text = "ThereÅfs not enough time for questions, child. Find the other fragments of me, and you will be reunited with your pet. You will know where they are if you take me with you.";
                                            TutorialEnd++;
                                            break;
                                        case 8:
                                            nameText.text = "Kid";
                                            diaText.text = "R-really?";
                                            TutorialEnd++;
                                            break;
                                        case 9:
                                            nameText.text = "???";
                                            diaText.text = "YesÅc You will.";
                                            TutorialEnd++;
                                            break;
                                        case 10:
                                            nameText.text = "Kid";
                                            diaText.text = "O-okayÅc";
                                            TutorialEnd++;
                                            DialogueSegment1++;
                                            DialogueProg++;
                                            diaBox.SetActive(false);
                                            break;
                                    }
                                    break;
                                }

                            }
                            break;
                        case 1:
                            switch (DialogueSegment2)
                            {
                                if (CTracker.crystalCount = 2)
                            {
                                diaBox.SetActive(true);
                                case 0:
                                    switch (Crystal2)
                                    {
                                        case 0:
                                            nameText.text = "???";
                                            diaText.text = "Good. Just two more, child.";
                                            Crystal2++;
                                            break;
                                        case 1:
                                            nameText.text = "Kid";
                                            diaText.text = "I miss MephyÅc";
                                            Crystal2++;
                                            break;
                                        case 2:
                                            nameText.text = "???";
                                            diaText.text = "You will see your pet again, child. Now go find the other pieces. Hurry.";
                                            Crystal2++;
                                            break;
                                        case 3:
                                            nameText.text = "Kid";
                                            diaText.text = "O-okayÅc";
                                            Crystal2++;
                                            DialogueSegment2++;
                                            break;
                                    }
                                    break;
                                }
                                
                                case 1:
                                    switch (Crystal3)
                                    {
                                        case 0:
                                            nameText.text = "???";
                                            diaText.text = "One more crystal, childÅc";
                                            Crystal3++;
                                            break;
                                        case 1:
                                            nameBox.SetActive(false);
                                            diaText.text = "(The voice sounds more imposing and sinister)";
                                            Crystal3++;
                                            break;
                                        case 2:
                                            nameBox.SetActive(true);
                                            nameText.text = "Kid";
                                            diaText.text = "Eep!";
                                            Crystal3++;
                                            break;
                                        case 3:
                                            nameText.text = "???";
                                            diaText.text = "Do not fear, child. Lest you be consumed by these depths.";
                                            Crystal3++;
                                            break;
                                        case 4:
                                            nameText.text = "Kid";
                                            diaText.text = "(Sobs)";
                                            Crystal3++;

                                            break;
                                        case 5:
                                            nameText.text = "???";
                                            diaText.text = "(Sighs)";
                                            Crystal3++;
                                            DialogueSegment2++;
                                            break;


                                    }
                                    break;
                                case 2:
                                    switch (Crystal4)
                                    {
                                        case 0:
                                            nameText.text = "???";
                                            diaText.text = "GoodÅc that is all the fragments. Now return to the monolith at the center. You will be reunited with your pet once you open the gates.";
                                            Crystal4++;
                                            break;
                                        case 1:
                                            nameText.text = "Kid";
                                            diaText.text = "(Continues to sob)";
                                            Crystal4++;
                                            break;
                                        case 2:
                                            nameText.text = "???";
                                            diaText.text = "Stop crying, child. Your journey is at its end.";
                                            Crystal4++;
                                            break;
                                        case 3:
                                            nameText.text = "Kid";
                                            diaText.text = "(Sniffles), R-reallyÅc?";
                                            Crystal4++;
                                            break;
                                        case 4:
                                            nameText.text = "???";
                                            diaText.text = "YesÅc Now go to the temple, where it all began.";
                                            Crystal4++;
                                            DialogueSegment2++;
                                            DialogueProg++;
                                            break;
                                    }
                                    break;

                            }
                            break;
                        case 2:
                            switch (DialogueSegment3)
                            {
                                case 0:
                                    nameText.text = "???";
                                    diaText.text = "Thank you, childÅc";
                                    DialogueSegment3++;
                                    break;
                                case 1:
                                    nameText.text = "???";
                                    diaText.text = "... For freeing me. At last...";
                                    DialogueSegment3++;
                                    break;
                                case 2:
                                    nameBox.SetActive(false);
                                    diaText.text = "(The voice dissipates after its ominous message, and the kid enters the temple.)";
                                    DialogueSegment3++;
                                    break;
                                case 3:
                                    nameBox.SetActive(true);
                                    nameText.text = "Mephy(?)";
                                    diaText.text = "Meow~";
                                    DialogueSegment3++;
                                    break;
                                case 4:
                                    nameText.text = "Kid";
                                    diaText.text = "Mephy?! Come on, let's go home already-";
                                    DialogueSegment3++;
                                    break;
                                case 5:
                                    nameBox.SetActive(false);
                                    diaText.text = "(Mephy's neck snaps, and falls to the ground. ÅgMephyÅh then slinks back into the darkness as itÅfs dragged by a tentacle-like protrusion.)";
                                    DialogueSegment3++;
                                    break;
                                case 6:
                                    nameBox.SetActive(true);
                                    nameText.text = "Boy";
                                    diaText.text = "M-mephy?!";
                                    DialogueSegment3++;
                                    break;
                                case 7:
                                    nameText.text = "Boy";
                                    diaText.text = "AAAAAAAHHHHHH!!!";
                                    DialogueSegment3++;
                                    DialogueProg++;
                                    break;
                            }
                            break;
                    }
            }
    }

}




*/