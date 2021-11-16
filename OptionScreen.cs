using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionScreen : MonoBehaviour
{
    public Toggle fullscreenTog, vsyncTog;
    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedResulotion;
    public TMP_Text resolutionLabel;

    // Start is called before the first frame update
    void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }
        else
        {
            vsyncTog.isOn = true;
        }
        bool foundRes = false;
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;
                selectedResulotion = i;

                UpdateResLabel();
            }
        }
        if(!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;
            resolutions.Add(newRes);
            selectedResulotion = resolutions.Count - 1;

            UpdateResLabel();
        }
    }
    
    // Update is called once per frame
    void Update()
    {

    }
    public void ResLeft()
    {
        selectedResulotion--;
        if(selectedResulotion < 0)
        {
            selectedResulotion = 0;
        }
        UpdateResLabel();
    }

    public void ResRight()
    {
        selectedResulotion++;
        if(selectedResulotion > resolutions.Count -1)
        {
            selectedResulotion = resolutions.Count - 1;
        }
        UpdateResLabel();
    }
    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResulotion].horizontal.ToString() + " x " + resolutions[selectedResulotion].vertical.ToString();
    }
    public void ApplyGraphics()
    {
        //Screen.fullScreen = fullscreenTog.isOn;
       
        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
    else
        {
            QualitySettings.vSyncCount = 0;
        }
        Screen.SetResolution(resolutions[selectedResulotion].horizontal, resolutions[selectedResulotion].vertical, fullscreenTog.isOn);
    }
}
[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}
