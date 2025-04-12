using System.Text;

namespace Lab_8;

public class Blue_2 : Blue
{
    private string _garbage;
    private string _output;
    public string Output => _output;

    public Blue_2(string input, string garbage) : base(input){
        _garbage = garbage;
        _output = null;
    }

    public override void Review()
    {
        if (Input == null || _garbage == null) {
        _output = null;
        return;
        }
        string[] words = Input.Split(' ');
        string resultLine = "";
        string[] temp = new string[0];
        _output = Input;
        foreach (string word in words){
            if (word.Contains(_garbage))
            {
                if (word.Contains(".") || word.Contains(",") || word.Contains(";")){
                    char[] characters = word.ToCharArray();
                    if (word.Contains("\"")){
                        resultLine = _output.Replace(word + " ",  "\"\"" + characters[characters.Length - 1] + " ");
                    }
                    else{
                        resultLine = _output.Replace(" " + word, "" + characters[characters.Length - 1]);
                    }
                    _output = resultLine;
                }
                else {
                    resultLine = _output.Replace(word + " ", "");
                    _output = resultLine;
                }
                // char[] characters = word.ToCharArray();
                // string endChar = Convert.ToString(characters[characters.Length - 1]);
                // string beginChar = Convert.ToString(characters[0]);
                // if (beginChar == "\"" && Convert.ToString(characters[characters.Length - 2]) == "\""){
                //     resultLine = _output.Replace(word, "\"\"");
                //     System.Console.WriteLine(resultLine);
                // }
                // else if (endChar == "." || endChar == "," || endChar == ";") resultLine = _output.Replace(" " + word, "" + endChar);
                // else resultLine = _output.Replace(word + " ", "");
                // _output = resultLine;
            }
        }
        _output = _output.Replace("  ", "");
        _output = _output.Trim();
       
    }
    
    public override string ToString()
    {
        if (String.IsNullOrEmpty(Output)) return null;
        return Output;
    }
}