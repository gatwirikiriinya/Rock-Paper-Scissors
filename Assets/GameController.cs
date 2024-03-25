using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI playerChoiceText;
    public TextMeshProUGUI computerChoiceText;
    public TextMeshProUGUI resultText;
    public Button replayButton;

    private enum Choice { Rock, Paper, Scissors }
    private Choice playerChoice;
    private Choice computerChoice;

    private void Start()
    {
        ToggleReplayButton(false, false); // Disable replay button initially
    }

    public void SetPlayerChoice(string choice)
    {
        if (System.Enum.TryParse(choice, out Choice parsedChoice))
        {
            playerChoice = parsedChoice;
            playerChoiceText.text = "Player: " + choice;
        }
        else
        {
            Debug.LogError("Invalid player choice: " + choice);
        }
    }

    public void Shoot()
    {
        computerChoice = (Choice)UnityEngine.Random.Range(0, 3);
        computerChoiceText.text = "Computer: " + computerChoice.ToString();

        // Compare choices and display result
        switch (playerChoice)
        {
            case Choice.Rock:
                if (computerChoice == Choice.Paper)
                    resultText.text = "Computer Wins!";
                else if (computerChoice == Choice.Scissors)
                    resultText.text = "Player Wins!";
                else
                    resultText.text = "It's a Draw!";
                break;
            case Choice.Paper:
                if (computerChoice == Choice.Rock)
                    resultText.text = "Player Wins!";
                else if (computerChoice == Choice.Scissors)
                    resultText.text = "Computer Wins!";
                else
                    resultText.text = "It's a Draw!";
                break;
            case Choice.Scissors:
                if (computerChoice == Choice.Rock)
                    resultText.text = "Computer Wins!";
                else if (computerChoice == Choice.Paper)
                    resultText.text = "Player Wins!";
                else
                    resultText.text = "It's a Draw!";
                break;
        }

        ToggleReplayButton(true, true); // Enable replay button after shoot
    }

    public void Replay()
    {

        Debug.Log("Replay method called");
        playerChoiceText.text = "Player: ";
        computerChoiceText.text = "Computer: ";
        resultText.text = "";
        ToggleReplayButton(false, false); // Disable replay button again
    }

    public void ToggleReplayButton(bool isVisible, bool isInteractable)
    {
        replayButton.gameObject.SetActive(isVisible);
        replayButton.interactable = isInteractable;
    }


}
