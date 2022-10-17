using System;
namespace ScamTroller.Models.PrePostSEO
{

    public class Credit
    {
        public string Type;
        public string Number;
        public string Name;
        public string ExpirationDate;
        public DateTime ExpirationDateAsDate
        {
            get
            {
                if(string.IsNullOrEmpty(ExpirationDate))
                {
                    return DateTime.MinValue;
                }
                return new DateTime(2000 + int.Parse(ExpirationDate.Substring(3, 2)), int.Parse(ExpirationDate.Substring(0, 2)), 1);
            }
        }

        public Credit()
        {

        }

    }
}

