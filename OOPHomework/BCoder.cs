using System.Text;
using OOPHomework.Interface;
namespace OOPHomework;

/// <summary>Шифрование со сдвигом в обратный порядок</summary>
public class BCoder : ICoder
{
    public string Encode(string str)
    {
        char[] chrs = str.ToCharArray();
        StringBuilder sb = new StringBuilder(str.Length);
        for (int i = 0; i < str.Length; i++)
        {
            if (chrs[i] >= 'A' && chrs[i] <= 'Z')
                sb.Append((char)('Z' - (chrs[i] - 'A')));
            else if (chrs[i] >= 'a' && chrs[i] <= 'z')
                sb.Append((char)('z' - (chrs[i] - 'a')));
            else if (chrs[i] >= 'А' && chrs[i] <= 'Я')
                sb.Append((char)('Я' - (chrs[i] - 'А')));
            else if (chrs[i] >= 'а' && chrs[i] <= 'я')
                sb.Append((char)('я' - (chrs[i] - 'а')));
            else sb.Append(chrs[i]);
        }
        return sb.ToString();
    }
    public string Decode(string str)
    {
        char[] chrs = str.ToCharArray();
        StringBuilder sb = new StringBuilder(str.Length);
        for (int i = 0; i < str.Length; i++)
        {
            if (chrs[i] >= 'A' && chrs[i] <= 'Z')
                sb.Append((char)('Z' - chrs[i] + 'A'));
            else if (chrs[i] >= 'a' && chrs[i] <= 'z')
                sb.Append((char)('z' - chrs[i] + 'a'));
            else if (chrs[i] >= 'А' && chrs[i] <= 'Я')
                sb.Append((char)('Я' - chrs[i] + 'А'));
            else if (chrs[i] >= 'а' && chrs[i] <= 'я')
                sb.Append((char)('я' - chrs[i] + 'а'));
            else sb.Append(chrs[i]);
        }
        return sb.ToString();
    }
}