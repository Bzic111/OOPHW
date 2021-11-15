using System.Text;
using OOPHomework.Interface;

namespace OOPHomework;
/// <summary>Шифрование со сдвигом на 1 символ</summary>
public class ACoder : ICoder
{
    public string Encode(string str)
    {
        char[] chrs = str.ToCharArray();
        StringBuilder sb = new StringBuilder(str.Length);
        for (int i = 0; i < chrs.Length; i++)
        {
            if (chrs[i] == 'z') sb.Append('a');
            else if (chrs[i] >= 'a' && chrs[i] < 'z') sb.Append(++chrs[i]);
            else if (chrs[i] == 'Z') sb.Append('A');
            else if (chrs[i] >= 'A' && chrs[i] < 'Z') sb.Append(++chrs[i]);
            else sb.Append(chrs[i]);
        }
        return sb.ToString();
    }
    public string Decode(string str)
    {
        char[] chrs = str.ToCharArray();
        StringBuilder sb = new StringBuilder(str.Length);
        for (int i = 0; i < chrs.Length; i++)
        {
            if (chrs[i] == 'a') sb.Append('z');
            else if (chrs[i] > 'a' && chrs[i] <= 'z') sb.Append(--chrs[i]);
            else if (chrs[i] == 'A') sb.Append('Z');
            else if (chrs[i] > 'A' && chrs[i] <= 'Z') sb.Append(--chrs[i]);
            else sb.Append(chrs[i]);
        }
        return sb.ToString();
    }
}