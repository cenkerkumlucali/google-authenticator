    Install-Package Otp.NET
###### Ardından, aşağıdaki kodu kullanarak paylaşılan bir sır oluşturmak ve çıktısını almak gerçekten kolaydır:# 	Ardından, aşağıdaki kodu kullanarak paylaşılan bir sır oluşturmak ve çıktısını almak gerçekten kolaydır:
    var secret = KeyGeneration.GenerateRandomKey(20);
    var base32Secret = Base32Encoding.ToString(secret);
    Console.WriteLine(base32Secret);
###### 	İlk satırda oluşturduğumuz sır, bir bayt dizisidir. Ancak, bunu base32 kodlamasında çıkarıyoruz. Bu, sırrı mobil cihaza ileteceğimiz bir sonraki adım için önemlidir. Zor yoldan öğrendiğim gibi, sır, base32 kodlu değil, rastgele bir dize ise işe yaramaz.
###### Yukarıdakileri çalıştırırken, çıktıda aşağıdakileri aldım:
    L52AM3FD452MARQQQPT54N6XVAJK6JR7
#### 	Sır için QR Kodu Oluşturma
###### Stefan Sundin bu harika <a href = "https://stefansundin.github.io/2fa-qr/">2FA QR kod üretecini </a> yaptı . Zorunlu iki alan, Sır (yukarıda oluşturulan değeri yapıştırdığımız yer) ve bir Etikettir (rasgele olan ve uygulamayı tanımlayan - oraya “MFA Test 1” koyacağız).
[![https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-qr-code-1024x576.png](https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-qr-code-1024x576.png "https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-qr-code-1024x576.png")](https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-qr-code-1024x576.png "https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-qr-code-1024x576.png")
#### Google Authenticator'ı kurma
###### Telefonunuzun uygulama mağazasında Google Authenticator'ı bulun ve yükleyin. Birazdan göreceğimiz gibi, kameranıza erişim gerektiriyor.

[![https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-google-authenticator-1-576x1024.png](https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-google-authenticator-1-576x1024.png "https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-google-authenticator-1-576x1024.png")](https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-google-authenticator-1-576x1024.png "https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-google-authenticator-1-576x1024.png")
###### Kurulumdan ve yerleşik kısa öğreticisinden sonra, ilk TOTP kod oluşturucunuzu kurabileceğiniz noktaya gelirsiniz (buna “hesap” derler):
[![https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-google-authenticator-2-576x1024.png](https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-google-authenticator-2-576x1024.png "https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-google-authenticator-2-576x1024.png")](https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-google-authenticator-2-576x1024.png "https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-google-authenticator-2-576x1024.png")
###### Bu adım, paylaşılan sırrı Google Authenticator'a girdiğiniz yerdir. Bunu bir QR kodunu tarayarak (ilk seçenek) veya yazarak (ikinci seçenek) yapabilirsiniz. İkincisi, özellikle bir mobil cihazda yavaş ve acı vericidir ve QR kodunu tararken bir tür sorun olması durumunda yedek olarak tutulmalıdır. QR kodunu taramak gerçekten sadece bir kolaylık mekanizmasıdır ve aynı sırrın kodlanmış bir versiyonudur.
[![https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-google-authenticator-3-576x1024.png](https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-google-authenticator-3-576x1024.png "https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-google-authenticator-3-576x1024.png")](https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-google-authenticator-3-576x1024.png "https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-google-authenticator-3-576x1024.png")
###### QR kodunu taradığınızda, Google Authenticator paylaşılan sırrı edinir ve her 30 saniyede bir TOTP kodları oluşturmaya başlar:
[![https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-google-authenticator-4-576x1024.png](https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-google-authenticator-4-576x1024.png "https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-google-authenticator-4-576x1024.png")](https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-google-authenticator-4-576x1024.png "https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-google-authenticator-4-576x1024.png")
###### Burada bu kod oluşturuculardan birden fazlasına sahip olabileceğiniz için (farklı uygulamalar için), bir etiketle gelirler. Bu durumda, QR kodunu oluştururken Etiket alanına girdiğimiz tam olarak “MFA Test 1”e sahip olduğumuzu fark edeceksiniz.
#### Otp.NET'ten TOTP kodları oluşturma
###### .NET kodundan TOTP kodları oluşturmanız gerekiyorsa (esas olarak Google Authenticator'ın yaptığını yapmak için), Otp.NET bunu yapmayı çok kolaylaştırır:
    string base32Secret = "6L4OH6DDC4PLNQBA5422GM67KXRDIQQP";
    var secret = Base32Encoding.ToBytes(base32Secret);
     
    var totp = new Totp(secret);
    var code = totp.ComputeTotp();
     
    Console.WriteLine(code);
