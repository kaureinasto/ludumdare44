using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShowNextTickGain : MonoBehaviour
{
    private Text _text;
    private List<IAgeEffector> ageEffectors = new List<IAgeEffector>();

    private void Start()
    {
        _text = GetComponent<Text>();
        StartCoroutine(FindEffectors());
    }

    private IEnumerator FindEffectors()
    {
        while (ageEffectors.Count == 0)
        {
            ageEffectors = FindObjectsOfType<MonoBehaviour>().OfType<IAgeEffector>().ToList();
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Update()
    {
        float sum = 0f;
        foreach (IAgeEffector ageEffector in ageEffectors)
        {
            sum += ageEffector.GetEffectPerTick();
        }

        _text.text = "Total effect: " + sum.ToString("F1");
    }
}