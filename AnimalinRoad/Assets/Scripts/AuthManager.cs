using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using Firebase.Extensions;
using System;

public class User
{
    public string username;
    public string email;

    public User()
    {
    }

    public User(string username, string email)
    {
        this.username = username;
        this.email = email;
    }
}
public class AuthManager : MonoBehaviour
{
    [SerializeField] TMP_InputField emailField;
    [SerializeField] TMP_InputField passwordField;
    [SerializeField] TMP_InputField nameField;
    public bool isLog = false;
    public bool isJoin = false;
    public GameObject pannel;
    public GameObject pannel2;
    public TextMeshProUGUI nametext;

    DatabaseReference mDatabaseRef;
    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;
    private void Start()
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        isLog = false;
        isJoin = false;
        pannel.SetActive(false);
        pannel2.SetActive(false);
        nametext.text = "";
        InitializeFirebase();
    }

    protected virtual void InitializeFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;

            mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;

        });
    }
    void Awake()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        AppOptions options = new AppOptions { DatabaseUrl = new Uri("https://animalfreindserver-default-rtdb.firebaseio.com/") };
    }


    public void Login()
    {
        auth.SignInWithEmailAndPasswordAsync(emailField.text, passwordField.text).ContinueWith(
            task =>
            {
                if (task.IsCompleted && !task.IsFaulted && !task.IsCanceled)
                {
                    Debug.Log(emailField.text + "�� �α��� �ϼ̽��ϴ�.");
                    isLog = true;
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
                    isJoin = true;
                }
                else
                {
                    Debug.Log("ȸ������ ���� \n");
                }
            }
            );
    }

    public void setName()
    {
        Firebase.Auth.FirebaseUser user = auth.CurrentUser;
        if (user != null)
        {
            Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile
            {
                DisplayName = nameField.text,
            };
            user.UpdateUserProfileAsync(profile).ContinueWith(task => {
                if (task.IsCanceled)
                {
                    Debug.LogError("UpdateUserProfileAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
                    return;
                }

                Debug.Log("User profile updated successfully.");
            });
        }
        isJoin = false;
    }
    private void writeNewUser(string userId, string name, string email)
    {
        User user = new User(name, email);
        string json = JsonUtility.ToJson(user);
        Debug.Log("���ø�Ʈ1");
        mDatabaseRef.Child("users").Child(userId).SetRawJsonValueAsync(json);
        Debug.Log("���ø�Ʈ2");
    }
    private void Update()
    {
        if ( isLog == true)
        {
            Firebase.Auth.FirebaseUser user = auth.CurrentUser;
            if (user != null)
            {
                string Newname = user.DisplayName;
                string Newemail = user.Email;
                string Newuid = user.UserId;
                pannel2.SetActive(true);
                nametext.text = "Welcome! " + Newname.ToString();
                
            }
            //writeNewUser(user.UserId, user.DisplayName, user.Email);
        }
        if( isJoin == true ) 
        {
            pannel.SetActive(true);
        }
    }
}