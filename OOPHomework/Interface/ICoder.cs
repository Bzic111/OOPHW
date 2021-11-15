using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPHomework.Interface
{
    /// <summary>Шифрование</summary>
    internal interface ICoder
    {
        /// <summary>Зашифровать строку <paramref name="str"/></summary>
        /// <param name="str">Изменяемая строка</param>
        /// <returns>Зашифрованная строка</returns>
        public string Encode(string str);
        /// <summary>Расшифровать строку <paramref name="str"/></summary>
        /// <param name="str">Изменяемая строка</param>
        /// <returns>Расшифрованная строка</returns>
        public string Decode(string str);
    }
}
