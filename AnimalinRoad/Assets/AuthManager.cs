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
        nameField.gameObject.SetActive(true);
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
                    Debug.Log(emailField.text + "�� �α��� �ϼ̽��ϴ�.");
                   
                }
                else
                {
                    Debug.Log("�α��ο� �����ϼ̽��ϴ�.");
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
                    Debug.Log(emailField.text + "�� ȸ������! \n");
                    nameField.gameObject.SetActive(true);
                }
                else
                {
                    Debug.Log("ȸ������ ���� \n");
                }
            }
            );
    }
}