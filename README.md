# Self-Fost
Self Host Programming and Publishing


Youtube Video

https://www.youtube.com/watch?v=Wn7NhWTKqvE&feature=youtu.be


Self Host IP Reserved
 try
            {
                using (WebApp.Start<Startup>("http://*:8091"))
                {
                    Console.WriteLine("Web Api is Running");
                    Console.ReadKey();
                    Console.WriteLine("Web Api is Stopped");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

netsh http add urlacl http://*:8080/ user=EVERYONE : komutunu çalistirmamiz gerekiyor. yoksa IP olarak host edemiyoruz. CommandPrompt u yönetici olarak çalistirmak gerekmektedir.