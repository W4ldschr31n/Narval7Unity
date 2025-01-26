using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GestionJournal : MonoBehaviour
{
    int indexPage;
    public int maxPage = 10;
    public GameObject Page;
    public Dictionary<int, bool> PageDebloquer;
    public Text txtPages;

    private void Start()
    {
        PageDebloquer = new Dictionary<int, bool>()
        {
            { 0, false},
            { 1, false},
            { 2, false },
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
                txtPages.text = $"Page {p}/3";
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
    public void AddPages(int nbNote)
    {
        PageDebloquer[nbNote] = true;
        Refresh();
    }
}
