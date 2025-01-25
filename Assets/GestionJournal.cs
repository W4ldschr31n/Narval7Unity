using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GestionJournal : MonoBehaviour
{
    int indexPage;
    int maxPage = 10;
    public GameObject Page;

    private void Start()
    {
    }
    void Refresh()
    {
        for (int p = 0; p < Page.transform.childCount; p++)
        {
            Page.transform.GetChild(p).gameObject.SetActive(false);
        }
        for (int p = 0; p < Page.transform.childCount; p++)
        {
            if(p==indexPage)
            {
                Page.transform.GetChild(p).gameObject.SetActive(true);
            }
        }
    }
    public void PlusPage()
    {
        indexPage++;
        if (indexPage >= maxPage)
            indexPage = maxPage;
        Refresh();
    }
    public void MoinsPage()
    {
        indexPage--;
        if (indexPage <= 0)
            indexPage = 0;
        Refresh();
    }
}
