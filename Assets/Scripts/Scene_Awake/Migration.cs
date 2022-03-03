using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Migration : MonoBehaviour
{
    public Text text;
    public Text verText;
    
    public DatabaseReference reference = null;


    public DataSnapshot ds;


    // Start is called before the first frame update

    

    void Start()
    {
        FirebaseApp.DefaultInstance.Options.DatabaseUrl =
                   new System.Uri("https://hsuon-4c8e4-default-rtdb.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.GetReference("user");


/*        for (int i = 0; i < stringArray.length; i++)
        {
            MigrationFireBase(stringArray[i]);
            Debug.Log(i + " cleared");
        }*/
    }


    void MigrationFireBase(string UID)
    {
        reference = reference.Child(UID);
        reference.Child("HC01").SetValueAsync(false);
        reference.Child("HC02").SetValueAsync(false);
        reference.Child("HC03").SetValueAsync(false);
        reference.Child("HC04").SetValueAsync(false);
        reference.Child("HC05").SetValueAsync(false);
        reference.Child("HC06").SetValueAsync(false);
        reference.Child("HC07").SetValueAsync(false);

        reference.Child("C01").SetValueAsync(false);
        reference.Child("C02").SetValueAsync(false);
        reference.Child("C03").SetValueAsync(false);
        reference.Child("C04").SetValueAsync(false);
        reference.Child("C05").SetValueAsync(false);
        reference.Child("C06").SetValueAsync(false);
        reference.Child("C07").SetValueAsync(false);
        reference.Child("C08").SetValueAsync(false);
        reference.Child("C09").SetValueAsync(false);
        reference.Child("C10").SetValueAsync(false);

        reference.Child("B01").SetValueAsync(false);
        reference.Child("B02").SetValueAsync(false);
        reference.Child("B03").SetValueAsync(false);
        reference.Child("B04").SetValueAsync(false);
        reference.Child("B05").SetValueAsync(false);
        reference.Child("B06").SetValueAsync(false);
        reference.Child("B07").SetValueAsync(false);
        reference.Child("B08").SetValueAsync(false);
        reference.Child("B09").SetValueAsync(false);
        reference.Child("B10").SetValueAsync(false);

        reference.Child("P01").SetValueAsync(false);
        reference.Child("P02").SetValueAsync(false);
        reference.Child("P03").SetValueAsync(false);
        reference.Child("P04").SetValueAsync(false);
        reference.Child("P05").SetValueAsync(false);
        reference.Child("P06").SetValueAsync(false);
        reference.Child("P07").SetValueAsync(false);
        reference.Child("P08").SetValueAsync(false);
        reference.Child("P09").SetValueAsync(false);
        reference.Child("P10").SetValueAsync(false);

        
    }

}
