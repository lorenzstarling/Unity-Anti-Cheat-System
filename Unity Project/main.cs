using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    [SerializeField] private Button btnAdd;
    [SerializeField] private TMP_Text ValueTxt;

    int count = 0;
    ProtectedValue CountProtected;
    private void Awake()
    {
        InitValues();
        btnAdd.onClick.AddListener(AddValue);
    }

    private void Update()
    {
        if (CountProtected.CompareValue(count))
        {
            ValueTxt.text = "Value: " + count;
        }
    
    }
    private void InitValues()
    {
        CountProtected = new ProtectedValue(count);
        count = CountProtected.GetInt();
    }

    private void AddValue()
    {
        if (CountProtected.CompareValue(count))
        {
            count += 1;
            CountProtected.ApplyNewValue(count);
        }
        else
        {
            count = CountProtected.GetInt();
            Debug.LogError("CHEAT DETECTED!");
        }
    }

}
