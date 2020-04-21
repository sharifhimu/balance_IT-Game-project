using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreGamesPanel : MonoBehaviour {

	public void ColorBlindPressed()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.agamilabs.colorblind&hl=en");
    }

    public void CommandoPressed()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.AGAMiLabs.TheCommando");
    }

    public void MailRunnerPressed()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.MiddayDreamz.MailRunner");
    }

    public void MagicBubblePressed()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.middayDreamz.MyBubble");
    }

    public void BackPressed()
    {
        GetComponent<Animator>().SetTrigger("out");
    }

    public void DisablePanel()
    {
        gameObject.SetActive(false);
    }
}
