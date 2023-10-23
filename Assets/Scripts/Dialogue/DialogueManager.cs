using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject choicePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private static DialogueManager instance;
    private TextAsset textAsset;
    private Story currentStory;
    private bool dialogueIsPlaying;

    bool isChoosing;
    public Button buttonprefab;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Ensure the manager persists between scenes if needed
        }
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        
        // You can add initialization code here if needed



    }

    private void Update()
    {
        if (!dialogueIsPlaying)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        if (inkJSON == null)
        {
            Debug.LogError("Ink JSON file is missing.");
            return;
        }
        textAsset = inkJSON;
        currentStory = new Story(textAsset.text);

        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        //        Debug.Log(currentStory.ContinueMaximally());
        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory == null)
            return;

        if (currentStory.canContinue && isChoosing == false)
        {

            dialogueText.text = currentStory.Continue();
        }
        else if (!currentStory.canContinue && isChoosing == false) 
        {
            UpdateUI();
        }
        else 
        {
            ExitDialogueMode();
        }
    }

    void EnterChoiceMode()
    {
        dialoguePanel.SetActive(false);
        choicePanel.SetActive(true);
    }

    void UpdateUI() 
    {
        DestroyUI();
        isChoosing = true;
        EnterChoiceMode();
        //button maker factory

        List<Choice> _choice = currentStory.currentChoices;

        /*  for (int i = 0; i < _choice.Count; i++)
          {
              Button choiceButton = Instantiate(buttonprefab, choicePanel.transform) as Button;
              TextMeshProUGUI choiceText = buttonprefab.GetComponentInChildren<TextMeshProUGUI>();
              choiceText.text = _choice[i].text;
              Debug.Log(currentStory.currentChoices[_choice[i].index]);

              choiceButton.onClick.AddListener(delegate {
                  ChoiceHandler(_choice[i]);

              });
          }*/


        foreach (Choice choice in currentStory.currentChoices)
        {
            Button choiceButton = Instantiate(buttonprefab, choicePanel.transform) as Button;
            TextMeshProUGUI choiceText = buttonprefab.GetComponentInChildren<TextMeshProUGUI>();
            choiceText.text = choice.text;
            Debug.Log(currentStory.currentChoices[choice.index].text);

            choiceButton.onClick.AddListener(delegate
            {
                ChoiceHandler(choice);

            });
        }

        /*        for (int i = 0; i < currentStory.currentChoices.Count; i++)
                {

                }*/

        //ExitDialogueMode();
    }
    void DestroyUI() 
    {
        for (int i = 0; i < choicePanel.transform.childCount ; i++) 
        {
            Destroy(choicePanel.transform.GetChild(i).gameObject);
        }
    }

    void ExitChoiceMode() 
    {
        choicePanel.SetActive(false);
        isChoosing = false;
        DestroyUI();
        dialoguePanel.SetActive(true);
        ContinueStory();
    }
    public void ChoiceHandler(Choice a)
    {
        currentStory.ChooseChoiceIndex(a.index);
        //UpdateUI();
        ExitChoiceMode();


        //        Debug.Log(currentStory.ChooseChoiceIndex(choice));
        ContinueStory();
        
    }

}
