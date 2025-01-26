using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GestionJournal : MonoBehaviour
{
    int indexPage;
    public int maxPage = 10;
    public GameObject Page;
    public Dictionary<int, bool> PageDebloquer;

    private void Start()
    {
        PageDebloquer = new Dictionary<int, bool>()
        {
            { 0, true},
            { 1, false},
            { 2, false },
            { 3, false },
            { 4, false },
            { 5, true },
            { 6, false },
            { 7, false },
            { 8, true },
            { 9, false },
        };
        indexPage = 0;
        Refresh();
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
        int indexCourant = indexPage + 1;
        while(indexCourant%maxPage != indexPage)
        {
            if(PageDebloquer[indexCourant % maxPage])
            {
                indexPage = indexCourant % maxPage;
                break;
            }
            indexCourant++;
        }
        Refresh();
    }
    public void MoinsPage()
    {
        int indexCourant = indexPage - 1;
        while (indexCourant % maxPage != indexPage)
        {
            if (indexCourant < 0)
                indexCourant = maxPage - 1;
            if (PageDebloquer[indexCourant % maxPage])
            {
                indexPage = indexCourant % maxPage;
                break;
            }
            indexCourant--;
            
        }
        Refresh();
    }
}
