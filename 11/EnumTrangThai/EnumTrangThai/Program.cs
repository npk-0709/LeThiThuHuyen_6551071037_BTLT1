using System;

namespace OrderStatusEnumApp
{
    enum OrderStatus { Pending = 0, Approved = 1, Delivering = 2, Completed = 3, Canceled = 4 }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("LeThiThuHuyen_6551071037");
            int input;
            do
            {
                Console.WriteLine("Menu: 0.Pending, 1.Approved, 2.Delivering, 3.Completed, 4.Canceled, -1.Exit");
                Console.Write("Select status: ");
                input = int.Parse(Console.ReadLine());

                if (input == -1) break;
                if (input < 0 || input > 4)
                {
                    Console.WriteLine("Error: Input out of range!");
                    continue;
                }

                OrderStatus status = (OrderStatus)input;
                switch (status)
                {
                    case OrderStatus.Pending: Console.WriteLine("Order is waiting for admin approval."); break;
                    case OrderStatus.Approved: Console.WriteLine("Order approved, preparing for shipment."); break;
                    case OrderStatus.Delivering: Console.WriteLine("Shipper is delivering your order."); break;
                    case OrderStatus.Completed: Console.WriteLine("Transaction successful."); break;
                    case OrderStatus.Canceled: Console.WriteLine("Order has been canceled."); break;
                }
            } while (true);
        }
    }
}