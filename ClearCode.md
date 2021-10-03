f_len - filterLength // размер фильтра
filter_len - filter_length // размер фильтра
str1 - inputString // входная строка хэш-функции 1
str1 - inputString // входная строка хэш-функции 2
str1 - inputString // входная строка функции Add
index1 - indexFromHash1 // индекс массива, рассчитанный первой хэш функцией
index2 - indexFromHash2 // индекс массива, рассчитанный второй хэш функцией
str1 - inputString // входная строка функции IsValue
index1 - indexFromHash1 // индекс массива, рассчитанный первой хэш функцией
index2 - indexFromHash2 // индекс массива, рассчитанный второй хэш функцией
str - inputString // входная строка функции IsPalindrome
con1 - connectionNode1ToNode2 // направленное ребро между узлами 1 и 2
con2 - connectionNode2ToNode1 // направленное ребро между узлами 2 и 1
v1 - vertex1 // узел номер 1
v2 - vertex2 // узел номер 2
c - charArray // массив символов
dico - dictionaryCharacterCount // словарь количества повторений символов
i - indexInItems // индекс строки s в массиве items

6.1
r - resultListOfNodes
found - nodeToDelete
sum - sumOfWeights
output - recognitionResult
array - stackValuesAsArray

6.2
AST - Abstract Syntacs Tree
BST - Binary Search Tree
RMQ - Range Minimum Query
LCA - Least Common Ancestor

6.3
var temp в функции Swap
var node в функции Add
var currentNode в функции Merge

6.4
sz - cacheSize
data - choiceTableValue
table - choiceTable
cur - currentValueOfGain
max - maxGainCriterion


7.1
right - isRight
leftBalanced - isLeftBalanced
rightBalanced - isRightBalanced
correctLeftRigthDepth - isCorrectLeftRigthDepth
CheckPalindrome - IsPalindrome

7.2
result - found
flag - success
result - done


7.3 
for (int i = _levels; i >= 0; i--) // можно вместо i - currentLevel
for (var i = nodesInLine.Count - 1; i >= 0; i--) // можно вместо i - currentNode

7.4
first = Find(first); second = Find(second); // можно вместо second использовать last
for (int i = start; i <= stop; i++) // здесь пара start/stop. Stop можно переименовать в finish

7.5
private void Swap(int index, int current)
{
    var temp = HeapArray[index];
    HeapArray[index] = HeapArray[current];
    HeapArray[current] = temp;
}
заменён на:
private void Swap(int index, int current)
{
    var valueForIndex = HeapArray[index]; // временная переменная переименована для наглядности
    HeapArray[index] = HeapArray[current];
    HeapArray[current] = valueForIndex;
}


public static bool IsBalances(string str)
{
    var stack = new Stack<char>();
    var temp = str;

    while (temp.Length > 0)
    {
        if(temp[0] == '(')
            stack.Push(temp[0]);
        if (temp[0] == ')')
        {
            if (stack.Size() == 0) return false;
            stack.Pop();
        }    
        temp = temp.Substring(1);
    }

    return stack.Size() == 0;
}
заменён на:
public static bool IsBalances(string stringToCheck) // Имя аргумента функции IsBalances сделано более наглядным 
{
    var stack = new Stack<char>();

    while (stringToCheck.Length > 0) // избавился от временной переменной temp
    {
        if(stringToCheck[0] == '(')
            stack.Push(stringToCheck[0]);
        if (stringToCheck[0] == ')')
        {
            if (stack.Size() == 0) return false;
            stack.Pop();
        }    
        stringToCheck = stringToCheck.Substring(1);
    }

    return stack.Size() == 0;
}


7. Задания (12 примеров имён в вашем коде, которые следует избегать)
1.
было: private readonly LinkedList<T> list;
стало: private readonly LinkedList<T> internalStorageList;

2.
было: public DecisionTree(Dictionary<string, List<string>> table, string criterion)
стало: public DecisionTree(Dictionary<string, List<string>> choiceTable, string criterion)

3.
было: public double CalculateEntropy(Dictionary<string, List<string>> table, string parentCriterion, string criterion, string criterionValue)
стало: public double CalculateEntropy(Dictionary<string, List<string>> choiceTable, string parentCriterion, string criterion, string criterionValue)

4.
было: public double CalculateEntropy(Dictionary<string, List<string>> table, string criterion)
стало: public double CalculateEntropy(Dictionary<string, List<string>> choiceTable, string criterion)

5.
было: public double CalculateGain(Dictionary<string, List<string>> table, string parentCriterion, string criterion)
стало: public double CalculateGain(Dictionary<string, List<string>> choiceTable, string parentCriterion, string criterion)

6.
было: private void FormChilds(Dictionary<string, List<string>> table, DecisionTreeNode currentNode, string initialCriterion, Dictionary<string, DecisionTreeNode> leafs)
стало: private void FormChilds(Dictionary<string, List<string>> choiceTable, DecisionTreeNode currentNode, string initialCriterion, Dictionary<string, DecisionTreeNode> leafs)

7.
было: private Dictionary<string, List<string>> FilterTable(Dictionary<string, List<string>> table, string maxGainCriterion, string value)
стало: private Dictionary<string, List<string>> FilterTable(Dictionary<string, List<string>> choiceTable, string maxGainCriterion, string value)

8.
было: private static Dictionary<string, List<string>> table;
стало: private static Dictionary<string, List<string>> choiceTable;

9.
было: private string GetMaxGainCriterion(Dictionary<string, List<string>> table, string parentCriterion, List<string> otherCriterions)
стало: private string GetMaxGainCriterion(Dictionary<string, List<string>> choiceTable, string parentCriterion, List<string> otherCriterions)

10.
было: var list1 = new LinkedList();
стало: var firstTermList = new LinkedList();

11.
было: var list2 = new LinkedList();
стало: var lastTermList = new LinkedList();

12.
было: var sum = LinkedListExtra.AddTogether(firstTermList, lastTermList);
стало: var summaryList = LinkedListExtra.AddTogether(firstTermList, lastTermList);
