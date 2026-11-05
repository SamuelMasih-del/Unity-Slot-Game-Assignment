using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ReelController : MonoBehaviour
{
    public Image[] symbols;
    public Sprite[] symbolSprites;

    public IEnumerator SpinReel(int finalSymbol, float spinTime)
    {
        float elapsed = 0f;
        float speed = 0.05f;
        while (elapsed < spinTime)
        {
            int random = Random.Range(0, symbolSprites.Length);
            foreach (Image img in symbols) img.sprite = symbolSprites[random];
            yield return new WaitForSeconds(speed);
            elapsed += speed;
            if (elapsed > spinTime * 0.7f) speed += 0.02f;
        }
        foreach (Image img in symbols) img.sprite = symbolSprites[finalSymbol];
    }
}
