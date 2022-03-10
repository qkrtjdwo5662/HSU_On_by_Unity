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

	public DatabaseReference reference;


	public DataSnapshot ds;

	// Start is called before the first frame update
	public List<string> UID = new List<string>()
	{
		//Userid
	};


	void Start()
	{
		FirebaseApp.DefaultInstance.Options.DatabaseUrl =
				   new System.Uri("https://hsuon-4c8e4-default-rtdb.firebaseio.com/");

		reference = FirebaseDatabase.DefaultInstance.RootReference;


		for (int i = 0; i < UID.Count; i++)
		{
			MigrationFireBase(UID[i]);
			Debug.Log(i + " cleared");
		}
	}


	void MigrationFireBase(string UID)
	{
		reference = FirebaseDatabase.DefaultInstance.GetReference("users").Child(UID);

		//필드추가 : reference.Child("필드이름").SetValueAsync();
		//필드삭제 : reference.Child("필드이름").RemoveValueAsync();
		
		//추가 
		reference.Child("HC01").SetValueAsync(false);
		reference.Child("HC02").SetValueAsync(false);
		reference.Child("HC03").SetValueAsync(false);
		reference.Child("HC04").SetValueAsync(false);
		reference.Child("HC05").SetValueAsync(false);
		reference.Child("HC06").SetValueAsync(false);
		reference.Child("HC07").SetValueAsync(false);
		reference.Child("HC08").SetValueAsync(false);
		reference.Child("HC09").SetValueAsync(false);
		reference.Child("HC10").SetValueAsync(false);

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

		reference.Child("PET01").SetValueAsync(false);
		reference.Child("PET02").SetValueAsync(false);
		reference.Child("PET03").SetValueAsync(false);
		reference.Child("PET04").SetValueAsync(false);
		reference.Child("PET05").SetValueAsync(false);
		reference.Child("PET06").SetValueAsync(false);
		reference.Child("PET07").SetValueAsync(false);
		reference.Child("PET08").SetValueAsync(false);
		reference.Child("PET09").SetValueAsync(false);
		reference.Child("PET10").SetValueAsync(false);

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

		reference.Child("money").SetValueAsync(2000);


		//삭제
		reference.Child("Hair01").RemoveValueAsync();
		reference.Child("Hair02").RemoveValueAsync();
		reference.Child("Hair03").RemoveValueAsync();
		reference.Child("Hair04").RemoveValueAsync();
		reference.Child("Hair05").RemoveValueAsync();
		reference.Child("Hair06").RemoveValueAsync();
		reference.Child("Hair07").RemoveValueAsync();
		reference.Child("Hair08").RemoveValueAsync();
		reference.Child("Hair09").RemoveValueAsync();
		reference.Child("Hair10").RemoveValueAsync();

		reference.Child("Shirts01").RemoveValueAsync();
		reference.Child("Shirts02").RemoveValueAsync();
		reference.Child("Shirts03").RemoveValueAsync();
		reference.Child("Shirts04").RemoveValueAsync();
		reference.Child("Shirts05").RemoveValueAsync();
		reference.Child("Shirts06").RemoveValueAsync();
		reference.Child("Shirts07").RemoveValueAsync();
		reference.Child("Shirts08").RemoveValueAsync();
		reference.Child("Shirts09").RemoveValueAsync();
		reference.Child("Shirts10").RemoveValueAsync();

		reference.Child("Pants01").RemoveValueAsync();
		reference.Child("Pants02").RemoveValueAsync();
		reference.Child("Pants03").RemoveValueAsync();
		reference.Child("Pants04").RemoveValueAsync();
		reference.Child("Pants05").RemoveValueAsync();
		reference.Child("Pants06").RemoveValueAsync();
		reference.Child("Pants07").RemoveValueAsync();
		reference.Child("Pants08").RemoveValueAsync();
		reference.Child("Pants09").RemoveValueAsync();
		reference.Child("Pants10").RemoveValueAsync();

		reference.Child("Pet01").RemoveValueAsync();
		reference.Child("Pet02").RemoveValueAsync();
		reference.Child("Pet03").RemoveValueAsync();
		reference.Child("Pet04").RemoveValueAsync();
		reference.Child("Pet05").RemoveValueAsync();
		reference.Child("Pet06").RemoveValueAsync();
		reference.Child("Pet07").RemoveValueAsync();
		reference.Child("Pet08").RemoveValueAsync();
		reference.Child("Pet09").RemoveValueAsync();
		reference.Child("Pet10").RemoveValueAsync();


		reference.Child("Money").RemoveValueAsync();


	}
}
