using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class ProgresBar : MonoBehaviour
{

    [SerializeField] private Image filler;

    [SerializeField] private Text percentage;

    [Range(0,1.0f)][SerializeField]
    private float percentageValue = 0;


    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(IncrementProgressBar());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IncrementProgressBar() {

        while (percentageValue <= 1.0f) {
            percentageValue += 0.1f;
            filler.fillAmount = percentageValue;
            percentage.text = $" {percentageValue * 100} %";
            yield return new WaitForSeconds(1.0f);
            
        }
    
    }


}
