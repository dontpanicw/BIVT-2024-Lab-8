using System.Dynamic;
using System.Text;
using System.Xml.XPath;

namespace Lab_8;

public class Blue_4 : Blue
{
    private int _output;
    public int Output => _output;

    public Blue_4(string input) : base(input){
        _output = 0;
    }

    public override void Review()
    {
        int currentNumber = 0;
        int sum = 0;
        bool inNumber = false;
        foreach (char tempChar in Input)
        {
            if (tempChar >= '0' && tempChar <= '9'){
                currentNumber = currentNumber * 10 + (tempChar - '0');
                inNumber = true;
            }
            else
            {
                if (inNumber)
                {
                    sum += currentNumber;
                    currentNumber = 0;
                    inNumber = false;
                }
            }
        }
        if (inNumber)
        {
            sum += currentNumber;
        }
        _output = sum;
    }

    public string ToString()
    {
        string result = "" + _output;
        return result;
    }
}

