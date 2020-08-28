using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]

public class NameGenerator : MonoBehaviour
{
    string[] firstname = new string[] { "John", "Alex", "Jenny", "Skylar", "Charlie", "Ashleigh", "Shannon", "Sid", "James", "Rex", "Mackenzie", "Leslie", "Harley", "Zion", "Max"};
    string[] lastname = new string[] { "Smith", "Jones", "Lee", "James", "Benton", "Ferris", "Nova", "Carlton", "Croft", "Danger", "Robinson", "Livingstone", "Tear", "Stark", "Watney"};

    void Start()
    {
        Text text = GetComponent<Text>();
        string fName = firstname[Random.Range(0, firstname.Length-1)];
        string lName = lastname[Random.Range(0, lastname.Length - 1)];
        text.text = fName + " " + lName;
    }
}
