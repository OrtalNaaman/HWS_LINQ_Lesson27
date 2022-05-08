using System;

namespace HWS_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region EX4
            Console.WriteLine("*************EX4-select*************");
            List<int> listOfIntsNumbers = new List<int> { 21, 33, 40, 10, 11, 1, 55, 45 };

            Console.WriteLine("Method Syntax: ");
            List<string> listOfStringsNumbers = listOfIntsNumbers.Select(num => $"{num}, ").ToList();
            listOfStringsNumbers.ForEach(num => Console.Write(num));
            Console.WriteLine();

            Console.WriteLine("Query Syntax: ");              
            var newListOfStringsNumbers = (from num in listOfIntsNumbers
                                           select num.ToString() + ", ").ToList();
            newListOfStringsNumbers.ForEach(num => Console.Write(num));
            Console.WriteLine();

            #endregion

            #region EX5
            Console.WriteLine("*************EX5-where*************");
            List<string> namesList = new List<string> { "Alon", "Ortal", "Avital", "Gil", "Netanel", "Beni" };
            
            Console.WriteLine("Method Syntax: ");
            List<string> onlyMoreThan4L = namesList.Where(name => name.Length > 4).ToList();
            onlyMoreThan4L.ForEach(name => Console.WriteLine(name));
            
            Console.WriteLine("Query Syntax: ");
            var onlyMoreThan4LQuery= (from name in namesList
                                      where name.Length > 4
                                      select name).ToList();
            onlyMoreThan4LQuery.ForEach(name => Console.WriteLine(name));
            #endregion

            #region EX6
            Console.WriteLine("*************EX6-order*************");
            Console.WriteLine("Method Syntax: ");
            List<int> orderListOfNumbers = listOfIntsNumbers.OrderBy(num => num).ToList();
            orderListOfNumbers.ForEach(num => Console.WriteLine(num));
            Console.WriteLine("*************decending**************");
            List<int> decendingListOfNumbers = listOfIntsNumbers.OrderByDescending(num => num).ToList();
            decendingListOfNumbers.ForEach(num => Console.WriteLine(num));
 
            Console.WriteLine("Query Syntax: ");
            var orderListOfNumbersQuery = (from num in listOfIntsNumbers
                                           orderby num
                                           select num).ToList();
            var decendingListOfNumbersQuery = ( from num in listOfIntsNumbers
                                                orderby num descending
                                                select num).ToList();
            orderListOfNumbersQuery.ForEach(num => Console.WriteLine(num));
            Console.WriteLine("**************decending*************");
            decendingListOfNumbersQuery.ForEach(num => Console.WriteLine(num));

            Console.WriteLine("Method Syntax: ");
            List<string> orderListOfNames = namesList.OrderBy(name => name).ToList();
            orderListOfNames.ForEach(name => Console.WriteLine(name));
            Console.WriteLine("*************decending**************");
            List<string> decendingListOfNames = namesList.OrderByDescending(name => name).ToList();
            decendingListOfNames.ForEach(name => Console.WriteLine(name));

            Console.WriteLine("Query Syntax: ");
            var orderListOfNamesQuery = (from name in namesList
                                         orderby name
                                         select name).ToList();
            var decendingListOfNamesQuery = (from name in namesList
                                             orderby name descending
                                             select name).ToList();
            orderListOfNamesQuery.ForEach(name => Console.WriteLine(name));
            Console.WriteLine("**************decending*************");
            decendingListOfNamesQuery.ForEach(name => Console.WriteLine(name));
            #endregion

            #region EX7
            Console.WriteLine("*************EX7*************");
            List<int> listOfNum1 = new List<int> { 1, 4, 13, 20, 5, 55, 41, 29, 33, 0, 8 };
            List<int> listOfNum2 = new List<int> { 3, 14, 28, 12, 55, 27, 56, 29, 45, 6, 18, 20 };
            Console.WriteLine("Method Syntax: ");
            Console.WriteLine("Part A:");
            List<int> intersectListOfNumbers = listOfNum1.Intersect(listOfNum2).ToList();       
            intersectListOfNumbers.ForEach(num => Console.WriteLine(num));
            Console.WriteLine("Part B:");
            List<int> listOfOnlyDifferentNumbers = listOfNum1.Except(listOfNum2).ToList();                    
            listOfOnlyDifferentNumbers.ForEach(num => Console.WriteLine(num));
            Console.WriteLine("Part C:");
            List<int> listOfAllNumbers = listOfNum1.Union(listOfNum2).Distinct().OrderBy(num => num).ToList();           
            listOfAllNumbers.ForEach(num => Console.WriteLine(num));
            Console.WriteLine("Part D:");
            Console.WriteLine(listOfNum1.FirstOrDefault(num => num > 12));
            Console.WriteLine("Part E:");
            Console.WriteLine(listOfNum1.Union(listOfNum2).Max());
          
            Console.WriteLine("Query Syntax: ");
            #endregion

            #region EX8
            Console.WriteLine("*************EX8*************");
            Console.WriteLine("Method Syntax: ");
            Console.WriteLine("Query Syntax: ");
            #endregion

            #region EX9
            Console.WriteLine("*************EX9*************");
            Console.WriteLine("Method Syntax: ");
            Console.WriteLine("Query Syntax: ");
            #endregion

            #region EX10
            Console.WriteLine("************EX10*************");
            Console.WriteLine("Method Syntax: ");
            Console.WriteLine("Query Syntax: ");
            #endregion
        }

    }
}
    
