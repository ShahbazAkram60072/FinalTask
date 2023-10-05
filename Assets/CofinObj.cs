using UnityEngine;

public class CofinObj : MonoBehaviour, ITaskHandler
{
    public GameObject UiStatus;
    public void TaskEnter(PlayerScript player)
    {
        GetComponent<BoxCollider>().enabled = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        UiStatus.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void TaskExit(PlayerScript player)
    {
        if (player.isCofinPicked)
            return;
        GetComponent<BoxCollider>().enabled = true;
        UiStatus.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);
        player.ItemsUI.SetActive(false);
        player.ItemUI2.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
