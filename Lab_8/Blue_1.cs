using System.Text;

namespace Lab_8;

public class Blue_1 : Blue
{
    private string[] _output;
    public string[] Output => _output;

    public Blue_1(string input) : base(input){
        _output = new string[0];
    }

    public override void Review()
    {
        string[] words = Input.Split(' ');
        string currentLine = "";
        string[] temp = new string[0];

        foreach (string word in words)
        {
            if ((currentLine.Length + word.Length + (currentLine.Length > 0 ? 1 : 0)) <= 50)
            {
                if (currentLine.Length > 0)
                    currentLine += " ";
                currentLine += word;
            }
            else
            {
                Array.Resize(ref temp, temp.Length + 1);
                temp[temp.Length - 1] = currentLine;
                currentLine = word;
            }
        }

        if (currentLine.Length > 0)
        {
            Array.Resize(ref temp, temp.Length + 1);
            temp[temp.Length - 1] = currentLine;
        }
        _output = temp;
    }
    
    public string ToString()
    {
        if (_output == null) return null;

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < _output.Length; i++)
        {
            sb.AppendLine(_output[i]);
        }
        return sb.ToString();
    }
}