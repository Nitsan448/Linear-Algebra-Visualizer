using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvertButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate { Managers.Transformations.InvertMatrix(); });
    }
}
