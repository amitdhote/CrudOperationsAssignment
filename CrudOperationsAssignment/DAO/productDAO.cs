using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudOperationsAssignment.Entities;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CrudOperationsAssignment.DAO
{
    public class productDAO
    {
        private MongoClient mongoClient;
        private IMongoCollection<product>productCollection;
       
        public productDAO()
        {
            mongoClient = new MongoClient("mongodb://localhost:27017");
            //"mongodb://{System}:{Password}@localhost:27017/DbName"
            var database = mongoClient.GetDatabase("myDemo");
            productCollection = database.GetCollection<product>("product");
        }
        public void FindAll()
        {
            
            var products = productCollection.AsQueryable<product>().ToList();
            Console.WriteLine("\t\t\t\t====================================================");
            Console.WriteLine("\t\t\t\t{0,-10} {1,5} {2,10} {3,15} \n", "Name", "Price", "Status", "Date");
            Console.WriteLine("\t\t\t\t====================================================");
            foreach (var product in products)
            {
                /*Console.WriteLine("id: " + product.Id);
                Console.WriteLine("name: " + product.Name);
                Console.WriteLine("price: " + product.Price);
                Console.WriteLine("status: " + product.Status);
                Console.WriteLine("date: " + product.Date.ToShortDateString());
                Console.WriteLine("============================================");*/
                
                Console.WriteLine("\t\t\t\t{0,-10} {1,5:N1} {2,10:N1} {3,15:N1} ", product.Name, product.Price, product.Status, product.Date.ToShortDateString());

            }
            Console.WriteLine("\t\t\t\t====================================================\n");
        }
        public void searchById(string id)
        {
            Console.WriteLine("\t\t\t\t====================================================");
            Console.WriteLine("\t\t\t\t{0,-10} {1,5} {2,10} {3,15} \n", "Name", "Price", "Status", "Date");
            Console.WriteLine("\t\t\t\t====================================================");
            var productId = new ObjectId(id);
            var product = productCollection.AsQueryable<product>().SingleOrDefault(
                p => p.Id == productId);
            /*Console.WriteLine("id: " + product.Id);
            Console.WriteLine("name: " + product.Name);
            Console.WriteLine("price: " + product.Price);
            Console.WriteLine("status: " + product.Status);
            Console.WriteLine("date: " + product.Date.ToShortDateString());
            Console.WriteLine("============================================");*/
            Console.WriteLine("\t\t\t\t{0,-10} {1,5:N1} {2,10:N1} {3,15:N1} ", product.Name, product.Price, product.Status, product.Date.ToShortDateString());
            Console.WriteLine("\t\t\t\t====================================================\n");
        }
        public void searchByCategoryId()
        {
            Console.WriteLine("\t\t\t\tEnter Category ID :");
            //var productId = new ObjectId();
            //int catid = Convert.ToInt32(Console.ReadLine());
            Console.Write("                                ");
            string catid = Console.ReadLine();
            var product = productCollection.AsQueryable<product>().SingleOrDefault(p=>p.CategoryId==catid);
            Console.WriteLine("\t\t\t\t====================================================");
            Console.WriteLine("\t\t\t\t{0,-10} {1,5} {2,10} {3,15} \n", "Name", "Price", "Status", "Date");
            Console.WriteLine("\t\t\t\t====================================================");
            /*Console.WriteLine("id: " + product.Id);
                        Console.WriteLine("name: " + product.Name);
                        Console.WriteLine("price: " + product.Price);
                        Console.WriteLine("status: " + product.Status);
                        Console.WriteLine("date: " + product.Date.ToShortDateString());
                        Console.WriteLine("============================================");*/
            Console.WriteLine("\t\t\t\t{0,-10} {1,5:N1} {2,10:N1} {3,15:N1} ", product.Name, product.Price, product.Status, product.Date.ToShortDateString());
            Console.WriteLine("\t\t\t\t====================================================\n");
        }
        public void create()
        {
            /*product pro = new product
            {
                Name = "abc",
                Price = 11,
                Quantity = "4",
                Status = true,
                CategoryId="4",
                Date=DateTime.Now

            };*/
           /* var products = productCollection.AsQueryable<product>().ToList();
            var product = productCollection.AsQueryable<product>().SingleOrDefault(
                p => p.CategoryId ==id);*/
           
            Console.WriteLine("\t\t\t\tEnter Name of Product :");
            Console.Write("                                ");
            string name = Console.ReadLine();
            Console.WriteLine("\t\t\t\tEnter Price :");
            Console.Write("                                ");
            double price =Convert.ToDouble( Console.ReadLine());
            Console.WriteLine("\t\t\t\tEnter Quantity:");
            Console.Write("                                ");
            string quantity = Console.ReadLine();
            Console.WriteLine("\t\t\t\tEnter status :");
            Console.Write("                                ");
            bool status;
            string boolValue = Console.ReadLine();
            if (boolValue == "yes")
            {
                status = true;
            }
            else
            {
                status = false;
            }
            Console.WriteLine("\t\t\t\tEnter category Id :");
            Console.Write("                                ");
            string cat = Console.ReadLine();
            /*Console.WriteLine("Enter Date:");
            string date = Console.ReadLine();*/
            product pro = new product
            {
                Name = name,
                Price =price,
                Quantity = quantity,
                Status = status,
                CategoryId = cat,
                Date = DateTime.Now
            };
            productCollection.InsertOne(pro);
            Console.WriteLine("\t\t\t\t====================================================");
            Console.WriteLine("\t\t\t\tProduct Added Succefully.........");
            Console.WriteLine("\t\t\t\t====================================================");
        }
        public void Update(string id)
        {
            /*var result = productCollection.UpdateOne(
                 Builders<product>.Filter.Eq("_id",ObjectId.Parse("6269179a3a91788434a5b2a6")),
                 Builders<product>.Update
                 .Set("name","TV")
                 .Set("price",4500)
                 .Set("quantity","12")
                );*/
            
            var products = productCollection.AsQueryable<product>().ToList();
            var product = productCollection.AsQueryable<product>().SingleOrDefault(
                p => p.CategoryId == id);
            Console.WriteLine("\t\t\t\t====================================================");
            Console.WriteLine("\t\t\t\tSelect What you want to Update ??");
            Console.WriteLine("\t\t\t\t1.Product Name");
            Console.WriteLine("\t\t\t\t2.Product quantity");
            Console.WriteLine("\t\t\t\t3.Product Price");
            Console.WriteLine("\t\t\t\t4.Enter Status");
            Console.WriteLine("\t\t\t\t====================================================");
            Console.WriteLine("Enter you choice: ");
            Console.Write("                                ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {

                case 1:
                    Console.WriteLine("\t\t\t\tEnter The Product Name :");
                    Console.Write("                                ");
                    string name = Console.ReadLine();
                    var result = productCollection.UpdateOne(
                    Builders<product>.Filter.Eq("categoryId", id),
                    Builders<product>.Update
                   .Set("name",name)
                 
                   /*
                    * How to take boolena as Input From Console
                    *  boolean boolValue; 
                       string boolInput=Console.ReadLine();
                       if(boolInput=="yes")
                       {
                           boolValue=true;
                       }
                       else
                       {
                           boolValue=false;
                       }
                    */


                );
                    //Console.WriteLine("Update: " + result.ModifiedCount);
                    if (result.ModifiedCount > 0)
                    {
                        Console.WriteLine("\t\t\t\t=============================");
                        Console.WriteLine("Product Name Updated Succefully");
                        Console.WriteLine("=============================\n");
                    }
                    else
                    {
                        Console.WriteLine("\t\t\t\t=============================");
                        Console.WriteLine("\t\t\t\tWrong Product Key!!!");
                        Console.WriteLine("\t\t\t\t=============================");
                    }
                    break;
                case 2:
                    Console.WriteLine("\t\t\t\tEnter The Product Price:");
                    double price =Convert.ToDouble( Console.ReadLine());
                    var re = productCollection.UpdateOne(
                    Builders<product>.Filter.Eq("categoryId", id),
                    Builders<product>.Update
                   .Set("price", price)

                );
                    //Console.WriteLine("Update: " + re.ModifiedCount);
                    if (re.ModifiedCount > 0)
                    {
                        Console.WriteLine("\t\t\t\t=============================");
                        Console.WriteLine("\t\t\t\tProduct Price Updated Succefully");
                        Console.WriteLine("\t\t\t\t=============================\n");
                    }
                    else
                    {
                        Console.WriteLine("\t\t\t\t=============================");
                        Console.WriteLine("\t\t\t\tWrong Product Key!!!");
                        Console.WriteLine("\t\t\t\t=============================\n");
                    }
                    break;

                case 3:
                    Console.WriteLine("\t\t\t\tEnter The Product Quantity :");
                    Console.Write("                                ");
                    string quantity = Console.ReadLine();
                    var re1 = productCollection.UpdateOne(
                    Builders<product>.Filter.Eq("categoryId", id),
                    Builders<product>.Update
                   .Set("quantity", quantity)

                );
                    //Console.WriteLine("Update: " + re1.ModifiedCount);
                    if (re1.ModifiedCount > 0)
                    {
                        Console.WriteLine("\t\t\t\t=============================");
                        Console.WriteLine("\t\t\t\tProduct Quantity Updated Succefully");
                        Console.WriteLine("\t\t\t\t=============================\n");
                    }
                    else
                    {
                        Console.WriteLine("\t\t\t\t=============================");
                        Console.WriteLine("\t\t\t\tWrong Product Key!!!");
                        Console.WriteLine("\t\t\t\t=============================\n");
                    }
                    break;
                    case 4:
                        Console.WriteLine("Enter Product Status");
                        bool status;
                        string boolValue = Console.ReadLine();
                        if(boolValue=="yes" || boolValue=="Yes" || boolValue == "YES")
                        {
                         status = true;
                        }
                        else
                        {
                         status = false;
                        }
                    var re2 = productCollection.UpdateOne(
                    Builders<product>.Filter.Eq("categoryId", id),
                    Builders<product>.Update
                   .Set("status", status));
                    break;
            }
            /*var result = productCollection.UpdateOne(
                 Builders<product>.Filter.Eq("id", id),
                 Builders<product>.Update
                 .Set("name", "TV")
                 .Set("price", 4500)
                 .Set("quantity", "12")
                );*/
            //Console.WriteLine("Update: " + result.ModifiedCount);
        }
        public void updateMany(string catId)
        {
           /* var product = productCollection.AsQueryable<product>().SingleOrDefault(
               p => p.Status == status);*/
            Console.WriteLine("\t\t\t\tEnter The Product Quantity Update for ALL :");
            Console.Write("                                ");
            string quantity = Console.ReadLine();
            var re1 = productCollection.UpdateMany(
            Builders<product>.Filter.Eq("categoryId", catId),

            Builders<product>.Update
           .Set("quantity", quantity));
            Console.WriteLine("Update: " + re1.ModifiedCount);
        }
        public void delete(string id)
        {
            var result = productCollection.DeleteOne(Builders<product>.Filter.Eq("categoryId",id));
            Console.WriteLine("Deleted: " + result.DeletedCount);
            if (result.DeletedCount > 0)
            {
                Console.WriteLine("\t\t\t\t=============================");
                Console.WriteLine("\t\t\t\tProduct Deleted Succefully");
                Console.WriteLine("\t\t\t\t=============================\n");
            }
            else
            {
                Console.WriteLine("\t\t\t\t=============================");
                Console.WriteLine("\t\t\t\tWrong Product Key!!!");
                Console.WriteLine("\t\t\t\t=============================\n");
            }
        }

        public void deleteAll(string id)
        {
            var result = productCollection.DeleteMany(Builders<product>.Filter.Eq("categoryId", id));
            Console.WriteLine("Deleted: " + result.DeletedCount);
            if (result.DeletedCount > 0)
            {
                Console.WriteLine("\t\t\t\t=============================");
                Console.WriteLine("\t\t\t\tAll Product Deleted Succefully");
                Console.WriteLine("\t\t\t\t=============================\n");
            }
            else
            {
                Console.WriteLine("\t\t\t\t=============================");
                Console.WriteLine("\t\t\t\tWrong Product Key!!!");
                Console.WriteLine("\t\t\t\t=============================\n");
            }
        }
    }
}
