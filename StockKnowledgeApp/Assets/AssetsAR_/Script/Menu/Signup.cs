using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;

public class Signup : MonoBehaviour
{
    CurrentUser currentUser;

    public Gender[] genders;
    public School[] schools;
    public GradeLevel[] gradeLevels;
    public LoginResponse loginResponse;
    public ValidateAccountResponse validateAccountResponse;

    [Header("Page1")]
    public TMP_InputField firstName;
    public TMP_InputField middleName;
    public TMP_InputField lastName;
    public Button page1Button;
    [Header("Page2")]
    public TMP_InputField year;
    public TMP_Text yearErrorMessage;
    //public TMP_Dropdown year;
    public TMP_Dropdown month;
    public TMP_Dropdown day;
    public TMP_Dropdown gender;
    public TMP_InputField mobileNumber;
    public TMP_Text mobileNumberErrorMessage;
    public Button page2Button;
    bool isFulfilledRequirmentyear;
    bool isFulfilledRequirmentday;
    bool isFulfilledRequirmentmonth;
    bool isFulfilledRequirmentgender;
    bool isFulfilledRequirmentmobileNumber;
    [Header("Page3")]
    public TMP_Dropdown school;
    public string schoolVal;
    public TMP_InputField othersInputField;
    public GameObject othersGameObject;
    public TMP_Dropdown gradeLevel;
    public Button page3Button;
    [Header("Page4")]
    public TMP_InputField favoriteSubject;
    public TMP_InputField academicorCareergoal;
    public Button page4Button;
    [Header("Page5")]
    public Button EyeButton;
    public Button EyeButton2;
    public TMP_InputField emailAddress;
    public TMP_Text emailAddressErrorMessage;
    public TMP_InputField userName;
    public TMP_Text userNameErrorMessage;
    public TMP_InputField passWord;
    public TMP_Text passWordErrorMessage;
    public TMP_InputField repassWord;
    public TMP_Text repassWordErrorMessage;
    public Toggle termsAndConditionCheck;
    public Button page5Button;
    bool isFulfilledRequirmentemail;
    bool isFulfilledRequirmentusername;
    bool isFulfilledRequirmentpassword;
    [Header("Page6")]
    public TMP_InputField verificationCode;
    public TMP_Text verificationCodeErrorMessage;
    public TMP_Text sentToThisEmailErrorMessage;
    public Button page6Button;
    bool isFulfilledRequirmentverification;

    public bool validEmail;
    public bool validUsername;

    [Header("Var")]
    public int x = 0;
    public GameObject[] pages;


    public void Awake()
    {
        currentUser = GameObject.Find("CurrentUser").GetComponent<CurrentUser>();
    }

    public void Update()
    {
        InfoCheck();
        if (school.options[school.value].text == "other")
        {
            othersGameObject.SetActive(true);
            schoolVal = othersInputField.text;
        }
        else
        {
            schoolVal = school.options[school.value].text;
            othersGameObject.SetActive(false);
        }
    }

    public void Start()
    {
        //this.day.ClearOptions();

        string content = currentUser.GetRequest("/genders");
        genders = JsonConvert.DeserializeObject<Gender[]>(content);

        content = currentUser.GetRequest("/schools");
        schools = JsonConvert.DeserializeObject<School[]>(content);

        content = currentUser.GetRequest("/grade-levels");
        gradeLevels = JsonConvert.DeserializeObject<GradeLevel[]>(content);

        List<string> gendersList = genders.Select(i => i.name).ToList();
        List<string> schoolList = schools.Select(i => i.name).ToList();
        List<string> gradeLevelList = gradeLevels.Select(i => i.name).ToList();

        gender.ClearOptions();
        gender.AddOptions(gendersList);

        school.ClearOptions();
        school.AddOptions(schoolList);

        gradeLevel.ClearOptions();
        gradeLevel.AddOptions(gradeLevelList);

    }


