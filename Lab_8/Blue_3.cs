using System.Dynamic;
using System.Text;
using System.Xml.XPath;

namespace Lab_8;

public class Blue_3 : Blue
{
    private (char, double)[] _output;
    public (char, double)[] Output{
        get
        {
            (char, double)[] result = new (char, double)[_output.Length];
            _output.CopyTo(result, 0);

            for (int i = 0; i < result.Length - 1; i++)
            {
                for (int j = 0; j < result.Length - i - 1; j++)
                {
                    if (result[j].Item2 < result[j + 1].Item2)
                    {
                        (char, double) tmp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = tmp;
                    }
                    else if (result[j].Item2 == result[j + 1].Item2)
                    {
                        if (result[j].Item1 > result[j + 1].Item1)
                        {
                            (char, double) tmp = result[j];
                            result[j] = result[j + 1];
                            result[j + 1] = tmp;
                        }
                    }
                }
            }

            return result;
        }
    }

    public Blue_3(string input) : base(input){
        _output = new (char, double)[0];
    }

    public override void Review()
    {
        (char, double)[] temp = new (char, double)[0];
        char[] firstChars = new char[0];
        int counterChars = 0;

        string result = Input.Replace(" –", "");
        string[] words = result.Split(' ');
        for(int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].ToLower();
        }

        foreach (string word in words)
        {
            char[] characters = word.ToCharArray();
            if (firstChars.Contains(characters[0])){
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i].Item1 == characters[0])
                    {
                        temp[i] = (temp[i].Item1, temp[i].Item2 + 1);
                    }
                }
                counterChars++;
            }
            else{
                Array.Resize(ref firstChars, firstChars.Length + 1);
                firstChars[firstChars.Length - 1] = characters[0];
                Array.Resize(ref temp, temp.Length + 1);
                temp[temp.Length - 1] = (characters[0], 1);
                counterChars++;
            }
        }
        for (int i = 0; i < temp.Length; i++)
                {
                double percent = Math.Round(temp[i].Item2/counterChars * 100, 4);
                temp[i] = (temp[i].Item1, percent);

        _output = temp;
                }

    }
    
    public string ToString()
    {
        string result = "";
        foreach ((char, double) pair in Output)
        {
            result += pair.Item1 + " - " + pair.Item2 + "\n";
        }
        return result;
    }
}

