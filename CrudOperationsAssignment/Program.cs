using CrudOperationsAssignment.DAO;
using System;

namespace CrudOperationsAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            productDAO productdao = new productDAO();
            //productdao.FindAll();
            //productdao.searchById("6269179a3a91788434a5b2a6");
            //productdao.create();
            //productdao.Update();
            //productdao.delete("62691ce834187b302cc40818");
            //productdao.searchByCategoryId();
            Console.WriteLine("\t\t\t\t================= Product Management System ==================");
            while (true)
            {
                Console.WriteLine("\t\t\t\t====================================================");
                Console.WriteLine("\t\t\t\t1.Display All Product");
                Console.WriteLine("\t\t\t\t2.Search Product By CategpryId");
                Console.WriteLine("\t\t\t\t3.Add New Product");
                Console.WriteLine("\t\t\t\t4.Update Product Details");
                Console.WriteLine("\t\t\t\t5.Delete Product");
                Console.WriteLine("\t\t\t\t6.Update for All Product");
                Console.WriteLine("\t\t\t\t7.Delete All Record from Database");
                Console.WriteLine("\t\t\t\t====================================================");
                Console.WriteLine("\t\t\t\tEnter you choice: ");
                Console.Write("                                ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                     Console.WriteLine("\t\t\t\t\t\tAll Products Details\n");
                     productdao.FindAll();
                    break;
                    case 2:
                        Console.WriteLine("\t\t\t\t\t\tSearch Product By CategoryId");
                        productdao.searchByCategoryId();
                     break;
                    case 3:
                        Console.WriteLine("\t\t\t\t\t\tAdd New Product");
                        Console.WriteLine("\t\t\t\t\t\t===============");
                        productdao.create();
                     break;
                    case 4:
                        Console.WriteLine("\t\t\t\t\t\tEnter Id You want to Update:");
                        Console.Write("                                ");
                        string catid = Console.ReadLine();
                        Console.WriteLine("\t\t\t\t\t\tUpdate Product Details");
                        productdao.Update(catid);
                    break;
                    case 5:
                        Console.WriteLine("\t\t\t\t\t\tEnter Id You want to Delete:");
                        Console.Write("                                ");
                        string catid2 = Console.ReadLine();
                        //Console.WriteLine("Delete Product");
                        productdao.delete(catid2);
                        break;
                    case 6:
                        
                        
                        productdao.updateMany("1");
                        break;
                    case 7:
                        Console.WriteLine("\t\t\t\t\t\tEnter Id You want to Delete:");
                        Console.Write("                                ");
                        string catid1 = Console.ReadLine();
                        productdao.deleteAll(catid1);
                        break;
                }
            }
            
        }
    }
}
