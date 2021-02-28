using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };

        public static string CarAdded = "Araba eklendi.";
        public static string CarNameInvalid = "Araba markası geçersizdir.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarUpdated = "Araba güncellendi.";
        public static string CarsListed = "Arabalar listelendi.";
        public static string MaintenanceTime = "Şuan bakım zamanıdır.";
        public static string CarPropertyListed = "Seçtiğiniz arabanın özellikleri listelendi.";
        public static string CarBrandIdListed = "Seçtiğiniz markaya göre arabalar listelendi.";
        public static string CarColorIdListed = "Seçtiğiniz renge göre arabalar listelendi.";
        public static string CarDailyPriceListed = "Arabalar seçtiğiniz fiyat aralığına göre listelendi.";

        public static string BrandNameInvalid = "Marka ismi geçersizdir.";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated ="Marka güncellendi";
        public static string BrandsListed = "Markalar listelendi";
        public static string BrandPropertyListed = "Seçtiğiniz markanın özellikleri listelendi.";

        public static string ColorAdded = "Renk eklendi.";
        public static string ColorNameInvalid = "Renk ismi geçersizdir.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorsListed = "Renkler listelendi";
        public static string ColorPropertyListed = "Seçtiğiniz rengin özellikleri listelendi.";


        public static string RentalAddedError = "Araç henüz teslim edilmemiştir.";
        public static string RentalAdded = "Araç kiralandı.";
        public static string RentalDeleted ="Kiralama bilgileri silindi";
        public static string RentalUpdated = "Kiralama bilgileri güncellendi";
        public static string RentalsListed = "Kiralamalar listelendi";
        public static string RentalPropertyListed = "Seçtiğiniz kiralamanın özellikleri listelendi.";

        public static string CompanyNameInvalid = "Şirket ismi geçersizdir.";
        internal static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomersListed = "Müşteriler listelendi.";
        public static string CustomerPropertyListed = "Seçtiğiniz müşterinin özellikleri listelendi.";

        public static string UserNameInvalid = "Kullanıcı ismi geçersizdir.";
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UsersListed = "Kullanıcılar listelendi";
        public static string UserPropertyListed = "Seçtiğiniz kullanıcının özellikleri listelendi.";
        internal static string ReturnedRental;
        public static string CarCountOfBrandError = "Bir markadan en fazla 20 araba olabilir.";
        public static string CarNameAlreadyExists= "Bu araba ismine sahip bir araba sistemde vardır.";
        public static string CarImageDeleted ="Araba resmi silindi.";
        public static string CarImageListed="Araba resimleri listelendi";
        public static string CarImageListedCarId = "Seçilen arabanın resimleri listelendi.";
        public static string CarImageAdd = "Araba resmi eklendi.";
        public static string CarImageUpdate="Araba resmi güncellendi.";
        public static string FailAddedImageLimit="Resim ekleme sınırına ulaşmıştır.";
        public static string MustPicture="Resim göndermelisiniz.";
    }


}

