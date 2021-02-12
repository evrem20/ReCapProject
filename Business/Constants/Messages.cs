using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string CarNameInvalid = "Araba markası geçersiz.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarUpdated = "Araba güncellendi.";
        public static string CarListed = "Arabalar listelendi.";
        public static string MaintenanceTime = "Şuan bakım zamanıdır.";
        public static string CarPropertyListed = "Arabanın özellikleri listelendi.";
        public static string CarBrandIdListed = "Seçtiğiniz markaya göre arabalar listelendi.";
        public static string CarColorIdListed = "Seçtiğiniz renge göre arabalar listelendi.";
        public static string CarDailyPriceListed = "Arabalar seçtiğiniz fiyat aralığına göre listelendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated ="Marka güncellendi";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi";
        public static string RentalAddedError = "Araç henüz teslim edilmemiştir.";
        public static string RentalAdded = "Araç kiralandı.";
    }
}

