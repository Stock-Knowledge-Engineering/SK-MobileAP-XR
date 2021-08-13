using UnityEngine;
using TMPro;

public class Mode2_ImpulseMomentumQuestionManager : MonoBehaviour
{

    private Mode2_ImpulseMomentumGameManager gameManager;

    private AudioSource source;
    [Header("Model")]
    public Animator anim;


    [Header("DETAILS UI")]
    public GameObject[] details;
    public bool _isChange;
    public dropDownOptions[] dropDownOptions;

    [Header("QUESTIONS")]
    public TMP_Dropdown dropdownMenu;
    public TextMeshProUGUI question;
    public int dropdownValue;

    [Header("Answers")]
    public GameObject correctAnswer;
    public GameObject showInputAnswer;
    public TMP_InputField inputAnswer;




    private void Start()
    {
        gameManager = this.GetComponent<Mode2_ImpulseMomentumGameManager>();
        source = this.GetComponent<AudioSource>();


    }

    private void Update()
    {
        dropdownValue = dropdownMenu.value;
        correctAnswer.SetActive(dropdownMenu.value >= 1 && dropDownOptions[dropdownValue].hasAnswered ? true : false);
        showInputAnswer.SetActive(dropdownMenu.value == 0 || dropDownOptions[dropdownValue].hasAnswered ? false : true);


        for (int i = 0; i <= details.Length - 1; i++)
        {
            details[i].SetActive(dropdownMenu.value == i ? true : false);


        }





    }
    public void HandleInputData(int value)
    {
        switch (value)
        {
            case 0:
                question.text = "A 0.400-kg ball hits a wall with an initial velocity of 30 m/s, to the left. It rebounds with a final speed of 20 m/s, to the right";
                anim.SetTrigger("Introduction");


                break;
            case 1:
                question.text = "What is the initial momentum of the ball? _____ kg m/s";
                anim.SetTrigger("Question1");

                break;
            case 2:
                question.text = "What is the final momentum of the ball? _____ kg m/s";
                anim.SetTrigger("Question2");
                break;
            case 3:
                question.text = "What is the impulse imparted on the ball? _____ N*s";
                anim.SetTrigger("Question3");
                break;
            case 4:
                question.text = "If the ball stays in contact with the wall for 0.0080s, what is the average force experienced by the ball? _____ N";
                anim.SetTrigger("Question4");
                break;

            default:
                break;
        }
    }



    public void AnswerCheck()
    {
        if (inputAnswer.text == dropDownOptions[dropdownValue].answer)
        {
            dropDownOptions[dropdownValue].hasAnswered = true;
            dropDownOptions[dropdownValue].isCorrect = true;

            gameManager.CorrectAnswer();
        }
        if (inputAnswer.text != dropDownOptions[dropdownValue].answer)
        {
            dropDownOptions[dropdownValue].hasAnswered = true;
            dropDownOptions[dropdownValue].isCorrect = false;
            gameManager.IncorrectAnswer();
        }
        inputAnswer.text = "";

    }

    public void ShowCorrectAnswer()
    {
        dropDownOptions[dropdownValue].correctAnswer.SetActive(true);
    }


    public  void DropdownValueChanged(TMP_Dropdown change)
    {
        if (dropDownOptions[dropdownValue].correctAnswer)
        {
            dropDownOptions[dropdownValue].correctAnswer.SetActive(false);
        }

        PlaySound(source.clip = dropDownOptions[dropdownMenu.value].audio);    
    }

    public void PlaySound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }

}
[System.Serializable]
public class dropDownOptions
{
    public int questionNumber;
    public AudioClip audio;
    public bool hasAnswered;
    public bool isCorrect;
    public string answer;
    public GameObject correctAnswer;
}
