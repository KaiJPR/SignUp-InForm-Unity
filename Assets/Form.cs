using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Form : MonoBehaviour
{
    public GameObject SignUpForm;
    public GameObject LoginForm;
    public TMP_InputField signup_username;
    public TMP_InputField signup_password;
    public TMP_InputField signin_username;
    public TMP_InputField signin_password;
    public GameObject Success;
    public GameObject Fail;
    string[] username_list = new string[100];
    string[] password_list = new string[100];
    int counter = 0;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            SignUpForm.SetActive(false);
            LoginForm.SetActive(true);
        }
    }
    public void SignUp()
    {
        username_list[counter] = signup_username.text;
        password_list[counter] = signup_password.text;

        counter += 1;
    }
    public void SignIn()
    {
        if (PlayerPrefs.HasKey(signin_username.text))
        {
            if(PlayerPrefs.GetString(signin_username.text) == signin_password.text)
            {
                Success.SetActive(true);
            }
            else
            {
                Fail.SetActive(true);
            }
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Save", 0);
        for(int i = 0; i < username_list.Length; i++)
        {
            PlayerPrefs.SetString(username_list[i], password_list[i]);
        }
    }
}
