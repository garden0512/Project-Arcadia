using UnityEngine;
using TMPro;
using System.Collections;

namespace Arcadia.Prototype.ComprehensiveEffectPrototypeVer1
{
    public class StageStartBlinkText : MonoBehaviour
    {
        public TextMeshProUGUI stageNumber;
        public TextMeshProUGUI stageName;

        public void Start()
        {
            stageName.gameObject.SetActive(false);
            stageNumber.gameObject.SetActive(false);
            StartCoroutine(DelayAndBlinkText());
        }

        IEnumerator DelayAndBlinkText()
        {
            yield return new WaitForSeconds(2f);
            stageNumber.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
            stageName.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            stageNumber.gameObject.SetActive(false);
            stageName.gameObject.SetActive(false);
        }
    }
}