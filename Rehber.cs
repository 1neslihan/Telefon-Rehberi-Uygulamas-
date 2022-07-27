using System.Collections;

public class Rehber{
    //Rehbere ekleyeceğim kişilerin şablonu için struct oluşturmayı tercih ettim
    //burada structdan kisiler nesnesi olusturuyorum
    Kisi kisiler=new Kisi();

    //kisi bilgilerimi tutmak için struct dönüş tipinde generic liste oluşturdum. 
    //Her bir eleman Ad,soyad ve telefon no bilgisi tutuyor.
    List<Kisi> kisiBilgisi=new();


//Rehber oluşturulurken default eklenecek 5 kişinin bilgilerini kurucu fonksiyona yazdırdım.
    public Rehber(){
        Kisi Kisi1=new();
        Kisi1.Ad="Ayse";
        Kisi1.Soyad="Yılmaz";
        Kisi1.TelNo="12345678";
        kisiBilgisi.Add(Kisi1);


        Kisi Kisi2=new();
        Kisi2.Ad="Ayse";
        Kisi2.Soyad="Yıldırım";
        Kisi2.TelNo="1345789";
        kisiBilgisi.Add(Kisi2);

        Kisi Kisi3=new();
        Kisi3.Ad="Hayriye";
        Kisi3.Soyad="Öztürk";
        Kisi3.TelNo="3456788";
        kisiBilgisi.Add(Kisi3);

        Kisi Kisi4=new();
        Kisi4.Ad="Mehmet";
        Kisi4.Soyad="Özdemir";
        Kisi4.TelNo="3446587498";
        kisiBilgisi.Add(Kisi4);

        Kisi Kisi5=new Kisi();
        Kisi5.Ad="Ahmet";
        Kisi5.Soyad="Devam";
        Kisi5.TelNo="566384749";
        kisiBilgisi.Add(Kisi5);


    }

    
//Menüyü fonksiyon olarak yazdım böylece alt seçenekler ve üst menüye dönüşlerde
//fonksiyonu çağırarak kod karmaşasının önüne geçtim.
    public void Menu(){
        Console.WriteLine("Lutfen yapmak istediğiniz işlemi seçiniz.");
        Console.WriteLine("*****************************************");
        Console.WriteLine("(1) Yeni numara kaydetmek");
        Console.WriteLine("(2) Var olan numarayı silmek");
        Console.WriteLine("(3) Var olan numarayı güncellemek");
        Console.WriteLine("(4) Rehberi listelemek");
        Console.WriteLine("(5) Rehberde arama yapmak");
        Console.WriteLine();
        Console.WriteLine();
        
        
        //yanlış karakter girdisi olsa bile ekrana hata mesajı verip menüyü yeniden çağıran kod bloğu
        try{
           int secim=Convert.ToInt32(Console.ReadLine());
           Console.WriteLine();
           if(secim==1)
           this.NumaraEklemek();

           if(secim==2)
           this.NumaraSil();

           if(secim==3)
           this.Guncelleme();
    
           if(secim==4)
           this.Listele();

           if(secim==5)
           this.Arama();

        }


        catch{
            Console.Clear();
            Console.WriteLine("Hatalı bir girdi yaptınız yeniden seçim yapınız.");
            Console.WriteLine("************************************************");
            Console.WriteLine();
            this.Menu();     
       }

       

           
    }  

//Programdan çıkış veya üst menüye dönüşü sağlayan kod bloğu
    public void Quit(){

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Bir üst menüye dönmek için herhangi bir tuşa basınız.");
        Console.WriteLine("Programı sonlandırmak için 'q' ya basınız");

        string quit=Console.ReadLine();
        if(quit=="q"){
           Environment.Exit('q'); 
        }
        else{
          Console.Clear();
          this.Menu();  
        }

    }  

//Numara eklemeye yarayan kod bloğu- Kullanıcı başa veya sona boş karakter koysa bile Trim() ile boşluklar silinir.
    public void NumaraEklemek(){


        Console.Write("Lutfen isim giriniz:                 ");
        kisiler.Ad=(Console.ReadLine()).Trim();

        Console.WriteLine();

        Console.Write("Lutfen soyisim giriniz:              ");
        kisiler.Soyad=(Console.ReadLine()).Trim();
        Console.WriteLine();

        Console.Write("Lutfen telefon numarası giriniz:     ");
        kisiler.TelNo=(Console.ReadLine()).Trim();
        Console.WriteLine();

        kisiBilgisi.Add(kisiler);
        this.Quit();


    }

//Numara silmeye yarayan kod bloğu
    public void NumaraSil(){

        string key="1";
        string y_n="n";
        if(kisiBilgisi.Count != 0){
            Console.Write("Lutfen silmek istediğiniz kişinin adı ya da soyadını giriniz: ");
            string silinecekKisi=Console.ReadLine();
            int tmp=0;
            for(int i=0;i<kisiBilgisi.Count;i++){
                if(kisiBilgisi[i].Ad==silinecekKisi || kisiBilgisi[i].Soyad==silinecekKisi){
                    Console.WriteLine(kisiBilgisi[i].Ad+" "+kisiBilgisi[i].Soyad+" adlı kisi rehberden silinmek üzere onaylıyor musunuz? (y/n)");
                    y_n=(Console.ReadLine()).Trim();
                    if(y_n=="y"){
                        kisiBilgisi.RemoveAt(i);
                        tmp=1;
                        break;
                    }
                    if(y_n=="n"){
                            
                    }
                        
                }
            }

            if(tmp==0){
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine(" * Silmeyi sonlandırmak için : (1)");
                Console.WriteLine(" * Yeniden denemek için      : (2)");
                Console.WriteLine();
                key=Console.ReadLine();
                if(key=="2"){
                    this.NumaraSil();
                }
                
                if(key=="1"){ 
                    this.Quit();
                }
            }      
 

        }   
        
    }

//Numara Güncellemeye yarayan kod bloğu
    public void Guncelleme(){
        string key="1";
        string y_n="n";
        int tmp=0;

        Console.Write("Lutfen güncellemek istediğiniz kişinin adı ya da soyadını giriniz: ");
        string guncellenecekKisi=Console.ReadLine();
        Console.WriteLine();

         for(int i=0;i<kisiBilgisi.Count;i++){
            if(kisiBilgisi[i].Ad==guncellenecekKisi || kisiBilgisi[i].Soyad==guncellenecekKisi){

                Console.WriteLine("Guncellemek istediğiniz kişi "+kisiBilgisi[i].Ad+" "+kisiBilgisi[i].Soyad+"mi?(y/n)");
                Console.WriteLine();
                y_n=Console.ReadLine();
                

                if(y_n=="y"){
                    Console.WriteLine(kisiBilgisi[i].Ad);
                    Console.WriteLine(kisiBilgisi[i].Soyad);
                    Console.Write("Yeni numara: ");
                    kisiler.Ad=kisiBilgisi[i].Ad;
                    kisiler.Soyad=kisiBilgisi[i].Soyad;
                    kisiler.TelNo=(Console.ReadLine()).Trim();
                    kisiBilgisi.RemoveAt(i);
                    kisiBilgisi.Add(kisiler);
                    tmp=1;
                    break;
                }   

                if(y_n=="n"){
                } 
            }
        }  

        if(tmp==0){
            Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine(" * Güncellemeyi sonlandırmak için : (1)");
            Console.WriteLine(" * Yeniden denemek için      : (2)");
            key=Console.ReadLine();
        }
        if(key=="2"){
            this.Guncelleme();
        }

        if(key=="1"){
            this.Quit();
        }
        

    }

//Rehberi listeleyen kod bloğu
    public void Listele(){

        Console.WriteLine("Telefon Rehberi");
        Console.WriteLine("************************");
        foreach(var item in kisiBilgisi){
           Console.WriteLine(item.Ad);
           Console.WriteLine(item.Soyad);
           Console.WriteLine(item.TelNo);
           Console.WriteLine("-");

        }

        this.Quit();

    }


//Rehberde Arama yapan kod bloğu
    public void Arama(){

        Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
        Console.WriteLine("****************************************");
        Console.WriteLine();
        Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
        Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
        Console.WriteLine();
        string key=Console.ReadLine();
        Console.WriteLine();

        string aranacakKisi;

        if(key=="1"){
            Console.Write("Lutfen aramak istediğiniz kişinin adı ya da soyadını giriniz: ");
            aranacakKisi=Console.ReadLine();
            Console.WriteLine();
            

            for(int i=0;i<kisiBilgisi.Count;i++){
                if(kisiBilgisi[i].Ad==aranacakKisi || kisiBilgisi[i].Soyad==aranacakKisi){
                    Console.WriteLine(kisiBilgisi[i].Ad);
                    Console.WriteLine(kisiBilgisi[i].Soyad);
                    Console.WriteLine(kisiBilgisi[i].TelNo);
                    Console.WriteLine("-");
                    Console.WriteLine();

                }
            }

        }

        if(key=="2"){

            Console.Write("Lutfen aramak istediğiniz telefon numarasını giriniz: ");
            aranacakKisi=Console.ReadLine();
            Console.WriteLine();

            for(int i=0;i<kisiBilgisi.Count;i++){
                if(kisiBilgisi[i].TelNo==aranacakKisi){
                    Console.WriteLine(kisiBilgisi[i].Ad);
                    Console.WriteLine(kisiBilgisi[i].Soyad);
                    Console.WriteLine(kisiBilgisi[i].TelNo);
                    Console.WriteLine("-");
                    Console.WriteLine();

                }
            }
        }
        this.Quit();
    }



}