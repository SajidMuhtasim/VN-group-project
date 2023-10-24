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

    [SerializeField] AudioClip audioClip;
    private static DialogueManager instance;
    private TextAsset textAsset;
    private Story currentStory;
    private bool dialogueIsPlaying;

    bool isChoosing;
    public VerticalLayoutGroup layoutContainer;
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
        DestroyUI();
        
        // You can add initialization code here if needed



    }

    private void Update()
    {
        if (!dialogueIsPlaying)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
            AudioManager.instance.PlaySFX(audioClip);
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

        if (currentStory.canContinue)
        {

            dialogueText.text = currentStory.Continue();
        }
        else if (currentStory.currentChoices.Count > 0) 
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

        List<Choice> _storychoice = currentStory.currentChoices;

        int index = 0;
       /* foreach (Choice choice in _storychoice)
        {
            Button choiceButton = Instantiate(buttonprefab, choicePanel.transform) as Button;
            TextMeshProUGUI choiceText = buttonprefab.GetComponentInChildren<TextMeshProUGUI>();
            choiceText.text = choice.text;

            Debug.Log(currentStory.currentChoices[choice.index].text);

            choiceButton.onClick.AddListener(delegate
            {
                ChoiceHandler(choice);

            });
            index++;
            Debug.Log(choiceText.text + index);
        }*/

        for (int i = 0; i < currentStory.currentChoices.Count; i++)
        {
            Choice choice = currentStory.currentChoices[i];
            Debug.Log(currentStory.currentChoices[i]);
            Button button = CreateButtonChoice(choice.text);

            button.onClick.AddListener(delegate
            {
                ChoiceHandler(choice);

            });
        }

        //ExitDialogueMode();
    }


    Button CreateButtonChoice(string text)
    {

        Button choiceButton = Instantiate(buttonprefab);
        
        choiceButton.transform.SetParent(layoutContainer.transform, false);

        var buttonText = choiceButton.GetComponentInChildren<TextMeshProUGUI>();
        
        buttonText.text = text;

        return choiceButton;
    }



    void DestroyUI() 
    {
        if (layoutContainer != null)
        {
            foreach (var button in layoutContainer.GetComponentsInChildren<Button>())
            {
                Destroy(button.gameObject);
            }
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
        DestroyUI();
        AudioManager.instance.PlaySFX(audioClip);

        //        Debug.Log(currentStory.ChooseChoiceIndex(choice));
        ContinueStory();
        
    }

}
