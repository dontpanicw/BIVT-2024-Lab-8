using System.Dynamic;
using System.Text;
using System.Xml.XPath;
using System.Text.RegularExpressions;

namespace Lab_8;

public class Blue_3 : Blue
{
    private (char, double)[] _output;
    public (char, double)[] Output{
        get
        {
            if (_output == null) return null;
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
        _output = null;
    }

    public override void Review()
    {
        if (string.IsNullOrWhiteSpace(Input)) return;
        (char, double)[] temp = new (char, double)[0];
        char[] firstChars = new char[0];
        int counterChars = 0;

        string cleaned = Input.Replace("\"", "").Replace("'", "");
        string cleanedStr = Regex.Replace(cleaned, @"\b[0-9\(\)\[\]\{\}\""][^\s]*", "").Replace("  ", " ").Trim();

        // string[] words = Input.Split(new[] { ' ' });

        // StringBuilder cleaned = new StringBuilder();

        // foreach (var word in words)
        // {
        //     if (word.Length == 0) continue;

        //     char firstChar = word[0];
            
        //     if (char.IsDigit(firstChar) || firstChar == '(' || firstChar == ')' || 
        //         firstChar == '[' || firstChar == ']' || firstChar == '{' || firstChar == '}')
        //     {
        //         continue; // пропускаем слово
        //     }

        //     cleaned.Append(word + " ");
        // }

        // string result = cleaned.ToString().Trim();

        //System.Console.WriteLine(cleanedStr);

        string result = cleanedStr.Replace(" –", "");
        string[] words = result.Split(' ');
        for(int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].ToLower();
        }

        foreach (string word in words)
        {
            int charIndex = 0;
            char[] characters = word.ToCharArray();
            if (characters[0].ToString() == "(")
            {
                charIndex = 1;
            }
            if (firstChars.Contains(characters[charIndex])){
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i].Item1 == characters[charIndex])
                    {
                        temp[i] = (temp[i].Item1, temp[i].Item2 + 1);
                    }
                }
                counterChars++;
            }
            else{
                Array.Resize(ref firstChars, firstChars.Length + 1);
                firstChars[firstChars.Length - 1] = characters[charIndex];
                Array.Resize(ref temp, temp.Length + 1);
                temp[temp.Length - 1] = (characters[charIndex], 1);
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
    
    // public override string ToString()
    // {
    //     if (_output == null || _output.Length == 0) return null;
    //     string result = "";
    //     for (int i = 0; i < Output.Length; i++)
    //     {
    //         if (i == Output.Length - 1){
    //             result += Output[i].Item1 + " - " + Output[i].Item2;
    //             break;
    //         }
    //         result += Output[i].Item1 + " - " + Output[i].Item2 + "\n";
    //     }
    //     return result;
    // }
    public override string ToString()
    {
        if (_output == null || _output.Length == 0) return null;
        StringBuilder result = new StringBuilder();
        
        for (int i = 0; i < Output.Length; i++)
        {
            result.Append(Output[i].Item1);
            result.Append(" - ");
            result.Append(Output[i].Item2.ToString("F4"));
            
            if (i != Output.Length - 1)
            {
                result.Append(Environment.NewLine);
            }
        }

        return result.ToString();
    }
}