    public void MonthsOnChange() {
        List<string> days = new List<string>();
        int month = this.month.value;
        int year = int.Parse(this.year.text);
        int numOfDays = System.DateTime.DaysInMonth(year, month);

        for (int i = 0; i < numOfDays; i++)
        {
            days.Add((i + 1).ToString());

        }
        Debug.Log("hello");
        this.day.AddOptions(days);
    }

    public void EmailOnChange()
    {
        string email = emailAddress.text;
        string content = currentUser.GetRequest(string.Format("/register/verify/email?value={0}", email));
        this.validEmail = !bool.Parse(content);

        /*if (!validEmail)
        {
            this.emailAddressErrorMessage.text = "Email has already been taken!";
        }*/
    }

    public void UsernameOnChange()
    {
        string username = this.userName.text;
        string content = currentUser.GetRequest(string.Format("/register/verify/username?value={0}", username));
        this.validUsername = !bool.Parse(content);

        /*if (!validUsername)
        {
            this.userNameErrorMessage.text = "Username has already been taken!";
        } */
    }

    public void SignupOnClick() {
        string firstname = this.firstName.text;
        string middlename = this.middleName.text;
        string lastname = this.lastName.text;
        string dateofbirth = string.Format("{0}-{1}-{2}", this.year.text, this.month.value, this.day.options[this.day.value].text);
        string gender = this.gender.options[this.gender.value].text;
        string mobileno = this.mobileNumber.text;
        string school = this.school.options[this.school.value].text;
        string other = this.othersInputField.text;
        string gradelevel = this.gradeLevel.options[this.gradeLevel.value].text;
        string favoritesubject = this.favoriteSubject.text;
        string careergoal = this.academicorCareergoal.text;
        string email = this.emailAddress.text;
        string username = this.userName.text;
        string password = this.passWord.text;

        var userObject = new JObject();

        userObject["username"] = username;
        userObject["email"] = email;
        userObject["password"] = password;
        userObject["firstName"] = firstname;
        userObject["middleName"] = middlename;
        userObject["lastName"] = lastname;
        userObject["mobileno"] = mobileno;
        userObject["gender"] = gender;
        userObject["dateofbirth"] = dateofbirth;
        //userObject["school"] = schoolVal; //new
        userObject["school"] = school;
        userObject["other"] = other;
        userObject["gradeLevel"] = gradelevel;
        userObject["favoriteSubject"] = favoritesubject;
        userObject["careerGoal"] = careergoal;

        var data = new JObject();
        data["data"] = userObject;

        string content = currentUser.PostRequest("/register/student", data);
        loginResponse = JsonConvert.DeserializeObject<LoginResponse>(content);

        currentUser.loginResponse = loginResponse;

        if (this.loginResponse.success)
        {
            Debug.Log("Register success");
            this.Next();
        }/*else if (this.loginResponse.success == false)
        {
            Debug.Log("Register Failed =-========");
        }*/
    }

    public void VerifyCodeOnChange()
    {
        string code = verificationCode.text;

        string content = currentUser.GetRequest(string.Format("/verify/verification-code?value={0}", code));
        VerifyCodeResponse verifyCodeResponse = JsonConvert.DeserializeObject<VerifyCodeResponse>(content);

        if (verifyCodeResponse.success)
        {
            isFulfilledRequirmentverification = true;
            verificationCodeErrorMessage.text = "";
        }
        else if (code == "")
            verificationCodeErrorMessage.text = "";
        else
        {
            isFulfilledRequirmentverification = false;
            verificationCodeErrorMessage.text = "The verification code that you entered is invalid!";
        }
    }

    public void VerifyCodeOnClick() {
        string code = verificationCode.text;
        int userid = currentUser.loginResponse.result[0].userid;

        var obj = new JObject();
        obj["code"] = code;
        obj["userid"] = userid;

        var data = new JObject();
        data["data"] = obj;

        string content = currentUser.PostRequest("/validate/account", data);
        validateAccountResponse = JsonConvert.DeserializeObject<ValidateAccountResponse>(content);

        if (validateAccountResponse.success)
        {
            isFulfilledRequirmentverification = true;
        }else
        {
            verificationCodeErrorMessage.text = "Code does not exist!";
            isFulfilledRequirmentverification = false;
        }
    }

