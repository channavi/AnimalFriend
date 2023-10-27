using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;

public class AuthManager : MonoBehaviour
{
    [SerializeField] TMP_InputField emailField;
    [SerializeField] TMP_InputField passwordField;
    [SerializeField] TMP_InputField nameField;

    Firebase.Auth.FirebaseAuth auth;
    private void Start()
    {
        nameField.gameObject.SetActive(false);
    }
    void Awake()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }


    public void Login()
    {
        auth.SignInWithEmailAndPasswordAsync(emailField.text, passwordField.text).ContinueWith(
            task =>
            {
                if (task.IsCompleted && !task.IsFaulted && !task.IsCanceled)
                {
                    Debug.Log(emailField.text + "로 로그인 하셨습니다.");
                   
                }
                else
                {
                    Debug.Log("로그인에 실패하셨습니다.");
                }
            }
            );
    }
    public void Join()
    {
        auth.CreateUserWithEmailAndPasswordAsync(emailField.text, passwordField.text).ContinueWith(
            task =>
            {
                if (!task.IsCanceled && !task.IsFaulted)
                {
                    Debug.Log(emailField.text + "로 회원가입! \n");
                    nameField.gameObject.SetActive(true);
                }
                else
                {
                    Debug.Log("회원가입 실패 \n");
                }
            }
            );
    }
}