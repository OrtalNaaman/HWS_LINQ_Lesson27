using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HWS_LINQ
{
    internal class Costumer
    {
        public string Name { get; set; }
        public int CostumerId { get; set; }
        public Agent CostumerAgent { get; set; }
        //public List<Order> CostumerOrders { get; set; }

        public Costumer(string name, int costumerId)
        {
            Name = name;
            CostumerId = costumerId;
            //CostumerOrders = new List<Order>();
        }

        public void AddAgentForNewCostumer(List<Agent> agents)
        {
            List<int> NumberOfCostumersPerAgent = (from agent in agents
                                                   select agent.AgentCostumers.Count()).ToList();
            int indexOfAvailableAgent = NumberOfCostumersPerAgent.IndexOf(NumberOfCostumersPerAgent.Min());
            CostumerAgent = agents[indexOfAvailableAgent];
            agents[indexOfAvailableAgent].AgentCostumers.Add(this);
        }

        //public void AddOrder(Order newOrder)
        //{
        //    CostumerOrders.Add(newOrder);
        //    Console.WriteLine("New order have added!");
        //    Console.WriteLine(newOrder);
        //}

        public override string ToString()
        {
            return $"Name: {Name}, Costumer Id:{CostumerId}, Costumer Agent: {CostumerAgent}";
        }
    }
}
