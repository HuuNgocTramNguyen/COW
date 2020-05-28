using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Xml.Linq;

namespace Demo_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            #region sinh vien
            //Console.WriteLine("Hello World!");
            //int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            //// print only item less than 10
            //IEnumerable<int> subset = from i in numbers
            //                          where i < 10
            //                          select i;
            //foreach (int i in subset)
            //    Console.WriteLine("Item: {0}", i);

            //Console.WriteLine("---Danh sach sv thi dau---");
            //List<SinhVien> lst = new List<SinhVien>();
            //SinhVien sv1 = new SinhVien();

            //sv1.HoTen = "Thuan";
            //sv1.Diem = 10;
            //lst.Add(sv1);

            //SinhVien sv2 = new SinhVien();
            //sv2.HoTen = "Tram0";
            //sv2.Diem = 8;
            //lst.Add(sv2);

            //SinhVien sv3 = new SinhVien();
            //sv3.HoTen = "Tram";
            //sv3.Diem = 2;
            //lst.Add(sv3);

            //var subSV = from sv in lst
            //            where sv.Diem.HasValue && sv.Diem.Value > 5
            //            select sv;
            ////cach 2: bieu thuc lambda
            //var subsv = lst.Where(sv => sv.Diem.HasValue && sv.Diem.Value > 5).ToList();
            //foreach (var i in subSV)
            //    Console.WriteLine("Sinh vien[{0}] - {1}", i.HoTen, (i.Diem.HasValue? i.Diem.Value.ToString():""));
            #endregion

            #region car
            List<Car> myCars = new List<Car>()
            {
                new Car{ PetName = "Xe1", Color = "Bạc", Speed = 100, Make = "BMW"},
                new Car{ PetName = "Xe2", Color = "Đen", Speed = 55, Make = "Toyota"},
                new Car{ PetName = "Xe3", Color = "Xanh", Speed = 5, Make = "Honda"},
                new Car{ PetName = "X4", Color = "Trắng", Speed = 43, Make = "Ford"}
            };
            // danh sach cac xe mau den
            var subcar = myCars.Where(c => c.Color == "Đen").ToList();
            foreach (var i in subcar)
            {
                Console.WriteLine("Xe [{0}] -  mau {1} - toc do {2} - tu hang {3}",
                                   i.PetName, i.Color, i.Speed.ToString(), i.Make);
            }
            // danh sach cac xe co toc do > 60
            var subcar1 = myCars.Where(c => c.Speed > 60 && c.Speed > 40).ToList();
            foreach(var i in subcar1)
            {
                Console.WriteLine("Xe [{0}] -  mau {1} - toc do {2} - tu hang {3}",
                                   i.PetName, i.Color, i.Speed.ToString(), i.Make);
            }
            #endregion

            #region productinfo
            Categories[] categories = new[]
            {
                new Categories {CategoryId = 1, CategoryName = "Nuoc ngot" },
                new Categories {CategoryId = 2, CategoryName = "Van phong pham" },
                new Categories {CategoryId = 3, CategoryName = "Thuc pham" }
            };

            Products[] products = new[]
            {
                new Products {ProductId = 11, ProductName = "Pepsi", NumberInStock = 10, CategoryId = 1 },
                new Products {ProductId = 12, ProductName = "Coca", NumberInStock = 20, CategoryId = 1 },
                new Products {ProductId = 21, ProductName = "But bi", NumberInStock = 100, CategoryId = 2 },
            };

            static PetOwner[] GetPetList()
            {
                PetOwner[] petOwners =
                    {new PetOwner { Name="Bảo",
              Pets = new List<string>{ "Chó", "Mèo" } },
                     new PetOwner { Name="Thảo",
              Pets = new List<string>{ "Két", "Cá sấu" } },
                     new PetOwner { Name="Tâm",
              Pets = new List<string>{ "Chuột", "Chó" } } };
                return petOwners;
            }

            var subproduct = products.Select(p => p).ToList();

            foreach (var i in subproduct)
            {
                //Console.WriteLine(i.ToString());
            }

            PetOwner[] petList = GetPetList();

            var query = from O in petList
                        from p in O.Pets
                        select p;

            foreach (var p in query)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine(" **********IN*********");
            //SelectEverything(products);
            //selectCatogories(categories);s
            //GetNamesAndDescriptions(products);
            //GetNamesAndDescriptions(categories);
            //GetOverstock(products);
            //OfTypeAsFilter();
            GetPetList();
            #endregion
            }

        //cach: 1
        //static void SelectEverything(Products[] products)
        //{
        //    var allProducts = from p in products
        //                      select p;

        //    foreach (var prod in allProducts)
        //    {
        //        Console.WriteLine(prod.ToString());
        //    }
        //}

        //cach2
        //static void SelectEverything(Products[] products)
        //{
        //    var allProducts = products.Select(n => n);

        //    foreach (var prod in allProducts)
        //    {
        //        Console.WriteLine(prod.ToString());
        //    }
        //}

        //category
        //static void selectCatogories(Categories[]categories)
        //{
        //    var allcategories = categories.Select(n => n);

        //    foreach (var cate in allcategories)
        //    {
        //        Console.WriteLine(cate.ToString());
        //    }
        //}

        ////travekieudulieumoi
        //static void GetNamesAndDescriptions(Products[] products)
        //{
        //    var nameDesc = from p in products
        //                   select new
        //                   {
        //                       p.ProductId,
        //                       p.ProductName
        //                   };

        //    foreach (var item in nameDesc)
        //    {
        //        Console.WriteLine(item.ToString());
        //    }
        //}

        //static void GetNamesAndDescriptions(Categories[] categories)
        //{
        //    var nameDesc = from c in categories
        //                   select new
        //                   {
        //                       c.CategoryName,
        //                       c.CategoryId
        //                   };

        //    foreach (var item in nameDesc)
        //    {
        //        Console.WriteLine(item.ToString());
        //    }
        //}

        //Laytonkho
        //static void GetOverstock(Products[] products)
        //{
        //    Console.WriteLine("The overstock items!");

        //    var overstock = products.Where(p => p.NumberInStock > 25);

        //    foreach (Products c in overstock)
        //    {
        //        Console.WriteLine(c.ToString());
        //    }
        //}

        //tra ve kieu du lieu
        //static void OfTypeAsFilter()
        //{
        //    // Extract the ints from the ArrayList.
        //    ArrayList myStuff = new ArrayList();
        //    myStuff.AddRange(new object[] { 10, 400, 8, false, new Car(), "string data" });

        //    var myInts = myStuff.OfType<bool>();

        //    // Prints out 10, 400, and 8.
        //    foreach (bool i in myInts)
        //    {
        //        Console.WriteLine("Int value: {0}", i);
        //    }
        //}
    }
}


