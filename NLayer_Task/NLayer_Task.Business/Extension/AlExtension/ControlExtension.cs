using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using NLayer_Task.Model.Dtos.Categories;
using NLayer_Task.Model.Dtos.ProductDto;
using NLayer_Task.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NLayer_Task.Business.Extension.AlExtension
{
    public static class ControlExtension
    {
        public static string IdControl(this int id)
        {
            if (id == 0)
                return "değer null olamaz";

            if (id == 0)
            {
                return "değer 0 olamaz";
            }
            else if (id < 0)
            {
                return "değer negatif olamaz";
            }
            else
            {
                return null;
            }
        }
        public static string priceControl(this decimal price)
        {
            if (price == null)
            {
                return "Fiyat boş olamaz";
            }
            else if (price < 0)
            {
                return "Fiyat negatif olamaz";
            }
            else
            {
                return null;
            }
        }

        public static string TextControl(this string text)
        {
            List<char> chars = new List<char>() { '!', '?', '%', '&', '=', '\'', '(', ')', '{', '}', '"' };
            if (text == null)
            {
                return "Bu veri boş olamaz";
            }
            if (text.Length < 2)
            {
                return "Bu veri 2 harften oluşamaz";
            }
            foreach (var item in chars)
            {
                if (text.ToLower().Contains(item))
                    return $"Bu veri [{item}] karakterini içeremez";
            }
            return null;
        }
        public static string minmaxControl(this decimal min, decimal max)
        {
            if (max == 0 || min == 0)
            {
                if (max == 0)
                {
                    return "max değeri 0 olamaz";
                }
                else
                {
                    return "min değeri 0 olamaz";
                }

            }
            else if (max < min)
            {
                return "minimum değer maximum değerden büyük olamaz";
            }
            else
            {
                return null;
            }
        }
        public static string minmaxControl(this short min, short max)
        {
            if (max == 0 || min == 0)
            {
                if (max == 0)
                {
                    return "max değeri 0 olamaz";
                }
                else
                {
                    return "min değeri 0 olamaz";
                }

            }
            else if (max < min)
            {
                return "minimum değer maximum değerden büyük olamaz";
            }
            else
            {
                return null;
            }
        }

        public static string DatesControl(this short date0, short date1)
        {
            if (date0 == 0 || date0 < 0)
                return "Yıl 0 yada negatif olamaz!";
            if (date1 == 0 || date1 < 0)
                return "Yıl 0 yada negatif olamaz!";
            if (date0 >= 2030 || date0 <= 1990)
                return "Yıl 2030 dan büyük yada 1990 dan küçük olamaz!";
            if (date1 >= 2030 || date1 <= 1990)
                return "Yıl 2030 dan büyük yada 1990 dan küçük olamaz!";
            if (date0 == null)
                return "Yıl boş olamaz!";
            if (date1 == null)
                return "Yıl boş olamaz!";
            if (date0 > date1)
                return "min yıl max yıldan büyük olamaz!";

            return null;
        }

        public static string DateControl(this short date0)
        {
            if (date0 == 0 || date0 < 0)
                return "Yıl 0 yada negatif olamaz!";
            if (date0 >= 2030 || date0 <= 1990)
                return "Yıl 2030 dan büyük yada 1990 dan küçük olamaz!";
            if (date0 == null)
                return "Yıl boş olamaz!";

            return null;
        }
    }
}
