using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public Button head;
    public Button body;
    public Button pantsu;

    public Text descript;

    [TextArea(3,10)]
    public List<string> Descriptions;

    void Start()
    {

        head.onClick.AddListener(delegate
        {

            ApplyText(0);

        });

        pantsu.onClick.AddListener(delegate
        {

            ApplyText(2);

        });

        body.onClick.AddListener(delegate
        {

            ApplyText(1);

        });
    }

    public void ApplyText(int ind)
    {

        descript.text = Descriptions[ind];

    }

    public void ApagarText(int ind)
    {
        descript.text = "";
    }

}
