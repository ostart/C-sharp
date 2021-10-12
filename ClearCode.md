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


3.1. Улучшите пять имён классов в вашем коде.
Data - Key
Manager - TaskManager
Settings - ApplicationSettings
Executor - TaskExecutor
JobData - JobDetails


3.2. Улучшите семь имён методов и объектов по схеме из пункта 2.
TimerTicks - TimerTicksInSeconds
MinNumOfTasks - MinNumberOfTasks
CreateNackResponse - ToNackResponse
GetOpenApiMessageType - ToOpenApiMessageType
ConvertToXmlString - ToXmlString
FinMinMax - FindMinOrMaxValueInSubTree
CalcCount - CalculateNodesInTreeToCounter


12 улучшений имён функций/методов в вашем коде в формате "было - стало - ваш комментарий"
1.
было: GetNotVisited
стало: GetNotVisitedVertexIndex
комментарий: не хватало наглядности

2.
было: TimerTicks
стало: TimerTicksInSeconds
комментарий: не хватало размерности

3.
было: DeleteNode
стало: DeleteNodeByKey
комментарий: добавлен параметр в имя, хотя возможно это избыточно, т.к. параметр ясен из имени аргумента функции

4.
было: CheckPalindrome
стало: IsPalindrome
комментарий: проще и нагляднее

5.
было: index
стало: GetIndexAndMakeReplace
комментарий: восстановлено правило именования функциий в C#, внесена конкретика и обозначен побочный эффект

6.
было: replace
стало: ReplaceAndReturnNew
комментарий: восстановлено правило именования функциий в C#, внесена конкретика

7.
было: CalcCount
стало: CalculateNodesInTreeToGetCounter
комментарий: добавлена наглядность и описание возвращаемого значения

8.
было: Find
стало: FindSlotIndex
комментарий: добавлена наглядность и описание возвращаемого значения

9.
было: Put
стало: PutAndReturnNewSlotIndex
комментарий: добавлена наглядность и обозначен побочный эффект

10.
было: HashFun
стало: CalculateHashFunction
комментарий: добавлена наглядность

11.
было: Hash1
стало: CalculateFirstHashFunction
комментарий: добавлена наглядность и устранены цифры в имени функции

12.
было: Hash2
стало: CalculateSecondHashFunction
комментарий: добавлена наглядность и устранены цифры в имени функции

3.1. Сделайте в своём коде три примера наглядных методов-фабрик
На C# не нашёл. Нашёл в коде на JS
1) Точка в декартовом пространстве с внутренним представлением в полярных координатах
const makeDecartPoint = (x, y) => {
  return {
    angle: Math.atan2(y, x),
    radius: Math.sqrt(x ** 2 + y ** 2)
  };
}
2) Рациональное число с чилителем и знаменателем
const makeRational = (numer, denom) => `${numer}/${denom}`;
const num = makeRational(numer, denom);
3) Различные конверторы, например:
public static DateTime XmlToDateTime(XmlNode node)
{
    var year = Convert.ToInt32(node["Year"]?.InnerText);
    var month = Convert.ToInt32(node["Month"]?.InnerText);
    var day = Convert.ToInt32(node["Day"]?.InnerText);
    var hour = Convert.ToInt32(node["Hour"]?.InnerText);
    var minute = Convert.ToInt32(node["Minute"]?.InnerText);
    return new DateTime(year, month, day, hour, minute, 0);
}

3.2. Если вы когда-нибудь использовали интерфейсы или абстрактные классы, напишите несколько примеров их правильного именования
было:
internal interface IAssemblerInterpreter
public class AssemblerInterpreter : IAssemblerInterpreter
стало:
internal interface AssemblerInterpreter
public class AssemblerInterpreterImp : AssemblerInterpreter

было:
public interface IBookRepository
public class BookRepository: IBookRepository
стало:
public interface BookRepository
public class BookRepositoryImp: BookRepository


