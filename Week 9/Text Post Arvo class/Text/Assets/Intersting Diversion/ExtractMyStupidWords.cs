using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExtractMyStupidWords : MonoBehaviour {

    public TextAsset text;
    public string result;

    public string[] tmp;

    private readonly string FRONT_TOKEN = "* '''";
    private readonly string TRIPPLE_QUOTE = "'''";

    // Use this for initialization
    void Start () {
        string parseThis = text.text;

        var splitRes = parseThis.Split("\n".ToCharArray());

        var onlyValidLines = splitRes.Where(x => x.StartsWith(FRONT_TOKEN));

        //tmp = onlyValidLines.ToArray();

        var trimFront = onlyValidLines.Select(x => x.Substring(FRONT_TOKEN.Length));

        //tmp = trimFront.ToArray();

        var justTheWords = trimFront.Select(x => x.Substring(0,x.IndexOf(TRIPPLE_QUOTE)));

        var justWordsAsArray = justTheWords.ToArray();

        result = string.Join("\n", justWordsAsArray);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
