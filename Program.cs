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
            var onlyMoreThan4LQuery = (from name in namesList
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
            var decendingListOfNumbersQuery = (from num in listOfIntsNumbers
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
            Console.WriteLine("Part A:");
            var listOfEqualNumbers = (from num in listOfNum1
                                      where listOfNum2.Contains(num)
                                      select num).ToList();
            listOfEqualNumbers.ForEach(num => Console.WriteLine(num));

            Console.WriteLine("Part D:");
            List<int> firstBiggerThan12 = (from num in listOfNum1
                                           where num > 12
                                           select num).ToList();
            Console.WriteLine(firstBiggerThan12[0]);

            #endregion

            #region EX8
            Console.WriteLine("*************EX8-Join*************");

            List<Agent> agents = new List<Agent>()
            {
                new("Snir Lavi", 45632178),
                new("Shay Cohen", 41532170),
                new("Aya Levi", 47832175),
                new("Dana Barel", 45552124)
            };
            List<Costumer> costumers = new List<Costumer>()
            {
                new("Ortal Naaman", 25689741),
                new("Yarden SimanTov", 454771378),
                new("Tali Dgani", 859476413),
                new("Moshe Ohana",CreateRandomInteger(11111111,999999999)),
                new("Barak Halel",CreateRandomInteger(11111111,999999999)),
                new("Shimon Navon",CreateRandomInteger(11111111,999999999)),
                new("Agam Halevi",CreateRandomInteger(11111111,999999999)),
                new("Liat Gueta",CreateRandomInteger(11111111,999999999)),
                new("Or Baruch",CreateRandomInteger(11111111,999999999)),
                new("Dvir Levi",CreateRandomInteger(11111111,999999999)),
                new("Gal Yair",CreateRandomInteger(11111111,999999999)),
            };

            foreach (Costumer costumer in costumers)
            {
                costumer.AddAgentForNewCostumer(agents);
                //Console.WriteLine($"Hello {costumer.Name} Your Agent is {costumer.CostumerAgent.AgentName}");
            }

            Console.WriteLine("Method Syntax: ");
            var joinCstmByAgentName = costumers.Join(agents,
                costumer => costumer.CostumerAgent.AgentName,
                agent => agent.AgentName,
                (costumer, agent) => new
                {
                    costumer.Name,
                    agent.AgentName
                }).ToList();

            joinCstmByAgentName.ForEach(costumer => Console.WriteLine(costumer));

            Console.WriteLine("Query Syntax: ");
            var joinCstmByAgentNameQuery = (from costumer in costumers
                                            join agent in agents
                                            on costumer.CostumerAgent.AgentName equals agent.AgentName
                                            select new
                                            {
                                                CostumerName = costumer.Name,
                                                CostumerAgent = agent.AgentName,
                                            }).ToList();
            joinCstmByAgentNameQuery.ForEach(costumer => Console.WriteLine(costumer));
            #endregion

            #region EX9
            Console.WriteLine("*************EX9*************");
            List<Order> orders = new List<Order>();

            foreach (Costumer costumer in costumers)
            {
                orders.Add(new(costumer.Name, CreateRandomInteger(150000, 300000), CreateRandomInteger(250, 1000)));
            }

            orders.Add(new(costumers[0].Name, CreateRandomInteger(150000, 300000), CreateRandomInteger(250, 1000)));
            orders.Add(new(costumers[3].Name, CreateRandomInteger(150000, 300000), CreateRandomInteger(250, 1000)));
            orders.Add(new(costumers[3].Name, CreateRandomInteger(150000, 300000), CreateRandomInteger(250, 1000)));
            orders.Add(new(costumers[5].Name, CreateRandomInteger(150000, 300000), CreateRandomInteger(250, 1000)));
            orders.Add(new(costumers[5].Name, CreateRandomInteger(150000, 300000), CreateRandomInteger(250, 1000)));

            Console.WriteLine("Method Syntax: ");
            var costumerOrders = (costumers.GroupJoin(orders,
                costumer => costumer.Name,
                order => order.CostumerName,
                (costumer, order) => new
                {
                    Costumer = costumer,
                    Orders = order.ToList()
                }).ToList()).ToList();
            costumerOrders.ForEach(costumer => Console.WriteLine(costumer));


            Console.WriteLine("Query Syntax: ");
            var costumerOrdersQuery = (from costumer in costumers
                                       join order in orders
                                       on costumer.Name equals order.CostumerName
                                       into ordersOfCostumer
                                       select new
                                       {
                                           costumer = costumer,
                                           orders = ordersOfCostumer.ToList()
                                       }).ToList();
            costumerOrdersQuery.ForEach(costumer => Console.WriteLine(costumer));
            #endregion

            #region EX10
            Console.WriteLine("************EX10*************");
            Console.WriteLine("Method Syntax: ");
            Console.WriteLine("\nCostumer that arrived two orders worth more than 500:");
            foreach (var csmr in costumerOrders)
            {
                if (csmr.Orders.Count() > 2 && csmr.Orders.Sum(order => order.TotalPrice) > 500)
                {
                    Console.WriteLine($"Costumer: {csmr.Costumer.Name}");
                    Console.WriteLine("Orders:");
                    foreach (var order in csmr.Orders)
                        Console.WriteLine(order);
                }
            }

            Console.WriteLine("Query Syntax: ");
            var moreThenTwoOrdersWorth500 = (from csmr in costumerOrdersQuery
                                             where csmr.orders.Count() > 2 && csmr.orders.Sum(order => order.TotalPrice) > 500
                                             select csmr).ToList();
            Console.WriteLine("\nCostumer that arrived two orders worth more than 500:");
            moreThenTwoOrdersWorth500.ForEach(costumer => Console.WriteLine(costumer.costumer.Name));

            Console.WriteLine("\nDetails:");
            foreach (var costumer in moreThenTwoOrdersWorth500)
            {
                Console.WriteLine($"Costumer: {costumer.costumer.Name}");
                Console.WriteLine("Orders:");
                foreach (var order in costumer.orders)
                    Console.WriteLine(order);
            }
            #endregion
        }

        public static int CreateRandomInteger(int from, int to)
        {
            Random r = new Random();
            return r.Next(from, to);
        }
    }
}








