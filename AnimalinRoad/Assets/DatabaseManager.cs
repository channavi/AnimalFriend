using Firebase.Auth;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
public class DatabaseManager : MonoBehaviour
{
    private DatabaseReference reference;
    private Firebase.Auth.FirebaseUser user;

    // Start is called before the first frame update
    void Start()
    {
        // Set up the reference to the Firebase database
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        // Get the current user
        user = FirebaseAuth.DefaultInstance.CurrentUser;
    }

    // Method to set the nickname for the current user
    public void SetNickname(string nickname)
    {
        // Check if the user is logged in
        if (user != null)
        {
            // Set the nickname in the database
            reference.Child("users").Child(user.UserId).Child("nickname").SetValueAsync(nickname).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("Nickname set successfully.");
                }
                else
                {
                    Debug.LogError("Failed to set nickname.");
                }
            });
        }
        else
        {
            Debug.LogError("User not logged in.");
        }
    }
}
