using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    internal bool isCofinPicked = false;
    internal bool isPickiing = false;
    public Text weaponText, PointsText, InstrumentText;
    public GameObject ItemsUI,ItemUI2,NotPickedUI,Cofin;
    private bool isRestarted = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ITaskHandler>() != null)
        {
            isPickiing = true;
            other.GetComponent<ITaskHandler>().TaskEnter(this);
        }
    }

    public void ShowUnablePanel()
    {
        NotPickedUI.SetActive(true);
        StartCoroutine(HidePanel());
    }

    private IEnumerator HidePanel()
    {
        yield return new WaitForSeconds(1.5f);
        NotPickedUI.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ITaskHandler>() != null)
        {
            isPickiing = false;
            other.GetComponent<ITaskHandler>().TaskExit(this);
        }
    }
    public void PickItem(int item)
    {
        Cofin.SetActive(false);
        switch (item)
        {
            case 1:
                weaponText.text = "Weapons : 1";
                isCofinPicked = true;
                EnableThings();
                break;
            case 2:
                PointsText.text = "Points : 1";
                isCofinPicked = true;
                EnableThings();
                break;
            case 3:
                InstrumentText.text = "Instruments : 1";
                isCofinPicked = true;
                EnableThings();
                break;
        }
    }
    private void EnableThings()
    {
        ItemsUI.SetActive(false);
        ItemUI2.SetActive(false);
        isPickiing = false;
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<Rigidbody>().isKinematic = false;
    }

    private void Update()
    {
        if(isRestarted)
            return;
        if (Input.GetKey(KeyCode.R))
        {
            isRestarted = true;
            SceneManager.LoadScene(0);
        }
    }
}
