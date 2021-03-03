# WordCounter
Counting frequently used words in a file

This application was developed using C# and .net Core 3.1 in Visual Studio 2019.

How to run the program?
Download Executable folder, make sure to leave stopwords.txt, Text1.txt and Text2.txt in the same folder. Open command prompt and navigate into the folder containing the exe program. Type WordParser.exe to run the program. Once you are prompted, type the filename to see the frequently used 20 words in the file.

Output from Text1

us - 11
peopl - 10
Right - 10
Govern - 10
Law - 9
State - 9
power - 8
time - 6
among - 5
declar - 5
establish - 5
refus - 5
Form - 4
abolish - 4
new - 4
Coloni - 4
Assent - 4
larg - 4
Legislatur - 4
legisl - 4

Output from Text2

said - 462
Alice - 399
littl - 126
look - 104
like - 97
on - 94
know - 90
went - 83
go - 77
thing - 77
thought - 76
Queen - 76
time - 74
sai - 70
get - 68
see - 68
think - 64
King - 64
well - 60
Turtl - 60


This program takes a file, and reads all lines of the given file. For each line, it splits words using a space separator. After the words are split, it ignores empty words after replacing all non-alphabet characters, also checks if the word belongs to stop words list after removing leading and trailing non-alphabet characters. This program selects all words and replaces non-alphabet characters. It applies Porter Stemmer algorithm to stem words to a morphological root and then sorts word in a descending order to pick 20 most frequently used words.



