// See https://aka.ms/new-console-template for more information

using System.Diagnostics.Tracing;
using System.Globalization;

string[] words = new string[]
{
    "he",
    "waS",
    "she",
    "Was",
    "he",
    "wAs"
};

// 1. With dictionary
Dictionary<string, int> occurences = new();

foreach (string word in words)
{
    if (occurences.ContainsKey(word.ToLower()))
    {
        occurences[word.ToLower()] += 1;
    }
    else
    {
        occurences.Add(word.ToLower(), 1);
    }
}
/*for(int i = 0; i < words.Length; i++)
{
    int count = 1;
    for(int j = i + 1; j < words.Length; j++)
    {
        if (words[i].ToLower() == words[j].ToLower())
        {
            count++;
            occurences.Add(words[i].ToLower(), count);
        }
    }
}*/

foreach (KeyValuePair<string, int> occurence in occurences)
{
    Console.WriteLine($"{occurence.Key} -> {occurence.Value}");
}

int[] result = occurences.Values.ToArray();
Array.Sort(result);
Console.WriteLine($"{{{string.Join(", ", result)}}}");
foreach (int r in result) Console.WriteLine(r);

// 2. It works
var counts = words
    .GroupBy(w => w.ToLower())
    .Select(g => new { Word = g.Key, Count = g.Count() })
    .ToList();

foreach (var count in counts) Console.WriteLine(count);


// 3. Not working
/*Array.Sort(words);

List<int> counts = new ();
for (int i = 0; i < words.Length; i++)
{
    int count = 1;
    for (int j = 0; j < words.Length; j++)
    {
        if (i != j && words[j].ToLower() == words[i].ToLower())
        {
            count++;
        }
        else break;
    }
    counts.Add(count);
}
foreach (int c in counts) Console.WriteLine(c);
*/

// 4. Works but not properly
/*int Duplicate = words.Length + 1; //any value not in the range of the string array
for (int i = 0; i < words.Length; i++)
{
    int count = 1;
    for (int j = 0; j < words.Length; j++)
    {
        if (i != j)  //to avoid same string comparison
        {
            if (string.Compare(words[i].ToLower(), words[j].ToLower()) == 0)   //or else .Equals(0) 
            {
                count++;
                Duplicate = j;
            }
        }
    }
    if (i != Duplicate)
    {
        Console.WriteLine("{0}   {1}", words[i], count);
    }
}*/