    public void Next()
    {
        if (x < 6)
        {
            pages[x].SetActive(false);
            x++;
            pages[x].SetActive(true);
        }
    }

    public void Prev()
    {
        if (x > 0)
        {
            pages[x].SetActive(false);
            x--;
            pages[x].SetActive(true);
        }
    }

    public void SignUpButton() //if all the details has been inputed.
    {

    }

    public void InfoCheck()
    {
        //Debug.Log("Info Checking");
        //page1
        if (firstName.text != "" && middleName.text != "" && lastName.text != "")
        {
            page1Button.interactable = true;
        }
        else
        {
            page1Button.interactable = false;
        }
        //page2
        if (year.text != "" && mobileNumber.text != "")
        {
            //========== Year ==========
            if (year.text.Any(char.IsDigit))
            {
                if (year.text.Length == 4)
                {
                    isFulfilledRequirmentyear = true;
                    yearErrorMessage.text = "";
                }
                else
                {
                    yearErrorMessage.text = "Invalid Year";
                    isFulfilledRequirmentyear = false;
                }
            } else
            {
                yearErrorMessage.text = "Only numbers are accepted in this input.";
                isFulfilledRequirmentyear = false;
            }
            //=========== Month ==========
            if (this.month.options[this.month.value].text.Contains("Month") == false)
            {
                isFulfilledRequirmentmonth = true;
            }
            else
            {
                isFulfilledRequirmentmonth = false;
            }
            //=========== Day ==========
            if (this.day.options[this.day.value].text.Contains("Day") == false)
            {
                isFulfilledRequirmentday = true;
            }
            else
            {
                isFulfilledRequirmentday = false;
            }
            //=========== Gender ==========
            if (this.gender.options[this.gender.value].text.Contains("Gender") == false)
            {
                isFulfilledRequirmentgender = true;
            }
            else
            {
                isFulfilledRequirmentgender = false;
            }
            //=========== MobileNumber ============
            if (mobileNumber.text.Any(char.IsDigit))
            {
                isFulfilledRequirmentmobileNumber = true;
                mobileNumberErrorMessage.text = "";
            }
            else
            {
                mobileNumberErrorMessage.text = "Only numbers are accepted in this input.";
                isFulfilledRequirmentmobileNumber = false;
            }
        }
        else
        {
            page2Button.interactable = false;
        }
        //Final Result Page 2
        if (isFulfilledRequirmentyear == true && isFulfilledRequirmentmonth == true && isFulfilledRequirmentday == true && isFulfilledRequirmentgender == true && isFulfilledRequirmentmobileNumber == true)
        {
            page2Button.interactable = true;
        }
        else
        {
            page2Button.interactable = false;
        }
        //page3
        if (school.options[school.value].text != "School")
        {
            page3Button.interactable = true;
        }
        else
        {
            page3Button.interactable = false;
        }
        //page4
        if (favoriteSubject.text != "" && academicorCareergoal.text != "")
        {
            page4Button.interactable = true;
        }
        else
        {
            page4Button.interactable = false;
        }
        //page5
        if (emailAddress.text != "" && userName.text != "" && passWord.text != "" && repassWord.text != "" && termsAndConditionCheck.isOn == true)
        {
            //==============Email===============
            if (emailAddress.text.Contains("@") && emailAddress.text.Contains(".com"))
            {
                //Existing Email check
                EmailOnChange();
                if (validEmail)
                {
                    emailAddressErrorMessage.text = "";
                    isFulfilledRequirmentemail = true;
                }
                else if (!validEmail)
                {
                    emailAddressErrorMessage.text = "Email has already been taken!";
                    isFulfilledRequirmentemail = false;
                }
            }
            else
            {
                emailAddressErrorMessage.text = "Email/Gmail is invalid";
                isFulfilledRequirmentemail = false;
            }
            //==============Username=============
            UsernameOnChange();
            if (validUsername)
            {
                isFulfilledRequirmentusername = true;
                userNameErrorMessage.text = "";
            }
            else if (!validUsername)
            {
                userNameErrorMessage.text = "Username has already been taken!";
                isFulfilledRequirmentusername = false;
            }
            //==============Password============
            //Symbol requirment
            if (passWord.text.Contains("!") || passWord.text.Contains("@") || passWord.text.Contains("#") || passWord.text.Contains("$") || passWord.text.Contains("%") || passWord.text.Contains("&") || passWord.text.Contains("*"))
            {
                passWordErrorMessage.text = "";
                //Character requirement
                if (passWord.text.Length >= 8)
                {
                    passWordErrorMessage.text = "";
                    //Capital Letter requirment
                    if (passWord.text.Any(char.IsUpper) && passWord.text.Any(char.IsLetterOrDigit) && passWord.text.Any(char.IsLower))
                    {
                        passWordErrorMessage.text = "";
                        if (passWord.text == repassWord.text)
                        {
                            isFulfilledRequirmentpassword = true;
                            repassWordErrorMessage.text = "";
                        }
                        else
                        {
                            isFulfilledRequirmentpassword = false;
                            repassWordErrorMessage.text = "Password does not match!";
                        }
                    }
                    else
                    {
                        passWordErrorMessage.text = "Password must contain atleast 1 upper case letter, 1 lower case letter, and 1 number";
                        isFulfilledRequirmentpassword = false;
                    }
                }
                else
                {
                    passWordErrorMessage.text = "Password must be 8 characters long";
                    isFulfilledRequirmentpassword = false;
                }
            }
            else
            {
                passWordErrorMessage.text = "Password must contain atleast 1 non-alphanumeric symbol";
                isFulfilledRequirmentpassword = false;
            }
        }
        else
        {
            isFulfilledRequirmentpassword = false;
        }
        //Final Result Page 5
        if (isFulfilledRequirmentemail == true && isFulfilledRequirmentusername == true && isFulfilledRequirmentpassword == true)
        {
            page5Button.interactable = true;
        }
        else
        {
            page5Button.interactable = false;
        }

        /*//page5
        if (validEmail && validUsername)
        {
            page5Button.interactable = true;
        }
        else
        {
            page5Button.interactable = false;
        }*/

        //page6
        if (verificationCode.text != "") //change to verificationCode.text != "" + OTHER CONDITION
        {
            page6Button.interactable = true;
            if (isFulfilledRequirmentverification == true)
            {
                SceneManager.LoadScene("Dashboard");
            }
            else if (isFulfilledRequirmentverification == false)
            {
                verificationCodeErrorMessage.text = "Code does not exist!";
            }
        }
        else
        {
            page6Button.interactable = false;
        }
    }

    public void PasswordEye()
    {
        if (passWord.contentType == TMP_InputField.ContentType.Password)
        {
            passWord.contentType = TMP_InputField.ContentType.Standard;
        }
        else
        {
            passWord.contentType = TMP_InputField.ContentType.Password;
            EyeButton.interactable = false;
            EyeButton.interactable = true;
        }
        passWord.ForceLabelUpdate();
    }

    public void RepasswordEye()
    {
        if (repassWord.contentType == TMP_InputField.ContentType.Password)
        {
            repassWord.contentType = TMP_InputField.ContentType.Standard;
        }
        else
        {
            repassWord.contentType = TMP_InputField.ContentType.Password;
            EyeButton2.interactable = false;
            EyeButton2.interactable = true;
        }
        repassWord.ForceLabelUpdate();
    }

    public void DidNotReceivedEmail()
    {
        sentToThisEmailErrorMessage.text = emailAddress.text;
    }
}