Внесите 12 правок в свой код, в которых улучшите работу с константами, и напишите по каждой, что конкретно вы улучшили
1. const string StatusCoverOpen = '3'; // уточнено, что это именно именованная константа статуса
2. const string StatusPaperJam = '8'; // уточнено, что это именно именованная константа статуса
3. const string StatusInputEmpty = '808'; // уточнено, что это именно именованная константа статуса
4. private const string DelimiterInCsvFiles = ";"; // уточнено, что разделитель именно в CSV файлах
5. private const int FilePackSizePerDequeuing = 10000; // количество файлов вытаскиваемых из очереди за один шаг
6. private const int DefaultDeviceId = 0; // идентификатор устройства по умолчанию
7. private const int LocalDeviceId = 100000; // идентификтор локального устройства
8. private const string MacAddressSeparator = ";"; // уточнил, что это разделитель в Мас-адресах
9. private const int MaximalUrlLength = 2000; // максимальная длина Url
10. private const int MaximalFilenameLength = 256; // максимальная длина имени файла
11. public const string ManualIntegration = "Manual"; // учтонил, что именно ручной тип интеграции
12. private const int NotYetDefinedStatus = 0; // уточнил, что константа ещё не установленного статуса именно для статуса

Типы данных. Внесите 12 правок в свой код с учётом рекомендаций, и напишите по каждой, как и что конкретно вы улучшили
1. 
было: if (count + 1 > capacity) MakeArray(capacity * 2);
стало: 
var needToDobleTheSize = count + 1 > capacity; // введена говорящая логическая переменная
if (needToDobleTheSize) MakeArray(capacity * 2);
2. 
было: if (index < 0 || index > count) throw new ArgumentOutOfRangeException("index");
стало:
var isIndexOutOfRange = index < 0 || index > count; // введена говорящая логическая переменная
if (isIndexOutOfRange) throw new ArgumentOutOfRangeException("index");
3. 
было: if(count < capacity / 2) MakeArray(capacity * 2 / 3);
стало:
var needToReduceTheSize = count < capacity / 2; // введена говорящая логическая переменная
if(needToReduceTheSize) MakeArray(capacity * 2 / 3);
4. double actualResult = decisionTree.CalculateEntropy(choiceTable, "Play Tennis"); // применён double вместо float
5. Assert.AreEqual(0.94, actualResult, 0.001); // сравнение double сделано с заданием точности, а не на равенство
6. var proportion = choiceTableValue.Where(x => x == item).Count()/(double)choiceTableValue.Count; // вынужден сделать приведение знаменателя к double из-за того, что по умолчанию деление / даёт в результате целочисленное значение типа int
7. 
было:
var d1 = Convert.ToDouble(var1);
var d2 = Convert.ToDouble(var2);
if (d1 > d2) result = 1;
стало:
var d1 = Convert.ToDecimal(var1);
var d2 = Convert.ToDecimal(var2);
if (d1 > d2) result = 1; // Decimal намного точнее чем Double. Сравнение и операции с деньгами лучше производить в Decimal
8. 
было: const int decimalValue = 0;
стало: const int initialValue = 0; // это вообще шедевр обмана. В тоге и не Decimal совсем
9. Math.Round(targetValue * (decimal)avgPageCost, 2, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture);  // double заменён на decimal
10. public JsonContent(object obj) : base(obj.SerializeJson(), Encoding.Unicode, "application/json") { } // UTF8 заменён на Unicode
11. 
// DivideByZeroException возникает только при работе с целочисленными значениями и decimal. При работе с числами с плавающей запятой при делении на ноль получаем  значение «бесконечности». Тогда необзодимо проверять знаменатель на ноль
было: int result = arg1 / arg2;
стало: if (arg2 != 0) int result = arg1 / arg2;
12. Интернационализация поддержана из коробки файлом ресурсов .resx
<data name="NotFound" xml:space="preserve">
    <value>Сущность &lt;{0}&gt; не найдена</value>
</data>
<data name="NotFound" xml:space="preserve">
    <value>Entity &lt;{0}&gt; is not found</value>
</data>

Переменные и их значения. Внесите 15 правок в свой код с учётом рекомендаций и напишите по каждой, что конкретно вы улучшили:
1. result является аккумулятором, инициализирована нулём и помещена прямо перед циклом
var result = 0.0;
foreach (var item in values)
{
    var proportion = choiceTableValue.Where(x => x == item).Count()/(double)choiceTableValue.Count;
    result += proportion * CalculateEntropy(choiceTable, parentCriterion, criterion, item);
}

2. sumOfWeights является аккумулятором, инициализирована нулём и помещена прямо перед циклом
var sumOfWeights = 0m;
for (int i = 0; i < weigths.GetLength(0); i++)
    for (int j = 0; j < weigths.GetLength(1); j++)
        sumOfWeights += weigths[i,j] * input[i,j];

3. total является аккумулятором, инициализирована нулём и помещена прямо перед циклом
var total = 0;
for (var i = 0; i <= charArray.GetUpperBound(0); i++)
    total += (int)charArray[i];

