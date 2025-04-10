using System.Text;

namespace Lab_8;

public class Blue_2 : Blue
{
    private string _garbage;
    private string _output;
    public string Output => _output;

    public Blue_2(string input, string garbage) : base(input){
        _garbage = garbage;
        _output = "";
    }

    public override void Review()
    {
        string[] words = Input.Split(' ');
        string resultLine = "";
        string[] temp = new string[0];
        _output = Input;
        foreach (string word in words){
            if (word.Contains(_garbage))
            {
                char[] characters = word.ToCharArray();
                string tempChar = Convert.ToString(characters[characters.Length - 1]);
                if (tempChar == "." || tempChar == "," || tempChar == ";") resultLine = _output.Replace(" " + word, "" + tempChar);
                else resultLine = _output.Replace(word + " ", "");
                _output = resultLine;
            }
        }
        _output = _output.Replace("  ", "");
        _output = _output.Trim();
    }
    
    public string ToString()
    {
        return _output;
    }
}