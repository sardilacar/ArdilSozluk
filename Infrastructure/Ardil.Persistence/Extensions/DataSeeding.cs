using Ardil.Domain.Entities;
using Ardil.Domain.Entities.Identity;
using Ardil.Domain.Enums.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Persistence.Extensions
{
    public static class DataSeeding
    {
        public static void Seed(this ModelBuilder builder)
        {

            List<AppRole> roles = SeedRoles();
            List<AppUser> users = SeedUsers(roles);
            List<AppUserRole> userRoles = SeedUserRoles(users, roles);
            var listOnlyWriterRoles = roles.Where(p => new List<string> { AppRolesEnum.ADMIN, AppRolesEnum.WRITER }.Contains(p.Name)).Select(s => s.Id).ToList();
            List<Topic> topics = SeedTopics(users.Where(x => listOnlyWriterRoles.Contains(x.RoleId)).ToList());
            List<Entry> entries = SeedEntries(users, topics);


            builder.Entity<AppRole>().HasData(roles);
            builder.Entity<AppUser>().HasData(users);
            builder.Entity<AppUserRole>().HasData(userRoles);
            builder.Entity<Topic>().HasData(topics);
            builder.Entity<Entry>().HasData(entries);



        }

        private static List<AppRole> SeedRoles()
        {
            List<AppRole> roles = new List<AppRole> {
                new AppRole() { Name = AppRolesEnum.ADMIN},
                new AppRole() { Name = AppRolesEnum.WRITER},
                new AppRole() { Name = AppRolesEnum.SUBSCRIBER}
            };
            foreach (var role in roles)
            {
                role.Id = Guid.NewGuid();
                role.CreatedDate = DateTime.UtcNow;
                role.NormalizedName = role.Name.ToUpper().Normalize();
            }
            return roles;
        }

        private static List<AppUser> SeedUsers(List<AppRole> roles)
        {
            PasswordHasher<AppUser> password_hasher = new PasswordHasher<AppUser>();
            var random = new Random();
            List<AppUser> users = new List<AppUser> {
                new AppUser() {  Name = "Admin", Surname = "Admin", UserName = "admin"},
                new AppUser() {  Name = "Sevtap", Surname = "Alpuğan", UserName = "gok yeleli bozkurtun avukati"},
                new AppUser() {  Name = "Emre", Surname = "Sualp",  UserName = "emre123"},
                new AppUser() {  Name = "Ender", Surname = "Özkara", UserName = "nootropil"},
                new AppUser() {  Name = "Berkan", Surname = "Çörekçi",  UserName = "ardil123"},
                new AppUser() {  Name = "Lütfi", Surname = "Erez", UserName = "whatyougetiswhatyoudid"},
                new AppUser() {  Name = "Şahinalp", Surname = "Koyuncu", UserName = "fincan"},
                new AppUser() {  Name = "Rengin", Surname = "Yalçın", UserName = "kmc"},
                new AppUser() {  Name = "Selçuk", Surname = "Erbulak", UserName = "kutup ayisinin arkadasi"},
                new AppUser() {  Name = "Zekeriya", Surname = "Karabulut", UserName = "tombalaktobe"},
                new AppUser() {  Name = "Lütfi", Surname = "Çetiner", UserName = "cumhuriyet halk partisi"},
                new AppUser() {  Name = "Öykü", Surname = "Kuday", UserName = "taissa farmiga"},
                new AppUser() {  Name = "Haşim", Surname = "Özdenak", UserName = "simgeselkedi"},
                new AppUser() {  Name = "Alparslan", Surname = "Ağaoğlu", UserName = "ortalama insan dusuncesine sahip insan"},
                new AppUser() {  Name = "Serdar", Surname = "Okumus", UserName = "serdarsl 06"},
                new AppUser() {  Name = "Rahime", Surname = "Arıcan", UserName = "cuprac"},
                new AppUser() {  Name = "Günay", Surname = "Egeli", UserName = "vidanjorgillerden"},
                new AppUser() {  Name = "Talib", Surname = "Kaplangı", UserName = "i am cookie monsters nipple"},
                new AppUser() {  Name = "Habil", Surname = "Karaduman", UserName = "inomniaparatus"},
                new AppUser() {  Name = "Necdet", Surname = "Tahincioğlu", UserName = "golgebeyi"},
                new AppUser() {  Name = "Işılay", Surname = "Orban", UserName = "warone"},
                new AppUser() {  Name = "Lerzan", Surname = "Özbir", UserName = "colifact"},
            };

            string[] Domains = { "gmail.com", "hotmail.com", "outlook.com" };
            foreach (var user in users)
            {
                string firstName = Char.ToLower(user.Name[0]) + user.Name.Substring(1);
                string lastName = Char.ToLower(user.Surname[0]) + user.Surname.Substring(1);
                string domain = Domains[random.Next(Domains.Length)];
                int roleIndex = random.Next(roles.Count);
                user.Email = $"{firstName}.{lastName}@{domain}".ToLower();
                user.Id = Guid.NewGuid();
                user.RoleId = roles.ElementAt(roleIndex).Id;
                user.CreatedDate = DateTime.UtcNow;
                user.NormalizedEmail = user.Email.ToUpper().Normalize();
                user.NormalizedUserName = user.UserName.ToUpper().Normalize();
            }

            users[0].PasswordHash = password_hasher.HashPassword(users[0], "admin");
            users[1].PasswordHash = password_hasher.HashPassword(users[1], "Emre1234.");
            users[2].PasswordHash = password_hasher.HashPassword(users[2], "Ardil.222");

            return users;

        }

        private static List<AppUserRole> SeedUserRoles(List<AppUser> users, List<AppRole> roles)
        {
            List<AppUserRole> userRoles = new List<AppUserRole>();
            foreach (var user in users)
            {
                userRoles.Add(new() { UserId = user.Id, RoleId = user.RoleId });
            }
            return userRoles;
        }

        private static List<Topic> SeedTopics(List<AppUser> users)
        {
            var random = new Random();
            List<Topic> topics = new List<Topic>()
            {
                new() {Subject = "ingilizce rusça arapça bilmek"},
                new() {Subject = "gent vs brudge"},
                new() {Subject = "gece 02.30'a mr randevusu vermek"},
                new() {Subject = "hesabı erkek öder bu bir görgü kuralıdır"},
                new() {Subject = "ekşi itiraf"},
                new() {Subject = "bir kadının erkeğe yürümesi"},
                new() {Subject = "türk solunun en iyi yaptığı şey"},
                new() {Subject = "9 ekim 2023 israilin topyekün savaşı"},
                new() {Subject = "ekşi sözlük dertleşecek insan veritabanı"},
                new() {Subject = "temizliğe gelen kadına öğlen yemeği verilir mi"},
                new() {Subject = "ülkemde yahudi mülteci istemiyorum"},
                new() {Subject = "akif emin soyyiğit"},
                new() {Subject = "mahmut orhan"},
                new() {Subject = "anın fotoğrafı"},
                new() {Subject = "israil-filistin savaşı"},
                new() {Subject = "sözlükteki filistin düşmanları"},
                new() {Subject = "aylık geliri 100 bin lira olan biri çalışmalı mı"},
                new() {Subject = "gömercin kuşları"},
                new() {Subject = "zamanın çok hızlı geçmesi"},
                new() {Subject = "viskiyle iyi giden şeyler"},
                new() {Subject = "dijital vergi dairesi"},
                new() {Subject = "kutsal motor"},
                new() {Subject = "temizlik yaparken gelen iç hesaplaşma yapma isteği"},
                new() {Subject = "naber dergi"}
            };
            foreach(var topic in topics)
            {
                int rand = random.Next(users.Count);
                topic.Id = Guid.NewGuid();
                topic.CreatedDate = DateTime.UtcNow;
                topic.UserId = users[rand].Id;
            }
            return topics;
        }

        private static List<Entry> SeedEntries(List<AppUser> users, List<Topic> topics)
        {
            var random = new Random();
            List<Entry> entries = new List<Entry>()
            {
                new() { Content = "kaybedenler kulübü'nü izlemek için sinema salonunun açılmasını beklerken, uzakta duran bu abimize \"ismail abiiii?\" diye bağırılmış, karşılığında \"huooop!\" diye cevap alınmıştır. samimiyeti, sempatikliği oyunculuğu kadar takdire şayan."},
                new() { Content = "inanmıyorsanız da saygı duyun. haşa “sözde tanrı” falan ayıp oluyor.\r\n açılmasını beklerken, uzakta duran bu abimize \"ismail abiiii?\" diye bağırılmış, karşılığında \"huooop!\" diye cevap alınmıştır. samimiyeti, sempatikliği oyunculuğu kadar takdire şayan."},
                new() { Content = "dogrudur zira herkes baska dns ve vpn'leri kullaniyor.\r\nben misal 1 haftadir almanya'dan atiyorum.\r\nama aslinda istanbul'da ikamet etmekteyim.\r\nannemler de karadenizli.\r\n\r\noyle."},
                new() { Content = "arkasında sağlam huzursuzluk olduğunu düşündüğüm karar.\r\n\r\nadam devletin yapamadığı şeyleri yaptı yangında, ünlüler aradı, parasal destek verdi. bizim iktidar parayı başkasının yönetmesinden hoşlanmaz. isterler ki 10 lira bağış gelsin. 8'ini yiyip kalan 2 lirasını kendilerine biat edenlere dağıtsınlar."},
                new() { Content = "var böyle bir durum özellikle son dönemde hortlamış durumda tek tek isimlerini yazmaya gerek yok filistinle ilgili bir başlığa girin bütün yahudiler türkiye'de toplanmış sanabilirsiniz\r\n\r\nhalk olarak her zaman filistin'in yanında olduk olmaya devam edeceğiz\r\nbiz her zaman mazlumların yanında olacağız haberiniz ola\r\npkk ne kadar hakliysa israil de o kadar hakli\r\ndünyayı zulüm çukuruna dönüştüren yahudi emperyalizmi eninde sonunda sonlanacak kapitalizmin başını cektigi insanların canlarını, mallarını sömüren onları kolelestiren bu köhne zihniyetin bitmesi çok yakın hem de her zamankinden daha yakın.."},
                new() { Content = "\" halk olarak filistin'in yanında olduk \"\r\n\r\nolmamışsın. bak burada entry giriyorsun. o halk dediğin hangi halk bilmiyorum ama, boş boş gevezelik yapacağına al halkını, gidin filistin'i savunun."},
                new() { Content = "filistin ve kudüs tatavalarıyla her türlü takiyeciliği yapıp cihad çağrısında bulunan ama kendisi ve çocukları ise dua desteğinde bulunmaktan başka bir sik yapmayan islamcı iki yüzlüleri deşifre eden düşmanlardır."},
                new() { Content = "yıllarca israilin filistinde yaptıkları nasıl kabul edilemez ise, filistin militanlarının israile girip kadın çocuk demeden herkesi katletmesi de kabul edilemez. türkiye'nin kendinden başka dostu yoktur. kimsenin götünü yalamasına da ihtiyacı yoktur. siktir git şimdi yeni bir başlık aç “arap sevicileri ve vatanı arap mülteciler ile bölmek istiyenler bu başlık altında toplanıyor” diye. ya da git filistine, katıl arap kardeşlerinin haklı davasına götün yiyorsa. mehmetçiği bulaştırma!"},
                new() { Content = "eğer saat üzerinde wifi'yi kapatırsanız şarjı bir gün ekstra fazla gidebiliyor. zaten telefonunuza bluetooth ile bağlandığı için de tam randımanlı kullanabilirsiniz bu şekilde de.\r\n"},
                new() { Content = "gent'in şehir mimarisine hayran olmamak elde değil. ancak \"off çok türk var burada\" diyen tiplerdenseniz önermem. özellikle türk mahallesine girerseniz bağcılar mı gent mi belli değil. ayrıca küçük şehir 2 güne gent'i gezebilirsiniz. sonra da brugge'e gidersiniz. zaten arabayla 1 saatlik yol."},
                new() { Content = "1 hafta her iki şehir için de çok uzun bir süre. ayrı ayrı her ikisi de gezilecekse tamam fakat 1 haftanın tamamı yalnızca bir tanesine ayrılacaksa yazık olur. zaten hem çok küçük hem de birbirlerine çok yakın şehirler.\r\n\r\nama illa birinden birini tercih edeyim derseniz ben olsam brugge'ü seçerdim. güzelliğinin brüksel'le veya gent'le kıyaslanabileceğini dahi sanmıyorum.\r\n"},
                new() { Content = "brugge en çok gitmek istediğim ve içimde kalan tek avrupa şehridir. bu versusta ben brugge'dan yanayım:)"},
                new() { Content = "siktir edin klişe şehirleri. sizi, belçika’nın keşfedilmemiş cenneti (bkz: charleroi)’ya davet ediyorum. swh."},
                new() { Content = "2,5 üst"},
                new() { Content = "hayırlı forumlar. az turist olsun kafa dinleyim ama en az brugge kadar güzel olsun deniliyorsa gent. çok turist çok sosyalleşme daha fazla hareket deniliyorsa brugge."},
                new() { Content = "akit gazetesi yazarı ali karahasanoğlu tarafından, hodri meydan minvalinde yazılan köşe yazısının anafikri ve başlığıdır..\r\n\r\nbunlar iyice cüretkâr hâle geldiler.\r\n\r\nirticanın, bölücü terörden bile daha amansız ve sinsi bir düşman olduğunu ve bu ülkeyi korkunç bir felakete sürükleyebileceği gerçeğini her gün biraz daha yaşayarak müşahede ediyoruz.\r\n\r\ndini esaslara göre yönetilen ortadoğu ülkelerinde cehalet, yobazlık, kan ve gözyaşı durmuyorken ve suudi arabistan bile modernleşme yolunda ıslahatlar yapma arefesinde iken, şu arapperest tayfanın derdine bakın hele !\r\n\r\nbu ülke, şu anda görece olarak ortadoğu ülkelerinden daha müreffeh, güçlü ve modern bir ülke ise, bunun için yiyin için ve ebedi lider mustafa kemal atatürk'e dua edin. yoksa afganistan'dan farkımız kalmazdı. bombalı eylemler, iç savaş manzaraları, tecavüz ve terör eksik olmazdı.\r\n\r\n--- spoiler ---\r\n\r\nevet laikliği değiştirmek istiyoruz, var mı diyeceğiniz?\r\n\r\n“darbecilerin yaptığı anayasa, türkiye’ye yakışmıyor, değiştirelim” denildiğinde chp susuyor, iyi parti konuşuyor, iyi parti susuyor baro başkanları konuşuyor, baro başkanları susuyor anayasa hukuku profesörü olduğunu iddia eden darbeseverler konuşmaya başlıyor..\r\n\r\nhemen hepsinin iddiası şu:\r\n\r\n“bugünkü mevcut millet meclisi’nin anayasayı değiştirme yetkisi yoktur.”\r\n\r\nbuna ilaveten şunu da öne sürüyorlar:\r\n\r\n“darbe anayasasının değişmeyen maddesi mi kaldı ki?”\r\n\r\nson olarak saadet partisi genel başkanı temel karamollaoğlu bile tartışmaya katıldı.\r\n\r\no da, anayasanın, yapılan değişikliklerle yamalı bohçaya döndüğünü, artık anayasayı değiştirmeye gerek kalmadığını söyledi.\r\n\r\n“yamalı bohça” olduğunu kendileri söylüyor ama, yenisinin sıfırdan yazılmasını da istemiyorlar..\r\n\r\nyani “yamalı bohça, yenisinden iyidir” diyorlar..\r\n\r\nonlarca yaması olan bir pantolonu, yamasız bir pantolona tercih ediyorlar..\r\n\r\nyok yok “israf olmasın” diye değil, “yeni bir pantolon almaya paramız olmadığı için” değil, darbecilerin anayasasının, bir madde ile de olsa, yürürlükte olması için.\r\n\r\nyoksa yeni pantolon almak için, yani yeni anayasa için para harcamayacağız ki, milletvekilleri zaten maaşlarını alıyorlar..\r\n\r\nsadece kanunları yapsalar da aynı maaşı alacaklar, birkaç saat daha fazla çalışıp anayasayı da değiştirmiş olsalar aynı maaşı alacaklar.\r\n\r\nne yani “anayasayı değiştirdiler” diye, milletvekillerine “fazla çalışma parası” mı vereceğiz?\r\n\r\nanayasayı değiştirme girişimi, geliyor geliyor, “sizin derdiniz, darbecilerin anayasasını değiştirmek değil, laikliği değiştirmek” noktasında tıkanıyor..\r\n\r\niki yüze yakın maddesi olan anayasayı değiştirmek istiyorsunuz, adamların gözü hiçbir şey görmüyor, laikliğe takılıp kalıyorlar.\r\n\r\no zaman muhataplarımızı da rahatlatalım, biz de rahatlayalım..\r\n\r\nhodri meydan diyelim..\r\n\r\nmeclis yeni anayasayı yapar, halk da onaylarsa..\r\n\r\nbu şartla laikliği de değiştirelim..\r\n\r\nvar mısınız?\r\n\r\nyok öyle, “atatürk, halka şöyle önem verdi, böyle önem verdi” deyip…\r\n\r\n“atatürk saltanatı kaldırarak, yönetimi bir ailenin elinden alıp halka verdi” deyip..\r\n\r\n“demokrasi halk yönetimidir” deyip..\r\n\r\nsonra halkoyuna sunulacak bir anayasa değişikliğine, “olmaz, olamaz.. nayır! asla ve kata değiştirilemez, değiştirilmesi teklif dahi edilemez” demek..\r\n\r\nlaikliği yeniden yazalım..\r\n\r\nbiliyorum, kemalistler bu ifademi okuyunca, hop oturup, hop kalkacaklar.\r\n\r\nçok heyecanlanmasınlar, biraz sakin olsunlar.\r\n\r\n“laikliği değiştirelim, anayasayı yeniden düzenleyelim” dediysem, şunu önermedim:\r\n\r\n“türkiye cumhuriyeti vatandaşlarının tamamı, isteseler de istemeseler de müslüman’dırlar. beş vakit namaz kılmak zorundadırlar, kadınlar başlarını örtmek zorundadır.”\r\n\r\nböyle bir şey söyleyen yok, isteyen de yok.\r\n\r\ninancımızda temel ilke şudur: “dinde zorlama yoktur.”\r\n\r\nbu çerçevede “laikliği anayasada tekrar düzenleyelim” derken şunu öneriyoruz:\r\n\r\nhani bize laikliği özgürlük olarak öğretiyordunuz ya..\r\n\r\nşimdi, laikliği öyle tanımlayarak anayasaya koyalım.\r\n\r\n“laiklik özgürlüktür” diyelim.\r\n\r\n“laiklik, kimsenin inancına, kıyafetine, ibadetine, ibadetsizliğine karışmamaktır” diyerek laikliğin tanımına devam edelim.\r\n\r\nhodri meydan!\r\n\r\n“anayasanın değişmeyen sadece dört maddesi kaldı. bunların derdi de, darbe anayasasını değiştirmek değil, dört maddeyi değiştirmek” diyerek, laikliği korumak istediklerini söyleyenlere hodri meydan!\r\n\r\nlaikliği, özgürlük şeklinde tanımlayan sizsiniz.\r\n\r\nseçim öncesinde “laiklik özgürlüktür” diye tanımlarsınız ama seçim sonrasında, “dini semboller kamuda kullanılamaz. laiklik gereği başörtü yasaktır” diye yan çizersiniz.\r\n\r\nyan çizmemeniz için, anayasada laikliğin tam tanımını yapalım.\r\n\r\nkimsenin inancına da, ibadetine de karışılamayacağını yazalım.\r\n\r\nböylece dindarlar da rahat etsin dinsizler de rahat etsin.\r\n\r\nkemalistlerin yeni anayasa konusunda bu kadar açık bir şekilde riyakarlık yaptıkları ortadayken, saadet partisi’nin de onların dümen suyuna girip “anayasa zaten yamalı bohça, neyini değiştireceksiniz” açıklaması yapmaları, yarın bir iktidar değişikliğinde, yeniden hortlatılacak 28 şubat‘ın vebalini de, onların üzerine yıkacaktır.\r\n\r\n“tbmm, cumhurbaşkanlığı sisteminde bypass ediliyor” söyleminin peşinde koşanların, son günlerde aynı tbmm’ye, anayasayı değiştirme konusunda “yetkisi yok” eleştirisi getirmeleri, “halktan yetki almadılar” mavalı ile tbmm’yi bypass etme girişimleri de ayrı bir handikaptır.\r\n\r\nvarsın onlar, darbecilerin anayasasına razı olsunlar..\r\n\r\nmilletin seçtikleri, milletin anayasasını bir an önce yapıp, yürürlüğe koysunlar!\r\n\r\ngerekiyorsa laiklik ile ilgili maddeyi de değiştirsinler, en azından laikliğin tanımını yapıp, yanlış yorumlanmasını da önlesinler.\r\n\r\n--- spoiler ---\r\n\r\nkaynak burada"},
                new() { Content = "istemek serbest. içinden dilediğin kadar iste. ama atatürkçü gençlik olduğu sürece laiklik de baki olacaktır."},
                new() { Content = "deme lann essah mı diyin....???\r\nşok geçiriyorum...\r\nakit gazetesi yazarı demiş...\r\nulen şunu dese \" robbespierre'i hiç affetmiyoruz devrim çok farklı olabilirdi\" yeminle kalpten giderdim...\r\nbu şekli ile haber değeri yoktur...\r\n\r\ntanım : malumun ilanı olan beyan..."},
                new() { Content = "oğlum siz çatal bıçak kullanmayı bile 21.yüzyılda öğrenmiş adamlarsınız. bir şeyleri değiştirmek size çok ağır gelir.\r\n\r\n(bkz: aynen kanzi)"},
                new() { Content = "üniversitede öğretim görevlisi olan muhammet ali çağlar da şeriat şeriat diye bi tarafını parçalıyodu, umrede taciz olayından sonra laik ve demokratik türkiye cumhuriyeti'nden yardım istemişti hatırlarsanız. bunun gibi pezevenkleri en az 6 ay süreyle ortadoğunun herhangi bir yerine bıraksak aslında türkiye daha rahat bi nefes alır\r\n"},
                new() { Content = "güzel. biz zaten biliyorduk \"özgürlükçü\" adı altında istediğiniz anayasayla neyi amaçladığınızı, o güruhtan iyi ya da kötü adı bilinen biri tarafından da teyit edilmiş oldu.\r\n\r\naçık sözlülüğünü tebrik ediyorum arkadaşın. dostumuz düşmanımız netleşsin iyice."},
                new() { Content = "arap saksocularının her daim hayali olmuş, ancak ortamı tamamen ele geçirince dillendirmeye cesaret edebildikleri cümle.\r\n\r\nayrıca burada ağlayan, atarlanan ekşicilere bakmayın. kurusıkı tabanca gibi bam bam ötüyorsunuz; herifler 20 küsür senedir \"atı alıp üsküdarı geçiyor\" göt gibi bakıyorsunuz. sizin gibi boş heriflerle o kadar çok muhatap oldum ki ben artık ümidi kestim.\r\n\r\nokuyup \"aa bak hala direnen, cumhuriyet aşığı gençler var ümidim var\" diyecekler de fazla ümitlenmesinler. böyle yarak kürek atarlanmak dışında 20 senedir başka faaliyet göstermeyen, klasik gazoz türk gençliğinden bir cacık olmaz."},
                new() { Content = "laikliğin ne demek olduğunu dahi bilmeyen siyasal islamcı yazarımsı şahsın bir garip hezeyanı.\r\n"},
                new() { Content = "katatonia'nın “sky void of stars tour” kapsamında 20 ocak cumartesi günü zorlu psm ana sahnede vereceği konser.\r\n\r\nbiletler çarşamba (11.10.2023) günü 11:00'den itibaren hammer müzik, passo ve biletix'te."},
                new() { Content = "şahane bir doğum günü hediyesi olacak.\r\n"},
                new() { Content = "wowowowow. alırım bi dal.\r\n"},
                new() { Content = "ne oldu da bütün gruplar türkiye'ye gelmeye başladı\r\n"},
                new() { Content = "ulan izmire de gelin ya, gerçi anders olmadan tadı olmaz da neyse.\r\n"},
                new() { Content = "uzun zamandır çok sevdiğim bir müzisyenin/grubun konserine gidemiyorum. sebep olarak ise tabii türkiye konser kıtlığı diyebiliriz. katatonia, çok sevrek takip ettiğim ama son albümlerinden ve gidişatlarından pek keyif almadığım, yine de çok sevdiğim isveç'li gothic-progressive rock/metal grubu.\r\n\r\nsanırım en son 7 ekim'de vienna konseri gerçekleşmiş. 7 ekim vienna setlist'ine bakacak olursak eski şarkılara epey yer verilmiş. bu biraz sevindirici bi görüntü.\r\n\r\nen son 23 şubat 2013 katatonia epica istanbul konserinde izlemiştim. hasret sona ersin bari.\r\n\r\nbu arada konsere beylikdüzü/avcılar/bahçeşehir taraflarından gidecek olan varsa gece geri nası dönülür falan bi haber etsin. bu taraflara yeni taşındım ve pek bilmiyorum. gece etkinliklerinde geri dönüş sıkıntı oluyor"},
                new() { Content = "muazzam haber! sürpriz oldu. görsel\r\ngelmelerine neden olan entry: (bkz: #152545673)"},
                new() { Content = "ne zamandır içimden geçiyordu, süper oldu. konserin ayakta olması da çok iyi. oturarak metal konseri olmuyor."},
                new() { Content = "byükçekmecede vukü bulan olay\r\n\r\nyapılan açıklamanın bir kısmını buraya bırakıyorum\r\n\r\nolay sonrası saldırıyı gerçekleştirdiği belirlenen m.b.ç. (2003 doğumlu- 32 suç kaydı var) saldırıyı gerçekleştirdiği silahla birlikte yakalanarak gözaltına alınmıştır.\r\n\r\nbu it yaşından çok suç işlemiş ama dışarda\r\n\r\nkaynak"},
                new() { Content = "bunu anlayamiyorum, adamin 32 suc kaydi varsa neden hala disarda dolasabiliyor? el bebek gul bebek buyuttugumuz cocuklarin hayatlarini alabiliyor?\r\n"},
                new() { Content = "en çok da şöyle daha küçük bebesi olan görev şehitlerine üzülüyorum.\r\n\r\nşimdi karşı tarafa gelince... daha 20 yaşında bir piçsin sen kimsin de düşmanların olacak orospunun eniği. eğer öyle bir düşman biriktirecek hayatın varsa en az müebbetlik suçların olmuştur. herkes yılmaz güney, herkes kabadayı herkes mafya aq.\r\n"},
                new() { Content = "\"suça sürüklenen çocuk\" diye bir dangalaklık çıkardılar ve infaz rejimini de buna göre düzenlediler. böyle bir saçmalık olmasaydı şehit polisimiz hayatta olacaktı..."},
                new() { Content = "anasının amına geri sokulması gereken bir varlığın gerçekleştirdiği üzücü olay. geçenlerde şunu yazmıştım:\r\n\r\n(bkz: #156970995)\r\n\r\ncidden ne oluyor?\r\n\r\nedit: bir de bu vardı. malezya mı oluruz iran mı oluruz pakistan mı oluruz derken guatemala olma yolundayız sanki. asrın liderimiz sağolsun.\r\n\r\n(bkz: #156024789)"},
                new() { Content = "suçları arasında tweet atmak olmadığı için dışarıda gezebilen katil tarafından gerçekleştirilen cinayet.\r\n"},
                new() { Content = "niye etkisiz hale getirmemişler ki.\r\nkeşke tamamen etkisiz olsaymış aq evladı.\r\n"},
                new() { Content = "allah rahmet eylesin. kaybedecek bir şeyi olmayan kişilerle çatışmaya giriyorlar. sonrası bir kör kurşunla hayata gözlerini yumuyorlar. çok üzücü ne diyelim başka.\r\n"},
                new() { Content = "daha önce hiç görmediğimiz adi suçluların polis ve jandarma şehit etmesi hızla tırmanıyor. bu son 4 ayda 4. vaka sanırım, yanlış hatırlamıyorsam...\r\n\r\nbu tipler 32 sabıka ve tabancayla geziyorlar, polisi şehit edene kadar da hala içimizde yaşıyorlardı. onun için siz de bireysel silahlanmayı destekleyin."},
                new() { Content = "bu cinayetin sorumlusu o suçluyu dışarı salan, dışarıda tutan kişilerdir. bu salma hastalığı cinayet gibi ciddi sonuçlara yol açıyor ama kimin umrunda. bu olay da birkaç saat konuşulup unutulacak, serbest bırakma hastalığı devam edecek.\r\n"},
                new() { Content = "aktürk gofret\r\n\r\npaketine bakıp dandik birşey sandım, güzelmiş :)"},
                new() { Content = "dost markalı bütün ürünler. diğer markalara göre en sevdiğim o :)\r\n"},
                new() { Content = "teatone ice tea şeftali 1 lt. bu lezzeti seveceksiniz !\r\ntükenmeden alın.\r\ne hadi !"},
                new() { Content = "donmuş gıdaları :) diğer markalara göre gayet uygun tadı da güzel\r\n"},
                new() { Content = "geçen yıl şef bıçağı aldım (hani şu satıra benzeyen) piyasası, min:300 olan bir ürünü\r\n100 küsüre kapatmıştım. gayet de ergonomik\r\nkullanırken korkmuyorum. tefal."},
                new() { Content = "muhtemelen son filistin-israil çekişmesi hasebiyle 22 ekimdeki konserini ertelemiş müzik grubu.\r\n"},
                new() { Content = "pos bıyık bırakıp israil götü yalamak.\r\n"},
                new() { Content = "müzik"},
                new() { Content = "(bkz: laf ebeliği)"},
                new() { Content = "kadıköy rıhtımda halay çekmek\r\n"},
                new() { Content = "solcu olmadıkları bölümü hariç, her zaman yanlış karar vermeleridir. hkp var biraz o kurtarıyor solu. türkiye'de sol hkp gibi olur. gerisi amerikan emperyalizminin kendilerine tanımladığı alanda takılan sol liberaller."},
                new() { Content = "iki seçenekli sorularda her zaman yanlış seçeneği işaretlemek\r\n"},
                new() { Content = "malum partiyi 20 küsür senedir iktidarda tutmak.\r\n\r\nbakın şu ekonomik buhranda, ülkedeki milyonlarca başıboş mültecinin olduğu durumda, alım gücünün eksilere indiği halde bile bu adamlardan yönetimi alamamak için bildiğin ho sığırı olmak gerekli. seçim zamanı mecburen oy verdik lakin benden üçün birini alırlar, ilk seçimde malum partiye oy atacam sizi daha harder faster ziksin diye."},
                new() { Content = "sağlamak.\r\n"},
                new() { Content = "(bkz: dolce far niente)"},
                new() { Content = "sağı daha çok birleştirecek söylemlerde ve eylemlerde bulunmak. normal şartlar altında sağ partiler dönemin yaşananlar, herhangi bir sol parti döneminde yaşansa diyemiyorum çünkü bu yaşananların binde biri yaşansa zaten hükümet on defa düşer seçime gidilirdi vs. ama sağ tarafta bunca şeye rağmen yaprak kımıldamıyorsa bunun tek sebebi solun yaptığı seçimler, eylemler ve söylemlerdir."},
                new() { Content = "röportajından anladığım kadarıyla aday olmayacak fakat tevfik yamantürk'e ve hasan arat'a açık destek attı."},
                new() { Content = "sözcü tv röportajında kenan komutandan bahsetmesi enteresan,anlaşılan böyle saçma sapan işleri ve sosyal medya jargonunu zaman zaman takip etmekte,ama hoşuma gitti,tebessüm ettirdi:)"},
                new() { Content = "ahmet nur çebi maçası yetiyosa istediği tv'de karşıma çıksın demiş.\r\nlink\r\ndön başkan dön artık, özledik."},
                new() { Content = "kendisine saallayarak başkan olan anç'nin kulübü getirdiği hale bakarak anç' ye sallaması haksız olmayan eski beşiktaş başkanı.\r\n\r\nben doğuştan beşiktaşlıyım, çakma beşiktaşlı değilim gibi sözlerinin anç'ye gönderme olduğu düşünülürse sen şimdi çakma beşiktaşlı olduğunu düşündüğün birini 2. başkan yapıp 6.5 sene de yönetiminde tutup başkan olmasının önünü mü açtın o zaman diye de sorulması gerek ama."},
                new() { Content = "açıklama yapacağım diye kendi dininde ahiretliğini yakan kişi. şirk koşmuştur.\r\n\r\n’’islam'ın şartı 5, altıncısı haddini bilmek.’’\r\n\r\nkaynak: sözcü"},
                new() { Content = "abi bizim taraftarın şu eskiye dönme çabasını hiçbir zaman anlamayacağım. 2023 yılında bazı konulara quaresma geri gelsin yazanı bile var. sergen gittiğinde herkes şenol hoca gelsin dedi, şimdi tekrar sergen diyorlar. tepkiler arşa çıkıp yolladığımız, hatta \"paralar nerede?\" gibi ağır şekilde itham ettiğimiz adamı şu anda yana yakına geri isteyen bir grup var. bir kere de kan değişikliği olsun, bir kere de yeni bir şey sunun abi. 2023 biterken hala talisca hayali kurmayalım mesela, nedir bu geçmiş sevdası?\r\n\r\nkulübün kapısından asla girmemesi gereken eski başkan. diğer eskiler için de aynısını düşünüyorum."},
            };

            foreach (var entry in entries)
            {
                int topicIndex = random.Next(topics.Count);
                int userIndex = random.Next(users.Count);
                entry.Id = Guid.NewGuid();
                entry.TopicId = topics[topicIndex].Id;
                entry.UserId = users[userIndex].Id;
                entry.CreatedDate = DateTime.UtcNow;
                entry.Status = false;
            }
            return entries;
        }
    }
}