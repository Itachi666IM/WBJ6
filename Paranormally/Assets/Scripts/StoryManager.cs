using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
public class StoryManager : MonoBehaviour
{
    [SerializeField] TMP_Text dialogText;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject storyCutscene;
    [SerializeField] GameObject skipButton;
    public string[] dialogs;
    string currentDialog;
    int index = 0;
    public float typingSpeed;

    private void Start()
    {
        dialogText.text = "";
        currentDialog = dialogs[index];
        StartCoroutine(WriteSentence());
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator WriteSentence()
    {
        foreach(char c in currentDialog.ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(typingSpeed);
        nextButton.SetActive(true);
    }

    public void NextSentence()
    {
        nextButton.SetActive(false);
        dialogText.text = "";
        if(index +1  < dialogs.Length)
        {
            index++;
            currentDialog = dialogs[index];
            StartCoroutine(WriteSentence());
        }
        else
        {
            if(skipButton!=null)
            {
                skipButton.SetActive(false);
            }
            storyCutscene.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void EndSkip()
    {
        dialogText.text = "";
        nextButton.SetActive(false);
        if(skipButton!=null)
        {
            skipButton.SetActive(false);
        }
        storyCutscene.SetActive(true);
    }
}