###### 	Yöntem , kod oluşturma algoritması için kullanılacak geçerli zaman olarak ComputeTotp()isteğe bağlı bir parametre alır . DateTimeSağlanmadıysa DateTime.UtcNow, genellikle kullanmak istediğiniz şey olan kullanır.
[![https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-generation-code-1024x576.jpg](https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-generation-code-1024x576.jpg "https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-generation-code-1024x576.jpg")](https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-generation-code-1024x576.jpg "https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-generation-code-1024x576.jpg")
###### Google Authenticator kullandığımız için aslında buna hiç ihtiyacımız yok, bu yüzden gerçekten ihtiyacınız olursa aklınızda bulundurmanız gereken bir şey bu. Aynı zamanda doğru yolda olduğumuza dair bir güvence de veriyor, çünkü C# ile mobil cihazda yaptığımız şeyler açıkça uyum içinde.
#### TOTP Kodlarını Doğrulama
###### Gördüğümüz her işlem gibi, TOTP kodlarını Otp.NET ile doğrulamak da çok kolay. Aşağıdaki kod, bunun nasıl yapılacağını gösterir, ancak kodun çoğu aslında girdi ve çıktıyı işler.
    string base32Secret = "6L4OH6DDC4PLNQBA5422GM67KXRDIQQP";
    var secret = Base32Encoding.ToBytes(base32Secret);
     
    var totp = new Totp(secret);
     
    while (true)
    {
        Console.Write("Enter code: ");
        string inputCode = Console.ReadLine();
        bool valid = totp.VerifyTotp(inputCode, out long timeStepMatched,
            VerificationWindow.RfcSpecifiedNetworkDelay);
     
        string validStr = valid ? "Valid" : "Invalid";
        var colour = valid ? ConsoleColor.Green : ConsoleColor.Red;
        Console.ForegroundColor = colour;
        Console.WriteLine(validStr);
        Console.ResetColor();
    }
###### 	Tekrar tekrar test ederken şöyle görünebilir:
[![https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-verification-output.png](https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-verification-output.png "https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-verification-output.png")](https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-verification-output.png "https://gigi.nullneuron.net/gigilabs/wp-content/uploads/2019/10/totp-verification-output.png")
###### Öte yandan, aynı kodu iki kez kabul etmek, tek kullanımlık şifreler üretmemiz gerektiğini düşünürsek yanlıştır . Bir kodun iki kez kullanılmadığından emin olmak için, bir kodun kullanılıp kullanılmadığını daha sonra kontrol edebileceğimiz bir şey saklamamız gerekir. İkinci parametrenin nedeni budur . Bize kullanılan zaman adımını gösteren bir sayı verir, böylece bir kod kullanıldığında bunu kaydedebiliriz ve daha sonra aynı zaman adımının daha önce kullanılıp kullanılmadığını kontrol edebiliriz.VerifyTotp()
    string base32Secret = "6L4OH6DDC4PLNQBA5422GM67KXRDIQQP";
    var secret = Base32Encoding.ToBytes(base32Secret);
     
    var totp = new Totp(secret);
     
    var usedTimeSteps = new HashSet<long>();
     
    while (true)
    {
        Console.Write("Enter code: ");
        string inputCode = Console.ReadLine();
        bool valid = totp.VerifyTotp(inputCode, out long timeStepMatched,
            VerificationWindow.RfcSpecifiedNetworkDelay);
     
        valid &= !usedTimeSteps.Contains(timeStepMatched);
        usedTimeSteps.Add(timeStepMatched);
     
        string validStr = valid ? "Valid" : "Invalid";
        var colour = valid ? ConsoleColor.Green : ConsoleColor.Red;
        Console.ForegroundColor = colour;
        Console.WriteLine(validStr);
        Console.ResetColor();
    }
