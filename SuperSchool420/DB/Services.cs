using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SuperSchool420.DB
{
    public partial class Service
    {
        public string NewImagePath
        {
            get
            {
                return $"/Assets/{MainImagePath}";
            }
        }
        public string PreviousCostVisibility
        {
            get
            {
                return Discount != null ? "Visible" : "Collapsed";
            }
        }
        public SolidColorBrush BackgroundColor
        {
            get
            {
                return Discount != null ? new SolidColorBrush(Color.FromRgb(94, 208, 189)) : new SolidColorBrush(Colors.White);
            }
        }
        public int CostWithDiscount
        {
            get
            {
                if (Discount != null)
                {
                    return (int)(Cost - ((Cost * Discount) / 100));
                }
                else
                {
                    return Cost;
                }

            }
        }

        public string CostAndDurationText
        {
            get
            {
                string result = "";
                if (Discount != 0)
                {
                    result += " ";
                }
                result += $"{CostWithDiscount} ";
                if (CostWithDiscount % 100 >= 11 && CostWithDiscount % 100 <= 14)
                {
                    result += "рублей";
                }
                else if (CostWithDiscount % 10 == 1)
                {
                    result += "рубль";
                }
                else if (CostWithDiscount % 10 >= 2 && CostWithDiscount % 10 <= 4)
                {
                    result += "рубля";
                }
                else
                {
                    result += "рублей";
                }
                result += $" за ";
                int hours = DurationInSeconds / 60;
                int minutes = DurationInSeconds % 60;
                if (hours > 0)
                {
                    result += $"{hours} ";
                    if (hours % 100 >= 11 && hours % 100 <= 14)
                    {
                        result += "минут";
                    }
                    else if (hours % 10 == 1)
                    {
                        result += "минуту";
                    }
                    else if (hours % 10 >= 2 && hours % 10 <= 4)
                    {
                        result += "минуы";
                    }
                    else
                    {
                        result += "минут";
                    }
                    result += " ";
                }
                if (hours == 0 || minutes > 0)
                {
                    result += $"{minutes} ";
                    if (minutes >= 11 && minutes <= 14)
                    {
                        result += "минут";
                    }
                    else if (minutes % 10 == 1)
                    {
                        result += "минуту";
                    }
                    else if (minutes % 10 >= 2 && minutes % 10 <= 4)
                    {
                        result += "минуты";
                    }
                    else
                    {
                        result += "минут";
                    }
                }
                return result;
            }
        }

        public string DiscountText
        {
            get
            {
                if (Discount != null)
                {
                    return $"*скидка {Discount}%";
                }
                else
                {
                    return " ";
                }

            }
        }

        public string DiscountTextVisibility
        {
            get
            {
                return Discount != 0 ? "Visible" : "Hidden";
            }
        }

    }
}
