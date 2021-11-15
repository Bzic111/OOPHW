global using System;
global using System.Globalization;
global using System.Collections.Generic;
global using OOPHomework;
using OOPHomework.Figure;

ACoder coder = new();
BCoder coder2 = new();
string str = coder.Encode($"Hello new world!");
string str2 = coder2.Encode($"Hello new world!");
Console.WriteLine($"Encode\n{str}\n{str2}");
str = coder.Decode(str);
str2 = coder2.Decode(str2);
Console.WriteLine($"Decode\n{str}\n{str2}");



Point pt = new(3, 3);
Console.WriteLine(pt.GetInfo());
