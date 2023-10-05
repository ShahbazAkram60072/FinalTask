using System.Collections;
using UnityEngine;
public class BoxA : MonoBehaviour, ITaskHandler
{
    private PlayerScript player;
    public GameObject[] btnUI;
    public GameObject BxBtn,Text;
    public void TaskEnter(PlayerScript player)
    {
        if (!player.isCofinPicked)
        {
            player.ShowUnablePanel();
            return;
        }
        //GetComponent<BoxCollider>().enabled = false;
        //player.GetComponent<Rigidbody>().isKinematic = true;
        Cursor.lockState = CursorLockMode.Confined;
        this.player=player ;
        for (int i = 0; i < btnUI.Length; i++)
        {
            btnUI[i].SetActive(false);
        }
        BxBtn.SetActive(true);
    }
    private IEnumerator HidePanel()
    {
        Text.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Text.SetActive(false);
    }
    public void DropObject()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        player.GetComponent<Rigidbody>().isKinematic = false;
        Cursor.lockState = CursorLockMode.Locked;
        Destroy(GetComponent<BoxCollider>());
        transform.GetComponent<AudioSource>().Play();
        for (int i = 0; i < btnUI.Length; i++)
        {
            btnUI[i].SetActive(false);
        }
        player.weaponText.text = "Weapons : 0";
        player.PointsText.text = "Points : 0";
        player.InstrumentText.text = "Instruments : 0";
        StartCoroutine(HidePanel());
    }
    public void TaskExit(PlayerScript player)
    {
        if (!player.isCofinPicked)
        {
            return;
        }
        GetComponent<BoxCollider>().enabled = true;
        //player.GetComponent<Rigidbody>().isKinematic = false;
        Cursor.lockState = CursorLockMode.Locked;
        for (int i = 0; i < btnUI.Length; i++)
        {
            btnUI[i].SetActive(false);
        }
    }
}