4. total является аккумулятором, инициализирована нулём и помещена прямо перед циклом
var total = 0;
for (var i = 0; i <= c.GetUpperBound(0); i++)
    total += c[i];

5. Переменная i объявлена непостредственно в цикле и уничтожается сразу по выходу из него
for (int i = 0; i < data.Count; i += 1)
{
    if (data[i] == criterionValue) resultData.Add(parentData[i]);
}

6. Валидация перед использованием переменной
if (criterion == null) return _root;

7. Валидация перед использованием переменной
if (_root != null && _root.Criterion == criterion) return _root;

8. Счетчик и аккумулятор объявлены прямо пред циклом и после возвращения уничтожаются
var counter = 0;
var result = new List<int>();
while(str.IndexOf(sign,counter) != -1)
{
    result.Add(str.IndexOf(sign,counter));
    counter = str.IndexOf(sign,counter) + 1;
}
return result;

9. Счетчик объявлен непосредственно перед циклом
var counter = 0;
while(true)
{
    block.Nonce = counter;
    var hash = Hash(block);
    var match = Regex.Match(hash, "0{" + NumberOfZeros + "}$");
    if (match.Success) return hash;
    counter += 1;
}

10. Счетчик объявлен непосредственно перед циклом
var counter = 0;
do
{
    currentNode = RandomStep(currentNode);
    counter += 1;
}while(currentNode.Index != stopIndex);

11. head объявлена непосредственно перед использование в цикле
private T GetHead()
{
    while(input.Size() > 0) output.Push(input.Pop());
    var head = output.Pop();
    while(output.Size() > 0) input.Push(output.Pop());
    return head;
}

12. Счетчик смещён прямо перед объявлением цикла. В цикле проверка инварианта в коде
var node = list.head;
var counter = -1;
while (node != null)
{
    Assert.AreEqual(counter, node.value, "Test TestAddOrderedListIntAsc failed. List sequence is not correct");
    counter += 1;
    node = node.next;
}

13. Здесь вообще всё идеально в итоге. Короткая функция, переменные цикла объявлены как аргументы функции и уничтожаются при выходе
public static void QuickSortTailOptimization(int[] array, int left, int right)
{
    while (left < right)
    {
        int pivot = ArrayChunk(array, left, right);
        QuickSortTailOptimization(array, left, pivot - 1);
        left = pivot + 1;
    }
}

14. В конструкторе инициализируются все переменные и дерево
public aBST(int depth)
{
    // правильно рассчитайте размер массива для дерева глубины depth:
    var tree_size = 0;
    for (var i = 0; i <= depth; i++) tree_size += (int)Math.Pow(2, i);
    Tree = new int?[tree_size];
    for (var i = 0; i < tree_size; i++) Tree[i] = null;
}

15. Все переменные объявлены как readonly и инициализированы в конструкторе
public class DSU<T>
{
    private readonly Dictionary<T, T> _parent;
    // Ранг дерева >= высоты дерева
    private readonly Dictionary<T, int> _rank;
    private readonly Random _rand;

    public DSU()
    {
        _parent = new Dictionary<T, T>();
        _rank = new Dictionary<T, int>();
        _rand = new Random();
    }
...

Время жизни переменных. Внесите 15 правок в свой код с учётом рекомендаций из данного занятия, и напишите, что конкретно вы улучшили
1. internal int? [] Tree; // массив ключей сделан менее доступным
2. internal int NodeKey; // ключ узла сделан менее доступным 
3. internal BSTNode Parent; // родитель или null для корня сделан менее доступным
4. internal BSTNode LeftChild; // левый потомок сделан менее доступным
5. internal BSTNode RightChild; // правый потомок сделан менее доступным
6. internal int Level; // глубина узла сделана менее доступной
7. internal int Left; // сделан менее доступным
8. internal int Right; // сделан менее доступным
9. private int _result; // переименована и сделана закрытой
10. private int[] _sortedArray; // переименован и сделан закрытым
11. private int NumberOfZeros {get;set;} // сделана закрытой
12. internal int filter_length; // длина фильтра сделана менее доступной
13. internal BitArray bitArray; // массив сделан менее доступным
14. internal BSTNode<T> Node; // поле сделано менее доступным
15. internal bool NodeHasKey; // поле сделано менее доступным
16. internal bool ToLeft; // флаг сделан менее доступным
