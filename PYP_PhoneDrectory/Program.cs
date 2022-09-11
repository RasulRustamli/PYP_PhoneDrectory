using PYP_PhoneDrectory.Abstractions.Services;
using PYP_PhoneDrectory.Entities;
using PYP_PhoneDrectory.Repositories;
using PYP_PhoneDrectory.Services;

IContactService contactService = new ContactServiceAdo();
string choose=string.Empty;
do
{
    Console.WriteLine("Kayıt Eklemek İçin     (a)");
    Console.WriteLine("Kayıt Listelemek İçin  (l)");
    Console.WriteLine("Kayıt Aramak İçin     (s)");
    Console.WriteLine("Çıkış                  (e)");

    choose = Console.ReadLine().ToLower();
    switch (choose)
    {
        case "a":
            Console.Write("Soyad giriniz: ");
            var surname = Console.ReadLine();
            Console.Write("Ad giriniz: ");
            var name = Console.ReadLine();
            Console.Write("Mail giriniz: ");
            var email = Console.ReadLine();
            Console.Write("Telefon numarası yazınız: ");
            var number = Console.ReadLine();
            Console.Write("Kaydetmek istiyormusunuz (Y/N): ");
            var yesno = Console.ReadLine();
            if (yesno.Trim().ToLower() == "y")
            {
                Contact contact = new Contact(name, surname,  email,number);
                contactService.Add(contact);
            }
            else if (yesno.Trim().ToLower() == "n")
                Console.WriteLine("İşlem iptal edildi");
            break;
        case "l":
            System.Console.WriteLine("Rehber Listeleniyor...");
            Console.WriteLine("Id           Adı           Soyadı           Telefon           Mail");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(new String('-', 100));
            Console.ResetColor();
            foreach (var list in contactService.GetAll())
                System.Console.WriteLine(list);
            Console.WriteLine("Kayıt Silmek İçin (d)");
            Console.WriteLine("İşlem Menüsü İçin (m)");
            break;
        case "s":

            break;
        case "e":
            Console.WriteLine("Çıkış yapıldı");
            break;
        default:
            Console.WriteLine("Yanlış karakter girdiniz");
            break;
    }
}
 while (choose != "e") ;
//coming soooon  :))))))