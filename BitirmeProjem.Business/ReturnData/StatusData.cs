using System;
using System.Reflection;
using Core.Utilities.Enum;
using Core.Utilities.ExtensionMethods;

namespace BitirmeProjem.Business.ReturnData
{

    class ReturnData
    {
    }

    /// <summary>
    /// Durum ve sonuç değerlerini göndermek için metotların geriye göndermesi gereken değer "StatusData" olmalıdır
    /// </summary>
    /// <typeparam name="T">Geriye döndürülecek olan class değeri</typeparam>
    public class StatusData<T>
    {
        /// <summary>
        /// Geriye döndürülecek değer
        /// Değer Type şeklinde olmalıdır ve istenirse list olarak değer girilmelidir.
        /// </summary>
        public T Entity { get; set; }

        /// <summary>
        /// Durum Değerini Enum Şeklinde Döndürmek İçin Kullanılacaktır
        /// Başarılı, Başarısız, Hatalı gibi değerler döndürecektir
        /// </summary>
        public StatusData Status { get; set; }
        public StatusData()
        {
            Status = new StatusData();
        }
    }


    /// <summary>
    /// Durum mesajı için kullanılacak olan classtır.
    /// Mesaj değeri string olarak yazılmalıdır
    /// Status değeri 
    /// </summary>
    public class StatusData
    {
        private Enums.StatusEnum _status;
        /// <summary>
        /// Verilecek Mesajın String Halidir ve Orjinal Dilinde Gönderilecektir.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Varsayılan Mesaj Döndürme Enum Yapısıdır. İçeriğe Başarılı veya Başarısız Değeri Yazılmalıdır
        /// </summary>
        public Enums.StatusEnum Status
        {
            get { return _status; }
            set
            {
                _status = value;
                
            }
        }
        /// <summary>
        /// Eğer ki "Status" içeriği haricinde bir enum döndürmek isterseniz yazdığınızsıradan bir enumuda döndürebilirsiniz
        /// </summary>
        public Enum CustomEnum { get; set; }

        /// <summary>
        /// Hata çıkma durumunda Exception sınıfından bir örnek ekleyebilirsiniz
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// MethodBase.GetCurrentMethod() Metodunu Kullanarak İsim Değeri Ekleyebilirsiniz.
        /// </summary>
        public MethodBase MethodBase { get; set; }
    }



}
